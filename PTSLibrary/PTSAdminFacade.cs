using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSLibrary
{
    public class PTSAdminFacade : PTSSuperFacade
    {

        //This is the admin DAO
        private DAO.AdminDAO dao;

        //constructor
        public PTSAdminFacade() : base (new DAO.AdminDAO())
        {
            dao = (DAO.AdminDAO)base.dao;
        }

        //Admin authentication
        public int Authenticate(string username, string password)
        {
            if (username == "" || password == "")
            {
                throw new Exception("Missing Data");
            }
            return dao.Authenticate(username, password);
        }

        //Creating a new project
        public void CreateProject(string name, DateTime startDate, DateTime endDate, int customerId, int administratorId)
        {
            if (name == "" || name == null || startDate == null || endDate == null)
            {
                throw new Exception("Missing Project data.");
            }
            dao.CreateProject(name, startDate, endDate, customerId, administratorId);
        }

        //To create a new task in project
        public void CreateTask(string name, DateTime startDate, DateTime endDate, int teamId, Guid projectId)
        {
            if (name == null || name == "" || startDate == null || endDate == null)
            {
                throw new Exception("Missing Data");
            }
            dao.CreateTask(name, startDate, endDate, teamId, projectId);
        }

        //To get list of customers
        public Customer[] GetListOfCustomers()
        {
            return dao.GetListOfCustomers().ToArray();
        }

        //Getting list of projects
        public Project[] GetListOfProjects(int adminId)
        {
            return dao.GetListOfProjects(adminId).ToArray();
        }

        //Getting list of teams
        public Team[] GetListOfTeams()
        {
            return dao.GetListOfTeams().ToArray();
        }
    }
}
