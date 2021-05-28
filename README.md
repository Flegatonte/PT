# Programming Technology Lab

## Team

| Name Surname (initials) | GUID                                     |
| ----------------------- | ---------------------------------------- |
| Gloria Fiammengo        | `{53b61a73-2df3-40b8-a850-f2a2e769e157}` |
| Carlos Valle            | `{263dbfc7-54cd-4663-9e86-42fc8242bca4}` |

# Task 1 Check list

- [ ] text is in C# and use .NET
- [ ] build succeeded
- [ ] all UT are green
- [ ] Object model representing process data
  - [ ] structured data is used to create object model
  - [ ] Users: a collection of all actors relevant to the implemented business process (e.g.: readers, customers, suppliers, etc)
  - [ ] Catalog: a dictionary of the goods descriptions (e.g.: books, good )
  - [ ] Process state: description of the current process state (e.g: the current content of the shop, library, etc.)
  - [ ] Events:  description of all events contributing to the process state change in time.
- [ ] Dependency injection (additional framework is not required)
- [ ] `Data` layer is clearly stated (no database of file access is required)
- [ ] `Data` API is abstract
- [ ] `Logic` layer is clearly stated
- [ ] `Logic` API is clearly stated
- [ ] `Logic` uses only the abstract `Data` layer API
- [ ] Unit Test - 2+ testing data generation methods
- [ ] layers are tested independently
- [ ] only code in the solution is tested

# Task 2 Check list

- [ ] text is in C# and use .NET
- [ ] build succeeded
- [ ] all UT are green
- [ ] Object model representing process data (reuse it from Task1)
- [ ] layers are clearly stated in the language terms
- [ ] `Data` layer is implemented using external SQL database and should be defined using LINQ to SQL (ORM)
- [ ] LINQ (method and query syntax) is used to fetch data from the database
- [ ] `Presentation` - his layer must be implemented in accordance with the `Model-View-ViewModel` (`MVVM`) software pattern
- [ ] `Presentation` - the Master-Detail pattern
- [ ] `View Model` must be tested using 2 independent `Model` data generation methods
- [ ] `View Model` is tested independently
- [ ] `View Model` use dependency injection for testing purpose (additional framework is not required)
- [ ] The data and controls must be bond together using the data binding mechanism
- [ ] `View` - design the appropriate GUI using `XAML` language (it should be C# codeless)
