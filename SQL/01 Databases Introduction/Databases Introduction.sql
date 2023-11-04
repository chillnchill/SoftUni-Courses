--Task 1
CREATE DATABASE [Minions]

USE Minions

--Task 2
CREATE TABLE [Minions] (
	[Id] INT PRIMARY KEY,
	[Name] NVARCHAR(50) NOT NULL,
	[Age] INT,
)

CREATE TABLE [Towns] (
	[Id] INT PRIMARY KEY,
	[Name] NVARCHAR(70) NOT NULL,
)

--Task 3
ALTER TABLE [Minions]
ADD [TownId] INT FOREIGN KEY REFERENCES [Towns]([Id])

--Task 4
INSERT INTO [Towns] ([Id], [Name])
	VALUES
		(1, 'Sofia'),
		(2, 'Plovdiv'),
		(3, 'Varna')

INSERT INTO [Minions] ([Id], [Name], [Age], [TownId])
	VALUES
		(1, 'Kevin', 22, 1),
		(2, 'Bob', 15, 3),
		(3, 'Steward', NULL, 2)

--Task 5
TRUNCATE TABLE [Minions]
-- Task 6
DROP TABLE [Minions], [Towns]

--Task 7
CREATE TABLE [People] (
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(200) NOT NULL,
	[Picture] VARBINARY(MAX),
	CHECK (DATALENGTH([Picture]) < 2000000),
	[Height] DECIMAL(3, 2),
	[Weight] DECIMAL(5, 2),
	[Gender] CHAR(1) NOT NULL,
	CHECK ([Gender] = 'm' OR [Gender] = 'f'),
	[Birthdate] DATE NOT NULL,
	[Biography] NVARCHAR(MAX)
)

INSERT INTO [People] ([Name],[Height],[Weight],[Gender],[Birthdate],[Biography])
	VALUES
		('Pesho', 1.74, 69.50, 'm', '1992-06-28', 'me'),
		('Gosho', 1.64, 65.50, 'm', '1992-01-11', 'you'),
		('Stosho', 1.54, 64.50, 'm', '1992-03-23', 'they'),
		('Hosha', 1.56, 61.50, 'f', '1992-12-25', 'she'),
		('Lasha', 1.75, 63.50, 'f', '1992-07-16', 'her')

--Task 8
CREATE TABLE [Users](
	[Id] BIGINT PRIMARY KEY IDENTITY,
	[Username] VARCHAR(30) UNIQUE NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	[ProfilePicture] VARBINARY(MAX),
	CHECK (DATALENGTH([ProfilePicture]) < 900000),
	[LastLoginTime] DATETIME2,
	IsDeleted BIT
)

INSERT INTO Users (Username, Password, ProfilePicture, LastLoginTime, IsDeleted)
VALUES
    ('user1', 'password1', NULL, NULL, 0),
    ('user2', 'password2', NULL, NULL, 0),
    ('user3', 'password3', NULL, NULL, 0),
    ('user4', 'password4', NULL, NULL, 0),
    ('user5', 'password5', NULL, NULL, 0);

--Task 9
ALTER TABLE Users
DROP CONSTRAINT PK_Users

ALTER TABLE Users
ADD CONSTRAINT PK_Users PRIMARY KEY (Id, Username);

--Task 10
ALTER TABLE Users
ADD CONSTRAINT CK_PasswordMinLength CHECK (DATALENGTH([Password]) > 5)

--Task 11
ALTER TABLE Users
ADD CONSTRAINT DF_LastLoginTime DEFAULT GETDATE() FOR LastLoginTime

--Task 12
ALTER TABLE Users
DROP CONSTRAINT PK_Users;

ALTER TABLE Users
ADD CONSTRAINT PK_Users PRIMARY KEY (Id);

ALTER TABLE Users
ADD CONSTRAINT UQ_Username_Length CHECK (LEN(Username) >= 3);

--Task 13
CREATE DATABASE [Movies]
GO

USE Movies
GO

CREATE TABLE [Directors](
	[Id] INT PRIMARY KEY IDENTITY,
	[DirectorName] NVARCHAR(100) NOT NULL,
	[Notes] NVARCHAR(MAX)
)

CREATE TABLE [Genres](
	[Id] INT PRIMARY KEY IDENTITY,
	[GenreName] NVARCHAR(50) NOT NULL,
	[Notes] NVARCHAR(MAX)
)

CREATE TABLE [Categories](
	[Id] INT PRIMARY KEY IDENTITY,
	[CategoryName] NVARCHAR(50) NOT NULL,
	[Notes] NVARCHAR(MAX)
)

CREATE TABLE [Movies](
	[Id] INT PRIMARY KEY IDENTITY,
	[Title] NVARCHAR(100) NOT NULL,
	[DirectorId] INT FOREIGN KEY REFERENCES [Directors]([Id]) NOT NULL,
	[CopyrightYear] DATE,
	[Length] INT,
	[GenreId] INT FOREIGN KEY REFERENCES [Genres]([Id]) NOT NULL,
	[CategoryId] INT FOREIGN KEY REFERENCES [Categories]([Id]) NOT NULL,
	[Rating] DECIMAL(2,1),
	[Notes] VARCHAR(MAX)
)

INSERT INTO Directors (DirectorName, Notes)
VALUES
    (N'Director 1', N'Notes 1'),
    (N'Director 2', N'Notes 2'),
    (N'Director 3', N'Notes 3'),
    (N'Director 4', N'Notes 4'),
    (N'Director 5', N'Notes 5');


INSERT INTO Genres (GenreName, Notes)
VALUES
    (N'Genre 1', N'Genre Notes 1'),
    (N'Genre 2', N'Genre Notes 2'),
    (N'Genre 3', N'Genre Notes 3'),
    (N'Genre 4', N'Genre Notes 4'),
    (N'Genre 5', N'Genre Notes 5');


INSERT INTO Categories (CategoryName, Notes)
VALUES
    (N'Category 1', N'Category Notes 1'),
    (N'Category 2', N'Category Notes 2'),
    (N'Category 3', N'Category Notes 3'),
    (N'Category 4', N'Category Notes 4'),
    (N'Category 5', N'Category Notes 5');


INSERT INTO Movies (Title, DirectorId, CopyrightYear, Length, GenreId, CategoryId, Rating, Notes)
VALUES
    (N'Movie 1', 1, '2020', 120, 1, 1, 7.5, N'Movie Notes 1'),
    (N'Movie 2', 2, '2018', 105, 2, 2, 8.0, N'Movie Notes 2'),
    (N'Movie 3', 3, '2019', 95, 3, 3, 6.9, N'Movie Notes 3'),
    (N'Movie 4', 4, '2022', 130, 4, 4, 9.2, N'Movie Notes 4'),
    (N'Movie 5', 5, '2017', 112, 5, 5, 7.8, N'Movie Notes 5');


--Task 14
-- Create the CarRental database
CREATE DATABASE CarRental;
GO

-- Use the CarRental database
USE CarRental;
GO

-- Create the Categories table
CREATE TABLE Categories (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    CategoryName NVARCHAR(50) NOT NULL,
    DailyRate DECIMAL(10, 2) NOT NULL,
    WeeklyRate DECIMAL(10, 2) NOT NULL,
    MonthlyRate DECIMAL(10, 2) NOT NULL,
    WeekendRate DECIMAL(10, 2) NOT NULL
);

-- Create the Cars table
CREATE TABLE Cars (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    PlateNumber NVARCHAR(20) NOT NULL,
    Manufacturer NVARCHAR(50) NOT NULL,
    Model NVARCHAR(50) NOT NULL,
    CarYear INT NOT NULL,
    CategoryId INT,
    Doors INT NOT NULL,
    Picture VARBINARY(MAX),
    Condition NVARCHAR(100) NOT NULL,
    Available BIT NOT NULL,
    FOREIGN KEY (CategoryId) REFERENCES Categories(Id)
);

-- Create the Employees table
CREATE TABLE Employees (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    Title NVARCHAR(50),
    Notes NVARCHAR(MAX)
);

-- Create the Customers table
CREATE TABLE Customers (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    DriverLicenceNumber NVARCHAR(20) NOT NULL,
    FullName NVARCHAR(100) NOT NULL,
    Address NVARCHAR(100),
    City NVARCHAR(50),
    ZIPCode NVARCHAR(10),
    Notes NVARCHAR(MAX)
);

-- Create the RentalOrders table
CREATE TABLE RentalOrders (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    EmployeeId INT NOT NULL,
    CustomerId INT NOT NULL,
    CarId INT NOT NULL,
    TankLevel DECIMAL(5, 2) NOT NULL,
    KilometrageStart INT NOT NULL,
    KilometrageEnd INT NOT NULL,
    TotalKilometrage INT NOT NULL,
    StartDate DATETIME NOT NULL,
    EndDate DATETIME NOT NULL,
    TotalDays INT NOT NULL,
    RateApplied DECIMAL(10, 2) NOT NULL,
    TaxRate DECIMAL(5, 2) NOT NULL,
    OrderStatus NVARCHAR(50) NOT NULL,
    Notes NVARCHAR(MAX),
    FOREIGN KEY (EmployeeId) REFERENCES Employees(Id),
    FOREIGN KEY (CustomerId) REFERENCES Customers(Id),
    FOREIGN KEY (CarId) REFERENCES Cars(Id)
);

-- Insert 3 records into the Categories table
INSERT INTO Categories (CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate)
VALUES
    (N'Economy', 35.99, 249.99, 899.99, 69.99),
    (N'Compact', 45.99, 299.99, 1099.99, 79.99),
    (N'SUV', 65.99, 449.99, 1699.99, 99.99);

-- Insert 3 records into the Cars table
INSERT INTO Cars (PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Condition, Available)
VALUES
    (N'ABC123', N'Toyota', N'Corolla', 2022, 1, 4, N'Excellent', 1),
    (N'XYZ789', N'Ford', N'Focus', 2021, 2, 4, N'Good', 1),
    (N'DEF456', N'Honda', N'CR-V', 2023, 3, 4, N'New', 1);

-- Insert 3 records into the Employees table
INSERT INTO Employees (FirstName, LastName, Title, Notes)
VALUES
    (N'John', N'Doe', N'Rental Agent', N'Employee Notes 1'),
    (N'Jane', N'Smith', N'Manager', N'Employee Notes 2'),
    (N'Bob', N'Johnson', N'Rental Agent', N'Employee Notes 3');

-- Insert 3 records into the Customers table
INSERT INTO Customers (DriverLicenceNumber, FullName, Address, City, ZIPCode, Notes)
VALUES
    (N'DL12345', N'Alice Johnson', N'123 Main St', N'New York', N'10001', N'Customer Notes 1'),
    (N'DL67890', N'Bob Smith', N'456 Elm St', N'Los Angeles', N'90001', N'Customer Notes 2'),
    (N'DL54321', N'Charlie Brown', N'789 Oak St', N'Chicago', N'60601', N'Customer Notes 3');

-- Insert 3 records into the RentalOrders table
INSERT INTO RentalOrders (EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, TotalKilometrage, StartDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus, Notes)
VALUES
    (1, 1, 1, 0.75, 1000, 1500, 500, '2023-01-15', '2023-01-20', 5, 249.99, 0.08, N'Completed', N'Order Notes 1'),
    (2, 2, 2, 0.50, 500, 800, 300, '2023-02-10', '2023-02-15', 5, 299.99, 0.08, N'Completed', N'Order Notes 2'),
    (3, 3, 3, 0.90, 300, 600, 300, '2023-03-05', '2023-03-10', 5, 449.99, 0.08, N'Completed', N'Order Notes 3');


--Task 15
-- Create the Hotel database
CREATE DATABASE Hotel;
GO

-- Use the Hotel database
USE Hotel;
GO

-- Create the Employees table
CREATE TABLE Employees (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    Title NVARCHAR(50),
    Notes NVARCHAR(MAX)
);

-- Create the Customers table
CREATE TABLE Customers (
    AccountNumber NVARCHAR(20) PRIMARY KEY,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    PhoneNumber NVARCHAR(20),
    EmergencyName NVARCHAR(100),
    EmergencyNumber NVARCHAR(20),
    Notes NVARCHAR(MAX)
);

-- Create the RoomStatus table
CREATE TABLE RoomStatus (
    RoomStatus NVARCHAR(50) PRIMARY KEY,
    Notes NVARCHAR(MAX)
);

-- Create the RoomTypes table
CREATE TABLE RoomTypes (
    RoomType NVARCHAR(50) PRIMARY KEY,
    Notes NVARCHAR(MAX)
);

-- Create the BedTypes table
CREATE TABLE BedTypes (
    BedType NVARCHAR(50) PRIMARY KEY,
    Notes NVARCHAR(MAX)
);

-- Create the Rooms table
CREATE TABLE Rooms (
    RoomNumber NVARCHAR(10) PRIMARY KEY,
    RoomType NVARCHAR(50) NOT NULL,
    BedType NVARCHAR(50) NOT NULL,
    Rate DECIMAL(10, 2) NOT NULL,
    RoomStatus NVARCHAR(50) NOT NULL,
    Notes NVARCHAR(MAX),
    FOREIGN KEY (RoomType) REFERENCES RoomTypes(RoomType),
    FOREIGN KEY (BedType) REFERENCES BedTypes(BedType),
    FOREIGN KEY (RoomStatus) REFERENCES RoomStatus(RoomStatus)
);

-- Create the Payments table
CREATE TABLE Payments (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    EmployeeId INT NOT NULL,
    PaymentDate DATE NOT NULL,
    AccountNumber NVARCHAR(20) NOT NULL,
    FirstDateOccupied DATE NOT NULL,
    LastDateOccupied DATE NOT NULL,
    TotalDays INT NOT NULL,
    AmountCharged DECIMAL(10, 2) NOT NULL,
    TaxRate DECIMAL(5, 2) NOT NULL,
    TaxAmount DECIMAL(10, 2) NOT NULL,
    PaymentTotal DECIMAL(10, 2) NOT NULL,
    Notes NVARCHAR(MAX),
    FOREIGN KEY (EmployeeId) REFERENCES Employees(Id),
    FOREIGN KEY (AccountNumber) REFERENCES Customers(AccountNumber)
);

-- Create the Occupancies table
CREATE TABLE Occupancies (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    EmployeeId INT NOT NULL,
    DateOccupied DATE NOT NULL,
    AccountNumber NVARCHAR(20) NOT NULL,
    RoomNumber NVARCHAR(10) NOT NULL,
    RateApplied DECIMAL(10, 2) NOT NULL,
    PhoneCharge DECIMAL(10, 2),
    Notes NVARCHAR(MAX),
    FOREIGN KEY (EmployeeId) REFERENCES Employees(Id),
    FOREIGN KEY (AccountNumber) REFERENCES Customers(AccountNumber),
    FOREIGN KEY (RoomNumber) REFERENCES Rooms(RoomNumber)
);

-- Insert 3 records into the Employees table
INSERT INTO Employees (FirstName, LastName, Title, Notes)
VALUES
    (N'John', N'Doe', N'Receptionist', N'Employee Notes 1'),
    (N'Jane', N'Smith', N'Manager', N'Employee Notes 2'),
    (N'Bob', N'Johnson', N'Housekeeping', N'Employee Notes 3');

-- Insert 3 records into the Customers table
INSERT INTO Customers (AccountNumber, FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber, Notes)
VALUES
    (N'Cust001', N'Alice', N'Johnson', N'123-456-7890', N'Emergency Contact 1', N'987-654-3210', N'Customer Notes 1'),
    (N'Cust002', N'Bob', N'Smith', N'555-555-5555', N'Emergency Contact 2', N'555-555-5555', N'Customer Notes 2'),
    (N'Cust003', N'Charlie', N'Brown', N'111-222-3333', N'Emergency Contact 3', N'333-222-1111', N'Customer Notes 3');

-- Insert 3 records into the RoomStatus table
INSERT INTO RoomStatus (RoomStatus, Notes)
VALUES
    (N'Vacant', N'Available for booking'),
    (N'Occupied', N'Currently in use'),
    (N'Maintenance', N'Under maintenance');

-- Insert 3 records into the RoomTypes table
INSERT INTO RoomTypes (RoomType, Notes)
VALUES
    (N'Standard', N'Basic room type'),
    (N'Deluxe', N'Upgraded room type'),
    (N'Suite', N'Spacious and luxurious');

-- Insert 3 records into the BedTypes table
INSERT INTO BedTypes (BedType, Notes)
VALUES
    (N'Single', N'Single bed'),
    (N'Double', N'Double bed'),
    (N'King', N'King-sized bed');

-- Insert 3 records into the Rooms table
INSERT INTO Rooms (RoomNumber, RoomType, BedType, Rate, RoomStatus, Notes)
VALUES
    (N'101', N'Standard', N'Single', 89.99, N'Vacant', N'Room Notes 1'),
    (N'202', N'Deluxe', N'King', 129.99, N'Vacant', N'Room Notes 2'),
    (N'303', N'Suite', N'King', 199.99, N'Vacant', N'Room Notes 3');

-- Insert 3 records into the Payments table
INSERT INTO Payments (EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, TotalDays, AmountCharged, TaxRate, TaxAmount, PaymentTotal, Notes)
VALUES
    (1, '2023-01-15', N'Cust001', '2023-01-15', '2023-01-20', 5, 449.95, 0.08, 35.99, 485.94, N'Payment Notes 1'),
    (2, '2023-02-10', N'Cust002', '2023-02-10', '2023-02-15', 5, 649.95, 0.08, 51.99, 701.94, N'Payment Notes 2'),
    (3, '2023-03-05', N'Cust003', '2023-03-05', '2023-03-10', 5, 999.95, 0.08, 79.99, 1079.94, N'Payment Notes 3');

-- Insert 3 records into the Occupancies table
INSERT INTO Occupancies (EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge, Notes)
VALUES
    (1, '2023-01-15', N'Cust001', '101', 89.99, 10.00, N'Occupancy Notes 1'),
    (2, '2023-02-10', N'Cust002', '202', 129.99, 15.00, N'Occupancy Notes 2'),
    (3, '2023-03-05', N'Cust003', '303', 199.99, 20.00, N'Occupancy Notes 3');

--Task 16
-- Create the SoftUni database
CREATE DATABASE SoftUni;
GO

-- Use the SoftUni database
USE SoftUni;
GO

-- Create the Towns table
CREATE TABLE Towns (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(50) NOT NULL
);

-- Create the Addresses table
CREATE TABLE Addresses (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    AddressText NVARCHAR(100) NOT NULL,
    TownId INT NOT NULL,
    FOREIGN KEY (TownId) REFERENCES Towns(Id)
);

-- Create the Departments table
CREATE TABLE Departments (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(50) NOT NULL
);

-- Create the Employees table
CREATE TABLE Employees (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(50) NOT NULL,
    MiddleName NVARCHAR(50),
    LastName NVARCHAR(50) NOT NULL,
    JobTitle NVARCHAR(100) NOT NULL,
    DepartmentId INT NOT NULL,
    HireDate DATE NOT NULL,
    Salary DECIMAL(10, 2) NOT NULL,
    AddressId INT NOT NULL,
    FOREIGN KEY (DepartmentId) REFERENCES Departments(Id),
    FOREIGN KEY (AddressId) REFERENCES Addresses(Id)
);

--Task 17
--With Query
BACKUP DATABASE [SoftUni]
	TO DISK = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\Backup\soft-uni.bak' WITH NOFORMAT,
	NOINIT,
	NAME = N'SoftUni-Full Database Backup',
	SKIP,
	NOREWIND,
	NOUNLOAD,
	STATS = 10
GO
--Task 18

-- Insert data into the Towns table
INSERT INTO Towns (Name)
VALUES
    ('Sofia'),
    ('Plovdiv'),
    ('Varna'),
    ('Burgas');

-- Insert data into the Departments table
INSERT INTO Departments (Name)
VALUES
    ('Engineering'),
    ('Sales'),
    ('Marketing'),
    ('Software Development'),
    ('Quality Assurance');
--Insert data into the Addresses table

INSERT INTO Addresses (AddressText,TownId)
VALUES
	('123 Main Street', 1),
    ('456 Elm Street', 2),
    ('789 Oak Street', 3),
    ('101 Maple Street', 4),
    ('202 Pine Street', 1);
-- Insert data into the Employees table
INSERT INTO Employees (FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary, AddressId)
VALUES
    ('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, '2013-01-02', 3500.00, 1),
    ('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '2004-03-02', 4000.00, 2),
    ('Maria', 'Petrova', 'Ivanova', 'Intern', 5, '2016-08-28', 525.25, 3),
    ('Georgi', 'Teziev', 'Ivanov', 'CEO', 2, '2007-12-09', 3000.00, 4),
    ('Peter', 'Pan', 'Pan', 'Intern', 3, '2016-08-28', 599.88, 3);

--Task 19
SELECT * 
FROM Towns 

SELECT *
FROM Departments

SELECT *
FROM Employees


--Task 20
SELECT * 
FROM [Towns] 
ORDER BY [Name]

SELECT *
FROM [Departments]
ORDER BY [Name]

SELECT *
FROM [Employees]
ORDER BY [Salary] DESC

--Task 21
SELECT [Name]
FROM [Towns] 
ORDER BY [Name]

SELECT [Name]
FROM [Departments]
ORDER BY [Name]

SELECT FirstName,LastName,JobTitle,Salary
FROM [Employees]
ORDER BY [Salary] DESC

--Task 22
UPDATE [Employees]
SET [Salary] = [Salary] * 1.1;

SELECT Salary
FROM [Employees]

--Task 23
USE Hotel

GO

UPDATE Payments
SET TaxRate = TaxRate * 0.97;

SELECT TaxRate
FROM Payments

--Task 24
TRUNCATE TABLE Occupancies