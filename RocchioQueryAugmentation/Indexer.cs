using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Threading;

namespace RocchioQueryAugmentation
{
    public class Indexer
    {
        private IDictionary<string, IDictionary<string, IList<int>>> invertedIndex;
        private IDictionary<string, int> termFrequencies;
        private static Indexer instance;
        private static char[] delimiters = { '[', ' ', '.', '=', '?', '!', ':', '@', '<', '>', '(', ')', '"', '-', ';', '\'', '&', '_', '\\', '{', '}', '|', '[', ']', '\n', '\t' }; 
        private ConcurrentQueue<Document> queue;
        private Thread workerThread; 
       
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

        private Indexer() { }

        public void ClearData()
        {
            invertedIndex = new Dictionary<string, Dictionary<string, List<int>>>() as IDictionary<string, IDictionary<string, IList<int>>>;
            termFrequencies = new Dictionary<string, int>() as IDictionary<string, int>;
            queue = new ConcurrentQueue<Document>();
        }

        public void IndexDocuments()
        {
            Document doc;
            if(!queue.TryDequeue(out doc))
            {
                return;
            }
            doc.TfWeights = new List<int>();
            string bodyContent = new WebSearcher().GetBodyContentFromUrl(doc.Url);
            doc.BodyContent = bodyContent != null ? bodyContent : doc.Summary;
            List<string> terms = new List<string>();
            string[] tokens = doc.BodyContent.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < tokens.Length; i++)
            {
                tokens[i] = tokens[i].ToLower();
                if(tokens[i] == null || tokens[i].Length < 2 || tokens[i].Length > 12 || tokens[i].All(char.IsDigit))
                {
                    continue;
                }
                terms.Add(tokens[i]);
                if(!termFrequencies.ContainsKey(tokens[i]))
                {
                    termFrequencies.Add(tokens[i], 1);
                }
                else
                {
                    termFrequencies[tokens[i]]++;
                }

            }
        }





    }
}
