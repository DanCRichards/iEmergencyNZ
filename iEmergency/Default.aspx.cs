using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObjects;

namespace iEmergency
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            user objUser = null;
            if (Session["objUser"] != null)
            {
                // THERE IS A USER

                objUser = Session["objUser"] as user;
                lblUserFullName.InnerText = "Welcome " + objUser.name;
            }
            
        }
    }
}