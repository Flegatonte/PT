using Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
	[TestClass]
	public class FixedGenValTest
	{
		private IRepository repository;
		private IDataGenerator generator;
		private DataContext context;

		[TestInitialize]
		public void Initialize()
		{
			context = new DataContext();
			repository = new DataRepository(context);
			generator = new FixedValuesGenerator();
			generator.GenarateData(context);
		}

		[TestMethod]
		public void TestCheckGenerationNotNull()
		{
			Assert.IsNotNull(repository.GetAllMovies());
			Assert.IsNotNull(repository.GetAllUsers());
			Assert.IsNotNull(repository.GetAllEvents());
			Assert.IsNotNull(repository.GetAllStates());
		}

		[TestMethod]
		public void TestCheckGenerationCount()
		{
			Assert.AreEqual(repository.GetAllMoviesNumber(), 5);
			Assert.AreEqual(repository.GetAllUsersNumber(), 5);
			Assert.AreEqual(repository.GetAllEventsNumber(), 5);
		}

		[TestMethod]
		[ExpectedException(typeof(System.Exception))]
		public void TestCheckUserGenerationEqual()
		{
			User user1 = new User("Carlos", "Valle", 903543, 6);
			Assert.IsNotNull(repository.GetUserById(user1.Id));
			Assert.AreEqual(repository.GetUserById(user1.Id), user1);

			User user2 = new User("Gloria", "Fiammengo", 903685, 4);
			Assert.IsNotNull(repository.GetUserById(user2.Id));
			Assert.AreEqual(repository.GetUserById(user2.Id), user2);
			user2 = repository.GetUserById(0);
		}

		[TestMethod]
		[ExpectedException(typeof(System.Exception))]
		public void TestCheckMovieGenerationEqual()
		{
			Movie movie1 = new Movie(1, "SkyFall", "Sam Mendes", 2012 MovieGenre.Adventure);
			Assert.IsNotNull(repository.GetMovieById(movie1.Id));
			Assert.AreEqual(repository.GetUserById(movie1.Id), movie1);
			movie1 = repository.GetMovieById(150);
		}
	}
}