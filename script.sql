USE [dbWithoutBorder]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 23.01.2020 10:31:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tBonus]    Script Date: 23.01.2020 10:31:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tBonus](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[description] [nchar](10) NULL,
	[percentBonus] [float] NOT NULL,
 CONSTRAINT [PK_tBonus] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tContract]    Script Date: 23.01.2020 10:31:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tContract](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idUser] [int] NOT NULL,
	[idDevice] [int] NULL,
	[idBonus] [int] NULL,
	[idOperator] [int] NOT NULL,
	[conlusionDate] [datetime] NOT NULL,
	[price] [float] NOT NULL,
	[idTarif] [int] NULL,
 CONSTRAINT [PK_tContract] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tDevice]    Script Date: 23.01.2020 10:31:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tDevice](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idManufacture] [int] NOT NULL,
	[idTypeDevice] [int] NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[price] [float] NOT NULL,
	[image] [varbinary](max) NOT NULL,
 CONSTRAINT [PK_tDevice] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tInfoDevice]    Script Date: 23.01.2020 10:31:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tInfoDevice](
	[id] [int] NOT NULL,
 CONSTRAINT [PK_tInfoDevice] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tManufacture]    Script Date: 23.01.2020 10:31:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tManufacture](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[description] [nvarchar](max) NULL,
 CONSTRAINT [PK_tManufacture] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tNumber]    Script Date: 23.01.2020 10:31:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tNumber](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[phone] [nvarchar](50) NOT NULL,
	[status] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_tNumber] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tNumberUser]    Script Date: 23.01.2020 10:31:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tNumberUser](
	[idNumber] [int] NOT NULL,
	[idUser] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tRole]    Script Date: 23.01.2020 10:31:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tRole](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_tRole] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tSpec]    Script Date: 23.01.2020 10:31:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tSpec](
	[idUser] [int] NOT NULL,
	[title] [nvarchar](50) NULL,
 CONSTRAINT [PK_tSpec] PRIMARY KEY CLUSTERED 
(
	[idUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tTarif]    Script Date: 23.01.2020 10:31:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tTarif](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[description] [nvarchar](50) NULL,
	[price] [float] NOT NULL,
 CONSTRAINT [PK_tTarif] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tTypeDevice]    Script Date: 23.01.2020 10:31:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tTypeDevice](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[description] [nvarchar](max) NULL,
 CONSTRAINT [PK_tTypeDevice] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tUsers]    Script Date: 23.01.2020 10:31:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tUsers](
	[idUser] [int] IDENTITY(1,1) NOT NULL,
	[idRole] [int] NOT NULL,
	[login] [nvarchar](50) NULL,
	[password] [nvarchar](50) NULL,
	[name] [nvarchar](50) NOT NULL,
	[surname] [nvarchar](50) NOT NULL,
	[middlename] [nvarchar](50) NULL,
	[passportSeria] [int] NOT NULL,
	[passportNumber] [int] NOT NULL,
	[Photo] [varbinary](max) NULL,
 CONSTRAINT [PK_tUsers] PRIMARY KEY CLUSTERED 
(
	[idUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[tContract]  WITH CHECK ADD  CONSTRAINT [FK_tContract_tBonus] FOREIGN KEY([idBonus])
REFERENCES [dbo].[tBonus] ([id])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[tContract] CHECK CONSTRAINT [FK_tContract_tBonus]
GO
ALTER TABLE [dbo].[tContract]  WITH CHECK ADD  CONSTRAINT [FK_tContract_tDevice] FOREIGN KEY([idDevice])
REFERENCES [dbo].[tDevice] ([id])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[tContract] CHECK CONSTRAINT [FK_tContract_tDevice]
GO
ALTER TABLE [dbo].[tContract]  WITH CHECK ADD  CONSTRAINT [FK_tContract_tTarif] FOREIGN KEY([idTarif])
REFERENCES [dbo].[tTarif] ([id])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[tContract] CHECK CONSTRAINT [FK_tContract_tTarif]
GO
ALTER TABLE [dbo].[tContract]  WITH CHECK ADD  CONSTRAINT [FK_tContract_tUsers] FOREIGN KEY([idUser])
REFERENCES [dbo].[tUsers] ([idUser])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[tContract] CHECK CONSTRAINT [FK_tContract_tUsers]
GO
ALTER TABLE [dbo].[tContract]  WITH CHECK ADD  CONSTRAINT [FK_tContract_tUsers1] FOREIGN KEY([idOperator])
REFERENCES [dbo].[tUsers] ([idUser])
GO
ALTER TABLE [dbo].[tContract] CHECK CONSTRAINT [FK_tContract_tUsers1]
GO
ALTER TABLE [dbo].[tDevice]  WITH CHECK ADD  CONSTRAINT [FK_tDevice_tManufacture] FOREIGN KEY([idManufacture])
REFERENCES [dbo].[tManufacture] ([id])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[tDevice] CHECK CONSTRAINT [FK_tDevice_tManufacture]
GO
ALTER TABLE [dbo].[tDevice]  WITH CHECK ADD  CONSTRAINT [FK_tDevice_tTypeDevice] FOREIGN KEY([idTypeDevice])
REFERENCES [dbo].[tTypeDevice] ([id])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[tDevice] CHECK CONSTRAINT [FK_tDevice_tTypeDevice]
GO
ALTER TABLE [dbo].[tInfoDevice]  WITH CHECK ADD  CONSTRAINT [FK_tInfoDevice_tDevice] FOREIGN KEY([id])
REFERENCES [dbo].[tDevice] ([id])
GO
ALTER TABLE [dbo].[tInfoDevice] CHECK CONSTRAINT [FK_tInfoDevice_tDevice]
GO
ALTER TABLE [dbo].[tNumberUser]  WITH CHECK ADD  CONSTRAINT [FK_tNumberUser_tNumber] FOREIGN KEY([idNumber])
REFERENCES [dbo].[tNumber] ([id])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[tNumberUser] CHECK CONSTRAINT [FK_tNumberUser_tNumber]
GO
ALTER TABLE [dbo].[tNumberUser]  WITH CHECK ADD  CONSTRAINT [FK_tNumberUser_tUsers] FOREIGN KEY([idUser])
REFERENCES [dbo].[tUsers] ([idUser])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[tNumberUser] CHECK CONSTRAINT [FK_tNumberUser_tUsers]
GO
ALTER TABLE [dbo].[tSpec]  WITH CHECK ADD  CONSTRAINT [FK_tSpec_tUsers] FOREIGN KEY([idUser])
REFERENCES [dbo].[tUsers] ([idUser])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tSpec] CHECK CONSTRAINT [FK_tSpec_tUsers]
GO
ALTER TABLE [dbo].[tUsers]  WITH CHECK ADD  CONSTRAINT [FK_tUsers_tRole] FOREIGN KEY([idRole])
REFERENCES [dbo].[tRole] ([id])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[tUsers] CHECK CONSTRAINT [FK_tUsers_tRole]
GO
