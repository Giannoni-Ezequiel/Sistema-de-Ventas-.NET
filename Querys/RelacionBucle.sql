USE [SistemaVentas]
GO
/****** Object:  StoredProcedure [dbo].[EmpleadoListar]    Script Date: 27/12/2022 17:54:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[EmpleadoListar] 
as
begin
select * from Empleado inner join Usuario on Empleado.emple_id_usuario = Usuario.id_usuario
/*select * from Empleado inner join Empleado on Empleado.emple_id_usuario = Empleado.emple_id_supervisor*/
end