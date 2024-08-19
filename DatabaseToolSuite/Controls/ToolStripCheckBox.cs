using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace DatabaseToolSuite.Controls
{
    [DesignerCategory("code")]
    [ToolboxBitmap(typeof(CheckBox))]
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.All)]
    public class ToolStripCheckBox : ToolStripControlHost
    {
        public ToolStripCheckBox():base(new CheckBox())
        {
            this.CheckBoxControl.CheckedChanged += new System.EventHandler(CheckBox_CheckedChanged);
            this.CheckBoxControl.CheckStateChanged += new System.EventHandler(CheckBox_CheckStateChanged);
        }

        public CheckBox CheckBoxControl
        {
            get { return (CheckBox)base.Control; }
        }

        #region CheckedChanged

        public bool Checked
        {
            get { return this.CheckBoxControl.Checked; }
            set { this.CheckBoxControl.Checked = value; }
        }
        
        public event EventHandler CheckedChanged;

        public void DoCheckedChanged()
        {
            //...

            this.OnCheckedChanged(new EventArgs());
        }

        protected virtual void OnCheckedChanged(EventArgs e)
        {
            CheckedChanged?.Invoke(this, e);
        }

        private void CheckBox_CheckedChanged(Object sender, EventArgs e)
        {
            this.DoCheckedChanged();
        }

        #endregion

        #region CheckStateChanged

        public CheckState CheckState
        {
            get { return this.CheckBoxControl.CheckState; }
            set { this.CheckBoxControl.CheckState = value; }
        }

        public event EventHandler CheckStateChanged;

        public void DoCheckStateChanged()
        {
            this.OnCheckStateChanged(new EventArgs());
        }

        protected virtual void OnCheckStateChanged(EventArgs e)
        {
            EventHandler CheckStateChangedEvent = CheckStateChanged;
            if (CheckStateChangedEvent != null)
            {
                CheckStateChangedEvent(this, e);
            }
        }

        private void CheckBox_CheckStateChanged(Object sender, EventArgs e)
        {
            this.DoCheckStateChanged();
        }

        #endregion
    }
}
