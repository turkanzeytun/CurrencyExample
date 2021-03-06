USE [master]
GO
/****** Object:  Database [CurrencyDataDB]    Script Date: 03.08.2016 11:01:38 ******/
CREATE DATABASE [CurrencyDataDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CurrencyDataDBB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\CurrencyDataDBB.mdf' , SIZE = 4160KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'CurrencyDataDBB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\CurrencyDataDBB_log.ldf' , SIZE = 1040KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [CurrencyDataDB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CurrencyDataDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CurrencyDataDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CurrencyDataDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CurrencyDataDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CurrencyDataDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CurrencyDataDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [CurrencyDataDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [CurrencyDataDB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [CurrencyDataDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CurrencyDataDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CurrencyDataDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CurrencyDataDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CurrencyDataDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CurrencyDataDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CurrencyDataDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CurrencyDataDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CurrencyDataDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [CurrencyDataDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CurrencyDataDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CurrencyDataDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CurrencyDataDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CurrencyDataDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CurrencyDataDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CurrencyDataDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CurrencyDataDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CurrencyDataDB] SET  MULTI_USER 
GO
ALTER DATABASE [CurrencyDataDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CurrencyDataDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CurrencyDataDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CurrencyDataDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [CurrencyDataDB]
GO
/****** Object:  StoredProcedure [dbo].[ExchangeRatesToAddTable]    Script Date: 03.08.2016 11:01:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ExchangeRatesToAddTable] 
(
@RateDate DATETIME,
@ExchangeTypeID int,
@ExchangeBuying money,
@ExchangeSelling money,

@EffectiveBuying money,

@EffectiveSelling money



)
AS
BEGIN
	insert into ExchangeRates values(@ExchangeTypeID, @RateDate, @ExchangeBuying, @ExchangeSelling, @EffectiveBuying,@EffectiveSelling)
END


GO
/****** Object:  StoredProcedure [dbo].[GetExchangeRates]    Script Date: 03.08.2016 11:01:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetExchangeRates] 

AS
BEGIN
	SELECT * FROM ExchangeRates
END


GO
/****** Object:  StoredProcedure [dbo].[GetExchangeTypeByName]    Script Date: 03.08.2016 11:01:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetExchangeTypeByName] 
(
@ExchangeCode NCHAR(5)
)
AS
BEGIN
	SELECT * FROM ExchangeTypes WHERE ExchangeCode=@ExchangeCode
END


GO
/****** Object:  Table [dbo].[ExchangeRates]    Script Date: 03.08.2016 11:01:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExchangeRates](
	[CID] [int] IDENTITY(1,1) NOT NULL,
	[ExchangeTypeID] [int] NULL,
	[RateDate] [datetime] NULL,
	[ExchangeBuying] [money] NULL,
	[ExchangeSelling] [money] NULL,
	[EffectiveBuying] [money] NULL,
	[EffectiveSelling] [money] NULL,
 CONSTRAINT [PK_ExchangeRates] PRIMARY KEY CLUSTERED 
(
	[CID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ExchangeTypes]    Script Date: 03.08.2016 11:01:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExchangeTypes](
	[RID] [int] IDENTITY(1,1) NOT NULL,
	[ExchangeName] [nchar](50) NULL,
	[ExchangeCode] [nchar](5) NULL,
 CONSTRAINT [PK_ExchangeTypes] PRIMARY KEY CLUSTERED 
(
	[RID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[ExchangeRates] ON 

INSERT [dbo].[ExchangeRates] ([CID], [ExchangeTypeID], [RateDate], [ExchangeBuying], [ExchangeSelling], [EffectiveBuying], [EffectiveSelling]) VALUES (83, 1, CAST(0x0000A65700B42FF4 AS DateTime), 29905.0000, 29980.0000, 29926.0000, 30025.0000)
INSERT [dbo].[ExchangeRates] ([CID], [ExchangeTypeID], [RateDate], [ExchangeBuying], [ExchangeSelling], [EffectiveBuying], [EffectiveSelling]) VALUES (84, 2, CAST(0x0000A65700B430EA AS DateTime), 22497.0000, 22748.0000, 22601.0000, 22884.0000)
INSERT [dbo].[ExchangeRates] ([CID], [ExchangeTypeID], [RateDate], [ExchangeBuying], [ExchangeSelling], [EffectiveBuying], [EffectiveSelling]) VALUES (85, 3, CAST(0x0000A65700B430F2 AS DateTime), 44932.0000, 45184.0000, 44964.0000, 45288.0000)
INSERT [dbo].[ExchangeRates] ([CID], [ExchangeTypeID], [RateDate], [ExchangeBuying], [ExchangeSelling], [EffectiveBuying], [EffectiveSelling]) VALUES (86, 4, CAST(0x0000A65700B430F8 AS DateTime), 33478.0000, 33562.0000, 33501.0000, 33612.0000)
INSERT [dbo].[ExchangeRates] ([CID], [ExchangeTypeID], [RateDate], [ExchangeBuying], [ExchangeSelling], [EffectiveBuying], [EffectiveSelling]) VALUES (87, 5, CAST(0x0000A65700B430FC AS DateTime), 39489.0000, 39723.0000, 39517.0000, 39782.0000)
INSERT [dbo].[ExchangeRates] ([CID], [ExchangeTypeID], [RateDate], [ExchangeBuying], [ExchangeSelling], [EffectiveBuying], [EffectiveSelling]) VALUES (88, 6, CAST(0x0000A65700B430FF AS DateTime), 30852.0000, 31096.0000, 30898.0000, 31143.0000)
INSERT [dbo].[ExchangeRates] ([CID], [ExchangeTypeID], [RateDate], [ExchangeBuying], [ExchangeSelling], [EffectiveBuying], [EffectiveSelling]) VALUES (89, 1, CAST(0x0000A65700B43BA1 AS DateTime), 29905.0000, 29980.0000, 29926.0000, 30025.0000)
INSERT [dbo].[ExchangeRates] ([CID], [ExchangeTypeID], [RateDate], [ExchangeBuying], [ExchangeSelling], [EffectiveBuying], [EffectiveSelling]) VALUES (90, 2, CAST(0x0000A65700B43BB4 AS DateTime), 22497.0000, 22748.0000, 22601.0000, 22884.0000)
INSERT [dbo].[ExchangeRates] ([CID], [ExchangeTypeID], [RateDate], [ExchangeBuying], [ExchangeSelling], [EffectiveBuying], [EffectiveSelling]) VALUES (91, 3, CAST(0x0000A65700B43BB8 AS DateTime), 44932.0000, 45184.0000, 44964.0000, 45288.0000)
INSERT [dbo].[ExchangeRates] ([CID], [ExchangeTypeID], [RateDate], [ExchangeBuying], [ExchangeSelling], [EffectiveBuying], [EffectiveSelling]) VALUES (92, 4, CAST(0x0000A65700B43BBC AS DateTime), 33478.0000, 33562.0000, 33501.0000, 33612.0000)
INSERT [dbo].[ExchangeRates] ([CID], [ExchangeTypeID], [RateDate], [ExchangeBuying], [ExchangeSelling], [EffectiveBuying], [EffectiveSelling]) VALUES (93, 5, CAST(0x0000A65700B43BC0 AS DateTime), 39489.0000, 39723.0000, 39517.0000, 39782.0000)
INSERT [dbo].[ExchangeRates] ([CID], [ExchangeTypeID], [RateDate], [ExchangeBuying], [ExchangeSelling], [EffectiveBuying], [EffectiveSelling]) VALUES (94, 6, CAST(0x0000A65700B43BC4 AS DateTime), 30852.0000, 31096.0000, 30898.0000, 31143.0000)
SET IDENTITY_INSERT [dbo].[ExchangeRates] OFF
SET IDENTITY_INSERT [dbo].[ExchangeTypes] ON 

INSERT [dbo].[ExchangeTypes] ([RID], [ExchangeName], [ExchangeCode]) VALUES (1, N'ABD DOLARI                                        ', N'USD  ')
INSERT [dbo].[ExchangeTypes] ([RID], [ExchangeName], [ExchangeCode]) VALUES (2, N'AVUSTRALYA DOLARI                                 ', N'AUD  ')
INSERT [dbo].[ExchangeTypes] ([RID], [ExchangeName], [ExchangeCode]) VALUES (3, N'DANİMARKA KRONU                                   ', N'DKK  ')
INSERT [dbo].[ExchangeTypes] ([RID], [ExchangeName], [ExchangeCode]) VALUES (4, N'EURO                                              ', N'EUR  ')
INSERT [dbo].[ExchangeTypes] ([RID], [ExchangeName], [ExchangeCode]) VALUES (5, N'İNGİLİZ STERLİNİ                                  ', N'GBP  ')
INSERT [dbo].[ExchangeTypes] ([RID], [ExchangeName], [ExchangeCode]) VALUES (6, N'İSVİÇRE FRANGI                                    ', N'CHF  ')
SET IDENTITY_INSERT [dbo].[ExchangeTypes] OFF
ALTER TABLE [dbo].[ExchangeRates]  WITH CHECK ADD  CONSTRAINT [FK_ExchangeRates_ExchangeTypes] FOREIGN KEY([ExchangeTypeID])
REFERENCES [dbo].[ExchangeTypes] ([RID])
GO
ALTER TABLE [dbo].[ExchangeRates] CHECK CONSTRAINT [FK_ExchangeRates_ExchangeTypes]
GO
USE [master]
GO
ALTER DATABASE [CurrencyDataDB] SET  READ_WRITE 
GO
