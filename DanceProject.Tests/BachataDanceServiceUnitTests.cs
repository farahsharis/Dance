using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace DanceProject.Tests
{
	[TestFixture]
	public class BachataDanceServiceUnitTests
	{
		[Test]
		public void assume_correct_follower_dance_steps_is_accepted()
		{
			IList<string> user = new List<string> { "R", "L", "R", "LT", "L", "R", "L", "RT" };

			var sut = new BachataDanceService();
			var result = sut.FollowerDanceVerification(user);

			Assert.True(result.IsCorrect);

		}

		[Test]
		public void assume_correct_leader_dance_steps_is_accepted()
		{
			IList<string> user = new List<string> { "L", "R", "L", "RT", "R", "L", "R", "LT" };

			var sut = new BachataDanceService();
			var result = sut.LeaderDanceVerification(user);

			Assert.True(result.IsCorrect);

		}

		[Test]
		public void assume_correct_follower_dance_steps_is_accepted_without_finishing()
		{
			IList<string> user = new List<string> { "R", "L", "R", "LT", "L" };

			var sut = new BachataDanceService();
			var result = sut.FollowerDanceVerification(user);

			Assert.True(result.IsCorrect);

		}

		[Test]
		public void assume_correct_leader_dance_steps_is_accepted_without_finishing()
		{
			IList<string> user = new List<string> { "L", "R", "L" };

			var sut = new BachataDanceService();
			var result = sut.LeaderDanceVerification(user);

			Assert.True(result.IsCorrect);

		}

		[Test]
		public void assume_incorrect_follower_dance_steps_is_not_accepted()
		{
			IList<string> user = new List<string> { "R", "L", "L", "LT", "L", "R", "L", "RT" };

			var sut = new BachataDanceService();
			var result = sut.FollowerDanceVerification(user);

			Assert.False(result.IsCorrect);

		}

		[Test]
		public void assume_incorrect_leader_dance_steps_is_not_accepted()
		{
			IList<string> user = new List<string> { "L", "L", "L", "RT", "R", "L" };

			var sut = new BachataDanceService();
			var result = sut.LeaderDanceVerification(user);

			Assert.False(result.IsCorrect);

		}


		[Test]
		public void assume_correct_follower_dance_steps_is_accepted_for_multiple_dance_iterations()
		{
			IList<string> user = new List<string> { "R", "L", "R", "LT", "L", "R", "L", "RT", "R", "L", "R", "LT" };

			var sut = new BachataDanceService();
			var result = sut.FollowerDanceVerification(user);

			Assert.True(result.IsCorrect);
		}


		[Test]
		public void assume_correct_leader_dance_steps_is_accepted_for_multiple_dance_iterations()
		{
			IList<string> user = new List<string> { "l", "r", "l", "rt", "r", "l", "r", "lt", "l", "r", "l", "rt" };

			var sut = new BachataDanceService();
			var result = sut.LeaderDanceVerification(user);

			Assert.True(result.IsCorrect);
		}


		[Test]
		public void assume_correct_steps_with_mixed_lower_upper_case_is_accepted_for_follower()
		{
			IList<string> user = new List<string> { "R", "l", "r", "lt", "L" };

			var sut = new BachataDanceService();
			var result = sut.FollowerDanceVerification(user);

			Assert.True(result.IsCorrect);
		}

		[Test]
		public void assume_correct_steps_with_mixed_lower_upper_case_is_accepted_for_leader()
		{
			IList<string> user = new List<string> { "L", "r", "l", "RT", "r", "l", "r", "Lt" };

			var sut = new BachataDanceService();
			var result = sut.LeaderDanceVerification(user);

			Assert.True(result.IsCorrect);
		}
	}
}
