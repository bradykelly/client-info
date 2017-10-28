DELETE FROM Gender
SET IDENTITY_INSERT [dbo].[Gender] ON 
INSERT [dbo].[Gender] ([Id], [Name]) VALUES (1, N'Female')
INSERT [dbo].[Gender] ([Id], [Name]) VALUES (2, N'Male')
INSERT [dbo].[Gender] ([Id], [Name]) VALUES (3, N'Withheld')
SET IDENTITY_INSERT [dbo].[Gender] OFF
