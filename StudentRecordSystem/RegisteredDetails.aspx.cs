using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace StudentRecordSystem
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["MGMTDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

            
            StringBuilder table = new StringBuilder();

            SqlConnection con = null;
            try
            {
                using(con=new SqlConnection(strcon))
                {
                    con.Open();
                    SqlCommand comm = new SqlCommand("MGMTSP",con);
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.Parameters.AddWithValue("@Flag","Select");
                    SqlDataReader dr = comm.ExecuteReader();
                    table.Append("<table class='table table-hover table-bordered'>");
                    table.Append("<tr><th>StudentReg.Id</th><th>Full Name</th><th>Phone Number</th><th>Email</th><th>Address</th>");
                    table.Append("<th>Date of Birth</th><th>Father's Name</th><th>Mother's Name</th><th>Course Name</th><th>Image</th></tr>");
                  if(dr.HasRows)
                    {
                        while(dr.Read())
                        {
                            table.Append("<tr>");
                            table.Append("<td>" + dr[1] + "</td>");
                            table.Append("<td>" + dr[2] + "</td>");
                            table.Append("<td>" + dr[3] + "</td>");
                            table.Append("<td>" + dr[4] + "</td>");
                            table.Append("<td>" + dr[5] + "</td>");
                            table.Append("<td>" + dr[6] + "</td>");
                            table.Append("<td>" + dr[7] + "</td>");
                            table.Append("<td>" + dr[8] + "</td>");
                            table.Append("<td>" + dr[9] + "</td>");
                            table.Append("<td><img src='"+dr[10]+"' style='width:50px;height:40px'/></td>");
                            table.Append("</tr>");
                        }
                    }
                    table.Append("</table>");
                    PanelId.Controls.Add(new Literal { Text=table.ToString()});
                    dr.Close();
                }
            }
            catch(Exception ex)
            {
                Response.Write("<script>'" + ex.Message + "'</script>");
            }
            finally
            {
                con.Close();
            }

        }
    }
}