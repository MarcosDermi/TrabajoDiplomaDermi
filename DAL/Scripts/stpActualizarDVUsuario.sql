USE [DB_IngSoft]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ActualizarDVUsuario]
    @id INT,
    @dv NVARCHAR(MAX)
AS
BEGIN
    SET NOCOUNT ON;
    
    UPDATE Users 
    SET DV = @dv
    WHERE Id = @id;
END
GO 