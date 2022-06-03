using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace StudentRecordSystem
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["MGMTDB"].ConnectionString;
       
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login_ServerClick(object sender, EventArgs e)
        {

            Session["user"] = NameId.Value;
            SqlConnection con = null;
            try
            {
                using (con = new SqlConnection(strcon))
                {
                    SqlCommand cmd = new SqlCommand("MGMTSP", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Flag", "AdminCheck");
                    cmd.Parameters.AddWithValue("@AName", NameId.Value);
                    cmd.Parameters.AddWithValue("@Pass", PassId.Value);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if(dr.HasRows)
                    {
                        Response.Redirect("Registration.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('Incorrect Username or Password.')</script>");
                    }

                }                
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('"+ex.Message+"')</script>");
            }
            finally
            {
                con.Close();
            }



        }
    }
}