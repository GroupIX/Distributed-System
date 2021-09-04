using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSLibrary
{
    public class PTSSuperFacade : MarshalByRefObject
    {
        protected DAO.SuperDAO dao;  //Accesses a class in the subfolder

        public PTSSuperFacade (DAO.SuperDAO dao)
        {
            this.dao = dao;
        }

        public Task[] GetListOfTask(Guid projectId)
        {
            return (dao.GetListOfTasks(projectId)).ToArray();
        }
    }
}
