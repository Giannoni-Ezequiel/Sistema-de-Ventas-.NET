-------------------TABLA ORDENES DE COMPRA-----------------------

--PROCEDIMIENTO LISTAR--
create procedure ListarOrden as 
begin 
select * from Orden inner join Cliente on Orden.ord_id_cliente = Cliente.id_cliente
select * from Orden inner join Empleado on Orden.ord_id_empleado = Empleado.id_empleado
end
execute ListarOrden

--PROCEDIMIENTO OBTENER--
create procedure ObtenerOrden(@id_orden int) as
begin
select * from Orden where id_orden = @id_orden
end

--PROCEDIMIENTO GUARDAR--
create procedure GuardarOrden(
@cliente int,
@vendedor nvarchar(45),
@fecha_de_generacion nvarchar(45),
@id_cliente int,
@id_empleado int
) as
begin
insert into Orden(ord_cliente, ord_vendedor, ord_fecha_de_generacion, ord_id_cliente, ord_id_empleado) 
values (@cliente,@vendedor,@fecha_de_generacion,@id_cliente,@id_empleado)
end

--PROCEDIMIENTO EDITAR--
create procedure EditarOrden(
@id_orden int,
@cliente int,
@vendedor nvarchar(45),
@fecha_de_generacion nvarchar(45),
@id_cliente int,
@id_empleado int
) as
begin
UPDATE Orden 
set ord_cliente = @cliente,
	ord_vendedor = @vendedor,
	ord_fecha_de_generacion = @fecha_de_generacion,
	ord_id_cliente = @id_cliente,
	ord_id_empleado = @id_empleado
where id_orden = @id_orden
end

--PROCEDIMIENTO ELIMINAR--
create procedure EliminarOrden(
@id_orden int) as
begin
DELETE from Orden where id_orden = @id_orden
end

--EXECUTION--
EXECUTE GuardarOrden @cliente = 'cliente',@vendedor = 'vendedor',@fecha_de_generacion ='fecha_de_generacion',@id_cliente ='id_cliente',@id_empleado ='id_empleado'

--SELECT--
select * from Orden