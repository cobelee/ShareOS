using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Admin_Admin : System.Web.UI.MasterPage
{
    ShareOS.BLL.MonitorOffice bll_monitor = new ShareOS.BLL.MonitorOffice();
    ShareOS.BLL.ShareIssueManage bll_Issue = new ShareOS.BLL.ShareIssueManage();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Load_Shares_Config();

            hlQuery.NavigateUrl = "~/Default.aspx";
            hlAdmin.NavigateUrl = "~/Admin/Trade/Open.aspx";

            hlChangeAgent.NavigateUrl = "~/Admin/ChangeAgent.aspx";
            hlLogOffIdentity.NavigateUrl = "~/Admin/Shareholder/LogOffIdentity.aspx";

            // hlShareOwership.NavigateUrl = "~/Admin/ShareOwnershipList.aspx";
            hlShareOwershipAll.NavigateUrl = "~/Admin/ShareOwnershipListAll.aspx";
        }
    }

    protected void Load_Shares_Config()
    {
        var lastIssueNumber = bll_monitor.GetLastIssueNumber();
        var sic = bll_Issue.GetIssueConfig(lastIssueNumber);
        lbIssueNumber.Text = sic.IssueNumber.ToString();
        lbYear.Text = sic.IssueYear.ToString() + "年";
        lbSharesPrice.Text = Convert.ToDecimal(sic.SharePrice).ToString("C4");
    }
}
