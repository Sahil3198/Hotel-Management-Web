<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="hotels.aspx.cs" Inherits="HotelManagement.hotels" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #a{
            align-content:center;
            text-align:center;
            width: 500px;
            border: 5px solid blue;
            padding: 25px;
            margin: auto;  
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <body id="hotel">
        
    </body>
    <p>&nbsp;</p>
    <div id="a">
        <asp:Image ID="Image1" runat="server" Height="400px" ImageUrl="~/images/hotel.jpg" Width="500px" ImageAlign="Middle" />
        <h1>Our Hotel</h1>
    </div>
</asp:Content>
