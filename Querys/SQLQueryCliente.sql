CREATE TABLE Cliente(
id_cliente int Identity primary key,
clie_nombre varchar(50),
clie_apellido varchar (50),
clie_dni varchar(45),
clie_cuit varchar(45),
clie_razon_social varchar(50),
clie_tipo varchar(50),
clie_id_usuario int,
FOREIGN KEY (clie_id_usuario) REFERENCES Usuario(id_usuario)
)

SELECT * FROM Usuario
DROP TABLE Cliente 
DROP PROCEDURE EditarCliente



--Procedures CRUD CON RELACIONES Usuario



CREATE PROCEDURE ListarCliente as
BEGIN 
SELECT * FROM Cliente inner join Usuario ON Cliente.clie_id_usuario = Usuario.id_usuario
END





execute ListarCliente


CREATE PROCEDURE ObtenerCliente(@id_Contacto int) AS
BEGIN 
SELECT * FROM Cliente WHERE id_cliente = @id_Contacto
END


--Procedimiento Guardar Relación con Usuario
create procedure GuardarCliente(
@clie_nombre varchar(45),
@clie_apellido varchar(45),
@clie_dni varchar(45),
@clie_cuit varchar(45),
@clie_razon_social varchar(50),
@clie_tipo varchar(50),
@clie_id_usuario int

)
AS 
BEGIN 
INSERT INTO Cliente (clie_nombre, clie_apellido, clie_dni, clie_cuit, clie_razon_social, clie_tipo, clie_id_usuario)
VALUES (@clie_nombre, @clie_apellido, @clie_dni, @clie_cuit, @clie_razon_social, @clie_tipo, @clie_id_usuario)
END


--Editar relación con Usuario 
CREATE PROCEDURE EditarCliente(
@id_cliente int,
@clie_nombre varchar(45),
@clie_apellido varchar(45),
@clie_dni varchar(8),
@clie_cuit varchar(11),
@clie_razon_social varchar(50),
@clie_tipo varchar(50),
@clie_id_usuario int

) AS 
BEGIN 
UPDATE Cliente SET clie_nombre = @clie_nombre, clie_apellido = @clie_apellido, clie_dni = @clie_dni, clie_cuit = @clie_cuit, clie_razon_social = @clie_razon_social, clie_tipo = @clie_tipo, clie_id_usuario = @clie_id_usuario
WHERE id_cliente = @id_cliente
END

--Procedure Eliminar 
CREATE PROCEDURE EliminarCliente(
@id_cliente int)
AS
BEGIN
DELETE FROM Cliente WHERE id_cliente = @id_cliente
END







--CRUD SIN RELACIONES 
CREATE PROCEDURE ListarCliente as
BEGIN 
SELECT * FROM Cliente
END



--Procedimiento Guardar 
create procedure GuardarCliente(
@clie_nombre varchar(45),
@clie_apellido varchar(45),
@clie_dni varchar(45),
@clie_cuit varchar(45),
@clie_razon_social varchar(50),
@clie_tipo varchar(50)

)
AS 
BEGIN 
INSERT INTO Cliente (clie_nombre, clie_apellido, clie_dni, clie_cuit, clie_razon_social, clie_tipo)
VALUES (@clie_nombre, @clie_apellido, @clie_dni, @clie_cuit, @clie_razon_social, @clie_tipo)
END

execute GuardarCliente
--Procedure Modificar dni y cuit modificar char a 45
CREATE PROCEDURE EditarCliente(
@id_cliente int,
@clie_nombre varchar(45),
@clie_apellido varchar(45),
@clie_dni varchar(8),
@clie_cuit varchar(11),
@clie_razon_social varchar(50),
@clie_tipo varchar(50)

) AS 
BEGIN 
UPDATE Cliente SET clie_nombre = @clie_nombre, clie_apellido = @clie_apellido, clie_dni = @clie_dni, clie_cuit = @clie_cuit, clie_razon_social = @clie_razon_social, clie_tipo = @clie_tipo 
WHERE id_cliente = @id_cliente
END


--Procedure Eliminar 
CREATE PROCEDURE EliminarCliente(
@id_cliente int)
AS
BEGIN
DELETE FROM Cliente WHERE id_cliente = @id_cliente
END



insert into Cliente(clie_nombre,clie_apellido,clie_dni, clie_cuit, clie_razon_social, clie_tipo) values('Ariel','Profe','20292822','12202020222','19181991','Particular')

go

SELECT* FROM Cliente