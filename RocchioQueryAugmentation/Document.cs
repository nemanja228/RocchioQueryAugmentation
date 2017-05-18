using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocchioQueryAugmentation
{
    public class Document
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }

        public string Summary { get; set; }

        public bool IsRelevant { get; set; }

        public string BodyContent { get; set; }

        public Dictionary<string, int> TfWeights { get; set; }

        public Document(string title, string url, string summary)
        {
            Id = -1;
            Title = title;
            Url = url;
            Summary = summary;
            IsRelevant = false;
            BodyContent = null;
            TfWeights = null;
        }
    }
}
