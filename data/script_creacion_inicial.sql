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
ALTER TABLE [TOP_4].[Plan_medico] ADD  CONSTRAINT [DF_Plan_habilitado]  DEFAULT ((0)) FOR [habilitado]
GO

INSERT INTO [TOP_4].[Plan_medico] (id_plan_medico, descripcion, precio_bono_farmacia, precio_bono_consulta)
	(
		SELECT DISTINCT m.Plan_Med_Codigo, m.Plan_Med_Descripcion, 
			m.Plan_Med_Precio_Bono_Farmacia, m.Plan_Med_Precio_Bono_Consulta
		FROM gd_esquema.Maestra m
	)

GO