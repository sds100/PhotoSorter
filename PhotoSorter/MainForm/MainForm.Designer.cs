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
            this.buttonSourceDirectory = new System.Windows.Forms.Button();
            this.labelOutputDirectory = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonOutputDirectory = new System.Windows.Forms.Button();
            this.buttonSort = new System.Windows.Forms.Button();
            this.labelVersion = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.listBoxGroups = new System.Windows.Forms.CheckedListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.labelMessage = new System.Windows.Forms.Label();
            this.checkBoxIncludeSubDirectories = new System.Windows.Forms.CheckBox();
            this.listBoxSourceDirectories = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // buttonSourceDirectory
            // 
            this.buttonSourceDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSourceDirectory.Location = new System.Drawing.Point(452, 48);
            this.buttonSourceDirectory.Name = "buttonSourceDirectory";
            this.buttonSourceDirectory.Size = new System.Drawing.Size(153, 23);
            this.buttonSourceDirectory.TabIndex = 1;
            this.buttonSourceDirectory.Text = "Choose Source Folder";
            this.buttonSourceDirectory.UseVisualStyleBackColor = true;
            this.buttonSourceDirectory.Click += new System.EventHandler(this.ButtonSourceDirectory_Click);
            // 
            // labelOutputDirectory
            // 
            this.labelOutputDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.labelOutputDirectory.AutoSize = true;
            this.labelOutputDirectory.Location = new System.Drawing.Point(19, 324);
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
            this.label1.Size = new System.Drawing.Size(402, 39);
            this.label1.TabIndex = 3;
            this.label1.Text = "Where are the files to sort?\r\nYou can choose multiple folders by clicking \"Choose" +
    " Source Folder\" for each folder.\r\nSelect a path in the list then click \"Delete\" " +
    "button to remove it.";
            // 
            // buttonOutputDirectory
            // 
            this.buttonOutputDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOutputDirectory.Location = new System.Drawing.Point(792, 324);
            this.buttonOutputDirectory.Name = "buttonOutputDirectory";
            this.buttonOutputDirectory.Size = new System.Drawing.Size(153, 23);
            this.buttonOutputDirectory.TabIndex = 2;
            this.buttonOutputDirectory.Text = "Choose Output Folder";
            this.buttonOutputDirectory.UseVisualStyleBackColor = true;
            this.buttonOutputDirectory.Click += new System.EventHandler(this.ButtonOutputDirectory_Click);
            // 
            // buttonSort
            // 
            this.buttonSort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSort.Location = new System.Drawing.Point(870, 481);
            this.buttonSort.Name = "buttonSort";
            this.buttonSort.Size = new System.Drawing.Size(75, 23);
            this.buttonSort.TabIndex = 3;
            this.buttonSort.Text = "Sort";
            this.buttonSort.UseVisualStyleBackColor = true;
            this.buttonSort.Click += new System.EventHandler(this.ButtonSort_Click);
            // 
            // labelVersion
            // 
            this.labelVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelVersion.AutoSize = true;
            this.labelVersion.Location = new System.Drawing.Point(13, 486);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(45, 13);
            this.labelVersion.TabIndex = 8;
            this.labelVersion.Text = "Version:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 311);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(177, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Where should the files be sorted to?";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(13, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(280, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "You can sort both photos and videos.";
            // 
            // listBoxGroups
            // 
            this.listBoxGroups.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxGroups.CheckOnClick = true;
            this.listBoxGroups.FormattingEnabled = true;
            this.listBoxGroups.Location = new System.Drawing.Point(22, 387);
            this.listBoxGroups.Name = "listBoxGroups";
            this.listBoxGroups.Size = new System.Drawing.Size(216, 64);
            this.listBoxGroups.TabIndex = 3;
            this.listBoxGroups.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 365);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(219, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Which groups should the files be sorted into?";
            // 
            // labelMessage
            // 
            this.labelMessage.AutoSize = true;
            this.labelMessage.Location = new System.Drawing.Point(16, 311);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(0, 13);
            this.labelMessage.TabIndex = 14;
            // 
            // checkBoxIncludeSubDirectories
            // 
            this.checkBoxIncludeSubDirectories.AutoSize = true;
            this.checkBoxIncludeSubDirectories.Location = new System.Drawing.Point(717, 485);
            this.checkBoxIncludeSubDirectories.Name = "checkBoxIncludeSubDirectories";
            this.checkBoxIncludeSubDirectories.Size = new System.Drawing.Size(147, 17);
            this.checkBoxIncludeSubDirectories.TabIndex = 15;
            this.checkBoxIncludeSubDirectories.Text = "Include files in sub-folders";
            this.checkBoxIncludeSubDirectories.UseVisualStyleBackColor = true;
            // 
            // listBoxSourceDirectories
            // 
            this.listBoxSourceDirectories.FormattingEnabled = true;
            this.listBoxSourceDirectories.Location = new System.Drawing.Point(16, 103);
            this.listBoxSourceDirectories.Name = "listBoxSourceDirectories";
            this.listBoxSourceDirectories.Size = new System.Drawing.Size(923, 186);
            this.listBoxSourceDirectories.TabIndex = 16;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(957, 516);
            this.Controls.Add(this.listBoxSourceDirectories);
            this.Controls.Add(this.checkBoxIncludeSubDirectories);
            this.Controls.Add(this.labelMessage);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listBoxGroups);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.buttonSort);
            this.Controls.Add(this.buttonOutputDirectory);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelOutputDirectory);
            this.Controls.Add(this.buttonSourceDirectory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Photo Sorter";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonSourceDirectory;
        private System.Windows.Forms.Label labelOutputDirectory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonOutputDirectory;
        private System.Windows.Forms.Button buttonSort;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckedListBox listBoxGroups;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.CheckBox checkBoxIncludeSubDirectories;
        private System.Windows.Forms.ListBox listBoxSourceDirectories;
    }
}

