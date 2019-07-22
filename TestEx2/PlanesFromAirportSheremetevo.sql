USE TestEx2
GO

SELECT NameOfPlane FROM Airport airport, Plane
WHERE Airport = airport.OID and airport.NameOfAirport = 'Шереметьево'
