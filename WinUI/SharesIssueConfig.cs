using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinUI
{
    public partial class SharesIssueConfig : Form
    {
        ShareOS.BLL.ShareIssueManage bll_issue = new ShareOS.BLL.ShareIssueManage();
        ShareOS.BLL.SharesBonusManage bll_bonus = new ShareOS.BLL.SharesBonusManage();

        public SharesIssueConfig()
        {
            InitializeComponent();
        }

        private void DataBind_Config()
        {
           var configs = bll_issue.GetAllIssueConfigs();
            //IList<Tiyi.> configs = bll_issue.GetIssueConfigs();
            dgvConfig.DataSource = configs;
        }

        private void SharesIssueConfig_Load(object sender, EventArgs e)
        {
            DataBind_Config();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Dialog.GetSharesIssueConfig dlgConfig = new WinUI.Dialog.GetSharesIssueConfig();
            if (dlgConfig.ShowDialog(this) == DialogResult.OK)
            {
                ShareOS.Model.SharesIssueConfig config = dlgConfig.SharesIssueConfig;
                if (config != null)
                {
                    bll_bonus.InsertSharesIssueConfig(config.IssueNumber, config.Bonus, config.SharePrice, config.DPD);
                    DataBind_Config();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvConfig.SelectedRows.Count > 0)
            {
                int issueNumber = 0;
                issueNumber = Convert.ToInt32(dgvConfig.SelectedRows[0].Cells["IssueNumber"].Value);
                bll_bonus.DeleteSharesIssueConfig(issueNumber);
                DataBind_Config();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPayBonus_Click(object sender, EventArgs e)
        {
            if (dgvConfig.SelectedRows.Count > 0)
            {
                int issueNumber = 0;
                issueNumber = Convert.ToInt32(dgvConfig.SelectedRows[0].Cells["IssueNumber"].Value);
                bll_bonus.PayBonus(issueNumber);
                DataBind_Config();
            }
        }

        private void dgvConfig_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvConfig.SelectedRows.Count > 0)
            {
                bool isDistributed = false;
                isDistributed = Convert.ToBoolean(dgvConfig.SelectedRows[0].Cells["IsDistributed"].Value);
                btnPayBonus.Enabled = !isDistributed;
            }
        }
    }
}