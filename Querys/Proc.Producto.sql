-------------------TABLA PRODUCTOS-----------------------

--PROCEDIMIENTO LISTAR--
create procedure ListarProductos as 
begin 
select * from Producto inner Join Proveedor on Producto.id_producto = Proveedor.id_proveedor
end
execute ListarProductos

--PROCEDIMIENTO VISUALIZAR---
create procedure VisualizarProductos as
begin 
select id_producto, prod_nombre, prod_precio, prod_stock, prod_detalle, prod_img from Producto
end
execute VisualizarProductos

--PROCEDIMIENTO OBTENER--
create procedure ObtenerProductos(
@id_producto int) as
begin
select * from Producto where id_producto = @id_producto
end

--PROCEDIMIENTO GUARDAR--
create procedure GuardarProductos(
@nombre nvarchar(60),
@precio decimal(12,2),
@stock decimal(12,2),
@detalle nvarchar(250),
@img nvarchar(250),
@proveedor int

) as
begin
insert into Producto(prod_nombre, prod_precio, prod_stock, prod_detalle, prod_img, prod_proveedor) 
values (@nombre,@precio,@stock,@detalle,@img,@proveedor)
end

--PROCEDIMIENTO EDITAR--
create procedure EditarProductos(
@id_producto int,
@nombre nvarchar(60),
@precio decimal(12,2),
@stock decimal(12,2),
@detalle nvarchar(250),
@img nvarchar(250),
@proveedor int
) as
begin
UPDATE Producto 
set prod_nombre = @nombre,
	prod_precio = @precio, 
	prod_stock = @stock, 
	prod_detalle = @detalle,
	prod_img = @img, 
	prod_proveedor = @proveedor
	
where id_producto = @id_producto
end

--PROCEDIMIENTO ELIMINAR--
create procedure EliminarProductos(
@id_producto int) as
begin
DELETE from Producto where id_producto = @id_producto
end

--EXECUTION--
EXECUTE GuardarProductos @nombre='',@precio=50.25,@stock=50.00,@detalle='',@img='',@proveedor=1

--SELECT--
select * from Producto