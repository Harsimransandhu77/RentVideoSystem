USE [master]
GO
/****** Object:  Database [BookDB]    Script Date: 04-08-2021 2.51.06 AM ******/
CREATE DATABASE [BookDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BookDB_Data', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\BookDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'BookDB_Log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\BookDB.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [BookDB] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BookDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BookDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BookDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BookDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BookDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BookDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [BookDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BookDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BookDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BookDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BookDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BookDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BookDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BookDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BookDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BookDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BookDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BookDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BookDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BookDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BookDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BookDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BookDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BookDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BookDB] SET  MULTI_USER 
GO
ALTER DATABASE [BookDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BookDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BookDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BookDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [BookDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BookDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'BookDB', N'ON'
GO
ALTER DATABASE [BookDB] SET QUERY_STORE = OFF
GO
USE [BookDB]
GO
/****** Object:  Table [dbo].[BookingDetails]    Script Date: 04-08-2021 2.51.07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookingDetails](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CID] [int] NOT NULL,
	[VID] [int] NOT NULL,
	[Start] [varchar](50) NULL,
	[Due] [varchar](50) NULL,
	[Status] [varchar](50) NULL,
	[Cost] [int] NULL,
 CONSTRAINT [PK_Booking] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VideoDetails]    Script Date: 04-08-2021 2.51.07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VideoDetails](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](50) NULL,
	[Genre] [varchar](50) NULL,
	[Language] [varchar](50) NULL,
	[Cost] [varchar](50) NULL,
	[Copies] [int] NULL,
	[PublishYear] [varchar](50) NULL,
 CONSTRAINT [PK_Video] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[RentedVideo]    Script Date: 04-08-2021 2.51.07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[RentedVideo]
AS
SELECT dbo.BookingDetails.VID AS ID, dbo.VideoDetails.Title, dbo.VideoDetails.Genre, dbo.VideoDetails.Cost, dbo.VideoDetails.Copies, dbo.VideoDetails.Language, dbo.VideoDetails.PublishYear
FROM   dbo.BookingDetails INNER JOIN
             dbo.VideoDetails ON dbo.BookingDetails.VID = dbo.VideoDetails.ID
GO
/****** Object:  Table [dbo].[CustomerDetails]    Script Date: 04-08-2021 2.51.07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerDetails](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Phone] [varchar](50) NULL,
	[Address] [varchar](50) NULL,
	[JoinDate] [varchar](50) NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[BookingDetails] ON 

INSERT [dbo].[BookingDetails] ([ID], [CID], [VID], [Start], [Due], [Status], [Cost]) VALUES (17, 9, 10, N'02 August 21', N'02 August 21', N'Issue', 0)
INSERT [dbo].[BookingDetails] ([ID], [CID], [VID], [Start], [Due], [Status], [Cost]) VALUES (27, 9, 13, N'02 August 21', N'03 August 21', N'Return', 5)
SET IDENTITY_INSERT [dbo].[BookingDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[CustomerDetails] ON 

INSERT [dbo].[CustomerDetails] ([ID], [Name], [Phone], [Address], [JoinDate]) VALUES (9, N'Customer-1', N'12345679', N'City', N'31-Jul-21')
INSERT [dbo].[CustomerDetails] ([ID], [Name], [Phone], [Address], [JoinDate]) VALUES (16, N'Customer-2', N'123456', N'City', N'02-Aug-21')
INSERT [dbo].[CustomerDetails] ([ID], [Name], [Phone], [Address], [JoinDate]) VALUES (17, N'Customer-3', N'12345', N'City', N'02-Aug-21')
INSERT [dbo].[CustomerDetails] ([ID], [Name], [Phone], [Address], [JoinDate]) VALUES (18, N'Customer-4', N'12345678', N'City', N'02-Aug-21')
SET IDENTITY_INSERT [dbo].[CustomerDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[VideoDetails] ON 

INSERT [dbo].[VideoDetails] ([ID], [Title], [Genre], [Language], [Cost], [Copies], [PublishYear]) VALUES (13, N'Avenger', N'Action', N'English', N'5', 2, N'2021')
INSERT [dbo].[VideoDetails] ([ID], [Title], [Genre], [Language], [Cost], [Copies], [PublishYear]) VALUES (14, N'Iron Man', N'Action', N'English', N'5', 5, N'2021')
INSERT [dbo].[VideoDetails] ([ID], [Title], [Genre], [Language], [Cost], [Copies], [PublishYear]) VALUES (15, N'Captain America', N'Action', N'English', N'5', 10, N'2021')
SET IDENTITY_INSERT [dbo].[VideoDetails] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Customer_1]    Script Date: 04-08-2021 2.51.07 AM ******/
ALTER TABLE [dbo].[CustomerDetails] ADD  CONSTRAINT [IX_Customer_1] UNIQUE NONCLUSTERED 
(
	[Phone] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[getBooking]    Script Date: 04-08-2021 2.51.07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[getBooking] 
AS
BEGIN
	SET NOCOUNT ON;
	SELECT b.CID as 'CID',b.VID as 'VID', b.ID as 'ID',c.Name as 'Customer',v.Title as 'Video',v.Cost as 'Cost',b.Start as 'Booking Date',b.Due as 'Return Date', b.Status as 'Status'
	from BookingDetails b,VideoDetails v,CustomerDetails c where b.CID=c.ID and b.VID=v.ID;
END
GO
/****** Object:  StoredProcedure [dbo].[getCustomer]    Script Date: 04-08-2021 2.51.07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[getCustomer]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT ID,Name,Phone,Address,JoinDate from CustomerDetails;
END
GO
/****** Object:  StoredProcedure [dbo].[getVideo]    Script Date: 04-08-2021 2.51.07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[getVideo] 
AS
BEGIN
	SET NOCOUNT ON;
	SELECT ID,Title,Genre,Language,Cost+' $' as 'Cost',Copies,PublishYear from VideoDetails;
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[26] 2[15] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "BookingDetails"
            Begin Extent = 
               Top = 9
               Left = 57
               Bottom = 206
               Right = 279
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "VideoDetails"
            Begin Extent = 
               Top = 9
               Left = 336
               Bottom = 206
               Right = 558
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'RentedVideo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'RentedVideo'
GO
USE [master]
GO
ALTER DATABASE [BookDB] SET  READ_WRITE 
GO
