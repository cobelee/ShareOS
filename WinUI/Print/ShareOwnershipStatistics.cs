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

            dgvSharesStat.Columns["ShareholderNumber"].HeaderText = "�ɶ���";
            dgvSharesStat.Columns["EntrustedAgentName"].HeaderText = "ί�д�����";
            dgvSharesStat.Columns["CountOfShareholder"].HeaderText = "�����ɶ���";
            dgvSharesStat.Columns["SharesAmount"].HeaderText = "������Ȩ��";
            dgvSharesStat.Columns["SharesAmount"].DefaultCellStyle.Format = "N0";
            dgvSharesStat.Columns["SharesRatio"].HeaderText = "�ֹɱ���(%)";
            dgvSharesStat.Columns["SharesRatio"].DefaultCellStyle.Format = "N4";

            lbTotalShares.Text = bll_som.GetCorporateShareTotals().ToString("N0");

        }

        /// <summary>
        /// ���ݱ�����ӡ�� �����ݱ��������ݡ�
        /// </summary>
        /// <param name="row"></param>
        protected void ReportPrinter_DataBind()
        {
            //���ñ���ģ��·����
            LocalReport report = new LocalReport();
            report.ReportPath = "ί�д�����Ȩͳ��.rdlc";

            reportPrinter = new ReportPrinter(report);


            //���ر�������Դ��
            string reportDataSourceName0 = reportPrinter.LocalReport.GetDataSourceNames()[0];

            DataTable tableSource = bll_som.GetShareOwnershipStatisticsReportByEntrustedAgent();

            reportPrinter.LocalReport.DataSources.Add(new ReportDataSource(reportDataSourceName0, tableSource));

            //���ñ�������ֵ��
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