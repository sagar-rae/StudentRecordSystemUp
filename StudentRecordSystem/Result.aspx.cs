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
    public partial class WebForm9 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["MGMTDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                ShowSubject.Visible = false;
                DropListDataBind();
            }
            //else
            //{
            //    ShowSubject.Visible = true;
            //}
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            LoadSubject();
            CheckUser();
        }

        void CheckUser()
        {
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            SqlCommand com = new SqlCommand("MGMTSP", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Flag","CheckUser");
            com.Parameters.AddWithValue("@StudentId",StdRegId.Value);
            com.Parameters.AddWithValue("@AName",DrpListId.SelectedValue);
            SqlDataReader dr = com.ExecuteReader();
            if(dr.HasRows)
            {
                ShowSubject.Visible = true;
            }
            else
            {
                Response.Write("<script>alert('Student not found of that details.')</script>");
            }
        }

        void LoadSubject()
        {
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            SqlCommand com = new SqlCommand("MGMTSP",con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Flag", "ShowSubject");
            com.Parameters.AddWithValue("@AName",DrpListId.SelectedValue);
            SqlDataReader dr = com.ExecuteReader();
            if(dr.HasRows)
            {
                while(dr.Read())
                {
                    Sub1Id.InnerText = dr[1].ToString();
                    Sub2Id.InnerText = dr[2].ToString();
                    Sub3Id.InnerText = dr[3].ToString();
                    Sub4Id.InnerText = dr[4].ToString();
                }
            }
            dr.Close();
            con.Close();         
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

        void InsertResult()
        {
            SqlConnection con = null;
            try
            {
                using (con = new SqlConnection(strcon))
                {
                    con.Open();
                    SqlCommand com = new SqlCommand("MGMTSP", con);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@Flag", "ResultInsert");
                    com.Parameters.AddWithValue("@Sub1", Sub1Box.Value);
                    com.Parameters.AddWithValue("@Sub2", Sub2Box.Value);
                    com.Parameters.AddWithValue("@Sub3", Sub3Box.Value);
                    com.Parameters.AddWithValue("@Sub4", Sub4Box.Value);
                    com.Parameters.AddWithValue("@AName", DrpListId.SelectedValue);
                    com.Parameters.AddWithValue("@Id", StdRegId.Value);

                    int check = com.ExecuteNonQuery();
                    if (check > 0)
                    {
                        Response.Write("<script>alert('Successfully Inserted.')</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('Error')</script>");
                    }
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

        protected void Submit_Click(object sender, EventArgs e)
        {
            InsertResult();

        }
    }
}