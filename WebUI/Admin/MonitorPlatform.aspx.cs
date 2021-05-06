using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_MonitorPlatform : System.Web.UI.Page
{
    ShareOS.BLL.MonitorOffice bll_monitor = new ShareOS.BLL.MonitorOffice();
    ShareOS.BLL.SharesBonusManage bll_bonus = new ShareOS.BLL.SharesBonusManage();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            hfIssueNumber.Value = bll_bonus.GetLastIssueNumber().ToString();
            Load_Data();
        }
    }

    /// <summary>
    /// 加载数据
    /// </summary>
    private void Load_Data()
    {
        int issueNumber = Convert.ToInt32(hfIssueNumber.Value);
        lbIssueNumber.Text = issueNumber.ToString();

        int shareholderAmount = bll_monitor.GetSharesholderAmount(issueNumber);
        int shareAmount = bll_monitor.GetSharesInitialAmount(issueNumber);

        lbShareholderAmount.Text = shareholderAmount.ToString();
        lbSharesAmount.Text = shareAmount.ToString("N0");
        lbShareAmountPerCapita.Text = (shareAmount / shareholderAmount).ToString("N0");

        decimal sharePrice = bll_monitor.GetSharePrice(issueNumber);
        lbSharePrice.Text = sharePrice.ToString();
        lbCapitalization.Text = (shareAmount * sharePrice).ToString("N");

        lbPersonNumberOfClearShare.Text = bll_monitor.GetPersonNumberOfClearShare(issueNumber).ToString();
        //新股东人数(人)
        lbNumberOfNewShareholder.Text = bll_monitor.GetNumberOfBeNewShareholder(issueNumber).ToString();
        lbSharesAmountToClear.Text = bll_monitor.GetSharesAmountToClear(issueNumber).ToString("N2");

        //当期派发红股总数(股)
        lbBonusShareAmount.Text = bll_monitor.GetBonusShareAmountToAllocate(issueNumber).ToString("N0");

        //获取某期职工个人购买股权的总数量
        lbAmountOfShareholderBuyShare.Text = bll_monitor.GetAmountOfShareholderBuyShare(issueNumber).ToString("N0");

        //当期红股转让总数(股)
        lbAmountOfBonusShareToSell.Text = bll_monitor.GetAmountOfBonusShareToSell(issueNumber).ToString("N2");
    }
}