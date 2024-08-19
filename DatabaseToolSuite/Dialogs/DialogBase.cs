using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace DatabaseToolSuite.Dialogs
{
    public class DialogBase : Form
    {
        public const int RIGHT_BUTTON_MARGIN = 28;
        public const int BOTTOM_BUTTON_MARGIN = 51;

        public const int CONTROL_MARGIN = 6;
        public readonly static int LINES_MARGIN = SystemInformation.Border3DSize.Width * 2;
        public const int TOP_BORDER_HEIGHT = 42;
        public const int BOTTOM_BORDER_HEIGHT = 48;

        public readonly static Size BUTTON_SIZE = new Size(75, 23);
        public readonly static Size CAPTION_IMAGE_SIZE = new Size(TOP_BORDER_HEIGHT - CONTROL_MARGIN * 2, TOP_BORDER_HEIGHT - CONTROL_MARGIN * 2);
        public readonly static Font CAPTION_FONT = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);


        private EventHandler onApply;
        private EventHandler onCancel;
        private EventHandler onOk;
        private StringFormat stringFormat = new StringFormat();


        public string DialogCaption { get; set; }

        public Image DialogCaptionImage { get; set; }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            LinearGradientBrush brush = new LinearGradientBrush(new Point(0, 0), new Point(Width, TOP_BORDER_HEIGHT), SystemColors.GradientActiveCaption, SystemColors.GradientInactiveCaption);

            Rectangle captionRectagle = new Rectangle(CAPTION_IMAGE_SIZE.Width + CONTROL_MARGIN * 4, CONTROL_MARGIN, e.ClipRectangle.Width - CAPTION_IMAGE_SIZE.Width - CONTROL_MARGIN * 6, TOP_BORDER_HEIGHT - CONTROL_MARGIN * 2);
            graphics.FillRectangle(brush, 0, 0, e.ClipRectangle.Width, TOP_BORDER_HEIGHT);
            graphics.DrawLine(SystemPens.Highlight, 0, 1, e.ClipRectangle.Width, 1);
            graphics.DrawLine(SystemPens.Highlight, LINES_MARGIN, TOP_BORDER_HEIGHT, e.ClipRectangle.Width - LINES_MARGIN, TOP_BORDER_HEIGHT);

            graphics.FillRectangle(SystemBrushes.Window, CONTROL_MARGIN * 2, CONTROL_MARGIN, CAPTION_IMAGE_SIZE.Width, CAPTION_IMAGE_SIZE.Height);
            graphics.DrawRectangle(SystemPens.Highlight, CONTROL_MARGIN * 2, CONTROL_MARGIN, CAPTION_IMAGE_SIZE.Width, CAPTION_IMAGE_SIZE.Height);
            graphics.DrawRectangle(SystemPens.Highlight, CONTROL_MARGIN * 2 + LINES_MARGIN, CONTROL_MARGIN + LINES_MARGIN, CAPTION_IMAGE_SIZE.Width - LINES_MARGIN * 2, CAPTION_IMAGE_SIZE.Height - LINES_MARGIN * 2);

            graphics.DrawString(DialogCaption, CAPTION_FONT, SystemBrushes.Highlight, captionRectagle, stringFormat);
            if (DialogCaptionImage != null)
            {
                graphics.DrawImage(DialogCaptionImage, CONTROL_MARGIN * 2 + LINES_MARGIN + 1, CONTROL_MARGIN + LINES_MARGIN + 1, CAPTION_IMAGE_SIZE.Width - LINES_MARGIN * 2 - 1, CAPTION_IMAGE_SIZE.Height - LINES_MARGIN * 2 - 1);
            }

            graphics.FillRectangle(SystemBrushes.Window, 0, e.ClipRectangle.Height - BOTTOM_BORDER_HEIGHT, e.ClipRectangle.Width, BOTTOM_BORDER_HEIGHT);
            graphics.DrawLine(SystemPens.Highlight, LINES_MARGIN, e.ClipRectangle.Height - BOTTOM_BORDER_HEIGHT, e.ClipRectangle.Width - LINES_MARGIN, e.ClipRectangle.Height - BOTTOM_BORDER_HEIGHT);

            base.OnPaint(e);
        }
        
        protected bool OkButtonVisible
        {
            get
            {
                return button_OK.Visible;
            }
            set
            {
                button_OK.Visible = value;

            }
        }

        protected bool ApplyButtonVisible
        {
            get
            {
                return button_Apply.Visible;
            }
            set
            {
                button_Apply.Visible = value;
            }
        }

        protected bool CancelButtonVisible
        {
            get
            {
                return button_Cancel.Visible;
            }
            set
            {
                button_Cancel.Visible = value;
            }
        }

        protected bool ApplyButtonEnabled
        {
            get
            {
                return button_Apply.Enabled;
            }
            set
            {
                button_Apply.Enabled = value;
            }
        }

        protected bool OkButtonEnabled
        {
            get
            {
                return button_OK.Enabled;
            }
            set
            {
                button_OK.Enabled = value;
            }
        }

        protected string OkButtonText
        {
            get
            {
                return button_OK.Text;
            }
            set
            {
                button_OK.Text = value;
            }
        }

        protected string CancelButtonText
        {
            get
            {
                return button_Cancel.Text;
            }
            set
            {
                button_Cancel.Text = value;
            }
        }

        public event EventHandler Apply
        {
            add
            {
                onApply += value;
            }
            remove
            {
                onApply -= value;
            }
        }

        public event EventHandler Cancel
        {
            add
            {
                onCancel += value;
            }
            remove
            {
                onCancel -= value;
            }
        }

        public event EventHandler Ok
        {
            add
            {
                onOk += value;
            }
            remove
            {
                onOk -= value;
            }
        }

        protected virtual void OnApply(EventArgs eventargs)
        {
            onApply?.Invoke(this, eventargs);
        }

        protected virtual void OnCancel(EventArgs eventargs)
        {
            onCancel?.Invoke(this, eventargs);
        }

        protected virtual void OnOk(EventArgs eventargs)
        {
            onOk?.Invoke(this, eventargs);
        }

        public DialogBase()
        {
            stringFormat.LineAlignment = StringAlignment.Center;

            InitializeComponent();

            Text = Const.App.APP_CAPTION;
            KeyPreview = true;

            ResizeButton();
        }

        protected override void OnResize(EventArgs e)
        {
            ResizeButton();
            base.OnResize(e);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            DatabaseToolSuite.Properties.Settings.Default.DialogWidth = Width;
            DatabaseToolSuite.Properties.Settings.Default.DialogHight = Height;
            DatabaseToolSuite.Properties.Settings.Default.Save();

            base.OnFormClosed(e);
        }

        private void dialogButton_VisibleChanged(object sender, EventArgs e)
        {
            AcceptButton = button_OK.Visible ? button_OK : null;
            CancelButton = button_Cancel.Visible ? button_Cancel : null;

            if (
                button_Apply.Visible &&
                button_OK.Visible &&
                button_Cancel.Visible)
            {
                button_OK.TabIndex = 0;
                button_OK.TabStop = true;
                button_OK.DialogResult = DialogResult.OK;
                button_Cancel.TabIndex = 1;
                button_Cancel.TabStop = true;
                button_Cancel.DialogResult = DialogResult.Cancel;
                button_Apply.TabIndex = 2;
                button_Apply.TabStop = true;
                button_Apply.DialogResult = DialogResult.None;
            }
            else if (
                !button_Apply.Visible &&
                !button_OK.Visible &&
                button_Cancel.Visible)
            {
                button_Cancel.TabIndex = 1;
                button_Cancel.TabStop = true;
            }
            ResizeButton();
        }

        private void ResizeButton()
        {
            button_Apply.Size = BUTTON_SIZE;
            button_Cancel.Size = BUTTON_SIZE;
            button_OK.Size = BUTTON_SIZE;

            int left = Width - RIGHT_BUTTON_MARGIN - BUTTON_SIZE.Width;
            if (button_Cancel.Visible)
            {
                button_Cancel.Location = new Point(left, Height - BOTTOM_BUTTON_MARGIN - BUTTON_SIZE.Height);
                left = left - (BUTTON_SIZE.Width + CONTROL_MARGIN);
            }
            if (button_Apply.Visible)
            {
                button_Apply.Location = new Point(left, Height - BOTTOM_BUTTON_MARGIN - BUTTON_SIZE.Height);
                left = left - (BUTTON_SIZE.Width + CONTROL_MARGIN);
            }
            if (button_OK.Visible)
            {
                button_OK.Location = new Point(left, Height - BOTTOM_BUTTON_MARGIN - BUTTON_SIZE.Height);
            }
        }

        private void Apply_Click(object sender, EventArgs e)
        {
            OnApply(EventArgs.Empty);
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            OnCancel(EventArgs.Empty);
        }

        private void OK_Click(object sender, EventArgs e)
        {
            OnOk(EventArgs.Empty);
        }

        /// <summary>
        /// Required designer variable.
        /// </summary>
        protected System.ComponentModel.IContainer components = new System.ComponentModel.Container();

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
            this.button_Apply = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.button_OK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_Apply
            // 
            this.button_Apply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Apply.Location = new System.Drawing.Point(0, 0);
            this.button_Apply.Margin = new System.Windows.Forms.Padding(4);
            this.button_Apply.Name = "button_Apply";
            this.button_Apply.Size = new System.Drawing.Size(100, 28);
            this.button_Apply.TabIndex = 2;
            this.button_Apply.Text = "Применить";
            this.button_Apply.UseVisualStyleBackColor = true;
            this.button_Apply.VisibleChanged += new System.EventHandler(this.dialogButton_VisibleChanged);
            this.button_Apply.Click += new System.EventHandler(this.Apply_Click);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Cancel.Location = new System.Drawing.Point(0, 0);
            this.button_Cancel.Margin = new System.Windows.Forms.Padding(4);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(100, 28);
            this.button_Cancel.TabIndex = 1;
            this.button_Cancel.Text = "Отмена";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.VisibleChanged += new System.EventHandler(this.dialogButton_VisibleChanged);
            this.button_Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // button_OK
            // 
            this.button_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button_OK.Location = new System.Drawing.Point(0, 0);
            this.button_OK.Margin = new System.Windows.Forms.Padding(4);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(100, 28);
            this.button_OK.TabIndex = 0;
            this.button_OK.Text = "ОК";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.VisibleChanged += new System.EventHandler(this.dialogButton_VisibleChanged);
            this.button_OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // DialogBase
            // 
            this.AcceptButton = this.button_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_Cancel;
            this.ClientSize = this.ClientSize;
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_Apply);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DialogBase";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DialogEditorBase";
            this.Load += new System.EventHandler(this.DialogBase_Load);
            this.ResumeLayout(false);

        }

        #endregion
        protected Button button_Cancel;
        protected Button button_OK;
        private Button button_Apply;

        private void DialogBase_Load(object sender, EventArgs e)
        {
            DatabaseToolSuite.Properties.Settings.Default.Reload();
            Width = DatabaseToolSuite.Properties.Settings.Default.DialogWidth;
            Height = DatabaseToolSuite.Properties.Settings.Default.DialogHight;
        }
    }
}