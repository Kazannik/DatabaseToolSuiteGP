namespace DatabaseToolSuite.Dialogs
{
    partial class ImportProcessDialog
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
            this.importProgressBar = new System.Windows.Forms.ProgressBar();
            this.cancelButton = new System.Windows.Forms.Button();
            this.importBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.progressLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // importProgressBar
            // 
            this.importProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.importProgressBar.Location = new System.Drawing.Point(12, 49);
            this.importProgressBar.Name = "importProgressBar";
            this.importProgressBar.Size = new System.Drawing.Size(549, 23);
            this.importProgressBar.TabIndex = 0;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(236, 88);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(4);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(100, 27);
            this.cancelButton.TabIndex = 27;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // importBackgroundWorker
            // 
            this.importBackgroundWorker.WorkerReportsProgress = true;
            this.importBackgroundWorker.WorkerSupportsCancellation = true;
            this.importBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.importBackgroundWorker_DoWork);
            this.importBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.importBackgroundWorker_ProgressChanged);
            this.importBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.importBackgroundWorker_RunWorkerCompleted);
            // 
            // progressLabel
            // 
            this.progressLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressLabel.Location = new System.Drawing.Point(12, 9);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(549, 23);
            this.progressLabel.TabIndex = 28;
            this.progressLabel.Text = "##";
            this.progressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ImportProcessDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(573, 128);
            this.Controls.Add(this.progressLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.importProgressBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImportProcessDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ImportProcessDialog";
            this.Shown += new System.EventHandler(this.ImportProcessDialog_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar importProgressBar;
        private System.Windows.Forms.Button cancelButton;
        private System.ComponentModel.BackgroundWorker importBackgroundWorker;
        private System.Windows.Forms.Label progressLabel;
    }
}