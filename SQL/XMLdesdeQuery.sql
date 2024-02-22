DECLARE @tmpTipos AS TABLE (
	idT int,
	nombre varchar(100)
)

insert into @tmpTipos values (1, 'Lata')
insert into @tmpTipos values (2, 'botellas')

DECLARE @tmpItems AS TABLE (
	idI int,
	nombre varchar(100),
	idTipos int
)

insert into @tmpItems values (1, 'lata azul', 1)
insert into @tmpItems values (2, 'lata verde', 1)
insert into @tmpItems values (3, 'lata naranja', 1)
insert into @tmpItems values (4, 'botella chica', 2)


SELECT *
FROM @tmpTipos

SELECT *
FROM @tmpItems

SELECT tipo.nombre,
	(SELECT item.nombre
	FROM @tmpItems item
	WHERE item.idTipos = tipo.IdT
	FOR XML PATH)
FROM @tmpTipos tipo
FOR XML PATH