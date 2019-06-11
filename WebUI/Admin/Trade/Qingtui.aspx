<%@ Page Title="清退股权" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="Qingtui.aspx.cs" Inherits="Admin_Trade_Qingtui" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>清退股权</h1>
    <h4>本功能可批量清退股权，输入参数为用逗号分隔的多个股东号。</h4>
    <table style="width: 100%;">
        <td colspan="2">交易期信息：<asp:Literal ID="ltlIssueInfo" runat="server"></asp:Literal><br />
            本期已清退人员数：<asp:Literal ID="ltlNoOfCleared" runat="server" Text="0"></asp:Literal>&nbsp;人
            <asp:HiddenField ID="hfIssueNumber" runat="server" Value="0" />
        </td>
        <tr>
            <td style="width: 100px;">输入本期要清退
                <br />
                的股东号列表：</td>
            <td>
                <asp:TextBox ID="tbShareholderNumbers" runat="server" TextMode="MultiLine" Rows="7" Width="100%"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegExpValidator1" runat="server" ErrorMessage="输入格式有误，逗号仅支持英文逗号，不允许逗号结尾" ControlToValidate="tbShareholderNumbers" ValidationExpression="^(\d+,)*\d+$" ValidationGroup="Qingtui"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="btnQingtui" runat="server" Text="清退股权" OnClick="btnQingtui_Click" ValidationGroup="Qingtui" /></td>
        </tr>
    </table>
</asp:Content>

