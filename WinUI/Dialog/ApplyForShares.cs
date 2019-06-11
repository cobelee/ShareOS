using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinUI.Dialog
{
    public partial class ApplyForShares : Form
    {
        private ShareOS.Model.Shareholder shareholder;
        private int sharesAmountApplyFor;

        /// <summary>
        /// 获取股权受让申请数量。
        /// </summary>
        public int SharesAmountApplyFor
        {
            get { return sharesAmountApplyFor; }
        }

        public ShareOS.Model.Shareholder Shareholder
        {
            get { return shareholder; }
            set { shareholder = value; }
        }

        public ApplyForShares()
        {
            InitializeComponent();
        }

        private void DataBind_Shareholder(ShareOS.Model.Shareholder shareholder)
        {
            if (shareholder != null && shareholder.ShareholderName != string.Empty)
            {
                lbName.Text = shareholder.ShareholderName;
                lbShareholderNumber.Text = shareholder.ShareholderNumber.ToString();
                lbSex.Text = shareholder.Sex ? "男" : "女";
                lbIdentityCard.Text = shareholder.IdentityCard;
                lbPersonType.Text = shareholder.PersonType;
                lbStatus.Text = shareholder.Status.ToString();
            }
        }

        private void ApplyForShares_Load(object sender, EventArgs e)
        {
            DataBind_Shareholder(shareholder);
            nudShareOwnership.Select(0, 1);
        }

        private void nudShareOwnership_Validating(object sender, CancelEventArgs e)
        {
            int result = Convert.ToInt32(nudShareOwnership.Value) % 1000;
            decimal amount = nudShareOwnership.Value;
            if (result > 0 || amount == 0)
            {
                e.Cancel = true;
                errorProvider1.SetError((Control)sender, "要求1000的倍数");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError((Control)sender, null);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                sharesAmountApplyFor = Convert.ToInt32(nudShareOwnership.Value);
            }
            else
            {
                this.DialogResult = DialogResult.None;
            }
        }
    }
}