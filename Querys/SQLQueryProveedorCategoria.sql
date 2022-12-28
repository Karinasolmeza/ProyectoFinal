CREATE TABLE Categoria(
id_categoria int Identity primary key,
categ_detalle varchar(250)
)


CREATE TABLE Proveedor_Categoria(
id_proveedor int,  
id_categoria int,
FOREIGN KEY (id_proveedor) REFERENCES Proveedor(id_proveedor),
FOREIGN KEY (id_categoria) REFERENCES Categoria(id_categoria)
)

CREATE TABLE Proveedor(
id_proveedor int Identity primary key,
prove_nombre varchar(45),
prove_apellido varchar(45),
prove_direccion varchar(250),
prove_cuit varchar(45)

)

--Listar prov_cat
CREATE PROCEDURE ListarProveedorCategoria
AS
BEGIN
    SELECT p.id_proveedor, p.prove_nombre, c.id_categoria, c.categ_detalle
    FROM Proveedor_Categoria pc
    INNER JOIN Proveedor p ON pc.id_proveedor = p.id_proveedor
    INNER JOIN Categoria c ON pc.id_categoria = c.id_categoria
END

 ---Obtener Prove_cat 

 CREATE PROCEDURE ObtenerProveedorCategoria(@id_proveedor int, @id_categoria int) AS
BEGIN 
SELECT * FROM Proveedor_Categoria WHERE id_proveedor = @id_proveedor
END


--Guardar proveedor_categoria
CREATE PROCEDURE GuardarProveedorCategoria
    @id_proveedor int,
    @id_categoria int
AS
BEGIN
    INSERT INTO Proveedor_categoria (id_proveedor, id_categoria)
    VALUES (@id_proveedor, @id_categoria)
END


--Editar proveedor_categoria
CREATE PROCEDURE EditarProveedorCategoria
    @id_proveedor INT,
    @id_categoria INT
AS
BEGIN
    UPDATE Proveedor_categoria
    SET id_categoria = @id_categoria
    WHERE id_proveedor = @id_proveedor
END


--Eliminar categoria proveedor
CREATE PROCEDURE EliminarProveedorCategoria
    @id_proveedor INT,
	@id_categoria INT

AS
BEGIN
    
    DELETE FROM Proveedor_Categoria
    WHERE id_proveedor = @id_proveedor

END


DROP PROCEDURE EliminarProveedorCategoria
--eliminar relacion 
CREATE PROCEDURE EliminarProveedorCategoria
    @id_proveedor INT,
    @id_categoria INT
AS
BEGIN
    DELETE FROM Proveedor_Categoria
    WHERE id_proveedor = @id_proveedor AND id_categoria = @id_categoria
END


-------------------------------------------------------------------------
 --Ver que pasa con proveedor    
DELETE FROM Proveedor
    WHERE id_proveedor = @id_proveedor


	--guardar por nombre ESTE NO
CREATE PROCEDURE GuardarCategoriaPorProveedor(@proveedor INT,@categoria VARCHAR(50))ASBEGIN	DECLARE @categoria_id INT	SET @categoria_id = (SELECT cate_id FROM Categoria WHERE cate_nombre = @categoria)	INSERT INTO CategoriaProveedor(cp_proveedor, cp_categoria) 							VALUES(@proveedor, @categoria_id)END


INSERT INTO Proveedor_Categoria (id_proveedor, id_categoria)
VALUES (1, 1);


INSERT INTO Proveedor_Categoria (id_proveedor, id_categoria)
VALUES (1, 3);


Select * from Proveedor_Categoria

select * from Proveedor, Categoria

