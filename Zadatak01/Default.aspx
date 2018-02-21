<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Zadatak01.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 650px;
        }
        .auto-style2 {
            width: 200px;
        }
        .auto-style3 {
            width: 200px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">Države:</td>
                    <td class="auto-style3">Gradovi:</td>
                    <td>Grad:</td>
                </tr>
                <tr>
                    <td class="auto-style2" style="vertical-align: top">
                        <asp:DropDownList ID="ddlDrzave" runat="server" Width="150px" AutoPostBack="True" OnSelectedIndexChanged="ddlDrzave_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style3" style="vertical-align: top">
                        <asp:ListBox ID="lbGradovi" runat="server" Height="150px" Width="150px" AutoPostBack="True" OnSelectedIndexChanged="lbGradovi_SelectedIndexChanged"></asp:ListBox>
                    </td>
                    <td style="vertical-align: top">
                        <asp:TextBox ID="txtGrad" runat="server" Width="150px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Button ID="btnSaveToXML" runat="server" Text="Spremi XML" Width="100px" OnClick="btnSaveToXML_Click" />
                    </td>
                    <td class="auto-style3">
                        <asp:Button ID="btnDeleteGrad" runat="server" Text="Obriši grad" Width="100px" OnClick="btnDeleteGrad_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btnAddGrad" runat="server" Text="Dodaj grad" Width="100px" OnClick="btnAddGrad_Click" />
&nbsp;
                        <asp:Button ID="btnUpdateGrad" runat="server" Text="Uredi grad" Width="100px" OnClick="btnUpdateGrad_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <asp:Label ID="lblInfo" runat="server" Text="Label"></asp:Label>
    </form>
</body>
</html>
