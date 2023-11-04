-- Create the WMS database
CREATE DATABASE WMS


-- Create the Clients table
CREATE TABLE Clients (
    ClientId INT PRIMARY KEY IDENTITY,
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    Phone CHAR(12) CHECK(LEN(Phone) = 12) NOT NULL
)

-- Create the Mechanics table
CREATE TABLE Mechanics (
    MechanicId INT PRIMARY KEY IDENTITY,
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    Address VARCHAR(255) NOT NULL
)

-- Create the Models table
CREATE TABLE Models (
    ModelId INT PRIMARY KEY IDENTITY,
    [Name] VARCHAR(50) UNIQUE NOT NULL
);

-- Create the Jobs table
CREATE TABLE Jobs (
    JobId INT PRIMARY KEY IDENTITY,
    ModelId INT FOREIGN KEY REFERENCES Models(ModelId) NOT NULL,
    [Status] VARCHAR(11) DEFAULT 'Pending' CHECK([Status] IN ('Pending', 'In Progress', 'Finished')) NOT NULL,
    ClientId INT FOREIGN KEY REFERENCES Clients(ClientId) NOT NULL,
	MechanicId INT FOREIGN KEY REFERENCES Mechanics(MechanicId),
    IssueDate DATE NOT NULL,
    FinishDate DATE
)


-- Create the Orders table
CREATE TABLE Orders (
    OrderId INT PRIMARY KEY IDENTITY,
    JobId INT FOREIGN KEY REFERENCES Jobs(JobId) NOT NULL,
    IssueDate DATE,
    Delivered BIT DEFAULT 0 NOT NULL
)

-- Create the Vendors table
CREATE TABLE Vendors (
    VendorId INT PRIMARY KEY IDENTITY,
    Name VARCHAR(50) UNIQUE NOT NULL
)

-- Create the Parts table
CREATE TABLE Parts (
    PartId INT PRIMARY KEY IDENTITY,
    SerialNumber VARCHAR(50) UNIQUE NOT NULL,
    [Description] VARCHAR(255),
    Price DECIMAL(7, 2) CHECK (Price > 0), --might be a mistake, check later
    VendorId INT FOREIGN KEY REFERENCES Vendors(VendorId) NOT NULL,
    StockQty INT DEFAULT 0 CHECK (StockQty >= 0)
)

-- Create the OrderParts table
CREATE TABLE OrderParts (
    OrderId INT FOREIGN KEY REFERENCES Orders(OrderId) NOT NULL,
	PartId INT FOREIGN KEY REFERENCES Parts(PartId) NOT NULL,
    Quantity INT DEFAULT 1 CHECK (Quantity > 0),
    CONSTRAINT PK_JobsOrders PRIMARY KEY (OrderId, PartId)
)

-- Create the PartsNeeded table
CREATE TABLE PartsNeeded (
    JobId INT FOREIGN KEY REFERENCES Jobs(JobId) NOT NULL,
	PartId INT FOREIGN KEY REFERENCES Parts(PartId) NOT NULL,
    Quantity INT DEFAULT 1 CHECK (Quantity > 0),
    CONSTRAINT PK_JobsParts PRIMARY KEY (JobId, PartId)
)



--inserts
--1) clients
INSERT INTO Clients (FirstName, LastName, Phone)
VALUES
    ('Teri', 'Ennaco', '570-889-5187'),
    ('Merlyn', 'Lawler', '201-588-7810'),
    ('Georgene', 'Montezuma', '925-615-5185'),
    ('Jettie', 'Mconnell', '908-802-3564'),
    ('Lemuel', 'Latzke', '631-748-6479'),
    ('Melodie', 'Knipp', '805-690-1682'),
    ('Candida', 'Corbley', '908-275-8357');

--2 parts 
INSERT INTO Parts (SerialNumber, [Description], Price, VendorId)
VALUES
    ('WP8182119', 'Door Boot Seal', 117.86, 2),
    ('W10780048', 'Suspension Rod', 42.81, 1),
    ('W10841140', 'Silicone Adhesive', 6.77, 4),
    ('WPY055980', 'High Temperature Adhesive', 13.94, 3);

	
--update
UPDATE Jobs
SET MechanicId = 3, [Status] = 'In Progress'
WHERE [Status] = 'Pending';
	
--delete
DELETE FROM OrderParts
WHERE OrderId = 19

DELETE FROM Orders
WHERE OrderId = 19


--selects
--5
SELECT 
	CONCAT(m.FirstName,' ', m.LastName) AS Mechanic,
	j.[Status],
	j.IssueDate
FROM Mechanics AS m
JOIN Jobs AS j ON j.MechanicId = m.MechanicId
ORDER BY m.MechanicId, j.IssueDate, j.JobId ASC


--6
SELECT 
	CONCAT(c.FirstName,' ', c.LastName) AS Client,
	DATEDIFF(DAY, j.IssueDate, '2017-04-24') AS [Days going],
	j.[Status]
FROM Clients AS c
JOIN Jobs AS j ON j.ClientId = c.ClientId
WHERE [Status] != 'Finished' 
ORDER BY [Days going] DESC, c.ClientId ASC



--7
SELECT 
	CONCAT(m.FirstName,' ', m.LastName) AS Mechanic,
	AVG(DATEDIFF(DAY, j.IssueDate, j.FinishDate)) AS [Average Days]
FROM Mechanics AS m
JOIN Jobs AS j ON j.MechanicId = m.MechanicId
WHERE j.[Status] = 'Finished'
GROUP BY j.MechanicId, m.FirstName, m.LastName
ORDER BY j.MechanicId


--8
SELECT 
	CONCAT(m.FirstName,' ', m.LastName) AS Mechanic
FROM Mechanics AS m
LEFT JOIN Jobs AS j ON j.MechanicId = m.MechanicId
WHERE j.JobId IS NULL OR (SELECT COUNT(JobID)
						  FROM Jobs
						  WHERE [Status] <> 'Finished' AND MechanicId = m.MechanicId
						  GROUP BY MechanicId, [Status]) IS NULL
GROUP BY m.MechanicId, CONCAT(m.FirstName,' ', m.LastName)




--9 if we want to say that a NULL should be represented as a 0
SELECT
	j.JobId,
	ISNULL(SUM(p.Price * op.Quantity),0) AS Total
FROM Jobs AS j
LEFT JOIN Orders AS o ON o.JobId = j.JobId
LEFT JOIN OrderParts AS op ON op.OrderId = o.OrderId
LEFT JOIN Parts AS p ON p.PartId = op.PartId
WHERE j.[Status] = 'Finished'
GROUP BY j.JobId
ORDER BY Total DESC, j.JobId ASC


--10
SELECT p.PartId, p.[Description],
	SUM(pn.Quantity) AS [Required],
	SUM(p.StockQty) AS [In Stock], 0 AS Ordered
FROM Jobs AS j

FULL JOIN Orders o ON j.JobId = o.JobId
	JOIN PartsNeeded pn ON pn.JobId = j.JobId
	JOIN Parts p ON p.PartId = pn.PartId
WHERE j.[Status] <> 'Finished' AND o.Delivered IS NULL
GROUP BY p.PartId, p.Description
HAVING SUM(p.StockQty) < SUM(pn.Quantity)


--11

--CREATE PROC usp_PlaceOrder(@jobId INT, @serialNumber VARCHAR(50), @quantity INT)



SELECT * FROM Mechanics
SELECT * FROM Parts
SELECT * FROM PartsNeeded
SELECT * FROM Jobs
SELECT * FROM Orders
SELECT * FROM OrderParts

--12
CREATE OR ALTER FUNCTION udf_GetCost (@jobId INT)
RETURNS DECIMAL(15,2)
AS
BEGIN 
 DECLARE @result DECIMAL(15,2)
 SET @result = (SELECT SUM(p.Price * op.Quantity) AS TotalPrice	
 FROM Jobs AS j
  JOIN Orders AS o ON o.JobId = j.JobId
  JOIN OrderParts AS op ON op.OrderId = o.OrderId
  JOIN Parts AS p ON p.PartId = op.PartId
 WHERE j.JobId = @jobId
 GROUP BY j.JobId)

 IF @result IS NULL SET @result = 0;
 RETURN @result;
END

SELECT dbo.udf_GetCost(1)