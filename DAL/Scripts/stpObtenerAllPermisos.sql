USE [DB_IngSoft]
GO

/****** Object:  StoredProcedure [dbo].[ObtenerAllPermisos]    Script Date: 6/6/2025 21:46:02 ******/
DROP PROCEDURE [dbo].[ObtenerAllPermisos]
GO

/****** Object:  StoredProcedure [dbo].[ObtenerAllPermisos]    Script Date: 6/6/2025 21:46:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE   PROCEDURE [dbo].[ObtenerAllPermisos]
	
	@familia INT = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	if @familia = 0 select @familia = null;
	SET NOCOUNT ON;

    WITH recursivo AS (
        SELECT sp2.id_permiso_padre, sp2.id_permiso_hijo
        FROM permiso_permiso sp2
        WHERE 
            (@familia IS NULL AND sp2.id_permiso_padre IS NULL)
            OR
            (@familia IS NOT NULL AND sp2.id_permiso_padre = @familia)

        UNION ALL

        SELECT sp.id_permiso_padre, sp.id_permiso_hijo
        FROM permiso_permiso sp
        INNER JOIN recursivo r ON r.id_permiso_hijo = sp.id_permiso_padre
    )
    SELECT r.id_permiso_padre, r.id_permiso_hijo, p.id, p.nombre, p.es_patente
    FROM recursivo r
    INNER JOIN permiso p ON r.id_permiso_hijo = p.id;

END
GO


