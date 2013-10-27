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
	[id_usuario] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[username] [varchar](255) NOT NULL,
	[password] [varbinary](32) NOT NULL,
	[cant_intentos_fallidos] int NOT NULL,
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

ALTER TABLE [TOP_4].[Usuario] ADD  CONSTRAINT [DF_Usuario_cant_intentos_fallidos]  DEFAULT ((0)) FOR [cant_intentos_fallidos]
GO

---------------------------------Rol---------------------------------------

CREATE TABLE [TOP_4].[Rol](
	[id_rol] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](255) NOT NULL,
	[habilitado] [bit] NOT NULL,
 CONSTRAINT [PK_Rol] PRIMARY KEY CLUSTERED 
(
	[id_rol] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO

ALTER TABLE [TOP_4].[Rol] ADD  CONSTRAINT [DF_Rol_habilitado]  DEFAULT ((1)) FOR [habilitado]
GO


-- Creo los roles por defecto --
GO

INSERT INTO [TOP_4].[Rol] ([nombre],[habilitado]) VALUES ('Afiliado', 1)
INSERT INTO [TOP_4].[Rol] ([nombre],[habilitado]) VALUES ('Administrativo', 1)
INSERT INTO [TOP_4].[Rol] ([nombre],[habilitado]) VALUES ('Profesional', 1)

GO

---------------------------------Funcionalidad---------------------------------------
CREATE TABLE [TOP_4].[Funcionalidad](
	[id_funcionalidad] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](255) NOT NULL,
	[habilitado] [bit] NOT NULL,
 CONSTRAINT [PK_Funcionalidad] PRIMARY KEY CLUSTERED 
(
	[id_funcionalidad] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

ALTER TABLE [TOP_4].[Funcionalidad] ADD  CONSTRAINT [DF_Funcionalidad_habilitado]  DEFAULT ((1)) FOR [habilitado]
GO


-- Creo las funcionalidades existentes 
GO
-- Menu archivo:
INSERT INTO [TOP_4].[Funcionalidad] ([nombre],[habilitado])VALUES ('tsmArchivo' ,1) -- 1
INSERT INTO [TOP_4].[Funcionalidad] ([nombre],[habilitado])VALUES ('tsmSesion' ,1) -- 2
INSERT INTO [TOP_4].[Funcionalidad] ([nombre],[habilitado])VALUES ('tsmSesion_IniciarSesion' ,1) -- 3  
INSERT INTO [TOP_4].[Funcionalidad] ([nombre],[habilitado])VALUES ('tsmSesion_CerrarSesion' ,1) -- 4
INSERT INTO [TOP_4].[Funcionalidad] ([nombre],[habilitado])VALUES ('estadísticasToolStripMenuItem' ,1) --5 
INSERT INTO [TOP_4].[Funcionalidad] ([nombre],[habilitado])VALUES ('tsmSalir' ,1) -- 6
-- Menu Gestión de clínica
INSERT INTO [TOP_4].[Funcionalidad] ([nombre],[habilitado])VALUES ('tsmGestionDeClinica',1) --7
INSERT INTO [TOP_4].[Funcionalidad] ([nombre],[habilitado])VALUES ('tsmPlanes' ,1) -- 8
INSERT INTO [TOP_4].[Funcionalidad] ([nombre],[habilitado])VALUES ('tsmRoles' ,1) --9 
INSERT INTO [TOP_4].[Funcionalidad] ([nombre],[habilitado])VALUES ('tsmUsuarios' ,1) -- 10
INSERT INTO [TOP_4].[Funcionalidad] ([nombre],[habilitado])VALUES ('tsmCancelaciones' ,1) --11
INSERT INTO [TOP_4].[Funcionalidad] ([nombre],[habilitado])VALUES ('tsmCancelaciones_Afiliado' ,1) --12
INSERT INTO [TOP_4].[Funcionalidad] ([nombre],[habilitado])VALUES ('tsmCancelaciones_Profesional' ,1) --13
-- Menu Gestión de afiliados
INSERT INTO [TOP_4].[Funcionalidad] ([nombre],[habilitado])VALUES ('tsmAfiliados' ,1) --14
INSERT INTO [TOP_4].[Funcionalidad] ([nombre],[habilitado])VALUES ('tsmCompraDeBonos' ,1) --15
INSERT INTO [TOP_4].[Funcionalidad] ([nombre],[habilitado])VALUES ('tsmPedirTurno' ,1) --16
INSERT INTO [TOP_4].[Funcionalidad] ([nombre],[habilitado])VALUES ('tsmRegistroDeLlegada' ,1) --17
INSERT INTO [TOP_4].[Funcionalidad] ([nombre],[habilitado])VALUES ('tsmRegistroDeResultados' ,1) --18
INSERT INTO [TOP_4].[Funcionalidad] ([nombre],[habilitado])VALUES ('tsmRecetar' ,1) --19
-- Menu Gestión de profesionales
INSERT INTO [TOP_4].[Funcionalidad] ([nombre],[habilitado])VALUES ('tsmGestionDeProfesionales' ,1) --20
INSERT INTO [TOP_4].[Funcionalidad] ([nombre],[habilitado])VALUES ('tsmProfesionales' ,1) --21
INSERT INTO [TOP_4].[Funcionalidad] ([nombre],[habilitado])VALUES ('tsmEspecialidades' ,1) --22 
-- Menu Agenda
INSERT INTO [TOP_4].[Funcionalidad] ([nombre],[habilitado])VALUES ('tsmAgenda' ,1) --23
INSERT INTO [TOP_4].[Funcionalidad] ([nombre],[habilitado])VALUES ('tsmAgenda_Consultar' ,1) --24
INSERT INTO [TOP_4].[Funcionalidad] ([nombre],[habilitado])VALUES ('tsmAgenda_Registrar' ,1) --25

GO

---------------------------------Usuario_Rol---------------------------------------
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [TOP_4].[Usuario_Rol](
	[id_usuario] [numeric](18, 0) NOT NULL,
	[id_rol] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_Usuario_Rol] PRIMARY KEY CLUSTERED 
(
	[id_usuario] ASC,
	[id_rol] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [TOP_4].[Usuario_Rol]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Rol_Rol] FOREIGN KEY([id_rol])
REFERENCES [TOP_4].[Rol] ([id_rol])
GO
ALTER TABLE [TOP_4].[Usuario_Rol] CHECK CONSTRAINT [FK_Usuario_Rol_Rol]
GO

ALTER TABLE [TOP_4].[Usuario_Rol]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Rol_Usuario] FOREIGN KEY([id_usuario])
REFERENCES [TOP_4].[Usuario] ([id_usuario])
GO
ALTER TABLE [TOP_4].[Usuario_Rol] CHECK CONSTRAINT [FK_Usuario_Rol_Usuario]
GO

--- Creo los usuarios administradores
GO
INSERT INTO [TOP_4].[Usuario] ([username],[password],[habilitado]) VALUES ('admin1', CONVERT(varbinary,'0xE6B87050BFCB8143FCB8DB0170A4DC9ED00D904DDD3E2A4AD1B1E8DC0FDC9BE7'),1)
INSERT INTO [TOP_4].[Usuario_Rol] ([id_usuario],[id_rol]) VALUES (@@IDENTITY , 2)

INSERT INTO [TOP_4].[Usuario] ([username],[password],[habilitado]) VALUES ('admin2', CONVERT(varbinary,'0xE6B87050BFCB8143FCB8DB0170A4DC9ED00D904DDD3E2A4AD1B1E8DC0FDC9BE7'),1)
INSERT INTO [TOP_4].[Usuario_Rol] ([id_usuario],[id_rol]) VALUES (@@IDENTITY , 2)

INSERT INTO [TOP_4].[Usuario] ([username],[password],[habilitado]) VALUES ('admin3', CONVERT(varbinary,'0xE6B87050BFCB8143FCB8DB0170A4DC9ED00D904DDD3E2A4AD1B1E8DC0FDC9BE7'),1)
INSERT INTO [TOP_4].[Usuario_Rol] ([id_usuario],[id_rol]) VALUES (@@IDENTITY , 2)

INSERT INTO [TOP_4].[Usuario] ([username],[password],[habilitado]) VALUES ('admin4', CONVERT(varbinary,'0xE6B87050BFCB8143FCB8DB0170A4DC9ED00D904DDD3E2A4AD1B1E8DC0FDC9BE7'),1)
INSERT INTO [TOP_4].[Usuario_Rol] ([id_usuario],[id_rol]) VALUES (@@IDENTITY , 2)

INSERT INTO [TOP_4].[Usuario] ([username],[password],[habilitado]) VALUES ('admin5', CONVERT(varbinary,'0xE6B87050BFCB8143FCB8DB0170A4DC9ED00D904DDD3E2A4AD1B1E8DC0FDC9BE7'),1)
INSERT INTO [TOP_4].[Usuario_Rol] ([id_usuario],[id_rol]) VALUES (@@IDENTITY , 2)

GO


---------------------------------Rol_Funcionalidad---------------------------------------
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [TOP_4].[Rol_Funcionalidad](
	[id_rol] [numeric](18, 0) NOT NULL,
	[id_funcionalidad] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_Rol_Funcionalidad] PRIMARY KEY CLUSTERED 
(
	[id_rol] ASC,
	[id_funcionalidad] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [TOP_4].[Rol_Funcionalidad]  WITH CHECK ADD  CONSTRAINT [FK_Rol_Funcionalidad_Funcionalidad] FOREIGN KEY([id_funcionalidad])
REFERENCES [TOP_4].[Funcionalidad] ([id_funcionalidad])
GO
ALTER TABLE [TOP_4].[Rol_Funcionalidad] CHECK CONSTRAINT [FK_Rol_Funcionalidad_Funcionalidad]
GO

ALTER TABLE [TOP_4].[Rol_Funcionalidad]  WITH CHECK ADD  CONSTRAINT [FK_Rol_Funcionalidad_Rol] FOREIGN KEY([id_rol])
REFERENCES [TOP_4].[Rol] ([id_rol])
GO
ALTER TABLE [TOP_4].[Rol_Funcionalidad] CHECK CONSTRAINT [FK_Rol_Funcionalidad_Rol]
GO

-------------------- Roles y sus funcionalidades ----------------
--Rol Afiliado
INSERT INTO [TOP_4].[Rol_Funcionalidad] ([id_rol],[id_funcionalidad]) VALUES (1, 1)
INSERT INTO [TOP_4].[Rol_Funcionalidad] ([id_rol],[id_funcionalidad]) VALUES (1, 2)
INSERT INTO [TOP_4].[Rol_Funcionalidad] ([id_rol],[id_funcionalidad]) VALUES (1, 3)
INSERT INTO [TOP_4].[Rol_Funcionalidad] ([id_rol],[id_funcionalidad]) VALUES (1, 4)
INSERT INTO [TOP_4].[Rol_Funcionalidad] ([id_rol],[id_funcionalidad]) VALUES (1, 6)
INSERT INTO [TOP_4].[Rol_Funcionalidad] ([id_rol],[id_funcionalidad]) VALUES (1, 7)
INSERT INTO [TOP_4].[Rol_Funcionalidad] ([id_rol],[id_funcionalidad]) VALUES (1, 11)
INSERT INTO [TOP_4].[Rol_Funcionalidad] ([id_rol],[id_funcionalidad]) VALUES (1, 12)
INSERT INTO [TOP_4].[Rol_Funcionalidad] ([id_rol],[id_funcionalidad]) VALUES (1, 14)
INSERT INTO [TOP_4].[Rol_Funcionalidad] ([id_rol],[id_funcionalidad]) VALUES (1, 15)
INSERT INTO [TOP_4].[Rol_Funcionalidad] ([id_rol],[id_funcionalidad]) VALUES (1, 16)

--Rol Administrativo
INSERT INTO [TOP_4].[Rol_Funcionalidad] ([id_rol],[id_funcionalidad]) VALUES (2, 1)
INSERT INTO [TOP_4].[Rol_Funcionalidad] ([id_rol],[id_funcionalidad]) VALUES (2, 2)
INSERT INTO [TOP_4].[Rol_Funcionalidad] ([id_rol],[id_funcionalidad]) VALUES (2, 3)
INSERT INTO [TOP_4].[Rol_Funcionalidad] ([id_rol],[id_funcionalidad]) VALUES (2, 4)
INSERT INTO [TOP_4].[Rol_Funcionalidad] ([id_rol],[id_funcionalidad]) VALUES (2, 5)
INSERT INTO [TOP_4].[Rol_Funcionalidad] ([id_rol],[id_funcionalidad]) VALUES (2, 6)
INSERT INTO [TOP_4].[Rol_Funcionalidad] ([id_rol],[id_funcionalidad]) VALUES (2, 7)
INSERT INTO [TOP_4].[Rol_Funcionalidad] ([id_rol],[id_funcionalidad]) VALUES (2, 8)
INSERT INTO [TOP_4].[Rol_Funcionalidad] ([id_rol],[id_funcionalidad]) VALUES (2, 9)
INSERT INTO [TOP_4].[Rol_Funcionalidad] ([id_rol],[id_funcionalidad]) VALUES (2, 10)
INSERT INTO [TOP_4].[Rol_Funcionalidad] ([id_rol],[id_funcionalidad]) VALUES (2, 11)
INSERT INTO [TOP_4].[Rol_Funcionalidad] ([id_rol],[id_funcionalidad]) VALUES (2, 12)
INSERT INTO [TOP_4].[Rol_Funcionalidad] ([id_rol],[id_funcionalidad]) VALUES (2, 13)
INSERT INTO [TOP_4].[Rol_Funcionalidad] ([id_rol],[id_funcionalidad]) VALUES (2, 14)
INSERT INTO [TOP_4].[Rol_Funcionalidad] ([id_rol],[id_funcionalidad]) VALUES (2, 15)
INSERT INTO [TOP_4].[Rol_Funcionalidad] ([id_rol],[id_funcionalidad]) VALUES (2, 16)
INSERT INTO [TOP_4].[Rol_Funcionalidad] ([id_rol],[id_funcionalidad]) VALUES (2, 17)
INSERT INTO [TOP_4].[Rol_Funcionalidad] ([id_rol],[id_funcionalidad]) VALUES (2, 18)
INSERT INTO [TOP_4].[Rol_Funcionalidad] ([id_rol],[id_funcionalidad]) VALUES (2, 19)
INSERT INTO [TOP_4].[Rol_Funcionalidad] ([id_rol],[id_funcionalidad]) VALUES (2, 20)
INSERT INTO [TOP_4].[Rol_Funcionalidad] ([id_rol],[id_funcionalidad]) VALUES (2, 21)
INSERT INTO [TOP_4].[Rol_Funcionalidad] ([id_rol],[id_funcionalidad]) VALUES (2, 22)
INSERT INTO [TOP_4].[Rol_Funcionalidad] ([id_rol],[id_funcionalidad]) VALUES (2, 23)
INSERT INTO [TOP_4].[Rol_Funcionalidad] ([id_rol],[id_funcionalidad]) VALUES (2, 24)
INSERT INTO [TOP_4].[Rol_Funcionalidad] ([id_rol],[id_funcionalidad]) VALUES (2, 25)

--Rol Profesional
INSERT INTO [TOP_4].[Rol_Funcionalidad] ([id_rol],[id_funcionalidad]) VALUES (3, 1)
INSERT INTO [TOP_4].[Rol_Funcionalidad] ([id_rol],[id_funcionalidad]) VALUES (3, 2)
INSERT INTO [TOP_4].[Rol_Funcionalidad] ([id_rol],[id_funcionalidad]) VALUES (3, 3)
INSERT INTO [TOP_4].[Rol_Funcionalidad] ([id_rol],[id_funcionalidad]) VALUES (3, 4)
INSERT INTO [TOP_4].[Rol_Funcionalidad] ([id_rol],[id_funcionalidad]) VALUES (3, 5)
INSERT INTO [TOP_4].[Rol_Funcionalidad] ([id_rol],[id_funcionalidad]) VALUES (3, 6)
INSERT INTO [TOP_4].[Rol_Funcionalidad] ([id_rol],[id_funcionalidad]) VALUES (3, 7)
INSERT INTO [TOP_4].[Rol_Funcionalidad] ([id_rol],[id_funcionalidad]) VALUES (3, 11)
INSERT INTO [TOP_4].[Rol_Funcionalidad] ([id_rol],[id_funcionalidad]) VALUES (3, 13)
INSERT INTO [TOP_4].[Rol_Funcionalidad] ([id_rol],[id_funcionalidad]) VALUES (3, 14)
INSERT INTO [TOP_4].[Rol_Funcionalidad] ([id_rol],[id_funcionalidad]) VALUES (3, 18)
INSERT INTO [TOP_4].[Rol_Funcionalidad] ([id_rol],[id_funcionalidad]) VALUES (3, 19)
INSERT INTO [TOP_4].[Rol_Funcionalidad] ([id_rol],[id_funcionalidad]) VALUES (3, 23)
INSERT INTO [TOP_4].[Rol_Funcionalidad] ([id_rol],[id_funcionalidad]) VALUES (3, 24)
INSERT INTO [TOP_4].[Rol_Funcionalidad] ([id_rol],[id_funcionalidad]) VALUES (3, 25)
GO

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

------------------------------------------Agenda--------------------------------------------------

USE [GD2C2013]
GO

/****** Object:  Table [TOP_4].[Agenda]    Script Date: 10/27/2013 12:46:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [TOP_4].[Agenda](
	[id_agenda] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[id_profesional] [numeric](18, 0) NOT NULL,
	[fecha_desde] [datetime] NOT NULL,
	[fecha_hasta] [datetime] NOT NULL,
	[habilitado] [bit] NOT NULL,
 CONSTRAINT [PK_Agenda] PRIMARY KEY CLUSTERED 
(
	[id_agenda] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Agendas de los profesionales' , @level0type=N'SCHEMA',@level0name=N'TOP_4', @level1type=N'TABLE',@level1name=N'Agenda'
GO

ALTER TABLE [TOP_4].[Agenda]  WITH CHECK ADD  CONSTRAINT [FK_Agenda_Profesional] FOREIGN KEY([id_profesional])
REFERENCES [TOP_4].[Profesional] ([id_profesional])
GO

ALTER TABLE [TOP_4].[Agenda] CHECK CONSTRAINT [FK_Agenda_Profesional]
GO

ALTER TABLE [TOP_4].[Agenda] ADD  CONSTRAINT [DF_Agenda_habilitado]  DEFAULT ((1)) FOR [habilitado]
GO

INSERT INTO TOP_4.Agenda
(id_profesional, fecha_desde, fecha_hasta)
(
	SELECT DISTINCT p.id_profesional, MAX(m.Turno_Fecha) as 'maxturno' , 
			MIN(m.turno_fecha) as 'minturno'
	FROM gd_esquema.Maestra m
	INNER JOIN TOP_4.Profesional p
		ON p.documento = m.Medico_Dni
	WHERE m.Medico_Dni IS NOT NULL
	GROUP BY p.id_profesional, m.Medico_Dni, m.Medico_Nombre, m.Medico_Apellido
)

GO

------------------------------------------Dia_Agenda--------------------------------------------------

USE [GD2C2013]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [TOP_4].[Dia_Agenda](
	[id_dia_agenda] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[id_agenda] [numeric](18, 0) NOT NULL,
	[nro_dia_semana] [numeric](18, 0) NOT NULL,
	[nombre_dia_semana] [nvarchar](255) NOT NULL,
	[hora_desde] [time](7) NOT NULL,
	[hora_hasta] [time](7) NOT NULL,
	[habilitado] [bit] NOT NULL,
 CONSTRAINT [PK_Dia_Agenda] PRIMARY KEY CLUSTERED 
(
	[id_dia_agenda] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [TOP_4].[Dia_Agenda]  WITH CHECK ADD  CONSTRAINT [FK_Dia_Agenda_Agenda] FOREIGN KEY([id_agenda])
REFERENCES [TOP_4].[Agenda] ([id_agenda])
GO

ALTER TABLE [TOP_4].[Dia_Agenda] CHECK CONSTRAINT [FK_Dia_Agenda_Agenda]
GO

ALTER TABLE [TOP_4].[Dia_Agenda] ADD  CONSTRAINT [DF_Dia_Agenda_habilitado]  DEFAULT ((1)) FOR [habilitado]
GO
