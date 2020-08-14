<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="payment.aspx.cs" Inherits="HotelManagement.payment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Payment</title>
    <link rel="stylesheet" type="text/css" href="mystyle.css">
</head>
<body>
    <form id="form1" runat="server">
        <div class="logo">
			<h1 style="text-align:center;"><a href="#">Hotel<span>Continental</span></a></h1>
            <p>&nbsp;</p>
					<p>&nbsp;</p><p>&nbsp;</p>
					<p>&nbsp;</p>
            
					<div align="center">
						<table border="1" width="350" cellspacing="1" style="border-collapse: collapse" bordercolor="#666666" id="table2">
							<tr>
								<td class="td2">&nbsp;Payment Portal</td>
							</tr>
							<tr>
								<td style="padding-left: 10px; padding-top: 10px">
								<table border="0" width="100%" cellpadding="3" id="table3" cellspacing="3">
                                    <tr>
										<td width="100" class="td1" align="left">Client Id:</td>
										<td align="left">&nbsp;<asp:Label ID="Label1" runat="server" Text="Label" Font-Bold="True" Font-Size="Larger" ForeColor="Red"></asp:Label></td>
									</tr>
									<tr>
										<td width="100" class="td1" align="left">Client Name:</td>
										<td align="left">&nbsp;<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
                                        
									</tr>
									<tr>
										<td width="100" class="td1" align="left">Email Id:</td>
										<td align="left">&nbsp;<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></asp:TextBox></td>
									</tr>
                                     <tr>
										<td width="100" class="td1" align="left">Total Amount:</td>
										<td align="left">&nbsp;<asp:Label ID="Label2" runat="server" Text="Total Amount" Font-Bold="True" Font-Size="Medium"></asp:Label></td>
									</tr>
									<tr>
										<td align="left" colspan="2">
                                            &nbsp;&nbsp;
                                            <asp:Button ID="payonline" runat="server" Text="Payment Online" OnClick="payonline_Click" BackColor="#66CCFF" Font-Bold="True" ForeColor="Black" Width="140px" Height="37px" />
                                            &nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:Button ID="cancel" runat="server" Text="Cancel Payment" OnClick="cancel_Click" BackColor="#66CCFF" Font-Bold="True" ForeColor="Black" Width="147px" Height="37px" />
                                            
                                        </td>
									</tr>
								</table>
								</div>

		</div>
    
    </form>
</body>
</html>
