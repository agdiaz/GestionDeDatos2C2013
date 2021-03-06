-----------------------------------SCHEMA-----------------------------------------
GO
USE [GD2C2013]
GO
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'TOP_4')
EXEC sys.sp_executesql N'CREATE SCHEMA [TOP_4] AUTHORIZATION [dbo]'
GO

---------------------------------Plan Medico---------------------------------------

GO

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

GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [TOP_4].[Usuario](
	[id_usuario] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[username] [varchar](255) NOT NULL UNIQUE,
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

GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [TOP_4].[Rol](
	[id_rol] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](255) NOT NULL UNIQUE,
	[activo] [bit] NOT NULL,
	[habilitado] [bit] NOT NULL,
 CONSTRAINT [PK_Rol] PRIMARY KEY CLUSTERED 
(
	[id_rol] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [TOP_4].[Rol] ADD  CONSTRAINT [DF_Rol_activo]  DEFAULT ((1)) FOR [activo]
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
	[descripcion] [varchar](255) NOT NULL,
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
INSERT INTO [TOP_4].[Funcionalidad] ([nombre], [descripcion], [habilitado]) VALUES ('tsmArchivo', 'Archivo' ,1) -- 1
INSERT INTO [TOP_4].[Funcionalidad] ([nombre], [descripcion], [habilitado]) VALUES ('tsmSesion', 'Sesión',1) -- 2
INSERT INTO [TOP_4].[Funcionalidad] ([nombre], [descripcion], [habilitado]) VALUES ('tsmSesion_IniciarSesion', 'Iniciar sesión' ,1) -- 3  
INSERT INTO [TOP_4].[Funcionalidad] ([nombre], [descripcion], [habilitado]) VALUES ('tsmSesion_CerrarSesion','Cerrar sesión' ,1) -- 4
INSERT INTO [TOP_4].[Funcionalidad] ([nombre], [descripcion], [habilitado]) VALUES ('estadísticasToolStripMenuItem','Estadísticas' ,1) --5 
INSERT INTO [TOP_4].[Funcionalidad] ([nombre], [descripcion], [habilitado]) VALUES ('tsmSalir', 'Salir',1) -- 6
-- Menu Gestión de clínica
INSERT INTO [TOP_4].[Funcionalidad] ([nombre], [descripcion], [habilitado]) VALUES ('tsmGestionDeClinica','Gestión de clínica' ,1) --7
INSERT INTO [TOP_4].[Funcionalidad] ([nombre], [descripcion], [habilitado]) VALUES ('tsmPlanes','Planes' ,1) -- 8
INSERT INTO [TOP_4].[Funcionalidad] ([nombre], [descripcion], [habilitado]) VALUES ('tsmRoles', 'Roles' ,1) --9 
INSERT INTO [TOP_4].[Funcionalidad] ([nombre], [descripcion], [habilitado]) VALUES ('tsmUsuarios', 'Usuarios' ,1) -- 10
INSERT INTO [TOP_4].[Funcionalidad] ([nombre], [descripcion], [habilitado]) VALUES ('tsmCancelaciones', 'Cancelaciones', 1) --11
INSERT INTO [TOP_4].[Funcionalidad] ([nombre], [descripcion], [habilitado]) VALUES ('tsmCancelaciones_Afiliado', 'Cancelación afiliado'  ,1) --12
INSERT INTO [TOP_4].[Funcionalidad] ([nombre], [descripcion], [habilitado]) VALUES ('tsmCancelaciones_Profesional', 'Cancelación profesional' ,1) --13
-- Menu Gestión de afiliados
INSERT INTO [TOP_4].[Funcionalidad] ([nombre], [descripcion], [habilitado]) VALUES ('tsmAfiliados', 'Afiliados' ,1) --14
INSERT INTO [TOP_4].[Funcionalidad] ([nombre], [descripcion], [habilitado]) VALUES ('tsmCompraDeBonos', 'Compra de bonos' ,1) --15
INSERT INTO [TOP_4].[Funcionalidad] ([nombre], [descripcion], [habilitado]) VALUES ('tsmPedirTurno', 'Pedir turno' ,1) --16
INSERT INTO [TOP_4].[Funcionalidad] ([nombre], [descripcion], [habilitado]) VALUES ('tsmRegistroDeLlegada', 'Registro de llegada' ,1) --17
INSERT INTO [TOP_4].[Funcionalidad] ([nombre], [descripcion], [habilitado]) VALUES ('tsmRegistroDeResultados', 'Registro de resultados' ,1) --18
INSERT INTO [TOP_4].[Funcionalidad] ([nombre], [descripcion], [habilitado]) VALUES ('tsmRecetar', 'Recetar' ,1) --19
-- Menu Gestión de profesionales
INSERT INTO [TOP_4].[Funcionalidad] ([nombre], [descripcion], [habilitado]) VALUES ('tsmGestionDeProfesionales', 'Gestión de profesionales' ,1) --20
INSERT INTO [TOP_4].[Funcionalidad] ([nombre], [descripcion], [habilitado]) VALUES ('tsmProfesionales', 'Profesionales' ,1) --21
INSERT INTO [TOP_4].[Funcionalidad] ([nombre], [descripcion], [habilitado]) VALUES ('tsmEspecialidades', 'Especialidades' ,1) --22 
-- Menu Agenda
INSERT INTO [TOP_4].[Funcionalidad] ([nombre], [descripcion], [habilitado]) VALUES ('tsmAgenda', 'Agenda' ,1) --23
INSERT INTO [TOP_4].[Funcionalidad] ([nombre], [descripcion], [habilitado]) VALUES ('tsmAgenda_Consultar', 'Consultar agenda' ,1) --24
INSERT INTO [TOP_4].[Funcionalidad] ([nombre], [descripcion], [habilitado]) VALUES ('tsmAgenda_Registrar', 'Registrar agenda', 1) --25
-- ADRIAN:
INSERT INTO [TOP_4].[Funcionalidad] ([nombre], [descripcion], [habilitado]) VALUES ('tsmGestionDeAfiliados', 'Gestión de afiliados' ,1) --26 
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
--INSERT INTO [TOP_4].[Rol_Funcionalidad] ([id_rol],[id_funcionalidad]) VALUES (1, 14)
INSERT INTO [TOP_4].[Rol_Funcionalidad] ([id_rol],[id_funcionalidad]) VALUES (1, 15)
INSERT INTO [TOP_4].[Rol_Funcionalidad] ([id_rol],[id_funcionalidad]) VALUES (1, 16)
INSERT INTO [TOP_4].[Rol_Funcionalidad] ([id_rol],[id_funcionalidad]) VALUES (1, 26)

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
--INSERT INTO [TOP_4].[Rol_Funcionalidad] ([id_rol],[id_funcionalidad]) VALUES (2, 19)
INSERT INTO [TOP_4].[Rol_Funcionalidad] ([id_rol],[id_funcionalidad]) VALUES (2, 20)
INSERT INTO [TOP_4].[Rol_Funcionalidad] ([id_rol],[id_funcionalidad]) VALUES (2, 21)
INSERT INTO [TOP_4].[Rol_Funcionalidad] ([id_rol],[id_funcionalidad]) VALUES (2, 22)
INSERT INTO [TOP_4].[Rol_Funcionalidad] ([id_rol],[id_funcionalidad]) VALUES (2, 23)
INSERT INTO [TOP_4].[Rol_Funcionalidad] ([id_rol],[id_funcionalidad]) VALUES (2, 24)
INSERT INTO [TOP_4].[Rol_Funcionalidad] ([id_rol],[id_funcionalidad]) VALUES (2, 25)
INSERT INTO [TOP_4].[Rol_Funcionalidad] ([id_rol],[id_funcionalidad]) VALUES (2, 26)

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
--INSERT INTO [TOP_4].[Rol_Funcionalidad] ([id_rol],[id_funcionalidad]) VALUES (3, 14)
INSERT INTO [TOP_4].[Rol_Funcionalidad] ([id_rol],[id_funcionalidad]) VALUES (3, 18)
--INSERT INTO [TOP_4].[Rol_Funcionalidad] ([id_rol],[id_funcionalidad]) VALUES (3, 19)
INSERT INTO [TOP_4].[Rol_Funcionalidad] ([id_rol],[id_funcionalidad]) VALUES (3, 23)
INSERT INTO [TOP_4].[Rol_Funcionalidad] ([id_rol],[id_funcionalidad]) VALUES (3, 24)
INSERT INTO [TOP_4].[Rol_Funcionalidad] ([id_rol],[id_funcionalidad]) VALUES (3, 25)
INSERT INTO [TOP_4].[Rol_Funcionalidad] ([id_rol],[id_funcionalidad]) VALUES (3, 26)
GO


---------------------------------------CREACION DE USUARIOS CON SUS ROLES----------------------------------
--Creo usuarios y sus roles

CREATE TABLE #TmpUsuariosPacientes (
	[id_usuario] numeric(18,0) IDENTITY(1,1) NOT NULL,
	username numeric(18,0) NOT NULL,
	password varbinary(32) NOT NULL
)
INSERT INTO #TmpUsuariosPacientes
(username, password)
(
	SELECT DISTINCT m.Paciente_Dni, CONVERT(varbinary(32),'0x1AEAEBA4BDBF8907638434B60504B1037C01905BEC294FB2CD5348724F2FA64F', 1)
	FROM gd_esquema.Maestra m
)

SET IDENTITY_INSERT TOP_4.Usuario ON

INSERT INTO TOP_4.Usuario
(id_usuario, username, password)
(
	SELECT id_usuario, username, password
	FROM #TmpUsuariosPacientes
)

SET IDENTITY_INSERT TOP_4.Usuario OFF

INSERT INTO TOP_4.Usuario_Rol
(id_usuario, id_rol)
(
	SELECT id_usuario, 1
	FROM #TmpUsuariosPacientes
)

DROP TABLE #tmpUsuariosPacientes

--- Creo los usuarios administradores
GO
INSERT INTO [TOP_4].[Usuario] ([username],[password],[habilitado]) VALUES ('admin', CONVERT(varbinary(32),'0xE6B87050BFCB8143FCB8DB0170A4DC9ED00D904DDD3E2A4AD1B1E8DC0FDC9BE7', 1),1)
INSERT INTO [TOP_4].[Usuario_Rol] ([id_usuario],[id_rol]) VALUES (@@IDENTITY , 2)

INSERT INTO [TOP_4].[Usuario] ([username],[password],[habilitado]) VALUES ('admin2', CONVERT(varbinary(32),'0xE6B87050BFCB8143FCB8DB0170A4DC9ED00D904DDD3E2A4AD1B1E8DC0FDC9BE7', 1),1)
INSERT INTO [TOP_4].[Usuario_Rol] ([id_usuario],[id_rol]) VALUES (@@IDENTITY , 2)

INSERT INTO [TOP_4].[Usuario] ([username],[password],[habilitado]) VALUES ('admin3', CONVERT(varbinary(32),'0xE6B87050BFCB8143FCB8DB0170A4DC9ED00D904DDD3E2A4AD1B1E8DC0FDC9BE7', 1),1)
INSERT INTO [TOP_4].[Usuario_Rol] ([id_usuario],[id_rol]) VALUES (@@IDENTITY , 2)

INSERT INTO [TOP_4].[Usuario] ([username],[password],[habilitado]) VALUES ('admin4', CONVERT(varbinary(32),'0xE6B87050BFCB8143FCB8DB0170A4DC9ED00D904DDD3E2A4AD1B1E8DC0FDC9BE7', 1),1)
INSERT INTO [TOP_4].[Usuario_Rol] ([id_usuario],[id_rol]) VALUES (@@IDENTITY , 2)

INSERT INTO [TOP_4].[Usuario] ([username],[password],[habilitado]) VALUES ('admin5', CONVERT(varbinary(32),'0xE6B87050BFCB8143FCB8DB0170A4DC9ED00D904DDD3E2A4AD1B1E8DC0FDC9BE7', 1),1)
INSERT INTO [TOP_4].[Usuario_Rol] ([id_usuario],[id_rol]) VALUES (@@IDENTITY , 2)

GO

--Creo el usuario root con todos los roles
DECLARE @identidadRoot NUMERIC(18,0)
INSERT INTO [TOP_4].[Usuario] ([username],[password],[habilitado]) VALUES ('root', CONVERT(varbinary(32),'0xE6B87050BFCB8143FCB8DB0170A4DC9ED00D904DDD3E2A4AD1B1E8DC0FDC9BE7', 1),1)
SET @identidadRoot = @@IDENTITY
INSERT INTO [TOP_4].[Usuario_Rol] ([id_usuario],[id_rol]) VALUES (@identidadRoot , 1)
INSERT INTO [TOP_4].[Usuario_Rol] ([id_usuario],[id_rol]) VALUES (@identidadRoot , 2)
INSERT INTO [TOP_4].[Usuario_Rol] ([id_usuario],[id_rol]) VALUES (@identidadRoot , 3)

------------------------------------Profesional------------------------------------------------


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
	[tipo_documento] [int] NOT NULL,
	[documento] [numeric](18, 0) NOT NULL,
	[direccion] [varchar](255) NOT NULL,
	[telefono] [numeric](18, 0) NOT NULL,
	[mail] [varchar](255) NOT NULL,
	[fecha_nacimiento] [datetime] NOT NULL,
	[sexo] [int] NOT NULL,
	[matricula] [numeric](18, 0) NOT NULL UNIQUE,
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

ALTER TABLE [TOP_4].[Profesional] ADD  CONSTRAINT [DF_Profesionales_tipo_documento]  DEFAULT ((0)) FOR [tipo_documento]
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
 CONSTRAINT [PK_Prof] PRIMARY KEY CLUSTERED 
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
 
--inserto los profesionales y creo sus usuarios

insert into TOP_4.Profesional
	(nombre, apellido, documento, direccion, telefono, mail, fecha_nacimiento, matricula)
(
	SELECT nombre, apellido, documento, direccion, telefono, mail, fecha_nacimiento, matricula
		FROM #TmpProfesional
)

DECLARE @ultimaIdent NUMERIC(18,0)
SET @ultimaIdent = IDENT_CURRENT('TOP_4.Usuario')

INSERT INTO [TOP_4].[Usuario] 
	(username, password)
(
	SELECT documento, CONVERT(varbinary(32),'0x24AFE47D0BD302AE42643C5848D99B683264026CD12CC998E05E100BBF2DC30D', 1)
	FROM TOP_4.Profesional
)

UPDATE TOP_4.Profesional 
SET TOP_4.Profesional.id_usuario  = u.id_usuario
FROM TOP_4.Profesional
INNER JOIN	TOP_4.Usuario u
ON	u.username = convert(varchar(255), documento)

INSERT INTO [TOP_4].Usuario_Rol
(id_usuario, id_rol)
(
	SELECT id_usuario, 3
	FROM TOP_4.Profesional
)

DROP TABLE #TmpProfesional
GO

CREATE NONCLUSTERED INDEX [indice_id_usuario] ON [TOP_4].[Profesional]
(
	[id_usuario] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


------------------------------------Tipo_especialidad---------------------------------------------


GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [TOP_4].[Tipo_especialidad](
	[id_tipo_especialidad] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](255) NOT NULL,
	[habilitado] [bit] NOT NULL,
 CONSTRAINT [PK_Tipo_especialidad] PRIMARY KEY CLUSTERED 
(
	[id_tipo_especialidad] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [TOP_4].[Tipo_Especialidad] ADD  CONSTRAINT [DF_Tipo_Especialidad_habilitado]  DEFAULT ((1)) FOR [habilitado]
GO

SET ANSI_PADDING OFF
GO


SET IDENTITY_INSERT TOP_4.Tipo_especialidad ON

INSERT INTO TOP_4.Tipo_especialidad (id_tipo_especialidad, nombre)
(
	SELECT DISTINCT  m.Tipo_Especialidad_Codigo, m.Tipo_Especialidad_Descripcion 
		FROM gd_esquema.Maestra m
		WHERE Tipo_Especialidad_Codigo is not null	
)

SET IDENTITY_INSERT TOP_4.Tipo_especialidad OFF
---------------------------------------Especialidad--------------------------------------------------

GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [TOP_4].[Especialidad](
	[id_especialidad] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[id_tipo_especialidad] [numeric](18, 0) NOT NULL,
	[nombre] [nvarchar](255) NOT NULL,
	[habilitado] [bit] NOT NULL,
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

ALTER TABLE [TOP_4].[Especialidad] ADD  CONSTRAINT [DF_Especialidad_habilitado]  DEFAULT ((1)) FOR [habilitado]
GO

SET IDENTITY_INSERT TOP_4.Especialidad ON
INSERT INTO TOP_4.Especialidad
(id_especialidad, nombre, id_tipo_especialidad)
(
	SELECT DISTINCT  m.Especialidad_Codigo, m.Especialidad_Descripcion, m.Tipo_Especialidad_Codigo
		FROM gd_esquema.Maestra m
		WHERE m.Especialidad_Codigo IS NOT NULL
)
SET IDENTITY_INSERT TOP_4.Especialidad OFF
GO
------------------------------------Profesional_especialidad-----------------------------------------------

GO

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


GO

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
(id_profesional, fecha_hasta, fecha_desde)
(
	SELECT DISTINCT p.id_profesional, MAX(m.Turno_Fecha) as 'maxturno' , 
			MIN(m.turno_fecha) as 'minturno'
	FROM gd_esquema.Maestra m
	INNER JOIN TOP_4.Profesional p
		ON p.documento = m.Medico_Dni
	WHERE m.Medico_Dni IS NOT NULL
	AND m.Turno_Fecha IS NOT NULL
	GROUP BY p.id_profesional, m.Medico_Dni, m.Medico_Nombre, m.Medico_Apellido
)

GO

------------------------------------------Dia_Agenda--------------------------------------------------


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


INSERT INTO TOP_4.Dia_Agenda
(id_agenda, nro_dia_semana, nombre_dia_semana, hora_desde, hora_hasta)
( SELECT  agen.id_agenda, agen.numDia, agen.diaDeLaSemana, agen.primerHora, agen.ultimaHora
	FROM
	(
		SELECT p.id_profesional
				,cast(min(m.turno_fecha) as time) as 'primerHora' 
				,cast(max(m.turno_fecha) as time) as 'ultimaHora'
				,datepart(weekday,m.Turno_Fecha) as 'numDia'
				,datename(weekday, m.Turno_Fecha) as 'diaDeLaSemana'
				,ag.id_agenda
		FROM gd_esquema.Maestra m
		INNER JOIN TOP_4.Profesional p
			ON m.Medico_Dni = p.documento
		INNER JOIN TOP_4.Agenda ag
			ON ag.id_profesional = p.id_profesional
		WHERE m.Turno_Fecha IS NOT NULL
		GROUP BY p.id_profesional, datepart(weekday,m.Turno_Fecha), datename(weekday, m.Turno_Fecha), ag.id_agenda
	) agen
)
GO
-- ---------------------------- Dia Agenda Excepcion ----------------------------------
CREATE TABLE [TOP_4].[Dia_Agenda_Excepcion](
	[id_fecha_excepcion] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[id_agenda] [numeric](18, 0) NOT NULL,
	[dia] [datetime] NOT NULL,
 CONSTRAINT [PK_Dia_Agenda_Excepcion] PRIMARY KEY CLUSTERED 
(
	[id_fecha_excepcion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [TOP_4].[Dia_Agenda_Excepcion]  WITH CHECK ADD  CONSTRAINT [FK_Dia_Agenda_Excepcion_Agenda] FOREIGN KEY([id_agenda])
REFERENCES [TOP_4].[Agenda] ([id_agenda])
GO

ALTER TABLE [TOP_4].[Dia_Agenda_Excepcion] CHECK CONSTRAINT [FK_Dia_Agenda_Excepcion_Agenda]
GO


---------------------------------Afiliado----------------------------------------------



GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [TOP_4].[Afiliado](
	[id_afiliado] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[nro_principal] [numeric](18, 0) NOT NULL,
	[nro_secundario] [numeric](18, 0) NOT NULL,
	[id_usuario] [numeric](18, 0) NOT NULL,
	[id_plan_medico] [numeric](18, 0) NOT NULL,
	[tipo_documento] [int] NOT NULL,
	[documento] [numeric](18, 0) NOT NULL,
	[nombre] [varchar](255) NOT NULL,
	[apellido] [varchar](255) NOT NULL,
	[direccion] [varchar](255) NOT NULL,
	[telefono] [numeric](18, 0) NOT NULL,
	[mail] [varchar](255) NOT NULL,
	[fecha_nacimiento] [datetime] NOT NULL,
	[sexo] [int] NOT NULL,
	[estado_civil] [int] NOT NULL,
--	[cantidad_familiares] [int] NOT NULL,
	[fecha_baja] [datetime] NULL,
	[habilitado] [bit] NOT NULL,
 CONSTRAINT [PK_Afiliado] PRIMARY KEY CLUSTERED 
(
	[id_afiliado] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [TOP_4].[Afiliado]  WITH CHECK ADD  CONSTRAINT [FK_Afiliado_Plan_medico] FOREIGN KEY([id_plan_medico])
REFERENCES [TOP_4].[Plan_medico] ([id_plan_medico])
GO

ALTER TABLE [TOP_4].[Afiliado] CHECK CONSTRAINT [FK_Afiliado_Plan_medico]
GO

ALTER TABLE [TOP_4].[Afiliado]  WITH CHECK ADD  CONSTRAINT [FK_Afiliado_Usuario] FOREIGN KEY([id_usuario])
REFERENCES [TOP_4].[Usuario] ([id_usuario])
GO

ALTER TABLE [TOP_4].[Afiliado] CHECK CONSTRAINT [FK_Afiliado_Usuario]
GO

ALTER TABLE [TOP_4].[Afiliado] ADD  CONSTRAINT [DF_Afiliado_tipo_documento]  DEFAULT ((0)) FOR [tipo_documento]
GO

ALTER TABLE [TOP_4].[Afiliado] ADD  CONSTRAINT [DF_Afiliado_sexo]  DEFAULT ((0)) FOR [sexo]
GO

ALTER TABLE [TOP_4].[Afiliado] ADD  CONSTRAINT [DF_Afiliado_estado_civil]  DEFAULT ((0)) FOR [estado_civil]
GO

ALTER TABLE [TOP_4].[Afiliado] ADD  CONSTRAINT [DF_Afiliado_habilitado]  DEFAULT ((1)) FOR [habilitado]
GO

ALTER TABLE [TOP_4].[Afiliado] ADD CONSTRAINT [Unique_documento] UNIQUE (tipo_documento, documento)

--Primero inserto los usuarios con grupos familiares


CREATE TABLE #TmpPacientesGruposAntes (
	documento numeric(18,0) NOT NULL,
	direccion varchar(255) NOT NULL
)

CREATE TABLE #TmpPacientesGruposDespues (
	documento numeric(18,0) NOT NULL,
	direccion varchar(255) NOT NULL,
	num_principal numeric(18,0) NOT NULL,
	num_secundario numeric(18,0) NOT NULL
)

INSERT INTO #TmpPacientesGruposAntes
(documento, direccion)
(
	SELECT DISTINCT m.Paciente_Dni, m.Paciente_Direccion
	FROM gd_esquema.Maestra m
	WHERE exists(
		SELECT * FROM gd_esquema.Maestra m2
		WHERE m2.Paciente_Direccion = m.Paciente_Direccion
		AND m2.Paciente_Dni != m.Paciente_Dni
		)
)

DECLARE @docu_act numeric(18,0)
DECLARE @dire_act varchar(255)

DECLARE @num_princ_grupo numeric(18,0)
DECLARE @num_secu_grupo numeric(18,0)

DECLARE CUR_GRUPOS CURSOR FOR
	SELECT documento, direccion
	FROM #TmpPacientesGruposAntes

SET NOCOUNT ON	
OPEN CUR_GRUPOS

FETCH NEXT FROM CUR_GRUPOS
INTO @docu_act, @dire_act

WHILE @@FETCH_STATUS = 0
BEGIN
	SET @num_princ_grupo = null
	SET @num_secu_grupo = null
	
	SELECT  @num_princ_grupo=pgd.num_principal,
			@num_secu_grupo=ISNULL(MAX(pgd.num_secundario),0)
	FROM #TmpPacientesGruposDespues pgd
	WHERE pgd.direccion=@dire_act
	GROUP BY pgd.num_principal
	
	IF @num_princ_grupo IS NULL
	BEGIN
		DECLARE @max_num NUMERIC(18,0)
		SELECT @max_num=ISNULL(MAX(num_principal),0)
		FROM #TmpPacientesGruposDespues
		
		SET @max_num = @max_num + 100

		INSERT INTO #TmpPacientesGruposDespues
			(documento, direccion, num_principal, num_secundario)
		VALUES
			(@docu_act, @dire_act, @max_num , 1)
	END
	ELSE
	BEGIN
		SET @num_secu_grupo = @num_secu_grupo + 1
		INSERT INTO #TmpPacientesGruposDespues
			(documento, direccion, num_principal, num_secundario)
		VALUES
			(@docu_act, @dire_act, @num_princ_grupo, @num_secu_grupo )
	END
		
	FETCH NEXT FROM CUR_GRUPOS
	INTO @docu_act, @dire_act
END

CLOSE CUR_GRUPOS
DEALLOCATE CUR_GRUPOS

INSERT INTO TOP_4.Afiliado
(nro_principal, nro_secundario, id_usuario, id_plan_medico, 
	tipo_documento,	documento, nombre, apellido, direccion, 
	telefono, mail, fecha_nacimiento, sexo,	estado_civil)
(
	SELECT DISTINCT pgd.num_principal, pgd.num_secundario, usu.id_usuario, m.Plan_Med_Codigo, 0 as tipoDocu,
		m.Paciente_Dni, m.Paciente_Nombre, m.Paciente_Apellido, m.Paciente_Direccion, m.Paciente_Telefono,
		m.Paciente_Mail, m.Paciente_Fecha_Nac, 0 as sexo, 0 as estadoCivil 
	FROM #TmpPacientesGruposDespues pgd
	JOIN gd_esquema.Maestra m
		ON m.Paciente_Dni = pgd.documento
	JOIN TOP_4.Usuario usu
		ON usu.username = CONVERT(varchar(255),m.Paciente_Dni)
)


--Luego inserto los usuarios sin grupo familiar


CREATE TABLE #nrosPrinc (
	nro_principal numeric(18,0) IDENTITY(0, 100) NOT NULL,
	documento numeric(18,0) NOT NULL
)

INSERT INTO #nrosPrinc
	(documento)
(
	SELECT DISTINCT m.Paciente_Dni
	FROM gd_esquema.Maestra m
	WHERE m.Paciente_Dni NOT IN (SELECT documento from #TmpPacientesGruposAntes)
)

DECLARE @ident int
SELECT @ident=ISNULL(MAX(num_principal),0)
	FROM #TmpPacientesGruposDespues


INSERT INTO TOP_4.Afiliado
(nro_principal, nro_secundario, id_usuario, id_plan_medico, 
	tipo_documento,	documento, nombre, apellido, direccion, 
	telefono, mail, fecha_nacimiento, sexo,	estado_civil)
(
	SELECT DISTINCT np.nro_principal + @ident, 1, usu.id_usuario, m.Plan_Med_Codigo, 
		0 as tipoDocu, m.Paciente_Dni, m.Paciente_Nombre, m.Paciente_Apellido,
		m.Paciente_Direccion, m.Paciente_Telefono, m.Paciente_Mail,
		m.Paciente_Fecha_Nac, 0 as sexo, 0 as estadoCivil	
	FROM #nrosPrinc np
	JOIN gd_esquema.Maestra m
		ON m.Paciente_Dni=np.documento
	JOIN TOP_4.Usuario usu
		ON usu.username = CONVERT(varchar(255),m.Paciente_Dni)
	WHERE m.Paciente_Dni IS NOT NULL
	
)
DROP TABLE #nrosPrinc
DROP TABLE #TmpPacientesGruposAntes
DROP TABLE #TmpPacientesGruposDespues

GO
CREATE NONCLUSTERED INDEX [Afiliado_id_usuario] ON [TOP_4].[Afiliado]
(
	[id_usuario] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [indice_id_usuario] ON [TOP_4].[Afiliado]
(
	[documento] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


----------------------------------------------TURNO-------------------------------------------------


GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [TOP_4].[Turno](
	[id_turno] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[id_afiliado] [numeric](18, 0) NOT NULL,
	[id_profesional] [numeric](18, 0) NOT NULL,
	[fecha_turno] [datetime] NOT NULL,
	[fecha_llegada] [datetime] NULL,
	[habilitado] [bit] NOT NULL,
 CONSTRAINT [PK_Turno] PRIMARY KEY CLUSTERED 
(
	[id_turno] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [TOP_4].[Turno]  WITH CHECK ADD  CONSTRAINT [FK_Turno_Afiliado] FOREIGN KEY([id_afiliado])
REFERENCES [TOP_4].[Afiliado] ([id_afiliado])
GO

ALTER TABLE [TOP_4].[Turno] CHECK CONSTRAINT [FK_Turno_Afiliado]
GO

ALTER TABLE [TOP_4].[Turno]  WITH CHECK ADD  CONSTRAINT [FK_Turno_Profesional] FOREIGN KEY([id_profesional])
REFERENCES [TOP_4].[Profesional] ([id_profesional])
GO

ALTER TABLE [TOP_4].[Turno] CHECK CONSTRAINT [FK_Turno_Profesional]
GO

ALTER TABLE [TOP_4].[Turno] ADD  CONSTRAINT [DF_Turno_habilitado]  DEFAULT ((1)) FOR [habilitado]
GO

SET IDENTITY_INSERT TOP_4.Turno ON

INSERT INTO TOP_4.Turno
(id_turno, id_afiliado, id_profesional, fecha_turno, fecha_llegada)
(
	SELECT DISTINCT m.Turno_Numero, afi.id_afiliado, pro.id_profesional, m.Turno_Fecha, m.Turno_Fecha
	FROM gd_esquema.Maestra m
	INNER JOIN TOP_4.Afiliado afi
		ON afi.documento = m.Paciente_Dni
	INNER JOIN TOP_4.Profesional pro
		ON pro.documento = m.Medico_Dni
	WHERE m.Turno_Fecha IS NOT NULL
	AND m.Turno_Numero IS NOT NULL
	AND m.Medico_Dni IS NOT NULL
	AND m.Paciente_Dni IS NOT NULL
)
SET IDENTITY_INSERT TOP_4.Turno OFF
GO

CREATE NONCLUSTERED INDEX [indice_id_profesional] ON [TOP_4].[Turno]
(
	[id_profesional] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

--------------------------------------------MEDICAMENTO----------------------------------------------


GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [TOP_4].[Medicamento](
	[id_medicamento] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](255) NOT NULL,
	[habilitado] [bit] NOT NULL,
 CONSTRAINT [PK_Medicamento] PRIMARY KEY CLUSTERED 
(
	[id_medicamento] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [TOP_4].[Medicamento] ADD  CONSTRAINT [DF_Medicamento_habilitado]  DEFAULT ((1)) FOR [habilitado]
GO


INSERT INTO TOP_4.Medicamento
(nombre)
(
	SELECT DISTINCT Bono_Farmacia_Medicamento
	FROM gd_esquema.Maestra
	WHERE Bono_Farmacia_Medicamento IS NOT NULL
)
GO

-------------------------------------RESULTADO_TURNO--------------------------------------------


GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [TOP_4].[Resultado_Turno](
	[id_resultado_turno] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[id_turno] [numeric](18, 0) NOT NULL,
	[sintoma] [varchar](255) NOT NULL,
	[diagnostico] [varchar](255) NOT NULL,
	[fecha_diagnostico] [datetime] NOT NULL,
	[habilitado] [bit] NOT NULL,
 CONSTRAINT [PK_Resultado_Turno] PRIMARY KEY CLUSTERED 
(
	[id_resultado_turno] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [TOP_4].[Resultado_Turno]  WITH CHECK ADD  CONSTRAINT [FK_Resultado_Turno_Turno] FOREIGN KEY([id_turno])
REFERENCES [TOP_4].[Turno] ([id_turno])
GO

ALTER TABLE [TOP_4].[Resultado_Turno] CHECK CONSTRAINT [FK_Resultado_Turno_Turno]
GO

ALTER TABLE [TOP_4].[Resultado_Turno] ADD  CONSTRAINT [DF_Resultado_Turno_habilitado]  DEFAULT ((1)) FOR [habilitado]
GO

INSERT INTO TOP_4.Resultado_Turno
(id_turno, fecha_diagnostico, sintoma, diagnostico)
(
	SELECT DISTINCT m.Turno_Numero, m.Turno_Fecha, m.Consulta_Enfermedades, m.Consulta_Sintomas
	FROM gd_esquema.Maestra m
	WHERE Consulta_Enfermedades IS NOT NULL
)

GO
CREATE NONCLUSTERED INDEX [Resultado_id_turno] ON [TOP_4].[Resultado_Turno]
(
	[id_turno] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

-----------------------------------------RECETA------------------------------------------


GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [TOP_4].[Receta](
	[id_receta] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[id_resultado_turno] [numeric](18, 0) NOT NULL,
	[habilitado] [bit] NOT NULL,
 CONSTRAINT [PK_Receta] PRIMARY KEY CLUSTERED 
(
	[id_receta] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [TOP_4].[Receta]  WITH CHECK ADD  CONSTRAINT [FK_Receta_Resultado_Turno] FOREIGN KEY([id_resultado_turno])
REFERENCES [TOP_4].[Resultado_Turno] ([id_resultado_turno])
GO

ALTER TABLE [TOP_4].[Receta] CHECK CONSTRAINT [FK_Receta_Resultado_Turno]
GO

ALTER TABLE [TOP_4].[Receta] ADD  CONSTRAINT [DF_Receta_habilitado]  DEFAULT ((1)) FOR [habilitado]
GO


INSERT INTO TOP_4.Receta
(id_resultado_turno)
(
	SELECT rt.id_resultado_turno
	FROM gd_esquema.Maestra m
	INNER JOIN TOP_4.Resultado_Turno rt
		ON rt.id_turno = m.Turno_Numero
	WHERE m.Bono_Farmacia_Medicamento IS NOT NULL
)

-----------------------------------------Item_Receta------------------------------------------------------


GO

/****** Object:  Table [TOP_4].[Item_Receta]    Script Date: 11/03/2013 19:43:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [TOP_4].[Item_Receta](
	[id_item_receta] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[id_receta] [numeric](18, 0) NOT NULL,
	[id_medicamento] [numeric](18, 0) NOT NULL,
	[cantidad] [int] NOT NULL,
	[habilitado] [bit] NOT NULL,
 CONSTRAINT [PK_Item_Receta] PRIMARY KEY CLUSTERED 
(
	[id_item_receta] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [TOP_4].[Item_Receta]  WITH CHECK ADD  CONSTRAINT [FK_Item_Receta_Medicamento] FOREIGN KEY([id_medicamento])
REFERENCES [TOP_4].[Medicamento] ([id_medicamento])
GO

ALTER TABLE [TOP_4].[Item_Receta] CHECK CONSTRAINT [FK_Item_Receta_Medicamento]
GO

ALTER TABLE [TOP_4].[Item_Receta]  WITH CHECK ADD  CONSTRAINT [FK_Item_Receta_Receta] FOREIGN KEY([id_receta])
REFERENCES [TOP_4].[Receta] ([id_receta])
GO

ALTER TABLE [TOP_4].[Item_Receta] CHECK CONSTRAINT [FK_Item_Receta_Receta]
GO

ALTER TABLE [TOP_4].[Item_Receta] ADD  CONSTRAINT [DF_Item_Receta_habilitado]  DEFAULT ((1)) FOR [habilitado]
GO

INSERT INTO TOP_4.Item_Receta
(id_receta, id_medicamento, cantidad)
(	
	SELECT rec.id_receta, med.id_medicamento, 1
	FROM gd_esquema.Maestra m
	INNER JOIN TOP_4.Medicamento med
		ON m.Bono_Farmacia_Medicamento = med.nombre
	INNER JOIN TOP_4.Turno tur
		ON m.Turno_Numero = tur.id_turno
	INNER JOIN TOP_4.Resultado_Turno resTur
		ON tur.id_turno = resTur.id_turno
	INNER JOIN TOP_4.Receta rec
		ON rec.id_resultado_turno = resTur.id_resultado_turno
)

GO

------------------------------------------------------Compra---------------------------------------------------------


GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [TOP_4].[Compra](
	[id_compra] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[id_afiliado] [numeric](18, 0) NOT NULL,
	[fecha_compra] [datetime] NOT NULL,
	[costo] [numeric](18,0) NOT NULL,
	[habilitado] [bit] NOT NULL,
 CONSTRAINT [PK_Compra] PRIMARY KEY CLUSTERED 
(
	[id_compra] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [TOP_4].[Compra]  WITH CHECK ADD  CONSTRAINT [FK_Compra_Afiliado] FOREIGN KEY([id_afiliado])
REFERENCES [TOP_4].[Afiliado] ([id_afiliado])
GO

ALTER TABLE [TOP_4].[Compra] CHECK CONSTRAINT [FK_Compra_Afiliado]
GO

ALTER TABLE [TOP_4].[Compra] ADD  CONSTRAINT [DF_Compra_habilitado_1]  DEFAULT ((1)) FOR [habilitado]
GO


-------------------------------------------------Bono_Consulta-----------------------------------------------------------


GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [TOP_4].[Bono_Consulta](
	[id_bono_consulta] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[id_compra] [numeric](18, 0) NOT NULL,
	[id_turno] [numeric](18, 0) NULL,
	[id_plan_medico] [numeric](18, 0) NOT NULL,
	[fecha_impresion] [datetime] NOT NULL,
	[habilitado] [bit] NOT NULL,
 CONSTRAINT [PK_Bono_Consulta] PRIMARY KEY CLUSTERED 
(
	[id_bono_consulta] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [TOP_4].[Bono_Consulta]  WITH CHECK ADD  CONSTRAINT [FK_Bono_Consulta_Compra] FOREIGN KEY([id_compra])
REFERENCES [TOP_4].[Compra] ([id_compra])
GO

ALTER TABLE [TOP_4].[Bono_Consulta] CHECK CONSTRAINT [FK_Bono_Consulta_Compra]
GO

ALTER TABLE [TOP_4].[Bono_Consulta]  WITH CHECK ADD  CONSTRAINT [FK_Bono_Consulta_Plan_medico] FOREIGN KEY([id_plan_medico])
REFERENCES [TOP_4].[Plan_medico] ([id_plan_medico])
GO

ALTER TABLE [TOP_4].[Bono_Consulta] CHECK CONSTRAINT [FK_Bono_Consulta_Plan_medico]
GO

ALTER TABLE [TOP_4].[Bono_Consulta]  WITH CHECK ADD  CONSTRAINT [FK_Bono_Consulta_Turno] FOREIGN KEY([id_turno])
REFERENCES [TOP_4].[Turno] ([id_turno])
GO

ALTER TABLE [TOP_4].[Bono_Consulta] CHECK CONSTRAINT [FK_Bono_Consulta_Turno]
GO

ALTER TABLE [TOP_4].[Bono_Consulta] ADD  CONSTRAINT [DF_Bono_Consulta_habilitado_1]  DEFAULT ((1)) FOR [habilitado]
GO

--Inserto bonos consultas y compras asociadas
CREATE TABLE #tmpBonoConsulta(
	id_compra NUMERIC(18,0) IDENTITY(1,1),
	id_afiliado NUMERIC(18,0),
	id_plan_medico NUMERIC(18,0),
	fecha_compra datetime,
	fecha_impresion datetime,
	id_bono_consulta NUMERIC(18,0)
)


INSERT INTO #tmpBonoConsulta (id_afiliado, id_plan_medico, fecha_compra, fecha_impresion, id_bono_consulta)
(
	SELECT a.id_afiliado, m.Plan_Med_Codigo, Compra_Bono_Fecha, Bono_Consulta_Fecha_Impresion, Bono_Consulta_Numero
	FROM gd_esquema.Maestra m
	JOIN TOP_4.Afiliado a
		ON a.documento = m.Paciente_Dni
	WHERE Bono_Consulta_Numero IS NOT NULL
	AND Bono_Farmacia_Numero IS NULL
)

SET IDENTITY_INSERT TOP_4.Compra ON
INSERT INTO TOP_4.Compra (id_compra, id_afiliado, fecha_compra, costo)
(
	SELECT tbc.id_compra, tbc.id_afiliado, tbc.fecha_compra, pl.precio_bono_consulta
	FROM #tmpBonoConsulta tbc
	INNER JOIN TOP_4.Plan_medico pl
		ON pl.id_plan_medico = tbc.id_plan_medico
)
SET IDENTITY_INSERT TOP_4.Compra OFF

SET IDENTITY_INSERT TOP_4.Bono_Consulta ON
INSERT INTO TOP_4.Bono_Consulta (id_bono_consulta, id_compra, id_plan_medico, fecha_impresion)
(
	SELECT id_bono_consulta, id_compra, id_plan_medico, fecha_impresion
	FROM #tmpBonoConsulta
)
SET IDENTITY_INSERT TOP_4.Bono_Consulta OFF

DROP TABLE #tmpBonoConsulta

--Asigno a los bonos que fueron utilizados sus turnos correspondientes
UPDATE TOP_4.Bono_Consulta 
SET TOP_4.Bono_Consulta.id_turno = gd_esquema.Maestra.Turno_Numero
FROM gd_esquema.Maestra
INNER JOIN TOP_4.Bono_Consulta
	ON TOP_4.Bono_Consulta.id_bono_consulta = gd_esquema.Maestra.Bono_Consulta_Numero
WHERE gd_esquema.Maestra.Bono_Consulta_Numero IS NOT NULL
AND gd_esquema.Maestra.Bono_Farmacia_Numero IS NOT NULL

GO
CREATE NONCLUSTERED INDEX [indice_bono_consulta_id_compra] ON [TOP_4].[Bono_Consulta]
(
	[id_compra] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


------------------------------------------------Bono_Farmacia--------------------------------------------------

GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [TOP_4].[Bono_Farmacia](
	[id_bono_farmacia] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[id_compra] [numeric](18, 0) NOT NULL,
	[id_plan_medico] [numeric](18, 0) NOT NULL,
	[id_receta] [numeric](18, 0) NULL,
	[fecha_vencimiento] [datetime] NOT NULL,
	[fecha_impresion] [datetime] NOT NULL,
	[fecha_prescripcion] [datetime] NULL,
	[habilitado] [bit] NOT NULL,
 CONSTRAINT [PK_Bono_Farmacia] PRIMARY KEY CLUSTERED 
(
	[id_bono_farmacia] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [TOP_4].[Bono_Farmacia]  WITH CHECK ADD  CONSTRAINT [FK_Bono_Farmacia_Compra] FOREIGN KEY([id_compra])
REFERENCES [TOP_4].[Compra] ([id_compra])
GO

ALTER TABLE [TOP_4].[Bono_Farmacia] CHECK CONSTRAINT [FK_Bono_Farmacia_Compra]
GO

ALTER TABLE [TOP_4].[Bono_Farmacia]  WITH CHECK ADD  CONSTRAINT [FK_Bono_Farmacia_Plan_medico] FOREIGN KEY([id_plan_medico])
REFERENCES [TOP_4].[Plan_medico] ([id_plan_medico])
GO

ALTER TABLE [TOP_4].[Bono_Farmacia] CHECK CONSTRAINT [FK_Bono_Farmacia_Plan_medico]
GO

ALTER TABLE [TOP_4].[Bono_Farmacia]  WITH CHECK ADD  CONSTRAINT [FK_Bono_Farmacia_Receta] FOREIGN KEY([id_receta])
REFERENCES [TOP_4].[Receta] ([id_receta])
GO

ALTER TABLE [TOP_4].[Bono_Farmacia] CHECK CONSTRAINT [FK_Bono_Farmacia_Receta]
GO

ALTER TABLE [TOP_4].[Bono_Farmacia] ADD  CONSTRAINT [DF_Bono_Farmacia_habilitado]  DEFAULT ((1)) FOR [habilitado]
GO


CREATE TABLE #tmpBonosFarmacia(
	id_bono_farmacia NUMERIC(18,0),
	id_plan_medico NUMERIC(18,0),
	id_compra NUMERIC(18,0) IDENTITY(1,1),
	fecha_compra datetime,
	fecha_impresion datetime,
	fecha_vencimiento datetime,
	id_turno NUMERIC(18,0),
	dni	NUMERIC(18,0)
)

--Obtengo todos los bonos farmacia
INSERT INTO #tmpBonosFarmacia
(id_bono_farmacia, id_plan_medico, fecha_compra, fecha_impresion, fecha_vencimiento, dni)
(
	SELECT m.Bono_Farmacia_Numero, m.Plan_Med_Codigo, m.Compra_Bono_Fecha, m.Bono_Farmacia_Fecha_Impresion, m.Bono_Farmacia_Fecha_Vencimiento, m.Paciente_Dni
	FROM gd_esquema.Maestra m
	WHERE m.Bono_Farmacia_Numero IS NOT NULL
	AND m.Compra_Bono_Fecha IS NOT NULL 
)
--Seteo los turnos en los que fueron utilizados
UPDATE #tmpBonosFarmacia
SET #tmpBonosFarmacia.id_turno = gd_esquema.Maestra.Turno_Numero
FROM gd_esquema.Maestra
WHERE gd_esquema.Maestra.Bono_Farmacia_Numero = #tmpBonosFarmacia.id_bono_farmacia
AND gd_esquema.Maestra.Bono_Farmacia_Numero IS NOT NULL
AND gd_esquema.Maestra.Compra_Bono_Fecha IS NULL

--Inserto primero las compras de los bonos farmacia:

DECLARE @ultimaIdentCompra NUMERIC(18,0)
SET @ultimaIdentCompra = IDENT_CURRENT('TOP_4.Compra')

SET IDENTITY_INSERT TOP_4.Compra ON
INSERT INTO TOP_4.Compra (id_compra, id_afiliado, fecha_compra, costo)
(
	SELECT (tbf.id_compra + @ultimaIdentCompra ), a.id_afiliado, tbf.fecha_compra, pm.precio_bono_farmacia
	FROM #tmpBonosFarmacia tbf
	INNER JOIN TOP_4.Afiliado a
		ON a.documento = tbf.dni
	INNER JOIN TOP_4.Plan_medico pm
		ON tbf.id_plan_medico = pm.id_plan_medico
)
SET IDENTITY_INSERT TOP_4.Compra OFF

--Joineo, inserto y soy feliz porque esta es la ultima tabla de la migracion
SET IDENTITY_INSERT TOP_4.Bono_Farmacia ON
INSERT INTO TOP_4.Bono_Farmacia
(id_bono_farmacia, id_compra, id_plan_medico, id_receta, fecha_vencimiento, fecha_impresion, fecha_prescripcion)
(
	SELECT tbf.id_bono_farmacia, (tbf.id_compra + @ultimaIdentCompra) as id_compra, tbf.id_plan_medico,
		r.id_receta, tbf.fecha_vencimiento, tbf.fecha_impresion, tur.fecha_turno
	FROM #tmpBonosFarmacia tbf
	INNER JOIN TOP_4.Turno tur
		ON tbf.id_turno = tur.id_turno
	INNER JOIN TOP_4.Resultado_Turno rt
		ON rt.id_turno = tbf.id_turno
	INNER JOIN TOP_4.Receta r
		ON r.id_resultado_turno = rt.id_resultado_turno
)
SET IDENTITY_INSERT TOP_4.Bono_Farmacia OFF

DROP TABLE #tmpBonosFarmacia

CREATE NONCLUSTERED INDEX [indice_bono_farmacia_id_compra] ON [TOP_4].[Bono_Farmacia]
(
	[id_compra] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

--Creo este indice aqui por performance; ya se han ingresado los datos
CREATE NONCLUSTERED INDEX [compra_id_afiliado] ON [TOP_4].[Compra]
(
	[id_afiliado] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

-----------------------------------------Plan_Historico_Afiliado--------------------------------------------------

GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [TOP_4].[Plan_Historico_Afiliado](
	[id_plan_historico_afiliado] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[id_afiliado] [numeric](18, 0) NOT NULL,
	[id_plan_medico] [numeric](18, 0) NOT NULL,
	[fecha] [datetime] NOT NULL,
	[habilitado] [bit] NOT NULL,
 CONSTRAINT [PK_Plan_Historico_Afiliado] PRIMARY KEY CLUSTERED 
(
	[id_plan_historico_afiliado] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [TOP_4].[Plan_Historico_Afiliado]  WITH CHECK ADD  CONSTRAINT [FK_Plan_Historico_Afiliado_Afiliado] FOREIGN KEY([id_afiliado])
REFERENCES [TOP_4].[Afiliado] ([id_afiliado])
GO

ALTER TABLE [TOP_4].[Plan_Historico_Afiliado] CHECK CONSTRAINT [FK_Plan_Historico_Afiliado_Afiliado]
GO

ALTER TABLE [TOP_4].[Plan_Historico_Afiliado]  WITH CHECK ADD  CONSTRAINT [FK_Plan_Historico_Afiliado_Plan_medico] FOREIGN KEY([id_plan_medico])
REFERENCES [TOP_4].[Plan_medico] ([id_plan_medico])
GO

ALTER TABLE [TOP_4].[Plan_Historico_Afiliado] CHECK CONSTRAINT [FK_Plan_Historico_Afiliado_Plan_medico]
GO

ALTER TABLE [TOP_4].[Plan_Historico_Afiliado] ADD  CONSTRAINT [DF_Plan_Historico_Afiliado_habilitado]  DEFAULT ((1)) FOR [habilitado]
GO



------------------------------------------------------Tipo_Cancelacion-----------------------------------------------------


GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [TOP_4].[Tipo_Cancelacion](
	[id_tipo_cancelacion] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[nombre_tipo_cancelacion] [varchar](255) NOT NULL,
	[habilitado] [bit] NOT NULL,
 CONSTRAINT [PK_Tipo_Cancelacion] PRIMARY KEY CLUSTERED 
(
	[id_tipo_cancelacion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [TOP_4].[Tipo_Cancelacion] ADD  CONSTRAINT [DF_Tipo_Cancelacion_habilitado]  DEFAULT ((1)) FOR [habilitado]
GO
INSERT INTO TOP_4.Tipo_Cancelacion
(nombre_tipo_cancelacion)
VALUES ('Día no laborable')


INSERT INTO TOP_4.Tipo_Cancelacion
(nombre_tipo_cancelacion)
VALUES ('Sin justificacion')

INSERT INTO TOP_4.Tipo_Cancelacion
(nombre_tipo_cancelacion)
VALUES ('Tramite personal')

INSERT INTO TOP_4.Tipo_Cancelacion
(nombre_tipo_cancelacion)
VALUES ('Fallecimiento')

INSERT INTO TOP_4.Tipo_Cancelacion
(nombre_tipo_cancelacion)
VALUES ('Problemas de salud')

INSERT INTO TOP_4.Tipo_Cancelacion
(nombre_tipo_cancelacion)
VALUES ('Conflicto gremial')

INSERT INTO TOP_4.Tipo_Cancelacion
(nombre_tipo_cancelacion)
VALUES ('Exorcismo')

INSERT INTO TOP_4.Tipo_Cancelacion
(nombre_tipo_cancelacion)
VALUES ('Combustión espontónea')

INSERT INTO TOP_4.Tipo_Cancelacion
(nombre_tipo_cancelacion)
VALUES ('Otro')


-------------------------------------------------------Cancelacion----------------------------------------------------------------

GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [TOP_4].[Cancelacion](
	[id_cancelacion] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[id_tipo_cancelacion] [numeric](18, 0) NOT NULL,
	[id_turno] [numeric](18, 0) NOT NULL,
	[fecha] [datetime] NOT NULL,
	[cancelado_por] [char] NOT NULL,
	[motivo] [varchar](255) NOT NULL,
	[habilitado] [bit] NOT NULL,
 CONSTRAINT [PK_Cancelacion] PRIMARY KEY CLUSTERED 
(
	[id_cancelacion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [TOP_4].[Cancelacion]  WITH CHECK ADD  CONSTRAINT [FK_Cancelacion_Tipo_Cancelacion] FOREIGN KEY([id_tipo_cancelacion])
REFERENCES [TOP_4].[Tipo_Cancelacion] ([id_tipo_cancelacion])
GO

ALTER TABLE [TOP_4].[Cancelacion] CHECK CONSTRAINT [FK_Cancelacion_Tipo_Cancelacion]
GO

ALTER TABLE [TOP_4].[Cancelacion]  WITH CHECK ADD  CONSTRAINT [FK_Cancelacion_Turno] FOREIGN KEY([id_turno])
REFERENCES [TOP_4].[Turno] ([id_turno])
GO

ALTER TABLE [TOP_4].[Cancelacion] CHECK CONSTRAINT [FK_Cancelacion_Turno]
GO

ALTER TABLE [TOP_4].[Cancelacion] ADD  CONSTRAINT [DF_Cancelacion_habilitado]  DEFAULT ((1)) FOR [habilitado]
GO

ALTER TABLE [TOP_4].[Cancelacion] ADD CONSTRAINT [Cancelacion_cancelado_por] CHECK ([cancelado_por] IN ('P','A'))



