using Data.API;
using Data.DataFiles;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTests.Data
{
    [TestClass]
    public class EventTests
    {
        public IDataManager manager;

        [TestInitialize]
        public void Initialize()
        {
            manager = new DataManager();
        }

        [TestMethod]
        public void AddEventToDatabaseTest()
        {
            Assert.IsTrue(manager.AddReader(1, "Carlos Valle"));
            Assert.IsTrue(manager.AddBook(1, "El Principito", "Antoine de Saint-Exupéry"));

            Assert.IsTrue(manager.AddEvent(1, DateTime.Now, manager.GetBookByID(1).BookID, manager.GetReader(1).ReaderID));

            Assert.IsTrue(manager.DeleteEvent(manager.GetEventByID(1).EventID));
            Assert.IsTrue(manager.DeleteBook(manager.GetBookByID(1).BookID));
            Assert.IsTrue(manager.DeleteReader(manager.GetReader(1).ReaderID));
        }

        [TestMethod]
        public void UpdateEvent()
        {
            Assert.IsTrue(manager.AddReader(1, "JK Rowling"));
            Assert.IsTrue(manager.AddReader(2, "JK Rowling"));
            Assert.IsTrue(manager.AddBook(1, "Book1", "Author1"));
            Assert.IsTrue(manager.AddBook(2, "Book2", "Author2"));

            Assert.IsTrue(manager.GetBookByID(1).IsAvailable);

            Assert.IsTrue(manager.AddEvent(1, DateTime.Now, manager.GetBookByID(1).BookID, manager.GetReader(1).ReaderID));

            

            Assert.IsTrue(manager.UpdateEventBook(manager.GetEventByID(1).EventID, 2));
            Assert.IsTrue(manager.UpdateEventReader(manager.GetEventByID(1).EventID, 2));

            Assert.IsTrue(manager.GetBookByID(1).IsAvailable);

            Assert.IsTrue(manager.DeleteEvent(manager.GetEventByID(1).EventID));
            Assert.IsTrue(manager.DeleteBook(manager.GetBookByID(1).BookID));
            Assert.IsTrue(manager.DeleteBook(manager.GetBookByID(2).BookID));
            Assert.IsTrue(manager.DeleteReader(manager.GetReader(1).ReaderID));
            Assert.IsTrue(manager.DeleteReader(manager.GetReader(2).ReaderID));
        }
    }
}
