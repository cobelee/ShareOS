<%@ Page Title="创建新股东" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true"
    CodeFile="CreateShareholder.aspx.cs" Inherits="Admin_CreateShareholder" %>

<%@ Register TagPrefix="user" TagName="SEA_Shareholder" Src="~/UserControls/SEA_Shareholder.ascx" %>
<%@ Register TagPrefix="user" TagName="AjaxMessageBox" Src="~/UserControls/AjaxMessageBox.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <h1>
        创建新股东</h1>
    <user:SEA_Shareholder ID="SEA_Shareholder1" runat="server" />
    <user:AjaxMessageBox ID="AjaxMessageBox1" runat="server" />
</asp:Content>
