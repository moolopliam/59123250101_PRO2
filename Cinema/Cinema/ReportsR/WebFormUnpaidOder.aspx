<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormUnpaidOder.aspx.cs" Inherits="Cinema.Reports.WebFormUnpaidOder" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:DropDownList ID="DropDownList1" runat="server" Height="16px" Width="135px" DataSourceID="SqlDataSource1" DataTextField="B_Name" DataValueField="B_Name">
        </asp:DropDownList>
        <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:Cinema5927ConnectionString %>' SelectCommand="SELECT [B_Name] FROM [Table_StatusBay]"></asp:SqlDataSource>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Height="1045px" Width="1031px">
        </rsweb:ReportViewer>
    </form>
</body>
</html>
