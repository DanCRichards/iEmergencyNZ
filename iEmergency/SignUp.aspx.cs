using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;
using BusinessObjects;

namespace iEmergency
{
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // What to do when the page loads

        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            // make sure that the data is all goods. 
            // Add to database

            // INITALISING THE OBJECTS NEEDED FOR SQL INTERACTION
            BLL objBLL = new BLL();
            user objUser = new user(txtFullName.Value, txtEmail.Value, txtPassword.Value);

            int output = objBLL.SignUpBLL(objUser);

            if (output > 0)
            {
                // SignUp successful. 
                // 
                if (objBLL.signUpEmail(objUser))
                { // Attempts to send email //
                    // Works fine

                    ClientScript.RegisterStartupScript(this.GetType(), "alertwindow", "alert('Registered successfully');window.location.href = 'SignIn.aspx';", true);
                    return;


                }
               
                    ClientScript.RegisterStartupScript(this.GetType(), "alertwindow", "alert('Error occurred');window.location.href = 'SignUp.aspx';", true);

               
            }


        }


        
    }
}