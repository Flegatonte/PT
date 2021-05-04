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
			service.DeleteUser(102034);
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
			User returnedUser = service.GetUserByID(102033);

			Assert.IsNotNull(returnedUser);
			Assert.AreEqual(returnedUser.UserID, 102033);
			Assert.AreEqual(returnedUser.Name, "Jaromir");
			Assert.AreEqual(returnedUser.Surname, "Gac");
			Assert.AreEqual(returnedUser.PhoneNumber, "+48-855-5310-74");
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

			Assert.IsTrue(allUsers.Exists(r => r.UserID == 102033));
			Assert.IsTrue(allUsers.Exists(r => r.UserID == 102032));
			Assert.IsFalse(allUsers.Exists(r => r.UserID == 102));
		}


		[TestMethod]
		public void UpdateInfoAboutReaderTest()
		{
			User newUserData = new User("Andy", "Bassano", 102030, "+39-855-5200-76");

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
			service.AddMovie(new Movie(6, "A Game of Thrones", "George R.R.Martin", 1996, Movie.MovieGenre.Action, 130));

			Assert.AreEqual(service.GetMoviesCount(), 6);
		}

		[TestMethod]
		public void DeleteMovieTest()
		{
			Assert.AreEqual(service.GetMoviesCount(), 5);
			service.DeleteMovie(1);
			Assert.AreEqual(service.GetMoviesCount(), 4);
		}

		[TestMethod]
		public void GetAllBooksTest()
		{
			Dictionary<int, Movie> allMovies = service.GetMovieCatalog();
			Assert.AreEqual(allMovies.Count, 5);

			Assert.IsTrue(allMovies.ContainsKey(1));
			Assert.IsTrue(allMovies.ContainsKey(2));
			Assert.IsTrue(allMovies.ContainsKey(3));
			Assert.IsTrue(allMovies.ContainsKey(4));
			Assert.IsTrue(allMovies.ContainsKey(5));

			Assert.IsTrue(allMovies.ContainsValue(allMovies[1]));
			Assert.IsTrue(allMovies.ContainsValue(allMovies[2]));
			Assert.IsTrue(allMovies.ContainsValue(allMovies[3]));
			Assert.IsTrue(allMovies.ContainsValue(allMovies[4]));
			Assert.IsTrue(allMovies.ContainsValue(allMovies[5]));
		}
	}
}
		
