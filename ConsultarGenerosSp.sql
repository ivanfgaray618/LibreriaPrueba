IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('ConsultarGeneros') AND type in ('P', 'PC'))
	EXEC('CREATE PROC ConsultarGeneros AS BEGIN SET NOCOUNT ON; END')
GO
ALTER PROC ConsultarGeneros
AS
BEGIN
		SELECT IdSexo, Nombre FROM Sexo
END