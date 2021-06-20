using Presentation.ViewModel.MVVM;
using Service.API;
using Service.DataFiles;
using System;
using System.Collections.Generic;

namespace Presentation.ViewModel
{
    public class EventViewModel : ViewModelBase
    {
        private IEventService service;
        public EventViewModel(EventService service)
        {
            this.service = service;
        }
        public EventViewModel()
        {
            service = new EventService();
            AddEventCommand = new RelayCommand(AddEvent);
            UpdateEventBookCommand = new RelayCommand(UpdateEventBook);
            UpdateEventReaderCommand = new RelayCommand(UpdateEventReader);
            DeleteEventCommand = new RelayCommand(DeleteEvent);
            RefreshEventsCommand = new RelayCommand(RefreshEvents);
        }

        private int eventId;
        public int EventID
        {
            get
            {
                return eventId;
            }
            set
            {
                eventId = value;
                OnPropertyChanged("EventID");
            }
        }
        private int bookId;
        public int BookID
        {
            get
            {
                return bookId;
            }
            set
            {
                bookId = value;
                OnPropertyChanged("BookID");
            }
        }
        private int readerId;
        public int ReaderID
        {
            get
            {
                return readerId;
            }
            set
            {
                readerId = value;
                OnPropertyChanged("ReaderID");
            }
        }

        public RelayCommand AddEventCommand { get; private set; }
        public RelayCommand UpdateEventBookCommand { get; private set; }
        public RelayCommand UpdateEventReaderCommand { get; private set; }
        public RelayCommand DeleteEventCommand { get; private set; }
        public RelayCommand RefreshEventsCommand { get; private set; }

        private void AddEvent()
        {
            bool added = service.AddEvent(EventID, DateTime.Now, BookID, ReaderID);
            if (added)
            {
                text = "Borrow added";
            }
            else
            {
                text = "Cannot add Borrow";
            }
            MessageBoxShowDelegate(Text);
        }

        private IEventData currentEvent;
        public IEventData CurrentEvent
        {
            get => currentEvent;
            set
            {
                currentEvent = value;
                OnPropertyChanged("CurrentEvent");
            }
        }
        private void UpdateEventBook()
        {
            bool updated = service.UpdateEventBook(EventID, BookID);
            if (updated)
            {
                text = "Borrowed book updated";
            }
            else
            {
                text = "Cannot update borrowed book";
            }
            MessageBoxShowDelegate(Text);
        }
        private void UpdateEventReader()
        {
            bool updated = service.UpdateEventReader(EventID, ReaderID);
            if (updated)
            {
                text = "Borrowing reader updated";
            }
            else
            {
                text = "Cannot update borrowing reader";
            }
            MessageBoxShowDelegate(Text);
        }

        private void DeleteEvent()
        {
            bool deleted = service.DeleteEvent(EventID);
            if (deleted)
            {
                text = "Borrow deleted";
            }
            else
            {
                text = "Cannot delete Borrow";
            }
            MessageBoxShowDelegate(Text);
        }

        private void RefreshEvents()
        {
            Events = service.GetEvents();
        }

        private IEnumerable<IEventData> events;
        public IEnumerable<IEventData> Events
        {
            get
            {
                return events;
            }
            set
            {
                events = value;
                OnPropertyChanged("Events");
            }
        }

        private string text;
        public string Text
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
                OnPropertyChanged("Text");
            }
        }

        public Action<string> MessageBoxShowDelegate { get; set; } = x => throw new ArgumentOutOfRangeException($"The delegate {nameof(MessageBoxShowDelegate)} must be assigned by the view layer");
    }
}
