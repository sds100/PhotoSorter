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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // labelSourceDirectory
            // 
            this.labelSourceDirectory.AutoSize = true;
            this.labelSourceDirectory.Location = new System.Drawing.Point(115, 12);
            this.labelSourceDirectory.Name = "labelSourceDirectory";
            this.labelSourceDirectory.Size = new System.Drawing.Size(22, 13);
            this.labelSourceDirectory.TabIndex = 0;
            this.labelSourceDirectory.Text = "C:\\";
            // 
            // buttonSourceDirectory
            // 
            this.buttonSourceDirectory.Location = new System.Drawing.Point(519, 12);
            this.buttonSourceDirectory.Name = "buttonSourceDirectory";
            this.buttonSourceDirectory.Size = new System.Drawing.Size(140, 23);
            this.buttonSourceDirectory.TabIndex = 1;
            this.buttonSourceDirectory.Text = "Choose Source Directory";
            this.buttonSourceDirectory.UseVisualStyleBackColor = true;
            this.buttonSourceDirectory.Click += new System.EventHandler(this.ButtonSourceDirectory_Click);
            // 
            // labelOutputDirectory
            // 
            this.labelOutputDirectory.AutoSize = true;
            this.labelOutputDirectory.Location = new System.Drawing.Point(12, 41);
            this.labelOutputDirectory.Name = "labelOutputDirectory";
            this.labelOutputDirectory.Size = new System.Drawing.Size(22, 13);
            this.labelOutputDirectory.TabIndex = 2;
            this.labelOutputDirectory.Text = "C:\\";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "photos to organise:";
            // 
            // buttonOutputDirectory
            // 
            this.buttonOutputDirectory.Location = new System.Drawing.Point(519, 42);
            this.buttonOutputDirectory.Name = "buttonOutputDirectory";
            this.buttonOutputDirectory.Size = new System.Drawing.Size(140, 23);
            this.buttonOutputDirectory.TabIndex = 4;
            this.buttonOutputDirectory.Text = "Choose Output Directory";
            this.buttonOutputDirectory.UseVisualStyleBackColor = true;
            this.buttonOutputDirectory.Click += new System.EventHandler(this.ButtonOutputDirectory_Click);
            // 
            // buttonSort
            // 
            this.buttonSort.Location = new System.Drawing.Point(483, 200);
            this.buttonSort.Name = "buttonSort";
            this.buttonSort.Size = new System.Drawing.Size(75, 23);
            this.buttonSort.TabIndex = 5;
            this.buttonSort.Text = "Sort";
            this.buttonSort.UseVisualStyleBackColor = true;
            this.buttonSort.Click += new System.EventHandler(this.ButtonSort_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(210, 300);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(466, 23);
            this.progressBar1.TabIndex = 7;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.buttonSort);
            this.Controls.Add(this.buttonOutputDirectory);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelOutputDirectory);
            this.Controls.Add(this.buttonSourceDirectory);
            this.Controls.Add(this.labelSourceDirectory);
            this.Name = "MainForm";
            this.Text = "Form1";
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
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

