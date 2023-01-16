/*
 * ER/Studio 8.0 SQL Code Generation
 * Company :      gyl
 * Project :      ProyectoFinalDer.DM1
 * Author :       karinasolmeza83@gmail.com
 *
 * Date Created : Thursday, December 01, 2022 11:05:18
 * Target DBMS : Microsoft SQL Server 2008
 */

/* 
 * TABLE: Categoria 
 */

CREATE TABLE Categoria(
    id_categoria     int            IDENTITY(1,1),
    categ_detalle    varchar(50)    NULL,
    CONSTRAINT PK6 PRIMARY KEY NONCLUSTERED (id_categoria)
)
go



IF OBJECT_ID('Categoria') IS NOT NULL
    PRINT '<<< CREATED TABLE Categoria >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE Categoria >>>'
go

/* 
 * TABLE: categorias_proveedor 
 */

CREATE TABLE categorias_proveedor(
    id_proveedor    int    NOT NULL,
    id_categoria    int    NOT NULL,
    CONSTRAINT PK13 PRIMARY KEY NONCLUSTERED (id_proveedor, id_categoria)
)
go



IF OBJECT_ID('categorias_proveedor') IS NOT NULL
    PRINT '<<< CREATED TABLE categorias_proveedor >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE categorias_proveedor >>>'
go

/* 
 * TABLE: Cliente 
 */

CREATE TABLE Cliente(
    id_cliente           int            IDENTITY(1,1),
    clie_nombre          varchar(45)    NOT NULL,
    clie_dni             varchar(8)     NOT NULL,
    clie_cuit            varchar(11)    NOT NULL,
    clie_apellido        varchar(45)    NOT NULL,
    clie_razon_social    varchar(45)    NOT NULL,
    clie_tipo            int            NULL,
    clie_id_usuario      int            NULL,
    CONSTRAINT PK1 PRIMARY KEY NONCLUSTERED (id_cliente)
)
go



IF OBJECT_ID('Cliente') IS NOT NULL
    PRINT '<<< CREATED TABLE Cliente >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE Cliente >>>'
go

/* 
 * TABLE: Detalle_orden 
 */

CREATE TABLE Detalle_orden(
    id_orden            int               NOT NULL,
    id_detalle_orden    int               IDENTITY(1,1),
    det_ord_precio      decimal(12, 2)    NOT NULL,
    det_ord_cantidad    decimal(12, 2)    NOT NULL,
    id_producto         int               NOT NULL,
    CONSTRAINT PK9 PRIMARY KEY NONCLUSTERED (id_orden, id_detalle_orden)
)
go



IF OBJECT_ID('Detalle_orden') IS NOT NULL
    PRINT '<<< CREATED TABLE Detalle_orden >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE Detalle_orden >>>'
go

/* 
 * TABLE: Empleado 
 */

CREATE TABLE Empleado(
    id_empleado            int            NOT NULL,
    emple_nombre           varchar(45)    NOT NULL,
    emple_apellido         varchar(45)    NOT NULL,
    emple_id_supervisor    int            NULL,
    emple_id_usuario       int            NULL,
    CONSTRAINT PK4 PRIMARY KEY NONCLUSTERED (id_empleado)
)
go



IF OBJECT_ID('Empleado') IS NOT NULL
    PRINT '<<< CREATED TABLE Empleado >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE Empleado >>>'
go

/* 
 * TABLE: Orden 
 */

CREATE TABLE Orden(
    id_orden                   int         IDENTITY(1,1),
    ord_cliente                int         NULL,
    ord_vendedor               int         NULL,
    ord_fecha_de_generacion    datetime    NULL,
    ord_id_cliente             int         NULL,
    ord_id_empleado            int         NULL,
    CONSTRAINT PK8 PRIMARY KEY NONCLUSTERED (id_orden)
)
go



IF OBJECT_ID('Orden') IS NOT NULL
    PRINT '<<< CREATED TABLE Orden >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE Orden >>>'
go

/* 
 * TABLE: Producto 
 */

CREATE TABLE Producto(
    id_producto       int               IDENTITY(1,1),
    prod_nombre       varchar(60)       NOT NULL,
    prod_precio       decimal(12, 2)    NOT NULL,
    prod_stock        decimal(12, 2)    NULL,
    prod_detalle      varchar(250)      NULL,
    prod_img          varchar(250)      NULL,
    prod_proveedor    int               NULL,
    CONSTRAINT PK7 PRIMARY KEY NONCLUSTERED (id_producto)
)
go



IF OBJECT_ID('Producto') IS NOT NULL
    PRINT '<<< CREATED TABLE Producto >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE Producto >>>'
go

/* 
 * TABLE: Promocion_producto 
 */

CREATE TABLE Promocion_producto(
    id_promo              int         NOT NULL,
    id_producto           int         NOT NULL,
    promo_numero          int         NOT NULL,
    promo_fecha_inicio    datetime    NOT NULL,
    promo_fecha_fin       datetime    NOT NULL,
    CONSTRAINT PK19 PRIMARY KEY NONCLUSTERED (id_promo, id_producto, promo_numero)
)
go



IF OBJECT_ID('Promocion_producto') IS NOT NULL
    PRINT '<<< CREATED TABLE Promocion_producto >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE Promocion_producto >>>'
go

/* 
 * TABLE: Promociones 
 */

CREATE TABLE Promociones(
    id_promo        int               NOT NULL,
    promo_nombre    char(45)          NULL,
    descuento       decimal(10, 2)    NULL,
    CONSTRAINT PK18 PRIMARY KEY NONCLUSTERED (id_promo)
)
go



IF OBJECT_ID('Promociones') IS NOT NULL
    PRINT '<<< CREATED TABLE Promociones >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE Promociones >>>'
go

/* 
 * TABLE: Proveedor 
 */

CREATE TABLE Proveedor(
    id_proveedor        int             IDENTITY(1,1),
    provee_nombre       varchar(45)     NOT NULL,
    provee_apellido     varchar(45)     NOT NULL,
    provee_direccion    varchar(100)    NOT NULL,
    provee_cuit         varchar(11)     NOT NULL,
    CONSTRAINT PK5 PRIMARY KEY NONCLUSTERED (id_proveedor)
)
go



IF OBJECT_ID('Proveedor') IS NOT NULL
    PRINT '<<< CREATED TABLE Proveedor >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE Proveedor >>>'
go

/* 
 * TABLE: Rol 
 */

CREATE TABLE Rol(
    id_Rol         int         IDENTITY(1,1),
    rol_detalle    char(45)    NULL,
    CONSTRAINT PK16 PRIMARY KEY NONCLUSTERED (id_Rol)
)
go



IF OBJECT_ID('Rol') IS NOT NULL
    PRINT '<<< CREATED TABLE Rol >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE Rol >>>'
go

/* 
 * TABLE: Tipo_de_cliente 
 */

CREATE TABLE Tipo_de_cliente(
    id_tipo_cliente          int            IDENTITY(1,1),
    clie_tipo_descripcion    varchar(45)    NOT NULL,
    CONSTRAINT PK2 PRIMARY KEY NONCLUSTERED (id_tipo_cliente)
)
go



IF OBJECT_ID('Tipo_de_cliente') IS NOT NULL
    PRINT '<<< CREATED TABLE Tipo_de_cliente >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE Tipo_de_cliente >>>'
go

/* 
 * TABLE: Usuario 
 */

CREATE TABLE Usuario(
    id_usuario     int            IDENTITY(1,1),
    usua_nombre    varchar(45)    NOT NULL,
    usua_correo    varchar(45)    NOT NULL,
    usua_pass      varchar(45)    NOT NULL,
    usua_aut       bit            NOT NULL,
    id_Rol         int            NULL,
    CONSTRAINT PK3 PRIMARY KEY NONCLUSTERED (id_usuario)
)
go



IF OBJECT_ID('Usuario') IS NOT NULL
    PRINT '<<< CREATED TABLE Usuario >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE Usuario >>>'
go

/* 
 * TABLE: categorias_proveedor 
 */

ALTER TABLE categorias_proveedor ADD CONSTRAINT RefProveedor4 
    FOREIGN KEY (id_proveedor)
    REFERENCES Proveedor(id_proveedor)
go

ALTER TABLE categorias_proveedor ADD CONSTRAINT RefCategoria5 
    FOREIGN KEY (id_categoria)
    REFERENCES Categoria(id_categoria)
go


/* 
 * TABLE: Cliente 
 */

ALTER TABLE Cliente ADD CONSTRAINT RefTipo_de_cliente11 
    FOREIGN KEY (clie_tipo)
    REFERENCES Tipo_de_cliente(id_tipo_cliente)
go

ALTER TABLE Cliente ADD CONSTRAINT RefUsuario12 
    FOREIGN KEY (clie_id_usuario)
    REFERENCES Usuario(id_usuario)
go


/* 
 * TABLE: Detalle_orden 
 */

ALTER TABLE Detalle_orden ADD CONSTRAINT RefOrden7 
    FOREIGN KEY (id_orden)
    REFERENCES Orden(id_orden)
go

ALTER TABLE Detalle_orden ADD CONSTRAINT RefProducto8 
    FOREIGN KEY (id_producto)
    REFERENCES Producto(id_producto)
go


/* 
 * TABLE: Empleado 
 */

ALTER TABLE Empleado ADD CONSTRAINT RefEmpleado13 
    FOREIGN KEY (emple_id_supervisor)
    REFERENCES Empleado(id_empleado)
go

ALTER TABLE Empleado ADD CONSTRAINT RefUsuario14 
    FOREIGN KEY (emple_id_usuario)
    REFERENCES Usuario(id_usuario)
go


/* 
 * TABLE: Orden 
 */

ALTER TABLE Orden ADD CONSTRAINT RefCliente2 
    FOREIGN KEY (ord_id_cliente)
    REFERENCES Cliente(id_cliente)
go

ALTER TABLE Orden ADD CONSTRAINT RefEmpleado3 
    FOREIGN KEY (ord_id_empleado)
    REFERENCES Empleado(id_empleado)
go


/* 
 * TABLE: Producto 
 */

ALTER TABLE Producto ADD CONSTRAINT RefProveedor1 
    FOREIGN KEY (prod_proveedor)
    REFERENCES Proveedor(id_proveedor)
go


/* 
 * TABLE: Promocion_producto 
 */

ALTER TABLE Promocion_producto ADD CONSTRAINT RefPromociones9 
    FOREIGN KEY (id_promo)
    REFERENCES Promociones(id_promo)
go

ALTER TABLE Promocion_producto ADD CONSTRAINT RefProducto10 
    FOREIGN KEY (id_producto)
    REFERENCES Producto(id_producto)
go


/* 
 * TABLE: Usuario 
 */

ALTER TABLE Usuario ADD CONSTRAINT RefRol6 
    FOREIGN KEY (id_Rol)
    REFERENCES Rol(id_Rol)
go


