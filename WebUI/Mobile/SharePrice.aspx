<%@ Page Title="" Language="C#" MasterPageFile="~/Mobile/MasterPage.master" AutoEventWireup="true"
    CodeFile="SharePrice.aspx.cs" Inherits="Mobile_SharePrice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Chart ID="Chart1" runat="server" DataSourceID="odsShare" Width="600px">
        <Series>
            <asp:Series ChartType="Spline" Name="Series1" XValueMember="IssueYear" YValueMembers="SharePrice"
                YValuesPerPoint="4">
            </asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1">
            </asp:ChartArea>
        </ChartAreas>
        <Titles>
            <asp:Title Name="Title1" Text="镇海石化工业贸易有限责任公司股价曲线">
            </asp:Title>
        </Titles>
    </asp:Chart>
    <asp:ObjectDataSource ID="odsShare" runat="server" SelectMethod="SelectConfig" TypeName="ShareOS.BLL.SharesBonus">
    </asp:ObjectDataSource>
</asp:Content>
