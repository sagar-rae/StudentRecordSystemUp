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
    public partial class WebForm7 : System.Web.UI.Page
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
            SqlConnection con = null;
            try
            {
                using (con = new SqlConnection(strcon))
                {
                    con.Open();
                    SqlCommand comm = new SqlCommand("MGMTSP",con);
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.Parameters.AddWithValue("@Flag","Subject");
                    comm.Parameters.AddWithValue("@AName",DrpListId.SelectedValue);
                    comm.Parameters.AddWithValue("@Sub1",Subject1Id.Value);
                    comm.Parameters.AddWithValue("@Sub2", Subject2Id.Value);
                    comm.Parameters.AddWithValue("@Sub3", Subject3Id.Value);
                    comm.Parameters.AddWithValue("@Sub4", Subject4Id.Value);
                    int check = comm.ExecuteNonQuery();
                    if(check>0)
                    {
                        Response.Write("<script>alert('Succefully inserted.')</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('Something went wrong.')</script>");
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