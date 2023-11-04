--1
SELECT * FROM Departments

--2
SELECT Departments.Name AS dept_names
FROM Departments

--3
SELECT Employees.FirstName, Employees.LastName, Employees.Salary
FROM Employees;

--4
SELECT Employees.FirstName, Employees.MiddleName, Employees.LastName
FROM Employees;

--6
SELECT CONCAT(Employees.FirstName,'.', Employees.LastName, '@softuni.bg')
FROM Employees;

--7
SELECT DISTINCT Employees.Salary
FROM Employees;

--8
SELECT * FROM Employees
WHERE Employees.JobTitle = 'Sales Representative'

--9
SELECT Employees.FirstName, Employees.LastName, Employees.JobTitle
FROM Employees
WHERE Employees.Salary >= 20000 AND Employees.Salary <= 30000

--10
SELECT CONCAT(Employees.FirstName,' ',Employees.MiddleName,' ', Employees.LastName) AS Full_Name
FROM Employees
WHERE Salary IN (25000, 14000, 12500, 23600);

--11
SELECT Employees.FirstName, Employees.LastName
FROM Employees
WHERE Employees.ManagerID IS NULL;

--12
SELECT Employees.FirstName, Employees.LastName, Employees.Salary 
FROM Employees
WHERE Employees.Salary >= 50000
ORDER BY Salary DESC

--13
SELECT TOP 5 Employees.FirstName, Employees.LastName
FROM Employees
WHERE Employees.Salary >= 50000
ORDER BY Salary DESC

--14
SELECT Employees.FirstName, Employees.LastName
FROM Employees
WHERE Employees.DepartmentID != 4;

--15
SELECT * FROM Employees
ORDER BY Employees.Salary DESC,
Employees.FirstName,
Employees.LastName DESC,
Employees.MiddleName;

--CREATE VIEW V_EmployeesSalaries AS
--SELECT Employees.FirstName, Employees.LastName, Employees.Salary
--FROM Employees;

--This is correct syntax, it's just a view so it needs to be alone: 
--CREATE VIEW V_EmployeesSalaries AS
--SELECT Employees.FirstName, Employees.LastName, Employees.Salary
--FROM Employees;


--CREATE VIEW  V_EmployeeNameJobTitle
--AS
--(SELECT CONCAT(Employees.FirstName,' ',Employees.MiddleName,' ', Employees.LastName) AS [Full Name],
--Employees.JobTitle
--FROM Employees)
--25000, 14000, 12500 or 23600


SELECT DISTINCT JobTitle
FROM Employees

SELECT TOP (10) * FROM Projects 
ORDER BY StartDate ASC, Name;


SELECT TOP (7) FirstName, LastName, HireDate
FROM Employees
ORDER BY HireDate DESC;

UPDATE Employees
SET Salary += Salary * 0.12
WHERE DepartmentID IN (1, 2, 4, 11)

SELECT Salary FROM Employees
