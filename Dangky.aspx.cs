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
    public partial class Dangky : System.Web.UI.Page
    {
        int x = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            lbloi.Text = "";
        }

        protected void btndangky_Click(object sender, EventArgs e)
        {
            string name = Request.Form["nameRegister"];
            string email = Request.Form["emailRegister"];
            string password = Request.Form["PasswordRegister"];
            string repassword = Request.Form["RepasswordRegister"];

            using (DataTable dt = get_danhsach_User())
            {
                if ((password != repassword) || (password.Length==0))
                {
                    x = 1;
                }
                foreach (DataRow row in dt.Rows)
                {
                    if((row["userName"].ToString() == name) || (row["email"].ToString() == email))
                    {
                        x = 2;
                        break;
                    }                   
                }
                if (x == 1)
                {
                    lbloi.Text = "Mật khẩu và xác nhận mật khẩu không giống nhau!";
                }
                else if (x == 2)
                {
                    lbloi.Text = "Tên đăng nhập hoặc Email đã tồn tại. Vui long nhập lại !";
                }
                else
                {
                    string connectionString = ConfigurationManager.ConnectionStrings["Blog"].ConnectionString;
                    using (SqlConnection Cnn = new SqlConnection(connectionString))
                    {
                        using (SqlCommand Cmd = new SqlCommand("User_insert", Cnn))
                        {
                            Cmd.CommandType = CommandType.StoredProcedure;
                            Cmd.Parameters.AddWithValue("@userName", name);
                            Cmd.Parameters.AddWithValue("@email", email);
                            Cmd.Parameters.AddWithValue("@pass", password);
                            Cnn.Open();
                            Cmd.ExecuteNonQuery();
                            Cnn.Close();

                        }

                    }
                    Session["login"] = 1;
                    Session["name"] = name;
                    Session["email"] = email;
                    Response.Redirect("index.aspx");
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
    }
}