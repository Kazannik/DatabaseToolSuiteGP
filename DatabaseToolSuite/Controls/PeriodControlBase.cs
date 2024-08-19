using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace DatabaseToolSuite.Controls
{
    public class PeriodControlBase: Control
    {
        #region Dispose

        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #endregion

        private VisualStyleRenderer borderRenderer;

        internal static DateTimeFormatInfo FormatInfo = CultureInfo.CurrentCulture.DateTimeFormat;
        private StringFormat sf = new StringFormat() { Alignment = StringAlignment.Center };
        private StringFormat sfL = new StringFormat() { Alignment = StringAlignment.Near };
        private int month_label_width = 0;
        private int month_label_height = 0;
        private int today_label_width = 0;

        internal const int month_label_border = 1;

        private Arm.PeriodDate period;
        private int selectedYear;

        /// <summary>
        /// Коллекция кнопок.
        /// </summary>
        private PeriodBoxButtonCollection buttons;
        /// <summary>
        /// Кнопка, находящаяся в фокусе.
        /// </summary>
        private PeriodBoxButton HoveringButton;
        /// <summary>
        /// Любая нажатая кнопка.
        /// </summary>
        private PeriodBoxButton PressedButton;
        /// <summary>
        /// Кнопка, нажатая левой кнопкой мыши.
        /// </summary>
        private PeriodBoxButton LeftPressedButton;
        /// <summary>
        /// Кнопка, нажатая правой кнопкой мыши.
        /// </summary>
        private PeriodBoxButton RightPressedButton;
        /// <summary>
        /// Выбранная кнопка.
        /// </summary>
        private PeriodBoxButton SelectedButton;

        #region Constructor

        public PeriodControlBase() : base()
        {
            period = Arm.PeriodDate.Today();
            selectedYear = period.Year;
            InitializeComponent();
            InitializeButton();
        }

        public PeriodControlBase(string text):base(text:text)
        {
            period = Arm.PeriodDate.Today();
            selectedYear = period.Year;
            InitializeComponent();
            InitializeButton();
        }

        public PeriodControlBase(Control parent, string text):base(parent:parent, text:text)
        {
            period = Arm.PeriodDate.Today();
            selectedYear = period.Year;
            InitializeComponent();
            InitializeButton();
        }

        public PeriodControlBase(string text, int left, int top, int width, int height):base(text: text, left: left, top:top, width: width, height: height )
        {
            period = Arm.PeriodDate.Today();
            selectedYear = period.Year;
            InitializeComponent();
            InitializeButton();
        }

        public PeriodControlBase(Control parent, string text, int left, int top, int width, int height):base(parent: parent, text: text, left: left, top: top, width: width, height: height)
        {
            period = Arm.PeriodDate.Today();
            selectedYear = period.Year;
            InitializeComponent();
            InitializeButton();
        }

        private bool SetRenderer(VisualStyleElement element)
        {
            if (!VisualStyleRenderer.IsElementDefined(element))
            { return false; }
            if (borderRenderer == null)
            { borderRenderer = new VisualStyleRenderer(element); }
            else
            { borderRenderer.SetParameters(element); }
            return true;
        }
        
        private void InitializeButton()
        {
            BackColor = SystemColors.Window;
            ForeColor = SystemColors.WindowText;

            buttons = new PeriodBoxButtonCollection(this);
            Graphics graphics = CreateGraphics();
            SizeF labelsize;
            for (int i = 1; i <= 12; i++)
            {
                string monthname = FormatInfo.GetMonthName(i);
                labelsize = graphics.MeasureString(monthname, Font);
                if (month_label_height < labelsize.Height) month_label_height = (int)labelsize.Height;
                if (month_label_width < labelsize.Width) month_label_width = (int)labelsize.Width;
                buttons.Add(new PeriodBoxButton(i, monthname, ButtonType.ItemButton));
            }

            labelsize = graphics.MeasureString(" Сегодня: ", Font);
            today_label_width = (int)labelsize.Width;
            month_label_height += month_label_border * 4;
            month_label_width += month_label_border * 8;

            if (month_label_width > 0)
            {
                Width = month_label_border + (month_label_width + month_label_border) * 3;
                Height = month_label_border + (month_label_height + month_label_border) * 6;
            }
            buttons.Add(new PeriodBoxButton(0, "<<", ButtonType.PreviouseButton));
            buttons.Add(new PeriodBoxButton(0, selectedYear.ToString(), ButtonType.CaptionButton));
            buttons.Add(new PeriodBoxButton(0, ">>", ButtonType.NextButton));
            buttons.Add(new PeriodBoxButton(0, "Сегодня", ButtonType.TodayButton));
            OnResize(new EventArgs());
        }

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);
        }

        #endregion
        
        private Image backImage;

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (month_label_width > 0)
            {
                this.Width = month_label_width * 3 + 5;
                this.Height = month_label_height * 6 + month_label_border * 3 + 5;
                this.backImage = new Bitmap(width: this.Width, height: this.Height, format: System.Drawing.Imaging.PixelFormat.Format64bppArgb);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graphics = Graphics.FromImage(backImage);

            int startY = month_label_height + month_label_border;
            int startX = 2;
            int i = 0;

            if (SetRenderer(VisualStyleElement.TextBox.TextEdit.Focused))
            {
                borderRenderer.DrawEdge(graphics, new Rectangle(0, 0, backImage.Width - 1, backImage.Height - 1), Edges.Top | Edges.Right, EdgeStyle.Bump, EdgeEffects.Soft);
            }
                        
            SelectedButton = null;

            for (int y = 0; y <= 3; y++)
            {
                for (int x = 0; x <= 2; x++)
                {
                    buttons[i].rectangle = new Rectangle(startX + month_label_width * x,
                        startY + month_label_height * y,
                        month_label_width,
                        month_label_height);
                    buttons[i].border = new Rectangle(startX + month_label_border + month_label_width * x,
                        startY + month_label_border + month_label_height * y,
                        month_label_width - month_label_border * 2 - 1,
                        month_label_height - month_label_border - 1);
                    if (this.Value.Year == selectedYear && this.Value.Month == buttons[i].Index)
                    {
                        SelectedButton = buttons[i];
                    }
                    PaintButton(buttons[i], graphics);
                    i++;
                }
            }

            // Предыдущая дата.
            buttons[i].rectangle = new Rectangle(startX, 0, month_label_width, month_label_height + 1);
            buttons[i].border = new Rectangle(startX + month_label_border, 0, month_label_width - month_label_border * 2 - 1, month_label_height);
            DrawNavigationButton(buttons[i], graphics);
            i++;

            // Заголовок.
            buttons[i].rectangle = new Rectangle(startX + month_label_width, 0, month_label_width, month_label_height + 1);
            buttons[i].border = new Rectangle(startX + month_label_border + month_label_width, 0, month_label_width - month_label_border * 2 - 1, month_label_height);
            DrawCaption(buttons[i], graphics);
            i++;

            // Следующая дата.
            buttons[i].rectangle = new Rectangle(startX + month_label_width * 2, 0, month_label_width, month_label_height + 1);
            buttons[i].border = new Rectangle(startX + month_label_border + month_label_width * 2, 0, month_label_width - month_label_border * 2 - 1, month_label_height);
            DrawNavigationButton(buttons[i], graphics);
            i++;

            // Линия.
            graphics.DrawLine(SystemPens.ControlLight,
                month_label_border * 4,
                startY + month_label_height * 4 + month_label_border * 2,
                this.Width - month_label_border * 4,
                startY + month_label_height * 4 + month_label_border * 2);

            // Переход к текущей дате.
            buttons[i].rectangle = new Rectangle(startX, startY + month_label_height * 4 + month_label_border * 3, month_label_width * 3, month_label_height + 1);
            buttons[i].border = new Rectangle(startX + month_label_border, startY + month_label_height * 4 + month_label_border * 5, month_label_width * 3 - month_label_border * 2 - 1, month_label_height - month_label_border);
            PaintButton(buttons[i], graphics);

            e.Graphics.DrawImage(backImage, 0, 0);
        }

        private void PaintButton(PeriodBoxButton button, Graphics graphics)
        {
            Color ForeColor;
            if (button.Equals(HoveringButton))
            {
                if (LeftPressedButton == null)
                {
                    if (button.Equals(SelectedButton))
                    {
                        FillButton(button, graphics, ButtonState.Selected | ButtonState.Hovering);
                        ForeColor = GetForeColor(ButtonState.Selected | ButtonState.Hovering);
                    }
                    else
                    {
                        FillButton(button, graphics, ButtonState.Hovering);
                        ForeColor = GetForeColor(ButtonState.Hovering);
                    }
                }
                else
                {
                    FillButton(button, graphics, ButtonState.Selected | ButtonState.Hovering);
                    ForeColor = GetForeColor(ButtonState.Selected | ButtonState.Hovering);
                }
            }
            else
            {
                if (button.Equals(SelectedButton))
                {
                    FillButton(button, graphics, ButtonState.Selected);
                    ForeColor = GetForeColor(ButtonState.Selected);
                }
                else
                {
                    FillButton(button, graphics, ButtonState.Passive);
                    ForeColor = GetForeColor(ButtonState.Passive);
                }
            }

            if (button.ForeColor != ForeColor)
            {
                button.ForeColor = ForeColor;
            }

            Brush ForeColorBrush = new SolidBrush(ForeColor);
            if (button.ButtonType == ButtonType.CaptionButton)
            {
                graphics.DrawString(selectedYear.ToString(), Font, ForeColorBrush, button.border, sf);
            }
            else if (button.ButtonType == ButtonType.TodayButton)
            {
                ForeColor = GetForeColor(ButtonState.Selected);
                Brush TodayForeColorBrush = new SolidBrush(this.ForeColor);
                graphics.DrawString(button.Text + ": ", Font, TodayForeColorBrush, button.border, sfL);
                Rectangle today = new Rectangle(button.border.X + today_label_width, button.border.Y, button.border.Width - today_label_width, button.border.Height);
                graphics.DrawString(Arm.PeriodDate.Today().ToShortDateString() + " г.", Font, ForeColorBrush, today, sfL);
            }
            else
            {
                graphics.DrawString(button.Text, Font, ForeColorBrush, button.border, sf);
            }
            ForeColorBrush.Dispose();
        }

        private void FillButton(PeriodBoxButton button, Graphics graphics, ButtonState buttonState)
        {
            Color BackColor;
            Brush BackColorBrush;

            if (button.ButtonType == ButtonType.CaptionButton | button.ButtonType == ButtonType.TodayButton)
            {
                BackColor = GetButtonColor(ButtonState.Passive, 0);
                BackColorBrush = new LinearGradientBrush(button.rectangle, BackColor, GetButtonColor(ButtonState.Passive, 1), LinearGradientMode.Vertical);
            }
            else
            {
                BackColor = GetButtonColor(buttonState, 0);
                BackColorBrush = new LinearGradientBrush(button.rectangle, BackColor, GetButtonColor(buttonState, 1), LinearGradientMode.Vertical);
            }

            button.BackColor = BackColor;
            graphics.FillRectangle(BackColorBrush, button.rectangle);
            BackColorBrush.Dispose();

            //if (button.ButtonType == ButtonType.CaptionButton | button.ButtonType == ButtonType.TodayButton) { return; }

            if (buttonState == ButtonState.Selected)
            {
                Color BorderColor = GetBorderColor(buttonState);
                button.BorderColor = BorderColor;
                Pen BorderColorPen = new Pen(BorderColor, 1);
                graphics.DrawRectangle(BorderColorPen, button.border);
                BorderColorPen.Dispose();
            }
        }

        private void DrawNavigationButton(PeriodBoxButton button, Graphics graphics)
        {
            Color ForeColor;
            if (button.Equals(HoveringButton) & !button.Equals(PressedButton))
            {
                ForeColor = GetForeColor(ButtonState.Selected | ButtonState.Hovering);
            }
            else
            {
                ForeColor = GetForeColor(ButtonState.Passive);
            }
            Brush ForeColorBrush = new SolidBrush(ForeColor);
            Point center = new Point(button.rectangle.X + button.rectangle.Width / 2, button.rectangle.Y + button.rectangle.Height / 2 - 2);

            if (button.ButtonType == ButtonType.PreviouseButton)
            {
                graphics.FillPolygon(ForeColorBrush, new Point[] {new Point(center.X - 2, center.Y), new Point(center.X + 2, center.Y - 4), new Point(center.X + 2, center.Y + 4) });                
            }
            if (button.ButtonType == ButtonType.NextButton)
            {            
                graphics.FillPolygon(ForeColorBrush, new Point[] { new Point(center.X + 2, center.Y), new Point(center.X - 2, center.Y - 4), new Point(center.X - 2, center.Y + 4) });
            }
            ForeColorBrush.Dispose();
        }

        private void DrawCaption(PeriodBoxButton button, Graphics graphics)
        {
            Color ForeColor;
            if (button.Equals(HoveringButton) & !button.Equals(PressedButton))
            {
                ForeColor = GetForeColor(ButtonState.Selected | ButtonState.Hovering);
            }
            else
            {
                ForeColor = GetForeColor(ButtonState.Passive);
            }
            Brush ForeColorBrush = new SolidBrush(ForeColor);
            Brush BackColorBrush = new SolidBrush(BackColor);

            if (button.ButtonType == ButtonType.CaptionButton)
            {
                graphics.FillRectangle(BackColorBrush, button.rectangle);
                graphics.DrawString(this.selectedYear.ToString(), Font, ForeColorBrush, button.border, sf);
            }
            ForeColorBrush.Dispose();
        }
        private Color GetButtonColor(ButtonState buttonState, int colorIndex)
        {
            switch (buttonState)
            {
                case ButtonState.Hovering | ButtonState.Selected:
                    if (colorIndex == 0) return Color.FromArgb(235, 244, 253);
                    if (colorIndex == 1) return Color.FromArgb(194, 220, 253);
                    break;
                case ButtonState.Hovering:
                    if (colorIndex == 0) return Color.FromArgb(253, 254, 255);
                    if (colorIndex == 1) return Color.FromArgb(243, 248, 255);
                    break;
                case ButtonState.Selected:
                    if (colorIndex == 0) return Color.FromArgb(249, 249, 249);
                    if (colorIndex == 1) return Color.FromArgb(241, 241, 241);
                    break;
                case ButtonState.Passive:
                    if (colorIndex == 0) return this.BackColor;
                    if (colorIndex == 1) return this.BackColor;
                    break;
                default:
                    if (colorIndex == 0) return this.BackColor;
                    if (colorIndex == 1) return this.BackColor;
                    break;
            }
            return this.BackColor;
        }

        private Color GetBorderColor(ButtonState buttonState)
        {
            switch (buttonState)
            {
                case ButtonState.Hovering | ButtonState.Selected:
                    return Color.FromArgb(0, 102, 204);
                case ButtonState.Hovering:
                    return Color.FromArgb(185, 215, 252);
                case ButtonState.Selected:
                    return Color.FromArgb(0, 102, 204);
                case ButtonState.Passive:
                    return this.BackColor;
                default:
                    return this.BackColor;
            }
        }

        private Color GetForeColor(ButtonState buttonState)
        {
            switch (buttonState)
            {
                case ButtonState.Hovering | ButtonState.Selected:
                    return Color.FromArgb(0, 102, 204);
                case ButtonState.Hovering:
                    return Color.FromArgb(0, 102, 204);
                case ButtonState.Selected:
                    return Color.FromArgb(0, 102, 204);
                case ButtonState.Passive:
                    return this.ForeColor;
                default:
                    return this.ForeColor;
            }
        }

        #region Mouse Event

        protected override void OnMouseDown(MouseEventArgs e)
        {
            PressedButton = buttons[e.X, e.Y];
            if (PressedButton != null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (PressedButton.ButtonType == ButtonType.PreviouseButton)
                    {
                        this.selectedYear--;
                        this.Invalidate();
                    }
                    else if (PressedButton.ButtonType == ButtonType.NextButton)
                    {
                        this.selectedYear++;
                        this.Invalidate();
                    }
                    else if (PressedButton.ButtonType == ButtonType.TodayButton)
                    {
                        this.Value = 0;
                        this.DoButtonClick();
                    }
                    else if (PressedButton.ButtonType == ButtonType.CaptionButton)
                    {
                        this.selectedYear = 0;
                        this.Invalidate();
                    }
                }
                this.Invalidate(PressedButton.rectangle);
            }
            base.OnMouseDown(e);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            PeriodBoxButton button = buttons[e.X, e.Y];
            if (button != null)
            {
                switch (e.Button)
                {
                    case MouseButtons.Left:
                        if (button.ButtonType == ButtonType.TodayButton)
                        {
                            this.Value = Arm.PeriodDate.Today();
                            this.DoButtonClick();
                        }
                        else if (button.ButtonType == ButtonType.CaptionButton)
                        {
                            this.Invalidate();
                        }
                        else if (button.ButtonType == ButtonType.PreviouseButton | button.ButtonType == ButtonType.NextButton)
                        {
                            this.Invalidate();
                        }
                        else
                        {
                            LeftPressedButton = button;
                            RightPressedButton = null;
                            this.Value = Arm.PeriodDate.Create(this.selectedYear, button.Index);
                            this.DoButtonClick();
                        }
                        break;
                    case MouseButtons.Right:
                        if (button.ButtonType == ButtonType.ItemButton)
                        {
                            RightPressedButton = button;
                            LeftPressedButton = null;
                            this.Invalidate();
                        }
                        break;
                }
            }
            base.OnMouseClick(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {   if (HoveringButton != null)
            {   Rectangle rec = HoveringButton.rectangle;
                HoveringButton = null;
                this.Invalidate(rec);
            }
            base.OnMouseLeave(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            PeriodBoxButton button = buttons[e.X, e.Y];
            if (button != null)
            {   this.Cursor = Cursors.Hand;
                if (HoveringButton != button)
                {  if (HoveringButton != null && HoveringButton.rectangle != null)
                    {
                        Rectangle rec = HoveringButton.rectangle;
                        this.Invalidate(rec);
                    }
                    HoveringButton = button;
                    this.Invalidate(HoveringButton.rectangle);
                }
            }
            else
            {
                if (HoveringButton != null)
                {
                    Rectangle rec = HoveringButton.rectangle;
                    HoveringButton = null;
                    this.Invalidate(rec);
                }
                this.Cursor = Cursors.Default;
            }
            base.OnMouseMove(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (PressedButton != null)
            {
                Rectangle rec = PressedButton.rectangle;
                PressedButton = null;
                this.Invalidate(rec);
            }
            base.OnMouseUp(e);
        }

        #endregion

        #region Value

        public int Value
        {
            get { return this.period; }
            set
            {
                this.selectedYear = value.Year;
                if (!Equals(this.period, value))
                {
                    this.period = value;
                    this.DoValueChanged();
                }
            }
        }

        public event EventHandler<Arm.PeriodEventArgs> ValueChanged;

        public void DoValueChanged()
        {
            this.Invalidate();
            this.OnValueChanged(new Arm.PeriodEventArgs(this.period));
        }

        protected virtual void OnValueChanged(Arm.PeriodEventArgs e)
        {
            ValueChanged?.Invoke(this, e);
        }

        #endregion

        #region Click

        /// <summary>
        /// Событие, возникающее ври нажатии кнопки.
        /// </summary>
        public event EventHandler ButtonClick;

        public void DoButtonClick()
        {
            this.Invalidate();
            this.OnButtonClick(new EventArgs());
        }

        protected virtual void OnButtonClick(EventArgs e)
        {
            ButtonClick?.Invoke(this, e);
        }

        #endregion

        internal class PeriodBoxButton
        {   internal PeriodControlBase owner;
            internal ButtonState state = ButtonState.Passive;
            internal bool visible = true;
            internal bool allowed = true;
            //Private _Image As Icon = My.Resources.DefaultIcon
            internal Rectangle border;
            internal Rectangle rectangle;
            internal bool selected = false;

            internal Color BackColor = Color.Transparent;
            internal Color BorderColor = Color.Transparent;
            internal Color ForeColor = Color.Transparent;

            public PeriodBoxButton(int index, string text, ButtonType type)
            {   this.ButtonType = type;
                this.Index = index;
                this.Text = text;
            }

            public ButtonType ButtonType { get; }
            public string Text { get; }
            public int Index { get; }
        }

        internal class PeriodBoxButtonCollection : CollectionBase
        {   PeriodControlBase owner;

            public PeriodBoxButtonCollection(PeriodControlBase owner) : base()
            {  this.owner = owner;
            }

            public PeriodBoxButton this[int index]
            {   get { return (PeriodBoxButton)base.List[index]; }
            }

            public PeriodBoxButton this[string text]
            {   get
                {
                    foreach (PeriodBoxButton item in base.List)
                    {
                        if (item.Text.Equals(text)) return item;
                    }
                    return null;
                }
            }

            public PeriodBoxButton this[int x, int y]
            {   get
                {   foreach (PeriodBoxButton item in base.List)
                    {   if (item.rectangle != null)
                        {   if (item.rectangle.Contains(new Point(x, y)))
                            { return item; }
                        }
                    }
                    return null;
                }
            }

            public int Add(PeriodBoxButton item)
            {   item.owner = this.owner;
                return base.List.Add(item);
            }

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")]
            public void AddRange(PeriodBoxButtonCollection items)
            {   foreach (PeriodBoxButton item in items)
                {   this.Add(item);
                }
            }

            public int IndexOf(PeriodBoxButton item)
            {   return base.List.IndexOf(item);
            }

            public void Insert(int index, PeriodBoxButton value)
            {
                base.List.Insert(index, value);
            }

            public void Remove(PeriodBoxButton value)
            {
                base.List.Remove(value);
            }

            public bool Contains(PeriodBoxButton value)
            {
                return base.List.Contains(value);
            }

            protected override void OnValidate(object value)
            {
                if (!typeof(PeriodBoxButton).IsAssignableFrom(value.GetType()))
                {
                    throw new ArgumentException("value не является типом PeriodBoxButton.", "value");
                }
            }
        }

        internal enum ButtonState : int
        {
            Passive = 0,
            Hovering = 1,
            Selected = 2
        }

        internal enum ButtonType : int
        {
            /// <summary>
            /// Основной заголовок элемента управления.
            /// </summary>
            CaptionButton = 0,
            /// <summary>
            /// Кнопка перехода к предыдущему периоду
            /// </summary>
            PreviouseButton = 1,
            /// <summary>
            /// Кнопка перехода к следующему периоду.
            /// </summary>
            NextButton = 2,
            /// <summary>
            /// Кнопка выбора периода.
            /// </summary>
            ItemButton = 3,
            /// <summary>
            /// Кнопка перехода к текущей дате.
            /// </summary>
            TodayButton = 4
        }
    }
}