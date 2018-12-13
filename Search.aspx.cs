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
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string search = Request.QueryString["search"];
            hien_danhsach_chitiet_bytieuDe(search);
        }

        private DataTable get_danhsach_chitiet_bytieuDe(string tieude)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Blog"].ConnectionString;
            using (SqlConnection Cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand Cmd = new SqlCommand("chitiet_search", Cnn))
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@tieude", tieude);
                    using (SqlDataAdapter da = new SqlDataAdapter(Cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        private void hien_danhsach_chitiet_bytieuDe(string tieude)
        {
            using (DataTable dt = get_danhsach_chitiet_bytieuDe(tieude))
            {
                if (dt.Rows.Count > 0)
                {
                    rptBlog.DataSource = dt;
                    rptBlog.DataBind();
                    lblThongBao.Visible = false;
                }
                else
                {
                    lblThongBao.Text = "<p>Không có blog liên quan đến từ khóa</p>";
                }
            }
        }
    }
}