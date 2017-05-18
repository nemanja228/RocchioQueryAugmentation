using System;
using System.Collections.Generic;
using System.Linq;


namespace RocchioQueryAugmentation
{
    public class Indexer
    {
        private Dictionary<string, Dictionary<int, List<int>>> invertedIndex;
        private Dictionary<string, int> termFrequencies;
        private static Indexer instance;
        private static char[] delimiters = { '[', ' ', '.', '=', '?', '!', ':', '@', '<', '>', '(', ')', '"', '-', ';', '\'', '&', '_', '\\', '{', '}', '|', '[', ']', '\n', '\t' };

        //private ConcurrentQueue<Document> queue;
        //private Thread workerThread; 

        public Dictionary<string, Dictionary<int, List<int>>> InvertedIndex
        {
            get
            {
                return invertedIndex;
            }
        }

        public Dictionary<string, int> TermFrequencies
        {
            get
            {
                return termFrequencies;
            }
        }

        public static Indexer Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new Indexer();
                }

                return instance;
            }
        }

        private Indexer()
        {
            ClearData();
        }

        public void ClearData()
        {
            //List<int> tmp = new List<int>();
            //Dictionary<int, List<int>> tmpD = new Dictionary<int, List<int>>();
            //tmpD.Add(1, tmp);
            invertedIndex = new Dictionary<string, Dictionary<int, List<int>>>();
            //invertedIndex.Add("asdf", tmpD);
            termFrequencies = new Dictionary<string, int>() as Dictionary<string, int>;
            //queue = new ConcurrentQueue<Document>();
        }

        public void IndexDocuments(List<Document> documents)
        {
            foreach (var doc in documents)
            {
                doc.TfWeights = new Dictionary<string, int>() as Dictionary<string, int>;
                string bodyContent = new WebSearcher().GetBodyContentFromUrl(doc.Url);
                doc.BodyContent = bodyContent != null ? bodyContent : doc.Summary;
                List<string> terms = new List<string>();
                string[] tokens = doc.BodyContent.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < tokens.Length; i++)
                {
                    tokens[i] = tokens[i].ToLower();
                    if (String.IsNullOrWhiteSpace(tokens[i]) || tokens[i].Length < 2 || tokens[i].Length > 12 || tokens[i].All(char.IsDigit) || !tokens[i].All(char.IsLetterOrDigit))
                    {
                        continue;
                    }
                    terms.Add(tokens[i]);
                    if (!termFrequencies.ContainsKey(tokens[i]))
                    {
                        termFrequencies.Add(tokens[i], 1);
                    }
                    else
                    {
                        termFrequencies[tokens[i]]++;
                    }
                    if (!invertedIndex.ContainsKey(tokens[i]))
                    {
                        invertedIndex[tokens[i]] = new Dictionary<int, List<int>>() as Dictionary<int, List<int>>;
                    }
                    if (!invertedIndex[tokens[i]].ContainsKey(doc.Id))
                    {
                        invertedIndex[tokens[i]][doc.Id] = new List<int>() as List<int>;
                    }
                    invertedIndex[tokens[i]][doc.Id].Add(i);
                    if (!doc.TfWeights.ContainsKey(tokens[i]))
                    {
                        doc.TfWeights.Add(tokens[i], 0);
                    }
                    doc.TfWeights[tokens[i]]++;

                }
            }

            
        }

    }
}
