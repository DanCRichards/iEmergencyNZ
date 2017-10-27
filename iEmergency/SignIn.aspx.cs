using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObjects;
using BusinessLogicLayer;

namespace iEmergency
{
    public partial class SignIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SignIn_Click(object sender, EventArgs e)
        {

            user objuser = new user(txtUsername.Text); 
            BLL objBLL = new BLL();
            objuser = objBLL.signIn(objuser, txtPassword.Text);
            if(objuser.active == 1)
            {
                // LOGGED IN
                Session["objUser"] = objuser;
                ClientScript.RegisterStartupScript(this.GetType(), "alertwindow", "alert('Loged In');window.location.href = 'Default.aspx';", true);

            }
            else
            {
                // NOT LOGGED IN 
                ClientScript.RegisterStartupScript(this.GetType(), "Login Failed", "alert('Login Failed')", true);

            }
        }
    }
}