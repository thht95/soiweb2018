using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTLweb
{
    public partial class admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            List<User> listu = (List<User>)Application["user"];
            foreach (var temp in listu)
            {
                if (temp.user.Equals(TextBox1.Text))
                {
                    Response.Write(temp.url);
                }
                else
                {
                    Response.Write("nguoi dung dang khong onl");
                }
            }
        }
    }
}