USE [Clientes]
GO

/****** Object:  Table [dbo].[clientes]    Script Date: 22/07/2020 17:54:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[clientes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Cuenta] [varchar](50) NOT NULL,
	[Email] [varchar](50) NULL,
	[Contraseña] [varchar](50) NULL,
	[VencimientoP] [datetime] NULL,
	[VencimientoC] [datetime] NULL,
	[Nombre] [varchar](50) NULL,
	[Tipo] [int] NULL,
	[Pantallas] [varchar](50) NULL,
 CONSTRAINT [PK_clientes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

