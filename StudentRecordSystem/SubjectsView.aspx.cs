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

namespace StudentRecordSystem
{
    public partial class WebForm8 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["MGMTDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                DropListDataBind();
            }
        }
        void DropListDataBind()
        {
            SqlConnection con = new SqlConnection(strcon);
            SqlDataAdapter sda = new SqlDataAdapter("MGMTSP", con);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sda.SelectCommand.Parameters.AddWithValue("@Flag", "DropDownBind");
            DataTable data = new DataTable();
            sda.Fill(data);
            DrpListId.DataSource = data;
            DrpListId.DataTextField = "CourseName";
            DrpListId.DataValueField = "Id";
            DrpListId.DataBind();
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            StringBuilder table = new StringBuilder();
            SqlConnection con = null;
            try
            {
                using(con = new SqlConnection(strcon))
                {
                    con.Open();
                    SqlCommand com = new SqlCommand("MGMTSP",con);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@Flag","ShowSubject");
                    com.Parameters.AddWithValue("@AName",DrpListId.SelectedValue);
                    SqlDataReader dr = com.ExecuteReader();
                    table.Append("<table class='table table-hover table-bordered'>");
                    table.Append("<tr><th>First Subject</th><th>Second Subject</th><th>Third Subject</th><th>Fourth Subject</th></tr>");
                    if(dr.HasRows)
                    {
                        while(dr.Read())
                        {
                            table.Append("<tr>");
                            table.Append("<td>"+dr[1]+"</td>");
                            table.Append("<td>"+dr[2]+"</td>");
                            table.Append("<td>"+dr[3]+"</td>");
                            table.Append("<td>"+dr[4]+"</td>");
                            table.Append("</tr>");
                        }
                    }
                    table.Append("</table>");
                    PanelId.Controls.Add(new Literal { Text = table.ToString() });
                    dr.Close();
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