-------------------TABLA ROL-----------------------

--PROCEDIMIENTO LISTAR--
create procedure ListarRol as 
begin 
select * from Rol
end
execute ListarRol

--PROCEDIMIENTO OBTENER--
create procedure ObtenerRol(
@id_Rol int) as
begin
select * from Rol where id_Rol = @id_Rol
end

--PROCEDIMIENTO GUARDAR--
create procedure GuardarRol(
@rol_detalle char(45)
) as
begin
insert into Rol(rol_detalle) 
values (@rol_detalle)
end

--PROCEDIMIENTO EDITAR--
create procedure EditarRol(
@id_Rol int,
@rol_detalle char(45)
) as
begin
UPDATE Rol 
set rol_detalle = @rol_detalle
where id_Rol = @id_Rol
end

--PROCEDIMIENTO ELIMINAR--
create procedure ELiminarRol(
@id_Rol int) as
begin
DELETE from Rol where id_Rol = @id_Rol
end

--EXECUTION--
EXECUTE GuardarRol(@'detalle')

--SELECT--
select * from Rol