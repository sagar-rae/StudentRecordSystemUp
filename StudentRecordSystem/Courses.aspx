<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Courses.aspx.cs" Inherits="StudentRecordSystem.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server" class="border border-2 mt-5 p-5" style="margin: auto; width: 600px">
        <h3 class="display-5">Add Course</h3>
        <hr />
        <div class="container">
            <div class="row">
                <div class="col-md-6">
                 <%--   <label class="form-label">Course Id:</label>
                    <input type="text" runat="server" id="CourseId" class="form-control" />--%>
                    <label class="form-label">Course Name:</label>
                    <input type="text" runat="server" id="CourseNameId" class="form-control" />
                   <%-- <label class="form-label">Course Full Name:</label>
                    <input type="text" runat="server" id="CourseFNId" class="form-control" />--%>
                </div>
                <div class="">
                    <asp:Button runat="server" CssClass="btn btn-outline-danger mt-3 " Text="Insert" OnClick="CourseSubmit_Click" />
                </div>
            </div>
        </div>
    </form>
</asp:Content>
