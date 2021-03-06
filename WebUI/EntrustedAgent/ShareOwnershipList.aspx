﻿<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ShareOwnershipList.aspx.cs" Inherits="EntrustedAgent_ShareOwnershipList"
    Title="代理股权查询" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>代理股权查询</h1>
    <h3>委托代理人：<asp:Label ID="lbEntrustedAgentName" runat="server" Text=""></asp:Label></h3>
    <p class="post-footer">
        股东人数：<asp:Label ID="lbCountOfShareholder" runat="server" Text="Label"></asp:Label>
        位<br />
        (提示：点击列名，可排序。)
    </p>
    <asp:GridView ID="gvShareOwnership" runat="server" AllowSorting="True" AutoGenerateColumns="False"
        OnSorting="gvShareOwnership_Sorting" ShowFooter="True" Width="625px">
        <Columns>
            <asp:BoundField DataField="ShareholderNumber" HeaderText="股东号" SortExpression="ShareholderNumber" />
            <asp:BoundField DataField="JobNumber" HeaderText="工号" SortExpression="JobNumber" />
            <asp:BoundField DataField="ShareholderName" HeaderText="姓名" SortExpression="ShareholderName" />
            <asp:BoundField DataField="Sex" HeaderText="性别" SortExpression="Sex" />
            <asp:BoundField DataField="PersonType" HeaderText="人员类别" SortExpression="PersonType" />
            <asp:BoundField DataField="IdentityCard" HeaderText="身份证号" SortExpression="IdentityCard" />
            <asp:BoundField DataField="ShareTotals" HeaderText="股权数" SortExpression="ShareTotals"
                DataFormatString="{0:N0}">
                <ItemStyle HorizontalAlign="Right" Width="150px" />
            </asp:BoundField>
        </Columns>
    </asp:GridView>
</asp:Content>
