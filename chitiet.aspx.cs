using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace BTLweb
{
    public partial class chitiet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int idblog = Convert.ToInt32(Request.QueryString["idblog"]);
            int id = Convert.ToInt32(Request.QueryString["id"]);
            if (!IsPostBack)
            {
                hien_Blog(idblog);
                hien_chitiet_Blog(id);
                update_solanXem(id);
            }
        }

        public void hien_Blog(int id)
        {
           
            using(DataTable dt = get_Blog_byid(id))
            {
                rptBlog.DataSource = dt;
                rptBlog.DataBind();
            }
        }

        public DataTable get_Blog_byid(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Blog"].ConnectionString;
            using (SqlConnection Cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("blog_select_id",Cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        public void hien_chitiet_Blog(int id)
        {
            
            using (DataTable dt = get_chitiet_Blog_byid(id))
            {
                rptNoidung.DataSource = dt;
                rptNoidung.DataBind();
            }
        }

        public DataTable get_chitiet_Blog_byid(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Blog"].ConnectionString;
            using (SqlConnection Cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("chitiet_seclect_ID",Cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        public void update_solanXem(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Blog"].ConnectionString;
            using (SqlConnection Cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("chitiet_update_solanxem", Cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    Cnn.Open();
                    cmd.ExecuteNonQuery();
                    Cnn.Close();
                }
            }
        }
    }
}