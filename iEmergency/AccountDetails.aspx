<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AccountDetails.aspx.cs" Inherits="iEmergency.AccountDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-sm-12">
                <h1>Account Details - Daniel Richards</h1>

            </div>

            <div class="col-sm-7">
                <asp:Label Text="Name" runat="server"></asp:Label>
                <input type="text" id="txtName" class="form-control" Text="" required="required" runat="server" />


                <br />

                <asp:Label Text="Email" runat="server"></asp:Label>
                <input type="email" id="txtEmail" class="form-control" Text="" required="required" runat="server" />

                <br />

                <asp:Label Text="Disabilities" runat="server"></asp:Label>
                <input type="text" id="txtDisabilities" class="form-control" Text="" required="required" runat="server" />
            
                <br />

            <asp:Button ID="buttonSubmit" OnClick="buttonSubmit_Click" runat="server" Text="Update" CssClass="btn btn-primary" />
            </div>
            <div class="col-sm-5">

                <h3>Change your Emergency Contacts here</h3>
                <asp:Button ID="addRecord" OnClick="addRecord_Click" Text="Add Contact" runat="server" />
                <asp:GridView ID="GridView1" runat="server" OnRowEditing="GridView1_RowEditing" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnRowUpdating="GridView1_RowUpdating" AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2">
                    <Columns>
                        <asp:TemplateField HeaderText="Name">
                            <EditItemTemplate>
                                
                                <asp:TextBox ID="tbName" runat="server" Text='<%# Eval("name") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblID" runat="server" Text='<%# Eval("Id") %>' Visible="false"></asp:Label>
                                <asp:Label ID="txtContactName" runat="server" Text='<%# Eval("name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Email">
                            <EditItemTemplate>
                                <asp:TextBox ID="tbEmail" runat="server" Text='<%# Eval("email") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="txtContactEmail" runat="server" Text='<%# Eval("email") %>'></asp:Label>
                            </ItemTemplate>

                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Mobile">
                            <EditItemTemplate>
                                <asp:TextBox ID="tbMobile" runat="server" Text='<%# Eval("mobile") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="txtContactMobile" runat="server" Text='<%# Eval("mobile") %>'></asp:Label>
                            </ItemTemplate>

                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Relation To">
                            <EditItemTemplate>
                                <asp:TextBox ID="tbRelationTo" runat="server" Text='<%# Eval("relationTo") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="txtContactRelationTo" runat="server" Text='<%# Eval("relationTo") %>'></asp:Label>
                            </ItemTemplate></asp:TemplateField>


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

            </div>
        </div>
        <div class="row">
            <div class="col-sm-12"></div>
        </div>
    </div>
</asp:Content>
