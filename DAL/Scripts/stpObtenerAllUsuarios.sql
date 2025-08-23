USE [DB_IngSoft]
GO

/****** Object:  StoredProcedure [dbo].[ObtenerAllUsuarios]    Script Date: 2/5/2025 11:26:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



	CREATE PROCEDURE [dbo].[ObtenerAllUsuarios]

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    Select *
	from Users
	where deleted = 0
END;
GO


