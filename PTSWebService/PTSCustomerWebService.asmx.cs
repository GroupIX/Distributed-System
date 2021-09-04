using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using PTSLibrary;

namespace PTSWebService
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        private PTSCustomerFacade facade;

        public WebService1()
        {

            //Uncomment the following line if using designed components 
            //InitializeComponent(); 
            facade = new PTSCustomerFacade();
        }

        [WebMethod]
        //public string HelloWorld()
        //{
          //  return "Hello World";
        //}

        public int Authenticate(string name, string password)
        {
            return facade.Authenticate(name, password);
        }

        [WebMethod]
        public Project[] GetListOfProjects(int customerId)
        {
            return facade.GetListOfProjects(customerId);
        }
    }
}
