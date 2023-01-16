select * from Empleado inner Join Usuario
on Empleado.emple_id_usuario = Usuario.id_usuario
---INSERT----
insert into Rol
values ('Cliente')
insert into Usuario
values ('Guillermo Giannoni', 'guille@gmail.com', '2022', 3)
insert into Orden
values (3,1, '', 3, 1)
insert into Detalle_orden
values (1, 1,500, 80, 1)
insert into Usuario
values ('Michael Jackson', 'OfftheWall@gmail.com', '1979', 3)
insert into Tipo_de_cliente
values ('Empleado')
insert into Producto
values('Robot Aspirador', 10000.00, 20.00, 'Marca: Conga', 'url', 1)
insert into Empleado
values(1, 'Ezequiel', 'Giannoni', null, null)
insert into Promocion_producto
values(1, 1, 1,'', '')
insert into Promociones
values(1,'2x1', 50.00)
insert into Proveedor
values(1, 'Ezequiel', 'Giannoni', null, null)
insert into Categoria
values(1, 'Ezequiel', 'Giannoni', null, null)
insert into categorias_proveedor
values(1, 'Ezequiel', 'Giannoni', null, null)
----LISTAR----
select * from Usuario
select * from Rol
select * from Categoria
select * from categorias_proveedor
select * from Cliente
select * from Detalle_orden
select * from Empleado
select * from Orden
select * from Producto
select * from Promocion_producto
select * from Promociones
select * from Proveedor
select * from Tipo_de_cliente

update Tipo_de_cliente
set clie_tipo_descripcion='Empleado'
where id_tipo_cliente = 1
alter table Usuario
drop column usua_aut;