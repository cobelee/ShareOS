using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinUI
{
    public partial class Option : Form
    {
        
        public Option()
        {
            InitializeComponent();

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            switch (e.Node.Text)
            {
                case "公司全称": LoadDeveloper();
                    break;
                case "个人所得税率": LoadIRPEF();
                    break;
            }
        }

        private void LoadDeveloper()
        {
            UC.SettingCompanyName companyName = new WinUI.UC.SettingCompanyName();
            panel1.Controls.Clear();
            panel1.Controls.Add(companyName as Control);
            this.btnOK.Click += new EventHandler(companyName.Save);
        }

        private void LoadIRPEF()
        {
            UC.SettingIRPEF irpef = new WinUI.UC.SettingIRPEF();
            panel1.Controls.Clear();
            panel1.Controls.Add(irpef as Control);
            this.btnOK.Click += new EventHandler(irpef.Save);
        }

    }
}