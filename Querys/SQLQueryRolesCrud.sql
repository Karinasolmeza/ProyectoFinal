CREATE TABLE Roles(
id_rol int Identity PRIMARY KEY,
rol_detalle varchar(50) null,
)
 

--Listar Roles
CREATE PROCEDURE ListarRol as
BEGIN 
SELECT * FROM Roles
END

execute ListarRol


--Obtener Rol

CREATE PROCEDURE ObtenerRol(@id_rol int) AS
BEGIN 
SELECT * FROM Roles WHERE @id_rol = @id_rol
END



--Procedimiento Guardar 
create procedure GuardarRol(
@rol_detalle varchar(50)

)
AS 
BEGIN 
INSERT INTO Roles(rol_detalle)
VALUES (@rol_detalle)
END


execute GuardarRol


--Procedure Modificar
CREATE PROCEDURE EditarRol(
@id_rol int,
@rol_detalle varchar(50)

) AS 
BEGIN 
UPDATE Roles SET rol_detalle = @rol_detalle 
WHERE id_rol = @id_rol
END



--Procedure Eliminar 
CREATE PROCEDURE EliminarRol(
@id_rol int)
AS
BEGIN
DELETE FROM Roles WHERE id_rol = @id_rol
END
