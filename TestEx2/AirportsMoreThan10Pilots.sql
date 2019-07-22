USE TestEx2
GO



SELECT NameOfAirport FROM (SELECT NameOfAirport, Count(*) AS count FROM (SELECT NameOfAirport,Name FROM Airport,Pilot
WHERE Pilot.Airport=Airport.OID) x group by NameOfAirport) y
WHERE y.count>3



/*
SELECT NameOfAirport, QtyPilots
FROM Airport airport, Pilot
WHERE Airport = airport.OID and airport.QtyPilots > 10*/