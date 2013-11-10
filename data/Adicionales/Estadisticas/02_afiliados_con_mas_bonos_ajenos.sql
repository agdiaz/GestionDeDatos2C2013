
SELECT bonosConsulta.id_afiliado, bonosConsulta.nombre, bonosConsulta.apellido, bonosConsulta.cantBonosAjenosCons + bonosFarmacia.cantBonosAjenosFarm as cantBonosAjenos
FROM
(
	SELECT af.id_afiliado, af.nombre, af.apellido, COUNT(*) as cantBonosAjenosCons
	FROM TOP_4.Afiliado af
	INNER JOIN TOP_4.Turno tu
		ON tu.id_afiliado = af.id_afiliado
	INNER JOIN TOP_4.Bono_Consulta bc
		ON bc.id_turno = tu.id_turno
	INNER JOIN TOP_4.Compra co
		ON bc.id_compra = co.id_compra
	WHERE co.id_afiliado != af.id_afiliado
	GROUP BY af.id_afiliado, af.nombre, af.apellido
) bonosConsulta
INNER JOIN
(
	SELECT af.id_afiliado, af.nombre, af.apellido, COUNT(*) as cantBonosAjenosFarm
	FROM TOP_4.Afiliado af
	INNER JOIN TOP_4.Turno tu
		ON tu.id_afiliado = af.id_afiliado
	INNER JOIN TOP_4.Resultado_Turno rt
		ON rt.id_turno = tu.id_turno
	INNER JOIN TOP_4.Receta re
		ON re.id_resultado_turno = rt.id_resultado_turno
	INNER JOIN TOP_4.Bono_Farmacia bf
		ON bf.id_receta = re.id_receta
	INNER JOIN TOP_4.Compra co
		ON co.id_compra = bf.id_compra
	WHERE co.id_afiliado != af.id_afiliado
	GROUP BY af.id_afiliado, af.nombre, af.apellido
) bonosFarmacia
ON bonosConsulta.id_afiliado = bonosFarmacia.id_afiliado
ORDER BY cantBonosAjenos DESC


--Consulta que hago para probar
--En los datos existentes, no hay usuarios que hayan usado bonos comprados por otros

UPDATE TOP_4.Turno
SET id_afiliado = 6783
WHERE id_turno = 130308

UPDATE TOP_4.Turno
SET id_afiliado = 6783
WHERE id_turno = 130309

UPDATE TOP_4.Turno
SET id_afiliado = 6784
WHERE id_turno = 130310