using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace PTSLibrary.DAO
{

    //This is customer data access object where customers can access the database.
    class CustomerDAO : SuperDAO
    {
        public int Authenticate(string username, string password)
        {
            string sql;
            SqlConnection cn;
            SqlCommand cmd;
            SqlDataReader dr;

            sql = String.Format("SELECT CuatsomerId FROM Customer WHERE Username=(0) AND Password='(1)'", username, password); //format item (0) is replaced with the va;ue of the username
            cn = new SqlConnection(Properties.Settings.Default.ConnectionString);
            cmd = new SqlCommand(sql, cn);
            int id = 0;
            try
            {
                cn.Open();
                dr = cmd.ExecuteReader(CommandBehavior.SingleRow);
                if (dr.Read()) //Ensures that we only read from the SQL DatReader only if a matching customerId is returned. if not, 0 is returned.
                {
                    id = (int)dr["CustomerId"];
                }
                dr.Close();
            }
            catch (SqlException ex)
            {
                throw new Exception("Error Accessing Database", ex);
            }
            finally
            {
                cn.Close();
            }
            return id;
        }

        public List<Project> GetListOfProjects(int customerId)
        {

            string sql;
            SqlConnection cn;
            SqlCommand cmd;
            SqlDataReader dr;
            List<Project> projects;
            projects = new List<Project>();

            sql = "SELECT * FROM Project WHERE CustomerId = " + customerId.ToString();
            cn = new SqlConnection(Properties.Settings.Default.ConnectionString);
            cmd = new SqlCommand(sql, cn);

            try
            {
                cn.Open();
                dr = cmd.ExecuteReader();

                //definition for using sql2
                SqlConnection cn2; 
                SqlCommand cmd2; 
                SqlDataReader dr2;   

                while (dr.Read())
                {
                    List<Task> tasks = new List<Task>();
                    sql = "SELECT * FROM Task WHERE ProjectId= '" + dr["ProjectId"].ToString() + "'";
                    cn2 = new SqlConnection(Properties.Settings.Default.ConnectionString);
                    cmd2 = new SqlCommand(sql, cn2);
                    cn2.Open();
                    dr2 = cmd2.ExecuteReader();
                    while (dr2.Read())
                    {
                        Task t = new Task((Guid)dr2["TaskId"], dr2["Name"].ToString(), (Status)dr2["StatusId"]);
                        tasks.Add(t);
                    }
                    dr2.Close();
                    Project p = new Project(dr["Name"].ToString(), (DateTime)dr["ExpectedStartDate"], (DateTime)dr["ExpectedEndDate"], (Guid)dr["ProjectId"], tasks);
                    projects.Add(p);
                    //cn2.Close();
                }
                dr.Close();
            }
            catch (SqlException ex)
            {
                throw new Exception("Error Getting list", ex);
            }
            finally
            {
                cn.Close();
            }
            return projects;
        }
    }
}
