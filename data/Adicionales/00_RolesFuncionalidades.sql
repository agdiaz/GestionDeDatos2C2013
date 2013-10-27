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
---------------------------------Funcionalidad---------------------------------------
CREATE TABLE [TOP_4].[Funcionalidad](
	[id_funcionalidad] [numeric](18, 0) NOT NULL,
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

---------------------------------FK: Rol_Funcionalidad + Funcionalidad---------------------------------------
ALTER TABLE [TOP_4].[Rol_Funcionalidad]  WITH CHECK ADD  CONSTRAINT [FK_Rol_Funcionalidad_Funcionalidad] FOREIGN KEY([id_funcionalidad])
REFERENCES [TOP_4].[Funcionalidad] ([id_funcionalidad])
GO
ALTER TABLE [TOP_4].[Rol_Funcionalidad] CHECK CONSTRAINT [FK_Rol_Funcionalidad_Funcionalidad]
GO
---------------------------------FK: Rol_Funcionalidad + Rol---------------------------------------
ALTER TABLE [TOP_4].[Rol_Funcionalidad]  WITH CHECK ADD  CONSTRAINT [FK_Rol_Funcionalidad_Rol] FOREIGN KEY([id_rol])
REFERENCES [TOP_4].[Rol] ([id_rol])
GO
ALTER TABLE [TOP_4].[Rol_Funcionalidad] CHECK CONSTRAINT [FK_Rol_Funcionalidad_Rol]
GO

---------------------------------FK: Usuario_Rol + Rol---------------------------------------
ALTER TABLE [TOP_4].[Usuario_Rol]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Rol_Rol] FOREIGN KEY([id_rol])
REFERENCES [TOP_4].[Rol] ([id_rol])
GO
ALTER TABLE [TOP_4].[Usuario_Rol] CHECK CONSTRAINT [FK_Usuario_Rol_Rol]
GO
---------------------------------FK: Usuario_Rol + Usuario---------------------------------------
ALTER TABLE [TOP_4].[Usuario_Rol]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Rol_Usuario] FOREIGN KEY([id_usuario])
REFERENCES [TOP_4].[Usuario] ([id_usuario])
GO
ALTER TABLE [TOP_4].[Usuario_Rol] CHECK CONSTRAINT [FK_Usuario_Rol_Usuario]
GO
