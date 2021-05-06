<%@ Page Title="同步股东部门信息" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="SyncDepName.aspx.cs" Inherits="Admin_SyncDepName" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <h1>同步股东部门信息</h1>
    <div style="padding: 20px; border: 1px solid #696969; margin: 10px 0;">
        <div style="font-size: 1.3em; font-weight: bold;">
            说明
        </div>
        股权管理系统独立存储股东的部门信息，通过本页面的同步功能，可使每位股东的部门信息可与浪潮HCM企业端中间库同步。<br />
        本同步功能仅同步每位员工的部门信息，其它信息不作更新。
    </div>
    <div>
        <div style="margin: 20px 0 0 0;">
            同步过程需 10 - 20 秒，请耐心等候。同步完成后会显示同步报告。<br />
        </div>
        <asp:Panel ID="Panel1" runat="server">
            <asp:Button ID="btnSync" runat="server" Text="点击按钮开始同步" OnClick="btnSync_Click" />
            <asp:Label ID="lbSyncResult" runat="server" Text="部门信息同步完毕！" ForeColor="Green" Font-Size="1.2em" Visible="False"></asp:Label><br />
            <br />
            <asp:Label ID="lbImportRowCount" runat="server" Text="" Visible="false"></asp:Label>
        </asp:Panel>
    </div>
</asp:Content>

