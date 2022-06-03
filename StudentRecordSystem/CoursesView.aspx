<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="CoursesView.aspx.cs" Inherits="StudentRecordSystem.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
       
        //$(document).ready(function () {
        //    $('.delete_btn').on('click', function () {
        //        debugger;
        //    })
        //});
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <form class="border border-2 rounded-3 mt-5 p-3" style="width:500px; margin:auto">
            <h3 class="display-3" id="courseId">Courses</h3><hr />
            <asp:PlaceHolder runat="server" ID="PlaceholderCourse"></asp:PlaceHolder>
            </form>
        </div>
    </div>     
</asp:Content>
