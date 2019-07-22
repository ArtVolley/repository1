USE TestEx2
GO

SELECT Name FROM Airport airport, Pilot
WHERE Airport = airport.OID and airport.NameOfAirport = 'Шереметьево'
