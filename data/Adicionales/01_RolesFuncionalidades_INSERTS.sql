-- Creo los roles por defecto --
GO

INSERT INTO [TOP_4].[Rol] ([nombre],[habilitado]) VALUES ('Afiliado', 1)
INSERT INTO [TOP_4].[Rol] ([nombre],[habilitado]) VALUES ('Administrativo', 1)
INSERT INTO [TOP_4].[Rol] ([nombre],[habilitado]) VALUES ('Profesional', 1)

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

--- Creo los usuarios administradores
GO
INSERT INTO [TOP_4].[Usuario] ([username],[password],[habilitado]) VALUES ('admin1', '0xE6B87050BFCB8143FCB8DB0170A4DC9ED00D904DDD3E2A4AD1B1E8DC0FDC9BE7',1)
INSERT INTO [TOP_4].[Usuario_Rol] ([id_usuario],[id_rol]) VALUES (@@IDENTITY , 2)

INSERT INTO [TOP_4].[Usuario] ([username],[password],[habilitado]) VALUES ('admin2', '0xE6B87050BFCB8143FCB8DB0170A4DC9ED00D904DDD3E2A4AD1B1E8DC0FDC9BE7',1)
INSERT INTO [TOP_4].[Usuario_Rol] ([id_usuario],[id_rol]) VALUES (@@IDENTITY , 2)

INSERT INTO [TOP_4].[Usuario] ([username],[password],[habilitado]) VALUES ('admin3', '0xE6B87050BFCB8143FCB8DB0170A4DC9ED00D904DDD3E2A4AD1B1E8DC0FDC9BE7',1)
INSERT INTO [TOP_4].[Usuario_Rol] ([id_usuario],[id_rol]) VALUES (@@IDENTITY , 2)

INSERT INTO [TOP_4].[Usuario] ([username],[password],[habilitado]) VALUES ('admin4', '0xE6B87050BFCB8143FCB8DB0170A4DC9ED00D904DDD3E2A4AD1B1E8DC0FDC9BE7',1)
INSERT INTO [TOP_4].[Usuario_Rol] ([id_usuario],[id_rol]) VALUES (@@IDENTITY , 2)

INSERT INTO [TOP_4].[Usuario] ([username],[password],[habilitado]) VALUES ('admin5', '0xE6B87050BFCB8143FCB8DB0170A4DC9ED00D904DDD3E2A4AD1B1E8DC0FDC9BE7',1)
INSERT INTO [TOP_4].[Usuario_Rol] ([id_usuario],[id_rol]) VALUES (@@IDENTITY , 2)

GO




