namespace PhotoSorter.MainForm
{
    partial class MainForm
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
            this.labelSourceDirectory = new System.Windows.Forms.Label();
            this.buttonSourceDirectory = new System.Windows.Forms.Button();
            this.labelOutputDirectory = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonOutputDirectory = new System.Windows.Forms.Button();
            this.buttonSort = new System.Windows.Forms.Button();
            this.labelVersion = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelMessage = new System.Windows.Forms.Label();
            this.listBoxGroups = new System.Windows.Forms.CheckedListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelSourceDirectory
            // 
            this.labelSourceDirectory.AutoSize = true;
            this.labelSourceDirectory.Location = new System.Drawing.Point(19, 67);
            this.labelSourceDirectory.Name = "labelSourceDirectory";
            this.labelSourceDirectory.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.labelSourceDirectory.Size = new System.Drawing.Size(22, 23);
            this.labelSourceDirectory.TabIndex = 0;
            this.labelSourceDirectory.Text = "C:\\";
            // 
            // buttonSourceDirectory
            // 
            this.buttonSourceDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSourceDirectory.Location = new System.Drawing.Point(435, 62);
            this.buttonSourceDirectory.Name = "buttonSourceDirectory";
            this.buttonSourceDirectory.Size = new System.Drawing.Size(140, 23);
            this.buttonSourceDirectory.TabIndex = 1;
            this.buttonSourceDirectory.Text = "Choose Source Directory";
            this.buttonSourceDirectory.UseVisualStyleBackColor = true;
            this.buttonSourceDirectory.Click += new System.EventHandler(this.ButtonSourceDirectory_Click);
            // 
            // labelOutputDirectory
            // 
            this.labelOutputDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.labelOutputDirectory.AutoSize = true;
            this.labelOutputDirectory.Location = new System.Drawing.Point(19, 117);
            this.labelOutputDirectory.Name = "labelOutputDirectory";
            this.labelOutputDirectory.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.labelOutputDirectory.Size = new System.Drawing.Size(22, 23);
            this.labelOutputDirectory.TabIndex = 2;
            this.labelOutputDirectory.Text = "C:\\";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Where are the files to sort?";
            // 
            // buttonOutputDirectory
            // 
            this.buttonOutputDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOutputDirectory.Location = new System.Drawing.Point(435, 117);
            this.buttonOutputDirectory.Name = "buttonOutputDirectory";
            this.buttonOutputDirectory.Size = new System.Drawing.Size(140, 23);
            this.buttonOutputDirectory.TabIndex = 4;
            this.buttonOutputDirectory.Text = "Choose Output Directory";
            this.buttonOutputDirectory.UseVisualStyleBackColor = true;
            this.buttonOutputDirectory.Click += new System.EventHandler(this.ButtonOutputDirectory_Click);
            // 
            // buttonSort
            // 
            this.buttonSort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSort.Location = new System.Drawing.Point(497, 322);
            this.buttonSort.Name = "buttonSort";
            this.buttonSort.Size = new System.Drawing.Size(75, 23);
            this.buttonSort.TabIndex = 5;
            this.buttonSort.Text = "Sort";
            this.buttonSort.UseVisualStyleBackColor = true;
            this.buttonSort.Click += new System.EventHandler(this.ButtonSort_Click);
            // 
            // labelVersion
            // 
            this.labelVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelVersion.AutoSize = true;
            this.labelVersion.Location = new System.Drawing.Point(13, 327);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(45, 13);
            this.labelVersion.TabIndex = 8;
            this.labelVersion.Text = "Version:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(177, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Where should the files be sorted to?";
            // 
            // labelMessage
            // 
            this.labelMessage.AutoSize = true;
            this.labelMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMessage.Location = new System.Drawing.Point(13, 13);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(280, 17);
            this.labelMessage.TabIndex = 11;
            this.labelMessage.Text = "You can sort both photos and videos.";
            // 
            // listBoxGroups
            // 
            this.listBoxGroups.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxGroups.CheckOnClick = true;
            this.listBoxGroups.FormattingEnabled = true;
            this.listBoxGroups.Location = new System.Drawing.Point(22, 192);
            this.listBoxGroups.Name = "listBoxGroups";
            this.listBoxGroups.Size = new System.Drawing.Size(216, 109);
            this.listBoxGroups.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(219, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Which groups should the files be sorted into?";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(584, 357);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listBoxGroups);
            this.Controls.Add(this.labelMessage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.buttonSort);
            this.Controls.Add(this.buttonOutputDirectory);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelOutputDirectory);
            this.Controls.Add(this.buttonSourceDirectory);
            this.Controls.Add(this.labelSourceDirectory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Photo Sorter";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelSourceDirectory;
        private System.Windows.Forms.Button buttonSourceDirectory;
        private System.Windows.Forms.Label labelOutputDirectory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonOutputDirectory;
        private System.Windows.Forms.Button buttonSort;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.CheckedListBox listBoxGroups;
        private System.Windows.Forms.Label label3;
    }
}

