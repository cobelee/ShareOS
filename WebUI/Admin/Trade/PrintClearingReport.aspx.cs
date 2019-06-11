using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Trade_PrintClearingReport : System.Web.UI.Page
{
    ShareOS.BLL.ShareIssueManage bll_issue = new ShareOS.BLL.ShareIssueManage();
    ShareOS.BLL.ShareOwnershipManage bll_Shares = new ShareOS.BLL.ShareOwnershipManage();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Load_config();
            Load_ClearingPerson();
        }
    }

    private void Load_config()
    {
        Tiyi.ShareOS.SQLServerDAL.SharesIssueConfig config = bll_issue.GetIssueConfigByYear(DateTime.Now.Year);
        if (config != null)
        {
            ltlYear.Text = config.IssueYear.ToString();
            ltlIssueNumber.Text = config.IssueNumber.ToString();
        }
        else
        {
            ltlYear.Text = "本期股权交易未初始化";
            ltlIssueNumber.Text = "本期股权交易未初始化";
        }
    }

    private void Load_ClearingPerson()
    {
        int issueNumber = 0;
        int.TryParse(ltlIssueNumber.Text, out issueNumber);
        if (issueNumber > 0)
        {
            var clearingPerson = bll_Shares.GetSharesWithdrawal(issueNumber);
            gvClearing.DataSource = clearingPerson;
            gvClearing.DataBind();
        }
    }

    protected void cbSelectAll_CheckedChanged(object sender, EventArgs e)
    {

        CheckBox cbSelectAll = sender as CheckBox;
        //GridView gv = cbSelectAll.Parent.Parent as GridView;
        foreach (GridViewRow row in gvClearing.Rows)
        {
            CheckBox cbSelect = row.Cells[0].FindControl("cbSelect") as CheckBox;
            cbSelect.Checked = cbSelectAll.Checked;
        }
    }

    protected void btnPrint_Click(object sender, EventArgs e)
    {
        List<string> shNumList = new List<string>();
        foreach (GridViewRow row in gvClearing.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                CheckBox cbSelect = row.Cells[0].FindControl("cbSelect") as CheckBox;
                if (cbSelect.Checked)
                {
                    string shNum = gvClearing.DataKeys[row.RowIndex].Value.ToString();
                    shNumList.Add(shNum);
                }
            }

        }
        Session["ClearingShareholderNumbers"] = string.Join(",", shNumList.ToArray());
        Server.Transfer("PrintClearingReport_PrintView.aspx", true);
    }
}