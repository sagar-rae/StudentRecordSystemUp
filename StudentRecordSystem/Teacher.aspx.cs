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
    public partial class WebForm11 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["MGMTDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropListDataBind();
            }
            else
                    {
                DropSubjectDataBind();
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
        void DropSubjectDataBind()
        {

            //SqlConnection con = new SqlConnection(strcon);
            //SqlDataAdapter sda = new SqlDataAdapter("MGMTSP", con);
            //sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            //sda.SelectCommand.Parameters.AddWithValue("@Flag", "DropDownBindSubject");
            //sda.SelectCommand.Parameters.AddWithValue("@CourseId",DrpListId.SelectedValue);
            //DataTable data = new DataTable();
            //sda.Fill(data);
            //DropList2Id.DataSource = data;
            //DropList2Id.DataTextField = "Sub1";
            //DropList2Id.DataValueField = "Sub1";
            //DropList2Id.DataBind();

            SqlConnection con = new SqlConnection(strcon);
            SqlCommand com = new SqlCommand("MGMTSP", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Flag", "DropDownBindSubject");
            com.Parameters.AddWithValue("@CourseId", DrpListId.SelectedValue);
            con.Open();
            var cars = new string[] { "Volvo", "BMW", "Ford" };
            SqlDataReader dr = com.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    DropList2Id.DataSource = cars;
                    //DropList2Id.DataBind();
                }
            }
            dr.Close();
            con.Close();

        }
        protected void Submit_Click(object sender, EventArgs e)
        {
            DropSubjectDataBind();
        }

    }
}