-------------------TABLA EMPLEADOS-----------------------

--PROCEDIMIENTO LISTAR--
create procedure ListarEmpleado as 
begin 
select * from Empleado
end
execute ListarEmpleado

create procedure EmpleadoListar as 
begin 
select * from Empleado inner Join Usuario on Empleado.emple_id_usuario = Usuario.id_usuario
end
execute EmpleadoListar

--PROCEDIMIENTO OBTENER--
create procedure ObtenerEmpleado(@id_empleado int) as
begin
select * from Empleado where id_empleado = @id_empleado
end

--PROCEDIMIENTO GUARDAR--
create procedure GuardarEmpleados(
@nombre nvarchar(45),
@apellido nvarchar(45),
@id_supervisor int,
@id_usuario int
) as
begin
insert into Empleado(emple_nombre, emple_apellido, emple_id_supervisor, emple_id_usuario) 
values (@nombre,@apellido,@id_supervisor,@id_usuario)
end

--PROCEDIMIENTO EDITAR--
create procedure EditarEmpleado(
@id_empleado int,
@nombre nvarchar(45),
@apellido nvarchar(45),
@id_supervisor int,
@id_usuario int
) as
begin
UPDATE Empleado 
set 
	emple_nombre = @nombre,
	emple_apellido = @apellido,
	emple_id_supervisor = @id_supervisor,
	emple_id_usuario = @id_usuario
where id_empleado = @id_empleado
end

--PROCEDIMIENTO ELIMINAR--
create procedure EliminarEmpleado(
@id_empleado int) as
begin
DELETE from Empleado where id_empleado = @id_empleado
end

--EXECUTION--
EXECUTE GuardarEmpleado @nombre = 'Lionel', @apellido = 'Messi', @id_supervisor = '',@id_usuario = '' 

--SELECT--
select * from Empleado
select * from Usuario