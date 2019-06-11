<%@ Page Title="" Language="C#" MasterPageFile="~/Mobile/MasterPage.master" AutoEventWireup="true"
    CodeFile="PersonInfo.aspx.cs" Inherits="Mobile_PersonInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        table
        {
            table-layout: fixed;
        }
        .layoutTable td
        {
            border: 1px solid #CCCCFF;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>
        个人股东信息</h1>
    <h3>
        <asp:Label ID="lbShareholderName" runat="server" Text=""></asp:Label></h3>
    <table class="layoutTable">
        <tr>
            <th class="first">
                项目
            </th>
            <th>
                信息
            </th>
            <th class="first">
                项目
            </th>
            <th>
                信息
            </th>
        </tr>
        <tr class="row-a">
            <td class="first">
                性别
            </td>
            <td>
                <asp:Label ID="lbSex" runat="server" Text=""></asp:Label>
            </td>
            <td class="first">
                股东状态
            </td>
            <td>
                <asp:Label ID="lbStatus" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr class="row-b">
            <td class="first">
                股东号
            </td>
            <td>
                <asp:Label ID="lbShareholderNumber" runat="server" Text=""></asp:Label>
            </td>
            <td class="first">
                身份证号
            </td>
            <td>
                <asp:Label ID="lbIdentityCard" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr class="row-a">
            <td class="first">
                人员类别
            </td>
            <td>
                <asp:Label ID="lbPersonType" runat="server" Text=""></asp:Label>
            </td>
            <td class="first">
                委托代理人
            </td>
            <td>
                <asp:Label ID="lbEntrustedAgent" runat="server" Text=""></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
