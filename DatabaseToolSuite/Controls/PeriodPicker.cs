using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using ExcelAnalyzer.Arm;

namespace DatabaseToolSuite.Controls
{
    [DesignerCategory("code")]
    [ToolboxBitmap(typeof(ComboBox))]
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.All)]
    public class PeriodPicker : Base.PickerControlBase
    {
        PeriodPopupForm periodbox;

        public PeriodPicker() : base(new PeriodPopupForm())
        {
            this.periodbox = (PeriodPopupForm)this.control;
            this.periodbox.ButtonClick += new EventHandler(Periodbox_ButtonClick);
            this.periodbox.ValueChanged += new EventHandler<EventArgs>(PeriodBox_ValueChanged);
        }

        #region Value

        public int Value
        {
            get { return this.periodbox.Value; }
            set { this.periodbox.Value = value; }
        }

        public event EventHandler<EventArgs> ValueChanged;       

        protected virtual void OnValueChanged(EventArgs e)
        {
            ValueChanged?.Invoke(this, e);
        }
        
        private void PeriodBox_ValueChanged(object sender, EventArgs e)
        {
            this.OnValueChanged(e);
        }

        #endregion

        private void Periodbox_ButtonClick(object sender, EventArgs e)
        {
            this.HideDropDown();
        }

        protected override void OnPaintDisplay(PaintEventArgs e)
        {

        }
    }
}
