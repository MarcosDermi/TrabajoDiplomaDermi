USE [DB_IngSoft]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE OR ALTER PROCEDURE [dbo].[ModificarUsuario]
	
	@Id int,
	@Usuario nvarchar(50),
	@Nombre nvarchar(50),
	@Apellido nvarchar(50),
	@Mail nvarchar(50),
	@FechaNac date,
	@DNI int,
	@IsAdmin bit
AS
BEGIN
	
	SET NOCOUNT ON;
	update Users 
	set Usuario=@Usuario,
	Nombre=@Nombre,
	Apellido=@Apellido,
	Mail=@Mail,
	FechaNac=@FechaNac,
	DNI=@DNI,
	isAdmin=@IsAdmin
	where Id=@Id
END
GO


