using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Trade_Qingtui : System.Web.UI.Page
{
    ShareOS.BLL.ShareOwnershipManage bll_share = new ShareOS.BLL.ShareOwnershipManage();
    ShareOS.BLL.ShareIssueManage bll_Issue = new ShareOS.BLL.ShareIssueManage();
    ShareOS.BLL.MonitorOffice bll_monitor = new ShareOS.BLL.MonitorOffice();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Load_IssueInfo();
            Load_ClearedInfo();
        }
    }



    protected void Page_Unload(object sender, EventArgs e)
    {
        bll_Issue.Dispose();
        bll_share.Dispose();
    }

    private void Load_IssueInfo()
    {
        Tiyi.ShareOS.SQLServerDAL.SharesIssueConfig config = bll_Issue.GetIssueConfigByYear(DateTime.Now.Year);
        if (config != null)
        {
            ltlIssueInfo.Text = config.IssueYear.ToString() + "年第" + config.IssueNumber.ToString() + "期";
        }
        else
        {
            ltlIssueInfo.Text = "本交易期数据尚未初始化，请先开启年度交易。";
        }
    }

    private void Load_ClearedInfo()
    {
        Tiyi.ShareOS.SQLServerDAL.SharesIssueConfig config = bll_Issue.GetIssueConfigByYear(DateTime.Now.Year);
        if (config != null)
        {
            decimal num = bll_monitor.GetNumberOfClearedShareholder((int)config.IssueNumber);
            ltlNoOfCleared.Text = num.ToString();
        }

    }

    protected void btnQingtui_Click(object sender, EventArgs e)
    {
        List<int> lstShNums = new List<int>();
        string[] strShNums = tbShareholderNumbers.Text.Split(',');
        foreach (string strShNum in strShNums)
        {
            lstShNums.Add(Convert.ToInt32(strShNum));
        }
        int[] arrayShNums = lstShNums.ToArray();

        bll_share.QingtuiShares_Bat(arrayShNums, User.Identity.Name);
        Load_ClearedInfo();
        bll_share.Dispose();
    }
}