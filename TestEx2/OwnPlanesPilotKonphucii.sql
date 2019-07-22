USE TestEx2
GO

SELECT NameOfPlane FROM Pilot pilot, Plane plane, PlaneOwnPlane_PilotPilot
WHERE Pilot = pilot.OID and OwnPlane = plane.OID and pilot.Name = 'Конфуций'
