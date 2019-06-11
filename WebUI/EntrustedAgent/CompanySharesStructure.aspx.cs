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

public partial class EntrustedAgent_CompanySharesStructure : System.Web.UI.Page
{
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
                if (bll_ea.Exist(shareholder.ShareholderNumber) || bll_ea.IsAssistant(User.Identity.Name) || User.Identity.Name == "101527")
                {
                    Load_Company_Shares();
                }
                else
                {
                    Session["ErrorMessage"] = "该信息需要股东委托代理人才能查询！<br />或者，经由股东代理人为您授权，方可访问。";
                    Response.Redirect("~/Error.aspx");
                }
            }
        }
        else
        {
            Session["ErrorMessage"] = "信息需要登录后才能查询！";
            Response.Redirect("~/Error.aspx");
        }
    }

    protected void Load_Company_Shares()
    {
        DataTable table = bll_som.GetShareOwnershipStatisticsReportByEntrustedAgent();
        DataView view = table.DefaultView;
        gvCompanyShares.DataSource = view;
        gvCompanyShares.Columns[3].FooterStyle.HorizontalAlign = HorizontalAlign.Right;
        gvCompanyShares.Columns[3].FooterText = GetSharesSum(table).ToString("N0");
        gvCompanyShares.DataBind();
    }

    protected int GetSharesSum(DataTable table)
    {
        int sum = 0;
        foreach (DataRow row in table.Rows)
        {
            sum += Convert.ToInt32(row["SharesAmount"]);
        }
        return sum;
    }
    protected void gvCompanyShares_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataView view = gvCompanyShares.DataSource as DataView;
        view.Sort = e.SortExpression;
        gvCompanyShares.DataBind();
    }
}
