-- Create the Accounting database
CREATE DATABASE Accounting

-- Use the Accounting database
USE Accounting

-- Create the Countries table
CREATE TABLE Countries (
    Id INT PRIMARY KEY IDENTITY,
    [Name] NVARCHAR(10) NOT NULL
);

-- Create the Addresses table with foreign key relationships
CREATE TABLE Addresses (
    Id INT PRIMARY KEY IDENTITY,
    StreetName NVARCHAR(20) NOT NULL,
    StreetNumber INT,
    PostCode INT NOT NULL,
    City NVARCHAR(25) NOT NULL,
    CountryId INT FOREIGN KEY REFERENCES Countries(Id) NOT NULL
)

-- Create the Vendors table with foreign key relationship
CREATE TABLE Vendors (
    Id INT PRIMARY KEY IDENTITY,
    [Name] NVARCHAR(25) NOT NULL,
    NumberVAT NVARCHAR(15) NOT NULL,
    AddressId INT FOREIGN KEY REFERENCES Addresses(Id) NOT NULL
)

-- Create the Clients table with foreign key relationship
CREATE TABLE Clients (
    Id INT PRIMARY KEY IDENTITY,
    [Name] NVARCHAR(25) NOT NULL,
    NumberVAT NVARCHAR(15) NOT NULL,
    AddressId INT FOREIGN KEY REFERENCES Addresses(Id) NOT NULL
)

CREATE TABLE Categories (
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(10) NOT NULL
)

-- Create the Products table with foreign key relationships
CREATE TABLE Products (
    Id INT PRIMARY KEY IDENTITY,
    [Name] NVARCHAR(35) NOT NULL,
    Price DECIMAL(18, 2) NOT NULL,
    CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
    VendorId INT FOREIGN KEY REFERENCES Vendors(Id) NOT NULL
)

-- Create the Invoices table with foreign key relationship
CREATE TABLE Invoices (
    Id INT PRIMARY KEY IDENTITY,
    Number INT UNIQUE NOT NULL,
    IssueDate DATETIME2 NOT NULL,
    DueDate DATETIME2 NOT NULL,
    Amount DECIMAL(18, 2) NOT NULL,
    Currency NVARCHAR(5) NOT NULL,
    ClientId INT FOREIGN KEY REFERENCES Clients(Id) NOT NULL
)

-- Create the ProductsClients table with foreign key relationships
CREATE TABLE ProductsClients (
    ProductId INT FOREIGN KEY REFERENCES Products(Id) NOT NULL,
    ClientId INT FOREIGN KEY REFERENCES Clients(Id) NOT NULL,
    PRIMARY KEY (ProductId, ClientId)
)



INSERT INTO Products (Name, Price, CategoryId, VendorId)
VALUES
    ('SCANIA Oil Filter XD01', 78.69, 1, 1),
    ('MAN Air Filter XD01', 97.38, 1, 5),
    ('DAF Light Bulb 05FG87', 55.00, 2, 13),
    ('ADR Shoes 47-47.5', 49.85, 3, 5),
    ('Anti-slip pads S', 5.87, 5, 7);

INSERT INTO Invoices (Number, IssueDate, DueDate, Amount, Currency, ClientId)
VALUES
    (1219992181, '2023-03-01', '2023-04-30', 180.96, 'BGN', 3),
    (1729252340, '2022-11-06', '2023-01-04', 158.18, 'EUR', 13),
    (1950101013, '2023-02-17', '2023-04-18', 615.15, 'USD', 19);


	SELECT * FROM Invoices

UPDATE Invoices
SET DueDate = '2023-04-01'
WHERE IssueDate  BETWEEN '2022-11-01'AND '2022-11-30'


UPDATE Clients SET AddressId = 3 WHERE [Name] LIKE '%CO%'