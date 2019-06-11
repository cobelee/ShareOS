<%@ Page Title="开启年度交易" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="Open.aspx.cs" Inherits="Admin_Trade_Open" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>开启年度交易</h1>
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="viewToOpen" runat="server">
            <table>
                <tr>
                    <td colspan="2">
                        <asp:Literal ID="ltlLastInfo" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">请输入新一期交易期数据</td>
                </tr>
                <tr>
                    <td>股权交易年份：</td>
                    <td>
                        <asp:Literal ID="ltlYear" runat="server"></asp:Literal></td>
                </tr>
                <tr>
                    <td>股权交易期数：</td>
                    <td>
                        <asp:TextBox ID="tbIssueNumber" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>本期交易价格：</td>
                    <td>
                        <asp:TextBox ID="tbSharePrice" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnOpen" runat="server" Text="开启本期交易" OnClick="btnOpen_Click" /></td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="viewOpening" runat="server">
            <table>
                <tr>
                    <td colspan="2">当前交易期数据</td>
                </tr>
                <tr>
                    <td>股权期状态：</td>
                    <td>
                        <asp:Literal ID="ltlStatus" runat="server"></asp:Literal></td>
                </tr>
                <tr>
                    <td>股权交易年份：</td>
                    <td>
                        <asp:Literal ID="ltlYear2" runat="server"></asp:Literal></td>
                </tr>
                <tr>
                    <td>股权交易期数：</td>
                    <td>
                        <asp:Label ID="lbIssueNumber2" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td>本期交易价格：</td>
                    <td>
                        <asp:Label ID="lbSharePrice2" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td></td>
                    <td></td>
                </tr>
            </table>
        </asp:View>
    </asp:MultiView>

</asp:Content>

