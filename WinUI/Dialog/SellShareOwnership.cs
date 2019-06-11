using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinUI.Dialog
{
    public partial class SellShareOwnership : Form
    {
        ShareOS.BLL.ShareOwnershipManage bll_som = new ShareOS.BLL.ShareOwnershipManage();
        ShareOS.BLL.ShareholderRegister bll_shr = new ShareOS.BLL.ShareholderRegister();

        private int shareholderNumber;
        private decimal shareOwnershipAmount;

        public decimal ShareOwnershipAmount
        {
            get { return shareOwnershipAmount; }
            set { shareOwnershipAmount = value; }
        }
        private decimal currentSharePrice;

        public decimal CurrentSharePrice
        {
            get { return currentSharePrice; }
            set { currentSharePrice = value; }
        }

        public int ShareholderNumber
        {
            get { return shareholderNumber; }
            set { shareholderNumber = value; }
        }

        /// <summary>
        /// 初始化窗口
        /// </summary>
        public SellShareOwnership()
        {
            InitializeComponent();
            currentSharePrice = bll_som.GetCurrentSharePrice();
            lbSharePrice.Text = string.Format("{0:N4}", currentSharePrice);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                Int32.TryParse(tbShareholderNumber.Text, out shareholderNumber);
                shareOwnershipAmount = Convert.ToDecimal(tbShareOwnership.Text);
            }
            else
            {
                this.DialogResult = DialogResult.None;
            }
        }

        private void tbShareholderNumber_Validating(object sender, CancelEventArgs e)
        {
            Int32.TryParse(tbShareholderNumber.Text, out shareholderNumber);
            if (!bll_shr.ExistShareholder(shareholderNumber))
            {
                e.Cancel = true;
                errorProvider1.SetError((Control)sender, "股东号不存在！");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError((Control)sender, "");

                shareholderNumber = Convert.ToInt32(tbShareholderNumber.Text);

                ShareOS.Model.Shareholder shareholder = bll_shr.GetShareholder(shareholderNumber);
                lbShareholder.Text = shareholder.ShareholderName + "  " + shareholder.JobNumber;

                decimal shareTotals = bll_som.GetPersonalShareTotals(shareholderNumber);
                lbSharesTotals.Text = shareTotals.ToString();


                tbShareOwnership.Text = shareTotals.ToString();
                tbShareOwnership.Focus();
            }
        }


        private void tbShareOwnership_Validating(object sender, CancelEventArgs e)
        {
            decimal shareOwnership = 0m;
            decimal.TryParse(tbShareOwnership.Text, out shareOwnership);
            if (shareOwnership > 0 && shareOwnership <= Convert.ToDecimal(lbSharesTotals.Text))
            {
                e.Cancel = false;
                errorProvider1.SetError((Control)sender, null);
            }
            else
            {
                e.Cancel = true;
                errorProvider1.SetError((Control)sender, "请确认股权数量是否正确设置！");
            }
        }
    }
}