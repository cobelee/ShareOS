using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace WinUI.UC
{
    /// <summary>
    /// 设置个人所得税率
    /// </summary>
    public partial class SettingIRPEF : UserControl
    {
        public SettingIRPEF()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            tbIRPEF.Text = Properties.Settings.Default.IRPEF.ToString();
        }

        public void Save(object sender, EventArgs e)
        {
            decimal irpef = 0m;
            if (decimal.TryParse(tbIRPEF.Text, out irpef))
            {
                Properties.Settings.Default.IRPEF = irpef;
                Properties.Settings.Default.Save();
            }
        }

    }
}
