<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmergencyCall.aspx.cs" Inherits="iEmergency.EmergencyCall" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   
    <script src="\Scripts/Location.js"></script>
    <div class="container">
    <div class="row">
        <div class="col-sm-12 text-center">
            <h1><%= Agency %> Emergency Call</h1>
           
               <br />


        </div>
        <div class="col-sm-6">

            

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">

          
           <ContentTemplate>
            <asp:GridView ID="gvCallData" OnRowCommand="gvCallData_RowCommand" CssClass="table table-hover table-striped" runat="server" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" AutoGenerateColumns="false">
                <Columns>
                    <asp:TemplateField HeaderText="Title">
                        <ItemTemplate>
                            <asp:HiddenField ID="nodeID" value='<%# Eval("Id") %>' runat="server"/> 
                            <asp:Label ID="nodeTitle" runat="server" Text='<%# Eval("title") %>'></asp:Label>
                            <asp:Button ID="typeSelect" runat="server" CommandName="Select" CommandArgument='<%# Eval("Id") %>' Text='<%# (Eval("branchEnd").ToString()=="1" ? "Select as Emergency Type":"Search") %>'/>
                            <asp:HiddenField ID="branchEnd" value='<%# Eval("branchEnd") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#FFF1D4" />
                <SortedAscendingHeaderStyle BackColor="#B95C30" />
                <SortedDescendingCellStyle BackColor="#F1E5CE" />
                <SortedDescendingHeaderStyle BackColor="#93451F" />
            </asp:GridView>


                </ContentTemplate>
                  </asp:UpdatePanel>
            <asp:HiddenField runat="server" ID="txtTime" />

        </div>
        <div class="col-sm-6">
            
           
            <div id="map" style="width:400px;height:400px;background:yellow" onload="getLocation();"></div>
            <asp:HiddenField  ID="latitudeHDN" runat="server" />
            <asp:HiddenField ID="longitudeHDN" runat="server" />
            <asp:HiddenField ID ="accuracyHDN" runat="server" />
            <asp:HiddenField ID="locationDescriptionHDN" runat="server" />
            <asp:HiddenField ID="CurrentNode" runat="server" />
            
        </div>
        <div class="col-sm-12">

            <asp:Button ID="submit" OnClick="submit_Click" Text="Submit" runat="server" />
            
        </div>
    </div>
</div>
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyDH9ApsBkq7lNmLFxNEYfS0Uz1_Nogppwc&callback=getLocation"></script>

</asp:Content>
