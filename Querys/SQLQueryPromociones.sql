CREATE TABLE Promocion_producto(
    promo_numero INT Identity PRIMARY KEY,  
    id_promo int NULL, 
	id_producto int NULL,
    promo_fecha_inicio DATETIME NULL,
    promo_fecha_fin DATETIME NULL,
	
    FOREIGN KEY (id_promo) REFERENCES Promociones(id_promo),
    FOREIGN KEY (id_producto) REFERENCES Producto(id_producto)
);


--Listar Promos
CREATE PROCEDURE ListarPromociones as
BEGIN 
SELECT * FROM Promociones
END

--obtener categ
CREATE PROCEDURE ObtenerPromociones(@id_Promo int) AS
BEGIN 
SELECT * FROM Promociones WHERE id_promo = @id_promo
END


-- Guardar Categ

create procedure GuardarPromociones(
@promo_nombre varchar(250) NULL,
@promo_descuento decimal (12,2) NULL
)
AS 
BEGIN 
INSERT INTO Promociones
(promo_nombre, promo_descuento)
VALUES (@promo_nombre, @promo_descuento)
END


--Editar categ

CREATE PROCEDURE EditarPromociones(
@id_promo int,
@promo_nombre varchar(250) NULL,
@promo_descuento DECIMAl (12,2) NULL
) AS 
BEGIN 
UPDATE Promociones SET promo_nombre = @promo_nombre, promo_descuento = @promo_descuento
WHERE id_promo = @id_promo
END

--Eliminar categ

CREATE PROCEDURE EliminarPromociones(
@id_promo int)
AS
BEGIN
DELETE FROM Promociones WHERE id_promo = @id_promo
END

SELECT * FROM Promociones

---------------PROMOS POR PRODUCTOS


CREATE PROCEDURE ListarPromocionProducto
(
    @id_promo INT = NULL
)
AS
BEGIN
    SELECT * FROM Promocion_producto
    WHERE (@id_promo IS NULL OR id_promo = @id_promo)
END



---obtener promo prod

CREATE PROCEDURE ObtenerPromocionProducto(@promo_numero int) AS
BEGIN 
SELECT * FROM Promocion_producto WHERE @promo_numero = @promo_numero
END

------Guardar promo producto


CREATE PROCEDURE GuardarPromocionProducto
(

    @id_promo int NULL, 
	@id_producto int NULL,
    @promo_fecha_inicio DATETIME NULL,
    @promo_fecha_fin DATETIME NULL
	
)
AS
BEGIN

    
 
    INSERT INTO Promocion_producto( id_promo, id_producto, promo_fecha_inicio, promo_fecha_fin)
    VALUES ( @id_promo, @id_producto, @promo_fecha_inicio, @promo_fecha_fin)
END

----EDITAR

CREATE PROCEDURE EditarPromocionProducto
(
    @promo_numero INT,
    @id_promo INT,
    @id_producto INT,
    @promo_fecha_inicio DATETIME,
    @promo_fecha_fin DATETIME
)
AS
BEGIN
    UPDATE Promocion_producto
    SET id_promo = @id_promo,
        id_producto = @id_producto,
        promo_fecha_inicio = @promo_fecha_inicio,
        promo_fecha_fin = @promo_fecha_fin
    WHERE promo_numero = @promo_numero
END



-----------eliminar promo product
---Eliminar Detalle Orden
CREATE PROCEDURE EliminarPromocionProducto
(
    @promo_numero INT
)
AS
BEGIN
   

    DELETE FROM Promocion_producto
    WHERE promo_numero = @promo_numero;
END



-------------TRIGGER DESC
CREATE TRIGGER ActualizarPrecio ON Promocion_producto
AFTER INSERT, UPDATE
AS
BEGIN
    UPDATE p
    SET p.prod_precio = ROUND((1 - (pr.promo_descuento / 100)) * p.prod_precio, 2)
    FROM Producto p
    INNER JOIN inserted i ON p.id_producto = i.id_producto
    INNER JOIN Promociones pr ON i.id_promo = pr.id_promo
END


