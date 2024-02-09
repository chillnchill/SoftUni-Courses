
CREATE DATABASE Boardgames;

USE Boardgames;

-- Create the Categories table
CREATE TABLE Categories (
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(50) NOT NULL
);

-- Create the Addresses table
CREATE TABLE Addresses (
    Id INT PRIMARY KEY IDENTITY,
    StreetName NVARCHAR(100) NOT NULL,
    StreetNumber INT NOT NULL,
    Town NVARCHAR(30) NOT NULL,
    Country NVARCHAR(50) NOT NULL,
    ZIP INT NOT NULL
);

-- Create the Publishers table
CREATE TABLE Publishers (
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(30) NOT NULL UNIQUE,
    AddressId INT FOREIGN KEY REFERENCES Addresses(Id) NOT NULL,
    Website NVARCHAR(40),
    Phone NVARCHAR(20)
);

-- Create the PlayersRanges table
CREATE TABLE PlayersRanges (
    Id INT PRIMARY KEY IDENTITY,
    PlayersMin INT NOT NULL,
    PlayersMax INT NOT NULL
);

-- Create the Boardgames table
CREATE TABLE Boardgames (
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(30) NOT NULL,
    YearPublished INT NOT NULL,
    Rating DECIMAL(14, 2) NOT NULL,
    CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
    PublisherId INT FOREIGN KEY REFERENCES Publishers(Id) NOT NULL,
    PlayersRangeId INT FOREIGN KEY REFERENCES PlayersRanges(Id) NOT NULL
);

-- Create the Creators table
CREATE TABLE Creators (
    Id INT PRIMARY KEY IDENTITY,
    FirstName NVARCHAR(30) NOT NULL,
    LastName NVARCHAR(30) NOT NULL,
    Email NVARCHAR(30) NOT NULL
);

-- Create the CreatorsBoardgames table
CREATE TABLE CreatorsBoardgames (
    CreatorId INT FOREIGN KEY REFERENCES Creators(Id) NOT NULL,
    BoardgameId INT FOREIGN KEY REFERENCES BoardGames(Id) NOT NULL
    PRIMARY KEY (CreatorId, BoardgameId)
);


--inserts
--INSERT INTO Boardgames (Name, YearPublished, Rating, CategoryId, PublisherId, PlayersRangeId)
--VALUES
--    ('Deep Blue', 2019, 5.67, 1, 15, 7),
--    ('Paris', 2016, 9.78, 7, 1, 5),
--    ('Catan: Starfarers', 2021, 9.87, 7, 13, 6),
--    ('Bleeding Kansas', 2020, 3.25, 3, 7, 4),
--    ('One Small Step', 2019, 5.75, 5, 9, 2);

---- Insert data into the Publishers table
--INSERT INTO Publishers (Name, AddressId, Website, Phone)
--VALUES
--    ('Agman Games', 5, 'www.agmangames.com', '+16546135542'),
--    ('Amethyst Games', 7, 'www.amethystgames.com', '+15558889992'),
--    ('BattleBooks', 13, 'www.battlebooks.com', '+12345678907');

--updates
--UPDATE PlayersRanges
--SET PlayersMax += 1
--WHERE PlayersMin = 2 AND PlayersMax = 2

--UPDATE Boardgames
--SET [Name] += 'V2'
--WHERE YearPublished >= 2020

--delete


--DELETE FROM CreatorsBoardgames
--WHERE BoardgameId IN (1, 16, 31)

--DELETE FROM Boardgames
--WHERE PublisherId = 1

--DELETE FROM Publishers
--WHERE AddressId = 5

--DELETE FROM Addresses
--WHERE LEFT(Town, 1) = 'L'


--SELECTS

SELECT 
	[Name],
	Rating
FROM Boardgames
ORDER BY YearPublished, [Name] DESC

SELECT 
	b.Id,
	b.[Name],
	YearPublished,
	c.[Name]
FROM Boardgames AS b
JOIN Categories AS c ON c.Id = b.CategoryId
WHERE c.[Name] IN ('Strategy Games', 'Wargames')
ORDER BY YearPublished DESC

SELECT
    C.Id,
    CONCAT(C.FirstName, ' ', C.LastName) AS [Name],
    C.Email
FROM Creators AS C
LEFT JOIN CreatorsBoardgames AS CB ON C.Id = CB.CreatorId
WHERE CB.CreatorId IS NULL
ORDER BY [Name] ASC;


SELECT TOP (5)
	b.[Name],
	b.Rating,
	c.[Name] AS CategoryName
FROM Boardgames AS b
JOIN Categories AS c ON c.Id = b.CategoryId
JOIN PlayersRanges AS pr ON pr.Id = b.PlayersRangeId
WHERE b.Rating > 7.00 AND b.[Name] LIKE '%a%' OR b.Rating > 7.50 AND pr.PlayersMin = 2 AND pr.PlayersMax = 5
ORDER BY b.[Name], b.Rating DESC


SELECT 
    CONCAT(c.FirstName, ' ', c.LastName) AS [FullName],
    c.Email,
	MAX(b.Rating) AS Rating 
FROM Creators AS c
JOIN CreatorsBoardgames AS cb ON cb.CreatorId = c.Id
JOIN Boardgames AS b ON b.Id = cb.BoardgameId
WHERE Email LIKE '%.com%'
ORDER BY FullName ASC


WITH CreatorEmails AS (
    SELECT
        C.Id AS CreatorId,
        CONCAT(C.FirstName, ' ', C.LastName) AS FullName,
        C.Email
    FROM Creators AS C
    WHERE C.Email LIKE '%.com'
)

SELECT
    CE.FullName AS FullName,
    CE.Email AS Email,
    MAX(BG.Rating) AS Rating
FROM CreatorEmails AS CE
LEFT JOIN CreatorsBoardgames AS CB ON CE.CreatorId = CB.CreatorId
LEFT JOIN Boardgames AS BG ON CB.BoardgameId = BG.Id
WHERE Rating IS NOT NULL
GROUP BY CE.FullName, CE.Email
ORDER BY FullName ASC;

--mine
SELECT
    c.LastName,
    CEILING(AVG(b.Rating)) AS AverageRating,
    p.[Name] AS PublisherName
FROM Creators AS c
JOIN CreatorsBoardgames AS cb ON cb.CreatorId = c.Id
JOIN Boardgames AS b ON b.Id = cb.BoardgameId
JOIN Publishers AS p ON p.Id = b.PublisherId
WHERE p.[Name] = 'Stonemaier Games'
GROUP BY c.LastName, p.[Name]
ORDER BY (AVG(b.Rating)) DESC

--gpt
SELECT
    C.LastName AS CreatorLastName,
    CEILING(AVG(BG.Rating)) AS AverageRating,
    P.Name AS PublisherName
FROM Creators AS C
JOIN CreatorsBoardgames AS CB ON C.Id = CB.CreatorId
JOIN Boardgames AS BG ON CB.BoardgameId = BG.Id
JOIN Publishers AS P ON BG.PublisherId = P.Id
WHERE P.Name = 'Stonemaier Games'
GROUP BY C.LastName, P.Name
ORDER BY CEILING(AVG(BG.Rating)) DESC;


CREATE FUNCTION udf_CreatorWithBoardgames(@name NVARCHAR(50)) 
RETURNS INT
AS 
	BEGIN
	DECLARE @result INT
	SET @result = (SELECT COUNT(cb.BoardgameId)
     FROM Creators AS c
     JOIN CreatorsBoardgames AS cb ON cb.CreatorId = c.Id
     WHERE c.FirstName = @name)
	 RETURN @result;
   END

   SELECT dbo.udf_CreatorWithBoardgames('Bruno')


   --USP
CREATE OR ALTER PROC usp_SearchByCategory(@category NVARCHAR(50))
 AS 
	SELECT 
		b.[Name],
		b.YearPublished,
		b.Rating,
		c.[Name],
		p.[Name],
		CONCAT (pr.PlayersMin,' ', 'people') AS MinPlayers, 
		CONCAT (pr.PlayersMax,' ', 'people') AS MaxPlayers
	FROM Boardgames AS b
	JOIN Categories AS c ON c.Id = b.CategoryId
	JOIN Publishers AS p ON p.Id = b.PublisherId
	JOIN PlayersRanges AS pr ON pr.Id = b.PlayersRangeId
	WHERE c.[Name] = @category
	ORDER BY p.[Name], b.YearPublished DESC


	EXEC usp_SearchByCategory 'Wargames'