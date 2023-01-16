create proc UsuarioListar 
as
begin
select * from Usuario inner join Rol on Usuario.id_Rol = Rol.id_Rol
end

execute UsuarioListar
select * from Rol


