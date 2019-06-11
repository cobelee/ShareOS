<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="CompanySharesStructure.aspx.cs" Inherits="EntrustedAgent_CompanySharesStructure"
    Title="公司股权结构" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>
        公司股权结构</h1>
    <p class="post-footer">
        提示：点击列名，可排序。</p>
    <asp:GridView ID="gvCompanyShares" runat="server" AllowSorting="True" AutoGenerateColumns="False"
        OnSorting="gvCompanyShares_Sorting" ShowFooter="True" Width="625px">
        <Columns>
            <asp:BoundField DataField="EntrustedAgentName" HeaderText="股东代理人" SortExpression="EntrustedAgentName" />
            <asp:BoundField DataField="CountOfShareholder" HeaderText="代理人数" SortExpression="CountOfShareholder" />
            <asp:BoundField DataField="SharesAmount" DataFormatString="{0:N0}" HeaderText="代理股权数"
                SortExpression="SharesAmount">
                <ItemStyle HorizontalAlign="Right" Width="150px" />
            </asp:BoundField>
            <asp:BoundField DataField="SharesRatio" DataFormatString="{0:F4}" FooterText="100%"
                HeaderText="持股比例(%)" SortExpression="SharesRatio">
                <FooterStyle HorizontalAlign="Right" />
                <ItemStyle HorizontalAlign="Right" Width="150px" />
            </asp:BoundField>
        </Columns>
    </asp:GridView>
</asp:Content>
