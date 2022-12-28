--TABLA SIN RELACIONES

CREATE TABLE Producto(
id_producto int Identity primary key,
prod_nombre varchar(60),
prod_precio decimal(12,2),
prod_stock decimal(12,2),
prod_detalle varchar(250),
prod_img varchar(250),
)





--TABLA RELACION FK PROVEEDOR


CREATE TABLE Producto(
  id_producto int Identity primary key,
  prod_nombre varchar(60),
  prod_precio decimal(12,2),
  prod_stock decimal(12,2),
  prod_detalle varchar(250),
  prod_img varchar(250),
  prod_proveedor int,
  FOREIGN KEY (prod_proveedor) REFERENCES Proveedor(id_proveedor)
)
 
 DROP TABLE Producto

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

--Procedimiento para clientes 
CREATE PROCEDURE mostrarProducto
AS
BEGIN
  SELECT prod_nombre, prod_precio, prod_stock, prod_detalle, prod_img
  FROM Producto
END



--Procedure para vistas de los clientes 



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
@prod_img varchar(250),
@prod_proveedor int 

)
AS 
BEGIN 
INSERT INTO Producto(prod_nombre, prod_precio, prod_stock, prod_detalle, prod_img, prod_proveedor)
VALUES (@prod_nombre, @prod_precio, @prod_stock, @prod_detalle, @prod_img, @prod_proveedor)
END


EXECUTE GuardarProducto @prod_nombre='producto',@prod_precio=10, @prod_stock=11,@prod_detalle='detallecito',@prod_img='ur',@prod_proveedor=1
		
DROP PROCEDURE GuardarProducto
SELECT *FROM Producto
select * from Proveedor
--Procedure Modificar
CREATE PROCEDURE EditarProducto(

@id_producto int,
@prod_nombre varchar(60),
@prod_precio decimal(12,2),
@prod_stock decimal(12,2),
@prod_detalle varchar(250),
@prod_img varchar(250),
@prod_proveedor int

) AS 
BEGIN 
UPDATE Producto SET prod_nombre = @prod_nombre, prod_precio = @prod_precio, prod_stock = @prod_stock, prod_detalle = @prod_detalle, prod_img = @prod_img, prod_proveedor = @prod_proveedor 
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
insert into Producto(id_producto, prod_nombre, prod_precio, prod_stock, prod_detalle, prod_img, prod_proveedor) values(2,'Ibuprofeno','80','20','Producto desinflamatorio','',1)

go

SELECT * FROM Producto
SELECT * FROM Proveedor