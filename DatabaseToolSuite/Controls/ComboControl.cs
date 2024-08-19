﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DatabaseToolSuite.Controls
{
    [DesignerCategory("code")]
    [ToolboxBitmap(typeof(ComboBox))]
    [ComVisible(false)]
    public abstract class ComboControl<T> : ComboBox where T : ComboControl<T>.IComboBoxItem
    {
        protected StringFormat sfCode;
        protected StringFormat sfCaption;
        protected StringFormat sfHighlight;

        private List<T> list;

        #region Initialize

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            list = new List<T>();
        }

        public ComboControl() : base()
        {
            
            SuspendLayout();
            sfCode = (StringFormat)StringFormat.GenericTypographic.Clone();
            sfCode.Alignment = StringAlignment.Center;
            sfCode.LineAlignment = StringAlignment.Center;
            sfCode.FormatFlags = StringFormatFlags.NoClip | StringFormatFlags.NoWrap;

            sfCaption = (StringFormat)StringFormat.GenericTypographic.Clone();
            sfCaption.Alignment = StringAlignment.Near;
            sfCaption.LineAlignment = StringAlignment.Near;
            sfCaption.FormatFlags = StringFormatFlags.NoClip | StringFormatFlags.NoWrap;

            sfHighlight = (StringFormat)StringFormat.GenericTypographic.Clone();
            sfHighlight.Alignment = StringAlignment.Center;
            sfHighlight.LineAlignment = StringAlignment.Near;
            sfHighlight.FormatFlags = StringFormatFlags.NoClip | StringFormatFlags.NoWrap;

            InitializeComponent();

            base.DropDownStyle = ComboBoxStyle.DropDownList;
            DrawMode = DrawMode.OwnerDrawFixed;
            MaxDropDownItems = 20;
            DropDownWidth = 80;
            base.AutoSize = false;
            Width = 80;
            DropDownHeight = 200;
            Items.Clear();

            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        #region Draw Item

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            Graphics graphics = e.Graphics;

            SizeF CodeSize = graphics.MeasureString("FFFFF", Font);
            ItemHeight = (int)CodeSize.Height + SystemInformation.BorderSize.Height * 4;
            DropDownHeight = ItemHeight * 20 + SystemInformation.BorderSize.Height * 4;

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

                graphics.FillRectangle(backCaptionBrush, e.Bounds);
                graphics.FillRectangle(backCodeBrush, rectCode);

                DrawHighlightText(graphics, rectCode, Font, foreCodeBrush, SystemBrushes.HighlightText, SystemBrushes.Highlight, itemCodeString, sfCode, codeBuffer);

                graphics.DrawRectangle(borderPen, rectCode);

                DrawHighlightText(graphics, rectText, Font, foreCaptionBrush, SystemBrushes.HighlightText, SystemBrushes.Highlight, itemCaptionString, sfCaption, textBuffer);
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
                graphics.FillRectangle(backCaptionBrush, e.Bounds);
                graphics.FillRectangle(backCodeBrush, rectCode);
                graphics.DrawRectangle(borderPen, rectCode);
                graphics.DrawString(itemCodeString, Font, foreCodeBrush, rectCode, sfCode);
                graphics.DrawString(itemCaptionString, Font, foreCaptionBrush, rectText, sfCaption);
            }
        }
        
        private void DrawHighlightText(Graphics graphics, Rectangle rectagle, Font font, Brush foreColorBrush, Brush highlightForeColor, Brush highlightBackColor, string text, StringFormat format, string buffer)
        {
            if (string.IsNullOrWhiteSpace(buffer) || !text.Contains(buffer))
            {
                graphics.DrawString(text, font, foreColorBrush, rectagle, format);
            } 
            else
            {
                string firstText = text.Substring(0, text.IndexOf(buffer, StringComparison.CurrentCultureIgnoreCase));
                SizeF firstSize = graphics.MeasureString(firstText, font, rectagle.Width, format);

                string centerText = text.Substring(firstText.Length, buffer.Length);
                SizeF centerSize = graphics.MeasureString(centerText, font, rectagle.Width, format);

                string lastText = text.Substring(firstText.Length + centerText.Length);
                SizeF lastSize = graphics.MeasureString(lastText, font, rectagle.Width, format);

                Rectangle firstRect;
                if (format.Alignment == StringAlignment.Near)
                {
                    firstRect = new Rectangle(rectagle.X, rectagle.Y, (int) firstSize.Width, rectagle.Height);
                }
                else if (format.Alignment == StringAlignment.Far)
                {
                    SizeF textSize = graphics.MeasureString(text, font, rectagle.Width, format);
                    firstRect = new Rectangle(rectagle.Width - (int)textSize.Width, rectagle.Y, (int)firstSize.Width, rectagle.Height);
                }
                else
                {
                    SizeF textSize = graphics.MeasureString(text, font, rectagle.Width, format);
                    firstRect = new Rectangle((rectagle.Width - (int)textSize.Width + 2)/2 + 3, rectagle.Y, (int)firstSize.Width, rectagle.Height);
                }

                Rectangle centerRect = new Rectangle(firstRect.X + firstRect.Width + 1, rectagle.Y, (int)centerSize.Width, rectagle.Height);
                Rectangle lastRect = new Rectangle(centerRect.X + centerRect.Width + 1, rectagle.Y, (int)lastSize.Width, rectagle.Height);

                //graphics.FillRectangle( Brushes.Yellow, firstRect);
                //graphics.FillRectangle(Brushes.Yellow, lastRect);
                
                graphics.FillRectangle(highlightBackColor, centerRect);

                graphics.DrawString(firstText, font, foreColorBrush, firstRect, format);
                graphics.DrawString(centerText, font, highlightForeColor, centerRect, sfHighlight);
                graphics.DrawString(lastText, font, foreColorBrush, lastRect, format);
            }
        }
                       
        #endregion

        string codeBuffer = string.Empty;
        string textBuffer = string.Empty;
        int findNext = 0;

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode== Keys.Delete)
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
                if (FindCode(codeBuffer + e.KeyChar)) {
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

        public long? Value
        {
            get
            {
               return string.IsNullOrWhiteSpace(Code) ? (long?)null : long.Parse(Code);
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
            Items.Insert(index, item);
        }

        protected void Remove(T value)
        {
            list.Remove(value);
            Items.Remove(value);
        }

        protected void RemoveAt(int index)
        {
            object item = Items[index];
            list.Remove((T)item);
            Items.RemoveAt(index);            
        }

        protected void Clear()
        {
            list.Clear();
            Items.Clear();
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
            return Items.Add(item);
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

        public new T SelectedItem
        {
            get { return (T) base.SelectedItem; }
            set { base.SelectedItem = value; }
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

        public interface IComboBoxItem
        {
            string Code { get; }
            string Text { get; }            
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
