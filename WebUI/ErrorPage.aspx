<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ErrorPage.aspx.cs" Inherits="ErrorPage" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="width: 100%; color: #CC0099; font-size: x-large; text-align: center;
        margin: 50px 0 0 30">
        <asp:Literal ID="ltlErrorMessage" runat="server"></asp:Literal><br />
        <br />
        <asp:Button ID="btnGoBack" runat="server" Text="返回前页" OnClick="btnGoBack_Click" />
    </div>
</asp:Content>
