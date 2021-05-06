<%@ Page Title="注销股东身份" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true"
    CodeFile="LogOffIdentity.aspx.cs" Inherits="Admin_LogOffIdentity" %>

<%@ Register TagPrefix="User" TagName="AjaxMessageBox" Src="~/UserControls/AjaxMessageBox.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <h1>
        注销股东身份</h1>
    <div class="comments">
        以下列表是所有股权已退出的人员，可以注销其股东身份。</div>
    <div>
        <asp:Button ID="btnLogoutStatus" runat="server" Text="注销股东身份" OnClick="btnLogoutStatus_Click" /></div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:GridView ID="gvRegister" runat="server" DataSourceID="odsShareholders" AllowSorting="True"
                AutoGenerateColumns="False" DataKeyNames="ShareholderNumber">
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:CheckBox ID="cbSelectAll" runat="server" AutoPostBack="True" OnCheckedChanged="cbSelectAll_CheckedChanged" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="cbSelect" runat="server" />
                        </ItemTemplate>
                        <ItemStyle Width="20px" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="ShareholderNumber" HeaderText="股东号" />
                    <asp:BoundField DataField="JobNumber" HeaderText="工号" />
                    <asp:BoundField DataField="ShareholderName" HeaderText="姓名">
                        <ItemStyle Width="50px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Sex" HeaderText="性别" />
                    <asp:BoundField DataField="PersonType" HeaderText="人员类别" />
                    <asp:BoundField DataField="Status" HeaderText="股东身份" />
                    <asp:BoundField DataField="EntrustedAgentName" HeaderText="股权代理人" />
                    <asp:BoundField DataField="ShareTotals" HeaderText="当前股权数" />
                </Columns>
                <EmptyDataTemplate>
                    <asp:Label ID="Label1" runat="server" Text="当前无可退出人员。"></asp:Label>
                </EmptyDataTemplate>
            </asp:GridView>
            <asp:ObjectDataSource ID="odsShareholders" runat="server" SelectMethod="SelectShareholdersHaveNoShare"
                TypeName="ShareOS.BLL.ShareholderRegister" FilterExpression="Status='股东'"></asp:ObjectDataSource>
        </ContentTemplate>
    </asp:UpdatePanel>
    <User:AjaxMessageBox ID="ajaxMessageBox1" runat="server" />
</asp:Content>
