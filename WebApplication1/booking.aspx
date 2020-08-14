<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="booking.aspx.cs" Inherits="HotelManagement.booking" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
    table,td,th,tr{
       font-size:15px;
      color:white;
    }
</style>
<body>

    </body>
    <p>&nbsp;</p>
    <div align="center">
						<asp:Label ID="Label5" runat="server" Text="Label" Font-Bold="True" Font-Size="Larger" ForeColor="White" Visible="False"></asp:Label>
						<table border="0" width="350" cellspacing="1" style="border-collapse: collapse" bordercolor="#666666" id="table2">
							<tr>
								<td class="td2">&nbsp;Booking Hotal</td>
							</tr>
							<tr>
								<td style="padding-left: 10px; padding-top: 10px">
								<table border="0" width="100%" cellpadding="3" id="table3" cellspacing="3">
									<tr>
										<td width="100" class="td1" align="left">Select Hotel:<br /></td>
										<td align="left"><br /><asp:DropDownList ID="DropDownList1" runat="server" Height="25px" Width="179px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                            <asp:ListItem></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Hotel Must Select" ControlToValidate="DropDownList1" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                        </td>
									    
									</tr>
                                    <tr>
										<td width="100" class="td1" align="left">Room Type:</td>
										<td align="left"><br /><asp:DropDownList ID="DropDownList2" runat="server" Height="25px" Width="179px" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" AutoPostBack="True">
                                            <asp:ListItem></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Room Type Must Select" ControlToValidate="DropDownList2" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                        </td>
									</tr>
                                     <tr>
										<td width="100" class="td1" align="left">Room Price:</td>
										<td style="margin-left: 40px">
                                            <asp:Label ID="Label1" runat="server" Text="Price" Font-Bold="True" Font-Size="Larger" ForeColor="Black"></asp:Label>
                                            <br />
                                            </td>
									</tr>
                                    <tr>
										<td width="100" class="td1" align="left">Checked In:</td>
										<td align="left"><br /><asp:TextBox ID="TextBox1" runat="server" Width="165px"></asp:TextBox><asp:ImageButton ID="ImageButton1" runat="server" Height="17px" ImageUrl="~/images/drop-down-arrow_318-76747.jpg" OnClick="ImageButton1_Click" Width="26px" />
                                            <br /><asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged" ondayrender="Calendar1_DayRender"></asp:Calendar>
                                            <asp:CustomValidator id="CustomValidator2" runat="server" ErrorMessage="Please Select Check In Date" OnServerValidate="CustomValidator2_ServerValidate" ValidationGroup="Group1"></asp:CustomValidator>
                                        </td>
									</tr>
                                     <tr>
										<td width="100" class="td1" align="left">Checked Out:</td>
										<td align="left"><br /><asp:TextBox ID="TextBox2" runat="server" Width="165px"></asp:TextBox><asp:ImageButton ID="ImageButton2" runat="server" Height="16px" ImageUrl="~/images/drop-down-arrow_318-76747.jpg" OnClick="ImageButton2_Click" Width="25px" />
                                            <br /><asp:Calendar ID="Calendar2" runat="server" OnSelectionChanged="Calendar2_SelectionChanged" ondayrender="Calendar2_DayRender"></asp:Calendar>
                                            <asp:CustomValidator id="CustomValidator3" runat="server" ErrorMessage="Please Select Check Out Date" OnServerValidate="CustomValidator3_ServerValidate" ValidationGroup="Group1"></asp:CustomValidator>
                                        </td>
									</tr>
                                    <tr>
										<td width="100" class="td1" align="left">Check Rooms Availability:</td>
										<td style="margin-left: 40px">
                                            <asp:Label ID="Label2" runat="server" Text="Rooms Available" Font-Bold="True" Font-Size="Larger" ForeColor="Black"></asp:Label>
                                            <br />
                                            </td>
                                             
									</tr>
                                    <tr>
										<td width="100" class="td1" align="left">Rooms:</td>
										<td align="left"><br /><asp:DropDownList ID="DropDownList3" runat="server" Height="25px" Width="89px" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged">
                                            <asp:ListItem></asp:ListItem>
                                            <asp:ListItem>1</asp:ListItem>
                                            <asp:ListItem>2</asp:ListItem>
                                            <asp:ListItem>3</asp:ListItem>
                                            <asp:ListItem>4</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:Label ID="Label4" runat="server" Text="Please Select Rooms in Available rooms" Visible="False"></asp:Label>
                                            <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Please Select rooms" ControlToValidate="DropDownList3" OnServerValidate="CustomValidator1_ServerValidate1" ValidationGroup="Group1"></asp:CustomValidator>
                                            
                                        </td>
									</tr>
									<tr>
									
										<td align="center" colspan="2">
                                                            <asp:Button ID="Button1" runat="server" Text="Book Now" OnClick="Button1_Click" BackColor="#66CCFF" BorderColor="Black" BorderStyle="Solid" ValidationGroup="Group1" Height="41px" Width="89px" />&nbsp;<asp:Label ID="Label3" runat="server" Text="Error" Visible="False"></asp:Label>
                                        </td>
									</tr>
								</table>
                                    </table>
								</div>
</asp:Content>
