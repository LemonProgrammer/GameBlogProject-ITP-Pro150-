USE [master]
GO
/****** Object:  Database [ITP]    Script Date: 2/22/2019 6:49:52 PM ******/
CREATE DATABASE [ITP]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ITP', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.DBT130\MSSQL\DATA\ITP.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ITP_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.DBT130\MSSQL\DATA\ITP_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ITP] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ITP].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ITP] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ITP] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ITP] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ITP] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ITP] SET ARITHABORT OFF 
GO
ALTER DATABASE [ITP] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ITP] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ITP] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ITP] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ITP] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ITP] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ITP] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ITP] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ITP] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ITP] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ITP] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ITP] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ITP] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ITP] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ITP] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ITP] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ITP] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ITP] SET RECOVERY FULL 
GO
ALTER DATABASE [ITP] SET  MULTI_USER 
GO
ALTER DATABASE [ITP] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ITP] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ITP] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ITP] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [ITP] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'ITP', N'ON'
GO
USE [ITP]
GO
/****** Object:  Table [dbo].[Comments]    Script Date: 2/22/2019 6:49:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comments](
	[CommentID] [int] IDENTITY(1,1) NOT NULL,
	[ContentText] [nvarchar](1) NOT NULL,
	[OwnerUsername] [nvarchar](30) NOT NULL,
	[OwnerProfileImage] [nvarchar](250) NOT NULL,
	[DatePosted] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CommentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DiscussionComments]    Script Date: 2/22/2019 6:49:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DiscussionComments](
	[DiscussionCommentID] [int] NOT NULL,
	[DiscussionID] [int] NOT NULL,
	[CommentID] [int] NOT NULL,
 CONSTRAINT [PK_DiscussionComments] PRIMARY KEY CLUSTERED 
(
	[DiscussionCommentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Discussions]    Script Date: 2/22/2019 6:49:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Discussions](
	[DiscussionID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[ContentText] [nvarchar](1) NOT NULL,
	[OwnerUsername] [nvarchar](30) NOT NULL,
	[OnwerProfileImage] [nvarchar](250) NOT NULL,
	[Status] [bit] NOT NULL,
	[DatePosted] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[DiscussionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 2/22/2019 6:49:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[AccountID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](30) NOT NULL,
	[LastName] [varchar](30) NOT NULL,
	[Username] [nvarchar](30) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Age] [int] NOT NULL,
	[Birthday] [date] NOT NULL,
	[ProfileImage] [nvarchar](250) NULL,
	[Bio] [nvarchar](250) NULL,
PRIMARY KEY CLUSTERED 
(
	[AccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserComments]    Script Date: 2/22/2019 6:49:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserComments](
	[UserCommentID] [int] NOT NULL,
	[AccountID] [int] NOT NULL,
	[CommentID] [int] NOT NULL,
 CONSTRAINT [PK_UserComments] PRIMARY KEY CLUSTERED 
(
	[UserCommentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserDiscussion]    Script Date: 2/22/2019 6:49:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserDiscussion](
	[AccountId] [int] NOT NULL,
	[DiscussionId] [int] NOT NULL,
	[UserDiscussionID] [int] NOT NULL,
 CONSTRAINT [PK_UserDiscussion] PRIMARY KEY CLUSTERED 
(
	[UserDiscussionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DiscussionComments]  WITH CHECK ADD  CONSTRAINT [FK_DiscussionComments_Comments] FOREIGN KEY([CommentID])
REFERENCES [dbo].[Comments] ([CommentID])
GO
ALTER TABLE [dbo].[DiscussionComments] CHECK CONSTRAINT [FK_DiscussionComments_Comments]
GO
ALTER TABLE [dbo].[DiscussionComments]  WITH CHECK ADD  CONSTRAINT [FK_DiscussionComments_Discussions] FOREIGN KEY([DiscussionID])
REFERENCES [dbo].[Discussions] ([DiscussionID])
GO
ALTER TABLE [dbo].[DiscussionComments] CHECK CONSTRAINT [FK_DiscussionComments_Discussions]
GO
ALTER TABLE [dbo].[UserComments]  WITH CHECK ADD  CONSTRAINT [FK_UserComments_Comments] FOREIGN KEY([CommentID])
REFERENCES [dbo].[Comments] ([CommentID])
GO
ALTER TABLE [dbo].[UserComments] CHECK CONSTRAINT [FK_UserComments_Comments]
GO
ALTER TABLE [dbo].[UserComments]  WITH CHECK ADD  CONSTRAINT [FK_UserComments_User] FOREIGN KEY([AccountID])
REFERENCES [dbo].[User] ([AccountID])
GO
ALTER TABLE [dbo].[UserComments] CHECK CONSTRAINT [FK_UserComments_User]
GO
ALTER TABLE [dbo].[UserDiscussion]  WITH CHECK ADD  CONSTRAINT [FK_UserDiscussion_Discussions] FOREIGN KEY([DiscussionId])
REFERENCES [dbo].[Discussions] ([DiscussionID])
GO
ALTER TABLE [dbo].[UserDiscussion] CHECK CONSTRAINT [FK_UserDiscussion_Discussions]
GO
ALTER TABLE [dbo].[UserDiscussion]  WITH CHECK ADD  CONSTRAINT [FK_UserDiscussion_User] FOREIGN KEY([AccountId])
REFERENCES [dbo].[User] ([AccountID])
GO
ALTER TABLE [dbo].[UserDiscussion] CHECK CONSTRAINT [FK_UserDiscussion_User]
GO
USE [master]
GO
ALTER DATABASE [ITP] SET  READ_WRITE 
GO
