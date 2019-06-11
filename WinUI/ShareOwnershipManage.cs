using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace WinUI
{
    public partial class ShareOwnershipManage : Form
    {
        ShareOS.BLL.ShareOwnershipManage bll_ownership = new ShareOS.BLL.ShareOwnershipManage();
        ShareOS.BLL.SharesBonusManage bll_bonus = new ShareOS.BLL.SharesBonusManage();
        ShareOS.BLL.FundAccount bll_Fund = new ShareOS.BLL.FundAccount();

        public ShareOwnershipManage()
        {
            InitializeComponent();
        }

        protected void DataBind_ShareOwnership()
        {
            int issueNumber = bll_bonus.GetLastIssueNumber();
            DataView dv = bll_ownership.GetShareOwnershipReport(issueNumber).DefaultView;

            dgvShareOwnership.DataSource = dv;
            dgvShareOwnership.Columns["BarCode"].Visible = false;
        }

        private void ShareOwnershipManage_Load(object sender, EventArgs e)
        {
            DataBind_ShareOwnership();
        }

        private void btnIncrease_Click(object sender, EventArgs e)
        {
            int shareholderNumber = 0;
            int shareOwnershipAmount = 0;

            Dialog.GetInteger getInteger = new WinUI.Dialog.GetInteger();

            if (dgvShareOwnership.SelectedRows.Count > 0 && getInteger.ShowDialog(this) == DialogResult.OK)
            {
                shareholderNumber = Convert.ToInt32(dgvShareOwnership.SelectedRows[0].Cells["ShareholderNumber"].Value);
                shareOwnershipAmount = getInteger.ShareOwnershipAmount;
                bll_ownership.BuyShares(shareholderNumber, shareOwnershipAmount, bll_ownership.GetCurrentSharePrice(), "System");
                DataBind_ShareOwnership();
            }

        }

        private void btnDecrease_Click(object sender, EventArgs e)
        {
            int shareholderNumber = 0;
            int shareOwnershipAmount = 0;

            Dialog.GetInteger getInteger = new WinUI.Dialog.GetInteger();

            if (dgvShareOwnership.SelectedRows.Count > 0 && getInteger.ShowDialog(this) == DialogResult.OK)
            {
                shareholderNumber = Convert.ToInt32(dgvShareOwnership.SelectedRows[0].Cells["ShareholderNumber"].Value);
                shareOwnershipAmount = getInteger.ShareOwnershipAmount;
                bll_ownership.Tuigu(shareholderNumber, shareOwnershipAmount, bll_ownership.GetCurrentSharePrice(), "System");
                DataBind_ShareOwnership();
            }
        }

        private void btnHistoryRecord_Click(object sender, EventArgs e)
        {
            if (dgvShareOwnership.SelectedRows.Count > 0)
            {
                int shareholderNumber = 0;
                shareholderNumber = Convert.ToInt32(dgvShareOwnership.SelectedRows[0].Cells["ShareholderNumber"].Value);
                PersonalShareOwnership pso = new PersonalShareOwnership(shareholderNumber);
                pso.Show(this);

            }

        }


        private void btnBuyShareOwnership_Click(object sender, EventArgs e)
        {
            Dialog.BuyShareOwnership buySO = new WinUI.Dialog.BuyShareOwnership();

            if (dgvShareOwnership.SelectedRows.Count > 0 && buySO.ShowDialog(this) == DialogResult.OK && buySO.SharesAmount > 0)
            {
                int shareholderNumber;
                int issueNumber = bll_bonus.GetLastIssueNumber();

                foreach (DataGridViewRow row in dgvShareOwnership.SelectedRows)
                {
                    shareholderNumber = Convert.ToInt32(row.Cells["ShareholderNumber"].Value);
                    //增加股权。
                    bll_ownership.BuyShares(shareholderNumber, buySO.SharesAmount, bll_ownership.GetCurrentSharePrice(), "System");
                    //个人资金帐户变动。
                    bll_Fund.InsertFundAccountRecord(issueNumber, shareholderNumber, buySO.Money, ShareOS.Model.个人资金帐户变动因素.购股.ToString(), System.DateTime.Now);

                    row.Cells["ShareTotals"].Value = Convert.ToInt32(row.Cells["ShareTotals"].Value) + buySO.SharesAmount;
                }
            }
        }
    }
}