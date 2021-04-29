using Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
	[TestClass]
	public class RandomValGenTest
	{
		private IRepository repository;
		private IDataGenerator generator;
		private DataContext context;

		[TestInitialize]
		public void Initialize()
		{
			context = new DataContext();
			repository = new DataRepository(context);
			generator = new RandomValuesGenerator();
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
			Assert.AreEqual(repository.GetAllMoviesNumber(), 8);
			Assert.AreEqual(repository.GetAllUsersNumber(), 8);
			Assert.AreEqual(repository.GetAllEventsNumber(), 0);
		}
	}
}