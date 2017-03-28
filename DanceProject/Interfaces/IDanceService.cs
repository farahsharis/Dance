using System;
using System.Collections.Generic;

namespace DanceProject
{
	public interface IDanceService
	{
		StepResult FollowerDanceVerification(IList<string> steps);
		StepResult LeaderDanceVerification(IList<string> steps);
	}
}
