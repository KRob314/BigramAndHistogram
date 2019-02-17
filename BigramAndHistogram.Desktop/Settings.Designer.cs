namespace BigramAndHistogram.Desktop
{
    partial class Settings
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
            this.cbPunctuation = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbNumbers = new System.Windows.Forms.CheckBox();
            this.cbShowChart = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbOrderList = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbPunctuation
            // 
            this.cbPunctuation.AutoSize = true;
            this.cbPunctuation.Location = new System.Drawing.Point(22, 28);
            this.cbPunctuation.Name = "cbPunctuation";
            this.cbPunctuation.Size = new System.Drawing.Size(83, 17);
            this.cbPunctuation.TabIndex = 0;
            this.cbPunctuation.Text = "Punctuation";
            this.cbPunctuation.UseVisualStyleBackColor = true;
            this.cbPunctuation.CheckedChanged += new System.EventHandler(this.cbPunctuation_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbNumbers);
            this.groupBox1.Controls.Add(this.cbPunctuation);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 175);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filters";
            // 
            // cbNumbers
            // 
            this.cbNumbers.AutoSize = true;
            this.cbNumbers.Location = new System.Drawing.Point(22, 52);
            this.cbNumbers.Name = "cbNumbers";
            this.cbNumbers.Size = new System.Drawing.Size(68, 17);
            this.cbNumbers.TabIndex = 1;
            this.cbNumbers.Text = "Numbers";
            this.cbNumbers.UseVisualStyleBackColor = true;
            this.cbNumbers.CheckedChanged += new System.EventHandler(this.cbNumbers_CheckedChanged);
            // 
            // cbShowChart
            // 
            this.cbShowChart.AutoSize = true;
            this.cbShowChart.Location = new System.Drawing.Point(6, 28);
            this.cbShowChart.Name = "cbShowChart";
            this.cbShowChart.Size = new System.Drawing.Size(81, 17);
            this.cbShowChart.TabIndex = 2;
            this.cbShowChart.Text = "Show Chart";
            this.cbShowChart.UseVisualStyleBackColor = true;
            this.cbShowChart.CheckedChanged += new System.EventHandler(this.cbShowChart_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbOrderList);
            this.groupBox3.Controls.Add(this.cbShowChart);
            this.groupBox3.Location = new System.Drawing.Point(244, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 175);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Other";
            // 
            // cbOrderList
            // 
            this.cbOrderList.AutoSize = true;
            this.cbOrderList.Location = new System.Drawing.Point(6, 52);
            this.cbOrderList.Name = "cbOrderList";
            this.cbOrderList.Size = new System.Drawing.Size(106, 17);
            this.cbOrderList.TabIndex = 3;
            this.cbOrderList.Text = "Order Bigram List";
            this.cbOrderList.UseVisualStyleBackColor = true;
            this.cbOrderList.CheckedChanged += new System.EventHandler(this.cbOrderList_CheckedChanged);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 277);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "Settings";
            this.Text = "Settings";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox cbPunctuation;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbNumbers;
        private System.Windows.Forms.CheckBox cbShowChart;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox cbOrderList;
    }
}