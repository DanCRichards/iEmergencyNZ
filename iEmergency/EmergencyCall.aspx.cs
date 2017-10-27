using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObjects;
using BusinessLogicLayer;
using System.Data;



namespace iEmergency
{

    public partial class EmergencyCall : System.Web.UI.Page
    {
        protected String Agency = String.Empty;
        protected int node;
        protected bool nodeSelected = false;
        protected String agency = String.Empty;
        
        


        public void BindGrid(int node)
        {
            BLL objBLL = new BLL();
            DataSet ds = new DataSet();
            

            gvCallData.DataSource = objBLL.getIncidentTypes(node);
            gvCallData.DataBind();

            

           

        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["objUser"] == null)
            {
                Response.Redirect("SignIn.aspx");
            }


            txtTime.Value = DateTime.Now.ToString();


            if (!IsPostBack)
            {

                int node = 1;

                Session["PathString"] = String.Empty;
                Session["agency"] = String.Empty;


                BindGrid(node);

            }
            else { 


            }
        }

        protected void gvCallData_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "Select")
            {

                int value =  Convert.ToInt32(e.CommandArgument);
               if(value < 5)
                {
                    switch (value)
                    {
                        case 2:
                            Session["agency"] = "Fire Service";
                                break;
                        case 3:
                            Session["agency"] = "St John Ambulance";
                            break;
                        case 4:
                            Session["agency"] = "Police";
                            break;
                    }
                }

                

                BLL objBLL = new BLL();
                 BindGrid(value);
               


                Session["PathString"] = Session["PathString"] as String + " >" + objBLL.getCurrentNode(value);
                //  ClientScript.RegisterStartupScript(this.GetType(), "alertwindow", "alert('Emergency Selected');", true);
                }
           
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            
            double latitude = Convert.ToDouble(latitudeHDN.Value);
            user objUser = Session["objUser"] as user;
            int userId = objUser.id;
            String agency = Session["agency"] as String;
            String status = "Created";
            String path = Session["PathString"] as String;
            double longitude = Convert.ToDouble(longitudeHDN.Value);
            int priority = 1;
            int accuracy = Convert.ToInt32(accuracyHDN.Value);


            // Submit the actual thingy. 
            incident objIncident = new incident(agency, latitude, objUser.id, status, longitude, priority, accuracy, path, locationDescriptionHDN.Value);

            BLL objBLL = new BLL();
            objBLL.createIncident(objIncident);



            ClientScript.RegisterStartupScript(this.GetType(), "alertwindow", "window.location.href = 'IncidentList.aspx';", true);

            objBLL.emailContacts(userId);

            return;



            }
    }
}




// CODE FROM PREVIOUS RELEASES POTENTIALLY TO BE RESUED


    // USED FOR POST REQUEST TO PAGE TO SELECT EMERGENCY SERVICE




// First call

/*
Agency = Request.QueryString["agency"];
int node = 1;

if (Agency.Equals("fire", StringComparison.Ordinal))
{
    Agency = "Fire Service";
    node = 2;


    // SQL Statements here. 
}
else if (Agency.Equals("ambulance", StringComparison.Ordinal))
{
    Agency = "St John Amubulance";
    node = 3;
}
else if (Agency.Equals("police", StringComparison.Ordinal))
{
    // Go to different page
    Agency = "Police";
    node = 4;

}
else
{
    // Went to generic Emergency Services page. 
    // Keep node as 1, which allows someone to select the service they need
}
*/
// Set up incident call type here: 
