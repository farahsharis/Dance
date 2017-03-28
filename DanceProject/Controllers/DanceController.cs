using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace DanceProject.Controllers
{

	[Route("api/dance/")]
	public class DanceController : ApiController
	{
		public DanceController()
		{

		}
		BachataDanceService danceService = new BachataDanceService();


		[HttpPost]
		[Route("api/dance/{dance}/validate")]
		public StepResult PostDanceSteps(Bachata bachata)
		{
			var sex = bachata.Sex.ToLower();
			var steps = bachata.DanceSteps.ToList();

			if (bachata == null)
			{
				throw new NullReferenceException("Please send some dance steps!");
			}


			if (bachata.DanceSteps.Count < 1)
			{
				StepResult result = new StepResult();
				result.Notifications = "Send NUDES!! I mean Dance Steps!!";
				return result;

			}

			if (sex == "f")
			{
				var followerResult = danceService.FollowerDanceVerification(steps);
				return followerResult;

			}
			if (sex == "m")
			{
				var leadResult = danceService.LeaderDanceVerification(steps);
				return leadResult;

			}
			else
			{
				StepResult result = new StepResult();
				result.Notifications = "Enter 'F' for female or 'M' for male";
				return result;
			}
		}
	}





}