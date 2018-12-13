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
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            hien_danhsach_chitiet_moinhat();
            Response.Write(Session["url"]);
        }

        private DataTable get_danhsach_chitiet_moinhat()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Blog"].ConnectionString;
            using (SqlConnection Cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand Cmd = new SqlCommand("chitiet_select_orderby", Cnn))
                {
                    Cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter da = new SqlDataAdapter(Cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        private void hien_danhsach_chitiet_moinhat()
        {
            using(DataTable dt = get_danhsach_chitiet_moinhat())
            {
                rptChitiet.DataSource = dt;
                rptChitiet.DataBind();
            }
        }


    }
}