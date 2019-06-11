using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShareOS.BLL;

public partial class Admin_Trade_Fenhong : System.Web.UI.Page
{
    ShareOS.BLL.MonitorOffice bll_monitor = new MonitorOffice();
    ShareOS.BLL.ShareIssueManage bll_Issue = new ShareIssueManage();
    ShareOS.BLL.ShareOwnershipManage bll_shareManage = new ShareOwnershipManage();
    ShareOS.BLL.SharesBonusManage bll_shareBonus = new SharesBonusManage();
    ShareOS.BLL.ShareIssueManage bll_issueManage = new ShareIssueManage();

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

            ltlDividend.Text = (config.Bonus ?? 0m).ToString();
            ltlTotalDividendAfter.Text = bll_monitor.GetDividendAmountToAllocate((int)config.IssueNumber).ToString("N2");
        }
        else
        {
            ltlYear.Text = "本期股权交易期尚未初始化，请操作第一步开启年度交易。";
            lbIssueNumber.Text = "本期股权交易期尚未初始化，请操作第一步开启年度交易。";
        }



    }

    protected void btnPaixi_Click(object sender, EventArgs e)
    {
        Tiyi.ShareOS.SQLServerDAL.SharesIssueConfig config = bll_issueManage.GetIssueConfigByYear(DateTime.Now.Year);
        if (config == null)
        {
            MessageBox1.Show("今年的股权交易期尚未开启，请到第一步开启。");
            return;
        }


        decimal dividend = 0;
        decimal.TryParse(tbDividend.Text, out dividend);
        ltlDividend.Text = tbDividend.Text;
        int issueNumber = (int)config.IssueNumber;
        bll_issueManage.SaveDividendConfig(issueNumber, dividend);      // 配置现金派息
        decimal dividendAmount = bll_monitor.GetDividendAmountToAllocate(issueNumber);

        if (dividendAmount > 0)
        {
            MessageBox1.Show("本交易期疑是已经派息，请再次确认。");
            return;
        }
        else
        {
            // 开始现金派息
            bll_shareBonus.PayBonus(issueNumber);
            dividendAmount = bll_monitor.GetDividendAmountToAllocate(issueNumber);
            ltlTotalDividendAfter.Text = dividendAmount.ToString("N2");
            MessageBox1.Show("现金派息完成");
            btnPaixi.Enabled = false;
        }

    }
}