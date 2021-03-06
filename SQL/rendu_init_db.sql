USE [master]
GO
/****** Object:  Database [lbcfubl]    Script Date: 02/07/2016 02:45:06 ******/
CREATE DATABASE [lbcfubl]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'lbcfubl', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.MTI\MSSQL\DATA\lbcfubl.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'lbcfubl_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.MTI\MSSQL\DATA\lbcfubl_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
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
ALTER DATABASE [lbcfubl] SET RECOVERY SIMPLE 
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
USE [lbcfubl]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 02/07/2016 02:45:06 ******/
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
/****** Object:  Table [dbo].[Product]    Script Date: 02/07/2016 02:45:06 ******/
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
/****** Object:  Table [dbo].[Purchase]    Script Date: 02/07/2016 02:45:06 ******/
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
	[added_by] [varchar](8) NULL,
 CONSTRAINT [PK_Purchase] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Shopping]    Script Date: 02/07/2016 02:45:06 ******/
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
/****** Object:  Table [dbo].[Shopping_Product]    Script Date: 02/07/2016 02:45:06 ******/
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
/****** Object:  Table [dbo].[User]    Script Date: 02/07/2016 02:45:06 ******/
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
	[is_blocked] [int] NULL,
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
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Purchase] CHECK CONSTRAINT [FK_Purchase_Product]
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
/****** Object:  StoredProcedure [dbo].[Get_Purchase_Total]    Script Date: 02/07/2016 02:45:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Get_Purchase_Total]
	@id uniqueidentifier
AS
BEGIN
	SELECT SUM(Product.cost_with_margin * Shopping_Product.number)
	FROM Product
	INNER JOIN Shopping_Product on Shopping_Product.id_product = Product.id
	INNER JOIN Shopping on Shopping.id = Shopping_Product.id_shopping
	WHERE Shopping.id = @id
END





GO
/****** Object:  StoredProcedure [dbo].[Get_Stock_For_Date]    Script Date: 02/07/2016 02:45:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Get_Stock_For_Date]
	-- Add the parameters for the stored procedure here
	@datett datetime
AS
BEGIN
	SELECT p.name, sum(sp.number) as bought,
	(
		SELECT count(pu.id) as consummed
		FROM dbo.Purchase pu
		INNER JOIN dbo.Product p2 ON p2.id = pu.id_prod
		WHERE p2.name = p.name AND pu.date <= @datett
		AND NOT (pu.login LIKE 'lab')
		) consummed
	FROM dbo.Product p
	INNER JOIN dbo.Shopping_Product sp ON sp.id_product = p.id
	INNER JOIN dbo.Shopping sh ON sp.id_shopping = sh.id
	WHERE sh.date <= @datett
	GROUP BY p.name
END



GO
/****** Object:  StoredProcedure [dbo].[Get_User_Account_Day_History]    Script Date: 02/07/2016 02:45:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Get_User_Account_Day_History]
	@login varchar(8)
AS
BEGIN
	SELECT [User].login,
			SUM(a.argent) as day_account,
			ISNULL((SELECT SUM(b.argent)
					FROM Account b
					WHERE YEAR(b.date) <= YEAR(a.date)
					AND MONTH(b.date) <= MONTH(a.date)
					AND DAY(b.date) <= DAY(a.date)
					AND b.login LIKE @login
			), 0) as total_account,
			MONTH(a.date) as 'month',
			YEAR(a.date) as 'year',
			DAY(a.date) as 'day'
	FROM Account a
	INNER JOIN dbo.[User] ON a.login = [User].login
	WHERE a.login LIKE @login
	GROUP BY MONTH(a.date), YEAR(a.date), DAY(a.date), [User].login
END





GO
/****** Object:  StoredProcedure [dbo].[Get_User_Account_History]    Script Date: 02/07/2016 02:45:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Get_User_Account_History]
	@login varchar(8)
AS
BEGIN
	SELECT [User].login,
			SUM(a.argent) as month_account,
			ISNULL((SELECT SUM(b.argent)
					FROM Account b
					WHERE YEAR(b.date) <= YEAR(a.date)
					AND MONTH(b.date) <= MONTH(a.date)
					AND b.login LIKE @login
			), 0) as total_account,
			MONTH(a.date) as 'month',
			YEAR(a.date) as 'year'
	FROM Account a
	INNER JOIN dbo.[User] ON a.login = [User].login
	WHERE a.login LIKE @login
	GROUP BY MONTH(a.date), YEAR(a.date), [User].login
END





GO
/****** Object:  StoredProcedure [dbo].[Get_User_Depenses]    Script Date: 02/07/2016 02:45:06 ******/
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
/****** Object:  StoredProcedure [dbo].[Get_User_Money]    Script Date: 02/07/2016 02:45:06 ******/
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
/****** Object:  StoredProcedure [dbo].[Get_User_Money_History]    Script Date: 02/07/2016 02:45:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Get_User_Money_History]
	@login varchar(8)
AS
BEGIN
	WITH Purchase_History_T AS
	(
		SELECT [User].login,
			ISNULL((SELECT SUM(Product.cost_with_margin) 
					FROM Purchase b
					INNER JOIN Product ON Product.id = b.id_prod
					WHERE b.login LIKE @login
					AND MONTH(b.date) = MONTH(a.date)
					AND YEAR(b.date) = YEAR(a.date)
			), 0) as month_purchase,
			ISNULL((SELECT SUM(Product.cost_with_margin) 
					FROM Purchase b
					INNER JOIN Product ON Product.id = b.id_prod
					WHERE b.login LIKE @login
					AND MONTH(b.date) <= MONTH(a.date)
					AND YEAR(b.date) <= YEAR(a.date)
			), 0) as total_purchase,
			MONTH(a.date) as 'month_p',
			YEAR(a.date) as 'year_p'
		FROM Purchase a
		INNER JOIN dbo.[User] ON a.login = [User].login
		WHERE a.login LIKE @login
		GROUP BY MONTH(a.date), YEAR(a.date), [User].login
	)
	SELECT a.login,
			SUM(a.argent) as month_account,
			ISNULL((SELECT SUM(b.argent)
					FROM Account b
					WHERE YEAR(b.date) <= YEAR(a.date)
					AND MONTH(b.date) <= MONTH(a.date)
					AND b.login LIKE @login
			), 0) as total_account,
			Purchase_History_T.month_purchase,
			Purchase_History_T.total_purchase,
			Purchase_History_T.month_p,
			Purchase_History_T.year_p,
			MONTH(a.date) as 'month',
			YEAR(a.date) as 'year'
	FROM Account a
	FULL JOIN Purchase_History_T ON Purchase_History_T.month_p = MONTH(a.date) AND Purchase_History_T.year_p = YEAR(a.date)
	WHERE a.login LIKE @login
	GROUP BY MONTH(a.date), YEAR(a.date), a.login, Purchase_History_T.month_purchase, Purchase_History_T.total_purchase, Purchase_History_T.month_p, Purchase_History_T.year_p
END





GO
/****** Object:  StoredProcedure [dbo].[Get_User_Purchase_Day_History]    Script Date: 02/07/2016 02:45:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Get_User_Purchase_Day_History]
	@login varchar(8)
AS
BEGIN
	SELECT [User].login,
			ISNULL((SELECT SUM(Product.cost_with_margin) 
					FROM Purchase b
					INNER JOIN Product ON Product.id = b.id_prod
					WHERE b.login LIKE @login
					AND DAY(b.date) = DAY(a.date)
					AND MONTH(b.date) = MONTH(a.date)
					AND YEAR(b.date) = YEAR(a.date)
			), 0) as day_purchase,
			ISNULL((SELECT SUM(Product.cost_with_margin) 
					FROM Purchase b
					INNER JOIN Product ON Product.id = b.id_prod
					WHERE b.login LIKE @login
					AND DAY(b.date) <= DAY(a.date)
					AND MONTH(b.date) <= MONTH(a.date)
					AND YEAR(b.date) <= YEAR(a.date)
			), 0) as total_purchase,
			DAY(a.date) as 'day',
			MONTH(a.date) as 'month',
			YEAR(a.date) as 'year'
	FROM Purchase a
	INNER JOIN dbo.[User] ON a.login = [User].login
	WHERE a.login LIKE @login
	GROUP BY DAY(a.date), MONTH(a.date), YEAR(a.date), [User].login
END





GO
/****** Object:  StoredProcedure [dbo].[Get_User_Purchase_History]    Script Date: 02/07/2016 02:45:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Get_User_Purchase_History]
	@login varchar(8)
AS
BEGIN
	SELECT [User].login,
			ISNULL((SELECT SUM(Product.cost_with_margin) 
					FROM Purchase b
					INNER JOIN Product ON Product.id = b.id_prod
					WHERE b.login LIKE @login
					AND MONTH(b.date) = MONTH(a.date)
					AND YEAR(b.date) = YEAR(a.date)
			), 0) as month_purchase,
			ISNULL((SELECT SUM(Product.cost_with_margin) 
					FROM Purchase b
					INNER JOIN Product ON Product.id = b.id_prod
					WHERE b.login LIKE @login
					AND MONTH(b.date) <= MONTH(a.date)
					AND YEAR(b.date) <= YEAR(a.date)
			), 0) as total_purchase,
			MONTH(a.date) as 'month',
			YEAR(a.date) as 'year'
	FROM Purchase a
	INNER JOIN dbo.[User] ON a.login = [User].login
	WHERE a.login LIKE @login
	GROUP BY MONTH(a.date), YEAR(a.date), [User].login
END





GO
/****** Object:  StoredProcedure [dbo].[Get_Users_Accounts_Day_History]    Script Date: 02/07/2016 02:45:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Get_Users_Accounts_Day_History]
AS
BEGIN
	SELECT	SUM(a.argent) as day_account,
			ISNULL((SELECT SUM(b.argent)
					FROM Account b
					WHERE YEAR(b.date) <= YEAR(a.date)
					AND MONTH(b.date) <= MONTH(a.date)
					AND DAY(b.date) <= DAY(a.date)
			), 0) as total_account,
			MONTH(a.date) as 'month',
			YEAR(a.date) as 'year',
			DAY(a.date) as 'day'
	FROM Account a
	GROUP BY MONTH(a.date), YEAR(a.date), DAY(a.date)
END





GO
/****** Object:  StoredProcedure [dbo].[Get_Users_Accounts_History]    Script Date: 02/07/2016 02:45:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Get_Users_Accounts_History]
AS
BEGIN
	SELECT	SUM(a.argent) as month_account,
			ISNULL((SELECT SUM(b.argent)
					FROM Account b
					WHERE YEAR(b.date) <= YEAR(a.date)
					AND MONTH(b.date) <= MONTH(a.date)
			), 0) as total_account,
			MONTH(a.date) as 'month',
			YEAR(a.date) as 'year'
	FROM Account a
	GROUP BY MONTH(a.date), YEAR(a.date)
END





GO
/****** Object:  StoredProcedure [dbo].[Get_Users_Money]    Script Date: 02/07/2016 02:45:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Get_Users_Money]
AS
BEGIN
	SELECT [User].login, (SELECT ISNULL(SUM(Account.argent),0) FROM Account WHERE Account.login LIKE [User].login) - ISNULL(SUM(Product.cost_with_margin),0) as money FROM dbo.[User]
	LEFT JOIN dbo.Purchase ON [User].login = Purchase.login
	LEFT JOIN dbo.Product ON Product.id = Purchase.id_prod
	GROUP BY [User].login
END





GO
/****** Object:  StoredProcedure [dbo].[Get_Users_Purchases_Day_History]    Script Date: 02/07/2016 02:45:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Get_Users_Purchases_Day_History]
AS
BEGIN
	SELECT ISNULL((SELECT SUM(Product.cost_with_margin) 
					FROM Purchase b
					INNER JOIN Product ON Product.id = b.id_prod
					AND MONTH(b.date) = MONTH(a.date)
					AND YEAR(b.date) = YEAR(a.date)
					AND DAY(b.date) = DAY(a.date)
			), 0) as day_purchase,
			ISNULL((SELECT SUM(Product.cost_with_margin) 
					FROM Purchase b
					INNER JOIN Product ON Product.id = b.id_prod
					AND MONTH(b.date) <= MONTH(a.date)
					AND YEAR(b.date) <= YEAR(a.date)
					AND Day(b.date) <= DAY(a.date)
			), 0) as total_purchase,
			MONTH(a.date) as 'month',
			YEAR(a.date) as 'year',
			DAY(a.date) as 'day'
	FROM Purchase a
	GROUP BY MONTH(a.date), YEAR(a.date), DAY(a.date)
END





GO
/****** Object:  StoredProcedure [dbo].[Get_Users_Purchases_History]    Script Date: 02/07/2016 02:45:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Get_Users_Purchases_History]
AS
BEGIN
	SELECT ISNULL((SELECT SUM(Product.cost_with_margin) 
					FROM Purchase b
					INNER JOIN Product ON Product.id = b.id_prod
					AND MONTH(b.date) = MONTH(a.date)
					AND YEAR(b.date) = YEAR(a.date)
			), 0) as month_purchase,
			ISNULL((SELECT SUM(Product.cost_with_margin) 
					FROM Purchase b
					INNER JOIN Product ON Product.id = b.id_prod
					AND MONTH(b.date) <= MONTH(a.date)
					AND YEAR(b.date) <= YEAR(a.date)
			), 0) as total_purchase,
			MONTH(a.date) as 'month',
			YEAR(a.date) as 'year'
	FROM Purchase a
	GROUP BY MONTH(a.date), YEAR(a.date)
END





GO
USE [master]
GO
ALTER DATABASE [lbcfubl] SET  READ_WRITE 
GO
