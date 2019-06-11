using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ChangeAgent : System.Web.UI.Page
{
    ShareOS.BLL.ShareholderRegister bll_Register = new ShareOS.BLL.ShareholderRegister();
    ShareOS.BLL.EntrustedAgent bll_Agent = new ShareOS.BLL.EntrustedAgent();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Databind_ddlAgent();
            Databind_ddlSetAgent();
        }

    }

    protected void Databind_ddlAgent()
    {
        IList<ShareOS.Model.EntrustedAgent> agents = bll_Agent.Select();
        ddlAgents.Items.Clear();
        foreach (ShareOS.Model.EntrustedAgent agent in agents)
        {
            ddlAgents.Items.Add(new ListItem(agent.ShareholderName, agent.ShareholderNumber.ToString()));
        }
        ddlAgents.Items.Insert(0, "---全部---");
    }

    protected void Databind_ddlSetAgent()
    {
        IList<ShareOS.Model.EntrustedAgent> agents = bll_Agent.Select();
        ddlSetAgent.Items.Clear();
        foreach (ShareOS.Model.EntrustedAgent agent in agents)
        {
            ddlSetAgent.Items.Add(new ListItem(agent.ShareholderName, agent.ShareholderNumber.ToString()));
        }
        ddlSetAgent.Items.Insert(0, "---不操作---");
    }

    protected void gvRegister_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int shareholderId = Convert.ToInt32(gvRegister.DataKeys[e.RowIndex].Value);
        DropDownList ddlAgent = gvRegister.Rows[e.RowIndex].Cells[7].FindControl("ddlAgent") as DropDownList;
        int agentShareholderNumber = Convert.ToInt32(ddlAgent.SelectedItem.Value);
        ShareOS.BLL.Shareholder shareholder = bll_Register.GetShareholder(agentShareholderNumber);
        ShareOS.Model.EntrustedAgent agent = new ShareOS.Model.EntrustedAgent();
        agent.ShareholderNumber = shareholder.ShareholderNumber;
        bll_Agent.ActFor(shareholderId, agent);

        gvRegister.DataBind();
    }


    protected void odsShareholders_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        if (ddlAgents.SelectedIndex == 0)
        {
            odsShareholders.FilterParameters.Clear();

        }
        else
        {
            odsShareholders.FilterExpression = "EntrustedAgentName='" + ddlAgents.SelectedItem.Text + "'";
        }
    }
    protected void ddlAgents_SelectedIndexChanged(object sender, EventArgs e)
    {
        gvRegister.DataBind();
    }
    protected void ddlSetAgent_SelectedIndexChanged(object sender, EventArgs e)
    {
        int agentShareholderNumber = Convert.ToInt32(ddlSetAgent.SelectedItem.Value);
        ShareOS.BLL.Shareholder shareholder = bll_Register.GetShareholder(agentShareholderNumber);
        ShareOS.Model.EntrustedAgent agent = new ShareOS.Model.EntrustedAgent();
        agent.ShareholderNumber = shareholder.ShareholderNumber;

        foreach (GridViewRow row in gvRegister.Rows)
        {
            if ((row.Cells[0].FindControl("cbSelect") as CheckBox).Checked)
            {
                int shareholderId = Convert.ToInt32(gvRegister.DataKeys[row.RowIndex].Value);

                bll_Agent.ActFor(shareholderId, agent);
            }
        }
        gvRegister.DataBind();
    }
}