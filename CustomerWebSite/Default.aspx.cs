using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CustomerWebSite
{
    public partial class _Default : System.Web.UI.Page
    {
        private customerwebservice.WebService1 service;
        protected void page_Load(object sender, EventArgs e)
        {
            service = new customerwebservice.WebService1();
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            int id = service.Authenticate(txtUsername.Text, txtPassword.Text);  //Call on the 
            if (id > 0)
            {
                Session["id"] = id; //Saves id in session
                Response.Redirect("ProjectDetails.aspx"); // Succesful authentication redirects the user to ProjectDetails.aspx page
            }
            else
            {
                lblMessage.Text = "Incorrect login details, please try again";
            }

        }
    }
}