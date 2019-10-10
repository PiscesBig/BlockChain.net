<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="UserService.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="txt1" runat="server" Width="455px"></asp:TextBox>
        </div>
        <asp:TextBox ID="txt2" runat="server" Width="456px"></asp:TextBox>
        <p>
            <asp:Button ID="btn1" runat="server" OnClick="btn1_Click" Text="Button" />
        </p>
        <p>
            <asp:Label ID="lab1" runat="server" Text="Label"></asp:Label>
        </p>
    </form>
</body>
</html>
