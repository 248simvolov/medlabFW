USE [master]
GO
/****** Object:  Database [medlaba]    Script Date: 03.12.2023 22:36:09 ******/
CREATE DATABASE [medlaba]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'medlaba', FILENAME = N'E:\Programms\SQLServer\MSSQL16.MSSQLSERVER\MSSQL\DATA\medlaba000.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'medlaba_log', FILENAME = N'E:\Programms\SQLServer\MSSQL16.MSSQLSERVER\MSSQL\DATA\medlaba000_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [medlaba] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [medlaba].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [medlaba] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [medlaba] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [medlaba] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [medlaba] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [medlaba] SET ARITHABORT OFF 
GO
ALTER DATABASE [medlaba] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [medlaba] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [medlaba] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [medlaba] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [medlaba] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [medlaba] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [medlaba] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [medlaba] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [medlaba] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [medlaba] SET  DISABLE_BROKER 
GO
ALTER DATABASE [medlaba] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [medlaba] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [medlaba] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [medlaba] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [medlaba] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [medlaba] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [medlaba] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [medlaba] SET RECOVERY FULL 
GO
ALTER DATABASE [medlaba] SET  MULTI_USER 
GO
ALTER DATABASE [medlaba] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [medlaba] SET DB_CHAINING OFF 
GO
ALTER DATABASE [medlaba] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [medlaba] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [medlaba] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [medlaba] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'medlaba', N'ON'
GO
ALTER DATABASE [medlaba] SET QUERY_STORE = ON
GO
ALTER DATABASE [medlaba] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [medlaba]
GO
/****** Object:  Table [dbo].[Анализ]    Script Date: 03.12.2023 22:36:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Анализ](
	[КодАнализа] [int] IDENTITY(1,1) NOT NULL,
	[ДатаСдачи] [date] NOT NULL,
	[КодТипа] [int] NOT NULL,
	[Пациент] [nchar](11) NOT NULL,
	[РезультатАнализа] [int] NOT NULL,
	[АнализПроводил] [nchar](10) NOT NULL,
 CONSTRAINT [PK_Анализ] PRIMARY KEY CLUSTERED 
(
	[КодАнализа] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Должность]    Script Date: 03.12.2023 22:36:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Должность](
	[КодДолжности] [int] IDENTITY(1,1) NOT NULL,
	[Название] [nchar](80) NOT NULL,
	[Описание] [nchar](100) NULL,
 CONSTRAINT [PK_Должность] PRIMARY KEY CLUSTERED 
(
	[КодДолжности] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ПараметрыАнализов]    Script Date: 03.12.2023 22:36:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ПараметрыАнализов](
	[КодПараметра] [int] IDENTITY(1,1) NOT NULL,
	[Название] [nchar](80) NOT NULL,
	[Описание] [nchar](500) NULL,
	[ПринадлежитТипу] [int] NOT NULL,
 CONSTRAINT [PK_ПараметрАнализа] PRIMARY KEY CLUSTERED 
(
	[КодПараметра] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Пациент]    Script Date: 03.12.2023 22:36:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Пациент](
	[СНИЛС] [nchar](11) NOT NULL,
	[Фамилия] [nchar](20) NOT NULL,
	[Имя] [nchar](20) NOT NULL,
	[Отчество] [nchar](20) NULL,
	[ПаспортныеДанные] [nchar](10) NOT NULL,
	[ПолМужской] [bit] NOT NULL,
	[ДатаРождения] [date] NOT NULL,
	[ЭлектроннаяПочта] [nchar](60) NOT NULL,
 CONSTRAINT [PK_Пациент] PRIMARY KEY CLUSTERED 
(
	[СНИЛС] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[РезультатАнализа]    Script Date: 03.12.2023 22:36:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[РезультатАнализа](
	[КодРезультата] [int] IDENTITY(1,1) NOT NULL,
	[ПараметрАнализа] [int] NOT NULL,
	[Значение] [nchar](40) NULL,
	[Анализ] [int] NOT NULL,
 CONSTRAINT [PK_РезультатАнализа] PRIMARY KEY CLUSTERED 
(
	[КодРезультата] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Сотрудники]    Script Date: 03.12.2023 22:36:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Сотрудники](
	[ПаспортныеДанные] [nchar](10) NOT NULL,
	[Фамилия] [nchar](20) NOT NULL,
	[Имя] [nchar](20) NOT NULL,
	[Отчество] [nchar](20) NULL,
	[Должность] [int] NOT NULL,
	[АдресЭлектроннойПочты] [nvarchar](60) NOT NULL,
	[ПарольЭлектроннойПочты] [nvarchar](60) NOT NULL,
 CONSTRAINT [PK_Сотрудники] PRIMARY KEY CLUSTERED 
(
	[ПаспортныеДанные] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ТипАнализа]    Script Date: 03.12.2023 22:36:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ТипАнализа](
	[КодТипа] [int] IDENTITY(1,1) NOT NULL,
	[Название] [nchar](50) NOT NULL,
 CONSTRAINT [PK_ТипАнализа] PRIMARY KEY CLUSTERED 
(
	[КодТипа] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Анализ]  WITH CHECK ADD  CONSTRAINT [FK_Анализ_Пациент] FOREIGN KEY([Пациент])
REFERENCES [dbo].[Пациент] ([СНИЛС])
GO
ALTER TABLE [dbo].[Анализ] CHECK CONSTRAINT [FK_Анализ_Пациент]
GO
ALTER TABLE [dbo].[Анализ]  WITH CHECK ADD  CONSTRAINT [FK_Анализ_Сотрудники] FOREIGN KEY([АнализПроводил])
REFERENCES [dbo].[Сотрудники] ([ПаспортныеДанные])
GO
ALTER TABLE [dbo].[Анализ] CHECK CONSTRAINT [FK_Анализ_Сотрудники]
GO
ALTER TABLE [dbo].[Анализ]  WITH CHECK ADD  CONSTRAINT [FK_Анализ_ТипАнализа] FOREIGN KEY([КодТипа])
REFERENCES [dbo].[ТипАнализа] ([КодТипа])
GO
ALTER TABLE [dbo].[Анализ] CHECK CONSTRAINT [FK_Анализ_ТипАнализа]
GO
ALTER TABLE [dbo].[ПараметрыАнализов]  WITH CHECK ADD  CONSTRAINT [FK_ПараметрАнализа_ТипАнализа] FOREIGN KEY([ПринадлежитТипу])
REFERENCES [dbo].[ТипАнализа] ([КодТипа])
GO
ALTER TABLE [dbo].[ПараметрыАнализов] CHECK CONSTRAINT [FK_ПараметрАнализа_ТипАнализа]
GO
ALTER TABLE [dbo].[РезультатАнализа]  WITH CHECK ADD  CONSTRAINT [FK_РезультатАнализа_Анализ1] FOREIGN KEY([Анализ])
REFERENCES [dbo].[Анализ] ([КодАнализа])
GO
ALTER TABLE [dbo].[РезультатАнализа] CHECK CONSTRAINT [FK_РезультатАнализа_Анализ1]
GO
ALTER TABLE [dbo].[РезультатАнализа]  WITH CHECK ADD  CONSTRAINT [FK_РезультатАнализа_ПараметрАнализа] FOREIGN KEY([ПараметрАнализа])
REFERENCES [dbo].[ПараметрыАнализов] ([КодПараметра])
GO
ALTER TABLE [dbo].[РезультатАнализа] CHECK CONSTRAINT [FK_РезультатАнализа_ПараметрАнализа]
GO
ALTER TABLE [dbo].[Сотрудники]  WITH CHECK ADD  CONSTRAINT [FK_Сотрудники_Должность] FOREIGN KEY([Должность])
REFERENCES [dbo].[Должность] ([КодДолжности])
GO
ALTER TABLE [dbo].[Сотрудники] CHECK CONSTRAINT [FK_Сотрудники_Должность]
GO
USE [master]
GO
ALTER DATABASE [medlaba] SET  READ_WRITE 
GO
