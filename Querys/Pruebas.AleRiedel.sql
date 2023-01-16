INSERT INTO Categoria (categ_detalle) VALUES('TestCategoria');
INSERT INTO Categoria (categ_detalle) VALUES('TestCategoria1');
SELECT * FROM Categoria

INSERT INTO Proveedor (provee_nombre, provee_apellido, provee_direccion, provee_cuit) 
VALUES('Nombre', 'Apellido', 'Dirección', '12345678');
INSERT INTO Proveedor (provee_nombre, provee_apellido, provee_direccion, provee_cuit) 
VALUES('Nombre1', 'Apellido1', 'Dirección1', '87654321');
SELECT * FROM Proveedor

INSERT INTO categorias_proveedor (id_proveedor, id_categoria)
VALUES (
(select p.id_proveedor from Proveedor p where p.provee_cuit = '12345678'), /*id_proveedor*/
(select c.id_categoria from Categoria c where c.categ_detalle = 'TestCategoria1')  /*id_categoria*/
);
SELECT * FROM categorias_proveedor 

drop table Detalle_orden;
CREATE TABLE Detalle_orden (
    id_orden            int               NOT NULL,
    id_detalle_orden    int               IDENTITY(1,1),
    det_ord_precio      decimal(12, 2)    NOT NULL,
    det_ord_cantidad    decimal(12, 2)    NOT NULL,
    id_producto         int               NOT NULL,
    CONSTRAINT PK9 PRIMARY KEY NONCLUSTERED (id_orden, id_producto)
);