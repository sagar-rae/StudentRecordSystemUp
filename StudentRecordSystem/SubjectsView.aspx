<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="SubjectsView.aspx.cs" Inherits="StudentRecordSystem.WebForm8" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <form runat="server" class="border border-2 mt-5 p-5" style="margin: auto; width: 800px">
        <h3 class="display-5">Add Subjects</h3>
        <hr />
        <div class="container">
            <div class="row">
                <div class="col-md-6">           
                    <label class="form-label">Course Name:</label>
                     <asp:DropDownList CssClass="col-md-4 col-form-label rounded rounded-3" runat="server" ID="DrpListId"></asp:DropDownList>
                </div>
                <div class="">
                    <asp:Button runat="server" CssClass="btn btn-outline-danger mt-3 " Text="Search" OnClick="Submit_Click" />
                </div>
                <asp:Panel runat="server" ID="PanelId"></asp:Panel>
            </div>
        </div>
    </form>
</asp:Content>
