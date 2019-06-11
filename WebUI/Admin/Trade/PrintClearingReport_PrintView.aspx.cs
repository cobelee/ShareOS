using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Configuration;
using ShareOS.BLL;

public partial class Admin_Trade_PrintClearingReport_PrintView : System.Web.UI.Page
{
    ShareOS.BLL.ShareOwnershipManage bll_shareOwnership = new ShareOS.BLL.ShareOwnershipManage();
    ShareOS.BLL.ShareIssueManage bll_Issue = new ShareOS.BLL.ShareIssueManage();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            hfShareholderNumbers.Value = Session["ClearingShareholderNumbers"].ToString();
            Load_Report();
        }
    }

    protected List<PersonClearingReportItem> GetDataSource(string strShNums)
    {
        string[] strArrayShNums = strShNums.Split(',');
        List<Int32> intListShNums = new List<int>();
        foreach (string strShNum in strArrayShNums)
        {
            intListShNums.Add(Convert.ToInt32(strShNum));
        }
        int[] intArrayShNums = intListShNums.ToArray();
        return bll_shareOwnership.GetPersonClearingReport(intArrayShNums);
    }

    private void Load_Report()
    {
        //确认股权交易期数是否正确。
        Tiyi.ShareOS.SQLServerDAL.SharesIssueConfig config = bll_Issue.GetIssueConfigByYear(DateTime.Now.Year);
        if (config == null)
            return;

        //设置报表模版路径，若控件中已设，以下两包并不需求。
        //LocalReport report = new LocalReport();
        //report.ReportPath = "ReportShareApplication.rdlc";

        //加载报表数据源。
        string dataSourceName = reportPrinter.LocalReport.GetDataSourceNames()[0];
        List<PersonClearingReportItem> clearingReport = GetDataSource(hfShareholderNumbers.Value);

        reportPrinter.LocalReport.DataSources.Add(new ReportDataSource(dataSourceName, clearingReport));

        //设置报表参数值。
        ReportParameter[] parameters = new ReportParameter[4];
        string companyName = "镇海石化工业贸易有限责任公司";
        if (ConfigurationManager.AppSettings["CompanyName"] != null)
        {
            companyName = ConfigurationManager.AppSettings["CompanyName"];
        }
        if (!string.IsNullOrEmpty(companyName))
        {
            parameters[0] = new ReportParameter("Parm_CompanyName", companyName);
        }
        parameters[1] = new ReportParameter("Parm_IssueNumber", config.IssueNumber.ToString());
        parameters[2] = new ReportParameter("Parm_IssueYear", config.IssueYear.ToString());
        parameters[3] = new ReportParameter("Parm_SharePrice", config.SharePrice.ToString());

        reportPrinter.LocalReport.SetParameters(parameters);

        //System.Drawing.Printing.PrinterSettings ps = new System.Drawing.Printing.PrinterSettings();
        reportPrinter.LocalReport.DisplayName = "个人股权退出清算报告";

    }

    protected void ReportViewer1_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
    {
        string shareholderNumber = e.Parameters[0].Values[0];
        int shNumber = 0;
        int.TryParse(shareholderNumber, out shNumber);
        DataTable dt = bll_shareOwnership.GetPersonalShareOwnershipReport(shNumber);
        ReportDataSource ds = new ReportDataSource("DataSet1", dt);
        e.DataSources.Add(ds);
    }
}