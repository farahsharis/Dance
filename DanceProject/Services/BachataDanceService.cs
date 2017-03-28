using System;
using System.Collections.Generic;

namespace DanceProject
{

	public class BachataDanceService : IDanceService
	{

		IList<string> follower = new List<string> { "r", "l", "r", "lt", "l", "r", "l", "rt" };
		IList<string> leader = new List<string> { "l", "r", "l", "rt", "r", "l", "r", "lt" };

		public BachataDanceService()
		{

		}

		public StepResult FollowerDanceVerification(IList<string> inputSteps)
		{
			var steps = ToLowerCase(inputSteps);
			var completedSteps = CheckSteps(steps, follower);
			return completedSteps;
		}



		public StepResult LeaderDanceVerification(IList<string> inputSteps)
		{
			var steps = ToLowerCase(inputSteps);
			var completedSteps = CheckSteps(steps, leader);
			return completedSteps;
		}


		private StepResult CheckSteps(IList<string> userInputSteps, IList<string> correctSteps)
		{
			StepResult result = new StepResult();
			List<string> capturedSteps = new List<string>();
			var inputSize = userInputSteps.Count;
			int count = 0;

			for (var x = 0; x < inputSize; x++)
			{
				if (userInputSteps[count] != correctSteps[x % 8])
				{
					result.IsCorrect = false;
					result.StepsCompletedCorrectly = capturedSteps;
					result.Notifications = $"Your last step *{userInputSteps[count]}* was incorrect. ";

					return result;
				}
				capturedSteps.Add(userInputSteps[count]);
				count++;
			}

			return new StepResult { IsCorrect = true, StepsCompletedCorrectly = capturedSteps };
		}



		private List<string> ToLowerCase(IList<string> inputSteps)
		{
			List<string> lowerList = new List<string>();
			foreach (var step in inputSteps)
			{
				lowerList.Add(step.ToLower());
			}
			return lowerList;
		}

	}


}
