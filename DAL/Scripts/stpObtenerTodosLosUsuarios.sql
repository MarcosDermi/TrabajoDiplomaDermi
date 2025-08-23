USE [DB_IngSoft]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ObtenerTodosLosUsuarios]
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT Id, Usuario, Nombre, Apellido, Mail, FechaNac, DNI, isAdmin, Clave, DV
    FROM Users
    WHERE deleted = 0;
END
GO 