USE [Recruitment]
GO

/****** Object:  Table [dbo].[Job_Contacts]    Script Date: 2019/10/13 10:14:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Job_Contacts](
	[ctt_id] [smallint] NOT NULL,
	[ctt_date] [date] NOT NULL,
	[ctt_hhmm] [varchar](10) NULL,
	[role] [nvarchar](50) NULL,
	[location] [nvarchar](20) NULL,
	[appli] [bit] NOT NULL,
	[reply] [bit] NULL,
	[agency] [nvarchar](50) NOT NULL,
	[staff] [nvarchar](50) NOT NULL,
	[email] [nvarchar](50) NULL,
	[mobile] [nvarchar](20) NULL,
	[phone] [nvarchar](20) NULL,
	[remark] [nvarchar](250) NULL,
	[more] [nvarchar](250) NULL,
 CONSTRAINT [PK_Job_Contacts] PRIMARY KEY CLUSTERED 
(
	[ctt_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

