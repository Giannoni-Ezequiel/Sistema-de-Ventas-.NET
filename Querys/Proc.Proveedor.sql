-------------------TABLA PROVEEDORES-----------------------

--PROCEDIMIENTO LISTAR--
create procedure ListarProveedor as 
begin 
select * from Proveedor
end
execute ListarProveedor

--PROCEDIMIENTO OBTENER--
create procedure ObtenerProveedor(
@id_proveedor int) as
begin
select * from Proveedor where id_proveedor = @id_proveedor
end

--PROCEDIMIENTO GUARDAR--
create procedure GuardarProveedor(
@nombre nvarchar(45),
@apellido nvarchar(45),
@direccion nvarchar(100),
@cuit nvarchar(11)
) as
begin
insert into Proveedor(provee_nombre, provee_apellido, provee_direccion, provee_cuit) 
values (@nombre,@apellido,@direccion,@cuit)
end

--PROCEDIMIENTO EDITAR--
create procedure EditarProveedor(
@id_proveedor int,
@nombre nvarchar(45),
@apellido nvarchar(45),
@direccion nvarchar(100),
@cuit nvarchar(11)
) as
begin
UPDATE Proveedor 
set provee_nombre = @nombre,
	provee_apellido = @apellido, 
	provee_direccion = @direccion, 
	provee_cuit = @cuit
where id_proveedor = @id_proveedor
end

--PROCEDIMIENTO ELIMINAR--
create procedure EliminarProveedor(
@id_proveedor int) as
begin
DELETE from Proveedor where id_proveedor = @id_proveedor
end

--EXECUTION--
EXECUTE GuardarProveedor @nombre='nombre',@apellido='apellido',@direccion='direccion',@cuit='cuit'

--SELECT--
select * from Proveedor