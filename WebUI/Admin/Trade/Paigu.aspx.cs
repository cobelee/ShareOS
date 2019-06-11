using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShareOS.BLL;

public partial class Admin_Trade_Paigu : System.Web.UI.Page
{
    ShareOS.BLL.MonitorOffice bll_monitor = new MonitorOffice();
    ShareOS.BLL.ShareIssueManage bll_Issue = new ShareIssueManage();
    ShareOS.BLL.ShareOwnershipManage bll_shareManage = new ShareOwnershipManage();

    protected void Page_Load(object sender, EventArgs e)
    {
        Init_Load();
    }

    private void Init_Load()
    {
        Tiyi.ShareOS.SQLServerDAL.SharesIssueConfig config = bll_Issue.GetIssueConfigByYear(DateTime.Now.Year);
        if (config != null)
        {
            ltlYear.Text = config.IssueYear.ToString();
            lbIssueNumber.Text = config.IssueNumber.ToString();
            ltlSharePrice.Text = config.SharePrice.ToString();
            ltlTotalSharesAfter.Text = bll_monitor.GetBonusShareAmountToAllocate((int)config.IssueNumber).ToString("N0");

            decimal shareInitAmount = bll_monitor.GetSharesInitialAmount((int)config.IssueNumber);
            decimal kk = bll_monitor.GetBonusShareAmountToAllocate((int)config.IssueNumber);
            decimal scale = kk / shareInitAmount;
            ltlRationScale.Text = scale.ToString("N4");
        }
        else
        {
            ltlYear.Text = "本期股权交易期尚未初始化。";
            lbIssueNumber.Text = "本期股权交易期尚未初始化。";
        }



    }

    protected void btnPaigu_Click(object sender, EventArgs e)
    {
        int issueNumber = bll_monitor.GetLastIssueNumber();
        decimal rationScale = 0;
        decimal.TryParse(tbRationScale.Text, out rationScale);
        decimal sharePrice = 0;
        Decimal.TryParse(ltlSharePrice.Text, out sharePrice);
        string ope = User.Identity.Name;

        if (rationScale > 0)
        {
            bll_shareManage.ScalRationedShares(issueNumber, rationScale, sharePrice, ope);

            ltlRationScale.Text = tbRationScale.Text;
            ltlTotalSharesAfter.Text = bll_shareManage.GetCorporateShareTotals().ToString("N0");
            MessageBox1.Show("派股已完成");
            btnPaigu.Enabled = false;
        }
        else
        {
            MessageBox1.Show("派股比例未正确指定。");
        }
    }
}