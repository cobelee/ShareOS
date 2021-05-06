using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShareOS.BLL;

public partial class Admin_Trade_Open : System.Web.UI.Page
{
    ShareOS.BLL.MonitorOffice bll_monitor = new MonitorOffice();
    ShareOS.BLL.ShareIssueManage bll_Issue = new ShareIssueManage();
    protected void Page_Load(object sender, EventArgs e)
    {
        Init_Load();
    }

    private void Init_Load()
    {
        Tiyi.ShareOS.SQLServerDAL.SharesIssueConfig config = bll_Issue.GetIssueConfigByYear(DateTime.Now.Year);
        if (config != null)
        {
            // 若本期已初始化
            ShowOpeningInfo();
        }
        else
        {
            // 初始化本期数据操作：
            MultiView1.SetActiveView(viewToOpen);
            LoadLastConfig();
            tbYear.Text = DateTime.Now.Year.ToString();
        }



    }

    private void LoadLastConfig()
    {
        int lastIssue = bll_monitor.GetLastIssueNumber();

        Tiyi.ShareOS.SQLServerDAL.SharesIssueConfig config = bll_Issue.GetIssueConfig(lastIssue);
        ltlLastInfo.Text = "最近一期：" + config.DisplayText;
    }

    protected void btnOpen_Click(object sender, EventArgs e)
    {
        Tiyi.ShareOS.SQLServerDAL.SharesIssueConfig config = new Tiyi.ShareOS.SQLServerDAL.SharesIssueConfig();

        int issueNumber = 0;
        int.TryParse(tbIssueNumber.Text, out issueNumber);  // 获取股权交易期数

        decimal sharePrice = 0m;
        decimal.TryParse(tbSharePrice.Text, out sharePrice);  // 获取当前股价

        int issueYear = 0;
        int.TryParse(tbYear.Text, out issueYear);  //获取股权交易年份

        config.IssueNumber = issueNumber;
        if (issueYear == 0)
            config.IssueYear = DateTime.Now.Year;
        else
            config.IssueYear = issueYear;
        config.IsOpen = true;
        config.IsDistributed = false;
        config.Bonus = 0;
        config.DPD = DateTime.Now;      // Divident Payment Date 红利派发日期。
        config.SharePrice = sharePrice;  // 当前股价

        bll_Issue.OpenShareIssue(config);

        ShowOpeningInfo();

    }

    protected void ShowOpeningInfo()
    {
        MultiView1.SetActiveView(viewOpening);

        Tiyi.ShareOS.SQLServerDAL.SharesIssueConfig config = bll_Issue.GetIssueConfigByYear(DateTime.Now.Year);
        if (config != null)
        {
            ltlStatus.Text = config.IsOpen ? "开启" : "关闭";
            ltlYear2.Text = config.IssueYear.ToString();
            lbIssueNumber2.Text = (bll_monitor.GetLastIssueNumber()).ToString();
            lbSharePrice2.Text = config.SharePrice.ToString();
        }
    }
}