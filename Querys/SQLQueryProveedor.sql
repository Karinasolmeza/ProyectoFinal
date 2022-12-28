CREATE TABLE Proveedor(
id_proveedor int Identity primary key,
prove_nombre varchar(45),
prove_apellido varchar(45),
prove_direccion varchar(250),
prove_cuit varchar(45)

)


--Procedures CRUD

CREATE PROCEDURE ListarProveedor as
BEGIN 
SELECT * FROM Proveedor
END

execute ListarProveedor

CREATE PROCEDURE ObtenerProveedor(@id_Prove int) AS
BEGIN 
SELECT * FROM Proveedor WHERE id_proveedor = @id_Prove
END

--Procedimiento Guardar 
create procedure GuardarProveedor(
@prove_nombre varchar(45),
@prove_apellido varchar(45),
@prove_direccion varchar(250),
@prove_cuit varchar(45)

)
AS 
BEGIN 
INSERT INTO Proveedor
(prove_nombre, prove_apellido, prove_direccion, prove_cuit)
VALUES (@prove_nombre, @prove_apellido, @prove_direccion, @prove_cuit)
END


--Procedure Modificar
CREATE PROCEDURE EditarProveedor(
@id_proveedor int,
@prove_nombre varchar(45),
@prove_apellido varchar(45),
@prove_direccion varchar(250),
@prove_cuit varchar(45)

) AS 
BEGIN 
UPDATE Proveedor SET prove_nombre = @prove_nombre, prove_apellido= @prove_apellido, prove_direccion = @prove_direccion, prove_cuit = @prove_cuit 
WHERE id_proveedor = @id_proveedor
END


--Procedure Eliminar 
CREATE PROCEDURE EliminarProveedor(
@id_proveedor int)
AS
BEGIN
DELETE FROM Proveedor WHERE id_proveedor = @id_proveedor
END



insert into Proveedor(prove_nombre,prove_apellido,prove_direccion, prove_cuit) values('Provedor1','prove1','vive en 20292822','cuit12202020222')

go

SELECT* FROM Proveedor