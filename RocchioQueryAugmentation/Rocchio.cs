using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocchioQueryAugmentation
{
    public class RocchioAugmenter
    {
        private static RocchioAugmenter instance;
        private Dictionary<string, double> query;
        private static int DEFAULT_NUM_OF_TOP_RESULTS = 2;
        private static double A = 0.0;
        private static double B = 1.0;
        private static double C = 1.0;
        private static string[] wordsToSkip = { "about", "above", "after", "again", "against", "all", "am", "an", "and", "any", "are", "aren", "as", "at",
            "be", "because", "been", "before", "being", "below", "between", "both", "but", "by", "can", "cannot", "could", "couldn", "did", "didn", "do",
            "does", "doesn", "doing", "don", "down", "during", "each", "few", "for", "from", "further", "had", "hadn", "has", "hasn", "have", "haven", "having",
            "he", "her", "here", "here", "hers", "herself", "him", "himself", "his", "how", "how", "if", "in", "into", "is", "isn", "it", "its", "itself", "let",
            "me", "more", "most", "mustn", "my", "myself", "no", "nor", "not", "of", "off", "on", "once", "only", "or", "other", "ought", "our", "ours", "ourselves",
            "out", "over", "own", "same", "shan", "she", "should", "shouldn", "so", "some", "such", "than", "that", "the", "their", "theirs", "them", "themselves",
            "then", "there", "these", "they", "this", "those", "through", "to", "too", "under", "until", "up", "very", "was", "wasn", "we", "were", "weren", "what",
            "when", "where", "which", "while", "who", "whom", "why", "with", "would", "wouldn", "you", "your", "yours", "yourself", "yourselves" };


    public static RocchioAugmenter Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RocchioAugmenter();
                }

                return instance;
            }
        }

        private RocchioAugmenter()
        {
        }

        public void SetQuery(string originalQuery)
        {
            query = new Dictionary<string, double>();
            query.Add(originalQuery, 1.0);
        }

        public List<string> Rocchio(List<string> currentQuery, List<Document> documents, List<int> relevant, List<int> nonRelevant)
        {
            var invertedIndex = Indexer.Instance.InvertedIndex;
            Dictionary<string, double> weights = new Dictionary<string, double>();
            Dictionary<string, double> rWeights = new Dictionary<string, double>();
            Dictionary<string, double> nrWeights = new Dictionary<string, double>();

            foreach (var kvp in invertedIndex)
            {
                weights[kvp.Key] = 0.0;
            }

            foreach (var rDoc in relevant)
            {
                var doc = documents[rDoc];
                foreach (var term in doc.TfWeights)
                {
                    if(!rWeights.ContainsKey(term.Key))
                    {
                        rWeights.Add(term.Key, 0.0);
                    }
                    else
                    {
                        rWeights[term.Key] += doc.TfWeights[term.Key];
                    }
                }
            }

            foreach (var nrDoc in nonRelevant)
            {
                var doc = documents[nrDoc];
                foreach (var term in doc.TfWeights)
                {
                    if (!nrWeights.ContainsKey(term.Key))
                    {
                        nrWeights.Add(term.Key, 0.0);
                    }
                    else
                    {
                        nrWeights[term.Key] += doc.TfWeights[term.Key];
                    }
                }
            }

            foreach (var termKvp in invertedIndex)
            {
                var term = termKvp.Key;
                double idf = Math.Log10(documents.Count / (double)invertedIndex[term].Count);

                foreach (var docId in invertedIndex[term].Keys)
                {
                    if (documents.Where(d => d.Id == docId).Select(d => d).FirstOrDefault().IsRelevant)
                    {
                        weights[term] += B * idf * (rWeights[term] / relevant.Count);
                    }
                    else
                    {
                        weights[term] -= C * idf * (nrWeights[term] / nonRelevant.Count);
                    }
                }

                if (query.ContainsKey(term))
                {
                    query[term] = A * query[term] + weights[term];
                }
                else if(weights[term] > 0)
                {
                    query.Add(term, weights[term]);
                }

            }

            return GetTopTerms(currentQuery, query, DEFAULT_NUM_OF_TOP_RESULTS);
        }

        private List<string> GetTopTerms(List<string> currentQueryTerms, Dictionary<string, double> queryWeights, int numOfResults)
        {
            Porter2 porterStemmer = new Porter2();
            List<string> newQueryTerms = new List<string>();
            newQueryTerms.AddRange(currentQueryTerms);
            var dictionaryList = queryWeights.ToList();
            var sortedDictionary = dictionaryList.Select(kvp => kvp).OrderByDescending(kvp => kvp.Value).ToList();
            int i = 0;
            foreach (var term in sortedDictionary)
            {
                if (wordsToSkip.Contains(term.Key) || currentQueryTerms.Contains(term.Key) || currentQueryTerms.Contains(porterStemmer.stem(term.Key)))
                {
                    continue;
                }
                newQueryTerms.Add(term.Key);
                currentQueryTerms.Add(porterStemmer.stem(term.Key));
                i++;
                if (i >= numOfResults)
                    break;
            }
            return newQueryTerms;
        }
    }
}
