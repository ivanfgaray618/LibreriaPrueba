IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('ModificarAutor') AND type in ('P', 'PC'))
	EXEC('CREATE PROC ModificarAutor AS BEGIN SET NOCOUNT ON; END')
GO
ALTER PROC ModificarAutor
	@IdAutor AS INT,
	@Nombre AS VARCHAR(80),
	@Ciudad AS INT,
	@Sexo AS VARCHAR(2),
	@Error AS INT OUT
AS
BEGIN
BEGIN TRY
	BEGIN TRAN
		UPDATE Autor SET Nombre = @Nombre, IdCiudad = @Ciudad, Sexo = @Sexo WHERE IdAutor = @IdAutor
		SET @Error = 0
	COMMIT TRAN
END TRY
BEGIN CATCH
	ROLLBACK TRAN
	SET @Error = ERROR_NUMBER()
END CATCH
END