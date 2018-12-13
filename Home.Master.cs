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
    public partial class Home : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hien_danhsach_blog();
                hien_danhsach_chitiet_moinhat();
               
                Session["url"] = Request.RawUrl;
                if (Application["user"] == null)
                {
                    if (Session["user"] != null && Session["url"] != null)
                    {
                        List<User> listu = new List<User>();
                        User us = new User(Session["user"].ToString(), Session["url"].ToString());
                        listu.Add(us);
                        Application["user"] = listu;
                    }
                }
                else
                {
                    if (Session["user"] != null && Session["url"] != null)
                    {
                        List<User> listu = (List<User>)Application["user"];
                        User us = new User(Session["user"].ToString(), Session["url"].ToString());
                        listu.Add(us);
                        Application["user"] = listu;
                    }
                }
                //
            }
        } 

        private void hien_danhsach_blog()
        {
            using (DataTable dt = get_danhsach_Blog())
            {
                rptBlog.DataSource = dt;
                rptBlog.DataBind();
            }
        }

        private DataTable get_danhsach_Blog()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Blog"].ConnectionString;
            using (SqlConnection Cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand Cmd = new SqlCommand("blog_seclect_all", Cnn))
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

        private DataTable get_danhsach_chitiet_luotxem()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Blog"].ConnectionString;
            using (SqlConnection Cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand Cmd = new SqlCommand("chitiet_lanxem", Cnn))
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
            using (DataTable dt = get_danhsach_chitiet_luotxem())
            {
                rptChitiet_luotxem.DataSource = dt;
                rptChitiet_luotxem.DataBind();
            }
        }
    }
}