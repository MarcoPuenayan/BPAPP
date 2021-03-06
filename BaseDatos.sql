USE [master]
GO
/****** Object:  Database [DBAPP]    Script Date: 30-May-22 8:13:50 AM ******/
CREATE DATABASE [DBAPP] ON  PRIMARY 
( NAME = N'DBAPP', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.MSSQLSERVER\MSSQL\DATA\DBAPP.mdf' , SIZE = 2304KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DBAPP_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.MSSQLSERVER\MSSQL\DATA\DBAPP_log.LDF' , SIZE = 576KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [DBAPP] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DBAPP].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DBAPP] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DBAPP] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DBAPP] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DBAPP] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DBAPP] SET ARITHABORT OFF 
GO
ALTER DATABASE [DBAPP] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DBAPP] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DBAPP] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DBAPP] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DBAPP] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DBAPP] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DBAPP] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DBAPP] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DBAPP] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DBAPP] SET  ENABLE_BROKER 
GO
ALTER DATABASE [DBAPP] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DBAPP] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DBAPP] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DBAPP] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DBAPP] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DBAPP] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [DBAPP] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DBAPP] SET RECOVERY FULL 
GO
ALTER DATABASE [DBAPP] SET  MULTI_USER 
GO
ALTER DATABASE [DBAPP] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DBAPP] SET DB_CHAINING OFF 
GO
USE [DBAPP]
GO
/****** Object:  User [Sql_Service]    Script Date: 30-May-22 8:13:50 AM ******/
CREATE USER [Sql_Service] FOR LOGIN [Sql_Service] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 30-May-22 8:13:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 30-May-22 8:13:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[IdPersona] [uniqueidentifier] NOT NULL,
	[IdCliente] [uniqueidentifier] NOT NULL,
	[Contraseña] [nvarchar](max) NOT NULL,
	[Estado] [bit] NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
	[Genero] [nvarchar](max) NOT NULL,
	[Edad] [int] NOT NULL,
	[Identificacion] [nvarchar](max) NOT NULL,
	[Direccion] [nvarchar](max) NOT NULL,
	[Telefono] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cuentas]    Script Date: 30-May-22 8:13:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cuentas](
	[IdCuenta] [uniqueidentifier] NOT NULL,
	[NumeroCuenta] [nvarchar](max) NOT NULL,
	[TipoCuenta] [nvarchar](max) NOT NULL,
	[SaldoInicial] [decimal](18, 2) NOT NULL,
	[Estado] [bit] NOT NULL,
	[IdCliente] [uniqueidentifier] NULL,
	[LimiteDiario] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Cuentas] PRIMARY KEY CLUSTERED 
(
	[IdCuenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movimientos]    Script Date: 30-May-22 8:13:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movimientos](
	[IdMovimiento] [uniqueidentifier] NOT NULL,
	[Fecha] [datetime2](7) NOT NULL,
	[Tipo] [nvarchar](max) NOT NULL,
	[Valor] [decimal](18, 2) NOT NULL,
	[Saldo] [decimal](18, 2) NOT NULL,
	[IdCuenta] [uniqueidentifier] NULL,
	[Movimientos] [nvarchar](max) NOT NULL,
	[SaldoInicial] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Movimientos] PRIMARY KEY CLUSTERED 
(
	[IdMovimiento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[GetMovimientos]    Script Date: 30-May-22 8:13:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create view [dbo].[GetMovimientos]
as

select mov.Fecha as Fecha,
cli.Nombre as Cliente,
cli.IdCliente,
cue.NumeroCuenta as Cuenta,
cue.IdCuenta,
cue.TipoCuenta as TipoCuenta,
mov.Tipo Tipo,
mov.SaldoInicial as SaldoInicial,
mov.Valor as Movimiento,
mov.Saldo as SaldoDisponible

from Clientes as cli inner join Cuentas as cue on cli.IdCliente=cue.IdCliente
							  inner join Movimientos as mov on mov.IdCuenta=cue.IdCuenta
--where cue.IdCliente='8121f76e-1e7c-4a3a-885f-5bd36b984846'
--order by cli.Nombre	, mov.Fecha
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220529154650_migration', N'6.0.5')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220529162812_migration001', N'6.0.5')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220529172102_migration002', N'6.0.5')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220530010658_migration003', N'6.0.5')
GO
INSERT [dbo].[Clientes] ([IdPersona], [IdCliente], [Contraseña], [Estado], [Nombre], [Genero], [Edad], [Identificacion], [Direccion], [Telefono]) VALUES (N'e22a2a25-b40c-4d2d-91c9-e2b32f343e07', N'9e292700-f009-4966-b265-4032e70a43a8', N'1245', 1, N'Juan Osorio', N'Masculino', 27, N'2222222222', N'13 junio y Equinoccial', N'098874587')
INSERT [dbo].[Clientes] ([IdPersona], [IdCliente], [Contraseña], [Estado], [Nombre], [Genero], [Edad], [Identificacion], [Direccion], [Telefono]) VALUES (N'00066d99-3502-4c93-b0ad-87e39b55f500', N'8121f76e-1e7c-4a3a-885f-5bd36b984846', N'5678', 1, N'Marianela Montalvo', N'Femenino', 27, N'2222222222', N'Amazonas y NNUU', N'097548965')
INSERT [dbo].[Clientes] ([IdPersona], [IdCliente], [Contraseña], [Estado], [Nombre], [Genero], [Edad], [Identificacion], [Direccion], [Telefono]) VALUES (N'31f67d11-a86f-40c6-a913-1fdbb8b10d63', N'8cdfb875-bda0-4da1-96de-b9c957a56621', N'1234', 1, N'Jose Lema', N'Masculino', 25, N'1111111111', N'Otavalo sn y principal', N'098254785')
INSERT [dbo].[Clientes] ([IdPersona], [IdCliente], [Contraseña], [Estado], [Nombre], [Genero], [Edad], [Identificacion], [Direccion], [Telefono]) VALUES (N'32f9e57e-0610-40b7-ab43-369360d9fc6f', N'd62942c4-7d39-4c83-abfa-ea49917f8957', N'123456', 1, N'Marco Puenayan', N'Ahorro', 0, N'3333333333', N'Llano Grande', N'0993235913')
GO
INSERT [dbo].[Cuentas] ([IdCuenta], [NumeroCuenta], [TipoCuenta], [SaldoInicial], [Estado], [IdCliente], [LimiteDiario]) VALUES (N'112cb179-a1f6-4484-ba47-2c1b2d76e829', N'496825', N'Ahorros', CAST(0.00 AS Decimal(18, 2)), 1, N'8121f76e-1e7c-4a3a-885f-5bd36b984846', CAST(1000.00 AS Decimal(18, 2)))
INSERT [dbo].[Cuentas] ([IdCuenta], [NumeroCuenta], [TipoCuenta], [SaldoInicial], [Estado], [IdCliente], [LimiteDiario]) VALUES (N'7c91453f-c297-4c3d-b731-32e063a86dbe', N'478758', N'Ahorro', CAST(1425.00 AS Decimal(18, 2)), 1, N'8cdfb875-bda0-4da1-96de-b9c957a56621', CAST(1000.00 AS Decimal(18, 2)))
INSERT [dbo].[Cuentas] ([IdCuenta], [NumeroCuenta], [TipoCuenta], [SaldoInicial], [Estado], [IdCliente], [LimiteDiario]) VALUES (N'32f89532-1ad6-4c0e-8194-4ceb7517e226', N'123456', N'Ahorro', CAST(0.00 AS Decimal(18, 2)), 1, N'd62942c4-7d39-4c83-abfa-ea49917f8957', CAST(1000.00 AS Decimal(18, 2)))
INSERT [dbo].[Cuentas] ([IdCuenta], [NumeroCuenta], [TipoCuenta], [SaldoInicial], [Estado], [IdCliente], [LimiteDiario]) VALUES (N'02c9bf91-d419-4b69-9efa-a0e98620e0d3', N'495878', N'Ahorros', CAST(300.00 AS Decimal(18, 2)), 1, N'9e292700-f009-4966-b265-4032e70a43a8', CAST(1000.00 AS Decimal(18, 2)))
INSERT [dbo].[Cuentas] ([IdCuenta], [NumeroCuenta], [TipoCuenta], [SaldoInicial], [Estado], [IdCliente], [LimiteDiario]) VALUES (N'c1002c5a-af63-4dfb-8348-b988abd80db0', N'225487', N'Corriente', CAST(700.00 AS Decimal(18, 2)), 1, N'8121f76e-1e7c-4a3a-885f-5bd36b984846', CAST(1000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Movimientos] ([IdMovimiento], [Fecha], [Tipo], [Valor], [Saldo], [IdCuenta], [Movimientos], [SaldoInicial]) VALUES (N'e95a1961-91cc-43e2-b25f-1b0276459b11', CAST(N'2022-05-29T19:03:21.9783184' AS DateTime2), N'CREACION', CAST(0.00 AS Decimal(18, 2)), CAST(100.00 AS Decimal(18, 2)), N'c1002c5a-af63-4dfb-8348-b988abd80db0', N'Creación Cuenta', CAST(100.00 AS Decimal(18, 2)))
INSERT [dbo].[Movimientos] ([IdMovimiento], [Fecha], [Tipo], [Valor], [Saldo], [IdCuenta], [Movimientos], [SaldoInicial]) VALUES (N'54914198-b46a-44c1-8e41-6c552cdcb28f', CAST(N'2022-05-30T02:56:21.5343250' AS DateTime2), N'DEPOSITO', CAST(150.00 AS Decimal(18, 2)), CAST(450.00 AS Decimal(18, 2)), N'02c9bf91-d419-4b69-9efa-a0e98620e0d3', N'DEPOSITO 150', CAST(300.00 AS Decimal(18, 2)))
INSERT [dbo].[Movimientos] ([IdMovimiento], [Fecha], [Tipo], [Valor], [Saldo], [IdCuenta], [Movimientos], [SaldoInicial]) VALUES (N'657a72ad-9662-43b7-8708-6c66cc5730d9', CAST(N'2022-05-30T02:43:13.9350127' AS DateTime2), N'Creacion', CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), N'32f89532-1ad6-4c0e-8194-4ceb7517e226', N'Creación Cuenta', CAST(0.00 AS Decimal(18, 2)))
INSERT [dbo].[Movimientos] ([IdMovimiento], [Fecha], [Tipo], [Valor], [Saldo], [IdCuenta], [Movimientos], [SaldoInicial]) VALUES (N'93b74986-210c-4e8e-8a8c-77ff22fce71a', CAST(N'2022-05-29T18:59:03.6992227' AS DateTime2), N'CREACION', CAST(0.00 AS Decimal(18, 2)), CAST(2000.00 AS Decimal(18, 2)), N'7c91453f-c297-4c3d-b731-32e063a86dbe', N'Creación Cuenta', CAST(2000.00 AS Decimal(18, 2)))
INSERT [dbo].[Movimientos] ([IdMovimiento], [Fecha], [Tipo], [Valor], [Saldo], [IdCuenta], [Movimientos], [SaldoInicial]) VALUES (N'1e1fabd0-21c8-415e-b087-7c6aa3f55105', CAST(N'2022-05-29T19:04:36.2447915' AS DateTime2), N'CREACION', CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), N'02c9bf91-d419-4b69-9efa-a0e98620e0d3', N'Creación Cuenta', CAST(0.00 AS Decimal(18, 2)))
INSERT [dbo].[Movimientos] ([IdMovimiento], [Fecha], [Tipo], [Valor], [Saldo], [IdCuenta], [Movimientos], [SaldoInicial]) VALUES (N'd5b55b19-9c2b-43d0-8924-7cf9b93abd8f', CAST(N'2022-05-30T02:35:48.5704657' AS DateTime2), N'DEPOSITO', CAST(600.00 AS Decimal(18, 2)), CAST(700.00 AS Decimal(18, 2)), N'c1002c5a-af63-4dfb-8348-b988abd80db0', N'DEPOSITO 600', CAST(100.00 AS Decimal(18, 2)))
INSERT [dbo].[Movimientos] ([IdMovimiento], [Fecha], [Tipo], [Valor], [Saldo], [IdCuenta], [Movimientos], [SaldoInicial]) VALUES (N'1f87d900-b381-4039-a557-8505dadef3d7', CAST(N'2022-05-30T02:56:27.8067909' AS DateTime2), N'RETIRO', CAST(-150.00 AS Decimal(18, 2)), CAST(300.00 AS Decimal(18, 2)), N'02c9bf91-d419-4b69-9efa-a0e98620e0d3', N'RETIRO -150', CAST(450.00 AS Decimal(18, 2)))
INSERT [dbo].[Movimientos] ([IdMovimiento], [Fecha], [Tipo], [Valor], [Saldo], [IdCuenta], [Movimientos], [SaldoInicial]) VALUES (N'6657cf52-0255-4284-9bb8-8d3021eecc88', CAST(N'2022-05-30T02:37:40.7137651' AS DateTime2), N'DEPOSITO', CAST(150.00 AS Decimal(18, 2)), CAST(150.00 AS Decimal(18, 2)), N'02c9bf91-d419-4b69-9efa-a0e98620e0d3', N'DEPOSITO 150', CAST(0.00 AS Decimal(18, 2)))
INSERT [dbo].[Movimientos] ([IdMovimiento], [Fecha], [Tipo], [Valor], [Saldo], [IdCuenta], [Movimientos], [SaldoInicial]) VALUES (N'7f7852f8-e044-47ac-835b-9ae8d3d4b36a', CAST(N'2022-05-30T01:13:37.9811461' AS DateTime2), N'RETIRO', CAST(-575.00 AS Decimal(18, 2)), CAST(1425.00 AS Decimal(18, 2)), N'7c91453f-c297-4c3d-b731-32e063a86dbe', N'RETIRO 575', CAST(2000.00 AS Decimal(18, 2)))
INSERT [dbo].[Movimientos] ([IdMovimiento], [Fecha], [Tipo], [Valor], [Saldo], [IdCuenta], [Movimientos], [SaldoInicial]) VALUES (N'f54019bb-6e87-4880-9e12-c2efc1867fe5', CAST(N'2022-05-30T01:18:50.9874297' AS DateTime2), N'RETIRO', CAST(-540.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), N'112cb179-a1f6-4484-ba47-2c1b2d76e829', N'RETIRO 540', CAST(540.00 AS Decimal(18, 2)))
INSERT [dbo].[Movimientos] ([IdMovimiento], [Fecha], [Tipo], [Valor], [Saldo], [IdCuenta], [Movimientos], [SaldoInicial]) VALUES (N'3ce1a4ef-960c-4f46-b939-cbd51c69a676', CAST(N'2022-05-29T19:05:16.5461740' AS DateTime2), N'CREACION', CAST(0.00 AS Decimal(18, 2)), CAST(540.00 AS Decimal(18, 2)), N'112cb179-a1f6-4484-ba47-2c1b2d76e829', N'Creación Cuenta', CAST(540.00 AS Decimal(18, 2)))
INSERT [dbo].[Movimientos] ([IdMovimiento], [Fecha], [Tipo], [Valor], [Saldo], [IdCuenta], [Movimientos], [SaldoInicial]) VALUES (N'982bdbba-0ae4-40d5-88aa-da9672e38449', CAST(N'2022-05-30T02:56:14.9469184' AS DateTime2), N'DEPOSITO', CAST(150.00 AS Decimal(18, 2)), CAST(300.00 AS Decimal(18, 2)), N'02c9bf91-d419-4b69-9efa-a0e98620e0d3', N'DEPOSITO 150', CAST(150.00 AS Decimal(18, 2)))
GO
/****** Object:  Index [IX_Clientes_IdCliente]    Script Date: 30-May-22 8:13:51 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Clientes_IdCliente] ON [dbo].[Clientes]
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Cuentas_IdCliente]    Script Date: 30-May-22 8:13:51 AM ******/
CREATE NONCLUSTERED INDEX [IX_Cuentas_IdCliente] ON [dbo].[Cuentas]
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Movimientos_IdCuenta]    Script Date: 30-May-22 8:13:51 AM ******/
CREATE NONCLUSTERED INDEX [IX_Movimientos_IdCuenta] ON [dbo].[Movimientos]
(
	[IdCuenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Cuentas] ADD  DEFAULT ((0.0)) FOR [LimiteDiario]
GO
ALTER TABLE [dbo].[Movimientos] ADD  DEFAULT (N'') FOR [Movimientos]
GO
ALTER TABLE [dbo].[Movimientos] ADD  DEFAULT ((0.0)) FOR [SaldoInicial]
GO
ALTER TABLE [dbo].[Cuentas]  WITH CHECK ADD  CONSTRAINT [FK_Cuentas_Clientes_IdCliente] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Clientes] ([IdCliente])
GO
ALTER TABLE [dbo].[Cuentas] CHECK CONSTRAINT [FK_Cuentas_Clientes_IdCliente]
GO
ALTER TABLE [dbo].[Movimientos]  WITH CHECK ADD  CONSTRAINT [FK_Movimientos_Cuentas_IdCuenta] FOREIGN KEY([IdCuenta])
REFERENCES [dbo].[Cuentas] ([IdCuenta])
GO
ALTER TABLE [dbo].[Movimientos] CHECK CONSTRAINT [FK_Movimientos_Cuentas_IdCuenta]
GO
USE [master]
GO
ALTER DATABASE [DBAPP] SET  READ_WRITE 
GO
