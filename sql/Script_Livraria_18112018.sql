USE [master]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Livro](
	[Id] [uniqueidentifier] NOT NULL,
	[Titulo] [varchar](100) NOT NULL,
	[Descricao] [varchar](255) NOT NULL,
	[Autor] [varchar](100) NOT NULL,
	[Editora] [varchar](50) NOT NULL,
	[Edicao] [int] NULL,
	[ISBN] [varchar](50) NOT NULL,
	[Idioma] [varchar](50) NULL,
 CONSTRAINT [PK_Livro] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
