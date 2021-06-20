using Data.API;
using Data.DataFiles;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service.API;
using Service.DataFiles;

namespace UnitTests.Service
{
    [TestClass]
    public class ReaderTests
    {
        public IDataManager manager;
        public IReaderService service;

        [TestInitialize]
        public void Initialize()
        {
            manager = new DataManager();
            service = new ReaderService(manager);
        }

        [TestMethod]
        public void AddReaderToDatabaseTest()
        {
            Assert.IsTrue(service.AddReader(1, "Reader1"));
            Assert.AreEqual(service.GetReader(1).Name, "Reader1");
            Assert.AreEqual(service.GetReader(1).ReaderID, 1);

            Assert.IsTrue(service.DeleteReader(service.GetReader(1).ReaderID));
        }

        [TestMethod]
        public void UpdateReaderTest()
        {
            Assert.IsTrue(service.AddReader(1, "Reader2"));
            Assert.IsTrue(service.UpdateReader(service.GetReader(1).ReaderID, "Reader2"));

            Assert.AreEqual(service.GetReader(1).Name, "Reader3");
            Assert.AreEqual(service.GetReader(1).ReaderID, 1);

            Assert.IsTrue(service.DeleteReader(service.GetReader(1).ReaderID));
        }

        [TestMethod]
        public void AddSameReaderTest()
        {
            Assert.IsTrue(service.AddReader(1, "Reader4"));
            Assert.IsFalse(service.AddReader(1, "Reader4"));

            Assert.IsTrue(service.DeleteReader(service.GetReader(1).ReaderID));
        }
    }
}
