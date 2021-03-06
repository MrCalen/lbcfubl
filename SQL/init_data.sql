USE [lbcfubl]
GO
INSERT [dbo].[Product] ([id], [name], [description], [cost_without_margin], [cost_with_margin], [cost_HT], [taxe]) VALUES (N'8efe8e26-f45d-4720-8446-03a443f74884', N'Coca zéro', N'Boisson', 0.4699999988079071, 0.60000002384185791, NULL, NULL)
INSERT [dbo].[Product] ([id], [name], [description], [cost_without_margin], [cost_with_margin], [cost_HT], [taxe]) VALUES (N'052a4af2-abbc-411f-b4b0-5bc874309ebc', N'Bouteille d''eau', N'Boisson', 0.18000000715255737, 0.30000001192092896, NULL, NULL)
INSERT [dbo].[Product] ([id], [name], [description], [cost_without_margin], [cost_with_margin], [cost_HT], [taxe]) VALUES (N'c95401a3-885f-4697-bbaa-710b30368fee', N'Coca normal', N'Boisson', 0.49000000953674316, 0.60000002384185791, NULL, NULL)
INSERT [dbo].[Product] ([id], [name], [description], [cost_without_margin], [cost_with_margin], [cost_HT], [taxe]) VALUES (N'80485a62-cdc6-4c0c-85ef-aab9bdfdc965', N'RedBull', N'Boisson', 1.1499999761581421, 1.2000000476837158, NULL, NULL)
INSERT [dbo].[Product] ([id], [name], [description], [cost_without_margin], [cost_with_margin], [cost_HT], [taxe]) VALUES (N'f20ad3b4-bed8-410f-975a-adae971d6682', N'Kinder Bueno', N'Kinder Bueno', 0.5899999737739563, 0.60000002384185791, NULL, NULL)
INSERT [dbo].[Product] ([id], [name], [description], [cost_without_margin], [cost_with_margin], [cost_HT], [taxe]) VALUES (N'ba5167f0-ca74-4187-8fa5-e77fc4292d9a', N'Twix', N'barre choco', 0.5, 0.7, 0.4, 5.5)
INSERT [dbo].[User] ([login], [password], [role]) VALUES (N'admin', N'21232F297A57A5A743894A0E4A801FC3', 3)
INSERT [dbo].[User] ([login], [password], [role]) VALUES (N'maurer_h', N'F1F58E8C06B2A61CE13E0C0AA9473A72', 3)
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([login], [argent], [date], [id]) VALUES (N'maurer_h', 5, CAST(N'2015-04-28T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Account] ([login], [argent], [date], [id]) VALUES (N'admin', 20, CAST(N'2015-05-01T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Account] ([login], [argent], [date], [id]) VALUES (N'maurer_h', 145, CAST(N'2015-05-10T00:00:00.000' AS DateTime), 3)
SET IDENTITY_INSERT [dbo].[Account] OFF
SET IDENTITY_INSERT [dbo].[Purchase] ON 

INSERT [dbo].[Purchase] ([login], [date], [id_prod], [id]) VALUES (N'maurer_h', CAST(N'2016-05-15T00:00:00.000' AS DateTime), N'8efe8e26-f45d-4720-8446-03a443f74884', 1)
INSERT [dbo].[Purchase] ([login], [date], [id_prod], [id]) VALUES (N'maurer_h', CAST(N'2016-05-15T00:00:00.000' AS DateTime), N'f20ad3b4-bed8-410f-975a-adae971d6682', 2)
INSERT [dbo].[Purchase] ([login], [date], [id_prod], [id]) VALUES (N'maurer_h', CAST(N'2016-05-15T00:00:00.000' AS DateTime), N'052a4af2-abbc-411f-b4b0-5bc874309ebc', 3)
INSERT [dbo].[Purchase] ([login], [date], [id_prod], [id]) VALUES (N'maurer_h', CAST(N'2016-05-16T00:00:00.000' AS DateTime), N'052a4af2-abbc-411f-b4b0-5bc874309ebc', 4)
INSERT [dbo].[Purchase] ([login], [date], [id_prod], [id]) VALUES (N'admin', CAST(N'2016-05-16T00:00:00.000' AS DateTime), N'052a4af2-abbc-411f-b4b0-5bc874309ebc', 5)
INSERT [dbo].[Purchase] ([login], [date], [id_prod], [id]) VALUES (N'maurer_h', CAST(N'2016-05-17T00:00:00.000' AS DateTime), N'052a4af2-abbc-411f-b4b0-5bc874309ebc', 6)
INSERT [dbo].[Purchase] ([login], [date], [id_prod], [id]) VALUES (N'admin', CAST(N'2016-05-17T00:00:00.000' AS DateTime), N'80485a62-cdc6-4c0c-85ef-aab9bdfdc965', 7)
INSERT [dbo].[Purchase] ([login], [date], [id_prod], [id]) VALUES (N'admin', CAST(N'2016-05-17T00:00:00.000' AS DateTime), N'80485a62-cdc6-4c0c-85ef-aab9bdfdc965', 8)
INSERT [dbo].[Purchase] ([login], [date], [id_prod], [id]) VALUES (N'admin', CAST(N'2016-05-17T00:00:00.000' AS DateTime), N'f20ad3b4-bed8-410f-975a-adae971d6682', 9)
SET IDENTITY_INSERT [dbo].[Purchase] OFF
