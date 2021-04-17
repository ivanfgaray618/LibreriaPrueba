CREATE TABLE Pais(
	IdPais INT IDENTITY(1,1) PRIMARY KEY,
	Nombre VARCHAR(80)
)

CREATE TABLE Ciudad(
	IdCiudad INT IDENTITY(1,1) PRIMARY KEY,
	Nombre VARCHAR(80),
	IdPais INT,
	CONSTRAINT fk_Pais FOREIGN KEY (IdPais) REFERENCES Pais (IdPais),
)

CREATE TABLE Sexo(
	IdSexo VARCHAR(2) PRIMARY KEY,
	Nombre VARCHAR(80)
)

CREATE TABLE Autor(
	IdAutor INT IDENTITY(1,1) PRIMARY KEY,
	Nombre VARCHAR(80),
	IdCiudad INT,
	Sexo VARCHAR(2),
	CONSTRAINT fk_Ciudad FOREIGN KEY (IdCiudad) REFERENCES Ciudad (IdCiudad),
	CONSTRAINT fk_Sexo FOREIGN KEY (Sexo) REFERENCES Sexo (IdSexo),
)

CREATE TABLE Libro(
	IdLibro INT IDENTITY(1,1) PRIMARY KEY,
	Nombre VARCHAR(80),
	Fecha DATETIME,
	Costo Decimal,
	IdAutor INT,
	CONSTRAINT fk_Autor FOREIGN KEY (IdAutor) REFERENCES Autor (IdAutor),
)

INSERT INTO Pais VALUES('Colombia')
INSERT INTO Pais VALUES('Argentina')
INSERT INTO Pais VALUES('España')
INSERT INTO Pais VALUES('Alemania')

INSERT INTO Ciudad VALUES('Bogota',1)
INSERT INTO Ciudad VALUES('Cali',1)
INSERT INTO Ciudad VALUES('Medellin',1)
INSERT INTO Ciudad VALUES('Yopal',1)
INSERT INTO Ciudad VALUES('Buenos Aires',2)
INSERT INTO Ciudad VALUES('Cordoba',2)
INSERT INTO Ciudad VALUES('Madrid',3)
INSERT INTO Ciudad VALUES('Barcelona',3)
INSERT INTO Ciudad VALUES('Berlin',4)
INSERT INTO Ciudad VALUES('Múnich',4)

INSERT INTO Sexo VALUES('M','Masculino')
INSERT INTO Sexo VALUES('F','Femenino')

INSERT INTO Autor VALUES('Gabriel Garcia',3,'M')

INSERT INTO Libro VALUES('Libro de prueba','01/01/1990',40000,1)

select * from Pais
select * from Ciudad
select * from Sexo
select * from Autor
select * from Libro

