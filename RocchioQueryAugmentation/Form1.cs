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
using System.Globalization;

namespace RocchioQueryAugmentation
{
    public partial class RocchioForm : Form
    {
        private static string VALIDATION_FAILED = "Improper query, try again...";
        private static string VALIDATION_SUCCESSFUL = "Query validation succeeded!";
        private static string WEB_RETRIEVAL = "Retrieving results from web...";
        private static string INDEXING = "Indexing documents...";
        private static string ROCCHIO = "Calculating Rocchio vector...";

        private Indexer indexer;
        private RocchioAugmenter rocchio;
        private WebSearcher webSearcher;
        private List<Document> documentList;
        private int searchResultCounter;
        private List<string> currentQuery;
        private int currentPrecision;
        private int requiredPrecision;
        private int numResults = 10;

        public RocchioForm()
        {
            InitializeComponent();
            indexer = Indexer.Instance;
            rocchio = RocchioAugmenter.Instance;
            webSearcher = new WebSearcher();
            for (int i = 1; i < 3; i++)
            {
                comboBoxNum.Items.Add(i * 10);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string query = tbQuery.Text;
            
            if(String.IsNullOrWhiteSpace(query) || query.Length < 2 || !query.All(char.IsLetterOrDigit))
            {
                lblMessage.ForeColor = Color.MediumVioletRed;
                lblMessage.Text = VALIDATION_FAILED;
                Refresh();
            }
            else
            {
                lblMessage.ForeColor = Color.Green;
                lblMessage.Text = VALIDATION_SUCCESSFUL;
                Refresh();
            }

            string[] tmpArray = query.Split(new char[] { ' ', '\t', '\n' });

            currentQuery = new List<string>();
            query = tmpArray[0];
            currentQuery.Add(query);
            RetrieveFromWeb();

        }


        private void NextSearchResult()
        {
            searchResultCounter++;

            if (searchResultCounter < documentList.Count)
            {
                tbTitle.Text = documentList[searchResultCounter].Title;
                tbUrl.Text = documentList[searchResultCounter].Url;
                rtbSummary.Text = documentList[searchResultCounter].Summary;
            }
            else
            {
                gbSearch.Enabled = false;
                gbSearch.Visible = false;
                IndexAndRocchio();
            }
        }
        private void ResetForm()
        {
            tbQuery.Text = "";
            tbUrl.Text = "";
            tbTitle.Text = "";
            rtbSummary.Text = "";
            lblCurrentPrecision.Text = "";
            lblCurrentQuery.Text = "";
            gbQuery.Enabled = true;
            documentList = null;
            searchResultCounter = 0;
            currentPrecision = 0;
            comboBoxNum.SelectedIndex = 0;
            comboBoxPrecision.Items.Clear();
            Refresh();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            documentList[searchResultCounter].IsRelevant = true;
            NextSearchResult();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            documentList[searchResultCounter].IsRelevant = false;
            NextSearchResult();
        }

        private void IndexAndRocchio()
        {
            List<int> rel = new List<int>();
            List<int> nonrel = new List<int>();
            currentPrecision = 0;
            foreach (var doc in documentList)
            {
                if (doc.IsRelevant)
                {
                    currentPrecision++;
                    rel.Add(doc.Id);
                }
                else
                    nonrel.Add(doc.Id);
            }

            lblCurrentPrecision.Text = currentPrecision.ToString();

            if (currentPrecision < requiredPrecision)
            {
                lblMessage.Text = INDEXING;
                Refresh();
                indexer.ClearData();
                indexer.IndexDocuments(documentList);
                lblMessage.Text = ROCCHIO;
                if (currentQuery.Count == 1)
                    rocchio.SetQuery(currentQuery[0]);

                currentQuery = rocchio.Rocchio(currentQuery, documentList, rel, nonrel);
                lblCurrentQuery.Text = currentQuery.Aggregate((i, j) => i + " " + j);
                RetrieveFromWeb();
            }
            
            else
            {
                lblMessage.Text = "Target precision achieved!";
                ResetForm();
            }
        }

        private void RetrieveFromWeb()
        {
            lblMessage.ForeColor = Color.DeepSkyBlue;
            lblMessage.Text = WEB_RETRIEVAL;
            Refresh();

            string query = currentQuery.Aggregate((i, j) => i + " " + j);
            lblCurrentQuery.Text = query;
            documentList = webSearcher.GetTopSearchResults(query, numResults);
            if (documentList == null)
            {
                ResetForm();
                return;
            }

            gbQuery.Enabled = false;
            searchResultCounter = -1;
            gbSearch.Visible = true;
            gbSearch.Enabled = true;
            NextSearchResult();          
        }

        private void comboBoxNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            int num = (int)comboBoxNum.SelectedItem;
            numResults = num;
            comboBoxPrecision.Items.Clear();
            for (int i = 1; i <= num; i++)
            {
                comboBoxPrecision.Items.Add(i);
            }
        }

        private void comboBoxPrecision_SelectedIndexChanged(object sender, EventArgs e)
        {
            requiredPrecision = (int) comboBoxPrecision.SelectedItem;
        }


    }
}
