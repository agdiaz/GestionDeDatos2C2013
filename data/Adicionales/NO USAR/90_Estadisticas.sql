GO
CREATE PROCEDURE [TOP_4].[sp_topcancelacionesprofesionales]
	(
	@p_desde datetime,
	@p_fin datetime
	)
AS
BEGIN
--SELECT 'ads' as especialidad,1 as cantidad_cancelaciones
	SELECT TOP 5 es.nombre as especialidad, COUNT(*) cantidad_cancelaciones
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
	ORDER BY cantidad_cancelaciones DESC
END
GO
GO
CREATE PROCEDURE [TOP_4].[sp_topbonosfarmaciavencidosporafiliado]
	(
	@p_desde datetime,
	@p_fin datetime
	)
AS
BEGIN
--SELECT 5 as id_afiliado,100 as bonos_vencidos
	SELECT TOP 5 af.nombre as nombre, af.apellido as apellido, COUNT(*) as bonos_vencidos
	FROM TOP_4.Afiliado af
	INNER JOIN TOP_4.Compra co
		ON co.id_afiliado = af.id_afiliado
	INNER JOIN TOP_4.Bono_Farmacia bf
		ON bf.id_compra = co.id_compra
	WHERE bf.fecha_vencimiento BETWEEN @p_desde AND @p_fin
	AND bf.id_bono_farmacia NOT IN
	(
		SELECT bf.id_bono_farmacia
		FROM TOP_4.Turno tu2
		INNER JOIN TOP_4.Resultado_Turno rt2
			ON tu2.id_turno = rt2.id_turno
		INNER JOIN TOP_4.Receta re2
			ON rt2.id_resultado_turno = re2.id_resultado_turno
		INNER JOIN TOP_4.Bono_Farmacia bf2
			ON bf2.id_receta = re2.id_receta
		WHERE tu2.id_afiliado = af.id_afiliado
	)
	GROUP BY nombre, apellido
	ORDER BY bonos_vencidos DESC
END
GO

CREATE PROCEDURE [TOP_4].[sp_topafiliadosconbonossincomprarporellos]
	(
	@p_desde datetime,
	@p_fin datetime
	)
AS
BEGIN
--SELECT 2 as id_afiliado,200 as bonos_utilizados
SELECT TOP 10 bonosConsulta.nombre as nombre, bonosConsulta.apellido as apellido, 
	(bonosConsulta.cantBonosAjenosCons + bonosFarmacia.cantBonosAjenosFarm) as bonos_utilizados
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
	AND tu.fecha_turno BETWEEN @p_desde AND @p_fin
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
	AND tu.fecha_turno BETWEEN @p_desde AND @p_fin
	GROUP BY af.id_afiliado, af.nombre, af.apellido
) bonosFarmacia
ON bonosConsulta.id_afiliado = bonosFarmacia.id_afiliado
ORDER BY bonos_utilizados DESC

END




GO

CREATE PROCEDURE [TOP_4].[sp_topespecialidadesbonosfarmaciarecetados]
	(
	@p_desde datetime,
	@p_fin datetime
	)
AS
BEGIN
	SELECT TOP 5 esp.nombre as especialidad, COUNT(*) as bonos_farmacia_recetados
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
	WHERE bf.fecha_impresion BETWEEN @p_desde AND @p_fin
	GROUP BY esp.id_especialidad, esp.nombre
	ORDER BY bonos_farmacia_recetados DESC
END

GO