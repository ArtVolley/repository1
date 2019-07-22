USE TestEx2
GO

SELECT Name FROM Pilot pilot, Plane plane, PlaneOwnPlane_PilotPilot
WHERE Pilot = pilot.OID and OwnPlane = plane.OID and plane.NameOfPlane = '07N1001'


SELECT Name FROM Pilot pilot, Plane plane, PlaneAllowedPlanes_PilotWhoCanUse
WHERE WhoCanUse = pilot.OID and AllowedPlanes = plane.OID and plane.NameOfPlane = '07N1001'