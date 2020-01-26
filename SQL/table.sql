USE [Recruitment]
GO

/****** Object:  Table [dbo].[Job_Contacts_2]    Script Date: 2020/1/26 7:53:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Job_Contacts_2](
	[ctt_id] [smallint] NOT NULL,
	[ctt_date] [date] NOT NULL,
	[ctt_hhmm] [varchar](10) NULL,
	[role] [nvarchar](50) NULL,
	[client] [nvarchar](50) NULL,
	[location] [nvarchar](30) NULL,
	[appli] [bit] NOT NULL,
	[reply] [bit] NULL,
	[agency] [nvarchar](50) NOT NULL,
	[staff] [nvarchar](100) NOT NULL,
	[email] [nvarchar](100) NULL,
	[phones] [nvarchar](100) NULL,
	[remark] [nvarchar](250) NULL,
	[more] [nvarchar](250) NULL,
 CONSTRAINT [PK_JC2] PRIMARY KEY CLUSTERED 
(
	[ctt_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

