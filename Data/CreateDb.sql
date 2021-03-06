/*    ==Scripting Parameters==

    Source Server Version : SQL Server 2016 (13.0.4001)
    Source Database Engine Edition : Microsoft SQL Server Enterprise Edition
    Source Database Engine Type : Standalone SQL Server

    Target Server Version : SQL Server 2014
    Target Database Engine Edition : Microsoft SQL Server Standard Edition
    Target Database Engine Type : Standalone SQL Server
*/

/****** Object:  Table [dbo].[Address]    Script Date: 2017/10/30 09:54:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Address](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AddressTypeId] [int] NULL,
	[ClientId] [int] NULL,
	[UnitNo] [nvarchar](20) NULL,
	[ComplexName] [nvarchar](100) NULL,
	[StreetNo] [nvarchar](20) NULL,
	[StreetName] [nvarchar](100) NOT NULL,
	[Suburb] [nvarchar](100) NOT NULL,
	[City] [nvarchar](100) NULL,
	[PostalZipCode] [nvarchar](20) NULL,
 CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 2017/10/30 09:54:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GivenName] [nvarchar](100) NOT NULL,
	[FamilyName] [nvarchar](100) NULL,
	[GenderId] [int] NOT NULL,
	[DateOfBirth] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contact]    Script Date: 2017/10/30 09:54:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contact](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ContactType] [varchar](20) NOT NULL,
	[ClientId] [int] NOT NULL,
	[ContactDetail] [varbinary](50) NOT NULL,
 CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Gender]    Script Date: 2017/10/30 09:54:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gender](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Gender] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Client] ON 
GO
INSERT [dbo].[Client] ([Id], [GivenName], [FamilyName], [GenderId], [DateOfBirth]) VALUES (58, N'Cindy', N'Gotham', 3, CAST(N'2010-03-02T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Client] ([Id], [GivenName], [FamilyName], [GenderId], [DateOfBirth]) VALUES (57, N'Jane', N'Smith', 1, CAST(N'2000-08-06T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Client] ([Id], [GivenName], [FamilyName], [GenderId], [DateOfBirth]) VALUES (59, N'Jeanette', N'Andrews', 1, CAST(N'2019-07-06T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Client] ([Id], [GivenName], [FamilyName], [GenderId], [DateOfBirth]) VALUES (56, N'Roger', N'Smith', 2, CAST(N'1980-04-16T00:00:00.0000000' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[Client] OFF
GO
INSERT [dbo].[Gender] ([Id], [Name]) VALUES (0, N'Unknown')
GO
INSERT [dbo].[Gender] ([Id], [Name]) VALUES (1, N'Female')
GO
INSERT [dbo].[Gender] ([Id], [Name]) VALUES (2, N'Male')
GO
INSERT [dbo].[Gender] ([Id], [Name]) VALUES (3, N'Withheld')
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UX_Client]    Script Date: 2017/10/30 09:54:49 ******/
ALTER TABLE [dbo].[Client] ADD  CONSTRAINT [UX_Client] UNIQUE NONCLUSTERED 
(
	[GivenName] ASC,
	[FamilyName] ASC,
	[DateOfBirth] ASC,
	[GenderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK_Address_Client] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Client] ([Id])
GO
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK_Address_Client]
GO
ALTER TABLE [dbo].[Client]  WITH CHECK ADD  CONSTRAINT [FK_Client_Gender] FOREIGN KEY([GenderId])
REFERENCES [dbo].[Gender] ([Id])
GO
ALTER TABLE [dbo].[Client] CHECK CONSTRAINT [FK_Client_Gender]
GO
ALTER TABLE [dbo].[Contact]  WITH CHECK ADD  CONSTRAINT [FK_Contact_Client] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Client] ([Id])
GO
ALTER TABLE [dbo].[Contact] CHECK CONSTRAINT [FK_Contact_Client]
GO
