<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="Paigu.aspx.cs" Inherits="Admin_Trade_Paigu" %>

<%@ Register TagPrefix="user" TagName="AjaxMessageBox" Src="~/UserControls/AjaxMessageBox.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <h1>派发股利</h1>
    <h4>将分红以股份方式派发给股东。按比例给所有持股的股东派股，如每100股派发8股，则派股比例填0.08。股值为股权交易当期的股价。</h4>
    <table style="width: 100%;">
        <tr>
            <td colspan="2">请输入新一期交易期数据</td>
            <td rowspan="5"></td>
            <td>本期派股信息</td>
        </tr>
        <tr>
            <td>股权年份期数：</td>
            <td>
                <asp:Literal ID="ltlYear" runat="server"></asp:Literal>年第
                <asp:Label ID="lbIssueNumber" runat="server"></asp:Label>期</td>
            <td rowspan="3">派股比例：<asp:Literal ID="ltlRationScale" runat="server"></asp:Literal><br />
                当期交易价格：<asp:Literal ID="ltlSharePrice" runat="server"></asp:Literal><br />
                当期已派股总数：<asp:Literal ID="ltlTotalSharesAfter" runat="server"></asp:Literal>
            </td>

        </tr>
        <tr>
            <td>派股比例：</td>
            <td>
                <asp:TextBox ID="tbRationScale" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="btnPaigu" runat="server" Text="派股" OnClick="btnPaigu_Click" OnClientClick='return confirm("此操作不可逆，请确认交易年份、派股比例、交易价格\r数据完全正确，点确定继续。")' /></td>
        </tr>
    </table>
    <user:AjaxMessageBox ID="MessageBox1" runat="server" />
</asp:Content>

