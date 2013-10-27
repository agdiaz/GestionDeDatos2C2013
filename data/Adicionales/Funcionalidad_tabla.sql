---------------------------------Funcionalidad---------------------------------------
CREATE TABLE [TOP_4].[Funcionalidad](
	[id_funcionalidad] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](255) NOT NULL,
	[descripcion] [varchar] NOT NULL,
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
INSERT INTO [TOP_4].[Funcionalidad] ([nombre], [descripcion], [habilitado]) VALUES ('tsmAgenda_Registrar' ,1, 'Registrar agenda') --25

GO
