<%@ Page Language="C#" AutoEventWireup="true" CodeFile="change_password.aspx.cs" Inherits="change_password" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <table style="border:1px solid black; background-color:Black">
        <tr>
            <td><span style="color: #FF0000; font-weight: bold; text-decoration: underline;">
                Change Password</span></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td><asp:Label ID="Label2" runat="server" Font-Bold="true" Text="Email Id: "></asp:Label></td>
        </tr>
        <tr>
            <td><asp:Label ID="lblmail" runat="server" Font-Bold="true" Text=""></asp:Label></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td><asp:Label ID="Label3" runat="server" Font-Bold="true" Text="Enter New Password: "></asp:Label></td>
        </tr>
        <tr>
            <td><asp:TextBox TextMode="Password" runat="server" ID="txtpass" Font-Bold="true"></asp:TextBox>
                <span style="color: #FF0000">*</span>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Password doesn't match" ControlToCompare="txtpass" ControlToValidate="txtcpass"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td><asp:Label ID="Label4" runat="server" Font-Bold="true" Text="Confirm Password: "></asp:Label></td>
        </tr>
        <tr>
            <td><asp:TextBox TextMode="Password" runat="server" ID="txtcpass" Font-Bold="true"></asp:TextBox>
                <span style="color: #FF0000">*</span></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <th><asp:Button runat="server" ID="bntchange" Text="Change Password" 
                    onclick="bntchange_Click" /></th>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td><asp:Label ID="lblchangesuccess" runat="server" Font-Bold="true" ForeColor="Green"></asp:Label></td>
        </tr>
    </table>
    </form>
</body>
</html>
