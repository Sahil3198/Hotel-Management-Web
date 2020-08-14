<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="showuser.aspx.cs" Inherits="HotelManagement.showuser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="topnav1">
        <ul id="nav1">

            <li><asp:LinkButton ID="LinkButton1" runat="server" style=" text-decoration: none;" Font-Bold="True" ForeColor="White" OnClick="LinkButton1_Click">BOOKING HISTROY</asp:LinkButton></li>
            <li><asp:LinkButton ID="LinkButton2" runat="server" style=" text-decoration: none;" Font-Bold="True" ForeColor="White" OnClick="LinkButton2_Click">CANCELLATION</asp:LinkButton></li>
            <li><asp:LinkButton ID="LinkButton3" runat="server" style=" text-decoration: none;" Font-Bold="True" ForeColor="White" OnClick="LinkButton3_Click">SHOW PROFILE</asp:LinkButton></li>
            <li><asp:LinkButton ID="LinkButton4" runat="server" style=" text-decoration: none;" Font-Bold="True" ForeColor="White" OnClick="LinkButton4_Click">CHANGE PASSWORD</asp:LinkButton></li>
         </ul> 
     </div>
    <div>
        <asp:Panel ID="Panel1" runat="server" Visible="False">
            <div align="center" id="b2" style="font-size:100%;">
						<table border="1" width="350" cellspacing="1" style="border-collapse: collapse" bordercolor="#666666" id="table2">
							<tr >
								<td class="td2">Your Booking History</td>
							</tr>
							<tr>
								<td style="padding-left: 10px; padding-top: 10px">
								<table border="0" width="100%" cellpadding="3" id="table3" cellspacing="3">
                                    <asp:GridView ID="GridView1" runat="server"></asp:GridView>
								</table>
                                    </td>
                                </tr>
                            </table>
								</div>

        </asp:Panel>
        <asp:Panel ID="Panel2" runat="server" Visible="False">
            <div align="center" id="b2" style="font-size:100%;">
						<table border="1" width="350" cellspacing="1" style="border-collapse: collapse" bordercolor="#666666" id="table2">
							<tr >
								<td class="td2">Change Your Password</td>
							</tr>
							<tr>
								<td style="padding-left: 10px; padding-top: 10px">
								<table border="0" width="100%" cellpadding="3" id="table3" cellspacing="3">
									<tr>
										<td width="100" class="td1" align="left">Client ID:</td>
										<td align="left"><asp:Label ID="Label2" runat="server" Text="Label"></asp:Label></td>
									</tr>
									<tr>
										<td width="100" class="td1" align="left">Current Password:</td>
										<td align="left"><asp:TextBox ID="TextBox6" runat="server" TextMode="Password" Width="180px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Fill Old Password" ControlToValidate="TextBox6" ValidationGroup="Group1"></asp:RequiredFieldValidator></td>
									</tr>
                                    <tr>
										<td width="100" class="td1" align="left">New Password:</td>
										<td align="left"><asp:TextBox ID="TextBox7" runat="server" TextMode="Password" Width="180px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Fill New Password" ControlToValidate="TextBox7" ValidationGroup="Group1"></asp:RequiredFieldValidator></td>
									</tr>
                                    <tr>
										<td width="100" class="td1" align="left">Confirm Password:</td>
										<td align="left"><asp:TextBox ID="TextBox5" runat="server" TextMode="Password" Width="180px"></asp:TextBox><asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Password not match" controltovalidate="TextBox5" controltocompare="TextBox7" ValidationGroup="Group1"></asp:CompareValidator></td>
									</tr>
									<tr>
										
										<td align="center" colspan="2">
                                            <asp:Button ID="Button2" runat="server" Text="Submit" OnClick="Button2_Click" ValidationGroup="Group1" BackColor="#66CCFF" Font-Bold="True" ForeColor="Black"/>&nbsp;</td>
									</tr>
								</table>
                                    </td>
                                </tr>
                            </table>
								</div>

        </asp:Panel>
        <asp:Panel ID="Panel3" runat="server" Visible="False">
            <div align="center" id="b2" style="font-size:100%;">
						<table border="1" width="350" cellspacing="1" style="border-collapse: collapse" bordercolor="#666666" id="table2">
							<tr >
								<td class="td2">Cancellation of Hotel Booking</td>
							</tr>
							<tr>
								<td style="padding-left: 10px; padding-top: 10px">
								<table border="0" width="100%" cellpadding="3" id="table3" cellspacing="3">
									<tr>
										<td width="100" class="td1" align="left">Client ID:</td>
										<td align="left"><asp:Label ID="Label3" runat="server" Text="Label"></asp:Label></td>
									</tr>
									<tr>
										<td width="100" class="td1" align="left">Enter Your Booking Id:</td>
										<td align="left">&nbsp;<asp:TextBox ID="TextBox1" runat="server" Width="180px"></asp:TextBox></td>
									</tr>
									<tr>
										<td align="center" colspan="2">
                                            <asp:Button ID="Button1" runat="server" Text="Delete" OnClick="Button1_Click" BackColor="#66CCFF" Font-Bold="True" ForeColor="Black" />&nbsp;</td>
									</tr>
								</table>
                                    </td>
                                </tr>
                            </table>
								</div>

        </asp:Panel>
        <asp:Panel ID="Panel4" runat="server" Visible="False">
            <div align="center" id="b2" style="font-size:100%;">
						<table border="1" width="350" cellspacing="1" style="border-collapse: collapse" bordercolor="#666666" id="table2">
							<tr >
								<td class="td2">Your Profile</td>
							</tr>
							<tr>
								<td style="padding-left: 10px; padding-top: 10px">
								<table border="0" width="100%" cellpadding="3" id="table3" cellspacing="3">
									<tr>
										<td width="100" class="td1" align="left">Client Id:</td>
										<td align="left"><asp:Label ID="Label5" runat="server" Text="Label"></asp:Label></td>
									</tr>
                                    <tr>
										<td width="100" class="td1" align="left">First Name:</td>
										<td align="left"><asp:Label ID="Label6" runat="server" Text="Label"></asp:Label></td>
									</tr>
                                    <tr>
										<td width="100" class="td1" align="left">Last Name:</td>
										<td align="left"><asp:Label ID="Label7" runat="server" Text="Label"></asp:Label></td>
									</tr>
                                    <tr>
										<td width="100" class="td1" align="left">Email ID:</td>
										<td align="left"><asp:Label ID="Label8" runat="server" Text="Label"></asp:Label></td>
									</tr>
                                    <tr>
										<td width="100" class="td1" align="left">Mobile No:</td>
										<td align="left"><asp:Label ID="Label9" runat="server" Text="Label"></asp:Label></td>
									</tr>
								</table>
                                    </td>
                                </tr>
                            </table>
								</div>

        </asp:Panel>
    </div>
</asp:Content>
