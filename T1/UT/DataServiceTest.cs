using System;
using System.Collections.Generic;
using Data;
using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UT
{
	[TestClass]
	public class DataServiceTest
	{
		private DataService service;
		private Data data;
		private IDataGenerator generator;

		[TestInitialize]
		public void Initialize()
		{
			data = new Data();
			service = new DataService(new DataManager(data));
			generator = new DataGenerator();
			generator.GenarateData(data);
		}

		// Test for readers
		[TestMethod]
		public void AddReaderTest()
		{
			Assert.AreEqual(service.GetUsersCount(), 5);

			service.AddUser(new User("Andrea", "Sannino", 102036, "+39-845-5211-76");

			Assert.AreEqual(service.GetUsersCount(), 6);

			List<User> users = service.GetUsers();
			Assert.AreEqual(users.Count, 6);
			Assert.IsTrue(users.Exists(r => r.UserID == 102036));
		}

		[TestMethod]
		[ExpectedException(typeof(System.Exception))]
		public void AddReaderReapetedIDTest()
		{
			service.AddUser(new User("Vania", "Basso", 102036, "+39-845-5211-76"));
			service.AddUser(new User("Manfredi", "Sannino", 102036, "+39-845-5211-76"));
			Assert.AreEqual(service.GetUsersCount(), 6);
		}

		[TestMethod]
		public void DeleteUserTest()
		{
			Assert.AreEqual(service.GetUsersCount(), 5);
			service.DeleteUser(102036);
			Assert.AreEqual(service.GetUsersCount(), 4);
		}

		[TestMethod]
		public void DeleteNonExistingUserTest()
		{
			Assert.ThrowsException<InvalidOperationException>(
				() => service.DeleteUser(102040));
		}

		[TestMethod]
		public void GetUserByIDTest()
		{
			User returnedUser = service.GetUserByID(102036);

			Assert.IsNotNull(returnedUser);
			Assert.AreEqual(returnedUser.UserID, 102036);
			Assert.AreEqual(returnedUser.Name, "Andrea");
			Assert.AreEqual(returnedUser.Surname, "Sannino");
			Assert.AreEqual(returnedUser.PhoneNumber, "+39-845-5211-76");
		}

		[TestMethod]
		public void GetNonExistingUserByIdTest()
		{
			Assert.ThrowsException<Exception>(
				() => service.GetUserByID(102050));
		}


		[TestMethod]
		public void GetAllUsersTest()
		{
			List<Reader> allUsers = service.GetAllUsers();
			Assert.AreEqual(allReaders.Count, 5);

			Assert.IsTrue(allUsers.Exists(r => r.Id == 102036));
			Assert.IsTrue(allUsers.Exists(r => r.Id == 102033));
			Assert.IsTrue(allUsers.Exists(r => r.Id == 102032));
			Assert.IsFalse(allUsers.Exists(r => r.Id == 102));
		}


		[TestMethod]
		public void UpdateInfoAboutReaderTest()
		{
			User newUserData = new User("Andy", "Bassano", 102037, "+39-855-5200-76");

			Assert.AreEqual(service.GetUserByID(102030).PhoneNumber, "+48-885-5610-71");
			Assert.AreEqual(service.GetUserByID(102030).Name, "Adam");
			Assert.AreEqual(service.GetUserByID(102030).Surname, "Barna");
			service.UpdateUserInfo(newUserData);
			Assert.AreEqual(service.GetUserByID(102030).PhoneNumber, "+39-855-5200-76");
			Assert.AreEqual(service.GetUserByID(102030).Name, "Andy");
			Assert.AreEqual(service.GetUserByID(102030).Surname, "Bassano");
		}

		/// <summary>
		/// [TestMethod]
		/* public void UpdateInfoAboutNonExistingReaderTest()
		{
			Reader newReaderData = new Reader("Armaan", "Moran", 12, 5);
			Assert.ThrowsException<InvalidOperationException>(
				() => service.EditReader(newReaderData));
		} */
		/// </summary>



		// Tests for book catalog
		[TestMethod]
		public void AddMovieTest()
		{
			Assert.AreEqual(service.GetMoviesCount(), 5);
			Movie movie5 = new Movie(92835345, "A Game of Thrones", "George R.R.Martin", 1996, Movie.MovieGenre.Action, 130);

			Assert.AreEqual(service.GetMoviesCount(), 6);
		}

		[TestMethod]
		public void DeleteMovieTest()
		{
			Assert.AreEqual(service.GetMoviesCount(), 5);
			service.DeleteMovie(32433234);
			Assert.AreEqual(service.GetMoviesCount(), 4);
		}

		/*
		[TestMethod]
		public void GetAllBooksTest()
		{
			Dictionary<int, Book> allBooks = service.GetAllBooks();
			Assert.AreEqual(allBooks.Count, 5);

			Assert.IsTrue(allBooks.ContainsKey(1));
			Assert.IsTrue(allBooks.ContainsKey(2));
			Assert.IsTrue(allBooks.ContainsKey(3));
			Assert.IsTrue(allBooks.ContainsKey(4));
			Assert.IsTrue(allBooks.ContainsKey(5));

			Assert.IsTrue(allBooks.ContainsValue(allBooks[1]));
			Assert.IsTrue(allBooks.ContainsValue(allBooks[2]));
			Assert.IsTrue(allBooks.ContainsValue(allBooks[3]));
			Assert.IsTrue(allBooks.ContainsValue(allBooks[4]));
			Assert.IsTrue(allBooks.ContainsValue(allBooks[5]));
		}
		*/
		/*

		[TestMethod]
		public void AddBookWithTheSameIdTest()
		{
			Assert.ThrowsException<Exception>(
				() => service.AddBook(new Book(1, "A Game of Thrones", "George R.R.Martin", 1996, BookGenre.Fantasy)));
		}

		[TestMethod]
		public void DeleteNonExistingBookTest()
		{
			Assert.ThrowsException<InvalidOperationException>(
				() => service.DeleteBook(150));
		}

		[TestMethod]
		public void GetBookByIdTest()
		{
			Book returnedBook = service.GetBookById(1);

			Assert.IsNotNull(returnedBook);
			Assert.AreEqual(returnedBook.Id, 1);
			Assert.AreEqual(returnedBook.Title, "Lord of the Rings");
			Assert.AreEqual(returnedBook.Author, "J.R.R.Tolkien");
			Assert.AreEqual(returnedBook.PublishmentYear, 1954);
			Assert.AreEqual(returnedBook.Genre, BookGenre.Adventure);
		}

		[TestMethod]
		[ExpectedException(typeof(System.Exception))]
		public void GetNonExistingBookByIdTest()
		{
			Book returnedBook = service.GetBookById(15);

			Assert.IsNull(returnedBook);
			Assert.AreNotEqual(returnedBook.Id, 5);
			Assert.AreNotEqual(returnedBook.Title, "A Game of Thrones");
			Assert.AreNotEqual(returnedBook.Genre, BookGenre.Fantasy);
		}

		[TestMethod]
		public void UpdateInfoAboutBookTest()
		{
			Book newBookData = new Book(2, "A Clash of Kings", "George R.R.Martin", 1998, BookGenre.Fantasy);

			Assert.AreEqual(service.GetBookById(2).PublishmentYear, 1997);
			service.EditBook(newBookData);
			Assert.AreEqual(service.GetBookById(2).PublishmentYear, 1998);
		}

		[TestMethod]
		public void UpdateInfoAboutNonExistingBookTest()
		{
			Book newBookData = new Book(1231, "A Clash of Kings", "George R.R.Martin", 1998, BookGenre.Fantasy);
			Assert.ThrowsException<InvalidOperationException>(
				() => service.EditBook(newBookData));

		}

		[TestMethod]
		public void GetFirstBookByGenreTest()
		{
			Book returnedBook = service.GetBookByGenre(BookGenre.Fantasy);

			Assert.IsNotNull(returnedBook);
			Assert.AreEqual(returnedBook.Id, 2);
			Assert.AreEqual(returnedBook.Title, "Harry Potter");
			Assert.AreEqual(returnedBook.Genre, BookGenre.Fantasy);
		}


		//Test for states
		[TestMethod]
		public void AddNewBooktateToInventoryTest()
		{
			Book book1 = new Book(6, "A Game of Thrones", "George R.R.Martin", 1996, BookGenre.Fantasy);
			Book book2 = new Book(7, "The Notebook", "Nicholas Sparks", 1997, BookGenre.Romance);

			Assert.AreEqual(service.GetAmountOfAvailableCopiesById(6), 0);
			Assert.AreEqual(service.GetAmountOfAvailableCopiesById(7), 0);

			service.AddNewBookState(6, 5);
			service.AddNewBookState(7, 8);

			Assert.AreEqual(service.GetAmountOfAvailableCopiesById(6), 5);
			Assert.AreEqual(service.GetAmountOfAvailableCopiesById(7), 8);
		}


		[TestMethod]
		public void DeleteBookStateFromInventoryTest()
		{
			Assert.AreEqual(service.GetAmountOfAvailableCopiesById(2), 10);
			service.DeleteBookstate(2);
			Assert.AreEqual(service.GetAmountOfAvailableCopiesById(2), 0);
		}

		[TestMethod]
		public void AddExistingStateBookToInventoryTest()
		{
			Book book1 = new Book(1, "A Game of Thrones", "George R.R.Martin", 1996, BookGenre.Fantasy);

			Assert.ThrowsException<Exception>(() => service.AddNewBookState(1, 6));
			Assert.AreEqual(service.GetAmountOfAvailableCopiesById(1), 10);
			Assert.AreEqual(service.GetBookById(1).Title, "Lord of the Rings");
		}

		[TestMethod]
		public void DeleteNonExistingBookFromInventoryTest()
		{
			Assert.ThrowsException<InvalidOperationException>(() => service.DeleteBookstate(70));
		}

		[TestMethod]
		public void GetAllStatesTest()
		{
			Dictionary<int, int> allAvailableBooks = service.GetAllAvailableBooks();
			Assert.AreEqual(allAvailableBooks.Count, 5);

			Assert.IsTrue(allAvailableBooks.ContainsKey(1));
			Assert.IsTrue(allAvailableBooks.ContainsKey(2));
			Assert.IsTrue(allAvailableBooks.ContainsKey(3));
			Assert.IsTrue(allAvailableBooks.ContainsKey(4));
			Assert.IsTrue(allAvailableBooks.ContainsKey(5));

			Assert.IsTrue(allAvailableBooks.ContainsValue(10));
		}

		[TestMethod]
		public void UpdateBookStateTest()
		{
			service.UpdateStock(1, 6);
			service.UpdateStock(5, 20);

			Assert.AreEqual(service.GetAmountOfAvailableCopiesById(1), 6);
			Assert.AreEqual(service.GetAmountOfAvailableCopiesById(5), 20);
			Assert.AreEqual(service.GetAmountOfAvailableCopiesById(2), 10);
		}

		[TestMethod]
		public void UpdateBookStateNegativeTest()
		{
			Assert.ThrowsException<InvalidOperationException>(() => service.UpdateStock(2, -2));
			Assert.AreEqual(service.GetAmountOfAvailableCopiesById(2), 10);
		}

		[TestMethod]
		public void UpdateBookStateNonExistingTest()
		{
			Assert.ThrowsException<Exception>(() => service.UpdateStock(10, 10));
			Assert.AreEqual(service.GetAmountOfAvailableCopiesById(10), 0);
		}

		[TestMethod]
		public void GetStateTest()
		{
			Dictionary<int, int> allAvailableBooks = service.GetAllAvailableBooks();
			Assert.AreEqual(service.GetAllAvailableBooks(), allAvailableBooks);
		}


		//Test for events		
		[TestMethod]
		public void GetAllEventsTest()
		{
			List<Event> allEvents = service.GetAllEvents();
			Assert.AreEqual(allEvents.Count, 5);

			Assert.IsTrue(allEvents.Exists(e => e.Id == 1));
			Assert.IsTrue(allEvents.Exists(e => e.Id == 2));
			Assert.IsTrue(allEvents.Exists(e => e.Id == 3));
			Assert.IsTrue(allEvents.Exists(e => e.Id == 4));
			Assert.IsTrue(allEvents.Exists(e => e.Id == 5));
		}

		[TestMethod]
		public void GetEventByIdTest()
		{
			Event returnedEvent = service.GetEventById(1);

			Assert.IsNotNull(returnedEvent);
			Assert.AreEqual(returnedEvent.Id, 1);
			Assert.AreEqual(returnedEvent.Date, new DateTime(2020, 11, 16, 12, 0, 0));
			Assert.AreEqual(returnedEvent.Reader, service.GetReaderById(102030));
			Assert.AreEqual(returnedEvent.State, service.GetStateLibrary());
		}


		[TestMethod]
		public void GetNonExistingEventByIdTest()
		{
			Assert.ThrowsException<Exception>(() => service.GetEventById(10));

		}

		[TestMethod]
		public void UpdateInfoAboutEventTest()
		{
			BorrowingEvent newBorrowingEvent = new BorrowingEvent(1, service.GetReaderById(102031), service.GetStateLibrary(), new DateTime(2020, 11, 26, 15, 0, 0));

			Assert.AreEqual(service.GetEventById(1).Date, new DateTime(2020, 11, 16, 12, 0, 0));
			Assert.AreEqual(service.GetEventById(1).Reader, service.GetReaderById(102030));
			service.EditEvent(newBorrowingEvent);
			Assert.AreEqual(service.GetEventById(1).Date, new DateTime(2020, 11, 26, 15, 0, 0));
			Assert.AreEqual(service.GetEventById(1).Reader, service.GetReaderById(102031));
		}

		[TestMethod]
		public void UpdateInfoAboutNonExistingEventTest()
		{
			BorrowingEvent newBorrowingEvent = new BorrowingEvent(6, service.GetReaderById(102032), service.GetStateLibrary(), new DateTime(2020, 11, 26, 12, 0, 0));
			Assert.ThrowsException<InvalidOperationException>(() => service.EditEvent(newBorrowingEvent));
		}


		//Tests for borrowing and returning events
		[TestMethod]
		public void BorrowBookTest()
		{
			Assert.AreEqual(service.GetReaderById(102030).AmountOfBooksBorrowed, 4);
			Assert.AreEqual(service.GetAllEventsNumber(), 5);
			Assert.AreEqual(service.GetAmountOfAvailableCopiesById(1), 10);

			service.borrowBook(102030, 6, 1, DateTime.Now);

			Assert.AreEqual(service.GetReaderById(102030).AmountOfBooksBorrowed, 5);
			Assert.AreEqual(service.GetAllEventsNumber(), 6);
			Assert.AreEqual(service.GetAmountOfAvailableCopiesById(1), 9);
		}

		[TestMethod]
		public void BorrowBookNoCopiesInInventoryTest()
		{
			service.borrowBook(102030, 6, 1, DateTime.Now);
			service.borrowBook(102031, 7, 1, DateTime.Now);
			service.borrowBook(102032, 8, 1, DateTime.Now);
			service.borrowBook(102033, 9, 1, DateTime.Now);
			service.borrowBook(102034, 10, 1, DateTime.Now);
			service.borrowBook(102030, 11, 1, DateTime.Now);
			service.borrowBook(102031, 12, 1, DateTime.Now);
			service.borrowBook(102032, 13, 1, DateTime.Now);
			service.borrowBook(102033, 14, 1, DateTime.Now);
			service.borrowBook(102034, 15, 1, DateTime.Now);
			Assert.AreEqual(service.GetAllEventsNumber(), 15);
			Assert.AreEqual(service.GetAmountOfAvailableCopiesById(1), 0);

			var ex = Assert.ThrowsException<InvalidOperationException>(() => service.borrowBook(102030, 11, 1, DateTime.Now));
			Assert.AreSame(ex.Message, "The book is unavailable for borrowing.");
		}

		[TestMethod]
		public void ReturnBookTest()
		{
			service.borrowBook(102031, 6, 1, DateTime.Now);
			Assert.AreEqual(service.GetReaderById(102031).AmountOfBooksBorrowed, 1);
			Assert.AreEqual(service.GetAmountOfAvailableCopiesById(1), 9);

			service.returnBook(102031, 7, 1, DateTime.Now);
			Assert.AreEqual(service.GetReaderById(102031).AmountOfBooksBorrowed, 0);
			Assert.AreEqual(service.GetAmountOfAvailableCopiesById(1), 10);
		}

		[TestMethod]
		public void GetEventsForReaderTest()
		{
			List<Event> events = (List<Event>)service.GetEventsForReader(102030);
			Assert.IsNotNull(events);
			Assert.AreEqual(events.Count, 4);
			Assert.IsTrue(events.Exists(e => e.Id == 1));
			Assert.IsTrue(events.Exists(e => e.Id == 2));
			Assert.IsFalse(events.Exists(e => e.Id == 3));
			Assert.IsTrue(events.Exists(e => e.Id == 4));
			Assert.IsTrue(events.Exists(e => e.Id == 5));
		}

		[TestMethod]
		public void GetEventsForReaderNullTest()
		{
			List<Event> events = (List<Event>)service.GetEventsForReader(102034);
			Assert.AreEqual(events.Count, 0);
		}

		[TestMethod]
		public void GetEventsBetweenDatesTest()
		{
			List<Event> events = (List<Event>)service.GetEventsBetweenDates(new DateTime(2020, 11, 16, 12, 0, 0), new DateTime(2020, 11, 16, 13, 0, 0));
			Assert.IsNotNull(events);
			Assert.IsTrue(events.Exists(e => e.Id == 1));
			Assert.IsTrue(events.Exists(e => e.Id == 2));
			Assert.IsFalse(events.Exists(e => e.Id == 3));
			Assert.IsTrue(events.Exists(e => e.Id == 4));
			Assert.IsTrue(events.Exists(e => e.Id == 5));
		}
	}
	*/
}
