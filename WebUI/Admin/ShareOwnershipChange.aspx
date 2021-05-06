<%@ Page Title="股权变动查询" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true"
    CodeFile="ShareOwnershipChange.aspx.cs" Inherits="Admin_ShareOwnershipChange" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>股权变动查询</h1>
    <p>
        以下所列为当年股权发生变动的记录，包括老股东、新股东及当年股权清退的人员。<br />
        当年派发红股总数：<asp:Label ID="lbPaifa" runat="server" Text="0"></asp:Label><br />
        当年清退股权总数：<asp:Label ID="lbQingtui" runat="server" Text="0"></asp:Label><br />
        当年转让股权总数：<asp:Label ID="lbZhuangrang" runat="server" Text="0"></asp:Label><br />
        当年个人购买总数：<asp:Label ID="lbGerenGoumai" runat="server" Text="0"></asp:Label><br />
        当年变动股权总数：<asp:Label ID="lbChangeSum" runat="server" Text="0"></asp:Label>&nbsp;&nbsp(本交易期结束，变动总数应为0才为平衡。)
    </p>
    股权交易期数：<asp:DropDownList ID="ddlIssueNumber" runat="server">
    </asp:DropDownList>
    <asp:Button ID="btnQuery" runat="server" Text="  查询  " />
    <asp:GridView ID="gvOwnershipChange" runat="server" AutoGenerateColumns="False"
        AllowSorting="True" DataSourceID="odsChange" EmptyDataText="查询结果为空" EnableTheming="True" OnDataBound="gvOwnershipChange_DataBound">
        <Columns>
            <asp:BoundField DataField="DepName" HeaderText="部门" SortExpression="DepName" />
            <asp:BoundField DataField="ShareholderNumber" HeaderText="股东号" SortExpression="ShareholderNumber">
                <ItemStyle Width="50px" />
            </asp:BoundField>
            <asp:BoundField DataField="ShareholderName" HeaderText="姓名" SortExpression="ShareholderName" />
            <asp:TemplateField HeaderText="性别">
                <ItemTemplate>
                    <asp:Label ID="lbSex" runat="server" Text='<%#Convert.ToBoolean(Eval("Sex")) ? "男" : "女" %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="20px" />
            </asp:TemplateField>
            <asp:BoundField DataField="PersonType" HeaderText="人员类别" SortExpression="PersonType" />
            <asp:BoundField DataField="QichuShares" DataFormatString="{0:N0}" HeaderText="期初持股" SortExpression="QichuShares"
                ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" />
            <asp:BoundField DataField="PeifaBonusShares" DataFormatString="{0:N2}" HeaderText="配发红股">
                <HeaderStyle HorizontalAlign="Right" />
                <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="TuiShares" DataFormatString="{0:N2}" HeaderText="退股" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" />
            <asp:BoundField DataField="ZhuanrangBonusShares" DataFormatString="{0:N2}" HeaderText="红股转让" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" />
            <asp:BoundField DataField="GerenGuomaiShares" HeaderText="个人购买" SortExpression="GerenGuomaiShares"
                DataFormatString="{0:N0}" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right">
                <ItemStyle HorizontalAlign="Right" Width="50px" />
            </asp:BoundField>
            <asp:BoundField DataField="ShareTotals" DataFormatString="{0:N2}" HeaderText="结余股权数">
                <HeaderStyle HorizontalAlign="Right" />
                <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="EntrustedAgentName" HeaderText="代理人" SortExpression="EntrustedAgentName" />
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="odsChange" runat="server" SelectMethod="GetShareOwnershipChange"
        TypeName="ShareOS.BLL.ShareOwnershipManage">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlIssueNumber" Name="issueNumber" PropertyName="SelectedValue"
                Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
