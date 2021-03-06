﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrintBSLogReport_PrintView.aspx.cs" Inherits="Admin_Trade_PrintBSLogReport_PrintView" EnableTheming="false" Theme="" StylesheetTheme="" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>打印股权变动表</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:HiddenField ID="hfShareholderNumbers" runat="server" Value="" />
        <rsweb:ReportViewer ID="reportPrinter" runat="server" Font-Names="Verdana" Font-Size="8pt" Height="800px" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="100%">
            <LocalReport ReportPath="RDLCFile\PersonSharesChangeMain.rdlc" OnSubreportProcessing="ReportViewer1_SubreportProcessing">
            </LocalReport>
        </rsweb:ReportViewer>
    </form>
</body>
</html>
