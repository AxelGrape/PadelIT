USE [master]
GO
/****** Object:  Database [spelarbasen]    Script Date: 2023-10-08 14:59:38 ******/
CREATE DATABASE [spelarbasen]
GO
ALTER DATABASE [spelarbasen] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [spelarbasen].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [spelarbasen] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [spelarbasen] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [spelarbasen] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [spelarbasen] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [spelarbasen] SET ARITHABORT OFF 
GO
ALTER DATABASE [spelarbasen] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [spelarbasen] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [spelarbasen] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [spelarbasen] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [spelarbasen] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [spelarbasen] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [spelarbasen] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [spelarbasen] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [spelarbasen] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [spelarbasen] SET  ENABLE_BROKER 
GO
ALTER DATABASE [spelarbasen] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [spelarbasen] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [spelarbasen] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [spelarbasen] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [spelarbasen] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [spelarbasen] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [spelarbasen] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [spelarbasen] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [spelarbasen] SET  MULTI_USER 
GO
ALTER DATABASE [spelarbasen] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [spelarbasen] SET DB_CHAINING OFF 
GO
ALTER DATABASE [spelarbasen] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [spelarbasen] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [spelarbasen] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [spelarbasen] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [spelarbasen] SET QUERY_STORE = ON
GO
ALTER DATABASE [spelarbasen] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [spelarbasen]
GO
/****** Object:  Table [dbo].[Players]    Script Date: 2023-10-08 14:59:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Players](
	[PlayerId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
 CONSTRAINT [PK_Players] PRIMARY KEY CLUSTERED 
(
	[PlayerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bookings]    Script Date: 2023-10-08 14:59:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bookings](
	[BookingId] [int] IDENTITY(1,1) NOT NULL,
	[Datetime] [datetime] NOT NULL,
	[PlayerId] [int] NOT NULL,
 CONSTRAINT [PK_Bookings] PRIMARY KEY CLUSTERED 
(
	[BookingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[BookingView]    Script Date: 2023-10-08 14:59:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[BookingView]
AS
SELECT        b.Datetime, p.Name, p.PlayerId
FROM            dbo.Bookings AS b INNER JOIN
                         dbo.Players AS p ON b.PlayerId = p.PlayerId
GO
ALTER TABLE [dbo].[Bookings]  WITH CHECK ADD  CONSTRAINT [FK_Bookings_Players] FOREIGN KEY([PlayerId])
REFERENCES [dbo].[Players] ([PlayerId])
GO
ALTER TABLE [dbo].[Bookings] CHECK CONSTRAINT [FK_Bookings_Players]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
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
         Begin Table = "b"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 119
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "p"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 102
               Right = 416
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'BookingView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'BookingView'
GO
USE [master]
GO
ALTER DATABASE [spelarbasen] SET  READ_WRITE 
GO
