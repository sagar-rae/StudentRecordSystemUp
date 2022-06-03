<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="RegisteredDetails.aspx.cs" Inherits="StudentRecordSystem.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <form class="border border-2 rounded-3 mt-5 p-3" style="width:1300px; margin:auto">
            <h3 class="display-3">Student Registration Table</h3><hr />
               
           <asp:Panel runat="server" ID="PanelId"></asp:Panel>
            </form>
        </div>
    </div>
</asp:Content>
