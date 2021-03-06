USE [master]
GO
/****** Object:  Database [Internety]    Script Date: 2019-03-26 14:32:32 ******/
CREATE DATABASE [Internety]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Internety', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\Internety.mdf' , SIZE = 4160KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Internety_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\Internety_log.ldf' , SIZE = 1040KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Internety] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Internety].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Internety] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Internety] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Internety] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Internety] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Internety] SET ARITHABORT OFF 
GO
ALTER DATABASE [Internety] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Internety] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Internety] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Internety] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Internety] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Internety] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Internety] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Internety] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Internety] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Internety] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Internety] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Internety] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Internety] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Internety] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Internety] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Internety] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Internety] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Internety] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Internety] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Internety] SET  MULTI_USER 
GO
ALTER DATABASE [Internety] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Internety] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Internety] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Internety] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Internety', N'ON'
GO
USE [Internety]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 2019-03-26 14:32:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Client](
	[Client_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Surname] [varchar](50) NOT NULL,
	[Address] [varchar](50) NOT NULL,
	[Pesel] [char](11) NOT NULL,
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[Client_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FastInternet]    Script Date: 2019-03-26 14:32:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FastInternet](
	[FastInternet_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Internet_ID] [bigint] NOT NULL,
	[Upload] [bigint] NOT NULL,
	[Download] [bigint] NOT NULL,
 CONSTRAINT [PK_FastInternet] PRIMARY KEY CLUSTERED 
(
	[FastInternet_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Internet]    Script Date: 2019-03-26 14:32:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Internet](
	[Internet_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[SaleName] [varchar](50) NOT NULL,
	[InternetType_ID] [bigint] NOT NULL,
	[Price] [money] NOT NULL,
 CONSTRAINT [PK_Internet] PRIMARY KEY CLUSTERED 
(
	[Internet_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[InternetType]    Script Date: 2019-03-26 14:32:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[InternetType](
	[InternetType_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[InternetType_Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_InternetType] PRIMARY KEY CLUSTERED 
(
	[InternetType_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MediumInternet]    Script Date: 2019-03-26 14:32:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MediumInternet](
	[MediumInternet_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Internet_ID] [bigint] NOT NULL,
	[Upload] [bigint] NOT NULL,
	[Download] [bigint] NOT NULL,
 CONSTRAINT [PK_MediumInternet] PRIMARY KEY CLUSTERED 
(
	[MediumInternet_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Office]    Script Date: 2019-03-26 14:32:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Office](
	[Office_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Address] [varchar](200) NOT NULL,
 CONSTRAINT [PK_Office] PRIMARY KEY CLUSTERED 
(
	[Office_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Services]    Script Date: 2019-03-26 14:32:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Services](
	[Service_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[SaleName] [varchar](200) NOT NULL,
	[Internet_ID] [bigint] NOT NULL,
	[Price] [money] NOT NULL,
 CONSTRAINT [PK_Services] PRIMARY KEY CLUSTERED 
(
	[Service_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SlowInternet]    Script Date: 2019-03-26 14:32:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SlowInternet](
	[SlowInternet_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Internet_ID] [bigint] NOT NULL,
	[Upload] [bigint] NOT NULL,
	[Download] [bigint] NOT NULL,
 CONSTRAINT [PK_SlowInternet] PRIMARY KEY CLUSTERED 
(
	[SlowInternet_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Transactions]    Script Date: 2019-03-26 14:32:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transactions](
	[Transaction_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Date] [date] NOT NULL,
	[Price] [bigint] NOT NULL,
	[Service_ID] [bigint] NOT NULL,
	[Client_ID] [bigint] NOT NULL,
	[Worker_ID] [bigint] NOT NULL,
 CONSTRAINT [PK_Transactions] PRIMARY KEY CLUSTERED 
(
	[Transaction_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Workers]    Script Date: 2019-03-26 14:32:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Workers](
	[Worker_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Surname] [varchar](50) NOT NULL,
	[Salary] [bigint] NOT NULL,
	[Phone_Number] [bigint] NOT NULL,
	[Address] [varchar](50) NOT NULL,
	[Pesel] [varchar](50) NOT NULL,
	[Hire_Date] [date] NOT NULL,
	[Office_ID] [bigint] NOT NULL,
 CONSTRAINT [PK_Workers] PRIMARY KEY CLUSTERED 
(
	[Worker_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Internet] ADD  CONSTRAINT [DF_Internet_InternetType_ID]  DEFAULT ((1)) FOR [InternetType_ID]
GO
ALTER TABLE [dbo].[FastInternet]  WITH CHECK ADD  CONSTRAINT [FK_FastInternet_Internet] FOREIGN KEY([Internet_ID])
REFERENCES [dbo].[Internet] ([Internet_ID])
GO
ALTER TABLE [dbo].[FastInternet] CHECK CONSTRAINT [FK_FastInternet_Internet]
GO
ALTER TABLE [dbo].[Internet]  WITH CHECK ADD  CONSTRAINT [FK_Internet_InternetType] FOREIGN KEY([InternetType_ID])
REFERENCES [dbo].[InternetType] ([InternetType_ID])
GO
ALTER TABLE [dbo].[Internet] CHECK CONSTRAINT [FK_Internet_InternetType]
GO
ALTER TABLE [dbo].[MediumInternet]  WITH CHECK ADD  CONSTRAINT [FK_MediumInternet_Internet] FOREIGN KEY([Internet_ID])
REFERENCES [dbo].[Internet] ([Internet_ID])
GO
ALTER TABLE [dbo].[MediumInternet] CHECK CONSTRAINT [FK_MediumInternet_Internet]
GO
ALTER TABLE [dbo].[Services]  WITH CHECK ADD  CONSTRAINT [FK_Services_Internet] FOREIGN KEY([Internet_ID])
REFERENCES [dbo].[Internet] ([Internet_ID])
GO
ALTER TABLE [dbo].[Services] CHECK CONSTRAINT [FK_Services_Internet]
GO
ALTER TABLE [dbo].[SlowInternet]  WITH CHECK ADD  CONSTRAINT [FK_SlowInternet_Internet] FOREIGN KEY([Internet_ID])
REFERENCES [dbo].[Internet] ([Internet_ID])
GO
ALTER TABLE [dbo].[SlowInternet] CHECK CONSTRAINT [FK_SlowInternet_Internet]
GO
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_Client] FOREIGN KEY([Client_ID])
REFERENCES [dbo].[Client] ([Client_ID])
GO
ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK_Transactions_Client]
GO
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_Services] FOREIGN KEY([Service_ID])
REFERENCES [dbo].[Services] ([Service_ID])
GO
ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK_Transactions_Services]
GO
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_Workers] FOREIGN KEY([Worker_ID])
REFERENCES [dbo].[Workers] ([Worker_ID])
GO
ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK_Transactions_Workers]
GO
ALTER TABLE [dbo].[Workers]  WITH CHECK ADD  CONSTRAINT [FK_Workers_Office] FOREIGN KEY([Office_ID])
REFERENCES [dbo].[Office] ([Office_ID])
GO
ALTER TABLE [dbo].[Workers] CHECK CONSTRAINT [FK_Workers_Office]
GO
USE [master]
GO
ALTER DATABASE [Internety] SET  READ_WRITE 
GO
