using Data.API;
using Data.DataFiles;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service.DataFiles;

namespace UnitTests.Service
{
    [TestClass]
    public class BookTests
    {
        public IDataManager manager;
        public BookService service;

        [TestInitialize]
        public void Initialize()
        {
            manager = new DataManager();
            service = new BookService(manager);
        }
        [TestMethod]
        public void AddBookToDatabaseTest()
        {
            Assert.IsTrue(service.AddBook(1, "Book1", "Author1"));
            Assert.AreEqual(service.GetBookByID(1).Name, "Book1");
            Assert.AreEqual(service.GetBookByID(1).BookID, 1);
            Assert.AreEqual(service.GetBookByID(1).Author, "Author1");
            Assert.AreEqual(service.GetBookByID(1).IsAvailable, true);

            Assert.IsTrue(service.DeleteBook(service.GetBookByID(1).BookID));
        }

        [TestMethod]
        public void AddSameBookToDatabaseTest()
        {
            Assert.IsTrue(service.AddBook(1, "Book1", "Author1"));
            Assert.IsFalse(service.AddBook(1, "Book1", "Author1"));

            Assert.IsTrue(service.DeleteBook(service.GetBookByID(1).BookID));
        }

        [TestMethod]
        public void GetBooksByName()
        {
            Assert.IsTrue(service.AddBook(1, "Book2", "Author2"));
            Assert.IsTrue(service.AddBook(2, "Book2", "Author2"));

           

            Assert.IsTrue(service.DeleteBook(service.GetBookByID(1).BookID));
            Assert.IsTrue(service.DeleteBook(service.GetBookByID(2).BookID));
        }
    }
}