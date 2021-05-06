using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Finance_Clearing : System.Web.UI.Page
{
    ShareOS.BLL.MonitorOffice bll_office = new ShareOS.BLL.MonitorOffice();
    ShareOS.BLL.FinanceReport bll_finance = new ShareOS.BLL.FinanceReport();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Load_IssueNumber();
        }


    }

    #region
    decimal yingfaTotal = 0m;
    #endregion

    private void Load_IssueNumber()
    {
        int currentIssueNumber = 0;
        currentIssueNumber = bll_office.GetLastIssueNumber();
        ddlIssueNumber.Items.Clear();
        for (int i = currentIssueNumber; i >= 0; i--)
        {
            ddlIssueNumber.Items.Add(new ListItem(i.ToString()));
        }
    }

    protected void btnGenerate_Click(object sender, EventArgs e)
    {
        int issueNumber = 0;
        int.TryParse(ddlIssueNumber.SelectedValue, out issueNumber);

        bll_finance.GenerateClearingReport(issueNumber);
        GridView1.DataBind();
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType== DataControlRowType.DataRow)
        {
            decimal yingfa = 0m;
            DataRowView row = (DataRowView)e.Row.DataItem;

            decimal.TryParse(row["yingfa"].ToString(), out yingfa);
            yingfaTotal += yingfa;
        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[13].Text = yingfaTotal.ToString("N2");
        }

    }
}