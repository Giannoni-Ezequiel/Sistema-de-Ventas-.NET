USE [SistemaVentas]
GO
/****** Object:  StoredProcedure [dbo].[ListarUsuario]    Script Date: 28/12/2022 20:08:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[ListarUsuario] as 
begin 
select * from Usuario inner join Rol on Usuario.id_Rol = Rol.id_Rol
end