using Microsoft.VisualStudio.TestTools.UnitTesting;
using Presentation.ViewModel;

namespace UnitTests.Presentation
{
    [TestClass]
    public class BookViewModelTests
    {
        [TestMethod]
        public void ViewModelInitializeRelaysTest()
        {
            BookViewModel vm = new BookViewModel();
            Assert.IsNotNull(vm.RefreshBooksCommand);
            Assert.IsNotNull(vm.AddBookCommand);
            Assert.IsNotNull(vm.UpdateBookCommand);
            Assert.IsNotNull(vm.DeleteBookCommand);
            Assert.IsNotNull(vm.ShowEventsCommand);

            Assert.IsTrue(vm.RefreshBooksCommand.CanExecute(null));
            Assert.IsTrue(vm.AddBookCommand.CanExecute(null));
            Assert.IsTrue(vm.UpdateBookCommand.CanExecute(null));
            Assert.IsTrue(vm.DeleteBookCommand.CanExecute(null));
            Assert.IsTrue(vm.ShowEventsCommand.CanExecute(null));
            Assert.IsTrue(vm.ShowEventsCommand.CanExecute(null));
        }

        [TestMethod]
        public void AddBookCommandPopupWindowTest()
        {
            BookViewModel vm = new BookViewModel();
            Assert.IsTrue(vm.AddBookCommand.CanExecute(null));
        }

        [TestMethod]
        public void DeleteBookCommandPopupWindowTest()
        {
            BookViewModel vm = new BookViewModel();
            Assert.IsTrue(vm.DeleteBookCommand.CanExecute(null));
        }

        [TestMethod]
        public void UpdateBookCommandPopupWindowTest()
        {
            BookViewModel vm = new BookViewModel();
            vm.CurrentBook = null;
            Assert.IsTrue(vm.UpdateBookCommand.CanExecute(null));
        }

        [TestMethod]
        public void RefreshBooksCommandPopupWindowTest()
        {
            BookViewModel vm = new BookViewModel();
            Assert.IsTrue(vm.RefreshBooksCommand.CanExecute(null));
            vm.RefreshBooksCommand.Execute(null);
        }
    }
}
