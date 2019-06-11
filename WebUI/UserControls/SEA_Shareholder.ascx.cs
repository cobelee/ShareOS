using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControls_SEA_Shareholder : System.Web.UI.UserControl
{
    ShareOS.BLL.PersonType bll_personType = new ShareOS.BLL.PersonType();
    ShareOS.BLL.ShareholderRegister bll_register = new ShareOS.BLL.ShareholderRegister();
    ShareOS.BLL.ShareholderManage bll_shareholderManage = new ShareOS.BLL.ShareholderManage();
    Tiyi.PMS.PersonnelRoll wsPerson = new Tiyi.PMS.PersonnelRoll();

    public event EventHandler ShareholderCreated;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataBind_PersonType();
        }
    }

    public string Action
    {
        get { return hfAction.Value; }
        set { hfAction.Value = value; }
    }



    private void DataBind_PersonType()
    {
        IList<ShareOS.Model.PersonType> personTypes = bll_personType.GetPersonTypes();

        ddlPersonType.Items.Clear();
        foreach (ShareOS.Model.PersonType pt in personTypes)
        {
            ddlPersonType.Items.Add(pt.PersonTypeName);
        }
        if (ddlPersonType.Items.Count > 0)
        {
            ddlPersonType.SelectedIndex = 0;
        }
    }
    protected void btnCreateShareholder_Click(object sender, EventArgs e)
    {
        var shareholder = new Tiyi.ShareOS.SQLServerDAL.Shareholder();
        shareholder.ShareholderNumber = Convert.ToInt32(tbShareholderNumber.Text);
        shareholder.JobNumber = tbJobNumber.Text;
        shareholder.ShareholderName = tbName.Text;
        shareholder.Sex = rbtnMale.Checked ? true : false;
        shareholder.IdentityCard = tbIdentityCard.Text;
        shareholder.PersonType = ddlPersonType.SelectedItem.ToString();
        shareholder.Status = ShareOS.Model.ShareholderStatus.股东.ToString();

        bll_shareholderManage.CreateShareholder(shareholder);

        if (ShareholderCreated != null)
        {
            ShareholderCreated(this, new EventArgs());
        }

        tbShareholderNumber.Text = string.Empty;
        tbJobNumber.Text = string.Empty;
        tbName.Text = string.Empty;
        rbtnMale.Checked = true;
        tbIdentityCard.Text = string.Empty;
        ddlPersonType.SelectedIndex = 0;
    }
    protected void btnImportInfo_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(tbJobNumber.Text))
        {
            Tiyi.PMS.Personnel person = wsPerson.GetPersonnelByJobNumber(tbJobNumber.Text);
            tbName.Text = person.Individual.Name;
            if (person.Individual.Sex)
            {
                rbtnMale.Checked = true;
                rbtnFemale.Checked = false;
            }
            else
            {
                rbtnMale.Checked = false;
                rbtnFemale.Checked = true;
            }
            tbIdentityCard.Text = person.Individual.IdentityCard;
        }
    }
}