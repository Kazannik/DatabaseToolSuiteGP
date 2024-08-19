using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace DatabaseToolSuite.Controls
{
    [DesignerCategory("code")]
    [ToolboxBitmap(typeof(TextBox))]
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.All)]
    public class ToolStripNumericTextBox : ToolStripControlHost
    {
        public ToolStripNumericTextBox() : base(new NumericTextBox())
        {
            this.NumericTextBoxControl.TextChanged += new EventHandler(Numeric_ValueChanged);
        }

        public NumericTextBox NumericTextBoxControl
        {
            get { return (NumericTextBox)base.Control; }
        }

        #region ValueChanged

        public long Value
        {
            get { return NumericTextBoxControl.Value; }
        }

        public event EventHandler ValueChanged;

        public void DoValueChanged()
        {
            this.OnValueChanged(new EventArgs());
        }

        protected virtual void OnValueChanged(EventArgs e)
        {
            ValueChanged?.Invoke(this, e);
        }

        private void Numeric_ValueChanged(Object sender, EventArgs e)
        {
            this.DoValueChanged();
        }

        #endregion
    }
}