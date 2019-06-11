<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Error.aspx.cs" Inherits="Error" Title="出错" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>
        提示
    </h1>
    <h3>
        <asp:Label ID="lbMessage" runat="server" Text=""></asp:Label></h3>
</asp:Content>
