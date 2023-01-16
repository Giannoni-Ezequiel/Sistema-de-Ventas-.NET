-------------------TABLA DETALLE ORDEN-----------------------

--PROCEDIMIENTO LISTAR--
create procedure ListarDetalle_orden as 
begin 
select * from Detalle_orden inner Join Producto on Detalle_orden.id_producto = Producto.id_producto
end
execute ListarDetalle_orden

--PROCEDIMIENTO OBTENER--
create procedure ObtenerDetalle_orden(
@id_detalle_orden int) as
begin
select * from Detalle_orden where id_detalle_orden = @id_detalle_orden
end

--PROCEDIMIENTO GUARDAR--
create procedure GuardarDetalle_orden(
@id_orden int,
@det_ord_precio decimal(12,2),
@det_ord_cantidad decimal(12,2),
@id_producto int
) as
begin
insert into Detalle_orden(id_orden, det_ord_precio, det_ord_cantidad, id_producto) 
values (@id_orden,@det_ord_precio,@det_ord_cantidad,@id_producto )
end

--PROCEDIMIENTO EDITAR--
create procedure EditarDetalle_orden(
@id_orden int,
@id_detalle_orden int,
@det_ord_precio decimal(12,2),
@det_ord_cantidad decimal(12,2),
@id_producto int
) as
begin
UPDATE Detalle_orden 
set det_ord_precio = @det_ord_precio,
	det_ord_cantidad = @det_ord_cantidad,
	id_producto = @id_producto
where id_detalle_orden = @id_detalle_orden
end

--PROCEDIMIENTO ELIMINAR--
create procedure EliminarDetalle_orden(
@id_detalle_orden int) as
begin
DELETE from Detalle_orden where id_detalle_orden = @id_detalle_orden
end

--EXECUTION--
EXECUTE GuardarDetalle_orden @det_ord_precio = '500.00', @det_ord_cantidad = '50', @id_producto = 1

--SELECT--
select * from Detalle_orden