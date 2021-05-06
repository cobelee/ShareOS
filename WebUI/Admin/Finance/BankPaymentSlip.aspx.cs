using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Finance_YearlySettlement : System.Web.UI.Page
{
    ShareOS.BLL.MonitorOffice bll_office = new ShareOS.BLL.MonitorOffice();
    ShareOS.BLL.FinanceReport bll_finance = new ShareOS.BLL.FinanceReport();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Load_Bank();
            Load_IssueNumber();
        }

    }



    #region 定义全局变量
    decimal yingfaTotal = 0m;
    decimal incomeTaxTotal = 0m;
    #endregion

    #region 初始化dropdown控件
    private void Load_Bank()
    {
        var banks = bll_finance.GetBankNameList();
        ddlBank.Items.Clear();
        foreach (var bank in banks)
        {
            ddlBank.Items.Add(bank.BankName);
        }
        ddlBank.SelectedIndex = 0;
    }
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
    #endregion

    protected void btnGenerate_Click(object sender, EventArgs e)
    {
        int issueNumber = 0;
        int.TryParse(ddlIssueNumber.SelectedValue, out issueNumber);

        bll_finance.GenerateSettlementReport(issueNumber);
        GridView1.DataBind();
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            decimal yingfa = 0m;
            decimal tax = 0m;
            DataRowView row = (DataRowView)e.Row.DataItem;

            decimal.TryParse(row["IncomeTax"].ToString(), out tax);
            decimal.TryParse(row["yingfa"].ToString(), out yingfa);
            incomeTaxTotal += tax;
            yingfaTotal += yingfa;
        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[7].Text = incomeTaxTotal.ToString("N2");
            e.Row.Cells[8].Text = yingfaTotal.ToString("N2");
        }

    }

    protected void btnQuery_Click(object sender, EventArgs e)
    {
        ObjectDataSource1.FilterExpression = GetFilterExpression();
        GridView1.DataBind();
    }



    /// <summary>
    /// 获取筛选语句。
    /// </summary>
    /// <returns></returns>
    protected string GetFilterExpression()
    {
        string filter = string.Empty;
        if (ddlStatus.SelectedIndex > 0)
            filter += "Status='" + ddlStatus.SelectedValue + "' and BankName='" + ddlBank.SelectedValue + "'";
        else
            filter += "BankName='" + ddlBank.SelectedValue + "'";
        return filter;
    }

    protected void GridView1_DataBinding(object sender, EventArgs e)
    {
        ObjectDataSource1.FilterExpression = GetFilterExpression();
    }
}