--TABLA SIN RELACIONES

CREATE TABLE Producto(
id_producto int Identity primary key,
prod_nombre varchar(60),
prod_precio decimal(12,2),
prod_stock decimal(12,2),
prod_detalle varchar(250),
prod_img varchar(250),
)

SELECT * FROM Producto

CREATE PROCEDURE ListarProducto as
BEGIN 
SELECT * FROM Producto
END


--Procedures CRUD
--RELACION CON PROVEEDOR
CREATE PROCEDURE ListarProducto as
BEGIN 
SELECT * FROM Producto inner join Proveedor ON Producto.prod_proveedor = Proveedor.id_proveedor
END

execute ListarProducto

CREATE PROCEDURE ObtenerProducto(@id_prod int) AS
BEGIN 
SELECT * FROM Producto WHERE id_producto = @id_prod
END

--Procedimiento Guardar 
create procedure GuardarProducto(
@prod_nombre varchar(60),
@prod_precio decimal(12,2),
@prod_stock decimal(12,2),
@prod_detalle varchar(250),
@prod_img varchar(250)


)
AS 
BEGIN 
INSERT INTO Producto(prod_nombre, prod_precio, prod_stock, prod_detalle, prod_img)
VALUES (@prod_nombre, @prod_precio, @prod_stock, @prod_detalle, @prod_img)
END


--Procedure Modificar
CREATE PROCEDURE EditarProducto(

@id_producto int,
@prod_nombre varchar(60),
@prod_precio decimal(12,2),
@prod_stock decimal(12,2),
@prod_detalle varchar(250),
@prod_img varchar(250)

) AS 
BEGIN 
UPDATE Producto SET prod_nombre = @prod_nombre, prod_precio = @prod_precio, prod_stock = @prod_stock, prod_detalle = @prod_detalle, prod_img = @prod_img 
WHERE id_producto = @id_producto
END




--Procedure Eliminar 
CREATE PROCEDURE EliminarProducto(
@id_producto int)
AS
BEGIN
DELETE FROM Producto WHERE id_producto = @id_producto
END


--INSERT CON RELACIÓN DE PROVEEDOR 
insert into Producto(id_producto, prod_nombre, prod_precio, prod_stock, prod_detalle, prod_img) values(2,'Ibuprofeno','80','20','Producto desinflamatorio','',1)

go

SELECT * FROM Producto
SELECT * FROM Proveedor