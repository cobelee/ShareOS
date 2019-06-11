using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinUI
{
    public partial class ImportIdentityCard : Form

    {
        ShareOS.BLL.ShareholderRegister bll_sr = new ShareOS.BLL.ShareholderRegister();
        PMS.BLL.Personnel bll_Personnel = new PMS.BLL.Personnel();

        public ImportIdentityCard()
        {
            InitializeComponent();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            IList<ShareOS.Model.Shareholder> shareholders = bll_sr.GetShareholderList();
            PMS.Model.Personnel person;
            foreach (ShareOS.Model.Shareholder sh in shareholders)
            {
                if (string.IsNullOrEmpty(sh.ShareholderName))
                {
                    person = bll_Personnel.GetPersonnelByJobNumber(sh.JobNumber);
                    sh.ShareholderName = person.Individual.Name;
                    sh.Sex = person.Individual.Sex;
                    sh.IdentityCard = person.Individual.IdentityCard;
                    sh.PersonType = "其它人员";
                    sh.Status = ShareOS.Model.ShareholderStatus.股东;
                    bll_sr.Update(sh);
                }

            }
            MessageBox.Show("数据更新完毕");
        }
    }
}