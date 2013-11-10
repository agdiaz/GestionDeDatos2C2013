


SELECT TOP 5 esp.id_especialidad, esp.nombre, COUNT(*) as cantidad_bonos_farmacia
FROM TOP_4.Especialidad esp
INNER JOIN TOP_4.Profesional_Especialidad pe
	ON pe.id_especialidad = esp.id_especialidad
INNER JOIN TOP_4.Profesional pro
	ON pro.id_profesional = pe.id_profesional
INNER JOIN TOP_4.Turno tu
	ON tu.id_profesional = pro.id_profesional
INNER JOIN TOP_4.Resultado_Turno res
	ON res.id_turno = tu.id_turno
INNER JOIN TOP_4.Receta rec
	ON rec.id_resultado_turno = res.id_resultado_turno
INNER JOIN TOP_4.Bono_Farmacia bf
	ON bf.id_receta = rec.id_receta
GROUP BY esp.id_especialidad, esp.nombre
ORDER BY cantidad_bonos_farmacia