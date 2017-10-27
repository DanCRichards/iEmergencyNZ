<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="IncidentList.aspx.cs" Inherits="iEmergency.Incidents" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <h1>Incident List</h1>
    <br />
    <asp:GridView ID="GridView1" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowDeleting="GridView1_RowDeleting" OnRowCancelingEdit="GridView1_RowCancelingEdit" CssClass="table table-hover table-striped" AutoGenerateColumns="false" runat="server" BackColor="#DEBA84" s BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2">
        <Columns>
            <asp:TemplateField HeaderText="Agency">
                <ItemTemplate>
                    <asp:Label ID="txtAgency" runat="server" Text='<%# Eval("agency") %>'></asp:Label>
                    <asp:Label ID="lblID" runat="server" Visible="false" Text='<%# Eval("Id") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Emergency Decision Path">
                <EditItemTemplate>
                    <asp:TextBox ID="editpath" runat="server" Text='<%# Eval("description") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="txtDecisionPath" runat="server" Text='<%# Eval("description") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Date Time">
                <ItemTemplate>
                    <asp:Label ID="txtTimeStamp" runat="server" Text='<%# Eval("dateTimeStamp") %>'></asp:Label>
                </ItemTemplate>

            </asp:TemplateField>


            <asp:TemplateField HeaderText="Status">
                <EditItemTemplate>

                    <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="statusValue" DataValueField="statusValue"></asp:DropDownList>
                     <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:iEmergency %>" SelectCommand="SELECT DISTINCT statusValue FROM incident"></asp:SqlDataSource>
                     </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="txtStatus" runat="server" Text='<%# Eval("statusValue") %>'></asp:Label>

                </ItemTemplate>
               

            </asp:TemplateField>

            <asp:TemplateField HeaderText="Location">
                <ItemTemplate>
                    <asp:Label ID="txtLocation" runat="server" Text='<%# Eval("locationDescription") %>'></asp:Label>
                </ItemTemplate>


            </asp:TemplateField>

            <asp:TemplateField HeaderText="Accuracy (m)">
                <ItemTemplate>
                    <asp:Label ID="txtAccuracy" runat="server" Text='<%# Eval("locationAccuracy") %>'></asp:Label>
                </ItemTemplate>

            </asp:TemplateField>

            <asp:CommandField HeaderText="Edit/Delete" ShowEditButton="true" ShowDeleteButton="true" DeleteText="Delete" />
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

</asp:Content>
