CREATE DATABASE EstudianteDb
GO
USE EstudianteDb
GO
CREATE TABLE Estudiante
(
	EstudianteId int identity(1,1),
	Matricula varchar(9),
	Nombres varchar(30),
	Apellidos varchar (30),
	Telefono varchar(13),
	Cedula varchar(13),
	Email varchar(30),
	FechaNacimiento date,  

	Sexo int,
	Balance int,
);