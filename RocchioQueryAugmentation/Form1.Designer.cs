namespace RocchioQueryAugmentation
{
    partial class RocchioForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbQuery = new System.Windows.Forms.GroupBox();
            this.lblNum = new System.Windows.Forms.Label();
            this.comboBoxNum = new System.Windows.Forms.ComboBox();
            this.comboBoxPrecision = new System.Windows.Forms.ComboBox();
            this.tbQuery = new System.Windows.Forms.TextBox();
            this.lblPrecision = new System.Windows.Forms.Label();
            this.lblQuery = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.gbSearch = new System.Windows.Forms.GroupBox();
            this.btnNo = new System.Windows.Forms.Button();
            this.btnYes = new System.Windows.Forms.Button();
            this.rtbSummary = new System.Windows.Forms.RichTextBox();
            this.tbUrl = new System.Windows.Forms.TextBox();
            this.tbTitle = new System.Windows.Forms.TextBox();
            this.lblIsRelevant = new System.Windows.Forms.Label();
            this.lblSummary = new System.Windows.Forms.Label();
            this.lblUrl = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.gbInfo = new System.Windows.Forms.GroupBox();
            this.lblCurrentPrecision = new System.Windows.Forms.Label();
            this.lblCurrentQuery = new System.Windows.Forms.Label();
            this.lblCurrentPrec = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.lblCurrentQ = new System.Windows.Forms.Label();
            this.gbQuery.SuspendLayout();
            this.gbSearch.SuspendLayout();
            this.gbInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbQuery
            // 
            this.gbQuery.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.gbQuery.Controls.Add(this.lblNum);
            this.gbQuery.Controls.Add(this.comboBoxNum);
            this.gbQuery.Controls.Add(this.comboBoxPrecision);
            this.gbQuery.Controls.Add(this.tbQuery);
            this.gbQuery.Controls.Add(this.lblPrecision);
            this.gbQuery.Controls.Add(this.lblQuery);
            this.gbQuery.Controls.Add(this.btnSearch);
            this.gbQuery.Location = new System.Drawing.Point(16, 12);
            this.gbQuery.Name = "gbQuery";
            this.gbQuery.Size = new System.Drawing.Size(323, 156);
            this.gbQuery.TabIndex = 0;
            this.gbQuery.TabStop = false;
            this.gbQuery.Text = "Query:";
            // 
            // lblNum
            // 
            this.lblNum.AutoSize = true;
            this.lblNum.Location = new System.Drawing.Point(8, 46);
            this.lblNum.Name = "lblNum";
            this.lblNum.Size = new System.Drawing.Size(172, 13);
            this.lblNum.TabIndex = 6;
            this.lblNum.Text = "Number of search results to return: \r\n";
            // 
            // comboBoxNum
            // 
            this.comboBoxNum.FormattingEnabled = true;
            this.comboBoxNum.Location = new System.Drawing.Point(186, 43);
            this.comboBoxNum.Name = "comboBoxNum";
            this.comboBoxNum.Size = new System.Drawing.Size(131, 21);
            this.comboBoxNum.TabIndex = 5;
            this.comboBoxNum.SelectedIndexChanged += new System.EventHandler(this.comboBoxNum_SelectedIndexChanged);
            // 
            // comboBoxPrecision
            // 
            this.comboBoxPrecision.FormattingEnabled = true;
            this.comboBoxPrecision.Location = new System.Drawing.Point(186, 80);
            this.comboBoxPrecision.Name = "comboBoxPrecision";
            this.comboBoxPrecision.Size = new System.Drawing.Size(131, 21);
            this.comboBoxPrecision.TabIndex = 4;
            this.comboBoxPrecision.SelectedIndexChanged += new System.EventHandler(this.comboBoxPrecision_SelectedIndexChanged);
            // 
            // tbQuery
            // 
            this.tbQuery.Location = new System.Drawing.Point(186, 13);
            this.tbQuery.Name = "tbQuery";
            this.tbQuery.Size = new System.Drawing.Size(131, 20);
            this.tbQuery.TabIndex = 3;
            // 
            // lblPrecision
            // 
            this.lblPrecision.AutoSize = true;
            this.lblPrecision.Location = new System.Drawing.Point(8, 83);
            this.lblPrecision.Name = "lblPrecision";
            this.lblPrecision.Size = new System.Drawing.Size(121, 13);
            this.lblPrecision.TabIndex = 2;
            this.lblPrecision.Text = "Precision goal (percent):";
            // 
            // lblQuery
            // 
            this.lblQuery.AutoSize = true;
            this.lblQuery.Location = new System.Drawing.Point(6, 16);
            this.lblQuery.Name = "lblQuery";
            this.lblQuery.Size = new System.Drawing.Size(126, 13);
            this.lblQuery.TabIndex = 1;
            this.lblQuery.Text = "Enter a query (one term) :";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(186, 127);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(131, 23);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // gbSearch
            // 
            this.gbSearch.Controls.Add(this.btnNo);
            this.gbSearch.Controls.Add(this.btnYes);
            this.gbSearch.Controls.Add(this.rtbSummary);
            this.gbSearch.Controls.Add(this.tbUrl);
            this.gbSearch.Controls.Add(this.tbTitle);
            this.gbSearch.Controls.Add(this.lblIsRelevant);
            this.gbSearch.Controls.Add(this.lblSummary);
            this.gbSearch.Controls.Add(this.lblUrl);
            this.gbSearch.Controls.Add(this.lblTitle);
            this.gbSearch.Enabled = false;
            this.gbSearch.Location = new System.Drawing.Point(345, 12);
            this.gbSearch.Name = "gbSearch";
            this.gbSearch.Size = new System.Drawing.Size(327, 297);
            this.gbSearch.TabIndex = 1;
            this.gbSearch.TabStop = false;
            this.gbSearch.Text = "Search results:";
            this.gbSearch.Visible = false;
            // 
            // btnNo
            // 
            this.btnNo.Location = new System.Drawing.Point(170, 266);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(75, 23);
            this.btnNo.TabIndex = 8;
            this.btnNo.Text = "No";
            this.btnNo.UseVisualStyleBackColor = true;
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // btnYes
            // 
            this.btnYes.Location = new System.Drawing.Point(72, 266);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(75, 23);
            this.btnYes.TabIndex = 7;
            this.btnYes.Text = "Yes";
            this.btnYes.UseVisualStyleBackColor = true;
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // rtbSummary
            // 
            this.rtbSummary.Location = new System.Drawing.Point(6, 110);
            this.rtbSummary.Name = "rtbSummary";
            this.rtbSummary.ReadOnly = true;
            this.rtbSummary.Size = new System.Drawing.Size(315, 128);
            this.rtbSummary.TabIndex = 6;
            this.rtbSummary.Text = "";
            // 
            // tbUrl
            // 
            this.tbUrl.Location = new System.Drawing.Point(6, 71);
            this.tbUrl.Name = "tbUrl";
            this.tbUrl.ReadOnly = true;
            this.tbUrl.Size = new System.Drawing.Size(315, 20);
            this.tbUrl.TabIndex = 5;
            // 
            // tbTitle
            // 
            this.tbTitle.Location = new System.Drawing.Point(6, 32);
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.ReadOnly = true;
            this.tbTitle.Size = new System.Drawing.Size(315, 20);
            this.tbTitle.TabIndex = 4;
            // 
            // lblIsRelevant
            // 
            this.lblIsRelevant.AutoSize = true;
            this.lblIsRelevant.Location = new System.Drawing.Point(69, 250);
            this.lblIsRelevant.Name = "lblIsRelevant";
            this.lblIsRelevant.Size = new System.Drawing.Size(176, 13);
            this.lblIsRelevant.TabIndex = 3;
            this.lblIsRelevant.Text = "Is this result relevant for your query?";
            // 
            // lblSummary
            // 
            this.lblSummary.AutoSize = true;
            this.lblSummary.Location = new System.Drawing.Point(132, 94);
            this.lblSummary.Name = "lblSummary";
            this.lblSummary.Size = new System.Drawing.Size(53, 13);
            this.lblSummary.TabIndex = 2;
            this.lblSummary.Text = "Summary:";
            // 
            // lblUrl
            // 
            this.lblUrl.AutoSize = true;
            this.lblUrl.Location = new System.Drawing.Point(144, 55);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(32, 13);
            this.lblUrl.TabIndex = 1;
            this.lblUrl.Text = "URL:";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(144, 16);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(30, 13);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Title:";
            // 
            // gbInfo
            // 
            this.gbInfo.Controls.Add(this.lblCurrentPrecision);
            this.gbInfo.Controls.Add(this.lblCurrentQuery);
            this.gbInfo.Controls.Add(this.lblCurrentPrec);
            this.gbInfo.Controls.Add(this.lblStatus);
            this.gbInfo.Controls.Add(this.lblMessage);
            this.gbInfo.Controls.Add(this.lblCurrentQ);
            this.gbInfo.Location = new System.Drawing.Point(16, 176);
            this.gbInfo.Name = "gbInfo";
            this.gbInfo.Size = new System.Drawing.Size(323, 134);
            this.gbInfo.TabIndex = 2;
            this.gbInfo.TabStop = false;
            this.gbInfo.Text = "Info:";
            // 
            // lblCurrentPrecision
            // 
            this.lblCurrentPrecision.AutoSize = true;
            this.lblCurrentPrecision.Location = new System.Drawing.Point(120, 113);
            this.lblCurrentPrecision.Name = "lblCurrentPrecision";
            this.lblCurrentPrecision.Size = new System.Drawing.Size(0, 13);
            this.lblCurrentPrecision.TabIndex = 5;
            // 
            // lblCurrentQuery
            // 
            this.lblCurrentQuery.AutoSize = true;
            this.lblCurrentQuery.Location = new System.Drawing.Point(120, 86);
            this.lblCurrentQuery.Name = "lblCurrentQuery";
            this.lblCurrentQuery.Size = new System.Drawing.Size(0, 13);
            this.lblCurrentQuery.TabIndex = 4;
            // 
            // lblCurrentPrec
            // 
            this.lblCurrentPrec.AutoSize = true;
            this.lblCurrentPrec.Location = new System.Drawing.Point(19, 113);
            this.lblCurrentPrec.Name = "lblCurrentPrec";
            this.lblCurrentPrec.Size = new System.Drawing.Size(90, 13);
            this.lblCurrentPrec.TabIndex = 3;
            this.lblCurrentPrec.Text = "Current Precision:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(19, 42);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(40, 13);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "Status:";
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblMessage.Location = new System.Drawing.Point(65, 40);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(42, 17);
            this.lblMessage.TabIndex = 1;
            this.lblMessage.Text = "Idle...";
            // 
            // lblCurrentQ
            // 
            this.lblCurrentQ.AutoSize = true;
            this.lblCurrentQ.Location = new System.Drawing.Point(19, 86);
            this.lblCurrentQ.Name = "lblCurrentQ";
            this.lblCurrentQ.Size = new System.Drawing.Size(75, 13);
            this.lblCurrentQ.TabIndex = 0;
            this.lblCurrentQ.Text = "Current Query:";
            // 
            // RocchioForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(621, 322);
            this.Controls.Add(this.gbInfo);
            this.Controls.Add(this.gbSearch);
            this.Controls.Add(this.gbQuery);
            this.MaximumSize = new System.Drawing.Size(704, 360);
            this.MinimumSize = new System.Drawing.Size(360, 360);
            this.Name = "RocchioForm";
            this.Text = "Rocchio Query Augmentation";
            this.gbQuery.ResumeLayout(false);
            this.gbQuery.PerformLayout();
            this.gbSearch.ResumeLayout(false);
            this.gbSearch.PerformLayout();
            this.gbInfo.ResumeLayout(false);
            this.gbInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbQuery;
        private System.Windows.Forms.Label lblNum;
        private System.Windows.Forms.ComboBox comboBoxNum;
        private System.Windows.Forms.ComboBox comboBoxPrecision;
        private System.Windows.Forms.TextBox tbQuery;
        private System.Windows.Forms.Label lblPrecision;
        private System.Windows.Forms.Label lblQuery;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox gbSearch;
        private System.Windows.Forms.Label lblIsRelevant;
        private System.Windows.Forms.Label lblSummary;
        private System.Windows.Forms.Label lblUrl;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox tbUrl;
        private System.Windows.Forms.TextBox tbTitle;
        private System.Windows.Forms.Button btnNo;
        private System.Windows.Forms.Button btnYes;
        private System.Windows.Forms.RichTextBox rtbSummary;
        private System.Windows.Forms.GroupBox gbInfo;
        private System.Windows.Forms.Label lblCurrentPrec;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label lblCurrentQ;
        private System.Windows.Forms.Label lblCurrentPrecision;
        private System.Windows.Forms.Label lblCurrentQuery;
    }
}

