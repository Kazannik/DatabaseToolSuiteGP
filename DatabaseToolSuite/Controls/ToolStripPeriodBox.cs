using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace DatabaseToolSuite.Controls
{
    [DesignerCategory("code")]
    [ToolboxBitmap(typeof(ComboBox))]
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.All)]
    public class ToolStripPeriodBox: ToolStripControlHost
    {
        public ToolStripPeriodBox():base(new PeriodComboBox())
        {
            this.PeriodComboBox.Height = 10;
            this.PeriodComboBox.ValueChanged += new System.EventHandler<EventArgs>(PeriodComboBox_ValueChanged);
        }

        public PeriodComboBox PeriodComboBox
        {
            get { return (PeriodComboBox)base.Control; }
        }

        #region ValueChanged

        public Arm.PeriodDate Value
        {
            get { return this.PeriodComboBox.Value; }
            set { this.PeriodComboBox.Value = value; }
        }

        public event EventHandler ValueChanged;

        public void DoValueChanged()
        {
            this.OnValueChanged(new EventArgs(this.Value));
        }

        protected virtual void OnValueChanged(EventArgs e)
        {
            ValueChanged?.Invoke(this, e);
        }

        private void PeriodComboBox_ValueChanged(Object sender, EventArgs e)
        {
            this.DoValueChanged();
        }

        #endregion
    }
}
