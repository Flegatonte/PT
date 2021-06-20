using Microsoft.VisualStudio.TestTools.UnitTesting;
using Presentation.ViewModel;

namespace UnitTests.Presentation
{
    [TestClass]
    public class EventViewModelTests
    {
        [TestMethod]
        public void ViewModelInitializeRelaysTest()
        {
            EventViewModel vm = new EventViewModel();
            Assert.IsNotNull(vm.RefreshEventsCommand);
            Assert.IsNotNull(vm.AddEventCommand);
            Assert.IsNotNull(vm.DeleteEventCommand);
            Assert.IsNotNull(vm.UpdateEventBookCommand);
            Assert.IsNotNull(vm.UpdateEventReaderCommand);

            Assert.IsTrue(vm.RefreshEventsCommand.CanExecute(null));
            Assert.IsTrue(vm.AddEventCommand.CanExecute(null));
            Assert.IsTrue(vm.UpdateEventBookCommand.CanExecute(null));
            Assert.IsTrue(vm.UpdateEventReaderCommand.CanExecute(null));
            Assert.IsTrue(vm.DeleteEventCommand.CanExecute(null));
        }

        [TestMethod]
        public void AddEventCommandPopupWindowTest()
        {
            EventViewModel vm = new EventViewModel();
            Assert.IsTrue(vm.AddEventCommand.CanExecute(null));
        }

        [TestMethod]
        public void DeleteEventCommandPopupWindowTest()
        {
            EventViewModel vm = new EventViewModel();
            Assert.IsTrue(vm.DeleteEventCommand.CanExecute(null));
        }

        [TestMethod]
        public void UpdateEventCommandPopupWindowTest()
        {
            EventViewModel vm = new EventViewModel();
            vm.CurrentEvent = null;
            Assert.IsTrue(vm.UpdateEventBookCommand.CanExecute(null));
        }

        [TestMethod]
        public void RefreshEventsCommandPopupWindowTest()
        {
            EventViewModel vm = new EventViewModel();
            Assert.IsTrue(vm.UpdateEventReaderCommand.CanExecute(null));
            vm.RefreshEventsCommand.Execute(null);
        }
    }
}
