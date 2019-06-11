<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SEA_Shareholder.ascx.cs"
    Inherits="UserControls_SEA_Shareholder" %>
<asp:HiddenField ID="hfAction" runat="server" Value="Add" />
<table>
    <tr>
        <td>
            股东号
        </td>
        <td>
            <asp:TextBox ID="tbShareholderNumber" runat="server"></asp:TextBox>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="rfvShareholderNumber" runat="server" ControlToValidate="tbShareholderNumber"
                ErrorMessage="请输入股东号" ValidationGroup="Shareholder"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>
            股东姓名
        </td>
        <td>
            <asp:TextBox ID="tbName" runat="server"></asp:TextBox>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="tbName"
                ErrorMessage="请输入股东姓名" ValidationGroup="Shareholder"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>
            工号
        </td>
        <td>
            <asp:TextBox ID="tbJobNumber" runat="server"></asp:TextBox>
        </td>
        <td>
            <asp:Button ID="btnImportInfo" runat="server" Text="从人事数据库导入人员信息" 
                onclick="btnImportInfo_Click" />
        </td>
    </tr>
    <tr>
        <td>
            性别
        </td>
        <td>
            <asp:RadioButton ID="rbtnMale" runat="server" Checked="True" GroupName="Sex" Text="男" />
            <asp:RadioButton ID="rbtnFemale" runat="server" GroupName="Sex" Text="女" />
        </td>
        <td>
        </td>
    </tr>
    <tr>
        <td>
            身份证号码
        </td>
        <td>
            <asp:TextBox ID="tbIdentityCard" runat="server"></asp:TextBox>
        </td>
        <td>
        </td>
    </tr>
    <tr>
        <td>
            人员类别
        </td>
        <td>
            <asp:DropDownList ID="ddlPersonType" runat="server">
            </asp:DropDownList>
        </td>
        <td>
        </td>
    </tr>
    <tr>
        <td>
        </td>
        <td>
            <asp:Button ID="btnCreateShareholder" runat="server" Text=" 创建股东 " OnClick="btnCreateShareholder_Click"
                ValidationGroup="Shareholder" />
        </td>
        <td>
        </td>
    </tr>
</table>
