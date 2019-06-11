using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace WinUI.UC
{
    public partial class SettingCompanyName : UserControl
    {
        public SettingCompanyName()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            if (!string.IsNullOrEmpty(Properties.Settings.Default.CompanyName))
            {
                tbCompanyName.Text = Properties.Settings.Default.CompanyName;
            }
        }

        
        public void Save(object sender, EventArgs e)
        {
            Properties.Settings.Default.CompanyName = tbCompanyName.Text;
            Properties.Settings.Default.Save();
        }
    }
}
