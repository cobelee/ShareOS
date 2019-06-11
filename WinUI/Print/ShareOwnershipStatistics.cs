using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace WinUI.Print
{
    public partial class ShareOwnershipStatistics : Form
    {
        ShareOS.BLL.ShareOwnershipManage bll_som = new ShareOS.BLL.ShareOwnershipManage();
        ReportPrinter reportPrinter;

        public ShareOwnershipStatistics()
        {
            InitializeComponent();
        }

        private void ShareOwnershipStatistics_Load(object sender, EventArgs e)
        {
            DataTable dtReport = bll_som.GetShareOwnershipStatisticsReportByEntrustedAgent();
            DataView dvReport = dtReport.DefaultView;

            dgvSharesStat.DataSource = dvReport;

            dgvSharesStat.Columns["ShareholderNumber"].HeaderText = "股东号";
            dgvSharesStat.Columns["EntrustedAgentName"].HeaderText = "委托代理人";
            dgvSharesStat.Columns["CountOfShareholder"].HeaderText = "代理股东数";
            dgvSharesStat.Columns["SharesAmount"].HeaderText = "代理股权数";
            dgvSharesStat.Columns["SharesAmount"].DefaultCellStyle.Format = "N0";
            dgvSharesStat.Columns["SharesRatio"].HeaderText = "持股比例(%)";
            dgvSharesStat.Columns["SharesRatio"].DefaultCellStyle.Format = "N4";

            lbTotalShares.Text = bll_som.GetCorporateShareTotals().ToString("N0");

        }

        /// <summary>
        /// 数据报表打印器 绑定数据报表及数据。
        /// </summary>
        /// <param name="row"></param>
        protected void ReportPrinter_DataBind()
        {
            //设置报表模版路径。
            LocalReport report = new LocalReport();
            report.ReportPath = "委托代理股权统计.rdlc";

            reportPrinter = new ReportPrinter(report);


            //加载报表数据源。
            string reportDataSourceName0 = reportPrinter.LocalReport.GetDataSourceNames()[0];

            DataTable tableSource = bll_som.GetShareOwnershipStatisticsReportByEntrustedAgent();

            reportPrinter.LocalReport.DataSources.Add(new ReportDataSource(reportDataSourceName0, tableSource));

            //设置报表参数值。
            //ReportParameter[] parameters = new ReportParameter[2];
            //parameters[0] = new ReportParameter("PARM_CompanyName", Properties.Settings.Default.CompanyName);
            //parameters[1] = new ReportParameter("PARM_IssueNumber", cbbIssueNumber.SelectedItem.ToString());

            //report.SetParameters(parameters);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            ReportPrinter_DataBind();

            PrintPreview icp = new PrintPreview();
            icp.PrintPreviewControl.Document = reportPrinter.PrintDocument;
            icp.MdiParent = this.MdiParent;
            icp.Show();
            icp.WindowState = FormWindowState.Maximized;
        }


    }
}