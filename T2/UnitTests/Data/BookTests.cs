using Data.API;
using Data.DataFiles;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Data
{
    [TestClass]
    public class BookTests
    {
        public IDataManager manager;

        [TestInitialize]
        public void Initialize()
        {
            manager = new DataManager();
        }

        [TestMethod]
        public void AddBookToDatabaseTest()
        {
            Assert.IsTrue(manager.AddBook(1, "Don Quijote de la Mancha", "Miguel de Cervantes"));
            Assert.AreEqual(manager.GetBookByID(1).Name, "Don Quijote de la Mancha");
            Assert.AreEqual(manager.GetBookByID(1).Author, "Miguel de Cervantes");
            Assert.AreEqual(manager.GetBookByID(1).IsAvailable, true);

            Assert.IsTrue(manager.DeleteBook(manager.GetBookByID(1).BookID));
        }

        [TestMethod]
        public void AddSameBookToDatabaseTest()
        {
            Assert.IsTrue(manager.AddBook(1, "Harry Potter", "JK Rowling"));
            Assert.IsFalse(manager.AddBook(1, "Harry Potter", "JK Rowling"));

            Assert.IsTrue(manager.DeleteBook(manager.GetBookByID(1).BookID));
        }
    }
}
