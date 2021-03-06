USE [master]
GO
/****** Object:  Database [CovidMonitor]    Script Date: 10/07/2020 17:00:39 ******/
CREATE DATABASE [CovidMonitor]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CovidMonitor', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\CovidMonitor.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CovidMonitor_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\CovidMonitor_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [CovidMonitor] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CovidMonitor].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CovidMonitor] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CovidMonitor] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CovidMonitor] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CovidMonitor] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CovidMonitor] SET ARITHABORT OFF 
GO
ALTER DATABASE [CovidMonitor] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CovidMonitor] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CovidMonitor] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CovidMonitor] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CovidMonitor] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CovidMonitor] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CovidMonitor] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CovidMonitor] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CovidMonitor] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CovidMonitor] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CovidMonitor] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CovidMonitor] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CovidMonitor] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CovidMonitor] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CovidMonitor] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CovidMonitor] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CovidMonitor] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CovidMonitor] SET RECOVERY FULL 
GO
ALTER DATABASE [CovidMonitor] SET  MULTI_USER 
GO
ALTER DATABASE [CovidMonitor] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CovidMonitor] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CovidMonitor] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CovidMonitor] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CovidMonitor] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'CovidMonitor', N'ON'
GO
ALTER DATABASE [CovidMonitor] SET QUERY_STORE = OFF
GO
USE [CovidMonitor]
GO
/****** Object:  Table [dbo].[Patient]    Script Date: 10/07/2020 17:00:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patient](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[Age] [int] NULL,
	[City] [nchar](10) NULL,
	[Num_Of_Families] [int] NULL,
	[Status] [int] NULL,
	[Month] [nchar](10) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Patient] ON 

INSERT [dbo].[Patient] ([Id], [Name], [Address], [Age], [City], [Num_Of_Families], [Status], [Month]) VALUES (2002, N'Prajakta Naik', N'Vasco, Goa', 35, N'C3        ', 4, 4, N'M2        ')
INSERT [dbo].[Patient] ([Id], [Name], [Address], [Age], [City], [Num_Of_Families], [Status], [Month]) VALUES (2, N'Prajakta Sail', N'Siolim,Goa', 29, N'C2        ', 3, 1, N'M3        ')
INSERT [dbo].[Patient] ([Id], [Name], [Address], [Age], [City], [Num_Of_Families], [Status], [Month]) VALUES (2003, N'John Desouza', N'Siolim,Goa', 58, N'C4        ', 2, 4, N'M7        ')
INSERT [dbo].[Patient] ([Id], [Name], [Address], [Age], [City], [Num_Of_Families], [Status], [Month]) VALUES (2004, N'Priyanka Naik', N'Verna, Goa', 78, N'C7        ', 6, 5, N'M7        ')
SET IDENTITY_INSERT [dbo].[Patient] OFF
USE [master]
GO
ALTER DATABASE [CovidMonitor] SET  READ_WRITE 
GO
