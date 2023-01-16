-------------------TABLA USUARIOS-----------------------

--PROCEDIMIENTO LISTAR--
create procedure ListarUsuario as 
begin 
select * from Usuario
end
execute ListarUsuario

--PROCEDIMIENTO OBTENER--
create procedure ObtenerUsuario(
@id_usuario int) as
begin
select * from Usuario where id_usuario = @id_usuario
end

--PROCEDIMIENTO GUARDAR--
create procedure GuardarUsuario(
@nombre nvarchar(45),
@correo nvarchar(45),
@pass nvarchar(45),
@id_Rol int
) as
begin
insert into Usuario(usua_nombre, usua_correo, usua_pass, id_Rol) 
values (@nombre,@correo,@pass,@id_Rol)
end

--PROCEDIMIENTO EDITAR--
create procedure EditarUsuario(
@id_usuario int,
@nombre nvarchar(45),
@correo nvarchar(45),
@pass nvarchar(45),
@id_Rol int
) as
begin
UPDATE Usuario 
set usua_nombre = @nombre,
	usua_correo = @correo, 
	usua_pass = @pass,
	id_Rol = @id_Rol
	
where id_usuario = @id_usuario
end

--PROCEDIMIENTO ELIMINAR--
create procedure EliminarUsuario(
@id_usuario int) as
begin
DELETE from Usuario where id_usuario = @id_usuario
end

--EXECUTION--
EXECUTE GuardarUsuario @nombre = 'Gabriel', @correo = 'g@gmail.com', @pass = '123', @id_rol = '1'

--SELECT--
select * from Usuario