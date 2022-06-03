<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ResultView.aspx.cs" Inherits="StudentRecordSystem.WebForm10" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <form runat="server" class="border border-2 rounded-3 mt-5 p-3" style="width: 800px; margin: auto">
                <h3 class="display-3">Result Table</h3>
                <hr />
                <label class="form-label">Student Reg Id:</label>
                <input type="text" autocomplete="off" runat="server" id="StdRegId" class="col-md-2 rounded-2" />
                <label class="form-label">Course:</label>
                <asp:DropDownList CssClass="col-md-2 col-form-label rounded rounded-3 mt-3 mx-auto" runat="server" ID="DrpListId"></asp:DropDownList>
                <asp:Button runat="server" ID="SubmitBtn" CssClass="btn btn-outline-danger mb-1" OnClick="SubmitBtn_Click" Text="Search" />
                <table class="table table-hover table-bordered mt-3" id="tableId" runat="server">
                    <tr>
                        <th runat="server" id="th1"></th>
                        <th runat="server" id="th2"></th>
                        <th runat="server" id="th3"></th>
                        <th runat="server" id="th4"></th>
                        <th>Total</th>
                        <th>Percentage</th>
                        <th>Result</th>
                    </tr>
                    <tr runat="server" id="trId">
                        <td class="remove" runat="server" id="td1"></td>
                        <td class="remove" runat="server" id="td2"></td>
                        <td class="remove" runat="server" id="td3"></td>
                        <td class="remove" runat="server" id="td4"></td>
                        <td class="remove" runat="server" id="td5"></td>
                        <td class="remove" runat="server" id="td6"></td>
                        <td class="remove" runat="server" id="td7"></td>
                    </tr>
                </table>
            </form>
        </div>
    </div>
</asp:Content>
