<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="feedback.aspx.cs" Inherits="HotelManagement.feedback1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <body id="feedback">
        </body>

        <div align="center" id="b2" style="font-size:100%;">
            <p>&nbsp;</p>
						<table border="1" width="350" cellspacing="1" style="border-collapse: collapse" bordercolor="#666666" id="table2">
							<tr >
								<td class="td2">Please provide your feedback below:</td>
							</tr>
							<tr>
								<td style="padding-left: 10px; padding-top: 10px">
								<table border="0" width="100%" cellpadding="3" id="table3" cellspacing="3">
									<tr>
										<td width="100" class="td1" align="left">Your Name:</td>
										<td align="left">&nbsp;<asp:TextBox ID="TextBox1" runat="server" Width="180px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Fill Client Id" ControlToValidate="TextBox1" ValidationGroup="Group1" ForeColor="Red"></asp:RequiredFieldValidator>
										</td>
									</tr>
									<tr>
										<td width="100" class="td1" align="left">Email Address:</td>
										<td align="left">&nbsp;<asp:TextBox ID="TextBox2" runat="server" Width="180px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Email is Required" ControlToValidate="TextBox2" ValidationGroup="Group1" ForeColor="Red"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                                            ControlToValidate="TextBox2" ErrorMessage="Properd Email Please!" 
                                                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="Group1" ForeColor="Red"></asp:RegularExpressionValidator>
										</td>
									</tr>
                                    <tr>
										<td width="100" class="td1" align="left">Mobile Number:</td>
										<td align="left">&nbsp;<asp:TextBox ID="TextBox3" runat="server" Width="180px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Mobile number is Required" ControlToValidate="TextBox3" ValidationGroup="Group1" ForeColor="Red"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"  
                                            ControlToValidate="TextBox3" ErrorMessage="Mobile Number not Valid"  
                                            ValidationExpression="[0-9]{10}" ValidationGroup="Group1" ForeColor="Red"></asp:RegularExpressionValidator>
										</td>
									</tr>
                                    <tr>
										<td width="100" class="td1" align="left">Comments:</td>
										<td align="left">&nbsp;<asp:TextBox ID="TextBox4" runat="server" Height="100px" Width="200px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Fill Comments" ControlToValidate="TextBox4" ValidationGroup="Group1" ForeColor="Red"></asp:RequiredFieldValidator>
										</td>
									</tr>
									<tr>
										
										<td align="center" colspan="2">
                                            <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" ValidationGroup="Group1" BackColor="#66CCFF" ForeColor="Black"/>
                                            <br />
                                            <asp:Label ID="Label1" runat="server" Text="Label" Font-Bold="True" ForeColor="Red" Visible="False"></asp:Label>
                                        </td>
									</tr>
								</table>
                                    </td>
                                </tr>
                            </table>
								</div>
    
</asp:Content>
