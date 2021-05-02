using System;
using System.Collections.Generic;
using DL;
using LL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UT
{
	[TestClass]
	public class DataServiceTest
	{
		private DataService service;
		private Data data;
		private IDataGenerator generator;

		[TestInitialize]
		public void Initialize()
		{
			data = new Data();
			service = new DataService(new DataManager(data));
			generator = new DataGenerator();
			generator.GenarateData(data);
		}

		// Test for readers
		[TestMethod]
		public void AddUserTest()
		{
			Assert.AreEqual(service.GetUsersCount(), 5);

			service.AddUser(new User("Andrea", "Sannino", 102036, "+39-845-5211-76"));

			Assert.AreEqual(service.GetUsersCount(), 6);

			List<User> users = service.GetUsers();
			Assert.AreEqual(users.Count, 6);
			Assert.IsTrue(users.Exists(r => r.UserID == 102036));
		}

		

		[TestMethod]
		[ExpectedException(typeof(System.Exception))]
		public void AddReaderReapetedIDTest()
		{
			service.AddUser(new User("Vania", "Basso", 102036, "+39-845-5211-76"));
			service.AddUser(new User("Manfredi", "Sannino", 102036, "+39-845-5211-76"));
			Assert.AreEqual(service.GetUsersCount(), 6);
		}

		[TestMethod]
		public void DeleteUserTest()
		{
			Assert.AreEqual(service.GetUsersCount(), 5);
			service.DeleteUser(102036);
			Assert.AreEqual(service.GetUsersCount(), 4);
		}

		[TestMethod]
		public void DeleteNonExistingUserTest()
		{
			Assert.ThrowsException<InvalidOperationException>(
				() => service.DeleteUser(102040));
		}

		[TestMethod]
		public void GetUserByIDTest()
		{
			User returnedUser = service.GetUserByID(102036);

			Assert.IsNotNull(returnedUser);
			Assert.AreEqual(returnedUser.UserID, 102036);
			Assert.AreEqual(returnedUser.Name, "Andrea");
			Assert.AreEqual(returnedUser.Surname, "Sannino");
			Assert.AreEqual(returnedUser.PhoneNumber, "+39-845-5211-76");
		}

		[TestMethod]
		public void GetNonExistingUserByIdTest()
		{
			Assert.ThrowsException<Exception>(
				() => service.GetUserByID(102050));
		}


		[TestMethod]
		public void GetAllUsersTest()
		{
			List<User> allUsers = service.GetUsers();
			Assert.AreEqual(allUsers.Count, 5);

			Assert.IsTrue(allUsers.Exists(r => r.UserID == 102036));
			Assert.IsTrue(allUsers.Exists(r => r.UserID == 102033));
			Assert.IsTrue(allUsers.Exists(r => r.UserID == 102032));
			Assert.IsFalse(allUsers.Exists(r => r.UserID == 102));
		}


		[TestMethod]
		public void UpdateInfoAboutReaderTest()
		{
			User newUserData = new User("Andy", "Bassano", 102037, "+39-855-5200-76");

			Assert.AreEqual(service.GetUserByID(102030).PhoneNumber, "+48-885-5610-71");
			Assert.AreEqual(service.GetUserByID(102030).Name, "Adam");
			Assert.AreEqual(service.GetUserByID(102030).Surname, "Barna");
			service.EditUser(newUserData);
			Assert.AreEqual(service.GetUserByID(102030).PhoneNumber, "+39-855-5200-76");
			Assert.AreEqual(service.GetUserByID(102030).Name, "Andy");
			Assert.AreEqual(service.GetUserByID(102030).Surname, "Bassano");
		}
		



		
		// Tests for movie catalog
		[TestMethod]
		public void AddMovieTest()
		{
			Assert.AreEqual(service.GetMoviesCount(), 5);
			Movie movie5 = new Movie(92835345, "A Game of Thrones", "George R.R.Martin", 1996, Movie.MovieGenre.Action, 130);

			Assert.AreEqual(service.GetMoviesCount(), 6);
		}

		[TestMethod]
		public void DeleteMovieTest()
		{
			Assert.AreEqual(service.GetMoviesCount(), 5);
			service.DeleteMovie(32433234);
			Assert.AreEqual(service.GetMoviesCount(), 4);
		}
	}
}
		
