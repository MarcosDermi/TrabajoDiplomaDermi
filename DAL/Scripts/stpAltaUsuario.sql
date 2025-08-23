USE [DB_IngSoft]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


	CREATE PROCEDURE [dbo].[AltaUsuario]
	
	@Usuario NVARCHAR(50),
	@Nombre NVARCHAR(50),
    @Apellido NVARCHAR(50),
	@Mail NVARCHAR(50),
	@FechaNac date,
	@DNI int,
	@isAdmin bit,
	@Clave NVARCHAR(MAX),
	@deleted bit,
	@DV NVARCHAR(MAX) = NULL

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    INSERT INTO Users (Usuario, Nombre, Apellido, Mail, FechaNac, DNI, isAdmin, Clave, deleted, DV)
VALUES (@Usuario, @Nombre, @Apellido, @Mail, @FechaNac, @DNI, @isAdmin, @Clave, @deleted, @DV);
END;
GO