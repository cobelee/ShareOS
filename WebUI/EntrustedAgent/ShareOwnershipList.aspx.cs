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

public partial class EntrustedAgent_ShareOwnershipList : System.Web.UI.Page
{
    ShareOS.BLL.SharesBonusManage bll_bonus = new ShareOS.BLL.SharesBonusManage();
    ShareOS.BLL.EntrustedAgent bll_ea = new ShareOS.BLL.EntrustedAgent();
    ShareOS.BLL.ShareholderRegister bll_sr = new ShareOS.BLL.ShareholderRegister();
    ShareOS.BLL.ShareOwnershipManage bll_som = new ShareOS.BLL.ShareOwnershipManage();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (User.Identity.IsAuthenticated)
        {
            if (bll_sr.ExistShareholder(User.Identity.Name))
            {
                ShareOS.Model.Shareholder shareholder = bll_sr.GetShareholder(User.Identity.Name);
                if (bll_ea.Exist(shareholder.ShareholderNumber))
                {
                    lbEntrustedAgentName.Text = shareholder.ShareholderName;

                    Load_ShareOwnershipList(shareholder.ShareholderName);
                }
                else
                {
                    if (bll_ea.IsAssistant(User.Identity.Name))
                    {
                        int agent = bll_ea.GetAgentShareholderNumber(User.Identity.Name);
                        ShareOS.Model.Shareholder shareholder2 = bll_sr.GetShareholder(agent);
                        Load_ShareOwnershipList(shareholder2.ShareholderName);
                    }
                    else
                    {
                        Session["ErrorMessage"] = "该信息需要股东代理人才能查询！<br />或者，经由股东代理人为您授权，方可访问。";
                        Response.Redirect("~/Error.aspx");
                    }
                }
            }
        }
        else
        {
            Session["ErrorMessage"] = "信息需要登录后才能查询！";
            Response.Redirect("~/Error.aspx");
        }
    }

    protected void Load_ShareOwnershipList(string entrustedAgentName)
    {
        int issueNumber = bll_bonus.GetLastIssueNumber();
        DataTable table = bll_som.GetShareOwnershipReport(issueNumber);
        DataView view = table.DefaultView;
        view.RowFilter = "EntrustedAgentName = '" + entrustedAgentName + "'";
        gvShareOwnership.DataSource = view;
        gvShareOwnership.Columns[4].FooterStyle.HorizontalAlign = HorizontalAlign.Right;
        gvShareOwnership.Columns[4].FooterText = GetSharesSum(table, entrustedAgentName).ToString("N0");
        gvShareOwnership.DataBind();

    }


    protected void gvShareOwnership_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataView view = gvShareOwnership.DataSource as DataView;
        view.Sort = e.SortExpression;
        gvShareOwnership.DataBind();
    }

    protected int GetSharesSum(DataTable table, string filterName)
    {
        int sum = 0;
        int countOfShareholder = 0;
        foreach (DataRow row in table.Rows)
        {
            if (row["EntrustedAgentName"].ToString() == filterName)
            {
                sum += Convert.ToInt32(row["ShareTotals"]);
                countOfShareholder++;
            }
        }
        lbCountOfShareholder.Text = countOfShareholder.ToString();
        return sum;
    }


}
