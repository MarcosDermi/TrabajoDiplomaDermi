USE [DB_IngSoft]
GO

/****** Object:  Table [dbo].[Bitacoras]    Script Date: 5/7/2025 01:46:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Bitacoras]') AND type in (N'U'))
DROP TABLE [dbo].[Bitacoras]
GO

/****** Object:  Table [dbo].[Bitacoras]    Script Date: 5/7/2025 01:46:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Bitacoras](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Detalle] [nvarchar](max) NULL,
	[UsuarioID] [int] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[BitacoraTipoID] [int] NOT NULL,
 CONSTRAINT [PK_Bitacoras] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


