USE [master]
GO
/****** Object:  Database [DataLogs]    Script Date: 2015/12/11 11:35:43 ******/
CREATE DATABASE [DataLogs]
GO
USE [DataLogs]
GO
/****** Object:  Table [dbo].[Log_Data]    Script Date: 2015/12/11 11:35:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Log_Data](
	[Date] [datetime] NOT NULL,
	[Thread] [nvarchar](255) NULL,
	[Level] [nvarchar](255) NULL,
	[Logger] [nvarchar](255) NULL,
	[Message] [nvarchar](max) NULL,
	[Exception] [nvarchar](max) NULL,
	[ClientIP] [nvarchar](max) NULL,
	[ServerIP] [nvarchar](max) NULL,
	[RequestUrl] [nvarchar](max) NULL,
	[UserId] [nvarchar](max) NULL,
	[UserName] [nvarchar](max) NULL,
	[DisplayName] [nvarchar](max) NULL,
	[AreaName] [nvarchar](max) NULL,
	[ControllerName] [nvarchar](max) NULL,
	[ActionName] [nvarchar](max) NULL,
	[RunTime] [bigint] NULL,
	[FileName] [nvarchar](max) NULL,
	[ClassName] [nvarchar](max) NULL,
	[MethodName] [nvarchar](max) NULL,
	[LineNumber] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
USE [master]
GO
ALTER DATABASE [DataLogs] SET  READ_WRITE 
GO
