﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace DatabaseToolSuite.Dialogs
{
    public partial class OrganizationDialog : Form
    {
        private long key;
        private long index;

        public OrganizationDialog(Repositoryes.RepositoryDataSet.gaspsRow row, Repositoryes.RepositoryDataSet.gaspsDataTable gasps, Repositoryes.RepositoryDataSet.okatoDataTable okato, Repositoryes.RepositoryDataSet.authorityDataTable authority)
        {
            InitializeComponent();

            Repositoryes.RepositoryDataSet.gaspsRow owner = gasps.GetLastVersionOrganizationFromKey(row.owner_id);
            if (owner !=null)
            {
                ownerTextBox.Text = owner.name;
            }
            else
            {
                ownerTextBox.Text = string.Empty;
            }

            okatoComboBox.InitializeSource(okato);
            authorityComboBox.InitializeSource(authority);

            codeTextBox.Text = row.code;
            authorityComboBox.Code = row.authority_id.ToString("00");
            okatoComboBox.Code = row.okato_code;
            nameTextBox.Text = row.name;
            beginDateTimePicker.Value = row.date_beg;
            endDateTimePicker.Value = row.date_end; 

            if (row.date_end <= DateTime.Today)
            {
                endDateTimePicker.ForeColor = Color.Red;
            }

            key = row.key;
            index = row.index;
        }

        public OrganizationDialog()
        {
            InitializeComponent();
        }

        private void OrganizationDialog_Load(object sender, EventArgs e)
        {

        }

        private void lockCodeButton_Click(object sender, EventArgs e)
        {

        }

        private void newButton_Click(object sender, EventArgs e)
        {
            codeTextBox.Text = string.Empty;
            beginDateTimePicker.Value = DateTime.Today;
            endDateTimePicker.Value = new DateTime(2999, 12, 31);
            ownerTextBox.Text = string.Empty;
            authorityComboBox.SelectedIndex = -1;
            okatoComboBox.SelectedIndex = -1;
            nameTextBox.Text = string.Empty;
            newButton.Enabled = false;
            cloneButton.Enabled = false;
            createButton.Enabled = false;
            lockButton.Enabled = false;
            exitButton.Text = "Отмена";
        }

        private void cloneButton_Click(object sender, EventArgs e)
        {
            newButton.Enabled = false;
            cloneButton.Enabled = false;
            createButton.Enabled = false;
            lockButton.Enabled = false;
            exitButton.Text = "Отмена";
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            newButton.Enabled = false;
            cloneButton.Enabled = false;
            createButton.Enabled = false;
            lockButton.Enabled = false;
            exitButton.Text = "Отмена";
        }

        private void lockButton_Click(object sender, EventArgs e)
        {
            newButton.Enabled = false;
            cloneButton.Enabled = false;
            createButton.Enabled = false;
            lockButton.Enabled = false;
            exitButton.Text = "Отмена";
        }

        private void exitButton_Click(object sender, EventArgs e)
        {

        }

        private void savaButton_Click(object sender, EventArgs e)
        {

        }


        private enum Mode: int
        {
            viewOrgaization = 0,
            newOrganization = 1,
            cloneOrganization = 2,
            versionOrganization = 3,
            lockOrganization = 4
        }
    }
}
