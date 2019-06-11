using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Admin_ShareOwnershipList : System.Web.UI.Page
{
    ShareOS.BLL.SharesBonusManage bll_bonus = new ShareOS.BLL.SharesBonusManage();
    ShareOS.BLL.EntrustedAgent bll_ea = new ShareOS.BLL.EntrustedAgent();
    ShareOS.BLL.ShareholderRegister bll_sr = new ShareOS.BLL.ShareholderRegister();
    ShareOS.BLL.ShareOwnershipManage bll_som = new ShareOS.BLL.ShareOwnershipManage();
    Tiyi.PMS.PersonnelRoll bll_person = new Tiyi.PMS.PersonnelRoll();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Databind_ddlAgent();
            Load_ShareOwnershipList(ddlAgents.SelectedItem.Text);
        }



    }

    protected void Databind_ddlAgent()
    {
        IList<ShareOS.Model.EntrustedAgent> agents = bll_ea.Select();
        ddlAgents.Items.Clear();
        foreach (ShareOS.Model.EntrustedAgent agent in agents)
        {
            ddlAgents.Items.Add(new ListItem(agent.ShareholderName, agent.ShareholderNumber.ToString()));
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
    protected void ddlAgents_SelectedIndexChanged(object sender, EventArgs e)
    {
        Load_ShareOwnershipList(ddlAgents.SelectedItem.Text);
    }

    protected string GetOtherMessage(string jobNumber)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        
        Tiyi.PMS.Personnel person = bll_person.GetPersonnelByJobNumber(jobNumber);
        sb.Append("身份证号：");
        sb.AppendLine(person.Individual.IdentityCard);
        sb.AppendLine("<br />");
        sb.Append("家庭地址：");
        sb.AppendLine(person.Address.NativePlace);
        return sb.ToString();
    }
}
