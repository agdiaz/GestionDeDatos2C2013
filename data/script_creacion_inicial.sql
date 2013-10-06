-----------------------------------SCHEMA-----------------------------------------
GO
USE [GD2C2013]
GO
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'TOP_4')
EXEC sys.sp_executesql N'CREATE SCHEMA [TOP_4] AUTHORIZATION [dbo]'
GO

---------------------------------Plan Medico---------------------------------------

USE [GD2C2013]
GO
/****** Object:  Table [TOP_4].[Plan_medico]    Script Date: 10/06/2013 16:34:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [TOP_4].[Plan_medico](
	[id_plan_medico] [numeric](18, 0) NOT NULL,
	[descripcion] [varchar](255) NOT NULL,
	[precio_bono_farmacia] [numeric](18, 0) NOT NULL,
	[precio_bono_consulta] [numeric](18, 0) NOT NULL,
	[habilitado] [bit] NOT NULL,
 CONSTRAINT [PK_Plan] PRIMARY KEY CLUSTERED 
(
	[id_plan_medico] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Planes medicos' , @level0type=N'SCHEMA',@level0name=N'TOP_4', @level1type=N'TABLE',@level1name=N'Plan_medico'
GO
ALTER TABLE [TOP_4].[Plan_medico] ADD  CONSTRAINT [DF_Plan_habilitado]  DEFAULT ((1)) FOR [habilitado]
GO

INSERT INTO [TOP_4].[Plan_medico] (id_plan_medico, descripcion, precio_bono_farmacia, precio_bono_consulta)
	(
		SELECT DISTINCT m.Plan_Med_Codigo, m.Plan_Med_Descripcion, 
			m.Plan_Med_Precio_Bono_Farmacia, m.Plan_Med_Precio_Bono_Consulta
		FROM gd_esquema.Maestra m
	)

GO
---------------------------------Usuario---------------------------------------
USE [GD2C2013]
GO

/****** Object:  Table [TOP_4].[Usuario]    Script Date: 10/06/2013 17:12:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [TOP_4].[Usuario](
	[id_usuario] [numeric](18, 0) NOT NULL,
	[username] [varchar](255) NOT NULL,
	[password] [varbinary](32) NOT NULL,
	[habilitado] [bit] NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[id_usuario] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuarios del sistema' , @level0type=N'SCHEMA',@level0name=N'TOP_4', @level1type=N'TABLE',@level1name=N'Usuario'
GO

ALTER TABLE [TOP_4].[Usuario] ADD  CONSTRAINT [DF_Usuario_habilitado]  DEFAULT ((1)) FOR [habilitado]
GO


--aca inserts

------------------------------------Profesional------------------------------------------------

USE [GD2C2013]
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [TOP_4].[Profesional](
	[id_profesional] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[id_usuario] [numeric](18, 0) NULL,
	[nombre] [varchar](255) NOT NULL,
	[apellido] [varchar](255) NOT NULL,
	[tipo_documento] [varchar](255) NOT NULL,
	[documento] [numeric](18, 0) NOT NULL,
	[direccion] [varchar](255) NOT NULL,
	[telefono] [numeric](18, 0) NOT NULL,
	[mail] [varchar](255) NOT NULL,
	[fecha_nacimiento] [datetime] NOT NULL,
	[sexo] [int] NOT NULL,
	[matricula] [numeric](18, 0) NOT NULL,
	[habilitado] [bit] NOT NULL,
 CONSTRAINT [PK_Profesionales] PRIMARY KEY CLUSTERED 
(
	[id_profesional] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Profesionales que trabajan en la clinica' , @level0type=N'SCHEMA',@level0name=N'TOP_4', @level1type=N'TABLE',@level1name=N'Profesional'
GO

ALTER TABLE [TOP_4].[Profesional]  WITH CHECK ADD  CONSTRAINT [FK_Profesionales_Usuario] FOREIGN KEY([id_usuario])
REFERENCES [TOP_4].[Usuario] ([id_usuario])
GO

ALTER TABLE [TOP_4].[Profesional] CHECK CONSTRAINT [FK_Profesionales_Usuario]
GO

ALTER TABLE [TOP_4].[Profesional] ADD  CONSTRAINT [DF_Profesionales_tipo_documento]  DEFAULT ('DNI') FOR [tipo_documento]
GO

ALTER TABLE [TOP_4].[Profesional] ADD  CONSTRAINT [DF_Profesionales_sexo]  DEFAULT ((0)) FOR [sexo]
GO

ALTER TABLE [TOP_4].[Profesional] ADD  CONSTRAINT [DF_Profesionales_habilitado]  DEFAULT ((1)) FOR [habilitado]
GO

-- Creamos una tabla auxiliar solo para generar matriculas. No queremos que sea
-- autogenerado en la tabla final, pero lo autogeneramos en la temporal
CREATE TABLE #TmpProfesional (
	[nombre] [varchar](255) NOT NULL,
	[apellido] [varchar](255) NOT NULL,
	[documento] [numeric](18, 0) NOT NULL,
	[direccion] [varchar](255) NOT NULL,
	[telefono] [numeric](18, 0) NOT NULL,
	[mail] [varchar](255) NOT NULL,
	[fecha_nacimiento] [datetime] NOT NULL,
	[matricula] [numeric](18, 0) IDENTITY(924,13) NOT NULL,
 CONSTRAINT [PK_Profesionales] PRIMARY KEY CLUSTERED 
(
	[documento] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

insert into #TmpProfesional 
 (nombre, apellido, documento, direccion, telefono, mail, fecha_nacimiento)
 (
	SELECT DISTINCT m.Medico_Nombre, m.Medico_Apellido, m.Medico_Dni,
			m.Medico_Direccion, m.Medico_Telefono, m.medico_mail,
			m.Medico_Fecha_Nac
		FROM gd_esquema.Maestra m
		WHERE m.Medico_Nombre IS NOT NULL
 )
 
insert into TOP_4.Profesional
	(nombre, apellido, documento, direccion, telefono, mail, fecha_nacimiento, matricula)
(
	SELECT nombre, apellido, documento, direccion, telefono, mail, fecha_nacimiento, matricula
		FROM #TmpProfesional
)

DROP TABLE #TmpProfesional

GO
------------------------------------Tipo_especialidad---------------------------------------------

USE [GD2C2013]
GO

/****** Object:  Table [TOP_4].[Tipo_especialidad]    Script Date: 10/06/2013 18:03:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [TOP_4].[Tipo_especialidad](
	[id_tipo_especialidad] [numeric](18, 0) NOT NULL,
	[nombre] [varchar](255) NOT NULL,
 CONSTRAINT [PK_Tipo_especialidad] PRIMARY KEY CLUSTERED 
(
	[id_tipo_especialidad] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

INSERT INTO TOP_4.Tipo_especialidad (id_tipo_especialidad, nombre)
(
	SELECT DISTINCT  m.Tipo_Especialidad_Codigo, m.Tipo_Especialidad_Descripcion 
		FROM gd_esquema.Maestra m
		WHERE Tipo_Especialidad_Codigo is not null	
)
---------------------------------------Especialidad--------------------------------------------------
USE [GD2C2013]
GO

/****** Object:  Table [TOP_4].[Especialidad]    Script Date: 10/06/2013 18:09:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [TOP_4].[Especialidad](
	[id_especialidad] [numeric](18, 0) NOT NULL,
	[id_tipo_especialidad] [numeric](18, 0) NOT NULL,
	[nombre] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_Especialidad] PRIMARY KEY CLUSTERED 
(
	[id_especialidad] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [TOP_4].[Especialidad]  WITH CHECK ADD  CONSTRAINT [FK_Especialidad_Tipo_especialidad] FOREIGN KEY([id_tipo_especialidad])
REFERENCES [TOP_4].[Tipo_especialidad] ([id_tipo_especialidad])
GO

ALTER TABLE [TOP_4].[Especialidad] CHECK CONSTRAINT [FK_Especialidad_Tipo_especialidad]
GO

INSERT INTO TOP_4.Especialidad
(id_especialidad, nombre, id_tipo_especialidad)
(
	SELECT DISTINCT  m.Especialidad_Codigo, m.Especialidad_Descripcion, m.Tipo_Especialidad_Codigo
		FROM gd_esquema.Maestra m
		WHERE m.Especialidad_Codigo IS NOT NULL
)

GO
------------------------------------Profesional_especialidad-----------------------------------------------
USE [GD2C2013]
GO

/****** Object:  Table [TOP_4].[Profesional_Especialidad]    Script Date: 10/06/2013 18:18:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [TOP_4].[Profesional_Especialidad](
	[id_especialidad] [numeric](18, 0) NOT NULL,
	[id_profesional] [numeric](18, 0) NOT NULL
) ON [PRIMARY]

GO

ALTER TABLE [TOP_4].[Profesional_Especialidad]  WITH CHECK ADD  CONSTRAINT [FK_Profesional_Especialidad_Especialidad] FOREIGN KEY([id_especialidad])
REFERENCES [TOP_4].[Especialidad] ([id_especialidad])
GO

ALTER TABLE [TOP_4].[Profesional_Especialidad] CHECK CONSTRAINT [FK_Profesional_Especialidad_Especialidad]
GO

ALTER TABLE [TOP_4].[Profesional_Especialidad]  WITH CHECK ADD  CONSTRAINT [FK_Profesional_Especialidad_Profesional] FOREIGN KEY([id_profesional])
REFERENCES [TOP_4].[Profesional] ([id_profesional])
GO

ALTER TABLE [TOP_4].[Profesional_Especialidad] CHECK CONSTRAINT [FK_Profesional_Especialidad_Profesional]
GO

INSERT INTO TOP_4.Profesional_especialidad
(id_profesional, id_especialidad)
(
	SELECT DISTINCT p.id_profesional, m.Especialidad_Codigo
	FROM gd_esquema.Maestra m
	INNER JOIN TOP_4.Profesional p
		ON p.documento = m.Medico_Dni
)

GO