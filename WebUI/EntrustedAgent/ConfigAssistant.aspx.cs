using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EntrustedAgent_ConfigAssistant : System.Web.UI.Page
{
    ShareOS.BLL.EntrustedAgent bll_ea = new ShareOS.BLL.EntrustedAgent();
    ShareOS.BLL.ShareholderRegister bll_sr = new ShareOS.BLL.ShareholderRegister();

    Tiyi.MyDesktop.BLL.PersonManage bll_person = new Tiyi.MyDesktop.BLL.PersonManage();


    protected void Page_Load(object sender, EventArgs e)
    {
        if (User.Identity.IsAuthenticated)
        {
            if (bll_sr.ExistShareholder(User.Identity.Name))
            {
                ShareOS.Model.Shareholder shareholder = bll_sr.GetShareholder(User.Identity.Name);
                hfAgentShareholderNumber.Value = shareholder.ShareholderNumber.ToString();
                if (bll_ea.Exist(shareholder.ShareholderNumber))
                {
                    odsAssistant.SelectParameters["agentShareholderNumber"].DefaultValue = shareholder.ShareholderNumber.ToString();
                }
                else
                {
                    Session["ErrorMessage"] = "该信息需要股东委托代理人才能查询！";
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
    protected void btnAssign_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(tbJobNumber.Text))
        {
            int agent = bll_ea.GetAgentShareholderNumber(tbJobNumber.Text.Trim());
            if (agent > 0)
            {
                ShareOS.Model.Shareholder shareholder2 = bll_sr.GetShareholder(agent);
                lbConfirmMessage.Text = "该员工当前是 " + shareholder2.ShareholderName + " 的助理，" + "若您继续授权的话，他(她)将无法为" + shareholder2.ShareholderName + "代为处理事务。<br/>是否继续授权？";
                pnlConfirm.Visible = true;
            }
            else
            {
                Assiagn_Assistant(tbJobNumber.Text.Trim());
            }
        }
    }

    protected void Assiagn_Assistant(string jobNumber)
    {
        int agentShn;
        int.TryParse(hfAgentShareholderNumber.Value, out agentShn);
        if (bll_person.ExistPerson(jobNumber))
        {
            bll_ea.AssignAssistant(agentShn, jobNumber);
        }
        gvAssistant.DataBind();
    }

    public string GetName(string jobNumber)
    {
        var person = bll_person.GetPerson(jobNumber);
        return person.Name;
    }

    protected void lbtnDelete_Click(object sender, EventArgs e)
    {
        LinkButton lbtnDelete = sender as LinkButton;
        string jobNumber = lbtnDelete.CommandArgument;
        int agentShn;
        int.TryParse(hfAgentShareholderNumber.Value, out agentShn);
        bll_ea.DeleteAssistant(agentShn, jobNumber);
        gvAssistant.DataBind();
    }
    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(tbJobNumber.Text))
        {
            Assiagn_Assistant(tbJobNumber.Text.Trim());
            pnlConfirm.Visible = false;
        }
    }
}