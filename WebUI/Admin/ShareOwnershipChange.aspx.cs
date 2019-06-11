using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ShareOwnershipChange : System.Web.UI.Page
{
    ShareOS.BLL.ShareOwnershipManage bll_manage = new ShareOS.BLL.ShareOwnershipManage();
    ShareOS.BLL.SharesBonusManage bll_Bonus = new ShareOS.BLL.SharesBonusManage();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Load_IssueNumber();
        }
    }

    private void Load_IssueNumber()
    {
        int currentIssueNumber = 0;
        currentIssueNumber = bll_Bonus.GetLastIssueNumber();
        ddlIssueNumber.Items.Clear();
        for (int i = currentIssueNumber; i >= 0; i--)
        {
            ddlIssueNumber.Items.Add(new ListItem(i.ToString()));
        }
    }


}