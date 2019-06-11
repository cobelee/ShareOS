using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinUI
{
    public partial class ScaleRationedShares : Form
    {
        ShareOS.BLL.SharesBonusManage bll_bonus = new ShareOS.BLL.SharesBonusManage();
        ShareOS.BLL.ShareOwnershipManage bll_shareManage = new ShareOS.BLL.ShareOwnershipManage();

        public ScaleRationedShares()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 股权期数下拉框绑定数据。
        /// </summary>
        private void cbbIssueNumber_DataBind()
        {
            int currentIssueNumber = 0;
            currentIssueNumber = bll_bonus.GetLastIssueNumber();
            cbbIssueNumber.Items.Clear();
            for (int i = currentIssueNumber; i >= 0; i--)
            {
                cbbIssueNumber.Items.Add(i);
            }

        }

        private void ScaleRationedShares_Load(object sender, EventArgs e)
        {
            cbbIssueNumber_DataBind();
            if (cbbIssueNumber.Items.Count > 0)
                cbbIssueNumber.SelectedIndex = 0;

            lbTotalShares.Text = bll_shareManage.GetCorporateShareTotals().ToString("N0");
        }

        private void btnPeigu_Click(object sender, EventArgs e)
        {
            int issueNumber = Convert.ToInt32( cbbIssueNumber.SelectedItem);
            decimal rationScale = 0;
            decimal.TryParse(tbRationScale.Text, out rationScale);
            decimal sharePrice = 0;
            Decimal.TryParse(tbSharePrice.Text, out sharePrice);

            

            if (rationScale > 0)
            {
                System.Text.StringBuilder info = new StringBuilder();
                info.AppendLine("请一定要确认以下三项信息完全正确再点按钮，操作后无法撤消！");
                info.AppendLine();
                info.AppendLine("当前交易期数：" + issueNumber.ToString());
                info.AppendLine("派股比例：" + rationScale.ToString());
                info.AppendLine("当期股价：" + sharePrice.ToString());

                if (MessageBox.Show(info.ToString(), "特别提醒！！！", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
                {
                    bll_shareManage.ScalRationedShares(issueNumber, rationScale, sharePrice, "system");
                    
                    lbTotalSharesAfter.Text = bll_shareManage.GetCorporateShareTotals().ToString("N0");
                    MessageBox.Show("派股已完成");
                    btnPeigu.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("派股比例未正确指定。");
            }
        }


    }
}
