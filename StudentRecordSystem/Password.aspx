<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Password.aspx.cs" Inherits="StudentRecordSystem.WebForm6" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form class="border border-3 mx-auto mt-5 p-3 rounded-3" style="width: 600px;" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-md-6">
                    <label class="form-label">Enter your Password:</label>
                    <input type="text" class="form-control" runat="server" id="PrevPassId" />
                    <label class="form-label">New Password:</label>
                    <input type="text" class="form-control" runat="server" id="NewPassId" />
                </div>
                <div>
                    <asp:Button runat="server" ID="PassBtnId" CssClass="btn btn-outline-danger mt-2" Text="Submit" OnClick="PassBtnId_Click" />
                </div>
            </div>
        </div>
    </form>
</asp:Content>
