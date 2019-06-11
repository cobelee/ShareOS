<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ShareholderList.aspx.cs" Inherits="EntrustedAgent_ShareholderList"
    Title="代理股东查询" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>
        代理股东查询</h1>
    <h3>
        委托代理人：<asp:Label ID="lbEntrustedAgentName" runat="server" Text=""></asp:Label></h3>
    <p class="post-footer">
        股东人数：<asp:Label ID="lbCountOfShareholder" runat="server" Text=""></asp:Label>
        位<br />
        (提示：点击列名，可排序。)</p>
    <asp:GridView ID="gvShareholderList" runat="server" AllowSorting="True" AutoGenerateColumns="False"
        OnSorting="gvShareholderList_Sorting" Width="625px">
        <Columns>
            <asp:BoundField DataField="股东号" HeaderText="股东号" ReadOnly="True" SortExpression="股东号" />
            <asp:BoundField DataField="工号" HeaderText="工号" SortExpression="工号" />
            <asp:BoundField DataField="姓名" HeaderText="姓名" SortExpression="姓名" />
            <asp:BoundField DataField="性别" HeaderText="性别" SortExpression="性别" />
            <asp:BoundField DataField="身份证号" HeaderText="身份证号" />
            <asp:BoundField DataField="人员类别" HeaderText="人员类别" SortExpression="人员类别" />
            <asp:BoundField DataField="股东状态" HeaderText="股东状态" SortExpression="股东状态" />
        </Columns>
    </asp:GridView>
</asp:Content>
