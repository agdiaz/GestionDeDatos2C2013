SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [TOP4].[Password](
	[id] [varchar](50) NOT NULL,
	[password] [varbinary](32) NOT NULL,
	[descripcion] [varchar](50) NOT NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

-- Password administradores: 'w23c'
insert into [TOP_4].[Password] values ('ADMIN', CONVERT(varbinary(32),'0xE6B87050BFCB8143FCB8DB0170A4DC9ED00D904DDD3E2A4AD1B1E8DC0FDC9BE7', 1), 'w23c')

-- password: 'afiliado'
insert into [TOP_4].[Password] values ('AFILIADO', CONVERT(varbinary(32),'0x1AEAEBA4BDBF8907638434B60504B1037C01905BEC294FB2CD5348724F2FA64F', 1), 'afiliado')

-- password: 'profesional'
insert into [TOP_4].[Password] values ('PROFESIONAL', CONVERT(varbinary(32),'0x24AFE47D0BD302AE42643C5848D99B683264026CD12CC998E05E100BBF2DC30D', 1), 'profesional')