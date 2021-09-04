using System;
using CustomerWebSite.customerwebservice;


 public partial class ProjectDetails : System.Web.UI.Page
{
     protected void Page_Load(object sender, EventArgs e)
     {

     }

    public void ShowProjectDetails()
    {
        if (Session["id"] == null)  //If the page is accessed without being loggedin, regirect to login page
        {
            Response.Redirect("Default.aspx");
        }
        else
        {
            WebService1 service = new WebService1();
            Project[] projects = service.GetListOfProjects((int)Session["id"]);

            for (int i = 0; i < projects.Length; i++)
            {
                Project p = projects[i];
                Response.Write("<p>Project: <b>" + p.Name + "</b><br>");  //List each project
                Task[] tasks = p.Tasks;
                for (int j = 0; j < tasks.Length; j++)
                {
                    Task t = tasks[j];
                    Response.Write("Task: <i>" + t.Name + " - " + t.theStatus + "</i><br>");  //List tasks for each project
                }
                Response.Write("</p>");  //Writes to current HTTP output
            }
        }
    }
}