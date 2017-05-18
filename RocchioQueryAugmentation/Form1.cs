using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Diagnostics;

namespace RocchioQueryAugmentation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WebSearcher s = new WebSearcher();
            string query = "gates";
            string temp = s.GetBodyContentFromUrl("http://asdf.com");
            List<Document> searchResults = s.GetTopSearchResults(query, 10);
            Indexer indexer = Indexer.Instance;
            indexer.ClearData();
            indexer.IndexDocuments(searchResults);
            RocchioAugmenter rocchio = RocchioAugmenter.Instance;
            rocchio.SetQuery(query);
            var cq = new List<string>();
            cq.Add(query);
            var rel = new List<int>();
            var nonrel = new List<int>();
            foreach (var item in searchResults)
            {
                if (item.IsRelevant)
                    rel.Add(item.Id);
                else
                    nonrel.Add(item.Id);
            }
            var newq = rocchio.Rocchio(cq, searchResults, rel, nonrel);

             textBox1.Text = "";
        }
    }
}
