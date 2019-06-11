using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ShareOS.BLL;

namespace WinUI.Dialog
{
    public partial class SelectEntrustedAgent : Form
    {
        ShareOS.BLL.EntrustedAgent bll_EntrustedAgent = new EntrustedAgent();

        ShareOS.Model.EntrustedAgent selectedEntrustedAgent;

        /// <summary>
        /// 当前选中的股权委托代理人。
        /// </summary>
        public ShareOS.Model.EntrustedAgent SelectedEntrustedAgent
        {
            get { return selectedEntrustedAgent; }
        }

        public SelectEntrustedAgent()
        {
            InitializeComponent();
        }

        protected void DataBind_EntrustedAgent()
        {
            IList<ShareOS.Model.EntrustedAgent> eas = bll_EntrustedAgent.Select();
            lvEntrustedAgents.Items.Clear();
            foreach (ShareOS.Model.EntrustedAgent ea in eas)
            {
                ListViewItem item = new ListViewItem();
                item.Tag = ea;
                item.Text = ea.ShareholderName;
                item.SubItems.Add(ea.ShareholderNumber.ToString());
                item.SubItems.Add(ea.Sex ? "男" : "女");
                lvEntrustedAgents.Items.Add(item);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Dialog.SelectShareholder dialog = new WinUI.Dialog.SelectShareholder();
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                AddShareholder(dialog.SelectedShareholders);
            }
        }

        private void AddShareholder(IList<ShareOS.Model.Shareholder> shareholders)
        {
            foreach (ShareOS.Model.Shareholder sh in shareholders)
            {
                ShareOS.Model.EntrustedAgent ea = new ShareOS.Model.EntrustedAgent();
                sh.CopyTo(ea as ShareOS.Model.Shareholder);
                bll_EntrustedAgent.Insert(ea);

                ListViewItem item = new ListViewItem();
                item.Tag = ea;
                item.Text = ea.ShareholderName;
                item.SubItems.Add(ea.ShareholderNumber.ToString());
                item.SubItems.Add(ea.Sex ? "男" : "女");
                lvEntrustedAgents.Items.Add(item);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvEntrustedAgents.Items)
            {
                if (item.Checked)
                {
                    ShareOS.Model.EntrustedAgent ea = item.Tag as ShareOS.Model.EntrustedAgent;
                    bll_EntrustedAgent.Delete(ea.ShareholderNumber);
                    item.Remove();
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }

        private void EntrustedAgentManage_Load(object sender, EventArgs e)
        {
            DataBind_EntrustedAgent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (lvEntrustedAgents.CheckedItems.Count > 0)
            {
                selectedEntrustedAgent = lvEntrustedAgents.CheckedItems[0].Tag as ShareOS.Model.EntrustedAgent;
            }
        }
    }
}