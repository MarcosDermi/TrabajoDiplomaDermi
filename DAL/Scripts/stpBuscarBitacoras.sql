USE [DB_IngSoft]
GO

/****** Object:  StoredProcedure [dbo].[BuscarBitacora]    Script Date: 5/7/2025 01:47:50 ******/
DROP PROCEDURE [dbo].[BuscarBitacora]
GO

/****** Object:  StoredProcedure [dbo].[BuscarBitacora]    Script Date: 5/7/2025 01:47:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[BuscarBitacora]
    @NombreUsuario NVARCHAR(100) = NULL,
    @FechaDesde DATETIME = NULL,
    @FechaHasta DATETIME = NULL,
    @BitacoraTipoID INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        b.Id,
        b.Fecha,
        b.Detalle,
		u.Usuario,
        b.BitacoraTipoID
    FROM 
        Bitacoras b
    INNER JOIN 
        Users u ON b.UsuarioID = u.Id
    WHERE 
        (@NombreUsuario IS NULL OR u.Usuario LIKE '%' + @NombreUsuario + '%')
        AND (@FechaDesde IS NULL OR b.Fecha >= @FechaDesde)
        AND (@FechaHasta IS NULL OR b.Fecha <= @FechaHasta)
        AND (@BitacoraTipoID IS NULL OR b.BitacoraTipoID = @BitacoraTipoID)
    ORDER BY 
        b.Fecha DESC
END
GO


