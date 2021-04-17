IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('ConsultarLibros') AND type in ('P', 'PC'))
	EXEC('CREATE PROC ConsultarLibros AS BEGIN SET NOCOUNT ON; END')
GO
ALTER PROC ConsultarLibros
AS
BEGIN
		SELECT IdLibro, l.Nombre,Fecha,Costo, a.Nombre as 'NombreAutor', l.IdAutor FROM Libro l
		INNER JOIN Autor a ON l.IdAutor = a.IdAutor
END