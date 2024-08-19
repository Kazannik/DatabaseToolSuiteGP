using System;
using System.Drawing;
using System.Windows.Forms;

namespace DatabaseToolSuite.Controls
{
    public partial class PeriodPickerPopupForm : UserControl
    {
        public PeriodPickerPopupForm()
        {
            InitializeComponent();
        }

        private void PeriodPickerPopupForm_Resize(object sender, EventArgs e)
        {
            this.PopupMenu_PeriodBox.Location = new Point(0, 0);
            this.Size = this.PopupMenu_PeriodBox.Size;
        }

        #region Value

        public int Value
        {
            get { return this.PopupMenu_PeriodBox.Value; }
            set { this.PopupMenu_PeriodBox.Value = value; }            
        }

        private void PopupMenu_PeriodBox_ValueChanged(object sender, EventArgs e)
        {
            this.OnValueChanged(new EventArgs());
        }

        public event EventHandler<EventArgs> ValueChanged;
        
        protected virtual void OnValueChanged(EventArgs e)
        {
            EventHandler<EventArgs> ValueChangedEvent = ValueChanged;
            if (ValueChangedEvent != null)
            {
                ValueChangedEvent(this, e);
            }
        }

        #endregion

        #region Click

        private void PeriodBox_ButtonClick(object sender, EventArgs e)
        {
            this.OnButtonClick(new EventArgs());
        }

        public event EventHandler ButtonClick;

        protected virtual void OnButtonClick(EventArgs e)
        {
            EventHandler ButtonClickEvent = ButtonClick;
            if (ButtonClickEvent != null)
            {
                ButtonClickEvent(this, e);
            }
        }

        #endregion        
    }
}
