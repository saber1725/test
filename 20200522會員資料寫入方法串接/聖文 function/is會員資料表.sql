USE [MVCDB]
GO

/****** Object:  Table [dbo].[is會員資料]    Script Date: 2020/5/22 下午 03:07:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[is會員資料](
	[is會員資料id] [int] IDENTITY(1,1) NOT NULL,
	[is會員資料姓名] [nchar](10) NULL,
	[is會員資料暱稱] [nchar](10) NULL,
	[is會員資料性別] [nvarchar](5) NULL,
	[is會員資料連絡電話] [nchar](20) NULL,
	[is會員資料Email] [nchar](50) NOT NULL,
	[is會員資料密碼] [nchar](10) NOT NULL,
	[is會員資料地址] [nchar](50) NULL,
	[is會員資料身分證照片] [nvarchar](50) NULL,
	[is會員資料會員權限等級] [char](1) NOT NULL,
 CONSTRAINT [PK_is會員資料] PRIMARY KEY CLUSTERED 
(
	[is會員資料id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[is會員資料] ADD  CONSTRAINT [DF_is會員資料_is會員資料身分等級]  DEFAULT ((0)) FOR [is會員資料會員權限等級]
GO

