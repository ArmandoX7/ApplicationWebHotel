
CREATE DATABASE [Hotel]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Hotel', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\Hotel.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Hotel_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\Hotel_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Hotel] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Hotel].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Hotel] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Hotel] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Hotel] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Hotel] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Hotel] SET ARITHABORT OFF 
GO
ALTER DATABASE [Hotel] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Hotel] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Hotel] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Hotel] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Hotel] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Hotel] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Hotel] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Hotel] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Hotel] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Hotel] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Hotel] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Hotel] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Hotel] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Hotel] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Hotel] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Hotel] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Hotel] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Hotel] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Hotel] SET RECOVERY FULL 
GO
ALTER DATABASE [Hotel] SET  MULTI_USER 
GO
ALTER DATABASE [Hotel] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Hotel] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Hotel] SET FILESTREAM(NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Hotel] SET TARGET_RECOVERY_TIME = 0 SECONDS
GO
EXEC sys.sp_db_vardecimal_storage_format N'Hotel', N'ON'
GO
USE [Hotel]
GO
/****** Object:  StoredProcedure [dbo].[actualizarDescripcion]    Script Date: 17/04/2017 10:26:28 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[actualizardescripcion](@numeroHabitacion int, @descripcion nvarchar(MAX))
as
begin
	update Habitaciones set habDescripcion = @descripcion
	where habNumero = @numeroHabitacion
end
GO
/****** Object:  Table [dbo].[Alquiler]    Script Date: 17/04/2017 10:26:28 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Alquiler](
	[idAlquiler] [int] IDENTITY(1,1) NOT NULL,
	[alqHabitacion] [int] NOT NULL,
	[alqCliente] [int] NOT NULL,
	[alqFechaIngreso] [date] NOT NULL,
	[alqFechaSalida] [date] NOT NULL,
	[alqObservacion] [nvarchar](max) NULL,
	[alqEstado] [nvarchar](15) NOT NULL,
	[alqCostoTotal] [int] NOT NULL,
	[alqUsuario] [int] NOT NULL,
 CONSTRAINT [PK_Alquiler] PRIMARY KEY CLUSTERED 
(
	[idAlquiler] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 17/04/2017 10:26:28 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[idCliente] [int] IDENTITY(1,1) NOT NULL,
	[cliPersona] [int] NOT NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[idCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Contactenos]    Script Date: 17/04/2017 10:26:28 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contactenos](
	[idContactenos] [int] IDENTITY(1,1) NOT NULL,
	[conNombre] [nvarchar](50) NOT NULL,
	[conCorreo] [nvarchar](50) NOT NULL,
	[conComentario] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Contactenos] PRIMARY KEY CLUSTERED 
(
	[idContactenos] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Empleados]    Script Date: 17/04/2017 10:26:28 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleados](
	[idEmpleado] [int] IDENTITY(1,1) NOT NULL,
	[empPersona] [int] NOT NULL,
	[empCargo] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Empleados] PRIMARY KEY CLUSTERED 
(
	[idEmpleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Habitaciones]    */
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Habitaciones](
	[idHabitacion] [int] IDENTITY(1,1) NOT NULL,
	[habNumero] [int] NOT NULL,
	[habPiso] [int] NOT NULL,
	[habDescripcion] [nvarchar](max) NOT NULL,
	[habEstado] [nvarchar](15) NOT NULL,
	[habTipoHabitacion] [int] NOT NULL,
 CONSTRAINT [PK_Habitaciones] PRIMARY KEY CLUSTERED 
(
	[idHabitacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Personas]  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Personas](
	[idPersona] [int] IDENTITY(1,1) NOT NULL,
	[perIdentificacion] [nvarchar](15) NOT NULL,
	[perNombre] [nvarchar](50) NOT NULL,
	[perCorreo] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Personas] PRIMARY KEY CLUSTERED 
(
	[idPersona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TipoHabitaciones]     ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoHabitaciones](
	[idTipoHabitacion] [int] IDENTITY(1,1) NOT NULL,
	[tipNombre] [nvarchar](20) NOT NULL,
	[tipCosto] [int] NOT NULL,
 CONSTRAINT [PK_TipoHabitaciones] PRIMARY KEY CLUSTERED 
(
	[idTipoHabitacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Usuarios]     ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[idUsuario] [int] IDENTITY(1,1) NOT NULL,
	[usuEmpleado] [int] NOT NULL,
	[usuLogin] [nvarchar](15) NOT NULL,
	[usuPassword] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  View [dbo].[VistaCantidadHabitacionesPorTipo]     ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VistaCantidadHabitacionesPorTipo]
AS
SELECT        dbo.TipoHabitaciones.tipNombre, COUNT(dbo.Habitaciones.idHabitacion) AS Cantidad
FROM            dbo.Habitaciones INNER JOIN
                         dbo.TipoHabitaciones ON dbo.Habitaciones.habTipoHabitacion = dbo.TipoHabitaciones.idTipoHabitacion
GROUP BY dbo.TipoHabitaciones.tipNombre

GO
/****** Object:  View [dbo].[VistaEmpleadosCargo]   ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VistaEmpleadosCargo]
AS
SELECT        dbo.Personas.perIdentificacion, dbo.Personas.perNombre, dbo.Personas.perCorreo, dbo.Empleados.empCargo
FROM            dbo.Personas INNER JOIN
                         dbo.Empleados ON dbo.Personas.idPersona = dbo.Empleados.empPersona

GO
/****** Object:  View [dbo].[VistaHabitacionesAlquiladas]     ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VistaHabitacionesAlquiladas]
AS
SELECT        dbo.Personas.perNombre, dbo.Habitaciones.habNumero, dbo.Alquiler.alqFechaIngreso
FROM            dbo.Personas INNER JOIN
                         dbo.Clientes ON dbo.Personas.idPersona = dbo.Clientes.cliPersona INNER JOIN
                         dbo.Alquiler ON dbo.Clientes.idCliente = dbo.Alquiler.alqCliente INNER JOIN
                         dbo.Habitaciones ON dbo.Alquiler.alqHabitacion = dbo.Habitaciones.idHabitacion
WHERE        (dbo.Alquiler.alqEstado = 'Registrado')

GO
/****** Object:  View [dbo].[VistaHabitacionTipo]  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VistaHabitacionTipo]
AS
SELECT        dbo.Habitaciones.habNumero, dbo.Habitaciones.habPiso, dbo.Habitaciones.habDescripcion, dbo.TipoHabitaciones.tipNombre, dbo.TipoHabitaciones.tipCosto
FROM            dbo.Habitaciones INNER JOIN
                         dbo.TipoHabitaciones ON dbo.Habitaciones.habTipoHabitacion = dbo.TipoHabitaciones.idTipoHabitacion

GO
SET IDENTITY_INSERT [dbo].[Alquiler] ON 

INSERT [dbo].[Alquiler] ([idAlquiler], [alqHabitacion], [alqCliente], [alqFechaIngreso], [alqFechaSalida], [alqObservacion], [alqEstado], [alqCostoTotal], [alqUsuario]) VALUES (1, 5, 2, CAST(0x803C0B00 AS Date), CAST(0x993C0B00 AS Date), N'', N'Entregada', 1250000, 1)
INSERT [dbo].[Alquiler] ([idAlquiler], [alqHabitacion], [alqCliente], [alqFechaIngreso], [alqFechaSalida], [alqObservacion], [alqEstado], [alqCostoTotal], [alqUsuario]) VALUES (2, 1, 2, CAST(0x803C0B00 AS Date), CAST(0x993C0B00 AS Date), N'', N'Entregada', 1250000, 1)
INSERT [dbo].[Alquiler] ([idAlquiler], [alqHabitacion], [alqCliente], [alqFechaIngreso], [alqFechaSalida], [alqObservacion], [alqEstado], [alqCostoTotal], [alqUsuario]) VALUES (3, 1, 2, CAST(0x803C0B00 AS Date), CAST(0x993C0B00 AS Date), N'', N'Entregada', 1250000, 1)
INSERT [dbo].[Alquiler] ([idAlquiler], [alqHabitacion], [alqCliente], [alqFechaIngreso], [alqFechaSalida], [alqObservacion], [alqEstado], [alqCostoTotal], [alqUsuario]) VALUES (4, 6, 1, CAST(0x873C0B00 AS Date), CAST(0x993C0B00 AS Date), N'', N'Entregada', 1260000, 1)
INSERT [dbo].[Alquiler] ([idAlquiler], [alqHabitacion], [alqCliente], [alqFechaIngreso], [alqFechaSalida], [alqObservacion], [alqEstado], [alqCostoTotal], [alqUsuario]) VALUES (5, 6, 2, CAST(0x873C0B00 AS Date), CAST(0x993C0B00 AS Date), N'', N'Entregada', 1260000, 1)
INSERT [dbo].[Alquiler] ([idAlquiler], [alqHabitacion], [alqCliente], [alqFechaIngreso], [alqFechaSalida], [alqObservacion], [alqEstado], [alqCostoTotal], [alqUsuario]) VALUES (6, 8, 1, CAST(0x893C0B00 AS Date), CAST(0x993C0B00 AS Date), N'', N'Entregada', 800000, 1)
INSERT [dbo].[Alquiler] ([idAlquiler], [alqHabitacion], [alqCliente], [alqFechaIngreso], [alqFechaSalida], [alqObservacion], [alqEstado], [alqCostoTotal], [alqUsuario]) VALUES (7, 6, 1, CAST(0x8E3C0B00 AS Date), CAST(0x993C0B00 AS Date), N'', N'Entregada', 770000, 1)
INSERT [dbo].[Alquiler] ([idAlquiler], [alqHabitacion], [alqCliente], [alqFechaIngreso], [alqFechaSalida], [alqObservacion], [alqEstado], [alqCostoTotal], [alqUsuario]) VALUES (8, 1, 1, CAST(0x913C0B00 AS Date), CAST(0x993C0B00 AS Date), N'', N'Entregada', 400000, 1)
INSERT [dbo].[Alquiler] ([idAlquiler], [alqHabitacion], [alqCliente], [alqFechaIngreso], [alqFechaSalida], [alqObservacion], [alqEstado], [alqCostoTotal], [alqUsuario]) VALUES (9, 8, 2, CAST(0x913C0B00 AS Date), CAST(0x9A3C0B00 AS Date), N'xxxxxxxxxxx', N'Entregada', 450000, 1)
SET IDENTITY_INSERT [dbo].[Alquiler] OFF
SET IDENTITY_INSERT [dbo].[Clientes] ON 

INSERT [dbo].[Clientes] ([idCliente], [cliPersona]) VALUES (1, 6)
INSERT [dbo].[Clientes] ([idCliente], [cliPersona]) VALUES (2, 10)
SET IDENTITY_INSERT [dbo].[Clientes] OFF
SET IDENTITY_INSERT [dbo].[Contactenos] ON 

INSERT [dbo].[Contactenos] ([idContactenos], [conNombre], [conCorreo], [conComentario]) VALUES (1, N'Pedro', N'pedro@sss.com', N'Comentaio 11111..')
SET IDENTITY_INSERT [dbo].[Contactenos] OFF
SET IDENTITY_INSERT [dbo].[Empleados] ON 

INSERT [dbo].[Empleados] ([idEmpleado], [empPersona], [empCargo]) VALUES (1, 1, N'Gerente')
INSERT [dbo].[Empleados] ([idEmpleado], [empPersona], [empCargo]) VALUES (2, 2, N'Recepcionista')
INSERT [dbo].[Empleados] ([idEmpleado], [empPersona], [empCargo]) VALUES (4, 4, N'Recepcionista')
INSERT [dbo].[Empleados] ([idEmpleado], [empPersona], [empCargo]) VALUES (5, 5, N'Gerente')
INSERT [dbo].[Empleados] ([idEmpleado], [empPersona], [empCargo]) VALUES (6, 7, N'Gerente')
INSERT [dbo].[Empleados] ([idEmpleado], [empPersona], [empCargo]) VALUES (8, 9, N'Recepcionista')
INSERT [dbo].[Empleados] ([idEmpleado], [empPersona], [empCargo]) VALUES (9, 11, N'Recepcionista')
SET IDENTITY_INSERT [dbo].[Empleados] OFF
SET IDENTITY_INSERT [dbo].[Habitaciones] ON 

INSERT [dbo].[Habitaciones] ([idHabitacion], [habNumero], [habPiso], [habDescripcion], [habEstado], [habTipoHabitacion]) VALUES (1, 101, 1, N'Compuesta por cama sencilla, aire acondicionado, baño, televisor, agua caliente, internet.

Contiene una nevera pequeña.', N'Disponible', 1)
INSERT [dbo].[Habitaciones] ([idHabitacion], [habNumero], [habPiso], [habDescripcion], [habEstado], [habTipoHabitacion]) VALUES (3, 102, 1, N'Compuesta con cama doble, televisor, agua caliente, aire acondicionado, internet, nevera.', N'Disponible', 1)
INSERT [dbo].[Habitaciones] ([idHabitacion], [habNumero], [habPiso], [habDescripcion], [habEstado], [habTipoHabitacion]) VALUES (5, 201, 2, N'Compuesta por cama sencilla con televisor, con escritorio, nevera.', N'Disponible', 1)
INSERT [dbo].[Habitaciones] ([idHabitacion], [habNumero], [habPiso], [habDescripcion], [habEstado], [habTipoHabitacion]) VALUES (6, 202, 2, N'compuesta por dos camas', N'Disponible', 2)
INSERT [dbo].[Habitaciones] ([idHabitacion], [habNumero], [habPiso], [habDescripcion], [habEstado], [habTipoHabitacion]) VALUES (8, 301, 3, N'Consta de 1 cama sencilla, televisor, escritorio, baño. Aire acondicionado. Cuenta con conexión a televisión satelital.', N'Disponible', 1)
SET IDENTITY_INSERT [dbo].[Habitaciones] OFF
SET IDENTITY_INSERT [dbo].[Personas] ON 

INSERT [dbo].[Personas] ([idPersona], [perIdentificacion], [perNombre], [perCorreo]) VALUES (1, N'11', N'Pedro Picapiedra', N'ppiedra@yahoo.com')
INSERT [dbo].[Personas] ([idPersona], [perIdentificacion], [perNombre], [perCorreo]) VALUES (2, N'76', N'Marino Cuellar', N'ccuellar@sexxxxna.edu.co')
INSERT [dbo].[Personas] ([idPersona], [perIdentificacion], [perNombre], [perCorreo]) VALUES (4, N'77', N'Marino Cuellar', N'ccuellar@senjhghga.edu.co')
INSERT [dbo].[Personas] ([idPersona], [perIdentificacion], [perNombre], [perCorreo]) VALUES (5, N'78', N'Marino Cuellar', N'ccuellar@sena.edu.co')
INSERT [dbo].[Personas] ([idPersona], [perIdentificacion], [perNombre], [perCorreo]) VALUES (6, N'99', N'Pepito perez', N'pperez@sss.com')
INSERT [dbo].[Personas] ([idPersona], [perIdentificacion], [perNombre], [perCorreo]) VALUES (7, N'333', N'Cesar m Cuéllar', N'ccuellar@mwwwisena.edu.co')
INSERT [dbo].[Personas] ([idPersona], [perIdentificacion], [perNombre], [perCorreo]) VALUES (9, N'33', N'Cesar m Cuéllar', N'ccuellar@misweweweena.edu.co')
INSERT [dbo].[Personas] ([idPersona], [perIdentificacion], [perNombre], [perCorreo]) VALUES (10, N'1357', N'Monik Galindo', N'mgalindo@gmail.com')
INSERT [dbo].[Personas] ([idPersona], [perIdentificacion], [perNombre], [perCorreo]) VALUES (11, N'2468', N'Cesar M. Cuéllar', N'ccuellar@misena.edu.co')
SET IDENTITY_INSERT [dbo].[Personas] OFF
SET IDENTITY_INSERT [dbo].[TipoHabitaciones] ON 

INSERT [dbo].[TipoHabitaciones] ([idTipoHabitacion], [tipNombre], [tipCosto]) VALUES (1, N'Sencilla', 50000)
INSERT [dbo].[TipoHabitaciones] ([idTipoHabitacion], [tipNombre], [tipCosto]) VALUES (2, N'Doble', 70000)
INSERT [dbo].[TipoHabitaciones] ([idTipoHabitacion], [tipNombre], [tipCosto]) VALUES (3, N'Familiar', 100000)
SET IDENTITY_INSERT [dbo].[TipoHabitaciones] OFF
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([idUsuario], [usuEmpleado], [usuLogin], [usuPassword]) VALUES (1, 1, N'11', N'11')
INSERT [dbo].[Usuarios] ([idUsuario], [usuEmpleado], [usuLogin], [usuPassword]) VALUES (2, 2, N'76', N'76')
INSERT [dbo].[Usuarios] ([idUsuario], [usuEmpleado], [usuLogin], [usuPassword]) VALUES (3, 4, N'77', N'77')
INSERT [dbo].[Usuarios] ([idUsuario], [usuEmpleado], [usuLogin], [usuPassword]) VALUES (4, 5, N'78', N'78')
INSERT [dbo].[Usuarios] ([idUsuario], [usuEmpleado], [usuLogin], [usuPassword]) VALUES (5, 6, N'333', N'333')
INSERT [dbo].[Usuarios] ([idUsuario], [usuEmpleado], [usuLogin], [usuPassword]) VALUES (7, 8, N'33', N'33')
INSERT [dbo].[Usuarios] ([idUsuario], [usuEmpleado], [usuLogin], [usuPassword]) VALUES (8, 9, N'2468', N'2468')
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
/****** Object:  Index [UQ_Numero_Habitaciones]     ******/
ALTER TABLE [dbo].[Habitaciones] ADD  CONSTRAINT [UQ_Numero_Habitaciones] UNIQUE NONCLUSTERED 
(
	[habNumero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ_Correo_Personas]     ******/
ALTER TABLE [dbo].[Personas] ADD  CONSTRAINT [UQ_Correo_Personas] UNIQUE NONCLUSTERED 
(
	[perCorreo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ_Identificacion_Personas]     ******/
ALTER TABLE [dbo].[Personas] ADD  CONSTRAINT [UQ_Identificacion_Personas] UNIQUE NONCLUSTERED 
(
	[perIdentificacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ_Nombre_TipoHabitaciones]    ******/
ALTER TABLE [dbo].[TipoHabitaciones] ADD  CONSTRAINT [UQ_Nombre_TipoHabitaciones] UNIQUE NONCLUSTERED 
(
	[tipNombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ_Login_Usuarios]    ******/
ALTER TABLE [dbo].[Usuarios] ADD  CONSTRAINT [UQ_Login_Usuarios] UNIQUE NONCLUSTERED 
(
	[usuLogin] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Alquiler] ADD  CONSTRAINT [DF_Alquiler_alqFechaIngreso]  DEFAULT (getdate()) FOR [alqFechaIngreso]
GO
ALTER TABLE [dbo].[Alquiler] ADD  CONSTRAINT [DF_Alquiler_alqEstado]  DEFAULT (N'Registrado') FOR [alqEstado]
GO
ALTER TABLE [dbo].[Alquiler] ADD  CONSTRAINT [DF_Alquiler_alqCostoTotal]  DEFAULT ((0)) FOR [alqCostoTotal]
GO
ALTER TABLE [dbo].[Alquiler]  WITH CHECK ADD  CONSTRAINT [FK_Alquiler_Clientes] FOREIGN KEY([alqCliente])
REFERENCES [dbo].[Clientes] ([idCliente])
GO
ALTER TABLE [dbo].[Alquiler] CHECK CONSTRAINT [FK_Alquiler_Clientes]
GO
ALTER TABLE [dbo].[Alquiler]  WITH CHECK ADD  CONSTRAINT [FK_Alquiler_Habitaciones] FOREIGN KEY([alqHabitacion])
REFERENCES [dbo].[Habitaciones] ([idHabitacion])
GO
ALTER TABLE [dbo].[Alquiler] CHECK CONSTRAINT [FK_Alquiler_Habitaciones]
GO
ALTER TABLE [dbo].[Alquiler]  WITH CHECK ADD  CONSTRAINT [FK_Alquiler_Usuarios] FOREIGN KEY([alqUsuario])
REFERENCES [dbo].[Usuarios] ([idUsuario])
GO
ALTER TABLE [dbo].[Alquiler] CHECK CONSTRAINT [FK_Alquiler_Usuarios]
GO
ALTER TABLE [dbo].[Clientes]  WITH CHECK ADD  CONSTRAINT [FK_Clientes_Personas] FOREIGN KEY([cliPersona])
REFERENCES [dbo].[Personas] ([idPersona])
GO
ALTER TABLE [dbo].[Clientes] CHECK CONSTRAINT [FK_Clientes_Personas]
GO
ALTER TABLE [dbo].[Empleados]  WITH CHECK ADD  CONSTRAINT [FK_Empleados_Personas] FOREIGN KEY([empPersona])
REFERENCES [dbo].[Personas] ([idPersona])
GO
ALTER TABLE [dbo].[Empleados] CHECK CONSTRAINT [FK_Empleados_Personas]
GO
ALTER TABLE [dbo].[Habitaciones]  WITH CHECK ADD  CONSTRAINT [FK_Habitaciones_TipoHabitaciones] FOREIGN KEY([habTipoHabitacion])
REFERENCES [dbo].[TipoHabitaciones] ([idTipoHabitacion])
GO
ALTER TABLE [dbo].[Habitaciones] CHECK CONSTRAINT [FK_Habitaciones_TipoHabitaciones]
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_Empleados] FOREIGN KEY([usuEmpleado])
REFERENCES [dbo].[Empleados] ([idEmpleado])
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK_Usuarios_Empleados]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[21] 2[14] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Habitaciones"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 247
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TipoHabitaciones"
            Begin Extent = 
               Top = 6
               Left = 285
               Bottom = 119
               Right = 494
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 12
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VistaCantidadHabitacionesPorTipo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VistaCantidadHabitacionesPorTipo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[21] 2[13] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Personas"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 247
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Empleados"
            Begin Extent = 
               Top = 6
               Left = 285
               Bottom = 119
               Right = 494
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VistaEmpleadosCargo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VistaEmpleadosCargo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[21] 2[8] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = -96
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Personas"
            Begin Extent = 
               Top = 16
               Left = 61
               Bottom = 146
               Right = 270
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Clientes"
            Begin Extent = 
               Top = 33
               Left = 345
               Bottom = 129
               Right = 554
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Alquiler"
            Begin Extent = 
               Top = 74
               Left = 678
               Bottom = 204
               Right = 887
            End
            DisplayFlags = 280
            TopColumn = 5
         End
         Begin Table = "Habitaciones"
            Begin Extent = 
               Top = 174
               Left = 314
               Bottom = 304
               Right = 523
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
  ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VistaHabitacionesAlquiladas'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'    End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VistaHabitacionesAlquiladas'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VistaHabitacionesAlquiladas'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[10] 2[24] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Habitaciones"
            Begin Extent = 
               Top = 8
               Left = 79
               Bottom = 182
               Right = 288
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TipoHabitaciones"
            Begin Extent = 
               Top = 15
               Left = 400
               Bottom = 150
               Right = 609
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VistaHabitacionTipo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VistaHabitacionTipo'
GO
USE [master]
GO
ALTER DATABASE [Hotel] SET  READ_WRITE 
GO
