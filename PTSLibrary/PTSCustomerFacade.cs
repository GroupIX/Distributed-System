using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSLibrary
{
     public class PTSCustomerFacade : PTSSuperFacade
    {
        private DAO.CustomerDAO dao;

        public PTSCustomerFacade() : base(new DAO.CustomerDAO())  //Makes a call to the constructor of the superclass
        {
            dao = (DAO.CustomerDAO)base.dao;
        }

        public Project[] GetListOfProjects(int customerId)
        {
            return (dao.GetListOfProjects(customerId)).ToArray(); //Facade calls the dao allowing us to expose only certain mathods from the DAO
        }

        public int Authenticate(string name, string password)
        {
            return dao.Authenticate(name, password);
        }
    }
}
