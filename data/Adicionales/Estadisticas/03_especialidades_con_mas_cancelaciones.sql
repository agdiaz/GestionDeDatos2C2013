

SELECT TOP 5 es.id_especialidad, es.nombre, COUNT(*) cantCancelaciones
FROM TOP_4.Especialidad es
INNER JOIN TOP_4.Profesional_Especialidad pf
	ON pf.id_especialidad = es.id_especialidad
INNER JOIN TOP_4.Profesional pro
	ON pro.id_profesional = pf.id_profesional
INNER JOIN TOP_4.Turno tur
	ON tur.id_profesional = pro.id_profesional
INNER JOIN TOP_4.Cancelacion can
	ON can.id_turno = tur.id_turno
GROUP BY es.id_especialidad, es.nombre
ORDER BY cantCancelaciones

