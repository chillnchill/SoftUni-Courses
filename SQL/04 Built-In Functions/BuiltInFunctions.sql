--1
SELECT FirstName, LastName
FROM Employees
WHERE FirstName LIKE 'Sa%';

--2
SELECT FirstName, LastName
FROM Employees
WHERE LastName LIKE '%Ei%';

--3
SELECT FirstName
FROM Employees
WHERE DepartmentID IN (3, 10)
AND YEAR(HireDate) BETWEEN 1995 AND 2005

--4
SELECT FirstName, LastName
FROM Employees
WHERE JobTitle NOT LIKE '%engineer%'

--5

SELECT [Name]
FROM Towns
WHERE LEN([Name]) = 5 OR LEN([Name]) = 6
ORDER BY Name ASC

--6
SELECT TownID, [Name]
FROM Towns
WHERE LEFT([Name], 1) IN ('M', 'K', 'B', 'E') --takes the left letter of the first letter, big cool
ORDER BY Name ASC

--7

SELECT TownID, [Name]
FROM Towns
WHERE [Name] NOT LIKE '[RBD]%'
ORDER BY Name ASC


--8
CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT FirstName, LastName
FROM Employees
WHERE YEAR(HireDate) > 2000

--9
SELECT FirstName, LastName
FROM Employees
WHERE LEN(LastName) = 5

--10
SELECT EmployeeID, FirstName, LastName, Salary, DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeId) AS [Rank]
FROM Employees
WHERE Salary BETWEEN 10000 AND 50000
ORDER BY Salary DESC

--11

SELECT * FROM (
SELECT EmployeeID, FirstName, LastName, Salary, DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeId) AS [Rank]
FROM Employees
WHERE Salary BETWEEN 10000 AND 50000
) AS Ranked
WHERE [Rank] = 2
ORDER BY Salary DESC

--12

SELECT CountryName, IsoCode
FROM Countries
WHERE CountryName LIKE '%a%%a%%a%'
ORDER BY IsoCode ASC

--13
SELECT PeakName, RiverName,
LOWER(LEFT(PeakName, LEN(PeakName) - 1) + RiverName) AS Mix
FROM Peaks, Rivers
WHERE RIGHT(PeakName, 1) = LEFT(RiverName, 1)
ORDER BY Mix


--14
SELECT TOP(50) [Name], FORMAT([Start], 'yyyy-MM-dd')  
AS [Start]
FROM Games
WHERE DATEPART(YEAR, [Start]) BETWEEN 2011 AND 2012
ORDER BY [Start], [Name]

SELECT * FROM Users

--15
SELECT Username, SUBSTRING(Email, CHARINDEX('@', Email) + 1, LEN(Email))
AS EmailProvider
FROM Users
ORDER BY EmailProvider, Username

--16
SELECT Username, IpAddress
FROM Users
WHERE IpAddress LIKE '___.1%.%.___'
ORDER BY Username ASC

--17
SELECT [Name],
	CASE 
		WHEN DATEPART(HOUR, Start) BETWEEN 0 AND 11 THEN 'Morning'
		WHEN DATEPART(HOUR, Start) BETWEEN 12 AND 17 THEN 'Afternoon'
		WHEN DATEPART(HOUR, Start) BETWEEN 18 AND 23 THEN 'Evening'
	END AS [Part of the Day],
	CASE
		WHEN Duration <= 3 THEN 'Extra Short'
		WHEN Duration BETWEEN 4 AND 6 THEN 'Short'
		WHEN Duration > 6 THEN 'Long'
		ELSE 
		'Extra long'
	END AS [Duration]		
	FROM Games
ORDER BY [Name], [Duration], [Part of the Day]


SELECT ProductName, OrderDate,
	DATEADD(DAY, 3, OrderDate) AS [Pay Due],
	DATEADD(MONTH, 1, OrderDate) AS [Deliver Due]
FROM Orders