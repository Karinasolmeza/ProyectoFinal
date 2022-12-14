USE [master]
GO
/****** Object:  Database [farmapruebas]    Script Date: 29/12/2022 09:05:54 ******/
CREATE DATABASE [farmapruebas]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'farmapruebas', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\farmapruebas.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'farmapruebas_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\farmapruebas_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [farmapruebas] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [farmapruebas].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [farmapruebas] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [farmapruebas] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [farmapruebas] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [farmapruebas] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [farmapruebas] SET ARITHABORT OFF 
GO
ALTER DATABASE [farmapruebas] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [farmapruebas] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [farmapruebas] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [farmapruebas] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [farmapruebas] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [farmapruebas] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [farmapruebas] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [farmapruebas] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [farmapruebas] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [farmapruebas] SET  DISABLE_BROKER 
GO
ALTER DATABASE [farmapruebas] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [farmapruebas] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [farmapruebas] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [farmapruebas] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [farmapruebas] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [farmapruebas] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [farmapruebas] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [farmapruebas] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [farmapruebas] SET  MULTI_USER 
GO
ALTER DATABASE [farmapruebas] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [farmapruebas] SET DB_CHAINING OFF 
GO
ALTER DATABASE [farmapruebas] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [farmapruebas] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [farmapruebas] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [farmapruebas] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [farmapruebas] SET QUERY_STORE = OFF
GO
USE [farmapruebas]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 29/12/2022 09:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[id_categoria] [int] IDENTITY(1,1) NOT NULL,
	[categ_detalle] [varchar](250) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_categoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 29/12/2022 09:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[id_cliente] [int] IDENTITY(1,1) NOT NULL,
	[clie_nombre] [varchar](50) NULL,
	[clie_apellido] [varchar](50) NULL,
	[clie_dni] [varchar](45) NULL,
	[clie_cuit] [varchar](45) NULL,
	[clie_razon_social] [varchar](50) NULL,
	[clie_tipo] [varchar](50) NULL,
	[clie_id_usuario] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Detalle_orden]    Script Date: 29/12/2022 09:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Detalle_orden](
	[id_detalle_orden] [int] IDENTITY(1,1) NOT NULL,
	[det_id_orden] [int] NULL,
	[det_id_producto] [int] NULL,
	[det_ord_precio] [decimal](12, 2) NULL,
	[det_ord_cantidad] [decimal](12, 2) NULL,
	[det_ord_total] [decimal](18, 0) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_detalle_orden] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empleado]    Script Date: 29/12/2022 09:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleado](
	[id_empleado] [int] IDENTITY(1,1) NOT NULL,
	[emple_nombre] [varchar](45) NULL,
	[emple_apellido] [varchar](45) NULL,
	[emple_id_supervisor] [int] NULL,
	[emple_id_usuario] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_empleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orden]    Script Date: 29/12/2022 09:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orden](
	[id_orden] [int] IDENTITY(1,1) NOT NULL,
	[ord_fecha_de_generacion] [date] NULL,
	[ord_fecha_entrega] [date] NULL,
	[ord_id_cliente] [int] NULL,
	[ord_id_empleado] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_orden] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 29/12/2022 09:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[id_producto] [int] IDENTITY(1,1) NOT NULL,
	[prod_nombre] [varchar](60) NULL,
	[prod_precio] [decimal](12, 2) NULL,
	[prod_stock] [decimal](12, 2) NULL,
	[prod_detalle] [varchar](250) NULL,
	[prod_img] [varchar](250) NULL,
	[prod_proveedor] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_producto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Promocion_producto]    Script Date: 29/12/2022 09:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Promocion_producto](
	[promo_numero] [int] IDENTITY(1,1) NOT NULL,
	[id_promo] [int] NULL,
	[id_producto] [int] NULL,
	[promo_fecha_inicio] [datetime] NULL,
	[promo_fecha_fin] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[promo_numero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Promociones]    Script Date: 29/12/2022 09:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Promociones](
	[id_promo] [int] IDENTITY(1,1) NOT NULL,
	[promo_nombre] [varchar](250) NULL,
	[promo_descuento] [decimal](12, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_promo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proveedor]    Script Date: 29/12/2022 09:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proveedor](
	[id_proveedor] [int] IDENTITY(1,1) NOT NULL,
	[prove_nombre] [varchar](45) NULL,
	[prove_apellido] [varchar](45) NULL,
	[prove_direccion] [varchar](250) NULL,
	[prove_cuit] [varchar](45) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_proveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proveedor_Categoria]    Script Date: 29/12/2022 09:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proveedor_Categoria](
	[id_proveedor] [int] NULL,
	[id_categoria] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 29/12/2022 09:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[id_rol] [int] IDENTITY(1,1) NOT NULL,
	[rol_detalle] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_rol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 29/12/2022 09:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[id_usuario] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Correo] [varchar](50) NULL,
	[Clave] [varchar](100) NULL,
	[usuario_rol] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD FOREIGN KEY([clie_id_usuario])
REFERENCES [dbo].[Usuario] ([id_usuario])
GO
ALTER TABLE [dbo].[Detalle_orden]  WITH CHECK ADD FOREIGN KEY([det_id_orden])
REFERENCES [dbo].[Orden] ([id_orden])
GO
ALTER TABLE [dbo].[Detalle_orden]  WITH CHECK ADD FOREIGN KEY([det_id_producto])
REFERENCES [dbo].[Producto] ([id_producto])
GO
ALTER TABLE [dbo].[Empleado]  WITH CHECK ADD FOREIGN KEY([emple_id_supervisor])
REFERENCES [dbo].[Empleado] ([id_empleado])
GO
ALTER TABLE [dbo].[Empleado]  WITH CHECK ADD FOREIGN KEY([emple_id_usuario])
REFERENCES [dbo].[Usuario] ([id_usuario])
GO
ALTER TABLE [dbo].[Orden]  WITH CHECK ADD FOREIGN KEY([ord_id_cliente])
REFERENCES [dbo].[Cliente] ([id_cliente])
GO
ALTER TABLE [dbo].[Orden]  WITH CHECK ADD FOREIGN KEY([ord_id_empleado])
REFERENCES [dbo].[Empleado] ([id_empleado])
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD FOREIGN KEY([prod_proveedor])
REFERENCES [dbo].[Proveedor] ([id_proveedor])
GO
ALTER TABLE [dbo].[Promocion_producto]  WITH CHECK ADD FOREIGN KEY([id_promo])
REFERENCES [dbo].[Promociones] ([id_promo])
GO
ALTER TABLE [dbo].[Promocion_producto]  WITH CHECK ADD FOREIGN KEY([id_producto])
REFERENCES [dbo].[Producto] ([id_producto])
GO
ALTER TABLE [dbo].[Proveedor_Categoria]  WITH CHECK ADD FOREIGN KEY([id_categoria])
REFERENCES [dbo].[Categoria] ([id_categoria])
GO
ALTER TABLE [dbo].[Proveedor_Categoria]  WITH CHECK ADD FOREIGN KEY([id_proveedor])
REFERENCES [dbo].[Proveedor] ([id_proveedor])
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD FOREIGN KEY([usuario_rol])
REFERENCES [dbo].[Roles] ([id_rol])
GO
/****** Object:  StoredProcedure [dbo].[AutenticarUsuario]    Script Date: 29/12/2022 09:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AutenticarUsuario] (@Correo varchar(50), @Clave varchar(100)) AS
begin 
SELECT * FROM Usuario inner join Roles on Usuario.usuario_rol = id_rol where Correo like @Correo AND Clave LIKE @Clave
end
GO
/****** Object:  StoredProcedure [dbo].[EditarCategoria]    Script Date: 29/12/2022 09:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditarCategoria](
@id_categoria int,
@categ_detalle varchar(250)
) AS 
BEGIN 
UPDATE Categoria SET categ_detalle = @categ_detalle 
WHERE id_categoria = @id_categoria
END
GO
/****** Object:  StoredProcedure [dbo].[EditarCliente]    Script Date: 29/12/2022 09:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditarCliente](
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
GO
/****** Object:  StoredProcedure [dbo].[EditarDetalleOrden]    Script Date: 29/12/2022 09:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditarDetalleOrden]
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
GO
/****** Object:  StoredProcedure [dbo].[EditarEmpleado]    Script Date: 29/12/2022 09:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditarEmpleado](
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
GO
/****** Object:  StoredProcedure [dbo].[EditarOrden]    Script Date: 29/12/2022 09:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditarOrden](
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
GO
/****** Object:  StoredProcedure [dbo].[EditarProducto]    Script Date: 29/12/2022 09:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditarProducto](

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

GO
/****** Object:  StoredProcedure [dbo].[EditarPromociones]    Script Date: 29/12/2022 09:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditarPromociones](
@id_promo int,
@promo_nombre varchar(250) NULL,
@promo_descuento DECIMAl (12,2) NULL
) AS 
BEGIN 
UPDATE Promociones SET promo_nombre = @promo_nombre, promo_descuento = @promo_descuento
WHERE id_promo = @id_promo
END
GO
/****** Object:  StoredProcedure [dbo].[EditarPromocionProducto]    Script Date: 29/12/2022 09:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EditarPromocionProducto]
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
GO
/****** Object:  StoredProcedure [dbo].[EditarProveedor]    Script Date: 29/12/2022 09:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditarProveedor](
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
GO
/****** Object:  StoredProcedure [dbo].[EditarProveedorCategoria]    Script Date: 29/12/2022 09:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditarProveedorCategoria]
    @id_proveedor INT,
    @id_categoria INT
AS
BEGIN
    UPDATE Proveedor_categoria
    SET id_categoria = @id_categoria
    WHERE id_proveedor = @id_proveedor
END
GO
/****** Object:  StoredProcedure [dbo].[EditarRol]    Script Date: 29/12/2022 09:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditarRol](
@id_rol int,
@rol_detalle varchar(50)

) AS 
BEGIN 
UPDATE Roles SET rol_detalle = @rol_detalle 
WHERE id_rol = @id_rol
END

GO
/****** Object:  StoredProcedure [dbo].[EditarUsuario]    Script Date: 29/12/2022 09:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditarUsuario](

@id_usuario int,
@Nombre varchar(50),
@Correo varchar(50),
@Clave varchar(100),
@usuario_rol int


) AS 
BEGIN 
UPDATE Usuario SET Nombre = @Nombre, Correo = @Correo, Clave = @Clave, usuario_rol = @usuario_rol 
WHERE id_usuario = @id_usuario
END
GO
/****** Object:  StoredProcedure [dbo].[EliminarCategoria]    Script Date: 29/12/2022 09:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EliminarCategoria](
@id_categoria int)
AS
BEGIN
DELETE FROM Categoria WHERE id_categoria = @id_categoria
END
GO
/****** Object:  StoredProcedure [dbo].[EliminarCliente]    Script Date: 29/12/2022 09:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EliminarCliente](
@id_cliente int)
AS
BEGIN
DELETE FROM Cliente WHERE id_cliente = @id_cliente
END

GO
/****** Object:  StoredProcedure [dbo].[EliminarDetalleOrden]    Script Date: 29/12/2022 09:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EliminarDetalleOrden]
(
    @id_detalle_orden INT
)
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM Detalle_orden
    WHERE id_detalle_orden = @id_detalle_orden;
END
GO
/****** Object:  StoredProcedure [dbo].[EliminarEmpleado]    Script Date: 29/12/2022 09:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EliminarEmpleado](
@id_empleado int)
AS
BEGIN
DELETE FROM Empleado WHERE id_empleado = @id_empleado
END
GO
/****** Object:  StoredProcedure [dbo].[EliminarOrden]    Script Date: 29/12/2022 09:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EliminarOrden](
@id_orden int)
AS
BEGIN
DELETE FROM Orden WHERE id_orden = @id_orden
END
GO
/****** Object:  StoredProcedure [dbo].[EliminarProducto]    Script Date: 29/12/2022 09:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EliminarProducto](
@id_producto int)
AS
BEGIN
DELETE FROM Producto WHERE id_producto = @id_producto
END
GO
/****** Object:  StoredProcedure [dbo].[EliminarPromociones]    Script Date: 29/12/2022 09:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EliminarPromociones](
@id_promo int)
AS
BEGIN
DELETE FROM Promociones WHERE id_promo = @id_promo
END
GO
/****** Object:  StoredProcedure [dbo].[EliminarPromocionProducto]    Script Date: 29/12/2022 09:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EliminarPromocionProducto]
(
    @promo_numero INT
)
AS
BEGIN
   

    DELETE FROM Promocion_producto
    WHERE promo_numero = @promo_numero;
END
GO
/****** Object:  StoredProcedure [dbo].[EliminarProveedor]    Script Date: 29/12/2022 09:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EliminarProveedor](
@id_proveedor int)
AS
BEGIN
DELETE FROM Proveedor WHERE id_proveedor = @id_proveedor
END

GO
/****** Object:  StoredProcedure [dbo].[EliminarProveedorCategoria]    Script Date: 29/12/2022 09:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EliminarProveedorCategoria]
    @id_proveedor INT,
    @id_categoria INT
AS
BEGIN
    DELETE FROM Proveedor_Categoria
    WHERE id_proveedor = @id_proveedor AND id_categoria = @id_categoria
END
GO
/****** Object:  StoredProcedure [dbo].[EliminarRol]    Script Date: 29/12/2022 09:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EliminarRol](
@id_rol int)
AS
BEGIN
DELETE FROM Roles WHERE id_rol = @id_rol
END
GO
/****** Object:  StoredProcedure [dbo].[EliminarUsuario]    Script Date: 29/12/2022 09:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EliminarUsuario](
@id_usuario int)
AS
BEGIN
DELETE FROM Usuario WHERE id_usuario = @id_usuario
END
GO
/****** Object:  StoredProcedure [dbo].[GenerarOrden]    Script Date: 29/12/2022 09:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GenerarOrden]
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
GO
/****** Object:  StoredProcedure [dbo].[GuardarCategoria]    Script Date: 29/12/2022 09:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GuardarCategoria](
@categ_detalle varchar(250)
)
AS 
BEGIN 
INSERT INTO Categoria
(categ_detalle)
VALUES (@categ_detalle)
END
GO
/****** Object:  StoredProcedure [dbo].[GuardarCliente]    Script Date: 29/12/2022 09:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GuardarCliente](
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
GO
/****** Object:  StoredProcedure [dbo].[GuardarDetalleOrden]    Script Date: 29/12/2022 09:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GuardarDetalleOrden]
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
GO
/****** Object:  StoredProcedure [dbo].[GuardarDetalleOrdenCliente]    Script Date: 29/12/2022 09:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GuardarDetalleOrdenCliente]
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
GO
/****** Object:  StoredProcedure [dbo].[GuardarEmpleado]    Script Date: 29/12/2022 09:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GuardarEmpleado](
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
GO
/****** Object:  StoredProcedure [dbo].[GuardarOrden]    Script Date: 29/12/2022 09:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GuardarOrden](

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

GO
/****** Object:  StoredProcedure [dbo].[GuardarOrdenCliente]    Script Date: 29/12/2022 09:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GuardarOrdenCliente](

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
GO
/****** Object:  StoredProcedure [dbo].[GuardarProducto]    Script Date: 29/12/2022 09:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GuardarProducto](
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
GO
/****** Object:  StoredProcedure [dbo].[GuardarPromociones]    Script Date: 29/12/2022 09:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GuardarPromociones](
@promo_nombre varchar(250) NULL,
@promo_descuento decimal (12,2) NULL
)
AS 
BEGIN 
INSERT INTO Promociones
(promo_nombre, promo_descuento)
VALUES (@promo_nombre, @promo_descuento)
END
GO
/****** Object:  StoredProcedure [dbo].[GuardarPromocionProducto]    Script Date: 29/12/2022 09:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GuardarPromocionProducto]
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
GO
/****** Object:  StoredProcedure [dbo].[GuardarProveedor]    Script Date: 29/12/2022 09:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GuardarProveedor](
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
GO
/****** Object:  StoredProcedure [dbo].[GuardarProveedorCategoria]    Script Date: 29/12/2022 09:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GuardarProveedorCategoria]
    @id_proveedor int,
    @id_categoria int
AS
BEGIN
    INSERT INTO Proveedor_categoria (id_proveedor, id_categoria)
    VALUES (@id_proveedor, @id_categoria)
END
GO
/****** Object:  StoredProcedure [dbo].[GuardarRol]    Script Date: 29/12/2022 09:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GuardarRol](
@rol_detalle varchar(50)

)
AS 
BEGIN 
INSERT INTO Roles(rol_detalle)
VALUES (@rol_detalle)
END
GO
/****** Object:  StoredProcedure [dbo].[GuardarUsuario]    Script Date: 29/12/2022 09:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GuardarUsuario](
@Nombre varchar(50),
@Correo varchar(50),
@Clave varchar(100),
@usuario_rol int


)
AS 
BEGIN 
INSERT INTO Usuario(Nombre, Correo, Clave, usuario_rol)
VALUES (@Nombre, @Correo, @Clave, @usuario_rol)
END
GO
/****** Object:  StoredProcedure [dbo].[ListarCategoria]    Script Date: 29/12/2022 09:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ListarCategoria] as
BEGIN 
SELECT * FROM Categoria
END
GO
/****** Object:  StoredProcedure [dbo].[ListarCliente]    Script Date: 29/12/2022 09:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ListarCliente] as
BEGIN 
SELECT * FROM Cliente inner join Usuario ON Cliente.clie_id_usuario = Usuario.id_usuario
END
GO
/****** Object:  StoredProcedure [dbo].[ListarDetalleOrden]    Script Date: 29/12/2022 09:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ListarDetalleOrden]
(
    @id_orden INT = NULL
)
AS
BEGIN
    SELECT * FROM Detalle_orden
    WHERE (@id_orden IS NULL OR det_id_orden = @id_orden)
END
GO
/****** Object:  StoredProcedure [dbo].[ListarEmpleado]    Script Date: 29/12/2022 09:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ListarEmpleado]
AS
BEGIN
  SELECT e.*, u.*, s.*
  FROM Empleado e
    INNER JOIN Empleado s ON e.emple_id_supervisor = s.id_empleado
    INNER JOIN Usuario u ON e.emple_id_usuario = u.id_usuario;

END
GO
/****** Object:  StoredProcedure [dbo].[ListarOrden]    Script Date: 29/12/2022 09:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ListarOrden]
AS
BEGIN
  SELECT o.*, c.*, e.*
  FROM Orden o
    INNER JOIN Cliente c ON o.ord_id_cliente = c.id_cliente
    INNER JOIN Empleado e ON o.ord_id_empleado = e.id_empleado;

END
GO
/****** Object:  StoredProcedure [dbo].[ListarProducto]    Script Date: 29/12/2022 09:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ListarProducto] as
BEGIN 
SELECT * FROM Producto inner join Proveedor ON Producto.prod_proveedor = Proveedor.id_proveedor
END
GO
/****** Object:  StoredProcedure [dbo].[ListarPromociones]    Script Date: 29/12/2022 09:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Listar Promos
CREATE PROCEDURE [dbo].[ListarPromociones] as
BEGIN 
SELECT * FROM Promociones
END
GO
/****** Object:  StoredProcedure [dbo].[ListarPromocionProducto]    Script Date: 29/12/2022 09:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ListarPromocionProducto]
(
    @id_promo INT = NULL
)
AS
BEGIN
    SELECT * FROM Promocion_producto
    WHERE (@id_promo IS NULL OR id_promo = @id_promo)
END
GO
/****** Object:  StoredProcedure [dbo].[ListarProveedor]    Script Date: 29/12/2022 09:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ListarProveedor] as
BEGIN 
SELECT * FROM Proveedor
END
GO
/****** Object:  StoredProcedure [dbo].[ListarProveedorCategoria]    Script Date: 29/12/2022 09:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ListarProveedorCategoria]
AS
BEGIN
    SELECT p.id_proveedor, p.prove_nombre, c.id_categoria, c.categ_detalle
    FROM Proveedor_Categoria pc
    INNER JOIN Proveedor p ON pc.id_proveedor = p.id_proveedor
    INNER JOIN Categoria c ON pc.id_categoria = c.id_categoria
END
GO
/****** Object:  StoredProcedure [dbo].[ListarRol]    Script Date: 29/12/2022 09:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ListarRol] as
BEGIN 
SELECT * FROM Roles
END
GO
/****** Object:  StoredProcedure [dbo].[ListarUsuario]    Script Date: 29/12/2022 09:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE PROCEDURE [dbo].[ListarUsuario]
AS
BEGIN
  SELECT *
  FROM Usuario
END
GO
/****** Object:  StoredProcedure [dbo].[ListarUsuarioRol]    Script Date: 29/12/2022 09:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ListarUsuarioRol] as
BEGIN 
SELECT * FROM Usuario inner join Roles ON Usuario.usuario_rol = Roles.id_Rol
END
GO
/****** Object:  StoredProcedure [dbo].[mostrarProducto]    Script Date: 29/12/2022 09:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[mostrarProducto]
AS
BEGIN
  SELECT id_producto,prod_nombre, prod_precio, prod_stock, prod_detalle, prod_img
  FROM Producto
END
GO
/****** Object:  StoredProcedure [dbo].[ObtenerCategoria]    Script Date: 29/12/2022 09:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ObtenerCategoria](@id_Categ int) AS
BEGIN 
SELECT * FROM Categoria WHERE id_categoria = @id_Categ
END
GO
/****** Object:  StoredProcedure [dbo].[ObtenerCliente]    Script Date: 29/12/2022 09:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ObtenerCliente](@id_Contacto int) AS
BEGIN 
SELECT * FROM Cliente WHERE id_cliente = @id_Contacto
END
GO
/****** Object:  StoredProcedure [dbo].[ObtenerDetalleOrden]    Script Date: 29/12/2022 09:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ObtenerDetalleOrden](@id_detalle_orden int) AS
BEGIN 
SELECT * FROM Detalle_orden WHERE id_detalle_orden = @id_detalle_orden
END
GO
/****** Object:  StoredProcedure [dbo].[ObtenerEmpleado]    Script Date: 29/12/2022 09:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ObtenerEmpleado](@id_emple int) AS
BEGIN 
SELECT * FROM Empleado WHERE id_empleado = @id_emple
END
GO
/****** Object:  StoredProcedure [dbo].[ObtenerOrden]    Script Date: 29/12/2022 09:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ObtenerOrden](@id_orden int) AS
BEGIN 
SELECT * FROM Orden WHERE id_orden = @id_orden
END
GO
/****** Object:  StoredProcedure [dbo].[ObtenerProducto]    Script Date: 29/12/2022 09:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ObtenerProducto](@id_prod int) AS
BEGIN 
SELECT * FROM Producto WHERE id_producto = @id_prod
END
GO
/****** Object:  StoredProcedure [dbo].[ObtenerPromociones]    Script Date: 29/12/2022 09:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ObtenerPromociones](@id_Promo int) AS
BEGIN 
SELECT * FROM Promociones WHERE id_promo = @id_promo
END
GO
/****** Object:  StoredProcedure [dbo].[ObtenerPromocionProducto]    Script Date: 29/12/2022 09:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ObtenerPromocionProducto](@promo_numero int) AS
BEGIN 
SELECT * FROM Promocion_producto WHERE @promo_numero = @promo_numero
END
GO
/****** Object:  StoredProcedure [dbo].[ObtenerProveedor]    Script Date: 29/12/2022 09:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ObtenerProveedor](@id_Prove int) AS
BEGIN 
SELECT * FROM Proveedor WHERE id_proveedor = @id_Prove
END
GO
/****** Object:  StoredProcedure [dbo].[ObtenerProveedorCategoria]    Script Date: 29/12/2022 09:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE PROCEDURE [dbo].[ObtenerProveedorCategoria](@id_proveedor int, @id_categoria int) AS
BEGIN 
SELECT * FROM Proveedor_Categoria WHERE id_proveedor = @id_proveedor
END
GO
/****** Object:  StoredProcedure [dbo].[ObtenerRol]    Script Date: 29/12/2022 09:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ObtenerRol](@id_rol int) AS
BEGIN 
SELECT * FROM Roles WHERE @id_rol = @id_rol
END
GO
/****** Object:  StoredProcedure [dbo].[ObtenerUsuario]    Script Date: 29/12/2022 09:05:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ObtenerUsuario](@id_usuario int) AS
BEGIN 
SELECT * FROM Usuario WHERE id_usuario = @id_usuario
END
GO
USE [master]
GO
ALTER DATABASE [farmapruebas] SET  READ_WRITE 
GO
