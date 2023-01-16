USE [Farma]
GO

ALTER TABLE [dbo].[Empleado]  WITH CHECK ADD  CONSTRAINT [RefEmpleado13] FOREIGN KEY([emple_id_supervisor])
REFERENCES [dbo].[Empleado] ([id_empleado])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Empleado] CHECK CONSTRAINT [RefEmpleado13]
GO


