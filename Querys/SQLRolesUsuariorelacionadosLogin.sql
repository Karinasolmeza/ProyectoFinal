CREATE TABLE Roles(
id_rol int Identity PRIMARY KEY,
rol_detalle varchar(50) null,
)
 
 CREATE TABLE Usuario(
 id_usuario int Identity PRIMARY KEY,
 Nombre varchar(50) null,
 Correo varchar(50) null,
 Clave varchar(100) null,
 usuario_rol int FOREIGN KEY REFERENCES Roles(id_rol) null
 
	


 SELECT * FROM Usuario
 


 --valores roles
INSERT INTO Roles (id_rol, rol_detalle)
VALUES ( 'administrador'), ( 'empleado'),  ( 'cliente');



 --usuario admin/insert sin identity No usar más

 insert into Usuario Values (1,'Enrique','administrador@gmail.com','123',1)
 insert into Usuario Values (2,'Ariel','empleado@gmail.com','123',2)
 insert into Usuario Values (3,'Alejandro','cliente@gmail.com','123',3)


 --insert para identity Este si 
  SET IDENTITY_INSERT Usuario ON;
 INSERT INTO Usuario (id_Usuario, Nombre, Correo, Clave, usuario_rol)
VALUES (8, 'Enrique', 'administrador@gmail.com', '123', 1);

 INSERT INTO Usuario (id_Usuario, Nombre, Correo, Clave, usuario_rol)
VALUES (2,'Ariel','empleado@gmail.com','123',2);

 INSERT INTO Usuario (id_Usuario, Nombre, Correo, Clave, usuario_rol)
VALUES (3,'Alejandro','cliente@gmail.com','123',3);

 SET IDENTITY_INSERT Usuario OFF;


 SELECT * FROM Usuario
 SELECT * FROM Roles
 
 --procedimiento listar
 CREATE PROCEDURE ListarUsuario
AS
BEGIN
  SELECT *
  FROM Usuario
END



--PROCEDIMIENTO LOGIN 
CREATE PROCEDURE AutenticarUsuario (@Correo varchar(50), @Clave varchar(100)) AS
begin 
SELECT * FROM Usuario inner join Roles on Usuario.usuario_rol = id_rol where Correo like @Correo AND Clave LIKE @Clave
end
EXECUTE AutenticarUsuario @Correo ='administrador@gmail.com', @Clave = '123'


