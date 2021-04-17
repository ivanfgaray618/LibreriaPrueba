IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('ConsultarAutores') AND type in ('P', 'PC'))
	EXEC('CREATE PROC ConsultarAutores AS BEGIN SET NOCOUNT ON; END')
GO
ALTER PROC ConsultarAutores
AS
BEGIN
		SELECT a.IdAutor, 
			a.Nombre,
			p.Nombre as 'NombrePais', 
			s.Nombre as 'Sexo', 
			(SELECT COUNT(IdLibro) FROM Libro l where l.IdAutor = a.IdAutor) AS 'CantidadLibros',
			p.IdPais,
			c.IdCiudad,
			s.IdSexo
		FROM Autor a
		INNER JOIN Ciudad c ON c.IdCiudad = a.IdCiudad
		INNER JOIN Pais p ON p.IdPais = c.IdPais
		INNER JOIN Sexo s ON a.Sexo = s.IdSexo
END