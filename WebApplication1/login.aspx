<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="hotelmanagement.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Page</title>
     <link rel="stylesheet" type="text/css" href="mystyle.css">
</head>
<body>
        <form id="form1" runat="server">
            <div>
                 <ul id="m1">
                <li><a href="homepage.aspx">Online Hotel Booking</a></li>
                <li style="float:right"><a class="active" href="signup.aspx">Sign Up</a></li>
            </ul>
        </div>
        <div class="logo">
			<h1 style="text-align:center;"><a href="homepage.aspx">Hotel<span>Continental</span></a></h1>
            <p>&nbsp;</p>
					<p>&nbsp;</p>
            
					<div align="center">
						<table border="1" width="350" cellspacing="1" style="border-collapse: collapse" bordercolor="#666666" id="table2">
							<tr>
								<td class="td2">&nbsp;Client Login</td>
							</tr>
							<tr>
								<td style="padding-left: 10px; padding-top: 10px">
								<table border="0" width="100%" cellpadding="3" id="table3" cellspacing="3">
									<tr>
										<td width="100" class="td1" align="left">Client UserId:</td>
										<td align="left"><br /><asp:TextBox ID="TxtLogin" runat="server" OnTextChanged="TxtLogin_TextChanged" ></asp:TextBox><br /><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Fill Client Id" ControlToValidate="TxtLogin" ValidationGroup="Group1"></asp:RequiredFieldValidator></td>
									</tr>
									<tr>
										<td width="100" class="td1" align="left">Password:</td>
										<td align="left"><br /><asp:TextBox ID="TxtPassword" runat="server" TextMode="Password" OnTextChanged="TxtPassword_TextChanged"></asp:TextBox><br /><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Fill Password" ControlToValidate="TxtPassword" ValidationGroup="Group1"></asp:RequiredFieldValidator></td>
									</tr>
									<tr>
										
										<td align="center" colspan="2">
                                            <asp:Button ID="BtnLogin" runat="server"  Text="Login" Width="66px" OnClick="BtnLogin_Click" BackColor="#66CCFF" Font-Bold="True" ForeColor="Black" ValidationGroup="Group1" Height="36px"/>&nbsp;&nbsp;&nbsp;<asp:Button ID="Button1" runat="server" Text="Forgot Password?" BackColor="#66CCFF" Font-Bold="True" ForeColor="Black" Height="36px" Width="130px" OnClick="Button1_Click" />
                                            <br /><asp:Label ID="lblMsg" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                                        </td>
									</tr>
								</table>
								</div>

		</div>
    
       
        </form>
    
</body>
</html>
