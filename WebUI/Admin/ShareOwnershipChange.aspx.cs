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



    protected void gvOwnershipChange_DataBound(object sender, EventArgs e)
    {
        decimal paifaTotal = 0m;
        decimal qingtuiTotal = 0m;
        decimal zhuangrangTotal = 0m;
        decimal goumaiTotal = 0m;
        decimal changeSum = 0m;
        foreach (GridViewRow row in gvOwnershipChange.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                decimal paifa = 0m;
                decimal qingtui = 0m;
                decimal zhuangrang = 0m;
                decimal goumai = 0m;
                decimal.TryParse(row.Cells[6].Text, out paifa);
                decimal.TryParse(row.Cells[7].Text, out qingtui);
                decimal.TryParse(row.Cells[8].Text, out zhuangrang);
                decimal.TryParse(row.Cells[9].Text, out goumai);
                paifaTotal += paifa;
                qingtuiTotal += qingtui;
                zhuangrangTotal += zhuangrang;
                goumaiTotal += goumai;
            }
        }
        lbPaifa.Text = paifaTotal.ToString();
        lbQingtui.Text = qingtuiTotal.ToString();
        lbZhuangrang.Text = zhuangrangTotal.ToString();
        lbGerenGoumai.Text = goumaiTotal.ToString();

        changeSum = paifaTotal + qingtuiTotal + zhuangrangTotal + goumaiTotal;
        lbChangeSum.Text = changeSum.ToString();
    }
}