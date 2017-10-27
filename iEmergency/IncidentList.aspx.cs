using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;

namespace iEmergency
{
    public partial class Incidents : System.Web.UI.Page
    {

        public void BindGrid()
        {

            BLL objBLL = new BLL();
            GridView1.DataSource = objBLL.getAllIncidents();
            GridView1.DataBind();


        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["objUser"] == null)
            {
                Response.Redirect("SignIn.aspx");
            }
            BindGrid();

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindGrid();

        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            BLL objBLL = new BLL();

            GridViewRow row = GridView1.Rows[e.RowIndex];
            Label id = row.FindControl("lblID") as Label;
            DropDownList ddl = row.FindControl("DropDownList1") as DropDownList;
            TextBox tb = row.FindControl("editpath") as TextBox;

            int idValue = Convert.ToInt32(id.Text);
            

            int output = objBLL.updateIncident(ddl.SelectedValue, tb.Text, idValue);

            if(output > 0) {
                ClientScript.RegisterStartupScript(this.GetType(), "Sucess", "alert('Record updated');",true);
                GridView1.EditIndex = -1;
                BindGrid();
                return;
            }
            ClientScript.RegisterStartupScript(this.GetType(), "Error", "alert('Error occured');", true);
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            GridViewRow row = GridView1.Rows[e.RowIndex];

            Label id = row.FindControl("lblID") as Label;

            BLL objBLL = new BLL();
            int output = objBLL.deleteIncident(Convert.ToInt32(id.Text));

            if(output > 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Sucess", "alert('Record Deleted');", true);
                return;
            }
            ClientScript.RegisterStartupScript(this.GetType(), "Fail", "alert('Deletion Failed');", true);
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

            GridView1.EditIndex = -1;
            BindGrid();

        }
    }
}