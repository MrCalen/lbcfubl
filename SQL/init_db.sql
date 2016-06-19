USE [master]
GO
/****** Object:  Database [lbcfubl]    Script Date: 19/06/2016 23:00:40 ******/
CREATE DATABASE [lbcfubl]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'lbcfubl', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.CALENSERVER\MSSQL\DATA\lbcfubl.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'lbcfubl_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.CALENSERVER\MSSQL\DATA\lbcfubl_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [lbcfubl] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [lbcfubl].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [lbcfubl] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [lbcfubl] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [lbcfubl] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [lbcfubl] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [lbcfubl] SET ARITHABORT OFF 
GO
ALTER DATABASE [lbcfubl] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [lbcfubl] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [lbcfubl] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [lbcfubl] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [lbcfubl] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [lbcfubl] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [lbcfubl] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [lbcfubl] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [lbcfubl] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [lbcfubl] SET  DISABLE_BROKER 
GO
ALTER DATABASE [lbcfubl] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [lbcfubl] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [lbcfubl] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [lbcfubl] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [lbcfubl] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [lbcfubl] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [lbcfubl] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [lbcfubl] SET RECOVERY FULL 
GO
ALTER DATABASE [lbcfubl] SET  MULTI_USER 
GO
ALTER DATABASE [lbcfubl] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [lbcfubl] SET DB_CHAINING OFF 
GO
ALTER DATABASE [lbcfubl] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [lbcfubl] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [lbcfubl] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'lbcfubl', N'ON'
GO
USE [lbcfubl]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 19/06/2016 23:00:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[Account](
	[login] [varchar](8) NOT NULL,
	[argent] [float] NOT NULL,
	[date] [datetime] NOT NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Product]    Script Date: 19/06/2016 23:00:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Product](
	[id] [uniqueidentifier] NOT NULL,
	[name] [varchar](50) NOT NULL,
	[description] [varchar](255) NULL,
	[cost_without_margin] [float] NOT NULL,
	[cost_with_margin] [float] NOT NULL,
	[cost_HT] [float] NULL,
	[taxe] [float] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Purchase]    Script Date: 19/06/2016 23:00:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Purchase](
	[login] [varchar](8) NOT NULL,
	[date] [datetime] NOT NULL,
	[id_prod] [uniqueidentifier] NOT NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Purchase] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Shopping]    Script Date: 19/06/2016 23:00:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shopping](
	[id] [uniqueidentifier] NOT NULL,
	[date] [datetime] NOT NULL,
 CONSTRAINT [PK_Shopping] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Shopping_Product]    Script Date: 19/06/2016 23:00:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shopping_Product](
	[id_shopping] [uniqueidentifier] NOT NULL,
	[id_product] [uniqueidentifier] NOT NULL,
	[number] [int] NOT NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Shopping_Product] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 19/06/2016 23:00:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[login] [varchar](8) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[role] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[login] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_Accompte_User] FOREIGN KEY([login])
REFERENCES [dbo].[User] ([login])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_Accompte_User]
GO
ALTER TABLE [dbo].[Purchase]  WITH CHECK ADD  CONSTRAINT [FK_Purchase_Product] FOREIGN KEY([id_prod])
REFERENCES [dbo].[Product] ([id])
GO
ALTER TABLE [dbo].[Purchase] CHECK CONSTRAINT [FK_Purchase_Product]
GO
ALTER TABLE [dbo].[Purchase]  WITH CHECK ADD  CONSTRAINT [FK_Purchase_User] FOREIGN KEY([login])
REFERENCES [dbo].[User] ([login])
GO
ALTER TABLE [dbo].[Purchase] CHECK CONSTRAINT [FK_Purchase_User]
GO
ALTER TABLE [dbo].[Shopping_Product]  WITH CHECK ADD  CONSTRAINT [FK_Shopping_Product_Product] FOREIGN KEY([id_product])
REFERENCES [dbo].[Product] ([id])
GO
ALTER TABLE [dbo].[Shopping_Product] CHECK CONSTRAINT [FK_Shopping_Product_Product]
GO
ALTER TABLE [dbo].[Shopping_Product]  WITH CHECK ADD  CONSTRAINT [FK_Shopping_Product_Shopping] FOREIGN KEY([id_shopping])
REFERENCES [dbo].[Shopping] ([id])
GO
ALTER TABLE [dbo].[Shopping_Product] CHECK CONSTRAINT [FK_Shopping_Product_Shopping]
GO
/****** Object:  StoredProcedure [dbo].[Get_User_Depenses]    Script Date: 19/06/2016 23:00:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Get_User_Depenses]
	-- Add the parameters for the stored procedure here
	@user_login varchar(8)
AS
BEGIN
	SELECT SUM(Product.cost_with_margin) FROM dbo.Purchase
	INNER JOIN dbo.Product ON Product.id = Purchase.id_prod
	WHERE Purchase.login LIKE @user_login
END


GO
/****** Object:  StoredProcedure [dbo].[Get_User_Money]    Script Date: 19/06/2016 23:00:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Get_User_Money]
	-- Add the parameters for the stored procedure here
	@user_login varchar(8)
AS
BEGIN
	SELECT (SELECT ISNULL(SUM(Account.argent), 0) FROM Account WHERE Account.login LIKE @user_login) - ISNULL(SUM(Product.cost_with_margin), 0) FROM dbo.[User]
	INNER JOIN dbo.Purchase ON [User].login = Purchase.login
	INNER JOIN dbo.Product ON Product.id = Purchase.id_prod
	WHERE [User].login LIKE @user_login
END


GO
/****** Object:  StoredProcedure [dbo].[Get_Users_Money]    Script Date: 19/06/2016 23:00:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Get_Users_Money]
AS
BEGIN
	SELECT [User].login, (SELECT SUM(Account.argent) FROM Account WHERE Account.login LIKE [User].login) - SUM(Product.cost_with_margin) FROM dbo.[User]
	INNER JOIN dbo.Purchase ON [User].login = Purchase.login
	INNER JOIN dbo.Product ON Product.id = Purchase.id_prod
	GROUP BY [User].login
END


GO
USE [master]
GO
ALTER DATABASE [lbcfubl] SET  READ_WRITE 
GO
