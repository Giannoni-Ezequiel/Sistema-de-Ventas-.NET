-------------------TABLA CATEGORIA-----------------------

--PROCEDIMIENTO LISTAR--
create procedure ListarCategoria as 
begin 
select * from Categoria
end
execute ListarCategoria

--PROCEDIMIENTO OBTENER--
create procedure ObtenerCategoria(
@id_categoria int) as
begin
select * from Categoria where id_categoria = @id_categoria
end

--PROCEDIMIENTO GUARDAR--
create procedure GuardarCategoria(
@categ_detalle char(45)
) as
begin
insert into Categoria(categ_detalle) 
values (@categ_detalle)
end

--PROCEDIMIENTO EDITAR--
create procedure EditarCategoria(
@id_categoria int,
@categ_detalle nvarchar(45)
) as
begin
UPDATE Categoria 
set categ_detalle = @categ_detalle
where id_categoria = @id_categoria
end

--PROCEDIMIENTO ELIMINAR--
create procedure ELiminarCategoria(
@id_categoria int) as
begin
DELETE from Categoria where id_categoria = @id_categoria
end

--EXECUTION--
EXECUTE GuardarCategoria(@'detalle')

--SELECT--
select * from Categoria