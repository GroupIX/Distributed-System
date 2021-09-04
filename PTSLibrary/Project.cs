using System;
using System.Collections.Generic;

namespace PTSLibrary
{
	//This class keeps track of the projects. 

	[Serializable]
	public class Project
	{
		public Project()
        {

        }
		// Variable definition. 

		private string name;
		private DateTime expectedStartDate;
		private DateTime expectedEndDate;
		private Customer theCustomer;   //Still do not understand this definition.
		private Guid projectId;         //Great for a primary key in the database. Unique Identifier
		private List<Task> tasks;



		//Constructors

		public Project(string name, DateTime startDate, DateTime endDate, Guid projectId, Customer customer)
		{
			//<this> reffering to current clas instance members

			this.name = name;
			this.expectedStartDate = startDate;
			this.expectedEndDate = endDate;
			this.projectId = projectId;
			this.theCustomer = customer;
		}

		public Project(string name, DateTime startDate, DateTime endDate, Guid projectId, List<Task> tasks)
		{
			//<this> used to refer to current class instance members

			this.name = name;
			this.expectedStartDate = startDate;
			this.expectedEndDate = endDate;
			this.projectId = projectId;
			this.tasks = tasks;
		}

		
		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		public DateTime ExpectedStartDate
		{
			get { return expectedStartDate; }
			set { expectedStartDate = value; }
		}

		public DateTime ExpectedEndDate
		{
			get { return expectedEndDate; }
			set { expectedEndDate = value; }
		}

		public Guid ProjectId
		{
			get { return projectId; }
			set { projectId = value; }
		}

		public Customer TheCustomer
		{
			get { return theCustomer; }
			set { theCustomer = value; }
		}

		public List<Task> Tasks
		{
			get { return tasks; }
			set { tasks = value; }
		}
		


	}

}
