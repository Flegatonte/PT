using Microsoft.VisualStudio.TestTools.UnitTesting;
using Presentation.ViewModel;

namespace UnitTests.Presentation
{
    [TestClass]
    public class ReaderViewModelTests
    {
        [TestMethod]
        public void ViewModelInitializeRelaysTest()
        {
            ReaderViewModel vm = new ReaderViewModel();
            Assert.IsNotNull(vm.RefreshReadersCommand);
            Assert.IsNotNull(vm.AddReaderCommand);
            Assert.IsNotNull(vm.DeleteReaderCommand);
            Assert.IsNotNull(vm.UpdateReaderCommand);
            Assert.IsNotNull(vm.ShowBooksCommand);

            Assert.IsTrue(vm.RefreshReadersCommand.CanExecute(null));
            Assert.IsTrue(vm.AddReaderCommand.CanExecute(null));
            Assert.IsTrue(vm.DeleteReaderCommand.CanExecute(null));
            Assert.IsTrue(vm.UpdateReaderCommand.CanExecute(null));
            Assert.IsTrue(vm.ShowBooksCommand.CanExecute(null));
        }

        [TestMethod]
        public void AddReaderCommandPopupWindowTest()
        {
            ReaderViewModel vm = new ReaderViewModel();
            Assert.IsTrue(vm.AddReaderCommand.CanExecute(null));
        }

        [TestMethod]
        public void DeleteReaderCommandPopupWindowTest()
        {
            ReaderViewModel vm = new ReaderViewModel();
            Assert.IsTrue(vm.DeleteReaderCommand.CanExecute(null));
        }

        [TestMethod]
        public void UpdateReaderCommandPopupWindowTest()
        {
            ReaderViewModel vm = new ReaderViewModel();
            vm.CurrentReader = null;
            Assert.IsTrue(vm.UpdateReaderCommand.CanExecute(null));
        }

        [TestMethod]
        public void RefreshReadersCommandPopupWindowTest()
        {
            ReaderViewModel vm = new ReaderViewModel();
            Assert.IsTrue(vm.ShowBooksCommand.CanExecute(null));
            vm.RefreshReadersCommand.Execute(null);
        }
    }
}
