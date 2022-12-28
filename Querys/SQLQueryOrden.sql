--Orden DetalleOrden 

CREATE TABLE Orden(
    id_orden INT Identity PRIMARY KEY,  
    ord_fecha_de_generacion DATE NULL,
	ord_fecha_entrega DATE NULL,
    ord_id_cliente INT NULL,
    ord_id_empleado INT NULL,
    FOREIGN KEY (ord_id_cliente) REFERENCES Cliente(id_cliente),
    FOREIGN KEY (ord_id_empleado) REFERENCES Empleado(id_empleado)
);


CREATE TABLE Detalle_orden(
    id_detalle_orden INT Identity PRIMARY KEY,  
    det_id_orden INT NULL,
    det_id_producto INT NULL,
    det_ord_precio DECIMAL(12,2) NULL,
	det_ord_cantidad DECIMAL(12,2) NULL,
	det_ord_total DECIMAL(12,2) NULL,
    FOREIGN KEY (det_id_orden) REFERENCES Orden(id_orden),
    FOREIGN KEY (det_id_producto) REFERENCES Producto(id_producto)
);







CREATE PROCEDURE ListarOrden
AS
BEGIN
  SELECT o.*, c.*, e.*
  FROM Orden o
    INNER JOIN Cliente c ON o.ord_id_cliente = c.id_cliente
    INNER JOIN Empleado e ON o.ord_id_empleado = e.id_empleado;

END

EXECUTE ListarOrden;

INSERT INTO Orden (ord_fecha_de_generacion, ord_fecha_entrega, ord_id_cliente, ord_id_empleado)
VALUES 
('2022-01-01', '2022-01-02', 1, 7);

  SELECT *FROM Orden

CREATE PROCEDURE ObtenerOrden(@id_orden int) AS
BEGIN 
SELECT * FROM Orden WHERE id_orden = @id_orden
END


SELECT* FROM Orden



  --Procedimiento Guardar relacionado
create procedure GuardarOrden(

   @ord_fecha_de_generacion DATE,
   @ord_fecha_entrega DATE NULL,
   @ord_id_cliente INT NULL,
   @ord_id_empleado INT NULL

)
AS 
BEGIN 
INSERT INTO Orden
(ord_fecha_de_generacion, ord_fecha_entrega, ord_id_cliente, ord_id_empleado)
VALUES (@ord_fecha_de_generacion, @ord_fecha_entrega, @ord_id_cliente, @ord_id_empleado)
END





--Procedure Modificar relacionado
CREATE PROCEDURE EditarOrden(
   @id_orden int,
   @ord_fecha_de_generacion DATE NULL,
   @ord_fecha_entrega DATE null,
   @ord_id_cliente INT NULL,
   @ord_id_empleado INT NULL


) AS 
BEGIN 
UPDATE Orden SET ord_fecha_de_generacion = @ord_fecha_de_generacion, ord_fecha_entrega = @ord_fecha_entrega, ord_id_cliente = @ord_id_cliente, ord_id_empleado = @ord_id_empleado
WHERE id_orden = @id_orden
END





--Procedure Eliminar 
CREATE PROCEDURE EliminarOrden(
@id_orden int)
AS
BEGIN
DELETE FROM Orden WHERE id_orden = @id_orden
END







----------------------------------------DETALLE ORDEN ---------------------
CREATE TABLE Detalle_orden(
    id_detalle_orden INT Identity PRIMARY KEY,  
    det_id_orden INT NULL,
    det_id_producto INT NULL,
    det_ord_precio DECIMAL(12,2) NULL,
	det_ord_cantidad DECIMAL(12,2) NULL,
	det_ord_total DECIMAL(12,2) NULL,
    FOREIGN KEY (det_id_orden) REFERENCES Orden(id_orden),
    FOREIGN KEY (det_id_producto) REFERENCES Producto(id_producto)
);

ALTER TABLE Detalle_orden
ADD det_ord_total DECIMAL;




--LISTAR DETALLE ORDEN


DROP PROCEDURE ListarDetalleOrden

CREATE PROCEDURE ListarDetalleOrden
(
    @id_orden INT = NULL
)
AS
BEGIN
    SELECT * FROM Detalle_orden
    WHERE (@id_orden IS NULL OR det_id_orden = @id_orden)
END




---SI ---
Drop PROCEDURE ObtenerDetalleOrden
CREATE PROCEDURE ObtenerDetalleOrden(@id_detalle_orden int) AS
BEGIN 
SELECT * FROM Detalle_orden WHERE id_detalle_orden = @id_detalle_orden
END



EXECUTE ObtenerDetalleOrden @id_orden = 2;


----OBTENER CON PRECIO CANTIDAD
  CREATE PROCEDURE ObtenerDetalleOrden
(
    @id_detalle_orden INT
)
AS
BEGIN
  

    SELECT id_detalle_orden, det_id_orden, det_id_producto, det_ord_precio, det_ord_cantidad, det_ord_total
   FROM Detalle_orden
    WHERE det_id_orden = @id_orden;
END








-----GuardarDetalleOrden---







-----MODIFICACION PRECIO CANTIDAD
ALTER TABLE Detalle_orden
ADD det_ord_total DECIMAL;



CREATE PROCEDURE GuardarDetalleOrden
(
@det_id_orden INT,
@det_id_producto INT,
@det_ord_precio DECIMAL(12,2),
@det_ord_cantidad DECIMAL(12,2)
)
AS
BEGIN
    INSERT INTO Detalle_orden (det_id_orden, det_id_producto, det_ord_precio, det_ord_cantidad, det_ord_total)
    VALUES (@det_id_orden, @det_id_producto, @det_ord_precio, @det_ord_cantidad, @det_ord_precio * @det_ord_cantidad)
END





---Este es el final con stock y precio auto 
CREATE PROCEDURE GuardarDetalleOrden
(
@det_id_orden INT,
@det_id_producto INT,
@det_ord_precio DECIMAL(12,2),
@det_ord_cantidad DECIMAL(12,2)
)
AS
BEGIN
    UPDATE Producto
    SET prod_stock = prod_stock - @det_ord_cantidad
    WHERE id_producto = @det_id_producto;

    INSERT INTO Detalle_orden (det_id_orden, det_id_producto, det_ord_precio, det_ord_cantidad, det_ord_total)
    VALUES (@det_id_orden, @det_id_producto, @det_ord_precio, @det_ord_cantidad, @det_ord_precio * @det_ord_cantidad);
END




   DROP PROCEDURE GuardarDetalleOrden
  

-----Editar DETALLE ORDEN det
CREATE PROCEDURE EditarDetalleOrden
(
    @id_detalle_orden INT,
    @det_id_orden INT,
    @det_id_producto INT,
    @det_ord_precio DECIMAL(12,2),
    @det_ord_cantidad DECIMAL(12,2)
)
AS
BEGIN
  

    UPDATE Detalle_orden
    SET det_id_orden = @det_id_orden, 
	det_id_producto = @det_id_producto,
	det_ord_precio = @det_ord_precio, 
	det_ord_cantidad = @det_ord_cantidad,
   det_ord_total = @det_ord_precio * @det_ord_cantidad
    WHERE id_detalle_orden = @id_detalle_orden;
END



-----------a ver stock----

CREATE PROCEDURE EditarDetalleOrden
(
    @id_detalle_orden INT,
    @det_id_orden INT,
    @det_id_producto INT,
    @det_ord_precio DECIMAL(12,2),
    @det_ord_cantidad DECIMAL(12,2)
)
AS
BEGIN
  
    -- Descontar el stock del producto
    UPDATE Producto
    SET prod_stock = prod_stock - @det_ord_cantidad
    WHERE id_producto = @det_id_producto;
    
    -- Actualizar el detalle de orden
    UPDATE Detalle_orden
    SET det_id_orden = @det_id_orden, 
        det_id_producto = @det_id_producto,
        det_ord_precio = @det_ord_precio, 
        det_ord_cantidad = @det_ord_cantidad,
        det_ord_total = @det_ord_precio * @det_ord_cantidad
    WHERE id_detalle_orden = @id_detalle_orden;
END




------GENERAR ORDEN---



DROP PROCEDURE GenerarOrden

CREATE PROCEDURE GenerarOrden
(
   @ord_fecha_de_generacion DATE,
   @ord_fecha_entrega DATE NULL,
   @ord_id_cliente INT NULL,
   @ord_id_empleado INT NULL,
   @det_id_producto INT,
   @det_ord_precio DECIMAL(12,2),
   @det_ord_cantidad DECIMAL(12,2)
)
AS
BEGIN
   -- Primero, insertamos una nueva orden en la tabla Orden
   INSERT INTO Orden
   (ord_fecha_de_generacion, ord_fecha_entrega, ord_id_cliente, ord_id_empleado)
   VALUES (@ord_fecha_de_generacion, @ord_fecha_entrega, @ord_id_cliente, @ord_id_empleado);

   -- Luego, obtenemos el ID de la última orden insertada
   DECLARE @last_order_id INT = SCOPE_IDENTITY();

   -- Ahora, actualizamos el stock del producto en la tabla Producto
   UPDATE Producto
   SET prod_stock = prod_stock - @det_ord_cantidad
   WHERE id_producto = @det_id_producto;

   -- Finalmente, insertamos el detalle de la orden en la tabla Detalle_orden
   INSERT INTO Detalle_orden (det_id_orden, det_id_producto, det_ord_precio, det_ord_cantidad, det_ord_total)
   VALUES (@last_order_id, @det_id_producto, @det_ord_precio, @det_ord_cantidad, @det_ord_precio * @det_ord_cantidad);
END




---Eliminar Detalle Orden
CREATE PROCEDURE EliminarDetalleOrden
(
    @id_detalle_orden INT
)
AS
BEGIN
   

    DELETE FROM Detalle_orden
    WHERE id_detalle_orden = @id_detalle_orden;
END


---------------------------------Generar orden------------------




  -----Obtener--por id orden todavia no -------------------------------------------------------------------------------------------------------------------------------------------------

  CREATE PROCEDURE ObtenerDetalleOrden
(
    @id_orden INT
)
AS
BEGIN
  

    SELECT id_detalle_orden, det_id_orden, det_id_producto, det_ord_precio, det_ord_cantidad
    FROM Detalle_orden
    WHERE det_id_orden = @id_orden;
END


  -----Obtener--POR ID ORDEN NO POR AHORA
  CREATE PROCEDURE ObtenerDetalleOrden
(
    @id_orden INT
)
AS
BEGIN
  

    SELECT id_detalle_orden, det_id_orden, det_id_producto, det_ord_precio, det_ord_cantidad
    FROM Detalle_orden
    WHERE det_id_orden = @id_orden;
END



EXECUTE ListarDetalleOrden;

INSERT INTO Orden (ord_fecha_de_generacion, ord_fecha_entrega, ord_id_cliente, ord_id_empleado)
VALUES 
('2022-01-01', '2022-01-02', 1, 7);

  SELECT *FROM Orden




  CREATE PROCEDURE GuardarDetalleOrden
(
@det_id_orden INT,
@det_id_producto INT,
@det_ord_precio DECIMAL(12,2),
@det_ord_cantidad DECIMAL(12,2)
)
AS
BEGIN
INSERT INTO Detalle_orden (det_id_orden, det_id_producto, det_ord_precio, det_ord_cantidad)
VALUES (@det_id_orden, @det_id_producto, @det_ord_precio, @det_ord_cantidad);
END



CREATE PROCEDURE GuardarDetalleOrden
(
@det_id_orden INT,
@det_id_producto INT,
@det_ord_precio DECIMAL(12,2),
@det_ord_cantidad DECIMAL(12,2)
)
AS
BEGIN
    INSERT INTO Detalle_orden (det_id_orden, det_id_producto, det_ord_precio, det_ord_cantidad, det_ord_total)
    VALUES (@det_id_orden, @det_id_producto, @det_ord_precio, @det_ord_cantidad, @det_ord_precio * @det_ord_cantidad);
	 UPDATE Producto
    SET prod_stock = prod_stock - @det_ord_cantidad
    WHERE id_producto = @det_id_producto;



END





--------------Agregar validacion para q no sea -1 el stock -------------

CREATE PROCEDURE EditarDetalleOrden
(
    @id_detalle_orden INT,
    @det_id_orden INT,
    @det_id_producto INT,
    @det_ord_precio DECIMAL(12,2),
    @det_ord_cantidad DECIMAL(12,2)
)
AS
BEGIN
  
    -- Validar que el stock no sea negativo después de la edición
    IF (SELECT prod_stock FROM Producto WHERE id_producto = @det_id_producto) - @det_ord_cantidad >= 0 THEN
    
        -- Descontar el stock del producto
        UPDATE Producto
        SET prod_stock = prod_stock - @det_ord_cantidad
        WHERE id_producto = @det_id_producto;
    
        -- Actualizar el detalle de orden
        UPDATE Detalle_orden
        SET det_id_orden = @det_id_orden, 
            det_id_producto = @det_id_producto,
            det_ord_precio = @det_ord_precio, 
            det_ord_cantidad = @det_ord_cantidad,
            det_ord_total = @det_ord_precio * @det_ord_cantidad
        WHERE id_detalle_orden = @id_detalle_orden;
    ELSE
        -- Lanzar un error
        RAISERROR('El stock del producto es insuficiente para realizar la edición', 16, 1);
    END IF;
END
