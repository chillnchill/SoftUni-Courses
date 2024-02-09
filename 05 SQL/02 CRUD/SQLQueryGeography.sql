SELECT PeakName 
FROM Peaks
ORDER BY PeakName ASC

SELECT TOP (30) CountryName, Population 
FROM dbo.Countries
WHERE ContinentCode = 'EU'
ORDER BY Population DESC,
CountryName DESC

SELECT CountryName, CountryCode,
	CASE
		WHEN CurrencyCode = 'EUR' THEn 'Euro'
		ELSE 'Not Euro'
	END AS [Currency]
FROM dbo.Countries
ORDER BY CountryName ASC

