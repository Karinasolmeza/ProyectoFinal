CREATE TABLE Categoria(
id_categoria int Identity primary key,
categ_detalle varchar(250) null
)
  
  SELECT * FROM Usuario

--Listar Categ
CREATE PROCEDURE ListarCategoria as
BEGIN 
SELECT * FROM Categoria
END

--obtener categ
CREATE PROCEDURE ObtenerCategoria(@id_Categ int) AS
BEGIN 
SELECT * FROM Categoria WHERE id_categoria = @id_Categ
END


-- Guardar Categ

create procedure GuardarCategoria(
@categ_detalle varchar(250)
)
AS 
BEGIN 
INSERT INTO Categoria
(categ_detalle)
VALUES (@categ_detalle)
END

--Editar categ

CREATE PROCEDURE EditarCategoria(
@id_categoria int,
@categ_detalle varchar(250)
) AS 
BEGIN 
UPDATE Categoria SET categ_detalle = @categ_detalle 
WHERE id_categoria = @id_categoria
END

--Eliminar categ

CREATE PROCEDURE EliminarCategoria(
@id_categoria int)
AS
BEGIN
DELETE FROM Categoria WHERE id_categoria = @id_categoria
END