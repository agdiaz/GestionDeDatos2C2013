USE [GD2C2013]

DROP TABLE TOP_4.Cancelacion
DROP TABLE TOP_4.Tipo_Cancelacion
DROP TABLE TOP_4.Plan_Historico_Afiliado
DROP TABLE TOP_4.Bono_Farmacia
DROP TABLE TOP_4.Bono_Consulta
DROP TABLE TOP_4.Compra
DROP TABLE TOP_4.Item_Receta
DROP TABLE TOP_4.Receta
DROP TABLE TOP_4.Resultado_Turno
DROP TABLE TOP_4.Medicamento
DROP TABLE TOP_4.Turno
DROP TABLE TOP_4.Afiliado
DROP TABLE TOP_4.Rol_Funcionalidad
DROP TABLE TOP_4.Funcionalidad
DROP TABLE TOP_4.Usuario_Rol
DROP TABLE TOP_4.Rol
DROP TABLE TOP_4.Dia_Agenda_Excepcion
DROP TABLE TOP_4.Dia_Agenda
DROP TABLE TOP_4.Agenda
DROP TABLE TOP_4.Profesional_Especialidad
DROP TABLE TOP_4.Especialidad
DROP TABLE TOP_4.Tipo_especialidad
DROP TABLE TOP_4.Profesional
DROP TABLE TOP_4.Usuario
DROP TABLE TOP_4.Plan_medico

-- Borro funciones y sps:

declare @sql varchar(max)

set @sql = (SELECT 'DROP PROCEDURE [' + routine_schema + '].[' + routine_name + ']; '
from information_schema.routines where routine_schema = 'TOP_4' and routine_type IN ('PROCEDURE')
FOR XML PATH (''))
exec(@sql)


set @sql = (SELECT 'DROP FUNCTION [' + routine_schema + '].[' + routine_name + ']; '
from information_schema.routines where routine_schema = 'TOP_4' and routine_type IN ('FUNCTION')
FOR XML PATH (''))
exec(@sql)
