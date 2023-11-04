-- Create the TouristAgency database
CREATE DATABASE TouristAgency;

-- Use the TouristAgency database
USE TouristAgency;

CREATE TABLE Countries (
    Id INT PRIMARY KEY IDENTITY,
    [Name] NVARCHAR(50) NOT NULL
)


CREATE TABLE Destinations (
    Id INT PRIMARY KEY IDENTITY,
    [Name] NVARCHAR(50) NOT NULL,
    CountryId INT FOREIGN KEY REFERENCES Countries(Id) NOT NULL
)


CREATE TABLE Rooms (
    Id INT PRIMARY KEY IDENTITY,
    [Type] NVARCHAR(40) NOT NULL,
    Price DECIMAL(18, 2) NOT NULL,
    BedCount INT CHECK (BedCount > 0 AND BedCount <= 10) NOT NULL
)


CREATE TABLE Hotels (
    Id INT PRIMARY KEY IDENTITY,
    [Name] NVARCHAR(50) NOT NULL,
    DestinationId INT FOREIGN KEY REFERENCES Destinations(Id) NOT NULL
)


CREATE TABLE Tourists (
    Id INT PRIMARY KEY IDENTITY,
    [Name] NVARCHAR(80) NOT NULL,
    PhoneNumber NVARCHAR(20) NOT NULL,
    Email NVARCHAR(80),
    CountryId INT FOREIGN KEY REFERENCES Countries(Id) NOT NULL
)


CREATE TABLE Bookings (
    Id INT PRIMARY KEY IDENTITY,
    ArrivalDate DATETIME2 NOT NULL,
    DepartureDate DATETIME2 NOT NULL,
    AdultsCount INT CHECK (AdultsCount >= 1 AND AdultsCount <= 10) NOT NULL,
    ChildrenCount INT CHECK (ChildrenCount >= 0 AND ChildrenCount <= 9) NOT NULL,
    TouristId INT FOREIGN KEY REFERENCES Tourists(Id) NOT NULL,
    HotelId INT FOREIGN KEY REFERENCES Hotels(Id) NOT NULL,
    RoomId INT FOREIGN KEY REFERENCES Rooms(Id) NOT NULL
)


CREATE TABLE HotelsRooms (
    HotelId INT FOREIGN KEY REFERENCES Hotels(Id),
    RoomId INT FOREIGN KEY REFERENCES Rooms(Id),
    PRIMARY KEY (HotelId, RoomId)
)


--INSERT INTO Tourists ([Name], PhoneNumber, Email, CountryId)
--VALUES
--    ('John Rivers', '653-551-1555', 'john.rivers@example.com', 6),
--    ('Adeline Aglaé', '122-654-8726', 'adeline.aglae@example.com', 2),
--    ('Sergio Ramirez', '233-465-2876', 's.ramirez@example.com', 3),
--    ('Johan Müller', '322-876-9826', 'j.muller@example.com', 7),
--    ('Eden Smith', '551-874-2234', 'eden.smith@example.com', 6);


--INSERT INTO Bookings (ArrivalDate, DepartureDate, AdultsCount, ChildrenCount, TouristId, HotelId, RoomId)
--VALUES
--    ('2024-03-01', '2024-03-11', 1, 0, 21, 3, 5),
--    ('2023-12-28', '2024-01-06', 2, 1, 22, 13, 3),
--    ('2023-11-15', '2023-11-20', 1, 2, 23, 19, 7),
--    ('2023-12-05', '2023-12-09', 4, 0, 24, 6, 4),
--    ('2024-05-01', '2024-05-07', 6, 0, 25, 14, 6);

--UPDATE Bookings
--SET DepartureDate = DATEADD(DAY, 1, DepartureDate)
--WHERE ArrivalDate >= '2023-12-01' AND ArrivalDate < '2024-01-01'

--UPDATE Tourists
--SET Email = NULL
--WHERE [Name] LIKE '%MA%'


--DELETE FROM Bookings
--WHERE TouristId IN (6, 16, 25)

--DELETE FROM Tourists
--Where [Name] LIKE '% Smith%'

--5
SELECT 
	FORMAT(ArrivalDate, 'yyyy-MM-dd') AS ArrivalDate,
	AdultsCount,
	ChildrenCount
FROM Bookings AS b
JOIN Rooms AS r ON r.Id = b.RoomId
ORDER BY r.Price DESC, ArrivalDate ASC

--6
 --I didn't understand, look again
SELECT
    h.Id AS HotelId,
    h.Name AS HotelName
FROM Hotels AS h
WHERE
    EXISTS (
        SELECT 1
        FROM HotelsRooms AS hr
        WHERE hr.HotelId = h.Id AND hr.RoomId = 8  
    )
ORDER BY
    (SELECT COUNT(*) FROM Bookings AS b WHERE b.HotelId = h.Id) DESC

--7

	--I didn't understand LEFT JOIN
SELECT 
	t.Id,
	t.[Name],
	PhoneNumber
FROM Tourists AS t
LEFT JOIN Bookings AS b ON t.Id = b.TouristId
WHERE  B.TouristId IS NULL
ORDER BY t.[Name] 


--8
    --• HotelName
    --• DestinationName
    --• CountryName
SELECT TOP(10)
	h.[Name],
	d.[Name],
	c.[Name]
FROM Bookings AS b
JOIN Hotels AS h ON h.Id = b.HotelId
JOIN Destinations AS d ON d.Id = h.DestinationId
JOIN Countries AS c ON c.Id = d.CountryId
WHERE ArrivalDate < '2023-12-31' AND (h.Id % 2) != 0
ORDER BY c.[Name], b.ArrivalDate


--9
    --• HotelName
    --• RoomPrice
SELECT 
	h.[Name],
	r.Price
FROM Tourists AS t
JOIN Bookings AS b ON t.Id = b.TouristId
JOIN Hotels AS h ON h.Id = b.HotelId
JOIN Rooms AS r ON r.Id = b.RoomId
WHERE t.[Name] NOT LIKE '%EZ%'
ORDER BY r.Price DESC


--10
    --I didn't know how SUM and GRP BY work.
SELECT
	h.[Name] AS HotelName,
	SUM(DATEDIFF(DAY, ArrivalDate, DepartureDate) * r.Price) AS TotalRevenue
FROM Bookings AS b
JOIN Hotels AS h ON h.Id = b.HotelId
JOIN Rooms AS r ON r.Id = b.RoomId
GROUP BY h.[Name]
ORDER BY TotalRevenue DESC


--11
CREATE FUNCTION udf_RoomsWithTourists(@name NVARCHAR(40))
RETURNS INT
AS
	BEGIN
		DECLARE @result INT;
		SET @result = (SELECT 
		SUM(AdultsCount + ChildrenCount) AS People
		FROM Bookings AS b
		JOIN Rooms AS r ON r.Id = b.RoomId
		WHERE r.Type = @name)

		RETURN @result
	END

	
--12
CREATE PROC usp_SearchByCountry(@country NVARCHAR(50))
AS
	SELECT 
		t.[Name],
		t.PhoneNumber,
		t.Email,
		COUNT(b.TouristId) AS CountOfBookings
	FROM Tourists AS t
	JOIN Bookings AS b ON b.TouristId = t.Id
	JOIN Countries AS c ON c.Id = t.CountryId
	WHERE c.[Name] = @country
	GROUP BY t.[Name], t.PhoneNumber, t.Email
	ORDER BY t.[Name], CountOfBookings DESC


EXEC usp_SearchByCountry 'Greece'


--6 RE
SELECT 
	h.Id,
	h.[Name]
FROM HotelsRooms AS hr
JOIN Hotels AS h ON h.Id = hr.HotelId
JOIN Rooms AS r ON r.Id = hr.RoomId
LEFT JOIN Bookings AS b ON b.HotelId = h.Id
WHERE r.[Type] = 'VIP Apartment'
GROUP BY h.Id, h.[Name]
ORDER BY COUNT(b.Id) DESC


