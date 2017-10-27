<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="SignUp.aspx.cs" Inherits="iEmergency.SignUp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    
  
    <script src="Scripts/InitaliseLocationServices.js"></script>
    <div class="container">
        <div class="row">
            <div class="col-sm-4"></div>
                <h1> Sign Up - iEmergency NZ</h1>
            <div class="col-sm-4"></div>
        </div>
        <div class="row">
            <div class="form col-sm-6">
                    <div>
                        <h2>Sign Up</h2>
                        <div class="form-group">
                            <label for="textFullName">Full Name</label>
                            <input type="text" id="txtFullName" placeholder="Enter Full Name" class="form-control" required="required" runat="server"/>
                        </div>
                        <div class="form-group">
                            <label for="txtEmail">Email</label>
                            <input type="email" id="txtEmail" placeholder="Enter Email Address" class="form-control" required="required" runat="server"/>
                        </div>
                        <div class="form-group">
                            <label for="txtPassword">Password</label>
                            <input type="password" id="txtPassword" placeholder="Select secure password" class="form-control" required="required" runat="server"/>
                        </div>
                        <div class="form-group">
                            <%--<input type="submit" id="btnSignUp" value="Submit" class="btn btn-success" runat="server"/>--%>
                            <asp:Button ID="btnSignUp" Text="Submit" CssClass="btn btn-success" runat="server" OnClick="btnSignUp_Click"/>
                        </div>
                        <p>Existing User? <a href="Signin.aspx">Sign In!</a></p>
                    </div>
            </div>
            <div class="content col-sm-6">
                <h2>Insert Photo here:</h2>
                <p>
                    Photo button goes here maybe? 
                </p>
                
            </div>
        </div>
    </div>

 
</asp:Content>
