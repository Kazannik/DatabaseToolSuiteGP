using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace DatabaseToolSuite.Controls
{
    [DesignerCategory("code")]
    [ToolboxBitmap(typeof(ComboBox))]
    [ComVisible(false)]
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.All)]
    public abstract class ToolStripComboControl<T> : ToolStripComboBox where T : ComboControl<T>.IComboBoxItem
    {
        protected StringFormat sfCode;
        protected StringFormat sfCaption;

        private List<T> list;

        #region Initialize

        [DebuggerNonUserCode()]
        public ToolStripComboControl(IContainer container) : this()
        {
            if (container != null) { container.Add(this); }
        }

        [DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && components != null)
                { components.Dispose(); }
            }
            finally
            { base.Dispose(disposing); }
        }

        private IContainer components;

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            components = new Container();
            list = new List<T>();
        }

        public ToolStripComboControl() : base()
        {
            sfCode = (StringFormat)StringFormat.GenericTypographic.Clone();
            sfCode.Alignment = StringAlignment.Center;
            sfCode.LineAlignment = StringAlignment.Center;
            sfCode.FormatFlags = StringFormatFlags.NoClip | StringFormatFlags.NoWrap;

            sfCaption = (StringFormat)StringFormat.GenericTypographic.Clone();
            sfCaption.Alignment = StringAlignment.Near;
            sfCaption.LineAlignment = StringAlignment.Near;
            sfCaption.FormatFlags = StringFormatFlags.NoClip | StringFormatFlags.NoWrap;


            InitializeComponent();

            ComboBox.DrawItem += new DrawItemEventHandler(ComboBox_DrawItem);

            base.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBox.DrawMode = DrawMode.OwnerDrawFixed;
            MaxDropDownItems = 20;
            DropDownWidth = 80;
            base.AutoSize = false;
            Width = 200;
            DropDownHeight = 80;
            ComboBox.Items.Clear();
        }

        #endregion

        #region Draw Item

        private void ComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics graphics = e.Graphics;

            SizeF CodeSize = graphics.MeasureString("FFFFF", Font);
            ComboBox.ItemHeight = (int)CodeSize.Height + SystemInformation.BorderSize.Height * 4;
            DropDownHeight = ComboBox.ItemHeight * 8 + SystemInformation.BorderSize.Height * 4;

            Rectangle rectSelection = new Rectangle(e.Bounds.X + 1, e.Bounds.Y, e.Bounds.Width - 3, e.Bounds.Height - 1);
            Rectangle rectCode = new Rectangle(rectSelection.X + 2, rectSelection.Y + 2, (int)CodeSize.Width, rectSelection.Height - 4);
            Rectangle rectText = new Rectangle(rectCode.X + rectCode.Width + 6, rectCode.Y, e.Bounds.Width - rectCode.X - rectCode.Width - 6, rectCode.Height);

            Size TextSize = new Size(rectText.Width - SystemInformation.VerticalScrollBarWidth - 8, rectText.Height);

            Brush backCodeBrush, foreCodeBrush, backCaptionBrush, foreCaptionBrush;
            Pen borderPen;

            if (e.Index == -1)
            {
                backCodeBrush = SystemBrushes.Control;
                foreCodeBrush = SystemBrushes.ControlText;
                foreCaptionBrush = new SolidBrush(ForeColor);
                backCaptionBrush = new SolidBrush(BackColor);
                borderPen = new Pen(ForeColor);

                graphics.FillRectangle(backCaptionBrush, e.Bounds);
                graphics.FillRectangle(backCodeBrush, rectCode);
                graphics.DrawRectangle(borderPen, rectCode);
                graphics.DrawString("", Font, foreCodeBrush, rectCode, sfCode);
                graphics.DrawString("(не выбрано)", Font, foreCaptionBrush, rectText, sfCaption);
                return;
            }

            if (Items.Count <= e.Index) return;
            string itemCode = this[e.Index].Code;
            string itemCodeString = itemCode.ToString();
            string itemCaptionString = this[e.Index].Text.Trim();
            if ((e.State & DrawItemState.ComboBoxEdit) == DrawItemState.ComboBoxEdit)
            {
                backCodeBrush = new SolidBrush(BackColor);
                foreCodeBrush = new SolidBrush(ForeColor);
                foreCaptionBrush = new SolidBrush(ForeColor);
                backCaptionBrush = new SolidBrush(BackColor);
                borderPen = new Pen(ForeColor);
            }
            else
            {
                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                {
                    backCodeBrush = new LinearGradientBrush(rectCode, Color.FromArgb(249, 249, 249), Color.FromArgb(241, 241, 241), LinearGradientMode.Vertical);
                    foreCodeBrush = new SolidBrush(Color.FromArgb(0, 102, 204));
                    backCaptionBrush = SystemBrushes.Highlight;
                    foreCaptionBrush = SystemBrushes.HighlightText;
                    borderPen = new Pen(Color.FromArgb(0, 102, 204), 1);
                }
                else
                {
                    backCodeBrush = new SolidBrush(BackColor);
                    foreCodeBrush = new SolidBrush(ForeColor);
                    backCaptionBrush = new SolidBrush(BackColor);
                    foreCaptionBrush = new SolidBrush(ForeColor);
                    borderPen = new Pen(ForeColor, 1);
                }
            }
            graphics.FillRectangle(backCaptionBrush, e.Bounds);
            graphics.FillRectangle(backCodeBrush, rectCode);
            graphics.DrawRectangle(borderPen, rectCode);
            graphics.DrawString(itemCodeString, Font, foreCodeBrush, rectCode, sfCode);
            graphics.DrawString(itemCaptionString, Font, foreCaptionBrush, rectText, sfCaption);
        }

        #endregion

        string codeBuffer;
        string textBuffer;
        int findNext = 0;

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                codeBuffer = string.Empty;
                textBuffer = string.Empty;
                SelectedIndex = -1;
                findNext = 0;
            }
            base.OnKeyDown(e);
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            BeginUpdate();
            if (e.KeyChar == 0)
                e.Handled = false;
            else if (e.KeyChar == '\b')
            {
                e.Handled = false;
                if (!string.IsNullOrWhiteSpace(codeBuffer))
                {
                    codeBuffer = codeBuffer.Substring(0, codeBuffer.Length - 1);
                    FindCode(codeBuffer);
                }
                if (!string.IsNullOrWhiteSpace(textBuffer))
                {
                    textBuffer = textBuffer.Substring(0, textBuffer.Length - 1);
                    FindText(textBuffer);
                }
                findNext = 0;
            }
            else if (e.KeyChar == (0x0d))
            {
                e.Handled = false;
                findNext += 1;
                if (!string.IsNullOrWhiteSpace(codeBuffer))
                {
                    if (!FindCode(codeBuffer))
                        findNext = 0;
                }
                else if (!string.IsNullOrWhiteSpace(textBuffer))
                {
                    if (!FindText(textBuffer))
                        findNext = 0;
                }
            }
            else if (e.KeyChar >= 48 & e.KeyChar <= 57)
            {
                e.Handled = false;
                if (FindCode(codeBuffer + e.KeyChar))
                {
                    codeBuffer += e.KeyChar;
                    textBuffer = string.Empty;
                }
                findNext = 0;
            }
            else if (char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
                if (FindText(textBuffer + e.KeyChar))
                {
                    textBuffer += e.KeyChar;
                    codeBuffer = string.Empty;
                }
                findNext = 0;
            }
            else
                e.Handled = true;
            base.OnKeyPress(e);
            EndUpdate();
        }

        private bool FindCode(string code)
        {
            int i = 0;
            foreach (T item in list)
            {
                if (item.Code.Contains(code))
                {
                    i += 1;
                    this.SelectedItem = item;
                    if (i > findNext)
                        return true;
                }
            }
            return false;
        }

        private bool FindText(string text)
        {
            int i = 0;
            foreach (T item in Items)
            {
                if (item.Text.ToLower().Contains(text.ToLower()))
                {
                    i += 1;
                    this.SelectedItem = item;
                    if (i > findNext)
                        return true;
                }
            }
            return false;
        }


        public string Code
        {
            get
            {
                if (SelectedItem != null)
                {
                    return ((T)SelectedItem).Code;
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    SelectedIndex = -1;
                }
                else
                {
                    if (Contains(value))
                    {
                        SelectedItem = GetItem(value);
                    }
                    else
                    {
                        SelectedIndex = -1;
                    }
                }
            }
        }

        [ReadOnly(true)]
        public T this[int index]
        {
            get
            {
                return (T)Items[index: index];
            }
        }

        [ReadOnly(true)]
        public new ComboBoxStyle DropDownStyle
        {
            get { return base.DropDownStyle; }
        }

        protected void Insert(int index, T item)
        {
            list.Add(item);
            list.Sort(new ItemComparer());
            ComboBox.Items.Insert(index, item);
        }

        protected void Remove(T value)
        {
            list.Remove(value);
            ComboBox.Items.Remove(value);
        }

        protected void RemoveAt(int index)
        {
            object item = ComboBox.Items[index];
            list.Remove((T)item);
            ComboBox.Items.RemoveAt(index);
        }

        protected void Clear()
        {
            list.Clear();
            ComboBox.Items.Clear();
        }

        public int Add(T item)
        {
            foreach (T i in Items)
            {
                if (i.Code == item.Code)
                {
                    throw new ArgumentException("Элемент с кодом [" + item.Code.ToString() + "] ранее добавлен в коллекцию.", "item.Code");
                }
            }
            list.Add(item);
            list.Sort(new ItemComparer());
            return ComboBox.Items.Add(item);
        }

        public bool Contains(string code)
        {
            foreach (T i in Items)
            {
                if (i.Code == code)
                {
                    return true;
                }
            }
            return false;
        }

        public T GetItem(string code)
        {
            foreach (T i in Items)
            {
                if (i.Code == code)
                {
                    return i;
                }
            }
            return default(T);
        }        

        private class ItemComparer : IComparer<T>
        {
            public int Compare(T x, T y)
            {
                int xCode, yCode;
                if (int.TryParse(x.Code, out xCode) && int.TryParse(y.Code, out yCode))
                {
                    return decimal.Compare(xCode, yCode);
                }
                else
                {
                    return string.Compare(x.Code, y.Code);
                }
            }
        }
    }
}
