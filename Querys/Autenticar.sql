USE [Farma]
GO
/****** Object:  StoredProcedure [dbo].[AutenticarUsuarios]    Script Date: 21/12/2022 20:52:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[AutenticarUsuarios]
(@usua_correo nvarchar(45),
@usua_pass nvarchar(45))
as
begin
	select * from Usuario where usua_correo like @usua_correo AND usua_pass like @usua_pass
end

execute AutenticarUsuarios @usua_correo = 'e@gmail.com', @usua_pass = '123'