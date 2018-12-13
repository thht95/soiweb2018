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
    public partial class Blog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int idblog = Convert.ToInt32(Request.QueryString["idblog"]);
            hien_danhsach_chitiet_byID(idblog);
            hien_Blog(idblog);
        }

        private DataTable get_danhsach_chitiet_byID(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Blog"].ConnectionString;
            using (SqlConnection Cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand Cmd = new SqlCommand("chitiet_seclect_IDBLog", Cnn))
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@IDBlog", id);
                    using (SqlDataAdapter da = new SqlDataAdapter(Cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        private void hien_danhsach_chitiet_byID(int id)
        {
            using (DataTable dt = get_danhsach_chitiet_byID(id))
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
                using (SqlCommand cmd = new SqlCommand("blog_select_id", Cnn))
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

        public void hien_Blog(int id)
        {
            using (DataTable dt = get_Blog_byid(id))
            {
                rptTieude.DataSource = dt;
                rptTieude.DataBind();
            }
        }
    }
}