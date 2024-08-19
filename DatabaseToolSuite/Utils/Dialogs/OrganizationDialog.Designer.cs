namespace DatabaseToolSuite.Dialogs
{
    partial class OrganizationDialog
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
            this.components = new System.ComponentModel.Container();
            this.codeTextBox = new System.Windows.Forms.TextBox();
            this.codeLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lockCodeButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.ownerTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lockButton = new System.Windows.Forms.Button();
            this.createButton = new System.Windows.Forms.Button();
            this.cloneButton = new System.Windows.Forms.Button();
            this.newButton = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.savaButton = new System.Windows.Forms.Button();
            this.beginDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.authorityComboBox = new DatabaseToolSuite.Controls.AuthorityComboBox();
            this.okatoComboBox = new DatabaseToolSuite.Controls.OkatoComboBox();
            this.endDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // codeTextBox
            // 
            this.codeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.codeTextBox.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.codeTextBox.Location = new System.Drawing.Point(16, 41);
            this.codeTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.codeTextBox.Name = "codeTextBox";
            this.codeTextBox.ReadOnly = true;
            this.codeTextBox.Size = new System.Drawing.Size(180, 26);
            this.codeTextBox.TabIndex = 2;
            this.codeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // codeLabel
            // 
            this.codeLabel.AutoSize = true;
            this.codeLabel.Location = new System.Drawing.Point(13, 20);
            this.codeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.codeLabel.Name = "codeLabel";
            this.codeLabel.Size = new System.Drawing.Size(144, 17);
            this.codeLabel.TabIndex = 3;
            this.codeLabel.Text = "Код подразделения:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(265, 88);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Вид органа:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(265, 156);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "ОКАТО:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(262, 225);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Наименование:";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameTextBox.Location = new System.Drawing.Point(265, 248);
            this.nameTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.nameTextBox.Multiline = true;
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.nameTextBox.Size = new System.Drawing.Size(576, 54);
            this.nameTextBox.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 88);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(163, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Дата начала действия:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 157);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(186, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "Дата окончания действия:";
            // 
            // lockCodeButton
            // 
            this.lockCodeButton.Location = new System.Drawing.Point(203, 41);
            this.lockCodeButton.Name = "lockCodeButton";
            this.lockCodeButton.Size = new System.Drawing.Size(40, 26);
            this.lockCodeButton.TabIndex = 12;
            this.lockCodeButton.UseVisualStyleBackColor = true;
            this.lockCodeButton.Click += new System.EventHandler(this.lockCodeButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(265, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(212, 17);
            this.label6.TabIndex = 15;
            this.label6.Text = "Родительское подразделение:";
            // 
            // ownerTextBox
            // 
            this.ownerTextBox.Location = new System.Drawing.Point(265, 43);
            this.ownerTextBox.Multiline = true;
            this.ownerTextBox.Name = "ownerTextBox";
            this.ownerTextBox.ReadOnly = true;
            this.ownerTextBox.Size = new System.Drawing.Size(461, 42);
            this.ownerTextBox.TabIndex = 16;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lockButton);
            this.groupBox1.Controls.Add(this.createButton);
            this.groupBox1.Controls.Add(this.cloneButton);
            this.groupBox1.Controls.Add(this.newButton);
            this.groupBox1.Location = new System.Drawing.Point(848, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(183, 282);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Действия";
            // 
            // lockButton
            // 
            this.lockButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lockButton.Image = global::DatabaseToolSuite.Properties.Resources.Delete32;
            this.lockButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lockButton.Location = new System.Drawing.Point(6, 214);
            this.lockButton.Name = "lockButton";
            this.lockButton.Size = new System.Drawing.Size(171, 58);
            this.lockButton.TabIndex = 3;
            this.lockButton.Text = "Заблокировать";
            this.lockButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lockButton.UseVisualStyleBackColor = true;
            this.lockButton.Click += new System.EventHandler(this.lockButton_Click);
            // 
            // createButton
            // 
            this.createButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.createButton.Image = global::DatabaseToolSuite.Properties.Resources.Duplicate32;
            this.createButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.createButton.Location = new System.Drawing.Point(6, 150);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(171, 58);
            this.createButton.TabIndex = 2;
            this.createButton.Text = "Создать версию";
            this.createButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // cloneButton
            // 
            this.cloneButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cloneButton.Image = global::DatabaseToolSuite.Properties.Resources.Duplicate32;
            this.cloneButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cloneButton.Location = new System.Drawing.Point(6, 86);
            this.cloneButton.Name = "cloneButton";
            this.cloneButton.Size = new System.Drawing.Size(171, 58);
            this.cloneButton.TabIndex = 1;
            this.cloneButton.Text = "Клонировать в новый";
            this.cloneButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cloneButton.UseVisualStyleBackColor = true;
            this.cloneButton.Click += new System.EventHandler(this.cloneButton_Click);
            // 
            // newButton
            // 
            this.newButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.newButton.Image = global::DatabaseToolSuite.Properties.Resources.New32;
            this.newButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.newButton.Location = new System.Drawing.Point(6, 22);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(171, 58);
            this.newButton.TabIndex = 0;
            this.newButton.Text = "Создать новый";
            this.newButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(732, 42);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(109, 43);
            this.button5.TabIndex = 18;
            this.button5.Text = "Указать владельца";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // exitButton
            // 
            this.exitButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.exitButton.Image = global::DatabaseToolSuite.Properties.Resources.FileExit32;
            this.exitButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.exitButton.Location = new System.Drawing.Point(855, 314);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(171, 58);
            this.exitButton.TabIndex = 19;
            this.exitButton.Text = "Закрыть";
            this.exitButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // savaButton
            // 
            this.savaButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.savaButton.Image = global::DatabaseToolSuite.Properties.Resources.Save32;
            this.savaButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.savaButton.Location = new System.Drawing.Point(670, 314);
            this.savaButton.Name = "savaButton";
            this.savaButton.Size = new System.Drawing.Size(171, 58);
            this.savaButton.TabIndex = 20;
            this.savaButton.Text = "Сохранить";
            this.savaButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.savaButton.UseVisualStyleBackColor = true;
            this.savaButton.Click += new System.EventHandler(this.savaButton_Click);
            // 
            // beginDateTimePicker
            // 
            this.beginDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.beginDateTimePicker.Location = new System.Drawing.Point(16, 112);
            this.beginDateTimePicker.MaxDate = new System.DateTime(2999, 12, 31, 0, 0, 0, 0);
            this.beginDateTimePicker.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.beginDateTimePicker.Name = "beginDateTimePicker";
            this.beginDateTimePicker.Size = new System.Drawing.Size(141, 23);
            this.beginDateTimePicker.TabIndex = 21;
            // 
            // authorityComboBox
            // 
            this.authorityComboBox.Code = "";
            this.authorityComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.authorityComboBox.DropDownHeight = 172;
            this.authorityComboBox.DropDownWidth = 80;
            this.authorityComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.authorityComboBox.FormattingEnabled = true;
            this.authorityComboBox.IntegralHeight = false;
            this.authorityComboBox.ItemHeight = 21;
            this.authorityComboBox.Location = new System.Drawing.Point(265, 108);
            this.authorityComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.authorityComboBox.MaxDropDownItems = 20;
            this.authorityComboBox.Name = "authorityComboBox";
            this.authorityComboBox.Size = new System.Drawing.Size(576, 27);
            this.authorityComboBox.TabIndex = 1;
            // 
            // okatoComboBox
            // 
            this.okatoComboBox.Code = "";
            this.okatoComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.okatoComboBox.DropDownHeight = 172;
            this.okatoComboBox.DropDownWidth = 80;
            this.okatoComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.okatoComboBox.FormattingEnabled = true;
            this.okatoComboBox.IntegralHeight = false;
            this.okatoComboBox.ItemHeight = 21;
            this.okatoComboBox.Location = new System.Drawing.Point(265, 177);
            this.okatoComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.okatoComboBox.MaxDropDownItems = 20;
            this.okatoComboBox.Name = "okatoComboBox";
            this.okatoComboBox.Size = new System.Drawing.Size(576, 27);
            this.okatoComboBox.TabIndex = 0;
            // 
            // endDateTimePicker
            // 
            this.endDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.endDateTimePicker.Location = new System.Drawing.Point(16, 181);
            this.endDateTimePicker.MaxDate = new System.DateTime(2999, 12, 31, 0, 0, 0, 0);
            this.endDateTimePicker.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.endDateTimePicker.Name = "endDateTimePicker";
            this.endDateTimePicker.Size = new System.Drawing.Size(141, 23);
            this.endDateTimePicker.TabIndex = 22;
            // 
            // OrganizationDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1038, 384);
            this.Controls.Add(this.endDateTimePicker);
            this.Controls.Add(this.beginDateTimePicker);
            this.Controls.Add(this.savaButton);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ownerTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lockCodeButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.codeLabel);
            this.Controls.Add(this.codeTextBox);
            this.Controls.Add(this.authorityComboBox);
            this.Controls.Add(this.okatoComboBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "OrganizationDialog";
            this.Text = "OrganizationDialog";
            this.Load += new System.EventHandler(this.OrganizationDialog_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.OkatoComboBox okatoComboBox;
        private Controls.AuthorityComboBox authorityComboBox;
        private System.Windows.Forms.TextBox codeTextBox;
        private System.Windows.Forms.Label codeLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button lockCodeButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox ownerTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button lockButton;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.Button cloneButton;
        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button savaButton;
        private System.Windows.Forms.DateTimePicker beginDateTimePicker;
        private System.Windows.Forms.DateTimePicker endDateTimePicker;
    }
}