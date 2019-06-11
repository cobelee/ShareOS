using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_SO_Sum : System.Web.UI.Page
{
    ShareOS.BLL.EntrustedAgent bll_agent = new ShareOS.BLL.EntrustedAgent();
    ShareOS.BLL.MonitorOffice bll_monitor = new ShareOS.BLL.MonitorOffice();
    ShareOS.BLL.MonitorOffice bll_office = new ShareOS.BLL.MonitorOffice();
    ShareOS.BLL.ShareOwnershipManage bll_shareholder = new ShareOS.BLL.ShareOwnershipManage();

    DataTable report;
    decimal qichuSharesSum = 0m;
    decimal shareTotalsSum = 0m;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Init_Load();
        }
    }

    private void Init_Load()
    {
        lbShO.Text = bll_shareholder.GetCorporateShareTotals().ToString();  // 获取当前股权总数。
        hfIssueNumber.Value = bll_office.GetLastIssueNumber().ToString();
        int issueNumber = 0;
        int.TryParse(hfIssueNumber.Value, out issueNumber);

        report = bll_shareholder.GetShareOwnershipReport(issueNumber);


        IList<ShareOS.Model.EntrustedAgent> agentList = bll_agent.Select();
        gvAgent.DataSource = agentList;
        gvAgent.DataBind();
    }


    /// <summary>
    /// 获取指定股东代理人名下的股东人数。
    /// </summary>
    /// <param name="shareholderNumber">股东代理人的股东号</param>
    /// <returns></returns>
    protected int GetCount(int shareholderNumber)
    {
        int agencyCount = 0;
        agencyCount = bll_monitor.GetAgencyCount(shareholderNumber);
        return agencyCount;
    }

    protected string GetQichuShares(int agentShnum)
    {
        if (report == null)
            return "0.00";

        decimal qichu = 0.0m;

        foreach (DataRow row in report.Rows)
        {
            int agent = Convert.ToInt32(row["EntrustedAgent"]);
            if (agentShnum == agent)
                qichu += Convert.ToDecimal(row["QichuShares"]);
        }

        qichuSharesSum += qichu;

        return qichu.ToString("N2");
    }

    protected string GetShareTotals(int agentShnum)
    {
        if (report == null)
            return "0.00";

        decimal shares = 0.0m;

        foreach (DataRow row in report.Rows)
        {
            int agent = Convert.ToInt32(row["EntrustedAgent"]);
            if (agentShnum == agent)
                shares += Convert.ToDecimal(row["ShareTotals"]);
        }

        shareTotalsSum += shares;

        return shares.ToString("N2");
    }

    // 获取期初总股权数
    protected string GetQichuSharesSum()
    {
        return qichuSharesSum.ToString("N2");
    }

    // 获取期未总股权数
    protected string GetShareTotalsSum()
    {
        return shareTotalsSum.ToString("N2");
    }
    

}