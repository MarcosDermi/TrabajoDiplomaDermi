USE [DB_IngSoft]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ActualizarDVSistema]
    @dv NVARCHAR(MAX)
AS
BEGIN
    SET NOCOUNT ON;
    
    UPDATE DVSistema 
    SET DV = @dv, 
        FechaActualizacion = GETDATE()
    WHERE Id = 1;
    
    -- Si no existe el registro, lo creamos
    IF @@ROWCOUNT = 0
    BEGIN
        INSERT INTO DVSistema (DV, FechaActualizacion)
        VALUES (@dv, GETDATE());
    END
END
GO 