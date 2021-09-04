using System;
using System.Collections.Generic;
using System.Text;

namespace PTSLibrary
{

    [Serializable]

    //This class shows a task/tasks within a project.
    public class Task
    {
        public Task()
        {

        }

        //variable definition

        private Guid taskId;  //We use GUID for a unique identifier. It makes for great Primary Key in the backend database 
        private string name;
        private Status status;

        //constructors
        //Get retrieves the value.
        //Set sets the value

        public Guid TaskId
        {
            get { return taskId; }
            set { taskId = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Status theStatus
        {
            get { return status; }
            set { status = value; }
        }

        // method 

        public Task(Guid id, string name, Status status)
        {

            //<this> key word refers to the current instance of the class.
            //It accesses members from the constructors, instance methods and instance accessors (from geeksforgeeks)
            //Also used to track the instance invoked to perform some calculations or further processing related to that instance.

            //This is a constructor that sets the properties os tasks.
            //Constructors enable us to set default values.

            this.taskId = id;
            this.name = name;
            this.status = status;
        }
    }
}
