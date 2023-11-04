SELECT TOP 50 e.Firstname, e.LastName,
	t.Name as Town, a.AddressText
FROM Employees e
	JOIN Addresses a ON e.AddressID = a.AddressID
	JOIN Towns t ON a.TownID = t.TownID
ORDER BY e.FirstName, e.LastName



--1
SELECT TOP 5 
	e.EmployeeId,
	e.JobTitle,
	a.AddressId,
	a.AddressText
FROM Employees e
JOIN Addresses a ON a.AddressID = e.AddressID 
ORDER BY AddressID ASC

--2

SELECT TOP 50
	e.FirstName,
	e.LastName,
	t.[Name],
	a.AddressText
FROM Employees e
JOIN Addresses a ON a.AddressID = e.AddressID 
JOIN Towns t ON t.TownID = a.TownID
ORDER BY e.FirstName, e.LastName ASC


--3
SELECT 
	EmployeeID,
	FirstName,
	LastName,
	d.[Name]
FROM Employees AS e
JOIN Departments d ON d.DepartmentID = e.DepartmentID
WHERE d.[Name] = 'Sales'
ORDER BY EmployeeID

SELECT * FROM Departments


--4
SELECT TOP (5)
	EmployeeID,
	FirstName,
	Salary,
	d.Name
FROM Employees AS e
JOIN Departments d ON d.DepartmentID = e.DepartmentID
WHERE e.Salary > 15000
ORDER BY d.DepartmentID

--5
SELECT TOP (3)
	e.EmployeeID,
	e.FirstName
FROM Employees AS e
WHERE e.EmployeeID NOT IN (SELECT EmployeeID FROM EmployeesProjects)


Select * FROM Employees
--6
SELECT
	FirstName,
	LastName,
	HireDate,
	d.Name
FROM Employees AS e
JOIN Departments d ON d.DepartmentID = e.DepartmentID
WHERE d.Name IN ('Sales', 'Finance') AND YEAR(HireDate) > 1999
ORDER BY HireDate ASC


--7
SELECT TOP (5)
	e.EmployeeID,
	FirstName,
	p.Name
FROM Employees AS e
JOIN EmployeesProjects ep ON ep.EmployeeID = e.EmployeeID
JOIN Projects p ON p.ProjectID = ep.ProjectID
WHERE p.StartDate > '2002-08-13' AND p.EndDate IS NULL

--8
SELECT
	e.EmployeeID,
	FirstName,
	CASE 
		WHEN p.StartDate > '2005' THEN NULL
		ELSE p.Name
	END AS ProjectName
FROM Employees AS e
JOIN EmployeesProjects ep ON ep.EmployeeID = e.EmployeeID
JOIN Projects p ON p.ProjectID = ep.ProjectID
WHERE e.EmployeeID = 24


--9 Employee Manager
SELECT 
	e.EmployeeID,
	e.Firstname,
	e.ManagerID,
	m.FirstName AS ManagerName
FROM Employees AS e
JOIN Employees AS m ON m.EmployeeID = e.ManagerID
WHERE e.ManagerID IN (3, 7) 
ORDER BY e.EmployeeID ASC



--10
SELECT TOP (50)
	e.EmployeeID,
	CONCAT(e.FirstName, ' ', e.LastName) AS EmployeeName,
	CONCAT(m.FirstName, ' ', m.LastName) AS ManagerName,
	d.[Name] AS DepartmentName
FROM Employees AS e
JOIN Employees AS m ON m.EmployeeID = e.ManagerID
JOIN Departments AS d ON d.DepartmentID = e.DepartmentID
ORDER BY e.EmployeeID ASC

--11
SELECT TOP (1) AVG(Salary) AS MinAverageSalary
FROM Employees AS e
JOIN Departments AS d ON d.DepartmentID = e.DepartmentID
GROUP BY e.DepartmentID
ORDER BY MinAverageSalary

--12
SELECT * FROM MountainsCountries

SELECT
	mc.CountryCode,
	m.MountainRange,
	p.PeakName,
	p.Elevation
FROM Peaks AS p
JOIN Mountains AS m ON m.Id = p.MountainID 
JOIN MountainsCountries AS mc ON mc.MountainID = m.Id
WHERE Elevation > '2835' AND mc.CountryCode = 'BG'
ORDER BY Elevation DESC

--13
SELECT c.CountryCode, COUNT(*) AS [MountainRanges]
	FROM Countries AS c
	JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
	WHERE c.CountryCode IN ('US', 'RU', 'BG')
	GROUP BY c.CountryCode


SELECT * FROM CountriesRivers

--14 (LEFT JOIN SHOWCASE)
SELECT TOP (5)
	c.CountryName,
	r.RiverName
FROM Countries AS c
LEFT JOIN CountriesRivers AS cr ON cr.CountryCode = c.CountryCode
LEFT JOIN Rivers AS r ON cr.RiverId = r.Id
JOIN Continents AS con ON con.ContinentCode = c.ContinentCode
WHERE con.ContinentName = 'Africa'
ORDER BY c.CountryName ASC


--16 (15 has a star idc)
SELECT COUNT(*) AS [Count]
	FROM Countries AS c
	LEFT JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
	WHERE mc.MountainId IS NULL


--17
SELECT TOP (5)
	c.CountryName,
	MAX(p.Elevation) AS HighestPeakElevation,
	MAX(r.[Length]) AS LongestRiverLength
FROM Countries AS c
LEFT JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
LEFT JOIN Peaks AS p ON p.MountainId = mc.MountainId
LEFT JOIN CountriesRivers AS cr ON cr.CountryCode = c.CountryCode
LEFT JOIN Rivers AS r ON r.Id = cr.RiverId
GROUP BY CountryName
ORDER BY HighestPeakElevation DESC, LongestRiverLength DESC, c.CountryName ASC