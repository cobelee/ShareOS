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
    public partial class PersonalShareOwnership : Form
    {
        ShareOS.BLL.ShareOwnershipManage bll_som = new ShareOS.BLL.ShareOwnershipManage();
        ShareOS.BLL.ShareholderRegister bll_sr = new ShareOS.BLL.ShareholderRegister();
        ReportPrinter reportPrinter;

        private ShareOS.Model.Shareholder shareholder;
        

        public PersonalShareOwnership(int shareholderNumber)
        {
            InitializeComponent();
            shareholder = bll_sr.GetShareholder(shareholderNumber);
        }

        private void PersonalShareOwnership_Load(object sender, EventArgs e)
        {
            DataBind_ShareOwnership(shareholder.ShareholderNumber);
            DataBind_Shareholder(shareholder);
        }

        private void DataBind_ShareOwnership(int shareholderNumber)
        {
            if (shareholderNumber > 0)
            {
                dgvShareOwnership.DataSource = bll_som.GetPersonalShareOwnershipReport(shareholderNumber);
            }
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //设置报表模版路径。
            LocalReport report = new LocalReport();
            report.ReportPath = "个人股权变动记录.rdlc";

            reportPrinter = new ReportPrinter(report);


            //加载报表数据源。
            string reportDataSourceName = reportPrinter.LocalReport.GetDataSourceNames()[0];
            DataTable tableShareChangeRecord = bll_som.GetPersonalShareOwnershipReport(shareholder.ShareholderNumber);


            reportPrinter.LocalReport.DataSources.Add(new ReportDataSource(reportDataSourceName, tableShareChangeRecord));

            //设置报表参数值。
            ReportParameter[] parameters = new ReportParameter[7];
            parameters[0] = new ReportParameter("PARM_ShareholderName", shareholder.ShareholderName);
            parameters[1] = new ReportParameter("PARM_ShareholderNumber", shareholder.ShareholderNumber.ToString());
            parameters[2] = new ReportParameter("PARM_Sex", shareholder.Sex ? "男" : "女");
            parameters[3] = new ReportParameter("PARM_IdentityCardNumber", shareholder.IdentityCard);
            parameters[4] = new ReportParameter("PARM_PersonType", shareholder.PersonType);
            parameters[5] = new ReportParameter("PARM_Status", shareholder.Status.ToString());
            if (!string.IsNullOrEmpty(Properties.Settings.Default.CompanyName))
            {
                parameters[6] = new ReportParameter("PARM_CompanyName", Properties.Settings.Default.CompanyName);
            }

            report.SetParameters(parameters);

            printPreviewDialog1.Document = reportPrinter.PrintDocument;
            printPreviewDialog1.ShowDialog();
        }
    }
}