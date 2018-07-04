namespace PhotoSorter.SortPreviewForm
{
    partial class SortPreviewForm
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
            this.treeView = new System.Windows.Forms.TreeView();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.radioButtonMove = new System.Windows.Forms.RadioButton();
            this.radioButtonCopy = new System.Windows.Forms.RadioButton();
            this.labelOutputDirectory = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // treeView
            // 
            this.treeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView.Location = new System.Drawing.Point(13, 13);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(869, 496);
            this.treeView.TabIndex = 0;
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonConfirm.Location = new System.Drawing.Point(807, 515);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(75, 23);
            this.buttonConfirm.TabIndex = 1;
            this.buttonConfirm.Text = "Confirm";
            this.buttonConfirm.UseVisualStyleBackColor = true;
            // 
            // radioButtonMove
            // 
            this.radioButtonMove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radioButtonMove.AutoSize = true;
            this.radioButtonMove.Location = new System.Drawing.Point(13, 521);
            this.radioButtonMove.Name = "radioButtonMove";
            this.radioButtonMove.Size = new System.Drawing.Size(52, 17);
            this.radioButtonMove.TabIndex = 2;
            this.radioButtonMove.TabStop = true;
            this.radioButtonMove.Text = "Move";
            this.radioButtonMove.UseVisualStyleBackColor = true;
            // 
            // radioButtonCopy
            // 
            this.radioButtonCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radioButtonCopy.AutoSize = true;
            this.radioButtonCopy.Location = new System.Drawing.Point(72, 521);
            this.radioButtonCopy.Name = "radioButtonCopy";
            this.radioButtonCopy.Size = new System.Drawing.Size(49, 17);
            this.radioButtonCopy.TabIndex = 3;
            this.radioButtonCopy.TabStop = true;
            this.radioButtonCopy.Text = "Copy";
            this.radioButtonCopy.UseVisualStyleBackColor = true;
            // 
            // labelOutputDirectory
            // 
            this.labelOutputDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelOutputDirectory.AutoSize = true;
            this.labelOutputDirectory.Location = new System.Drawing.Point(127, 523);
            this.labelOutputDirectory.Name = "labelOutputDirectory";
            this.labelOutputDirectory.Size = new System.Drawing.Size(34, 13);
            this.labelOutputDirectory.TabIndex = 4;
            this.labelOutputDirectory.Text = "to C:\\";
            // 
            // SortPreviewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(894, 550);
            this.Controls.Add(this.labelOutputDirectory);
            this.Controls.Add(this.radioButtonCopy);
            this.Controls.Add(this.radioButtonMove);
            this.Controls.Add(this.buttonConfirm);
            this.Controls.Add(this.treeView);
            this.Name = "SortPreviewForm";
            this.Text = "Sort Preview";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.Button buttonConfirm;
        private System.Windows.Forms.RadioButton radioButtonMove;
        private System.Windows.Forms.RadioButton radioButtonCopy;
        private System.Windows.Forms.Label labelOutputDirectory;
    }
}