-------------------TABLA PROMCIONES-----------------------

--PROCEDIMIENTO LISTAR--
create procedure ListarPromociones as 
begin 
select * from Promociones
end
execute ListarPromociones

--PROCEDIMIENTO OBTENER--
create procedure ObtenerPromociones(
@id_promo int) as
begin
select * from Promociones where id_promo = @id_promo
end

--PROCEDIMIENTO GUARDAR--
create procedure GuardarPromociones(
@nombre char(45),
@descuento decimal(10,2)
) as
begin
insert into Promociones(promo_nombre, descuento) 
values (@nombre,@descuento)
end

--PROCEDIMIENTO EDITAR--
create procedure EditarPromociones(
@id_promo int,
@nombre char(45),
@descuento decimal(10,2)
) as
begin
UPDATE Promociones
set promo_nombre = @nombre,
	descuento = @descuento
where id_promo = @id_promo
end

--PROCEDIMIENTO ELIMINAR--
create procedure EliminarPromociones(
@id_promo int) as
begin
DELETE from Promociones where id_promo = @id_promo
end

--EXECUTION--
EXECUTE GuardarPromociones @nombre = 'nombre',@descuento = 'producto'

--SELECT--
select * from Promociones