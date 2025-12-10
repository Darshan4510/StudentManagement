<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddStudent.aspx.cs" Inherits="StudentManagement.AddStudent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container mt-4">
        <h3 class="mt-4">Add/Edit Student</h3>
        <div class="card shadow p-4">
            <div class="mb-3">
                <label class="form-label">Name</label>
                <asp:TextBox ID ="txtName" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
            <div class="mb-3">
                <label class="form-label">Email</label>
                <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class ="mb-3">
                <label class="form-label" >Mobile</label>
                <asp:TextBox ID="txtMobile" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class ="mb-3">
                <label class="form-label">City</label>
                <asp:TextBox ID="txtCity" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <asp:Button ID="btnSave" Text="Save Student" CssClass="btn btn-primary" runat="server" OnClick="btnSave_Click"/>
            <asp:Button ID="btnUpdate" runat="server" Text="Update Student" CssClass="btn btn-success ms-2" Visible="false" OnClick="btnUpdate_Click" />
            </div>

    </div>
</asp:Content>
