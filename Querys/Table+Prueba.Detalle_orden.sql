drop table Detalle_orden;
CREATE TABLE Detalle_orden (
    id_orden            int               NOT NULL,
    id_detalle_orden    int               IDENTITY(1,1),
    det_ord_precio      decimal(12, 2)    NOT NULL,
    det_ord_cantidad    decimal(12, 2)    NOT NULL,
    id_producto         int               NOT NULL,
    CONSTRAINT PK9 PRIMARY KEY NONCLUSTERED (id_detalle_orden)
);
ALTER TABLE Detalle_orden ADD CONSTRAINT RefOrden7
    FOREIGN KEY (id_orden)
    REFERENCES Orden(id_orden);
ALTER TABLE Detalle_orden ADD CONSTRAINT RefProducto8
    FOREIGN KEY (id_producto)
    REFERENCES Producto(id_producto);

	INSERT INTO Detalle_orden (id_orden, det_ord_precio, det_ord_cantidad, id_producto) VALUES (2, 0, 0, 1);
	select * from Detalle_orden