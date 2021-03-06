USE [master]
GO
/****** Object:  Database [Jewelry]    Script Date: 25.05.2017 01:02:53 ******/
CREATE DATABASE [Jewelry]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Kuyumcu', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\Kuyumcu.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Kuyumcu_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\Kuyumcu_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Jewelry] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Jewelry].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Jewelry] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Jewelry] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Jewelry] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Jewelry] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Jewelry] SET ARITHABORT OFF 
GO
ALTER DATABASE [Jewelry] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Jewelry] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Jewelry] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Jewelry] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Jewelry] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Jewelry] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Jewelry] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Jewelry] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Jewelry] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Jewelry] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Jewelry] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Jewelry] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Jewelry] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Jewelry] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Jewelry] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Jewelry] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Jewelry] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Jewelry] SET RECOVERY FULL 
GO
ALTER DATABASE [Jewelry] SET  MULTI_USER 
GO
ALTER DATABASE [Jewelry] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Jewelry] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Jewelry] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Jewelry] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Jewelry] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Jewelry', N'ON'
GO
ALTER DATABASE [Jewelry] SET QUERY_STORE = OFF
GO
USE [Jewelry]
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [Jewelry]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 25.05.2017 01:02:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Address](
	[AddressID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NOT NULL,
	[Country] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[District] [nvarchar](50) NULL,
	[Address] [nvarchar](max) NULL,
	[AddedDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[DeletedDate] [datetime] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED 
(
	[AddressID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Categories]    Script Date: 25.05.2017 01:02:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](500) NULL,
	[Picture] [nvarchar](200) NULL,
	[AddedDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[DeletedDate] [datetime] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Kategoriler] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Comment]    Script Date: 25.05.2017 01:02:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comment](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ProductID] [int] NOT NULL,
	[CustomerID] [int] NOT NULL,
	[Content] [nvarchar](500) NULL,
	[IsActive] [bit] NULL,
	[AddedDate] [datetime] NULL,
 CONSTRAINT [PK_Comment] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Customer]    Script Date: 25.05.2017 01:02:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](60) NOT NULL,
	[Password] [nvarchar](20) NOT NULL,
	[IDNumber] [nvarchar](11) NULL,
	[BirthDate] [date] NULL,
	[Phone] [nvarchar](50) NULL,
	[AddedDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[DeletedDate] [datetime] NULL,
	[IsActive] [bit] NULL,
	[Role] [bit] NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FavoriteProduct]    Script Date: 25.05.2017 01:02:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FavoriteProduct](
	[ProductID] [int] NOT NULL,
	[CustomerID] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_FavoriteProduct] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC,
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Gem]    Script Date: 25.05.2017 01:02:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gem](
	[GemID] [int] IDENTITY(1,1) NOT NULL,
	[GemName] [nvarchar](50) NOT NULL,
	[GemWeight] [decimal](5, 2) NULL,
	[Colour] [nvarchar](50) NULL,
	[Shape] [nvarchar](50) NULL,
	[AddedDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[DeletedDate] [datetime] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_TasOzellik] PRIMARY KEY CLUSTERED 
(
	[GemID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Mine]    Script Date: 25.05.2017 01:02:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mine](
	[MineID] [int] IDENTITY(1,1) NOT NULL,
	[MineName] [nvarchar](50) NULL,
	[Carat] [nvarchar](10) NULL,
	[AddedDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[DeletedDate] [datetime] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_MadenOzellik] PRIMARY KEY CLUSTERED 
(
	[MineID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Order]    Script Date: 25.05.2017 01:02:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NOT NULL,
	[AddressID] [int] NOT NULL,
	[ShippedDate] [datetime] NULL,
	[OrderDate] [datetime] NULL,
	[IsActive] [bit] NULL,
	[AddedDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[DeletedDate] [datetime] NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 25.05.2017 01:02:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[OrderID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[Quantity] [smallint] NULL,
	[UnitPrice] [money] NULL,
	[AddedDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[DeletedDate] [datetime] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_OrderDeatils] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProductPictures]    Script Date: 25.05.2017 01:02:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductPictures](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ProductID] [int] NOT NULL,
	[PictureURL] [nvarchar](200) NULL,
	[AddedDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[DeletedDate] [datetime] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_ProductPictures] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Products]    Script Date: 25.05.2017 01:02:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[SubCategoryID] [int] NOT NULL,
	[ProductName] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](300) NULL,
	[UnitsInStock] [tinyint] NULL,
	[UnitPrice] [money] NOT NULL,
	[Discount] [decimal](4, 2) NULL,
	[Weight] [decimal](6, 3) NULL,
	[GemWeight] [decimal](5, 2) NULL,
	[ProductPhoto] [nvarchar](150) NULL,
	[AddedDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[DeletedDate] [datetime] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Urunler] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SubCategory]    Script Date: 25.05.2017 01:02:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubCategory](
	[SubCategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryID] [int] NOT NULL,
	[GemID] [int] NULL,
	[MineID] [int] NOT NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_CategoryOzellik] PRIMARY KEY CLUSTERED 
(
	[SubCategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Address] ON 

INSERT [dbo].[Address] ([AddressID], [CustomerID], [Country], [City], [District], [Address], [AddedDate], [UpdateDate], [DeletedDate], [IsActive]) VALUES (1, 1, N'Türkiye', N'Edirne', N'Merkez', N'Balıkpazarı cad.', CAST(N'2017-05-14T00:00:00.000' AS DateTime), CAST(N'2017-05-15T03:40:24.883' AS DateTime), NULL, 1)
INSERT [dbo].[Address] ([AddressID], [CustomerID], [Country], [City], [District], [Address], [AddedDate], [UpdateDate], [DeletedDate], [IsActive]) VALUES (2, 1, N'Türkiye', N'İstanbul', N'Bostancı', N'Akasyalı Sokak.', CAST(N'2017-05-15T03:40:43.170' AS DateTime), NULL, CAST(N'2017-05-15T03:40:56.727' AS DateTime), 0)
INSERT [dbo].[Address] ([AddressID], [CustomerID], [Country], [City], [District], [Address], [AddedDate], [UpdateDate], [DeletedDate], [IsActive]) VALUES (3, 1, N'Türkiye', N'asd', N'Bostancı', N'qweqweqwe', CAST(N'2017-05-15T17:07:05.887' AS DateTime), NULL, NULL, 1)
INSERT [dbo].[Address] ([AddressID], [CustomerID], [Country], [City], [District], [Address], [AddedDate], [UpdateDate], [DeletedDate], [IsActive]) VALUES (4, 2, N'Türkiye', N'Edirne', N'Küçükyalı', N'asdqwe', CAST(N'2017-05-15T17:07:48.320' AS DateTime), NULL, NULL, 1)
INSERT [dbo].[Address] ([AddressID], [CustomerID], [Country], [City], [District], [Address], [AddedDate], [UpdateDate], [DeletedDate], [IsActive]) VALUES (5, 3, N'Türkiye', N'Merkez', N'Merkez', N'asd', CAST(N'2017-05-15T17:09:23.593' AS DateTime), NULL, CAST(N'2017-05-15T17:12:18.017' AS DateTime), 0)
INSERT [dbo].[Address] ([AddressID], [CustomerID], [Country], [City], [District], [Address], [AddedDate], [UpdateDate], [DeletedDate], [IsActive]) VALUES (6, 3, N'Türkiye', N'asdasdad', N'asdasd', N'türk ocağı sokağı mithatpaşa mah. of sitesi c blok dai 4türk ocağı sokağı mithatpaşa mah. of sitesi c blok dai 4türk ocağı sokağı mithatpaşa mah. of sitesi c blok dai 4türk ocağı sokağı mithatpaşa mah. of sitesi c blok dai 4türk ocağı sokağı mithatpaşa mah. of sitesi c blok dai 4türk ocağı sokağı mithatpaşa mah. of sitesi c blok dai 4türk ocağı sokağı mithatpaşa mah. of sitesi c blok dai 4türk ocağı sokağı mithatpaşa mah. of sitesi c blok dai 4türk ocağı sokağı mithatpaşa mah. of sitesi c blok dai 4', CAST(N'2017-05-15T17:12:31.940' AS DateTime), NULL, CAST(N'2017-05-15T17:12:39.490' AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[Address] OFF
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [Description], [Picture], [AddedDate], [UpdateDate], [DeletedDate], [IsActive]) VALUES (1, N'Yüzük', N'qweqweqweqweqwe', N'http://i.hizliresim.com/DPOZN3.png ', NULL, CAST(N'2017-05-21T20:14:20.377' AS DateTime), NULL, 1)
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [Description], [Picture], [AddedDate], [UpdateDate], [DeletedDate], [IsActive]) VALUES (2, N'Kolye', N'22', N'http://i.hizliresim.com/aLnW64.png ', NULL, CAST(N'2017-05-24T11:08:49.910' AS DateTime), NULL, 1)
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [Description], [Picture], [AddedDate], [UpdateDate], [DeletedDate], [IsActive]) VALUES (3, N'Bilezik', N'qwe', N'http://i.hizliresim.com/gqPaEO.jpg ', NULL, NULL, NULL, 1)
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [Description], [Picture], [AddedDate], [UpdateDate], [DeletedDate], [IsActive]) VALUES (6, N'Küpe', N'azxc', N'http://i.hizliresim.com/EgOokz.png ', NULL, NULL, CAST(N'2017-05-21T20:14:55.463' AS DateTime), 0)
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [Description], [Picture], [AddedDate], [UpdateDate], [DeletedDate], [IsActive]) VALUES (7, N'Bileklik', N'zxzxcczxczzczczcx', N'http://i.hizliresim.com/37O0d0.png ', NULL, CAST(N'2017-05-21T20:14:39.207' AS DateTime), CAST(N'2017-05-17T01:41:50.913' AS DateTime), 0)
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [Description], [Picture], [AddedDate], [UpdateDate], [DeletedDate], [IsActive]) VALUES (8, N'Set', N'asd', NULL, CAST(N'2017-05-16T13:54:25.707' AS DateTime), NULL, CAST(N'2017-05-17T01:41:38.437' AS DateTime), 0)
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [Description], [Picture], [AddedDate], [UpdateDate], [DeletedDate], [IsActive]) VALUES (9, N'Setlik', N'asdqweqweq', NULL, CAST(N'2017-05-16T14:47:24.047' AS DateTime), NULL, CAST(N'2017-05-16T14:58:02.780' AS DateTime), 0)
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [Description], [Picture], [AddedDate], [UpdateDate], [DeletedDate], [IsActive]) VALUES (10, N'Güncel settir', N'qweqweqweqweqwe', NULL, CAST(N'2017-05-16T14:48:10.923' AS DateTime), CAST(N'2017-05-17T01:44:51.913' AS DateTime), CAST(N'2017-05-16T14:58:09.470' AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[Categories] OFF
SET IDENTITY_INSERT [dbo].[Comment] ON 

INSERT [dbo].[Comment] ([ID], [ProductID], [CustomerID], [Content], [IsActive], [AddedDate]) VALUES (1, 1, 1, N'Deneme 1 2 3 ', 1, CAST(N'2017-05-20T03:39:22.523' AS DateTime))
INSERT [dbo].[Comment] ([ID], [ProductID], [CustomerID], [Content], [IsActive], [AddedDate]) VALUES (2, 1, 1, N'Deneme 4 5  6', 1, CAST(N'2017-05-20T03:39:38.130' AS DateTime))
INSERT [dbo].[Comment] ([ID], [ProductID], [CustomerID], [Content], [IsActive], [AddedDate]) VALUES (3, 1, 1, N'HOP', 1, CAST(N'2017-05-20T03:40:04.023' AS DateTime))
INSERT [dbo].[Comment] ([ID], [ProductID], [CustomerID], [Content], [IsActive], [AddedDate]) VALUES (4, 1, 1, N'cek cek', 1, CAST(N'2017-05-20T03:40:15.450' AS DateTime))
INSERT [dbo].[Comment] ([ID], [ProductID], [CustomerID], [Content], [IsActive], [AddedDate]) VALUES (5, 1, 1, N'yorum ', 1, CAST(N'2017-05-21T19:42:36.383' AS DateTime))
INSERT [dbo].[Comment] ([ID], [ProductID], [CustomerID], [Content], [IsActive], [AddedDate]) VALUES (6, 1, 1, N'yorum asdasd', 1, CAST(N'2017-05-21T19:43:08.000' AS DateTime))
INSERT [dbo].[Comment] ([ID], [ProductID], [CustomerID], [Content], [IsActive], [AddedDate]) VALUES (7, 2, 2, N'asd', 1, CAST(N'2017-05-22T13:10:34.140' AS DateTime))
INSERT [dbo].[Comment] ([ID], [ProductID], [CustomerID], [Content], [IsActive], [AddedDate]) VALUES (8, 2, 2, N'xczxc', 1, CAST(N'2017-05-22T13:10:38.230' AS DateTime))
INSERT [dbo].[Comment] ([ID], [ProductID], [CustomerID], [Content], [IsActive], [AddedDate]) VALUES (9, 2, 2, N'qweqwe', 1, CAST(N'2017-05-22T13:10:44.597' AS DateTime))
INSERT [dbo].[Comment] ([ID], [ProductID], [CustomerID], [Content], [IsActive], [AddedDate]) VALUES (10, 2, 3, N's', 1, CAST(N'2017-05-22T13:11:04.317' AS DateTime))
INSERT [dbo].[Comment] ([ID], [ProductID], [CustomerID], [Content], [IsActive], [AddedDate]) VALUES (11, 2, 3, N'a', 1, CAST(N'2017-05-22T13:11:06.223' AS DateTime))
INSERT [dbo].[Comment] ([ID], [ProductID], [CustomerID], [Content], [IsActive], [AddedDate]) VALUES (12, 1, 3, N'cok güzel', 1, CAST(N'2017-05-22T16:33:56.680' AS DateTime))
INSERT [dbo].[Comment] ([ID], [ProductID], [CustomerID], [Content], [IsActive], [AddedDate]) VALUES (13, 1, 3, N'cok cok cok güzel', 1, CAST(N'2017-05-22T16:34:04.470' AS DateTime))
SET IDENTITY_INSERT [dbo].[Comment] OFF
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([CustomerID], [Name], [LastName], [Email], [Password], [IDNumber], [BirthDate], [Phone], [AddedDate], [UpdateDate], [DeletedDate], [IsActive], [Role]) VALUES (1, N'Onur', N'Şişoğlu', N'o@o.com', N'11', N'23126354155', CAST(N'1992-05-20' AS Date), N'33521456', NULL, CAST(N'2017-05-21T19:56:10.087' AS DateTime), NULL, 1, 1)
INSERT [dbo].[Customer] ([CustomerID], [Name], [LastName], [Email], [Password], [IDNumber], [BirthDate], [Phone], [AddedDate], [UpdateDate], [DeletedDate], [IsActive], [Role]) VALUES (2, N'Ali', N'Çetiner', N'a@a.com', N'2223', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Customer] ([CustomerID], [Name], [LastName], [Email], [Password], [IDNumber], [BirthDate], [Phone], [AddedDate], [UpdateDate], [DeletedDate], [IsActive], [Role]) VALUES (3, N'Hasancan', N'şişoğlu', N'h@c.com', N'123', NULL, NULL, NULL, CAST(N'2017-05-15T03:50:07.667' AS DateTime), NULL, NULL, 1, NULL)
SET IDENTITY_INSERT [dbo].[Customer] OFF
INSERT [dbo].[FavoriteProduct] ([ProductID], [CustomerID], [IsActive]) VALUES (1, 1, 0)
INSERT [dbo].[FavoriteProduct] ([ProductID], [CustomerID], [IsActive]) VALUES (2, 1, 1)
INSERT [dbo].[FavoriteProduct] ([ProductID], [CustomerID], [IsActive]) VALUES (3, 1, 1)
INSERT [dbo].[FavoriteProduct] ([ProductID], [CustomerID], [IsActive]) VALUES (7, 3, 0)
INSERT [dbo].[FavoriteProduct] ([ProductID], [CustomerID], [IsActive]) VALUES (16, 1, 1)
SET IDENTITY_INSERT [dbo].[Gem] ON 

INSERT [dbo].[Gem] ([GemID], [GemName], [GemWeight], [Colour], [Shape], [AddedDate], [UpdateDate], [DeletedDate], [IsActive]) VALUES (1, N'Safir', CAST(0.15 AS Decimal(5, 2)), N'G', N'a', NULL, NULL, NULL, NULL)
INSERT [dbo].[Gem] ([GemID], [GemName], [GemWeight], [Colour], [Shape], [AddedDate], [UpdateDate], [DeletedDate], [IsActive]) VALUES (2, N'Tektaş', CAST(0.10 AS Decimal(5, 2)), N'G', N'yuvarlak', NULL, CAST(N'2017-05-18T01:22:56.843' AS DateTime), CAST(N'2017-05-18T01:33:44.810' AS DateTime), 0)
INSERT [dbo].[Gem] ([GemID], [GemName], [GemWeight], [Colour], [Shape], [AddedDate], [UpdateDate], [DeletedDate], [IsActive]) VALUES (3, N'Beştaş', CAST(0.15 AS Decimal(5, 2)), N'G', N'kare', NULL, NULL, NULL, 1)
INSERT [dbo].[Gem] ([GemID], [GemName], [GemWeight], [Colour], [Shape], [AddedDate], [UpdateDate], [DeletedDate], [IsActive]) VALUES (4, N'Tria', CAST(0.15 AS Decimal(5, 2)), N'G', N'kare', NULL, NULL, NULL, 1)
INSERT [dbo].[Gem] ([GemID], [GemName], [GemWeight], [Colour], [Shape], [AddedDate], [UpdateDate], [DeletedDate], [IsActive]) VALUES (5, N'Tamtur', CAST(0.15 AS Decimal(5, 2)), N'G', N'a', NULL, CAST(N'2017-05-21T20:16:51.450' AS DateTime), NULL, 1)
INSERT [dbo].[Gem] ([GemID], [GemName], [GemWeight], [Colour], [Shape], [AddedDate], [UpdateDate], [DeletedDate], [IsActive]) VALUES (6, N'Fantazi', CAST(0.15 AS Decimal(5, 2)), N'G', N's', NULL, NULL, NULL, 1)
INSERT [dbo].[Gem] ([GemID], [GemName], [GemWeight], [Colour], [Shape], [AddedDate], [UpdateDate], [DeletedDate], [IsActive]) VALUES (7, N'Elmas', CAST(0.15 AS Decimal(5, 2)), N'G', N'e', NULL, NULL, NULL, 1)
INSERT [dbo].[Gem] ([GemID], [GemName], [GemWeight], [Colour], [Shape], [AddedDate], [UpdateDate], [DeletedDate], [IsActive]) VALUES (8, N'Yakut', CAST(0.15 AS Decimal(5, 2)), N'd', N's', NULL, NULL, NULL, 1)
INSERT [dbo].[Gem] ([GemID], [GemName], [GemWeight], [Colour], [Shape], [AddedDate], [UpdateDate], [DeletedDate], [IsActive]) VALUES (9, N'Zümrüt', CAST(0.15 AS Decimal(5, 2)), N'G', N't', NULL, NULL, NULL, 1)
INSERT [dbo].[Gem] ([GemID], [GemName], [GemWeight], [Colour], [Shape], [AddedDate], [UpdateDate], [DeletedDate], [IsActive]) VALUES (10, N'İnci', CAST(0.15 AS Decimal(5, 2)), N'G', N'e', NULL, NULL, NULL, 1)
INSERT [dbo].[Gem] ([GemID], [GemName], [GemWeight], [Colour], [Shape], [AddedDate], [UpdateDate], [DeletedDate], [IsActive]) VALUES (11, N'Kelepçe', CAST(0.15 AS Decimal(5, 2)), N'G', N'f', NULL, NULL, NULL, 1)
INSERT [dbo].[Gem] ([GemID], [GemName], [GemWeight], [Colour], [Shape], [AddedDate], [UpdateDate], [DeletedDate], [IsActive]) VALUES (12, N'Su Yolu', NULL, N'G', N'Düz', CAST(N'2017-05-17T16:24:37.817' AS DateTime), NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[Gem] OFF
SET IDENTITY_INSERT [dbo].[Mine] ON 

INSERT [dbo].[Mine] ([MineID], [MineName], [Carat], [AddedDate], [UpdateDate], [DeletedDate], [IsActive]) VALUES (1, N'Pırlanta', NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[Mine] ([MineID], [MineName], [Carat], [AddedDate], [UpdateDate], [DeletedDate], [IsActive]) VALUES (2, N'Altin', NULL, NULL, NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[Mine] OFF
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([OrderID], [CustomerID], [AddressID], [ShippedDate], [OrderDate], [IsActive], [AddedDate], [UpdateDate], [DeletedDate]) VALUES (1, 1, 1, CAST(N'2017-05-14T00:00:00.000' AS DateTime), CAST(N'2017-05-14T00:00:00.000' AS DateTime), 1, CAST(N'2017-05-14T00:00:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[Order] ([OrderID], [CustomerID], [AddressID], [ShippedDate], [OrderDate], [IsActive], [AddedDate], [UpdateDate], [DeletedDate]) VALUES (2, 1, 1, CAST(N'2017-05-23T18:20:39.670' AS DateTime), CAST(N'2017-05-18T18:20:39.670' AS DateTime), 1, CAST(N'2017-05-18T18:21:12.853' AS DateTime), NULL, NULL)
INSERT [dbo].[Order] ([OrderID], [CustomerID], [AddressID], [ShippedDate], [OrderDate], [IsActive], [AddedDate], [UpdateDate], [DeletedDate]) VALUES (3, 1, 1, CAST(N'2017-05-26T20:06:41.200' AS DateTime), CAST(N'2017-05-21T20:06:41.200' AS DateTime), 1, CAST(N'2017-05-21T20:07:03.980' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[Order] OFF
SET IDENTITY_INSERT [dbo].[OrderDetails] ON 

INSERT [dbo].[OrderDetails] ([ID], [OrderID], [ProductID], [Quantity], [UnitPrice], [AddedDate], [UpdateDate], [DeletedDate], [IsActive]) VALUES (1, 1, 2, 10, 100.0000, CAST(N'2017-05-14T00:00:00.000' AS DateTime), NULL, NULL, 1)
INSERT [dbo].[OrderDetails] ([ID], [OrderID], [ProductID], [Quantity], [UnitPrice], [AddedDate], [UpdateDate], [DeletedDate], [IsActive]) VALUES (2, 2, 11, 6, 250.0000, CAST(N'2017-05-18T00:00:00.000' AS DateTime), NULL, NULL, 1)
INSERT [dbo].[OrderDetails] ([ID], [OrderID], [ProductID], [Quantity], [UnitPrice], [AddedDate], [UpdateDate], [DeletedDate], [IsActive]) VALUES (3, 2, 10, 9, 110.0000, CAST(N'2017-05-18T00:00:00.000' AS DateTime), NULL, NULL, 1)
INSERT [dbo].[OrderDetails] ([ID], [OrderID], [ProductID], [Quantity], [UnitPrice], [AddedDate], [UpdateDate], [DeletedDate], [IsActive]) VALUES (8, 2, 21, 5, 50.0000, CAST(N'2017-05-18T00:00:00.000' AS DateTime), NULL, NULL, 1)
INSERT [dbo].[OrderDetails] ([ID], [OrderID], [ProductID], [Quantity], [UnitPrice], [AddedDate], [UpdateDate], [DeletedDate], [IsActive]) VALUES (9, 2, 25, 5, 750.0000, CAST(N'2017-05-18T00:00:00.000' AS DateTime), NULL, NULL, 1)
INSERT [dbo].[OrderDetails] ([ID], [OrderID], [ProductID], [Quantity], [UnitPrice], [AddedDate], [UpdateDate], [DeletedDate], [IsActive]) VALUES (10, 3, 1, 6, 200.0000, CAST(N'2017-05-21T00:00:00.000' AS DateTime), NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[OrderDetails] OFF
SET IDENTITY_INSERT [dbo].[ProductPictures] ON 

INSERT [dbo].[ProductPictures] ([ID], [ProductID], [PictureURL], [AddedDate], [UpdateDate], [DeletedDate], [IsActive]) VALUES (1, 1, N'http://i.hizliresim.com/ALG0GB.jpg', NULL, NULL, NULL, NULL)
INSERT [dbo].[ProductPictures] ([ID], [ProductID], [PictureURL], [AddedDate], [UpdateDate], [DeletedDate], [IsActive]) VALUES (2, 1, N'http://i.hizliresim.com/r3ymvV.jpg', NULL, NULL, NULL, NULL)
INSERT [dbo].[ProductPictures] ([ID], [ProductID], [PictureURL], [AddedDate], [UpdateDate], [DeletedDate], [IsActive]) VALUES (3, 2, N'http://i.hizliresim.com/ALG0br.jpg', CAST(N'2017-05-22T00:00:00.000' AS DateTime), NULL, NULL, 1)
INSERT [dbo].[ProductPictures] ([ID], [ProductID], [PictureURL], [AddedDate], [UpdateDate], [DeletedDate], [IsActive]) VALUES (4, 3, N'http://i.hizliresim.com/p02mAq.jpg', CAST(N'2017-05-22T00:00:00.000' AS DateTime), NULL, NULL, 1)
INSERT [dbo].[ProductPictures] ([ID], [ProductID], [PictureURL], [AddedDate], [UpdateDate], [DeletedDate], [IsActive]) VALUES (5, 3, N'http://i.hizliresim.com/8MX9Ok.jpg', CAST(N'2017-05-22T00:00:00.000' AS DateTime), NULL, NULL, 1)
INSERT [dbo].[ProductPictures] ([ID], [ProductID], [PictureURL], [AddedDate], [UpdateDate], [DeletedDate], [IsActive]) VALUES (6, 6, N'http://i.hizliresim.com/Qay45G.jpg', CAST(N'2017-05-22T00:00:00.000' AS DateTime), NULL, NULL, 1)
INSERT [dbo].[ProductPictures] ([ID], [ProductID], [PictureURL], [AddedDate], [UpdateDate], [DeletedDate], [IsActive]) VALUES (7, 6, N'http://i.hizliresim.com/5gqo0l.jpg', CAST(N'2017-05-22T00:00:00.000' AS DateTime), NULL, NULL, 1)
INSERT [dbo].[ProductPictures] ([ID], [ProductID], [PictureURL], [AddedDate], [UpdateDate], [DeletedDate], [IsActive]) VALUES (8, 7, N'http://i.hizliresim.com/GBGp7V.jpg', CAST(N'2017-05-22T00:00:00.000' AS DateTime), NULL, NULL, 1)
INSERT [dbo].[ProductPictures] ([ID], [ProductID], [PictureURL], [AddedDate], [UpdateDate], [DeletedDate], [IsActive]) VALUES (9, 7, N'http://i.hizliresim.com/R0GbAa.jpg', CAST(N'2017-05-22T00:00:00.000' AS DateTime), NULL, NULL, 1)
INSERT [dbo].[ProductPictures] ([ID], [ProductID], [PictureURL], [AddedDate], [UpdateDate], [DeletedDate], [IsActive]) VALUES (10, 9, N'http://i.hizliresim.com/1L72Wb.jpg', CAST(N'2017-05-22T00:00:00.000' AS DateTime), NULL, NULL, 1)
INSERT [dbo].[ProductPictures] ([ID], [ProductID], [PictureURL], [AddedDate], [UpdateDate], [DeletedDate], [IsActive]) VALUES (11, 10, N'http://i.hizliresim.com/P0GYWb.jpg', CAST(N'2017-05-22T00:00:00.000' AS DateTime), NULL, NULL, 1)
INSERT [dbo].[ProductPictures] ([ID], [ProductID], [PictureURL], [AddedDate], [UpdateDate], [DeletedDate], [IsActive]) VALUES (12, 11, N'http://i.hizliresim.com/R0Gbzo.jpg', CAST(N'2017-05-22T00:00:00.000' AS DateTime), NULL, NULL, 1)
INSERT [dbo].[ProductPictures] ([ID], [ProductID], [PictureURL], [AddedDate], [UpdateDate], [DeletedDate], [IsActive]) VALUES (13, 11, N'http://i.hizliresim.com/j8Avbg.jpg', CAST(N'2017-05-22T00:00:00.000' AS DateTime), NULL, NULL, 1)
INSERT [dbo].[ProductPictures] ([ID], [ProductID], [PictureURL], [AddedDate], [UpdateDate], [DeletedDate], [IsActive]) VALUES (14, 11, N'http://i.hizliresim.com/ZZnAoz.jpg', CAST(N'2017-05-22T00:00:00.000' AS DateTime), NULL, NULL, 1)
INSERT [dbo].[ProductPictures] ([ID], [ProductID], [PictureURL], [AddedDate], [UpdateDate], [DeletedDate], [IsActive]) VALUES (15, 12, N'http://i.hizliresim.com/yEjAk0.jpg', CAST(N'2017-05-22T00:00:00.000' AS DateTime), NULL, NULL, 1)
INSERT [dbo].[ProductPictures] ([ID], [ProductID], [PictureURL], [AddedDate], [UpdateDate], [DeletedDate], [IsActive]) VALUES (16, 13, N'http://i.hizliresim.com/p02mLL.jpg', CAST(N'2017-05-22T00:00:00.000' AS DateTime), NULL, NULL, 1)
INSERT [dbo].[ProductPictures] ([ID], [ProductID], [PictureURL], [AddedDate], [UpdateDate], [DeletedDate], [IsActive]) VALUES (17, 14, N'http://i.hizliresim.com/Eg2zkn.jpg', CAST(N'2017-05-22T00:00:00.000' AS DateTime), NULL, NULL, 1)
INSERT [dbo].[ProductPictures] ([ID], [ProductID], [PictureURL], [AddedDate], [UpdateDate], [DeletedDate], [IsActive]) VALUES (18, 14, N'http://i.hizliresim.com/V0BgmV.jpg', CAST(N'2017-05-22T00:00:00.000' AS DateTime), NULL, NULL, 1)
INSERT [dbo].[ProductPictures] ([ID], [ProductID], [PictureURL], [AddedDate], [UpdateDate], [DeletedDate], [IsActive]) VALUES (19, 15, N'http://i.hizliresim.com/2rPYAv.jpg', CAST(N'2017-05-22T00:00:00.000' AS DateTime), NULL, NULL, 1)
INSERT [dbo].[ProductPictures] ([ID], [ProductID], [PictureURL], [AddedDate], [UpdateDate], [DeletedDate], [IsActive]) VALUES (20, 16, N'http://i.hizliresim.com/ld40lb.jpg', CAST(N'2017-05-22T00:00:00.000' AS DateTime), NULL, NULL, 1)
INSERT [dbo].[ProductPictures] ([ID], [ProductID], [PictureURL], [AddedDate], [UpdateDate], [DeletedDate], [IsActive]) VALUES (21, 16, N'http://i.hizliresim.com/1L725p.jpg', CAST(N'2017-05-22T00:00:00.000' AS DateTime), NULL, NULL, 1)
INSERT [dbo].[ProductPictures] ([ID], [ProductID], [PictureURL], [AddedDate], [UpdateDate], [DeletedDate], [IsActive]) VALUES (22, 19, N'https://i.hizliresim.com/1LqnRj.jpg', CAST(N'2017-05-22T00:00:00.000' AS DateTime), NULL, NULL, 1)
INSERT [dbo].[ProductPictures] ([ID], [ProductID], [PictureURL], [AddedDate], [UpdateDate], [DeletedDate], [IsActive]) VALUES (23, 20, N'https://i.hizliresim.com/DPpkao.jpg', CAST(N'2017-05-22T00:00:00.000' AS DateTime), NULL, NULL, 1)
INSERT [dbo].[ProductPictures] ([ID], [ProductID], [PictureURL], [AddedDate], [UpdateDate], [DeletedDate], [IsActive]) VALUES (24, 21, N'https://i.hizliresim.com/7q584N.jpg', CAST(N'2017-05-22T00:00:00.000' AS DateTime), NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[ProductPictures] OFF
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([ProductID], [SubCategoryID], [ProductName], [Description], [UnitsInStock], [UnitPrice], [Discount], [Weight], [GemWeight], [ProductPhoto], [AddedDate], [UpdateDate], [DeletedDate], [IsActive]) VALUES (1, 2, N'Pırlanta  Tektaş Yüzük', N'denemeninki', 100, 200.0000, CAST(0.10 AS Decimal(4, 2)), CAST(2.000 AS Decimal(6, 3)), CAST(0.10 AS Decimal(5, 2)), N'http://i.hizliresim.com/ALG0GB.jpg', CAST(N'2017-05-14T00:00:00.000' AS DateTime), NULL, NULL, 1)
INSERT [dbo].[Products] ([ProductID], [SubCategoryID], [ProductName], [Description], [UnitsInStock], [UnitPrice], [Discount], [Weight], [GemWeight], [ProductPhoto], [AddedDate], [UpdateDate], [DeletedDate], [IsActive]) VALUES (2, 2, N'Pırlanta  Tektaş Yüzük', N's', 90, 100.0000, CAST(0.20 AS Decimal(4, 2)), CAST(2.300 AS Decimal(6, 3)), CAST(0.15 AS Decimal(5, 2)), N'http://i.hizliresim.com/ALG0br.jpg', NULL, NULL, NULL, 1)
INSERT [dbo].[Products] ([ProductID], [SubCategoryID], [ProductName], [Description], [UnitsInStock], [UnitPrice], [Discount], [Weight], [GemWeight], [ProductPhoto], [AddedDate], [UpdateDate], [DeletedDate], [IsActive]) VALUES (3, 2, N'Pırlanta  Tektaş Yüzük', N'a', 70, 250.0000, CAST(0.15 AS Decimal(4, 2)), CAST(2.200 AS Decimal(6, 3)), CAST(0.10 AS Decimal(5, 2)), N'http://i.hizliresim.com/p02mAq.jpg', NULL, NULL, NULL, 1)
INSERT [dbo].[Products] ([ProductID], [SubCategoryID], [ProductName], [Description], [UnitsInStock], [UnitPrice], [Discount], [Weight], [GemWeight], [ProductPhoto], [AddedDate], [UpdateDate], [DeletedDate], [IsActive]) VALUES (6, 3, N'Pırlanta  Beştaş Yüzük', N'x', 50, 200.0000, CAST(0.12 AS Decimal(4, 2)), CAST(2.000 AS Decimal(6, 3)), CAST(0.50 AS Decimal(5, 2)), N'http://i.hizliresim.com/Qay45G.jpg', NULL, NULL, NULL, 1)
INSERT [dbo].[Products] ([ProductID], [SubCategoryID], [ProductName], [Description], [UnitsInStock], [UnitPrice], [Discount], [Weight], [GemWeight], [ProductPhoto], [AddedDate], [UpdateDate], [DeletedDate], [IsActive]) VALUES (7, 3, N'Pırlanta  Beştaş Yüzük', N'b', 90, 350.0000, CAST(0.25 AS Decimal(4, 2)), CAST(2.000 AS Decimal(6, 3)), CAST(0.51 AS Decimal(5, 2)), N'http://i.hizliresim.com/GBGp7V.jpg', NULL, NULL, NULL, 1)
INSERT [dbo].[Products] ([ProductID], [SubCategoryID], [ProductName], [Description], [UnitsInStock], [UnitPrice], [Discount], [Weight], [GemWeight], [ProductPhoto], [AddedDate], [UpdateDate], [DeletedDate], [IsActive]) VALUES (9, 1, N'Pırlanta  Safir Yüzükk', N'xxxzzzsssaaa', 52, 25.0000, CAST(0.10 AS Decimal(4, 2)), CAST(1.750 AS Decimal(6, 3)), CAST(0.35 AS Decimal(5, 2)), N'http://i.hizliresim.com/1L72Wb.jpg', NULL, CAST(N'2017-05-24T12:04:18.690' AS DateTime), NULL, 1)
INSERT [dbo].[Products] ([ProductID], [SubCategoryID], [ProductName], [Description], [UnitsInStock], [UnitPrice], [Discount], [Weight], [GemWeight], [ProductPhoto], [AddedDate], [UpdateDate], [DeletedDate], [IsActive]) VALUES (10, 1, N'Pırlanta  Safir Yüzük', N'hgf', 60, 110.0000, NULL, CAST(1.200 AS Decimal(6, 3)), CAST(0.10 AS Decimal(5, 2)), N'http://i.hizliresim.com/P0GYWb.jpg', NULL, NULL, NULL, 1)
INSERT [dbo].[Products] ([ProductID], [SubCategoryID], [ProductName], [Description], [UnitsInStock], [UnitPrice], [Discount], [Weight], [GemWeight], [ProductPhoto], [AddedDate], [UpdateDate], [DeletedDate], [IsActive]) VALUES (11, 11, N'Pırlanta  Tektaş Kolye', N'z', 60, 250.0000, NULL, CAST(2.000 AS Decimal(6, 3)), CAST(0.70 AS Decimal(5, 2)), N'http://i.hizliresim.com/R0Gbzo.jpg', NULL, NULL, NULL, 1)
INSERT [dbo].[Products] ([ProductID], [SubCategoryID], [ProductName], [Description], [UnitsInStock], [UnitPrice], [Discount], [Weight], [GemWeight], [ProductPhoto], [AddedDate], [UpdateDate], [DeletedDate], [IsActive]) VALUES (12, 19, N'Pırlanta Fantazi Kolye', N'hg', 80, 200.0000, NULL, CAST(1.200 AS Decimal(6, 3)), CAST(0.20 AS Decimal(5, 2)), N'http://i.hizliresim.com/yEjAk0.jpg', NULL, NULL, NULL, 1)
INSERT [dbo].[Products] ([ProductID], [SubCategoryID], [ProductName], [Description], [UnitsInStock], [UnitPrice], [Discount], [Weight], [GemWeight], [ProductPhoto], [AddedDate], [UpdateDate], [DeletedDate], [IsActive]) VALUES (13, 10, N'Pırlanta Safir Kolye', N'as', 15, 200.0000, NULL, CAST(1.000 AS Decimal(6, 3)), CAST(1.00 AS Decimal(5, 2)), N'http://i.hizliresim.com/p02mLL.jpg', NULL, NULL, NULL, 1)
INSERT [dbo].[Products] ([ProductID], [SubCategoryID], [ProductName], [Description], [UnitsInStock], [UnitPrice], [Discount], [Weight], [GemWeight], [ProductPhoto], [AddedDate], [UpdateDate], [DeletedDate], [IsActive]) VALUES (14, 13, N'Elmas Kolye', N'a', 10, 600.0000, NULL, CAST(1.000 AS Decimal(6, 3)), CAST(1.00 AS Decimal(5, 2)), N'http://i.hizliresim.com/Eg2zkn.jpg', NULL, NULL, NULL, 1)
INSERT [dbo].[Products] ([ProductID], [SubCategoryID], [ProductName], [Description], [UnitsInStock], [UnitPrice], [Discount], [Weight], [GemWeight], [ProductPhoto], [AddedDate], [UpdateDate], [DeletedDate], [IsActive]) VALUES (15, 14, N'Pırlanta Yakut Kolye', N'zxc', 35, 300.0000, NULL, CAST(1.000 AS Decimal(6, 3)), CAST(1.00 AS Decimal(5, 2)), N'http://i.hizliresim.com/2rPYAv.jpg', NULL, NULL, NULL, 1)
INSERT [dbo].[Products] ([ProductID], [SubCategoryID], [ProductName], [Description], [UnitsInStock], [UnitPrice], [Discount], [Weight], [GemWeight], [ProductPhoto], [AddedDate], [UpdateDate], [DeletedDate], [IsActive]) VALUES (16, 2, N'Pırlanta  Tektaş Yüzük', N'tyurtew', 200, 10.0000, CAST(0.70 AS Decimal(4, 2)), CAST(1.000 AS Decimal(6, 3)), CAST(1.00 AS Decimal(5, 2)), N'http://i.hizliresim.com/ld40lb.jpg', NULL, NULL, NULL, 1)
INSERT [dbo].[Products] ([ProductID], [SubCategoryID], [ProductName], [Description], [UnitsInStock], [UnitPrice], [Discount], [Weight], [GemWeight], [ProductPhoto], [AddedDate], [UpdateDate], [DeletedDate], [IsActive]) VALUES (19, 20, N'Bilmemne Bilezik', N'eqasdadfsasdf', 100, 200.0000, NULL, CAST(1.000 AS Decimal(6, 3)), CAST(1.00 AS Decimal(5, 2)), N'https://i.hizliresim.com/1LqnRj.jpg', NULL, NULL, NULL, 1)
INSERT [dbo].[Products] ([ProductID], [SubCategoryID], [ProductName], [Description], [UnitsInStock], [UnitPrice], [Discount], [Weight], [GemWeight], [ProductPhoto], [AddedDate], [UpdateDate], [DeletedDate], [IsActive]) VALUES (20, 16, N'Altın Olacak Kolye', N'Altın gibi Maşallah', 35, 100.0000, NULL, CAST(0.100 AS Decimal(6, 3)), CAST(1.00 AS Decimal(5, 2)), N'https://i.hizliresim.com/DPpkao.jpg', NULL, NULL, NULL, 1)
INSERT [dbo].[Products] ([ProductID], [SubCategoryID], [ProductName], [Description], [UnitsInStock], [UnitPrice], [Discount], [Weight], [GemWeight], [ProductPhoto], [AddedDate], [UpdateDate], [DeletedDate], [IsActive]) VALUES (21, 17, N'Pırlanta Küpe', N'ads', 30, 10.0000, NULL, CAST(1.000 AS Decimal(6, 3)), CAST(1.00 AS Decimal(5, 2)), N'https://i.hizliresim.com/7q584N.jpg', NULL, NULL, NULL, 1)
INSERT [dbo].[Products] ([ProductID], [SubCategoryID], [ProductName], [Description], [UnitsInStock], [UnitPrice], [Discount], [Weight], [GemWeight], [ProductPhoto], [AddedDate], [UpdateDate], [DeletedDate], [IsActive]) VALUES (23, 16, N'Altın Kolye', N'altın işte ', 15, 150.0000, NULL, NULL, NULL, NULL, CAST(N'2017-05-15T00:54:43.523' AS DateTime), NULL, NULL, 1)
INSERT [dbo].[Products] ([ProductID], [SubCategoryID], [ProductName], [Description], [UnitsInStock], [UnitPrice], [Discount], [Weight], [GemWeight], [ProductPhoto], [AddedDate], [UpdateDate], [DeletedDate], [IsActive]) VALUES (24, 16, N'İsimli Kolye(Onur)', N'altın işte ', 15, 150.0000, NULL, NULL, NULL, NULL, CAST(N'2017-05-15T00:57:09.480' AS DateTime), NULL, NULL, 1)
INSERT [dbo].[Products] ([ProductID], [SubCategoryID], [ProductName], [Description], [UnitsInStock], [UnitPrice], [Discount], [Weight], [GemWeight], [ProductPhoto], [AddedDate], [UpdateDate], [DeletedDate], [IsActive]) VALUES (25, 21, N'Altın Kolye', N'Güzel bilezik', 15, 150.0000, NULL, NULL, NULL, NULL, CAST(N'2017-05-17T02:12:08.203' AS DateTime), NULL, NULL, 1)
INSERT [dbo].[Products] ([ProductID], [SubCategoryID], [ProductName], [Description], [UnitsInStock], [UnitPrice], [Discount], [Weight], [GemWeight], [ProductPhoto], [AddedDate], [UpdateDate], [DeletedDate], [IsActive]) VALUES (26, 21, N'Altın Kolye', N'Güzel bilezik', 15, 150.0000, NULL, NULL, NULL, NULL, CAST(N'2017-05-17T02:12:10.760' AS DateTime), NULL, NULL, 1)
INSERT [dbo].[Products] ([ProductID], [SubCategoryID], [ProductName], [Description], [UnitsInStock], [UnitPrice], [Discount], [Weight], [GemWeight], [ProductPhoto], [AddedDate], [UpdateDate], [DeletedDate], [IsActive]) VALUES (27, 22, N'Alinin Kolyesi', N'qwe', 10, 2500.0000, NULL, NULL, NULL, NULL, CAST(N'2017-05-17T02:13:19.730' AS DateTime), NULL, NULL, 1)
INSERT [dbo].[Products] ([ProductID], [SubCategoryID], [ProductName], [Description], [UnitsInStock], [UnitPrice], [Discount], [Weight], [GemWeight], [ProductPhoto], [AddedDate], [UpdateDate], [DeletedDate], [IsActive]) VALUES (28, 22, N'Alinin Kolyesi', N'qwe', 10, 2500.0000, NULL, NULL, NULL, NULL, CAST(N'2017-05-17T02:13:19.767' AS DateTime), NULL, NULL, 1)
INSERT [dbo].[Products] ([ProductID], [SubCategoryID], [ProductName], [Description], [UnitsInStock], [UnitPrice], [Discount], [Weight], [GemWeight], [ProductPhoto], [AddedDate], [UpdateDate], [DeletedDate], [IsActive]) VALUES (29, 8, N'Yakut Yüzük', N'y', 35, 2500.0000, NULL, NULL, NULL, NULL, CAST(N'2017-05-17T16:06:03.737' AS DateTime), NULL, NULL, 1)
INSERT [dbo].[Products] ([ProductID], [SubCategoryID], [ProductName], [Description], [UnitsInStock], [UnitPrice], [Discount], [Weight], [GemWeight], [ProductPhoto], [AddedDate], [UpdateDate], [DeletedDate], [IsActive]) VALUES (30, 23, N'Set Kolye Bilezik Yüzük', N'asd', 10, 150.0000, NULL, NULL, NULL, NULL, CAST(N'2017-05-17T16:07:46.100' AS DateTime), NULL, NULL, 1)
INSERT [dbo].[Products] ([ProductID], [SubCategoryID], [ProductName], [Description], [UnitsInStock], [UnitPrice], [Discount], [Weight], [GemWeight], [ProductPhoto], [AddedDate], [UpdateDate], [DeletedDate], [IsActive]) VALUES (31, 25, N'Set', N'asdqweqweq', 12, 1.0000, NULL, NULL, NULL, NULL, CAST(N'2017-05-17T16:10:51.997' AS DateTime), NULL, NULL, 1)
INSERT [dbo].[Products] ([ProductID], [SubCategoryID], [ProductName], [Description], [UnitsInStock], [UnitPrice], [Discount], [Weight], [GemWeight], [ProductPhoto], [AddedDate], [UpdateDate], [DeletedDate], [IsActive]) VALUES (32, 27, N'Su Yolu Bileklik', N'altın işte ', 10, 12.0000, NULL, NULL, NULL, NULL, CAST(N'2017-05-21T20:41:06.843' AS DateTime), NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[Products] OFF
SET IDENTITY_INSERT [dbo].[SubCategory] ON 

INSERT [dbo].[SubCategory] ([SubCategoryID], [CategoryID], [GemID], [MineID], [IsActive]) VALUES (1, 1, 1, 1, 1)
INSERT [dbo].[SubCategory] ([SubCategoryID], [CategoryID], [GemID], [MineID], [IsActive]) VALUES (2, 1, 2, 1, 1)
INSERT [dbo].[SubCategory] ([SubCategoryID], [CategoryID], [GemID], [MineID], [IsActive]) VALUES (3, 1, 3, 1, 1)
INSERT [dbo].[SubCategory] ([SubCategoryID], [CategoryID], [GemID], [MineID], [IsActive]) VALUES (4, 1, 4, 1, 1)
INSERT [dbo].[SubCategory] ([SubCategoryID], [CategoryID], [GemID], [MineID], [IsActive]) VALUES (5, 1, 5, 1, 1)
INSERT [dbo].[SubCategory] ([SubCategoryID], [CategoryID], [GemID], [MineID], [IsActive]) VALUES (6, 1, 6, 1, 1)
INSERT [dbo].[SubCategory] ([SubCategoryID], [CategoryID], [GemID], [MineID], [IsActive]) VALUES (7, 1, 7, 1, 1)
INSERT [dbo].[SubCategory] ([SubCategoryID], [CategoryID], [GemID], [MineID], [IsActive]) VALUES (8, 1, 8, 1, 1)
INSERT [dbo].[SubCategory] ([SubCategoryID], [CategoryID], [GemID], [MineID], [IsActive]) VALUES (9, 1, 9, 1, 1)
INSERT [dbo].[SubCategory] ([SubCategoryID], [CategoryID], [GemID], [MineID], [IsActive]) VALUES (10, 2, 1, 1, 1)
INSERT [dbo].[SubCategory] ([SubCategoryID], [CategoryID], [GemID], [MineID], [IsActive]) VALUES (11, 2, 2, 1, 1)
INSERT [dbo].[SubCategory] ([SubCategoryID], [CategoryID], [GemID], [MineID], [IsActive]) VALUES (12, 2, 3, 1, 1)
INSERT [dbo].[SubCategory] ([SubCategoryID], [CategoryID], [GemID], [MineID], [IsActive]) VALUES (13, 2, 7, 1, 1)
INSERT [dbo].[SubCategory] ([SubCategoryID], [CategoryID], [GemID], [MineID], [IsActive]) VALUES (14, 2, 8, 1, 1)
INSERT [dbo].[SubCategory] ([SubCategoryID], [CategoryID], [GemID], [MineID], [IsActive]) VALUES (15, 2, 9, 1, 1)
INSERT [dbo].[SubCategory] ([SubCategoryID], [CategoryID], [GemID], [MineID], [IsActive]) VALUES (16, 2, NULL, 2, 1)
INSERT [dbo].[SubCategory] ([SubCategoryID], [CategoryID], [GemID], [MineID], [IsActive]) VALUES (17, 6, 2, 1, 1)
INSERT [dbo].[SubCategory] ([SubCategoryID], [CategoryID], [GemID], [MineID], [IsActive]) VALUES (18, 1, NULL, 2, 1)
INSERT [dbo].[SubCategory] ([SubCategoryID], [CategoryID], [GemID], [MineID], [IsActive]) VALUES (19, 2, 6, 1, 1)
INSERT [dbo].[SubCategory] ([SubCategoryID], [CategoryID], [GemID], [MineID], [IsActive]) VALUES (20, 3, NULL, 2, 1)
INSERT [dbo].[SubCategory] ([SubCategoryID], [CategoryID], [GemID], [MineID], [IsActive]) VALUES (21, 8, 10, 1, 1)
INSERT [dbo].[SubCategory] ([SubCategoryID], [CategoryID], [GemID], [MineID], [IsActive]) VALUES (22, 9, 10, 1, 1)
INSERT [dbo].[SubCategory] ([SubCategoryID], [CategoryID], [GemID], [MineID], [IsActive]) VALUES (23, 9, 2, 2, 1)
INSERT [dbo].[SubCategory] ([SubCategoryID], [CategoryID], [GemID], [MineID], [IsActive]) VALUES (25, 10, NULL, 2, 1)
INSERT [dbo].[SubCategory] ([SubCategoryID], [CategoryID], [GemID], [MineID], [IsActive]) VALUES (27, 7, 12, 2, 1)
SET IDENTITY_INSERT [dbo].[SubCategory] OFF
ALTER TABLE [dbo].[Comment] ADD  CONSTRAINT [DF_Comment_AddedDate]  DEFAULT (getdate()) FOR [AddedDate]
GO
ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [DF_Products_AddedDate]  DEFAULT (getdate()) FOR [AddedDate]
GO
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK_Address_Customer] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([CustomerID])
GO
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK_Address_Customer]
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_Comment_Customer] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([CustomerID])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_Comment_Customer]
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_Comment_Products] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductID])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_Comment_Products]
GO
ALTER TABLE [dbo].[FavoriteProduct]  WITH CHECK ADD  CONSTRAINT [FK_FavoriteProduct_Customer] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([CustomerID])
GO
ALTER TABLE [dbo].[FavoriteProduct] CHECK CONSTRAINT [FK_FavoriteProduct_Customer]
GO
ALTER TABLE [dbo].[FavoriteProduct]  WITH CHECK ADD  CONSTRAINT [FK_FavoriteProduct_Products] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductID])
GO
ALTER TABLE [dbo].[FavoriteProduct] CHECK CONSTRAINT [FK_FavoriteProduct_Products]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Address] FOREIGN KEY([AddressID])
REFERENCES [dbo].[Address] ([AddressID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Address]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Customer1] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([CustomerID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Customer1]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDeatils_Order] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Order] ([OrderID])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDeatils_Order]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDeatils_Products] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductID])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDeatils_Products]
GO
ALTER TABLE [dbo].[ProductPictures]  WITH CHECK ADD  CONSTRAINT [FK_ProductPictures_Products1] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductID])
GO
ALTER TABLE [dbo].[ProductPictures] CHECK CONSTRAINT [FK_ProductPictures_Products1]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_SubCategory] FOREIGN KEY([SubCategoryID])
REFERENCES [dbo].[SubCategory] ([SubCategoryID])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_SubCategory]
GO
ALTER TABLE [dbo].[SubCategory]  WITH CHECK ADD  CONSTRAINT [FK_SubCategory_Categories] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Categories] ([CategoryID])
GO
ALTER TABLE [dbo].[SubCategory] CHECK CONSTRAINT [FK_SubCategory_Categories]
GO
ALTER TABLE [dbo].[SubCategory]  WITH CHECK ADD  CONSTRAINT [FK_SubCategory_Gem] FOREIGN KEY([GemID])
REFERENCES [dbo].[Gem] ([GemID])
GO
ALTER TABLE [dbo].[SubCategory] CHECK CONSTRAINT [FK_SubCategory_Gem]
GO
ALTER TABLE [dbo].[SubCategory]  WITH CHECK ADD  CONSTRAINT [FK_SubCategory_Mine] FOREIGN KEY([MineID])
REFERENCES [dbo].[Mine] ([MineID])
GO
ALTER TABLE [dbo].[SubCategory] CHECK CONSTRAINT [FK_SubCategory_Mine]
GO
USE [master]
GO
ALTER DATABASE [Jewelry] SET  READ_WRITE 
GO
