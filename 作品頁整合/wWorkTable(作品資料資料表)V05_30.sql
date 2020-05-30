USE [期末專題]
GO

/****** Object:  Table [dbo].[wWorkTable]    Script Date: 2020/5/30 上午 11:29:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[wWorkTable](
	[編號] [int] IDENTITY(1,1) NOT NULL,
	[姓名] [nvarchar](50) NOT NULL,
	[分類] [nvarchar](50) NULL,
	[作品名稱] [nvarchar](50) NULL,
	[作品描述] [nvarchar](255) NULL,
	[圖片名稱] [nvarchar](50) NULL,
	[圖片路徑] [nvarchar](255) NULL,
	[上傳日期] [char](14) NULL,
	[勾選項目分類] [nvarchar](255) NULL,
 CONSTRAINT [PK_wWorkTable] PRIMARY KEY CLUSTERED 
(
	[編號] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

