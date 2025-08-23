USE [DB_IngSoft]
GO

/****** Object:  StoredProcedure [dbo].[GuardarBitacora]    Script Date: 5/7/2025 01:46:18 ******/
DROP PROCEDURE [dbo].[GuardarBitacora]
GO

/****** Object:  StoredProcedure [dbo].[GuardarBitacora]    Script Date: 5/7/2025 01:46:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO






CREATE   PROCEDURE [dbo].[GuardarBitacora]
	
	@Detalle NVARCHAR(MAX) = NULL,
	@UsuarioID INT,
	@Fecha DATETIME,
	@BitacoraTipoID INT

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	
	insert into Bitacoras (Detalle, UsuarioID, Fecha, BitacoraTipoID) values (@Detalle,@UsuarioID, @Fecha, @BitacoraTipoID);      

END
GO


