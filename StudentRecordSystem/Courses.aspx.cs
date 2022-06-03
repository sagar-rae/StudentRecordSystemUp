using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace StudentRecordSystem
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["MGMTDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CourseSubmit_Click(object sender, EventArgs e)
        {
            SqlConnection con = null;
            try
            {
                using(con=new SqlConnection(strcon))
                {
                    con.Open();
                    SqlCommand comm = new SqlCommand("MGMTSP",con);
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.Parameters.AddWithValue("@Flag","CourseInsert");
                    comm.Parameters.AddWithValue("@AName",CourseNameId.Value);
                    int check = comm.ExecuteNonQuery();
                    if(check>0)
                    {
                        Response.Write("<script>alert('Successfully inserted.')</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('Error.')</script>");
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