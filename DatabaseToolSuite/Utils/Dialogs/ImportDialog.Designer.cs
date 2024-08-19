namespace DatabaseToolSuite.Utils.Dialogs
{
    partial class ImportDialog
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.nameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.okatoColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.addressColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.openFilesButton = new System.Windows.Forms.Button();
            this.selectOrganizationButton = new System.Windows.Forms.Button();
            this.autoButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameColumn,
            this.okatoColumn,
            this.addressColumn});
            this.listView1.Location = new System.Drawing.Point(12, 12);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(833, 420);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // nameColumn
            // 
            this.nameColumn.Text = "Наименование";
            this.nameColumn.Width = 404;
            // 
            // okatoColumn
            // 
            this.okatoColumn.Text = "OKATO";
            this.okatoColumn.Width = 207;
            // 
            // addressColumn
            // 
            this.addressColumn.Text = "Адрес";
            this.addressColumn.Width = 212;
            // 
            // openFilesButton
            // 
            this.openFilesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.openFilesButton.Location = new System.Drawing.Point(851, 12);
            this.openFilesButton.Name = "openFilesButton";
            this.openFilesButton.Size = new System.Drawing.Size(120, 38);
            this.openFilesButton.TabIndex = 1;
            this.openFilesButton.Text = "Open Files ...";
            this.openFilesButton.UseVisualStyleBackColor = true;
            this.openFilesButton.Click += new System.EventHandler(this.openFilesButton_Click);
            // 
            // selectOrganizationButton
            // 
            this.selectOrganizationButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.selectOrganizationButton.Location = new System.Drawing.Point(851, 56);
            this.selectOrganizationButton.Name = "selectOrganizationButton";
            this.selectOrganizationButton.Size = new System.Drawing.Size(120, 38);
            this.selectOrganizationButton.TabIndex = 2;
            this.selectOrganizationButton.Text = "Select ...";
            this.selectOrganizationButton.UseVisualStyleBackColor = true;
            this.selectOrganizationButton.Click += new System.EventHandler(this.selectOrganizationButton_Click);
            // 
            // autoButton
            // 
            this.autoButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.autoButton.Location = new System.Drawing.Point(851, 100);
            this.autoButton.Name = "autoButton";
            this.autoButton.Size = new System.Drawing.Size(120, 38);
            this.autoButton.TabIndex = 3;
            this.autoButton.Text = "Auto ...";
            this.autoButton.UseVisualStyleBackColor = true;
            this.autoButton.Click += new System.EventHandler(this.autoButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Location = new System.Drawing.Point(851, 144);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(120, 38);
            this.saveButton.TabIndex = 4;
            this.saveButton.Text = "Save ...";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // ImportDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(983, 444);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.autoButton);
            this.Controls.Add(this.selectOrganizationButton);
            this.Controls.Add(this.openFilesButton);
            this.Controls.Add(this.listView1);
            this.Name = "ImportDialog";
            this.Text = "Импорт данных ФГИС ЕСНСИ";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader nameColumn;
        private System.Windows.Forms.ColumnHeader okatoColumn;
        private System.Windows.Forms.ColumnHeader addressColumn;
        private System.Windows.Forms.Button openFilesButton;
        private System.Windows.Forms.Button selectOrganizationButton;
        private System.Windows.Forms.Button autoButton;
        private System.Windows.Forms.Button saveButton;
    }
}