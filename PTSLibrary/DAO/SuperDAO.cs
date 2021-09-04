using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace PTSLibrary.DAO
{
    public class SuperDAO
    {

        protected Customer GetCustomer(int custId)
        {
            //Var declaration

            string sql;

            //imported functions from <system.data.sqlclient>
            //Necesssary to access our database

            SqlConnection cn;
            SqlCommand cmd;
            SqlDataReader dr;
            Customer cust;

            sql = "SELECT * FROM Customer WHERE CustomerId = " + custId;            //SQL statement that retrieves customer details
            cn = new SqlConnection(Properties.Settings.Default.ConnectionString); //Create connection using connection string.
            cmd = new SqlCommand(sql, cn);
            try
            {
                cn.Open();
                dr = cmd.ExecuteReader(CommandBehavior.SingleRow); //SQL command set to return a single row
                dr.Read();
                cust = new Customer(dr["Name"].ToString(), (int)dr["CustomerId"]);  //Creates a new instance of customer cust.
                dr.Close();
            }
            catch (SqlException ex)
            {
                throw new Exception("Error Getting Customer", ex);
            }
            finally
            {
                cn.Close();
            }
            return cust;
        }

        //Constructor
        public List<Task> GetListOfTasks(Guid projectId)
        {
            string sql;
            SqlConnection cn;
            SqlCommand cmd;
            SqlDataReader dr;
            List<Task> tasks;
            tasks = new List<Task>();

            sql = "SELECT * FROM Task WHERE ProjectId = '" + projectId + "'";
            cn = new SqlConnection(Properties.Settings.Default.ConnectionString);
            cmd = new SqlCommand(sql, cn);

            try
            {
                cn.Open();
                dr = cmd.ExecuteReader(); //Unlike the previous instance, it is not set to return a single row.
                while (dr.Read())         //dr may return more than one row, this iterates through these rows.
                {
                    Task t = new Task((Guid)dr["TaskId"], dr["Name"].ToString(), (Status)((int)dr["StatusId"]));
                    tasks.Add(t);
                }
                dr.Close();
            }
            catch (SqlException ex)
            {
                throw new Exception("Error getting tasks list", ex);
            }
            finally
            {
                cn.Close();
            }
            return tasks;
        }
    }
}
