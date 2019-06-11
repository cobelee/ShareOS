<%@ Page Title="职工股权监控平台" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true"
    CodeFile="MonitorPlatform.aspx.cs" Inherits="Admin_MonitorPlatform" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>
        公司股权信息监控平台</h1>
    <asp:HiddenField ID="hfIssueNumber" runat="server" Value="0" />
    <p>
        <div class="comments">
        </div>
    </p>
    <table style="width: 100%">
        <thead>
            <td colspan="2" style="height: 50px; font-family: 微软雅黑; font-size: 18px">
                第
                <asp:Label ID="lbIssueNumber" runat="server" Text="Label"></asp:Label>
                期股权交易统计数字
            </td>
        </thead>
        <tr>
            <td style="width: 150px;">
                现有股东总数(人)
            </td>
            <td>
                <asp:Label ID="lbShareholderAmount" runat="server" Text="lbShareholderAmount"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                期初总股权数(股)
            </td>
            <td>
                <asp:Label ID="lbSharesAmount" runat="server" Text="lbSharesAmount"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                人均拥有股权数(股)
            </td>
            <td>
                <asp:Label ID="lbShareAmountPerCapita" runat="server" Text="lbShareAmountPerCapita"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                当前股价(元)
            </td>
            <td>
                <asp:Label ID="lbSharePrice" runat="server" Text="lbSharePrice"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                当前市值(元)
            </td>
            <td>
                <asp:Label ID="lbCapitalization" runat="server" Text="lbCapitalization"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                当期清退股权人数(人)
            </td>
            <td>
                <asp:Label ID="lbPersonNumberOfClearShare" runat="server" Text="lbPersonNumberOfClearShare"></asp:Label>
            </td>
            <td>
                新股东人数(人)
            </td>
            <td>
                <asp:Label ID="lbNumberOfNewShareholder" runat="server" Text="lbNumberOfNewShareholder"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                当期清退股权总数(股)
            </td>
            <td>
                <asp:Label ID="lbSharesAmountToClear" runat="server" Text="lbSharesAmountToClear"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                当期配发红股总数(股)
            </td>
            <td>
                <asp:Label ID="lbBonusShareAmount" runat="server" Text="lbBonusShareAmount"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                当期个人购买股权总数(股)
            </td>
            <td>
                <asp:Label ID="lbAmountOfShareholderBuyShare" runat="server" Text="lbAmountOfShareholderBuyShare"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                当期红股转让总数(股)
            </td>
            <td>
                <asp:Label ID="lbAmountOfBonusShareToSell" runat="server" Text="lbAmountOfBonusShareToSell"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
