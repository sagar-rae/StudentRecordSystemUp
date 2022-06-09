<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Result.aspx.cs" Inherits="StudentRecordSystem.WebForm9" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">     
      

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server" class="border border-2 mt-5 p-5" style="margin: auto; width: 600px">
        <h3 class="display-5">Add Result</h3>
        <hr />
        <div class="container">
            <div class="row">
                <div class="col-md-6">
                    <label class="form-label">Student Registration:</label>
                    <input type="text" runat="server" id="StdRegId" class="form-control" />
                    <label class="form-label">Course:</label>
                    <asp:DropDownList CssClass="col-md-4 col-form-label rounded rounded-3 mt-3" runat="server" ID="DrpListId"></asp:DropDownList>
                </div>
                <div>
                    <asp:Button runat="server" CssClass="btn btn-outline-danger mt-3" ID="clickbtn" Text="Search" OnClientClick="Check()" OnClick="Search_Click" />

                </div>
                <div class="container" runat="server" id="ShowSubject">
                    <hr />
                    <div class="row">
                        <div class="col-md-6">
                            <label class="form-label" id="Sub1Id" runat="server"></label>
                            <input type="text" runat="server" id="Sub1Box" class="form-control" />
                            <label class="form-label" id="Sub2Id" runat="server"></label>
                            <input type="text" runat="server" id="Sub2Box" class="form-control" />
                            <label class="form-label" id="Sub3Id" runat="server"></label>
                            <input type="text" runat="server" id="Sub3Box" class="form-control" />
                            <label class="form-label" id="Sub4Id" runat="server"></label>
                            <input type="text" runat="server" id="Sub4Box" class="form-control" />
                            <asp:Button runat="server" CssClass="btn btn-outline-danger mt-3" Text="Submit" OnClick="Submit_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
