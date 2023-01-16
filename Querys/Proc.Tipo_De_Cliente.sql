-------------------TABLA Tipo_De_Cliente-----------------------

--PROCEDIMIENTO LISTAR--
create procedure ListarTipo_De_Cliente as 
begin 
select * from Tipo_de_cliente
end
execute ListarTipo_De_Cliente

--PROCEDIMIENTO OBTENER--
create procedure ObtenerTipo_De_Cliente(
@id_tipo_cliente int) as
begin
select * from Tipo_de_cliente where id_tipo_cliente = @id_tipo_cliente
end

--PROCEDIMIENTO GUARDAR--
create procedure GuardarTipo_De_Cliente(
@clie_tipo_descripcion varchar(45)
) as
begin
insert into Tipo_de_cliente(clie_tipo_descripcion) 
values (@clie_tipo_descripcion)
end

--PROCEDIMIENTO EDITAR--
create procedure EditarTipo_De_Cliente(
@id_tipo_cliente int,
@clie_tipo_descripcion varchar(45)
) as
begin
UPDATE Tipo_de_cliente 
set clie_tipo_descripcion = @clie_tipo_descripcion
where id_tipo_cliente = @id_tipo_cliente
end

--PROCEDIMIENTO ELIMINAR--
create procedure EliminarTipo_De_Cliente(
@id_tipo_cliente int) as
begin
DELETE from Tipo_de_cliente where id_tipo_cliente = @id_tipo_cliente
end

--EXECUTION--
EXECUTE GuardarTipo_De_Cliente @clie_tipo_descripcion='detalle'

--SELECT--
select * from Tipo_De_Cliente