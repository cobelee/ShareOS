<%@ Page Title="股权变动记录" Language="C#" MasterPageFile="~/Mobile/MasterPage.master"
    AutoEventWireup="true" CodeFile="PersonalSharesChanges.aspx.cs" Inherits="Mobile_PersonalSharesChanges" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>
        股权变动记录</h1>
    <h3>
        <asp:Label ID="lbShareholderName" runat="server" Text=""></asp:Label></h3>
    <asp:GridView ID="gvPersonShareOwnership" runat="server" AutoGenerateColumns="False"
        SkinID="DataGridView" Width="100%">
        <Columns>
            <asp:BoundField DataField="IssueNumber" DataFormatString="第{0:D}期" HeaderText="期数" />
            <asp:BoundField DataField="RegDate" DataFormatString="{0:yyyy-MM-dd}" HeaderText="时间" />
            <asp:BoundField DataField="SharesChanges" HeaderText="股权增减(+增加 -减少)" DataFormatString="{0:N2}">
                <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="OriginalSharePrice" HeaderText="交易股价(元)" DataFormatString="{0:C4}" />
            <asp:BoundField DataField="CauseOfChange" HeaderText="变动事由" />
            <asp:BoundField DataField="ShareTotals" HeaderText="持股总数" DataFormatString="{0:N0}">
                <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
        </Columns>
    </asp:GridView>
</asp:Content>
