--USE [Totalpack]
--GO
--/****** Object:  StoredProcedure [dbo].[spttp_BuscarAuditoriaKioscos]    Script Date: 03/28/2014 14:03:54 ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO
--------------------------------------------------------------------------------------------------------
---- Procedimiento  : spttp_BuscarAuditoriaKioscos
---- Descripcion    : retorna xml con los rut de los alumnos que han ocupado los servicios del totem                         
---- Parametros     : 1) @fechaInicio	: filtro fecha inicio
----					2) @fechaFin	: filtro fecha fin
----                  
---- Retorno        : 1)
----                  
---- Bitacora	      : 12/03/2014 Cristian Muñoz: Creacion SP spttp_BuscarAuditoriaKioscos
--------------------------------------------------------------------------------------------------------
--ALTER PROCEDURE [dbo].[spttp_BuscarAuditoriaKioscos] 

declare 

@fechaInicio datetime ,
@fechaFin datetime                                          
--AS

set @fechaInicio = GETDATE()-6;
set @fechaFin = GETDATE()

SELECT '',
 (SELECT top 10
    AUD_CONSULTA_SERVICIOS.Rut as "@Rut",
	CONVERT(VARCHAR,AUD_CONSULTA_SERVICIOS.Fecha,103) as "@Fecha",
	ttp_Servicios.Servicio as "@Servicios"
 FROM  
	AUD_CONSULTA_SERVICIOS
		INNER JOIN
	ttp_Servicios WITH(NOLOCK)
ON
	AUD_CONSULTA_SERVICIOS.IdServicio = ttp_Servicios.IdServicio
WHERE
	CONVERT(VARCHAR,AUD_CONSULTA_SERVICIOS.Fecha,103) BETWEEN CONVERT(VARCHAR,@fechaInicio,103) AND CONVERT(VARCHAR,@fechaFin,103)
  FOR XML PATH('Auditoria'), TYPE) 
FOR XML PATH('ListadoAuditorias')



DECLARE @TmpTabla AS TABLE ( NUMERO INT, TEXTO VARCHAR(100) )

INSERT INTO @TmpTabla VALUES (1,'UNO'),(2,'DOS'),(3,'TRES'),(4,'CUATRO'),(5,'CINCO')

SELECT
	NUMERO,
	TEXTO
FROM @TmpTabla
FOR XML PATH('NombreTAG')

SELECT
(
	SELECT
		NUMERO AS "@Numero",
		TEXTO AS "@Texto"
	FROM @TmpTabla
	FOR XML PATH('NombreTAG'), TYPE
)
FOR XML PATH('SeccionTAG')