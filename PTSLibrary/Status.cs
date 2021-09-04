using System;
using System.Collections.Generic;
using System.Text;

namespace PTSLibrary
{
	public enum Status  //enum is a special type that represents a group of constants. This means that the following values will not change.
	{
		ReadyToStart = 1,
		InProgress = 2,
		Completed = 3,
		WaitingForPredecessor = 4
	}
}
