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
    protected ShareOS.BLL.SharesBonusManage bll_Bonus = new ShareOS.BLL.SharesBonusManage();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            Load_Shares_Config();

            hlQuery.NavigateUrl = "~/Default.aspx";
            hlAdmin.NavigateUrl = "~/Admin/ShareOwnershipList.aspx";

            hlChangeAgent.NavigateUrl = "~/Admin/ChangeAgent.aspx";
            hlChangeStatus.NavigateUrl = "~/Admin/LogoutShareholderStatus.aspx";

            // hlShareOwership.NavigateUrl = "~/Admin/ShareOwnershipList.aspx";
            hlShareOwershipAll.NavigateUrl = "~/Admin/ShareOwnershipListAll.aspx";
        }
    }

    protected void Load_Shares_Config()
    {
        ShareOS.Model.SharesIssueConfig sic = bll_Bonus.SelectConfig(bll_Bonus.GetLastIssueNumber());
        lbIssueNumber.Text = sic.IssueNumber.ToString();
        lbYear.Text = sic.IssueYear.ToString() + "年";
        lbSharesPrice.Text = sic.SharePrice.ToString("C4");
    }
}
