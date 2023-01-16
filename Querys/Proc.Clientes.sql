-------------------TABLA CLIENTES-----------------------

--PROCEDIMIENTO LISTAR--
create procedure ListarClientes as 
begin 
select * from Cliente
end
execute ListarClientes

--PROCEDIMIENTO OBTENER--
create procedure ObtenerClientes(
@id_cliente int) as
begin
select * from Cliente where id_cliente = @id_cliente
end

--PROCEDIMIENTO GUARDAR--
create procedure GuardarClientes(
@nombre nvarchar(45),
@dni nvarchar(8),
@cuit nvarchar(11),
@apellido nvarchar(45),
@razon_social nvarchar(45),
@tipo int,
@id_usuario int
) as
begin
insert into Cliente(clie_nombre,clie_dni,clie_cuit,clie_apellido,clie_razon_social,clie_tipo,clie_id_usuario) 
values (@nombre,@dni,@cuit,@apellido,@razon_social,@tipo,@id_usuario)
end

--PROCEDIMIENTO EDITAR--
create procedure EditarClientes(
@id_cliente int,
@nombre nvarchar(45),
@dni nvarchar(8),
@cuit nvarchar(11),
@apellido nvarchar(45),
@razon_social nvarchar(45),
@tipo int,
@id_usuario int
) as
begin
UPDATE Cliente 
set clie_nombre = @nombre,
	clie_dni = @dni, 
	clie_cuit = @cuit,
	clie_apellido = @apellido,
	clie_razon_social = @razon_social,
	clie_tipo = @tipo,
	clie_id_usuario = @id_usuario
where id_cliente = @id_cliente
end

--PROCEDIMIENTO ELIMINAR--
create procedure ELiminarClientes(
@id_cliente int) as
begin
DELETE from Cliente where id_cliente = @id_cliente
end

--EXECUTION--
EXECUTE EditarClientes @id_cliente = '3',@nombre = 'Ezequiel', @dni = '39281233', @cuit = '20-Domotica',@apellido ='Giannoni', @razon_social = 'DomoRobot',@tipo = '1',@id_usuario ='1'

--SELECT--
select * from Cliente