<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ViewStudents.aspx.cs" Inherits="StudentManagement.ViewStudents" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container mt-4">

        <h3 class="mb-4">Student List</h3>

        <asp:GridView ID="GridView1" runat="server"
            CssClass="table table-bordered table-striped"
            AutoGenerateColumns="False"
            DataKeyNames="StudentId"
            OnRowCommand="GridView1_RowCommand">

            <Columns>

          
                <asp:BoundField DataField="StudentId" HeaderText="ID" ReadOnly="True" />

              
                <asp:BoundField DataField="Name" HeaderText="Name" />

               
                <asp:BoundField DataField="Email" HeaderText="Email" />

              
                <asp:BoundField DataField="Mobile" HeaderText="Mobile" />

              
                <asp:BoundField DataField="City" HeaderText="City" />

          
                <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>

                      
                        <asp:LinkButton ID="lnkEdit" runat="server"
                            Text="Edit"
                            CssClass="btn btn-sm btn-primary me-2"
                            CommandName="EditStudent"
                            CommandArgument='<%# Eval("StudentId") %>'>
                        </asp:LinkButton>

                      
                        <asp:LinkButton ID="lnkDelete" runat="server"
                            Text="Delete"
                            CssClass="btn btn-sm btn-danger"
                            CommandName="DeleteStudent"
                            CommandArgument='<%# Eval("StudentId") %>'
                            OnClientClick="return confirm('Are you sure you want to delete this student?');">
                        </asp:LinkButton>

                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>

        </asp:GridView>

    </div>

</asp:Content>