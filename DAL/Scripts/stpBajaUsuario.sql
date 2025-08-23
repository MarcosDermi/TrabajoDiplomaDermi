USE [DB_IngSoft]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE OR ALTER PROCEDURE [dbo].[BajaUsuario]

	@Id int
AS
BEGIN
	
	SET NOCOUNT ON;

	update Users
	set deleted=1
	where Id=@Id
END
GO


