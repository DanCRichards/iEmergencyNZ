<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="SignIn.aspx.cs" Inherits="iEmergency.SignIn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Sign In - iEmergency NZ</h1>

    <asp:Label runat="server" ID="LblUsername" Text="Email"></asp:Label>
    <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control"></asp:TextBox>
    <br />
     
    <asp:Label runat="server" ID="LblPassword" Text="Password"></asp:Label>
    <asp:TextBox runat="server" CssClass="form-control" TextMode="Password" ID="txtPassword" ></asp:TextBox>
    <br /> 
    <asp:Button CssClass="btn btn-primary" runat="server" OnClick="SignIn_Click" ID="submit"  Text="Login"/>
</asp:Content>
