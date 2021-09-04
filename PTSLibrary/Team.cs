using System;

namespace PTSLibrary
{

	[Serializable]
	//This is a comment.
	//This class represents teams working on any project, both internal and external.
	public class Team
	{
		public Team()
        {

        }
		private int id;
		private string location;
		private string name;
		private TeamLeader leader;   //What type is TeamLeader? String, int etc?

		//Get method retrieves the information stored in the property and return that value.
		//Set method inputs a value to the property that uses this method. 

		public int TeamId    //Here the property is TeamId. Get retrieves the value of TeamId while Set inputs a value to TeamId
		{
			get { return id; }
			set { id = value; }
		}

		public TeamLeader Leader
		{
			get { return leader; }
			set { leader = value; }
		}

		public string Location
		{
			get { return location; }
			set { location = value; }
		}

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		public Team(int id, string location, string name, TeamLeader leader)
		{
			this.location = location;
			this.name = name;
			this.id = id;
			this.leader = leader;
		}
	}
}
