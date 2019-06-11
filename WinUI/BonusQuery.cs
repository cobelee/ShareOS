using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinUI
{
    public partial class BonusQuery : Form
    {
        ShareOS.BLL.SharesBonusManage bll_sharesBonus = new ShareOS.BLL.SharesBonusManage();

        public BonusQuery()
        {
            InitializeComponent();
        }

        protected void DataBind_IssueNumber()
        {
            int lastIssueNumber = bll_sharesBonus.GetLastIssueNumber();

            cbbIssueNumber.Items.Clear();
            for (int i = lastIssueNumber; i > 0; i--)
            {
                cbbIssueNumber.Items.Add(i);
            }
        }

        private void BonusQuery_Load(object sender, EventArgs e)
        {
            DataBind_IssueNumber();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            int issueNumber = 0;
            Int32.TryParse(cbbIssueNumber.SelectedItem.ToString(),out issueNumber);
            dgvBonusRecord.DataSource = bll_sharesBonus.SelectBonusRecord(issueNumber);
        }

        private void btnPersonal_Click(object sender, EventArgs e)
        {
            if (dgvBonusRecord.SelectedRows.Count > 0)
            {
                int shareholderNumber = 0;
                shareholderNumber = Convert.ToInt32(dgvBonusRecord.SelectedRows[0].Cells["ShareholderNumber"].Value);
                if (shareholderNumber > 0)
                {
                    PersonalBonusRecord pbr = new PersonalBonusRecord(shareholderNumber);
                    pbr.MdiParent = this.MdiParent;
                    pbr.Show();
                }

                
            }
        }
    }
}