select * from Usuario
select * from Rol
select * from Cliente
select * from Tipo_de_cliente
select * from Empleado inner Join Usuario
on Empleado.emple_id_usuario = Usuario.id_usuario
select * from Detalle_orden
select * from Orden
insert into Rol
values ('Cliente')
insert into Usuario
values ('Lionel Messi', 'goleadormundial@gmail.com', '18122022', 2)
insert into Orden
values (3,1, '', 3, 1)
insert into Detalle_orden
values (1, 1,500, 80, 1)
insert into Usuario
values ('Michael Jackson', 'OfftheWall@gmail.com', '1979', 3)
insert into Tipo_de_cliente
values ('Empleado')
insert into Cliente
values('Eze', '39281233', '20-Domotica', 'Giannoni', 'DomoRobot', 1, 1)
insert into Empleado
values(1, 'Ezequiel', 'Giannoni', null, null)
update Rol
set rol_detalle='Vendedor'
where id_Rol = 3
alter table Usuario
drop column usua_aut;

create procedure AutenticarUsuarios
@usua_correo nvarchar(45),
@usua_pass nvarchar(45)
as
begin
	declare @status int
	if exists(select * from Usuario where usua_correo=@usua_correo AND usua_pass = @usua_pass)
	set @status = 1
	else
	set @status = 0
	select @status
end