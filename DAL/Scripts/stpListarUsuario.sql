USE [DB_IngSoft]
GO
/****** Object:  StoredProcedure [dbo].[ListarUsuario]    Script Date: 3/6/2025 17:24:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[ListarUsuario] 
	-- Add the parameters for the stored procedure here
	@Usuario NVARCHAR(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	 SELECT TOP 1 * 
	FROM Users 
	WHERE Usuario = @Usuario;

END
