USE [lbcfubl]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 20/06/2016 19:50:56 ******/
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
/****** Object:  Table [dbo].[Product]    Script Date: 20/06/2016 19:50:56 ******/
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
/****** Object:  Table [dbo].[Purchase]    Script Date: 20/06/2016 19:50:56 ******/
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
/****** Object:  Table [dbo].[Shopping]    Script Date: 20/06/2016 19:50:56 ******/
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
/****** Object:  Table [dbo].[Shopping_Product]    Script Date: 20/06/2016 19:50:56 ******/
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
/****** Object:  Table [dbo].[User]    Script Date: 20/06/2016 19:50:56 ******/
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
GO
ALTER TABLE [dbo].[Purchase] CHECK CONSTRAINT [FK_Purchase_Product]
GO
ALTER TABLE [dbo].[Purchase]  WITH CHECK ADD  CONSTRAINT [FK_Purchase_User] FOREIGN KEY([login])
REFERENCES [dbo].[User] ([login])
GO
ALTER TABLE [dbo].[Purchase] CHECK CONSTRAINT [FK_Purchase_User]
GO
ALTER TABLE [dbo].[Purchase]  WITH CHECK ADD  CONSTRAINT [FK_Purchase_User1] FOREIGN KEY([added_by])
REFERENCES [dbo].[User] ([login])
GO
ALTER TABLE [dbo].[Purchase] CHECK CONSTRAINT [FK_Purchase_User1]
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
/****** Object:  StoredProcedure [dbo].[Get_User_Depenses]    Script Date: 20/06/2016 19:50:56 ******/
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
/****** Object:  StoredProcedure [dbo].[Get_User_Money]    Script Date: 20/06/2016 19:50:56 ******/
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
/****** Object:  StoredProcedure [dbo].[Get_Users_Money]    Script Date: 20/06/2016 19:50:56 ******/
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
