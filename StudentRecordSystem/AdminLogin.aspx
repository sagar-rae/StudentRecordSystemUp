<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="StudentRecordSystem.AdminLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <!-- CSS only -->
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0-beta1/dist/css/bootstrap.min.css" rel="stylesheet"/>
    <script>
        function Check() {
            debugger;
            if (document.getElementById('NameId').value == '') {
                alert('Please Enter the Name');
                return false;
            }
            if (document.getElementById('PassId').value == '') {
                alert('Please Enter the Password');
                return false;
            }
            return true;
        }
    </script>
</head>
<body>
  
       
         <form id="form1" runat="server" style="width:400px; margin:auto" class="border border-2 p-5 mt-5 rounded-3"  >
          <h2 class="text-center display-3 border-1">Login</h2>   
          <input type="text" runat="server" id="NameId" placeholder="Enter Name" class="form-control" /><br />
          <input type="password" runat="server" id="PassId" placeholder="Enter Password" class="form-control"/>  
             <div>
               
             </div>
        <div>
            <asp:Button runat="server" Text="Login" CssClass="btn btn-outline-primary mt-3 w-100" OnClick="Login_ServerClick" OnClientClick="return Check();" />
        </div>
    </form>
        



</body>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0-beta1/dist/js/bootstrap.bundle.min.js"></script>
</html>
