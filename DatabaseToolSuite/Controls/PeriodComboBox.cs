using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace DatabaseToolSuite.Controls
{
    [System.Drawing.ToolboxBitmap(typeof(System.Windows.Forms.ComboBox))]
    public class PeriodComboBox: Base.PickerControlBase
    {
        private Rectangle FirstDecimalMonthRect;
        private Rectangle LastDecimalMonthRect;

        private Rectangle YearDecimalRect_01;
        private Rectangle YearDecimalRect_02;
        private Rectangle YearDecimalRect_03;
        private Rectangle YearDecimalRect_04;

        private int FirstDecimal;
        private int LastDecimal;

        private int YearDecimal_01;
        private int YearDecimal_02;
        private int YearDecimal_03;
        private int YearDecimal_04;

        private Rectangle monthRect;
        private Rectangle yearRect;

        private StateType state;

        enum StateType
        {
            Default = 0,
            SelectMonth = 1,
            SelectYear = 2,
            SelectMonthFirstDecimal = 3,
            SelectMonthLastDecimal = 4,
            SelectYearDecimal_01 = 5,
            SelectYearDecimal_02 = 6,
            SelectYearDecimal_03 = 7,
            SelectYearDecimal_04 = 8
        }


        public PeriodComboBox(): base(new PeriodPopupForm())
        {
            this.SuspendLayout();
            ((PeriodControlBase)this.Control).ButtonClick += new EventHandler(Periodbox_ButtonClick);
            ((PeriodControlBase)this.Control).ValueChanged += new System.EventHandler<EventArgs>(this.PeriodBox_ValueChanged);


            //dropDown.Closing += new ToolStripDropDownClosingEventHandler (DropDown_Closing);
            //dropDown.Closed += new ToolStripDropDownClosedEventHandler(DropDown_Closed);
            //dropDown.GotFocus += new EventHandler( DropDown_GotFocus);
            //dropDown.LostFocus += new EventHandler(DropDown_LostFocus);
            //dropDown.Opening += new CancelEventHandler(DropDown_Opening);
            //dropDown.Opened += new EventHandler(DropDown_Opened);               

            //dropDown.VisibleChanged += new EventHandler(DropDown_VisibleChanged);

            //controlHost.Width = this.DropDownWidth;
            //controlHost.Height = this.DropDownHeight;

            //PeriodBox.ButtonClick += new System.EventHandler(this.PeriodBox_ButtonClick);
            this.ResumeLayout(false);
            this.OnResize(new EventArgs());
        }

        public Arm.PeriodDate Value {
            get { return ((PeriodControlBase)this.Control).Value; }
            set { ((PeriodControlBase)this.Control).Value = value; }
        }
        
        #region Value       

        public event EventHandler<EventArgs> ValueChanged;

        public void DoValueChanged()
        {
            this.Invalidate();
            this.OnValueChanged(new EventArgs(this.Value));
        }

        protected virtual void OnValueChanged(EventArgs e)
        {
            ValueChanged?.Invoke(this, e);
        }

        private void PeriodBox_ValueChanged(object sender, EventArgs e)
        {
            this.DoValueChanged();
        }

        #endregion
        
        private void Periodbox_ButtonClick(object sender, EventArgs e)
        {
            HideDropDown();
            this.Invalidate();
        }

        protected override void OnGotFocus(EventArgs e)
        {   base.OnGotFocus(e);
            this.state = StateType.Default;
            this.Invalidate();
        }

        protected override void OnLostFocus(EventArgs e)
        {   base.OnLostFocus(e);
            this.state = StateType.Default;
            this.Invalidate();
        }          
   
        protected override void OnPreviewKeyDown(PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {   if (state == StateType.Default)
                { state = StateType.SelectYear; }
                else if (state == StateType.SelectYear)
                { state = StateType.SelectMonth; }
                else if (state == StateType.SelectMonth)
                { state = StateType.SelectYear; }
                else if (state == StateType.SelectMonthLastDecimal)
                { state = StateType.SelectMonthFirstDecimal; }
                this.Invalidate();
                e.IsInputKey = true;
            }
            else if (e.KeyCode == Keys.Right)
            {   if (state == StateType.Default)
                { state = StateType.SelectMonth; }
                else if (state == StateType.SelectMonth)
                { state = StateType.SelectYear; }
                else if (state == StateType.SelectYear)
                { state = StateType.SelectMonth; }
                else if (state == StateType.SelectMonthFirstDecimal)
                { state = StateType.SelectMonthLastDecimal; }

                this.Invalidate();
                e.IsInputKey = true;
            }
            else if (e.KeyCode == Keys.Up)
            {
                if (state == StateType.Default)
                {
                    state = StateType.SelectMonth;
                    this.Value = Arm.PeriodDate.Create(this.Value.Year, this.Value.PreviouseMonth.Month);
                }
                else if (state == StateType.SelectMonth)
                {
                    this.Value = Arm.PeriodDate.Create(this.Value.Year, this.Value.PreviouseMonth.Month);
                }
                else if (state == StateType.SelectYear)
                {
                    this.Value = this.Value.PreviouseYear;
                }
                else
                {
                }
                this.Invalidate();
                e.IsInputKey = true;
            }
            else if (e.KeyCode == Keys.Down)
            {
                if (state == StateType.Default)
                {
                    state = StateType.SelectMonth;
                    this.Value = Arm.PeriodDate.Create(this.Value.Year, this.Value.NextMonth.Month);
                }
                 else if (state == StateType.SelectMonth)
                {
                    this.Value = Arm.PeriodDate.Create(this.Value.Year, this.Value.NextMonth.Month);
                }
                else if (state == StateType.SelectYear)
                {
                    this.Value = this.Value.NextYear;
                }
                else
                {
                }
                this.Invalidate();
                e.IsInputKey = true;
            }
            else if (IsDecimal(e.KeyCode))
            {
                int code = DecimalKeyCodeToInt(e.KeyCode);
                if (state == StateType.Default | state == StateType.SelectMonth)
                {
                    GetDecimal(this.Value);
                    state = StateType.SelectMonthFirstDecimal;
                    if (code <= 1)
                    {
                        FirstDecimal = code;
                        state = StateType.SelectMonthLastDecimal;
                    }
                    else
                    {
                        FirstDecimal = 0;
                        LastDecimal = code;
                        state = StateType.SelectMonthLastDecimal;
                    }
                }
                else if (state == StateType.SelectYear)
                {
                    GetDecimal(this.Value);
                    state = StateType.SelectMonthFirstDecimal;
                }

                this.Invalidate();
                e.IsInputKey = true;
            }
            else if (e.KeyCode == Keys.Enter & IsDecimal(state))
            {   this.Invalidate();
                e.IsInputKey = true;
            }
            else if (e.KeyCode == Keys.Escape & IsDecimal(state))
            {   this.Invalidate();
                e.IsInputKey = true;
            }

            else
            {
                e.IsInputKey = false;
            }
            Debug.WriteLine("OnPreviewKeyDown " + e.KeyCode.ToString());
            base.OnPreviewKeyDown(e);
        }

        protected override void OnPaintDisplay(PaintEventArgs e)
        {
            if (state == StateType.SelectMonth)
            {
                e.Graphics.FillRectangle(SystemBrushes.Highlight, monthRect);
                TextRenderer.DrawText(e.Graphics, this.Value.MonthToString(), this.Font, monthRect, SystemColors.HighlightText, TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
                TextRenderer.DrawText(e.Graphics, this.Value.Year.ToString() + " г.", this.Font, yearRect, this.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
            }
            else if (state == StateType.SelectYear)
            {
                e.Graphics.FillRectangle(SystemBrushes.Highlight, yearRect);
                TextRenderer.DrawText(e.Graphics, this.Value.MonthToString(), this.Font, monthRect, this.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
                TextRenderer.DrawText(e.Graphics, this.Value.Year.ToString() + " г.", this.Font, yearRect, SystemColors.HighlightText, TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
            }
            else if (state == StateType.SelectMonthFirstDecimal)
            {
                e.Graphics.FillRectangle(SystemBrushes.Highlight, FirstDecimalMonthRect);
                TextRenderer.DrawText(e.Graphics, FirstDecimal.ToString(), this.Font, FirstDecimalMonthRect, SystemColors.HighlightText, TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
                TextRenderer.DrawText(e.Graphics, LastDecimal.ToString(), this.Font, LastDecimalMonthRect, this.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
                TextRenderer.DrawText(e.Graphics, this.Value.Year.ToString() + " г.", this.Font, yearRect, this.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
            }
            else if (state == StateType.SelectMonthLastDecimal)
            {
                e.Graphics.FillRectangle(SystemBrushes.Highlight, LastDecimalMonthRect);
                TextRenderer.DrawText(e.Graphics, FirstDecimal.ToString(), this.Font, FirstDecimalMonthRect, this.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
                TextRenderer.DrawText(e.Graphics, LastDecimal.ToString(), this.Font, LastDecimalMonthRect, SystemColors.HighlightText, TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
                TextRenderer.DrawText(e.Graphics, this.Value.Year.ToString() + " г.", this.Font, yearRect, this.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
            }
            else
            {
                TextRenderer.DrawText(e.Graphics, this.Value.MonthToString(), this.Font, e.ClipRectangle, this.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
                //TextRenderer.DrawText(e.Graphics, this.Value.Year.ToString() + " г.", this.Font, yearRect, this.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
            }
        }

        

        protected override void OnResize(EventArgs e)
        {
            Graphics graphics = this.CreateGraphics();
            SizeF monthSize = graphics.MeasureString("########", this.Font);
            SizeF yearSize = graphics.MeasureString("######", this.Font);
            SizeF decimalSize = graphics.MeasureString("#", this.Font);

            monthRect = new Rectangle(SystemInformation.FrameBorderSize.Width, SystemInformation.FrameBorderSize.Height, (int)monthSize.Width,(int) monthSize.Height );
            yearRect = new Rectangle(monthRect.Left + monthRect.Width, SystemInformation.FrameBorderSize.Height, (int)yearSize.Width, monthRect.Height);

            FirstDecimalMonthRect = new Rectangle(monthRect.Width / 2 - (int)decimalSize.Width, SystemInformation.FrameBorderSize.Height, (int)decimalSize.Width, monthRect.Height);
            LastDecimalMonthRect = new Rectangle(monthRect.Width / 2, SystemInformation.FrameBorderSize.Height, (int)decimalSize.Width, monthRect.Height);

            YearDecimalRect_01 = new Rectangle(yearRect.Width / 2 - (int)decimalSize.Width * 2, SystemInformation.FrameBorderSize.Height, (int)decimalSize.Width, monthRect.Height);
            YearDecimalRect_02 = new Rectangle(yearRect.Width / 2 - (int)decimalSize.Width, SystemInformation.FrameBorderSize.Height, (int)decimalSize.Width, monthRect.Height);
            YearDecimalRect_03 = new Rectangle(yearRect.Width / 2, SystemInformation.FrameBorderSize.Height, (int)decimalSize.Width, monthRect.Height);
            YearDecimalRect_04 = new Rectangle(yearRect.Width / 2 + (int)decimalSize.Width, SystemInformation.FrameBorderSize.Height, (int)decimalSize.Width, monthRect.Height);

            this.Size = new Size(SystemInformation.FrameBorderSize.Width * 2 + monthRect.Width + yearRect.Width + this.ButtonRectagle.Width, monthRect.Height + SystemInformation.FrameBorderSize.Height * 2);
            base.OnResize(e);
            this.Invalidate();
        }


        private void GetDecimal(Arm.PeriodDate period)
        {
            FirstDecimal = period[0];
            LastDecimal = period[1];
            YearDecimal_01 = period[2];
            YearDecimal_02 = period[3];
            YearDecimal_03 = period[4];
            YearDecimal_04 = period[5];
        }

        private Arm.PeriodDate GetPeriod()
        {
            return Arm.PeriodDate.Create(FirstDecimal, LastDecimal, YearDecimal_01, YearDecimal_02, YearDecimal_03, YearDecimal_04);
        }

        private static bool IsDecimal(Keys KeyCode)
        {
            return KeyCode == Keys.D0
                | KeyCode == Keys.D1
                | KeyCode == Keys.D2
                | KeyCode == Keys.D3
                | KeyCode == Keys.D4
                | KeyCode == Keys.D5
                | KeyCode == Keys.D6
                | KeyCode == Keys.D7
                | KeyCode == Keys.D8
                | KeyCode == Keys.D9;
        }

        private static bool IsDecimal(StateType type)
        {
            return type == StateType.SelectMonthFirstDecimal
                | type == StateType.SelectMonthLastDecimal
                | type == StateType.SelectYearDecimal_01
                | type == StateType.SelectYearDecimal_02
                | type == StateType.SelectYearDecimal_03
                | type == StateType.SelectYearDecimal_04;
        }

        private static int DecimalKeyCodeToInt(Keys KeyCode)
        {
            if (KeyCode == Keys.D1)
            { return 1; }
            else if (KeyCode == Keys.D2)
            { return 2; }
            else if (KeyCode == Keys.D3)
            { return 3; }
            else if (KeyCode == Keys.D4)
            { return 4; }
            else if (KeyCode == Keys.D5)
            { return 5; }
            else if (KeyCode == Keys.D6)
            { return 6; }
            else if (KeyCode == Keys.D7)
            { return 7; }
            else if (KeyCode == Keys.D8)
            { return 8; }
            else if (KeyCode == Keys.D9)
            { return 9; }
            else
            { return 0; }
        }
    }
}

