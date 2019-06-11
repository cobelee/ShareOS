using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinUI
{
    public partial class PersonalBonusRecord : Form
    {
        ShareOS.BLL.ShareholderRegister bll_sr = new ShareOS.BLL.ShareholderRegister();
        ShareOS.BLL.SharesBonusManage bll_bonus = new ShareOS.BLL.SharesBonusManage();

        private ShareOS.Model.Shareholder shareholder;

        public PersonalBonusRecord(int shareholderNumber)
        {
            InitializeComponent();
            shareholder = bll_sr.GetShareholder(shareholderNumber);
        }

        private void PersonalBonusRecord_Load(object sender, EventArgs e)
        {
            DataBind_Shareholder(shareholder);
            DataBind_ShareBonus(shareholder);
        }

        private void DataBind_ShareBonus(ShareOS.Model.Shareholder shareholder)
        {
            if (shareholder.ShareholderNumber > 0)
            {
                dgvBouns.DataSource = bll_bonus.SelectBonusRecord(shareholder);
                dgvBouns.Columns["ShareholderNumber"].Visible = false;
            }
        }

        private void DataBind_Shareholder(ShareOS.Model.Shareholder shareholder)
        {
            if (shareholder != null && shareholder.ShareholderName != string.Empty)
            {
                lbName.Text = shareholder.ShareholderName;
                lbShareholderNumber.Text = shareholder.ShareholderNumber.ToString();
                lbSex.Text = shareholder.Sex ? "ÄÐ" : "Å®";
                lbIdentityCard.Text = shareholder.IdentityCard;
                lbPersonType.Text = shareholder.PersonType;
                lbStatus.Text = shareholder.Status.ToString();
            }
        }
    }
}