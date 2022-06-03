using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using System.Web.Services;

namespace StudentRecordSystem
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["MGMTDB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e) // only loads the code inside it but doesnt initialze the function. why ????
        {
            StringBuilder table = new StringBuilder();

            SqlConnection con = null;
            try
            {
                using (con = new SqlConnection(strcon))
                {
                    con.Open();
                    SqlCommand comm = new SqlCommand("MGMTSP", con);
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.Parameters.AddWithValue("@Flag", "DropDownBind");
                    SqlDataReader dr = comm.ExecuteReader();
                    table.Append("<table class='table table-hover table-bordered text-center'>");
                    table.Append("<tr><th>Course Id</th><th>Course Name</th><th>Edit</th></tr>");
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            table.Append("<tr>");
                            table.Append("<td>" + dr[0] + "</td>");
                            table.Append("<td>" + dr[1] + "</td>");

                            table.Append("<td><input type='button' class='btn btn-outline-danger dltBtn' value='Delete' onclick='test(\"" + dr[0].ToString() + "\")'/></td>");
                            //table.Append("<td><asp:Button runat='server' class='btn btn-outline-danger DelBtn' OnClick='Unnamed_Click()' Text='Delete' /></td>");
                            table.Append("</tr>");
                        }
                    }
                    table.Append("</table>");
                    PlaceholderCourse.Controls.Add(new Literal { Text = table.ToString() });
                    dr.Close();

                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
            finally
            {
                con.Close();
            }
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            Response.Write("<script>alert('testing')</script>");
        }
        //void LoadData()
        //{
        //    StringBuilder table = new StringBuilder();

        //    SqlConnection con = null;
        //    try
        //    {
        //        using(con = new SqlConnection(strcon))
        //        {
        //            SqlCommand comm = new SqlCommand("MGMTSP",con);
        //            comm.CommandType = CommandType.StoredProcedure;
        //            comm.Parameters.AddWithValue("@Flag","ShowCourse");
        //            SqlDataReader dr = comm.ExecuteReader();
        //            table.Append("<table class='table table-hover table-bordered'>");
        //            table.Append("<tr><th>Course Id</th><th>Course Name</th></tr>");
        //            if(dr.HasRows)
        //            {
        //                while(dr.Read())
        //                {
        //                    table.Append("<tr>");
        //                    table.Append("<td>'" + dr[0] + "'</td>");
        //                    table.Append("<td>'" + dr[1] + "'</td>");
        //                    table.Append("</tr>");
        //                }
        //            }
        //            table.Append("</table>");
        //            PlaceholderCourse.Controls.Add(new Literal { Text = table.ToString() });
        //            dr.Close();

        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        Response.Write("<script>alert('" + ex.Message + "')</script>");
        //    }
        //    finally
        //    {
        //        con.Close();
        //    }
        //}
      [WebMethod]
        public static string DeleteFunc(int i)
        {
            string strcon = ConfigurationManager.ConnectionStrings["MGMTDB"].ConnectionString;
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            SqlCommand com = new SqlCommand("MGMTSP", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Flag","DeleteCourse");
            com.Parameters.AddWithValue("@AName",i);
            int check = com.ExecuteNonQuery();
            if (check > 0)
            {
                con.Close();
                var msg = "Successfully deleted.";
                return msg;
                
            }
            else
            {
                con.Close();
                var errMsg = "Error";
                return errMsg;
            }

           
        }
    }
}