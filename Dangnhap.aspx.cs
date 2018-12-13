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
    public partial class Dangnhap : System.Web.UI.Page
    {
        int x = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            lbloi.Text = "";           
        }

        private void check_login()
        {
            string name = Request.Form["nameRegister"];
            string password = Request.Form["PasswordRegister"];
            using (DataTable dt =  get_danhsach_User())
            {
                foreach (DataRow row in dt.Rows)
                {
                    if(row["userName"].ToString() == name)
                    {
                        x = 0;
                        if ((row["userName"].ToString() == name) && row["pass"].ToString() != password)
                        {
                            x = 2;
                        }
                        if (x == 2)
                        {
                            lbloi.Text = "mật khẩu không chính xác.Vui lòng kiểm tra lại tài khoản và mật khẩu !";
                        }
                        else
                        {
                            Session["login"] = 1;
                            Session["name"] = row["userName"].ToString();
                            Session["email"] = row["email"].ToString();
                            Session["url"] = Request.RawUrl;
                            Session["user"] = row["userName"].ToString();
                            Response.Redirect("index.aspx");
                            break;
                        }
                    }    
                }
                if (x == 1)
                {
                    lbloi.Text = "tài khoản không tồn tại";
                }
            } 
        }
    
        private DataTable get_danhsach_User()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Blog"].ConnectionString;
            using (SqlConnection Cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand Cmd = new SqlCommand("User_select_all", Cnn))
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

        protected void btndangnhap_Click(object sender, EventArgs e)
        {
            check_login();
        }
    }
}