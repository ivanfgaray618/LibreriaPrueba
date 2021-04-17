IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('ConsultarCiudades') AND type in ('P', 'PC'))
	EXEC('CREATE PROC ConsultarCiudades AS BEGIN SET NOCOUNT ON; END')
GO
ALTER PROC ConsultarCiudades
AS
BEGIN
		SELECT IdCiudad,Nombre,IdPais FROM Ciudad
END