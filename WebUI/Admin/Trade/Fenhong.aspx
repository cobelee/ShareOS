<%@ Page Title="现金派息分红操作" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="Fenhong.aspx.cs" Inherits="Admin_Trade_Fenhong" %>

<%@ Register TagPrefix="user" TagName="AjaxMessageBox" Src="~/UserControls/AjaxMessageBox.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <h1>现金分红</h1>
    <h4>按持股比例，将企业经营收益的部分以现金分红方式发放给股东。<br />
        注意：系统以每10股派发股息计，如每股派息 0.18元，则填写1.8元/10股。</h4>
    <table style="width: 100%;">
        <tr>
            <td colspan="2">请输入新一期交易期数据</td>
            <td rowspan="5"></td>
            <td>本期派股信息</td>
        </tr>
        <tr>
            <td>当前股权交易期：</td>
            <td>
                <asp:Literal ID="ltlYear" runat="server"></asp:Literal>年第
                <asp:Label ID="lbIssueNumber" runat="server"></asp:Label>期</td>
            <td rowspan="3">每10股派发股息：<asp:Literal ID="ltlDividend" runat="server"></asp:Literal>元<br />
                当期已派发股息总金额：<asp:Literal ID="ltlTotalDividendAfter" runat="server"></asp:Literal> 元
            </td>

        </tr>
        <tr>
            <td>每10股派发股息：</td>
            <td>
                <asp:TextBox ID="tbDividend" runat="server"></asp:TextBox>
                元/10股</td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="btnPaixi" runat="server" Text="派息" OnClick="btnPaixi_Click" OnClientClick='return confirm("此操作不可逆，请确认交易年份、交易期数、派息金额\r数据完全正确，点确定继续。")' /></td>
        </tr>
    </table>
    <user:AjaxMessageBox ID="MessageBox1" runat="server" />
</asp:Content>

