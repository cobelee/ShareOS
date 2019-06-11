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

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected ShareOS.BLL.SharesBonusManage bll_Bonus = new ShareOS.BLL.SharesBonusManage();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            Load_Shares_Config();

            hlQuery.NavigateUrl = "~/Default.aspx";
            hlAdmin.NavigateUrl = "~/Admin/ChangeAgent.aspx";

            hlPersonInfo.NavigateUrl = "~/Person/PersonInfo.aspx";
            hlShareOwnershipRecord.NavigateUrl = "~/Person/ShareOwnershipRecord.aspx";

            hlAssignAssistant.NavigateUrl = "~/EntrustedAgent/ConfigAssistant.aspx";
            hlShareholderList.NavigateUrl = "~/EntrustedAgent/ShareholderList.aspx";
            hlShareOwnershipList.NavigateUrl = "~/EntrustedAgent/ShareOwnershipList.aspx";
            hlCompanySharesStructure.NavigateUrl = "~/EntrustedAgent/CompanySharesStructure.aspx";
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
