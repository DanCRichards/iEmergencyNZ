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
    public partial class AccountDetails : System.Web.UI.Page
    {

        public void BindGrid(int userID)
        {

            BLL objBLL = new BLL();

            GridView1.DataSource = objBLL.getContactDetails(userID);
            GridView1.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["objUser"] == null)
            {
                Response.Redirect("SignIn.aspx");
            }

            if (!IsPostBack)
            {

                user objUser = Session["objUser"] as user;

                BindGrid(objUser.id);

                txtName.Value = objUser.name;
                txtEmail.Value = objUser.email;
                txtDisabilities.Value = objUser.disabilities;


            }
        }

        protected void buttonSubmit_Click(object sender, EventArgs e)
        {

            BLL objBLL = new BLL();
            user user = Session["objUser"] as user;
            objBLL.updateAccount(user.id, txtName.Value, txtEmail.Value, txtDisabilities.Value);
            user oldUser = Session["objUser"] as user;
            oldUser.email = txtEmail.Value;
            oldUser.name = txtName.Value;
            oldUser.disabilities = txtDisabilities.Value;

            Session["objUser"] = oldUser;
        }



        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {

            GridView1.EditIndex = e.NewEditIndex;
            user objUser = Session["objUser"] as user;

            BindGrid(objUser.id);

        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            user objUser = Session["objUser"] as user;

            BindGrid(objUser.id);

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            GridViewRow row = GridView1.Rows[e.RowIndex];

            Label id = row.FindControl("lblID") as Label;
            BLL objBLL = new BLL();


            objBLL.deleteAccountContact(Convert.ToInt32(id.Text));

            user objUser = Session["objUser"] as user;

            BindGrid(objUser.id);
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            GridViewRow row = GridView1.Rows[e.RowIndex];
            TextBox name = row.FindControl("tbName") as TextBox;
            TextBox email = row.FindControl("tbEmail") as TextBox;
            TextBox mobile = row.FindControl("tbMobile") as TextBox;
            TextBox relation = row.FindControl("tbRelationTo") as TextBox;
            Label id = row.FindControl("lblID") as Label;


            BLL objBLL = new BLL();
            int value = objBLL.updateContactRecord(name.Text, email.Text, mobile.Text, relation.Text, Convert.ToInt32(id.Text));
            if (value > 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Sucess", "alert('Record Updated');", true);
                GridView1.EditIndex = -1;
                user objUser = Session["objUser"] as user;

                BindGrid(objUser.id);

                return;
            }
            ClientScript.RegisterStartupScript(this.GetType(), "Fail", "alert('Deletion Failed');", true);
        }

        protected void addRecord_Click(object sender, EventArgs e)
        {
            // Add a record and get the ID of the user and put that in there as the database needs it. 

            BLL objBLL = new BLL();
            user objUser = Session["objUser"] as user;
            int userId = objUser.id;
            int value = objBLL.addContact(userId);
            if(value > 1) // Checks if update then rebinds .
            {
                BindGrid(userId);
            }
        }
    }
}
