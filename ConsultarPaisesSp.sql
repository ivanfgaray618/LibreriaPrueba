IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('ConsultarPaises') AND type in ('P', 'PC'))
	EXEC('CREATE PROC ConsultarPaises AS BEGIN SET NOCOUNT ON; END')
GO
ALTER PROC ConsultarPaises
AS
BEGIN
		SELECT IdPais, Nombre FROM Pais
END