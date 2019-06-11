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
    public partial class ShareOwnershipWithdrawal : Form
    {
        ShareOS.BLL.ShareOwnershipManage bll_som = new ShareOS.BLL.ShareOwnershipManage();
        ShareOS.BLL.ShareholderRegister bll_shr = new ShareOS.BLL.ShareholderRegister();
        ReportPrinter reportPrinter;

        public ShareOwnershipWithdrawal()
        {
            InitializeComponent();
        }

        private void cbCurrentYear_CheckedChanged(object sender, EventArgs e)
        {
            dtpYear.Enabled = !cbCurrentYear.Checked;
        }

        protected void DateGridView_DateBind()
        {
            DateTime beginDate, endDate;
            if (cbCurrentYear.Checked)
            {
                beginDate = new DateTime(System.DateTime.Now.Year, 1, 1);
                endDate = new DateTime(System.DateTime.Now.Year + 1, 1, 1);
            }
            else
            {
                beginDate = new DateTime(dtpYear.Value.Year, 1, 1);
                endDate = new DateTime(dtpYear.Value.Year + 1, 1, 1);
            }
            DataTable shareWithDrawTable = bll_som.GetShareOwnershipWithdrawal(beginDate, endDate);
            DataView dv = shareWithDrawTable.DefaultView;
            ShowShareWithdrawTotal(shareWithDrawTable);
            dgvShareOwnership.DataSource = dv;
        }

        protected void ShowShareWithdrawTotal(DataTable shareWithDrawTable)
        {
            decimal total = 0;
            for (int i = 0; i < shareWithDrawTable.Rows.Count; i++)
            {
                decimal changes = 0;
                changes = Convert.ToDecimal(shareWithDrawTable.Rows[i]["SharesChanges"]);
                total += changes;
            }
            lbWithdrawTotals.Text = total.ToString("N2");

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Dialog.SellShareOwnership sso = new WinUI.Dialog.SellShareOwnership();
            if (sso.ShowDialog(this) == DialogResult.OK)
            {
                if (sso.ShareholderNumber > 0)
                {
                    bll_som.Tuigu(sso.ShareholderNumber, sso.ShareOwnershipAmount, sso.CurrentSharePrice, "System");
                }
                DateGridView_DateBind();
            }
        }

        private void ShareOwnershipWithdrawal_Load(object sender, EventArgs e)
        {
            DateGridView_DateBind();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dgvShareOwnership.SelectedRows.Count < 1)
                return;

            ReportPrinter_DataBind(dgvShareOwnership.SelectedRows[0]);

            printPreviewDialog1.Document = reportPrinter.PrintDocument;
            printPreviewDialog1.ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (dgvShareOwnership.SelectedRows.Count < 1)
                return;

            int regId;
            if (MessageBox.Show(this, "确实要撤销股权退出操作吗？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dgvShareOwnership.SelectedRows)
                {
                    regId = Convert.ToInt32(row.Cells["RegId"].Value);
                    bll_som.CancelChange(regId);
                }
            }
            DateGridView_DateBind();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            DateGridView_DateBind();
        }

        private void btnPreviewPersonWithdrawalReport_Click(object sender, EventArgs e)
        {
            if (dgvShareOwnership.SelectedRows.Count < 1)
                return;

            ReportPrinter_DataBind(dgvShareOwnership.SelectedRows[0]);

            PreviewPersonWithdrawalReport ppwr = new PreviewPersonWithdrawalReport();
            ppwr.PrintPreviewControl.Document = reportPrinter.PrintDocument;
            ppwr.Show(this);
        }

        /// <summary>
        /// 数据报表打印器 绑定数据报表及数据。
        /// </summary>
        /// <param name="row"></param>
        protected void ReportPrinter_DataBind(DataGridViewRow row)
        {
            ShareOS.Model.Shareholder shareholder;

            shareholder = bll_shr.GetShareholder(Convert.ToInt32(row.Cells["ShareholderNumber"].Value));
            int regId;
            regId = Convert.ToInt32(row.Cells["RegId"].Value);
            ShareOS.Model.SharesWithdrawalReport swdr = bll_som.GetPersonWithdrawalReport(regId);

            swdr.TaxRate = Properties.Settings.Default.IRPEF;



            //设置报表模版路径。
            LocalReport report = new LocalReport();
            report.ReportPath = "个人股权退出清算报告.rdlc";

            reportPrinter = new ReportPrinter(report);


            //加载报表数据源。
            string reportDataSourceName0 = reportPrinter.LocalReport.GetDataSourceNames()[0];
            string reportDataSourceName1 = reportPrinter.LocalReport.GetDataSourceNames()[1];
            DataTable tableShareChangeRecord = bll_som.GetPersonalShareOwnershipReport(shareholder.ShareholderNumber);
            DataTable tableShareWithdrawalReport = bll_som.GetPersonWithdrawalReportTable(regId);


            reportPrinter.LocalReport.DataSources.Add(new ReportDataSource(reportDataSourceName0, tableShareChangeRecord));
            reportPrinter.LocalReport.DataSources.Add(new ReportDataSource(reportDataSourceName1, tableShareWithdrawalReport));

            //设置报表参数值。
            ReportParameter[] parameters = new ReportParameter[11];
            parameters[0] = new ReportParameter("PARM_ShareholderName", shareholder.ShareholderName);
            parameters[1] = new ReportParameter("PARM_ShareholderNumber", shareholder.ShareholderNumber.ToString());
            parameters[2] = new ReportParameter("PARM_Sex", shareholder.Sex ? "男" : "女");
            parameters[3] = new ReportParameter("PARM_JobNumber", shareholder.JobNumber);
            parameters[4] = new ReportParameter("PARM_IdentityCardNumber", shareholder.IdentityCard);
            parameters[5] = new ReportParameter("PARM_PersonType", shareholder.PersonType);
            parameters[6] = new ReportParameter("PARM_Status", shareholder.Status.ToString());
            if (!string.IsNullOrEmpty(Properties.Settings.Default.CompanyName))
            {
                parameters[7] = new ReportParameter("PARM_CompanyName", Properties.Settings.Default.CompanyName);
            }
            parameters[8] = new ReportParameter("PARM_PretaxProfits", swdr.PretaxProfits.ToString("N2"));
            parameters[9] = new ReportParameter("PARM_IncomTax", swdr.IncomTax.ToString("N2"));
            parameters[10] = new ReportParameter("PARM_ReturnCash", swdr.ReturnCash.ToString("N2"));

            report.SetParameters(parameters);
        }

        private void btnMultPrint_Click(object sender, EventArgs e)
        {
            if (dgvShareOwnership.SelectedRows.Count < 1)
                return;

            if (printDialog1.ShowDialog(this) == DialogResult.OK)
            {
                foreach (DataGridViewRow row in dgvShareOwnership.SelectedRows)
                {
                    ReportPrinter_DataBind(row);
                    reportPrinter.PrintDocument.PrinterSettings = printDialog1.PrinterSettings;
                    reportPrinter.Print();
                }
            }

        }
    }
}