<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Zadatak02.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1" style="width: 660px">
                <tr>
                    <td style="width: 660px">Država:</td>
                    <td style="width: 660px">Grad:</td>
                    <td style="width: 660px">Naziv grada:</td>
                </tr>
                <tr>
                    <td style="width: 660px; vertical-align: top;">
                        <asp:ListBox ID="lbDrzave" runat="server" AutoPostBack="True" Height="160px" OnSelectedIndexChanged="lbDrzave_SelectedIndexChanged" Width="200px"></asp:ListBox>
                    </td>
                    <td style="width: 660px; vertical-align: top;">
                        <asp:ListBox ID="lbGradovi" runat="server" AutoPostBack="True" Height="160px" OnSelectedIndexChanged="lbGradovi_SelectedIndexChanged" Width="200px"></asp:ListBox>
                    </td>
                    <td style="width: 660px; vertical-align: top;">
                        <asp:TextBox ID="txtGrad" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 660px">
                        <asp:Button ID="btnSaveToXML" runat="server" OnClick="btnSaveToXML_Click" Text="Spremi XML" Width="100px" />
                    </td>
                    <td style="width: 660px">
                        <asp:Button ID="btnDeleteGrad" runat="server" OnClick="btnDeleteGrad_Click" Text="Obriši grad" Width="100px" />
                    </td>
                    <td style="width: 660px">
                        <asp:Button ID="btnInsertGrad" runat="server" OnClick="btnInsertGrad_Click" Text="Dodaj grad" Width="100px" />
&nbsp;
                        <asp:Button ID="btnUpdateGrad" runat="server" OnClick="btnUpdateGrad_Click" Text="Uredi grad" Width="100px" />
                    </td>
                </tr>
            </table>
            <br />
            <asp:Label ID="lblInfo" runat="server" ForeColor="Red"></asp:Label>
        </div>
    </form>
</body>
</html>
