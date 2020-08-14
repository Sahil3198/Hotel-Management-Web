<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="signup.aspx.cs" Inherits="HotelManagement.signup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Sign Up Page</title>
    <link rel="stylesheet" type="text/css" href="mystyle.css"/>
</head>
<body id="signup">
    <form id="form1" runat="server">
        <div>
                 <ul id="m1">
                <li><a href="homepage.aspx">Online Hotel Booking</a></li>
                <li style="float:right"><a class="active" href="login.aspx">Login</a></li>
            </ul>
        </div>
        <div class="logo">
			<h1 style="text-align:center;"><a href="homepage.aspx">Hotel<span>Continental</span></a></h1>           
					<div align="center">
						<table border="1" width="350" cellspacing="1" style="border-collapse: collapse" bordercolor="#666666" id="table2">
							<tr>
								<td class="td2">&nbsp;Sign Up</td>
							</tr>
							<tr>
								<td style="padding-left: 10px; padding-top: 10px">
								<table style="color:white;font-weight: bold;font-size: 120%;" border="0" width="100%" cellpadding="3" cellspacing="3">
									<tr>
										<td width="100" align="left">Client UserId:</td>
										<td align="left"><br /><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br /><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Fill Client Id" ControlToValidate="TextBox1" ValidationGroup="Group1"></asp:RequiredFieldValidator></td>
									</tr>
                                    <tr>
										<td width="100" align="left">First Name:</td>
										<td align="left"><br /><asp:TextBox ID="TextBox3" runat="server"></asp:TextBox><br /><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Fill First Name" ControlToValidate="TextBox3" ValidationGroup="Group1"></asp:RequiredFieldValidator></td>
									</tr>
                                    <tr>
										<td width="100" align="left">Last Name:</td>
										<td align="left"><br /><asp:TextBox ID="TextBox4" runat="server"></asp:TextBox><br /><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please Fill Last Name" ControlToValidate="TextBox4" ValidationGroup="Group1"></asp:RequiredFieldValidator></td>
									</tr>
                                    <tr>
										<td width="100" align="left">Email ID:</td>
										<td align="left"><br /><asp:TextBox ID="TextBox6" runat="server"></asp:TextBox><br /><asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                                            ControlToValidate="TextBox6" ErrorMessage="Properd Email Please!" 
                                                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="Group1"></asp:RegularExpressionValidator></td>
									</tr>
                                    <tr>
										<td width="100" align="left">Mobile No:</td>
										<td align="left"><br /><asp:TextBox ID="TextBox7" runat="server"></asp:TextBox><br /><asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"  
                                            ControlToValidate="TextBox7" ErrorMessage="RegularExpressionValidator"  
                                            ValidationExpression="[0-9]{10}" ValidationGroup="Group1"></asp:RegularExpressionValidator > </td>
									</tr>
									<tr>
										<td width="100" align="left">Password:</td>
										<td align="left"><br /><asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox><br /><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please Fill Password" ControlToValidate="TextBox2" ValidationGroup="Group1"></asp:RequiredFieldValidator></td>
									</tr>
                                    <tr>
										<td width="100" align="left">Confirm Password:</td>
										<td align="left"><br /><asp:TextBox ID="TextBox5" runat="server" TextMode="Password"></asp:TextBox><br /><asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="CompareValidator" controltovalidate="TextBox5" controltocompare="TextBox2" ValidationGroup="Group1"></asp:CompareValidator></td>
									</tr>
									<tr>
										
										<td align="center" colspan="2">
                                            <asp:Button ID="Button1" runat="server" Text="Done" ValidationGroup="Group1" BackColor="#66CCFF" Font-Bold="True" ForeColor="Black" OnClick="Button1_Click" Height="32px" Width="63px"/>
                                            <br />
                                            <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
                                        </td>
									</tr>
								</table>
								</div>

		</div>
    </form>
</body>
</html>
