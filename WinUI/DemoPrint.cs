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
    public partial class DemoPrint : Form
    {
        ReportPrinter reportPrinter;

        public DemoPrint()
        {
            InitializeComponent();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            printDialog1.Document = reportPrinter.PrintDocument;
            if (printDialog1.ShowDialog(this) == DialogResult.OK)
            {
                //printDialog1.Document.PrinterSettings = printDialog1.PrinterSettings;
                reportPrinter.Print();
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            reportPrinter.Export("Excel");
        }

        private void DemoPrint_Load(object sender, EventArgs e)
        {
            //设置报表模版路径。
            LocalReport report = new LocalReport();
            report.ReportPath = "ReportShareApplication.rdlc";

            reportPrinter = new ReportPrinter(report);



            //加载报表数据源。
            string dataSourceName = reportPrinter.LocalReport.GetDataSourceNames()[0];
            ShareOS.BLL.ShareOwnershipManage bll_som = new ShareOS.BLL.ShareOwnershipManage();
            ShareOS.BLL.SharesBonusManage bll_bonus = new ShareOS.BLL.SharesBonusManage();
            int issueNumber = bll_bonus.GetLastIssueNumber();
            reportPrinter.LocalReport.DataSources.Add(new ReportDataSource(dataSourceName, bll_som.GetShareOwnershipReport(issueNumber)));

            //设置报表参数值。

            ReportParameter[] parameters = new ReportParameter[4];
            parameters[0] = new ReportParameter("Parm_CompanyName", "镇海石化工业贸易有限责任公司");
            parameters[1] = new ReportParameter("Parm_IssueNumber", "2");
            parameters[2] = new ReportParameter("Parm_IssueYear", "2010");
            parameters[3] = new ReportParameter("Parm_SharePrice", "1.56");

            report.SetParameters(parameters);
        }

        private void btnExportImage_Click(object sender, EventArgs e)
        {
            reportPrinter.Export("Image");
        }

        private void btnPreviewPrint_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = reportPrinter.PrintDocument;
            printPreviewDialog1.ShowDialog(this);
        }

    }
}