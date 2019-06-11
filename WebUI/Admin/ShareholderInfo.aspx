<%@ Page Title="所有股东信息" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true"
    CodeFile="ShareholderInfo.aspx.cs" Inherits="Admin_ShareholderInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>
        所有股东信息</h1>
    <p>
        <div class="comments">
            以下所列人员全部为股东，非股东，或已退出股权人员已不在内。
        </div>
    </p>
    <p>
        当前股东总数：<asp:Label ID="lbSh" runat="server" Text=""></asp:Label>
        人。<br />
    </p>
    <asp:HiddenField ID="hfIssueNumber" runat="server" />
    <asp:GridView ID="GridView1" runat="server" DataSourceID="odsShareholders" AutoGenerateColumns="False"
        Width="625px" OnDataBound="GridView1_DataBound">
        <Columns>
            <asp:BoundField DataField="ShareholderNumber" HeaderText="股东号" SortExpression="ShareholderNumber" />
            <asp:BoundField DataField="JobNumber" SortExpression="JobNumber" HeaderText="工号" />
            <asp:BoundField DataField="ShareholderName" HeaderText="姓名" />
            <asp:TemplateField HeaderText="性别">
                <ItemTemplate>
                    <asp:Label ID="idSex" runat="server" Text='<%# Convert.ToBoolean(Eval("Sex"))? "男":"女" %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="PersonType" SortExpression="PersonType" HeaderText="人员类别" />
            <asp:BoundField DataField="IdentityCard" HeaderText="身份证号" />
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="odsShareholders" runat="server" SelectMethod="GetShareOwnershipReport"
        TypeName="ShareOS.BLL.ShareOwnershipManage">
        <SelectParameters>
            <asp:ControlParameter ControlID="hfIssueNumber" Name="issueNumber" 
                PropertyName="Value" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
