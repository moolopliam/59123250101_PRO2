<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormMovie.aspx.cs" Inherits="Cinema.Reports.WebFormMovie" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:DropDownList ID="DropDownList1" runat="server" Height="25px" Width="122px" DataSourceID="SqlDataSource1" DataTextField="S_NameStatus" DataValueField="S_NameStatus">
            </asp:DropDownList>
            <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:Cinema5927ConnectionString2 %>' SelectCommand="SELECT [S_NameStatus] FROM [Table_StatusMovie]"></asp:SqlDataSource>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:Button ID="Button1"  runat="server" OnClick="Button1_Click" Text="ค้นหา" />
          
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Height="1025px" Width="1082px">
            </rsweb:ReportViewer>
        </div>
    </form>
</body>
</html>
