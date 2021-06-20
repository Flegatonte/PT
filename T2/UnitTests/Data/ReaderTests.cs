using Data.API;
using Data.DataFiles;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Data
{
    [TestClass]
    public class ReaderTests
    {
        public IDataManager manager;

        [TestInitialize]
        public void Initialize()
        {
            manager = new DataManager();
        }

        [TestMethod]
        public void AddReaderToDatabaseTest()
        {
            Assert.IsTrue(manager.AddReader(1, "Valle"));
            Assert.AreEqual(manager.GetReader(1).Name, "Valle");
            Assert.AreEqual(manager.GetReader(1).ReaderID, 1);

            Assert.IsTrue(manager.DeleteReader(manager.GetReader(1).ReaderID));
        }

        [TestMethod]
        public void UpdateReaderTest()
        {
            Assert.IsTrue(manager.AddReader(1, "Miguel"));
            Assert.IsTrue(manager.UpdateReader(manager.GetReader(1).ReaderID, "Sergio"));

            Assert.AreEqual(manager.GetReader(1).Name, "Sergio");
            Assert.AreEqual(manager.GetReader(1).ReaderID, 1);

            Assert.IsTrue(manager.DeleteReader(manager.GetReader(1).ReaderID));
        }

        [TestMethod]
        public void AddSameReaderTest()
        {
            Assert.IsTrue(manager.AddReader(1, "Gloria"));
            Assert.IsFalse(manager.AddReader(1, "Gloria"));

            Assert.IsTrue(manager.DeleteReader(manager.GetReader(1).ReaderID));
        }
    }
}
