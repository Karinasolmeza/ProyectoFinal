 CREATE TABLE Usuario(
 id_usuario int Identity PRIMARY KEY,
 Nombre varchar(50) null,
 Correo varchar(50) null,
 Clave varchar(100) null,
 usuario_rol int FOREIGN KEY REFERENCES Roles(id_rol) null
 
 )


 --Procedures CRUD
--Listar usuarios
CREATE PROCEDURE ListarUsuarioRol as
BEGIN 
SELECT * FROM Usuario inner join Roles ON Usuario.usuario_rol = Roles.id_Rol
END

execute ListarUsuarioRol



CREATE PROCEDURE ObtenerUsuario(@id_usuario int) AS
BEGIN 
SELECT * FROM Usuario WHERE id_usuario = @id_usuario
END

--Procedimiento Guardar 
create procedure GuardarUsuario(
@Nombre varchar(50),
@Correo varchar(50),                   
@Clave varchar(100),
@usuario_rol int


)
AS 
BEGIN 
INSERT INTO Usuario(Nombre, Correo, Clave, usuario_rol)
VALUES (@Nombre, @Correo, @Clave, @usuario_rol)
END


--Procedure Modificar
CREATE PROCEDURE EditarUsuario(

@id_usuario int,
@Nombre varchar(50),
@Correo varchar(50),
@Clave varchar(100),
@usuario_rol int


) AS 
BEGIN 
UPDATE Usuario SET Nombre = @Nombre, Correo = @Correo, Clave = @Clave, usuario_rol = @usuario_rol 
WHERE id_usuario = @id_usuario
END

SELECT * FROM Usuario
--Eliminar
CREATE PROCEDURE EliminarUsuario(
@id_usuario int)
AS
BEGIN
DELETE FROM Usuario WHERE id_usuario = @id_usuario
END
