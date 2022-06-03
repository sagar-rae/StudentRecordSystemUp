<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Subjects.aspx.cs" Inherits="StudentRecordSystem.WebForm7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <form runat="server" class="border border-2 mt-5 p-5" style="margin: auto; width: 600px">
        <h3 class="display-5">Add Subjects</h3>
        <hr />
        <div class="container">
            <div class="row">
                <div class="col-md-6">           
                    <label class="form-label">Course Name:</label>
                     <asp:DropDownList CssClass="col-md-4 col-form-label rounded rounded-3" runat="server" ID="DrpListId"></asp:DropDownList>
                    <label class="form-label">Subject 1:</label>
                    <input type="text" runat="server" id="Subject1Id" class="form-control" />
                     <label class="form-label">Subject 2:</label>
                    <input type="text" runat="server" id="Subject2Id" class="form-control" />
                     <label class="form-label">Subject 3:</label>
                    <input type="text" runat="server" id="Subject3Id" class="form-control" />
                     <label class="form-label">Subject 4:</label>
                    <input type="text" runat="server" id="Subject4Id" class="form-control" />

                </div>
                <div class="">
                    <asp:Button runat="server" CssClass="btn btn-outline-danger mt-3 " Text="Insert" OnClick="Submit_Click" />
                </div>
            </div>
        </div>
    </form>
</asp:Content>
