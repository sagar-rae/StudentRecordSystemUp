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
    public partial class WebForm1 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["MGMTDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["user"]!=null)
            {
                Response.Write("Hello "+Session["user"].ToString());
            }
            else
            {
                Response.Redirect("AdminLogin.aspx");
            }

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
            sda.SelectCommand.Parameters.AddWithValue("@Flag","DropDownBind");
            DataTable data = new DataTable();
            sda.Fill(data);
            DrpListId.DataSource = data;
            DrpListId.DataTextField = "CourseName";
            DrpListId.DataValueField = "Id";
            DrpListId.DataBind();

        }
        protected void Submit_Click(object sender, EventArgs e)
        {
            SqlConnection con=null;
            try
            {
                using(con=new SqlConnection(strcon))
                {
                    con.Open();
                    SqlCommand comm = new SqlCommand("MGMTSP",con);
                    comm.CommandType=CommandType.StoredProcedure;
                    fileUploadId.SaveAs(Server.MapPath("~/ImageFolder") + System.IO.Path.GetFileName(fileUploadId.FileName));
                    string linkPath = "ImageFolder/" + System.IO.Path.GetFileName(fileUploadId.FileName);
                    comm.Parameters.AddWithValue("@Flag","Insert");
                    comm.Parameters.AddWithValue("@StudentID",StdId.Value);
                    comm.Parameters.AddWithValue("@Img",linkPath);
                    comm.Parameters.AddWithValue("@FullName",FnameId.Value);
                    comm.Parameters.AddWithValue("@PhoneNumber",PhNumId.Value);
                    comm.Parameters.AddWithValue("@Email",EmailId.Value);
                    comm.Parameters.AddWithValue("@Address",AddressId.Value);
                    comm.Parameters.AddWithValue("@DateOfBirth",DOBId.Value);
                    comm.Parameters.AddWithValue("@FathersName",FatherId.Value);
                    comm.Parameters.AddWithValue("@MothersName",MotherId.Value);
                    comm.Parameters.AddWithValue("@CourseName",DrpListId.SelectedValue);
                    int check = comm.ExecuteNonQuery();

                    if(check>0)
                    {
                        Response.Write("<script>alert('Succesfully inserted')</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('Error')</script>");
                    }                   
                }
            }
            catch(Exception ex)
            {
                Response.Write("<script>'"+ex.Message+"'</script>");
            }
            finally
            {
                con.Close();
            }
        }
    }
}