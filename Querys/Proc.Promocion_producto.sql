-------------------TABLA Promocion_producto-----------------------

--PROCEDIMIENTO LISTAR--
create procedure ListarPromocion_producto as 
begin 
select * from Promocion_producto
end
execute ListarPromocion_producto

--PROCEDIMIENTO OBTENER--
create procedure ObtenerPromocion_producto(
@promo_numero int) as
begin
select * from Promocion_producto where promo_numero = @promo_numero
end

--PROCEDIMIENTO GUARDAR--
create procedure GuardarPromocion_producto(
@promo_fecha_inicio datetime,
@promo_fecha_fin datetime
) as
begin
insert into Promocion_producto(promo_fecha_inicio, promo_fecha_fin ) 
values (@promo_fecha_inicio,@promo_fecha_fin)
end

--PROCEDIMIENTO EDITAR--
create procedure EditarPromocion_producto(
@id_promo int,
@id_producto int,
@promo_numero int,
@promo_fecha_inicio datetime,
@promo_fecha_fin datetime
) as
begin
UPDATE Promocion_producto 
set id_promo = @id_promo,
	id_producto = @id_producto,
	promo_fecha_inicio = @promo_fecha_inicio,
	promo_fecha_fin = @promo_fecha_fin
where promo_numero = @promo_numero
end

--PROCEDIMIENTO ELIMINAR--
create procedure EliminarPromocion_producto(
@promo_numero int) as
begin
DELETE from Promocion_producto where promo_numero = @promo_numero
end

--EXECUTION--
EXECUTE GuardarPromocion_producto @promo_fecha_inicio='',@promo_fecha_fin=''

--SELECT--
select * from Promocion_producto