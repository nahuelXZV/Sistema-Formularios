USE [master]
GO
/****** Object:  Database [template]    Script Date: 27/4/2025 17:49:58 ******/
CREATE DATABASE [template]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'template', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\template.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'template_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\template_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [template] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [template].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [template] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [template] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [template] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [template] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [template] SET ARITHABORT OFF 
GO
ALTER DATABASE [template] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [template] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [template] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [template] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [template] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [template] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [template] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [template] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [template] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [template] SET  DISABLE_BROKER 
GO
ALTER DATABASE [template] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [template] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [template] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [template] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [template] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [template] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [template] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [template] SET RECOVERY FULL 
GO
ALTER DATABASE [template] SET  MULTI_USER 
GO
ALTER DATABASE [template] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [template] SET DB_CHAINING OFF 
GO
ALTER DATABASE [template] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [template] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [template] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [template] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'template', N'ON'
GO
ALTER DATABASE [template] SET QUERY_STORE = ON
GO
ALTER DATABASE [template] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200)
GO
USE [template]
GO
/****** Object:  Schema [Configuracion]    Script Date: 27/4/2025 17:49:59 ******/
CREATE SCHEMA [Configuracion]
GO
/****** Object:  Schema [Formulario]    Script Date: 27/4/2025 17:49:59 ******/
CREATE SCHEMA [Formulario]
GO
/****** Object:  Schema [General]    Script Date: 27/4/2025 17:49:59 ******/
CREATE SCHEMA [General]
GO
/****** Object:  Schema [Seguridad]    Script Date: 27/4/2025 17:49:59 ******/
CREATE SCHEMA [Seguridad]
GO
/****** Object:  Table [Configuracion].[Concepto]    Script Date: 27/4/2025 17:49:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Configuracion].[Concepto](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Tipo] [int] NOT NULL,
	[Clave] [varchar](250) NOT NULL,
	[Nombre] [varchar](250) NOT NULL,
	[Valor] [varchar](250) NOT NULL,
	[Descripcion] [varchar](250) NULL,
	[Secuencia] [int] NOT NULL,
	[Editable] [bit] NULL,
 CONSTRAINT [PK_Concepto] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Configuracion].[Entidad]    Script Date: 27/4/2025 17:49:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Configuracion].[Entidad](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](250) NOT NULL,
	[Descripcion] [varchar](250) NULL,
	[Direccion] [varchar](250) NULL,
	[Latitud] [varchar](250) NULL,
	[Longitud] [varchar](250) NULL,
	[Telefono] [varchar](50) NULL,
	[Correo] [varchar](250) NULL,
	[Eliminado] [bit] NOT NULL,
 CONSTRAINT [PK_Entidad] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Formulario].[Formulario]    Script Date: 27/4/2025 17:49:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Formulario].[Formulario](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](250) NOT NULL,
	[Descripcion] [varchar](250) NULL,
	[Ponderacion] [float] NOT NULL,
	[Orden] [smallint] NULL,
	[Activo] [bit] NOT NULL,
	[Eliminado] [bit] NOT NULL,
 CONSTRAINT [PK_Formulario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Formulario].[Gestion]    Script Date: 27/4/2025 17:49:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Formulario].[Gestion](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](250) NOT NULL,
	[Descripcion] [varchar](250) NULL,
	[FechaInicio] [datetime] NOT NULL,
	[FechaFin] [datetime] NOT NULL,
	[Activo] [bit] NOT NULL,
	[Terminado] [bit] NOT NULL,
	[Eliminado] [bit] NOT NULL,
 CONSTRAINT [PK_Gestion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Formulario].[Grupo]    Script Date: 27/4/2025 17:49:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Formulario].[Grupo](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](250) NOT NULL,
	[Descripcion] [varchar](250) NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[Activo] [bit] NOT NULL,
	[Eliminado] [bit] NOT NULL,
 CONSTRAINT [PK_Grupo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Formulario].[GrupoFormulario]    Script Date: 27/4/2025 17:49:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Formulario].[GrupoFormulario](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[GrupoId] [bigint] NOT NULL,
	[FormularioId] [bigint] NOT NULL,
	[Eliminado] [bit] NOT NULL,
 CONSTRAINT [PK_GrupoFormulario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Formulario].[Pregunta]    Script Date: 27/4/2025 17:49:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Formulario].[Pregunta](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Enunciado] [varchar](max) NOT NULL,
	[Descripcion] [varchar](max) NOT NULL,
	[Orden] [smallint] NOT NULL,
	[Ponderacion] [float] NOT NULL,
	[Activo] [bit] NOT NULL,
	[Requerido] [bit] NOT NULL,
	[Opciones] [varchar](max) NULL,
	[TipoId] [bigint] NOT NULL,
	[FormularioId] [bigint] NOT NULL,
	[Eliminado] [bit] NOT NULL,
 CONSTRAINT [PK_Pregunta] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Formulario].[RespuestaFormulario]    Script Date: 27/4/2025 17:49:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Formulario].[RespuestaFormulario](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[GradoCumplimiento] [float] NULL,
	[Observaciones] [varchar](500) NULL,
	[Resultado] [float] NULL,
	[FormularioId] [bigint] NOT NULL,
	[RespuestaGrupoId] [bigint] NOT NULL,
	[Eliminado] [bit] NOT NULL,
 CONSTRAINT [PK_RespuestaFormulario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Formulario].[RespuestaGrupo]    Script Date: 27/4/2025 17:49:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Formulario].[RespuestaGrupo](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Puntuacion] [float] NOT NULL,
	[EntidadId] [bigint] NOT NULL,
	[GrupoId] [bigint] NOT NULL,
	[GestionId] [bigint] NOT NULL,
	[Eliminado] [bit] NOT NULL,
 CONSTRAINT [PK_RespuestaGrupo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Formulario].[RespuestaPregunta]    Script Date: 27/4/2025 17:49:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Formulario].[RespuestaPregunta](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Respuesta] [varchar](250) NOT NULL,
	[RespuestaFormularioId] [bigint] NOT NULL,
	[PreguntaId] [bigint] NOT NULL,
	[Eliminado] [bit] NOT NULL,
 CONSTRAINT [PK_RespuestaPregunta] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Seguridad].[Acceso]    Script Date: 27/4/2025 17:49:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Seguridad].[Acceso](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](200) NOT NULL,
	[Secuencia] [int] NOT NULL,
	[Controlador] [varchar](200) NOT NULL,
	[Vista] [varchar](200) NOT NULL,
	[Url] [varchar](200) NOT NULL,
	[Icono] [varchar](200) NOT NULL,
	[Descripcion] [varchar](200) NOT NULL,
	[ModuloId] [bigint] NOT NULL,
	[Eliminado] [bit] NOT NULL,
 CONSTRAINT [PK_Acceso] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Seguridad].[Modulo]    Script Date: 27/4/2025 17:49:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Seguridad].[Modulo](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](150) NOT NULL,
	[Icono] [varchar](100) NOT NULL,
	[Secuencia] [int] NOT NULL,
	[Eliminado] [bit] NOT NULL,
 CONSTRAINT [PK_Modulo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Seguridad].[Perfil]    Script Date: 27/4/2025 17:49:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Seguridad].[Perfil](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](250) NOT NULL,
	[Descripcion] [varchar](250) NOT NULL,
	[Eliminado] [bit] NOT NULL,
 CONSTRAINT [PK_Perfil] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Seguridad].[PerfilAcceso]    Script Date: 27/4/2025 17:49:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Seguridad].[PerfilAcceso](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[PerfilId] [bigint] NOT NULL,
	[AccesoId] [bigint] NOT NULL,
	[Eliminado] [bit] NOT NULL,
 CONSTRAINT [PK_PerfilAcceso] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Seguridad].[Usuario]    Script Date: 27/4/2025 17:49:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Seguridad].[Usuario](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](250) NOT NULL,
	[Apellido] [varchar](250) NOT NULL,
	[Username] [varchar](100) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Password] [varchar](150) NOT NULL,
	[FechaCreacion] [datetime] NULL,
	[PerfilId] [bigint] NULL,
	[Eliminado] [bit] NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [Configuracion].[Concepto] ADD  CONSTRAINT [DF_Concepto_Editable]  DEFAULT ((0)) FOR [Editable]
GO
ALTER TABLE [Configuracion].[Entidad] ADD  CONSTRAINT [DF_Entidad_Eliminado]  DEFAULT ((0)) FOR [Eliminado]
GO
ALTER TABLE [Formulario].[Formulario] ADD  CONSTRAINT [DF_Formulario_Ponderacion]  DEFAULT ((0)) FOR [Ponderacion]
GO
ALTER TABLE [Formulario].[Formulario] ADD  CONSTRAINT [DF_Formulario_Activo]  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [Formulario].[Formulario] ADD  CONSTRAINT [DF_Formulario_Eliminado]  DEFAULT ((0)) FOR [Eliminado]
GO
ALTER TABLE [Formulario].[Gestion] ADD  CONSTRAINT [DF_Gestion_Activo]  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [Formulario].[Gestion] ADD  CONSTRAINT [DF_Gestion_Terminado]  DEFAULT ((0)) FOR [Terminado]
GO
ALTER TABLE [Formulario].[Gestion] ADD  CONSTRAINT [DF_Gestion_Eliminado]  DEFAULT ((0)) FOR [Eliminado]
GO
ALTER TABLE [Formulario].[Grupo] ADD  CONSTRAINT [DF_Grupo_Activo]  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [Formulario].[Grupo] ADD  CONSTRAINT [DF_Grupo_Eliminado]  DEFAULT ((0)) FOR [Eliminado]
GO
ALTER TABLE [Formulario].[GrupoFormulario] ADD  CONSTRAINT [DF_GrupoFormulario_Eliminado]  DEFAULT ((0)) FOR [Eliminado]
GO
ALTER TABLE [Formulario].[Pregunta] ADD  CONSTRAINT [DF_Pregunta_Ponderacion]  DEFAULT ((0)) FOR [Ponderacion]
GO
ALTER TABLE [Formulario].[Pregunta] ADD  CONSTRAINT [DF_Pregunta_Activo]  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [Formulario].[Pregunta] ADD  CONSTRAINT [DF_Pregunta_Requerido]  DEFAULT ((0)) FOR [Requerido]
GO
ALTER TABLE [Formulario].[Pregunta] ADD  CONSTRAINT [DF_Pregunta_Eliminado]  DEFAULT ((0)) FOR [Eliminado]
GO
ALTER TABLE [Formulario].[RespuestaFormulario] ADD  CONSTRAINT [DF_RespuestaFormulario_Eliminado]  DEFAULT ((0)) FOR [Eliminado]
GO
ALTER TABLE [Formulario].[RespuestaGrupo] ADD  CONSTRAINT [DF_RespuestaGrupo_Eliminado]  DEFAULT ((0)) FOR [Eliminado]
GO
ALTER TABLE [Formulario].[RespuestaPregunta] ADD  CONSTRAINT [DF_RespuestaPregunta_Eliminado]  DEFAULT ((0)) FOR [Eliminado]
GO
ALTER TABLE [Seguridad].[Acceso] ADD  CONSTRAINT [DF_Acceso_Eliminado]  DEFAULT ((0)) FOR [Eliminado]
GO
ALTER TABLE [Seguridad].[Perfil] ADD  CONSTRAINT [DF_Perfil_Eliminado]  DEFAULT ((0)) FOR [Eliminado]
GO
ALTER TABLE [Seguridad].[PerfilAcceso] ADD  CONSTRAINT [DF_PerfilAcceso_Eliminado]  DEFAULT ((0)) FOR [Eliminado]
GO
ALTER TABLE [Seguridad].[Usuario] ADD  CONSTRAINT [DF_Usuario_Eliminacion]  DEFAULT ((0)) FOR [Eliminado]
GO
ALTER TABLE [Formulario].[GrupoFormulario]  WITH CHECK ADD  CONSTRAINT [FK_GrupoFormulario_Formulario] FOREIGN KEY([FormularioId])
REFERENCES [Formulario].[Formulario] ([Id])
GO
ALTER TABLE [Formulario].[GrupoFormulario] CHECK CONSTRAINT [FK_GrupoFormulario_Formulario]
GO
ALTER TABLE [Formulario].[GrupoFormulario]  WITH CHECK ADD  CONSTRAINT [FK_GrupoFormulario_Grupo] FOREIGN KEY([GrupoId])
REFERENCES [Formulario].[Grupo] ([Id])
GO
ALTER TABLE [Formulario].[GrupoFormulario] CHECK CONSTRAINT [FK_GrupoFormulario_Grupo]
GO
ALTER TABLE [Formulario].[Pregunta]  WITH CHECK ADD  CONSTRAINT [FK_Pregunta_Concepto] FOREIGN KEY([TipoId])
REFERENCES [Configuracion].[Concepto] ([Id])
GO
ALTER TABLE [Formulario].[Pregunta] CHECK CONSTRAINT [FK_Pregunta_Concepto]
GO
ALTER TABLE [Formulario].[RespuestaFormulario]  WITH CHECK ADD  CONSTRAINT [FK_RespuestaFormulario_Formulario] FOREIGN KEY([FormularioId])
REFERENCES [Formulario].[Formulario] ([Id])
GO
ALTER TABLE [Formulario].[RespuestaFormulario] CHECK CONSTRAINT [FK_RespuestaFormulario_Formulario]
GO
ALTER TABLE [Formulario].[RespuestaGrupo]  WITH CHECK ADD  CONSTRAINT [FK_RespuestaGrupo_Entidad] FOREIGN KEY([EntidadId])
REFERENCES [Configuracion].[Entidad] ([Id])
GO
ALTER TABLE [Formulario].[RespuestaGrupo] CHECK CONSTRAINT [FK_RespuestaGrupo_Entidad]
GO
ALTER TABLE [Formulario].[RespuestaGrupo]  WITH CHECK ADD  CONSTRAINT [FK_RespuestaGrupo_Gestion] FOREIGN KEY([GestionId])
REFERENCES [Formulario].[Gestion] ([Id])
GO
ALTER TABLE [Formulario].[RespuestaGrupo] CHECK CONSTRAINT [FK_RespuestaGrupo_Gestion]
GO
ALTER TABLE [Formulario].[RespuestaGrupo]  WITH CHECK ADD  CONSTRAINT [FK_RespuestaGrupo_Grupo] FOREIGN KEY([GrupoId])
REFERENCES [Formulario].[Grupo] ([Id])
GO
ALTER TABLE [Formulario].[RespuestaGrupo] CHECK CONSTRAINT [FK_RespuestaGrupo_Grupo]
GO
ALTER TABLE [Formulario].[RespuestaPregunta]  WITH CHECK ADD  CONSTRAINT [FK_RespuestaPregunta_Pregunta] FOREIGN KEY([PreguntaId])
REFERENCES [Formulario].[Pregunta] ([Id])
GO
ALTER TABLE [Formulario].[RespuestaPregunta] CHECK CONSTRAINT [FK_RespuestaPregunta_Pregunta]
GO
ALTER TABLE [Formulario].[RespuestaPregunta]  WITH CHECK ADD  CONSTRAINT [FK_RespuestaPregunta_RespuestaFormulario] FOREIGN KEY([RespuestaFormularioId])
REFERENCES [Formulario].[RespuestaFormulario] ([Id])
GO
ALTER TABLE [Formulario].[RespuestaPregunta] CHECK CONSTRAINT [FK_RespuestaPregunta_RespuestaFormulario]
GO
ALTER TABLE [Seguridad].[Acceso]  WITH CHECK ADD  CONSTRAINT [FK_Acceso_Modulo] FOREIGN KEY([ModuloId])
REFERENCES [Seguridad].[Modulo] ([Id])
GO
ALTER TABLE [Seguridad].[Acceso] CHECK CONSTRAINT [FK_Acceso_Modulo]
GO
ALTER TABLE [Seguridad].[PerfilAcceso]  WITH CHECK ADD  CONSTRAINT [FK_PerfilAcceso_Acceso] FOREIGN KEY([AccesoId])
REFERENCES [Seguridad].[Acceso] ([Id])
GO
ALTER TABLE [Seguridad].[PerfilAcceso] CHECK CONSTRAINT [FK_PerfilAcceso_Acceso]
GO
ALTER TABLE [Seguridad].[PerfilAcceso]  WITH CHECK ADD  CONSTRAINT [FK_PerfilAcceso_Perfil] FOREIGN KEY([PerfilId])
REFERENCES [Seguridad].[Perfil] ([Id])
GO
ALTER TABLE [Seguridad].[PerfilAcceso] CHECK CONSTRAINT [FK_PerfilAcceso_Perfil]
GO
ALTER TABLE [Seguridad].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Perfil] FOREIGN KEY([PerfilId])
REFERENCES [Seguridad].[Perfil] ([Id])
GO
ALTER TABLE [Seguridad].[Usuario] CHECK CONSTRAINT [FK_Usuario_Perfil]
GO
USE [master]
GO
ALTER DATABASE [template] SET  READ_WRITE 
GO
