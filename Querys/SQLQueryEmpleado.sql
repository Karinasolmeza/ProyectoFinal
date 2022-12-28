CREATE TABLE Empleado(
  id_empleado int Identity primary key,
  emple_nombre varchar(45),
  emple_apellido varchar(45),
  emple_id_supervisor int NULL,
  emple_id_usuario int,
  
  FOREIGN KEY (emple_id_supervisor) REFERENCES Empleado(id_empleado),
  FOREIGN KEY (emple_id_usuario) REFERENCES Usuario(id_usuario)
);

DROP TABLE Empleado 
DROP PROCEDURE ListarEmpleado
--Procedure listar relacionado


CREATE PROCEDURE ListarEmpleado
AS
BEGIN
  SELECT e.*, u.*, s.*
  FROM Empleado e
    INNER JOIN Empleado s ON e.emple_id_supervisor = s.id_empleado
    INNER JOIN Usuario u ON e.emple_id_usuario = u.id_usuario;

END


--insert identity 
 SET IDENTITY_INSERT Empleado Off;
 INSERT INTO Empleado(id_empleado, emple_nombre, emple_apellido, emple_id_supervisor, emple_id_usuario)
VALUES (1,'Ariel','Profe',1,9);
  SELECT * FROM Empleado

  --Obtener 
  CREATE PROCEDURE ObtenerEmpleado(@id_emple int) AS
BEGIN 
SELECT * FROM Empleado WHERE id_empleado = @id_emple
END


  --Procedimiento Guardar relacionado
create procedure GuardarEmpleado(
@emple_nombre varchar(45),
@emple_apellido varchar(45),
@emple_id_supervisor int NULL,
@emple_id_usuario int


)
AS 
BEGIN 
INSERT INTO Empleado
(emple_nombre, emple_apellido, emple_id_supervisor, emple_id_usuario)
VALUES (@emple_nombre, @emple_apellido, @emple_id_supervisor, @emple_id_usuario)
END

SELECT *FROM Usuario


--Procedure Modificar relacionado
CREATE PROCEDURE EditarEmpleado(
@id_empleado int,
@emple_nombre varchar(45),
@emple_apellido varchar(45),
@emple_id_supervisor int NULL,
@emple_id_usuario int

) AS 
BEGIN 
UPDATE Empleado SET emple_nombre = @emple_nombre, emple_apellido= @emple_apellido, emple_id_supervisor = @emple_id_supervisor, emple_id_usuario = @emple_id_usuario
WHERE id_empleado = @id_empleado
END

--Procedure Eliminar 
CREATE PROCEDURE EliminarEmpleado(
@id_empleado int)
AS
BEGIN
DELETE FROM Empleado WHERE id_empleado = @id_empleado
END





--Procedures CRUD SIN RELACIONAR !!

CREATE PROCEDURE ListarEmpleado as
BEGIN 
SELECT * FROM Empleado
END

execute ListarEmpleado

CREATE PROCEDURE ObtenerEmpleado(@id_emple int) AS
BEGIN 
SELECT * FROM Empleado WHERE id_empleado = @id_emple
END

--Procedimiento Guardar 
create procedure GuardarEmpleado(
@emple_nombre varchar(45),
@emple_apellido varchar(45)


)
AS 
BEGIN 
INSERT INTO Empleado
(emple_nombre, emple_apellido)
VALUES (@emple_nombre, @emple_apellido)
END


--Procedure Modificar
CREATE PROCEDURE EditarEmpleado(
@id_empleado int,
@emple_nombre varchar(45),
@emple_apellido varchar(45)


) AS 
BEGIN 
UPDATE Empleado SET emple_nombre = @emple_nombre, emple_apellido= @emple_apellido 
WHERE id_empleado = @id_empleado
END


--Procedure Eliminar 
CREATE PROCEDURE EliminarEmpleado(
@id_empleado int)
AS
BEGIN
DELETE FROM Empleado WHERE id_empleado = @id_empleado
END



insert into Empleado (emple_nombre,emple_apellido) values('Empleado1','emple 1')

go

SELECT* FROM Empleado