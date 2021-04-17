IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('ModificarLibro') AND type in ('P', 'PC'))
	EXEC('CREATE PROC ModificarLibro AS BEGIN SET NOCOUNT ON; END')
GO
ALTER PROC ModificarLibro
	@IdLibro AS INT,
	@NombreLibro AS VARCHAR(80),
	@FechaLibro AS DATETIME,
	@CostoLibro AS DECIMAL,
	@Autor AS INT,
	@Error AS INT OUT
AS
BEGIN
BEGIN TRY
	BEGIN TRAN
		UPDATE Libro SET Nombre = @NombreLibro, Fecha = @FechaLibro, Costo = @CostoLibro, IdAutor = @Autor WHERE IdLibro = @IdLibro
		SET @Error = 0
	COMMIT TRAN
END TRY
BEGIN CATCH
	ROLLBACK TRAN
	SET @Error = ERROR_NUMBER()
END CATCH
END