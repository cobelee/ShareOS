using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinUI.Dialog
{
    public partial class GetSharesIssueConfig : Form
    {
        ShareOS.BLL.SharesBonusManage bll_SharesBonus = new ShareOS.BLL.SharesBonusManage();
        private ShareOS.Model.SharesIssueConfig sharesIssueConfig;

        public ShareOS.Model.SharesIssueConfig SharesIssueConfig
        {
            get { return sharesIssueConfig; }
        }


        public GetSharesIssueConfig()
        {
            InitializeComponent();
        }

        protected decimal GetNewIssueNumber()
        {
            return Convert.ToDecimal(bll_SharesBonus.GetLastIssueNumber() + 1);
        }

        protected void DataBind_IssueNumber()
        {
            nudIssueNumber.Value = GetNewIssueNumber();
        }

        private void GetSharesIssueConfig_Load(object sender, EventArgs e)
        {
            DataBind_IssueNumber();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            sharesIssueConfig = new ShareOS.Model.SharesIssueConfig();
            sharesIssueConfig.IssueNumber = Convert.ToInt32(nudIssueNumber.Value);
            sharesIssueConfig.DPD = dtpDPD.Value;
            sharesIssueConfig.IssueYear = dtpDPD.Value.Year;
            sharesIssueConfig.Bonus = Convert.ToDecimal(tbBonus.Text);
            sharesIssueConfig.SharePrice = Convert.ToDecimal(tbSharePrice.Text);
            sharesIssueConfig.IsDistributed = false;

        }
    }
}