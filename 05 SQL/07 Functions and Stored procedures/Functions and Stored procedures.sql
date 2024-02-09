--1
CREATE PROC usp_GetEmployeesSalaryAbove35000
AS
  SELECT FirstName, LastName
  FROM Employees
  WHERE SALARY > 35000

EXEC usp_GetEmployeesSalaryAbove35000


--2
CREATE PROC usp_GetEmployeesSalaryAboveNumber (@inputSalary DECIMAL(18,4)) 
AS
	SELECT FirstName, LastName
	FROM Employees
	WHERE SALARY >= @inputSalary

EXEC usp_GetEmployeesSalaryAboveNumber 48100


--3
CREATE PROC usp_GetTownsStartingWith (@inputString NVARCHAR(100))
AS
	SELECT [Name]
	FROM Towns
	WHERE LEFT([Name], LEN(@inputString)) = @inputString

EXEC usp_GetTownsStartingWith 'b'


--4 ADDING JOINS
CREATE PROC usp_GetEmployeesFromTown (@townName NVARCHAR(100))
AS
	SELECT FirstName, LastName
	FROM Employees AS e
	JOIN Addresses AS a ON a.AddressID = e.AddressID
	JOIN Towns AS t ON t.TownID = a.TownID
	WHERE @townName = t.[Name]

EXEC usp_GetEmployeesFromTown Sofia


--5
CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS VARCHAR(50)
AS
BEGIN
     DECLARE @result VARCHAR(50)

      	IF (@salary < 30000) 
      		SET @result = 'Low'
      	ELSE IF (@salary >= 30000 AND @salary <= 50000)
      		SET @result = 'Average'
      	ELSE 
      		SET @result = 'High'

	 RETURN @result;
END


SELECT dbo.ufn_GetSalaryLevel(Salary) FROM Employees


SELECT * FROM Employees

--6

CREATE PROC usp_EmployeesBySalaryLevel (@salaryLevel NVARCHAR(10))
AS
SELECT FirstName, 
		LastName
FROM Employees
WHERE dbo.ufn_GetSalaryLevel(Salary) = @salaryLevel

EXEC usp_EmployeesBySalaryLevel High

--7

CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(MAX), @word VARCHAR(MAX))
RETURNS BIT
BEGIN
DECLARE @count INT = 1;

WHILE (@count < LEN(@word))
BEGIN
	DECLARE @currentLetter CHAR(1) = SUBSTRING(@word,@count,1)

	IF (CHARINDEX(@currentLetter, @setOfLetters) = 0)
		RETURN 0
	SET @count += 1;
END
RETURN 1
END

SELECT dbo.ufn_IsWordComprised('oistmiahf', 'Sofia')


--9
CREATE PROC usp_GetHoldersFullName
AS
SELECT CONCAT(FirstName,' ', LastName) AS [Full Name]
FROM AccountHolders


--10
CREATE PROC usp_GetHoldersWithBalanceHigherThan(@money DECIMAL(15,2))
AS
SELECT FirstName, LastName
FROM AccountHolders AS ah
JOIN Accounts AS a ON a.AccountHolderId = ah.Id
GROUP BY FirstName, LastName
HAVING SUM(Balance) > @money
ORDER BY FirstName, LastName



--11
CREATE FUNCTION ufn_CalculateFutureValue(@initialSum DECIMAL(15,2), @interestRate FLOAT, @years INT)
RETURNS DECIMAL(15,4)
AS
	BEGIN
		DECLARE @result DECIMAL(15,4)
		SET @result = @initialSum * POWER((1+ @interestRate), @years)
		RETURN @result
	END

SELECT dbo.ufn_CalculateFutureValue(1000, 0.1, 5)

--12

CREATE PROC usp_CalculateFutureValueForAccount(@accountId INT, @interestRate FLOAT) 
AS
Select 
	a.Id AS [Account Id],
	ah.FirstName,
	ah.LastName,
	a.Balance AS [Current Balance],
	dbo.ufn_CalculateFutureValue(a.Balance, @interestRate, 5) AS [Balance in 5 years]
FROM Accounts AS a
JOIN AccountHolders AS ah ON ah.Id = a.AccountHolderId
WHERE a.Id = @accountId


	