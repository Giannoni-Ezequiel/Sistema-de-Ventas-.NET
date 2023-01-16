-------------------TABLA categorias_proveedor-----------------------

--PROCEDIMIENTO LISTAR--
create procedure ListarCategorias_Proveedor as 
begin 
select * from categorias_proveedor
end
execute ListarCategorias_Proveedor

--PROCEDIMIENTO OBTENER--
create procedure ObtenerCategorias_Proveedor(
@ int) as
begin
select * from categorias_proveedor where  = @
end

--PROCEDIMIENTO GUARDAR--
create procedure GuardarCategorias_Proveedor(
@id_proveedor int,
@id_categoria int
) as
begin
INSERT INTO categorias_proveedor (id_proveedor, id_categoria)
VALUES (@id_proveedor, @id_categoria)
end

--PROCEDIMIENTO EDITAR--
create procedure EditarCategorias_Proveedor(
@id_proveedor int,
@id_categoria int
) as
begin
UPDATE categorias_proveedor 
set  = @
where  = @
end

--PROCEDIMIENTO ELIMINAR--
create procedure EliminarCategorias_Proveedor(
@ int) as
begin
DELETE from categorias_proveedor where  = @
end

--EXECUTION--
EXECUTE GuardarCategorias_Proveedor @id_proveedor= , @id_categoria = 

--SELECT--
select * from categorias_proveedor