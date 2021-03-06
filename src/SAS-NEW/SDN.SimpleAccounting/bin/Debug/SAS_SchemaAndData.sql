
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 3/12/2018 3:21:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Accounts](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Acc-Name] [nvarchar](100) NULL,
	[Acc-Type] [int] NULL,
	[Acc-Open-Bal] [decimal](18, 4) NULL,
	[Acc-Cur-Bal] [decimal](18, 4) NULL,
	[Acc-Year-to-date] [datetime] NULL,
	[Acc-Inactive] [char](1) NULL CONSTRAINT [DF_Accounts_Acc-Inactive]  DEFAULT ('N'),
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsDeleted] [bit] NULL,
	[IsLinked] [bit] NULL,
	[AccountsCode] [int] NULL,
	[AccYearToDate] [decimal](18, 4) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AccountsIdentity]    Script Date: 3/12/2018 3:21:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountsIdentity](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Acc-Type-Name] [nvarchar](200) NULL,
	[Acc-Type-Code] [int] NULL,
 CONSTRAINT [PK_AccountsIdentity] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AccountType]    Script Date: 3/12/2018 3:21:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountType](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Acc-Type-Name] [nvarchar](50) NULL,
	[Acc-Type-Code] [nvarchar](10) NULL,
	[AccountsOrder] [int] NULL,
 CONSTRAINT [PK_AccountType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Categories]    Script Date: 3/12/2018 3:21:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Cat-Name] [nvarchar](100) NULL,
	[Cat-Code] [nvarchar](5) NULL,
	[Content-Type] [nvarchar](20) NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Country]    Script Date: 3/12/2018 3:21:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[CountryId] [int] NOT NULL,
	[CountryName] [nvarchar](50) NULL,
	[CountryCode] [nvarchar](2) NULL,
	[NumCode] [tinyint] NULL,
	[PhoneCode] [tinyint] NULL,
	[Inactive] [nchar](10) NULL CONSTRAINT [DF_Country_Inactive]  DEFAULT (N'N'),
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[DeletedBy] [int] NULL,
	[DeletedDate] [datetime] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[CountryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CountryCurrency]    Script Date: 3/12/2018 3:21:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CountryCurrency](
	[Id] [int] NOT NULL,
	[Category] [nvarchar](50) NULL,
	[CountryName] [nvarchar](200) NULL,
	[CurrencyName] [nvarchar](10) NULL,
	[CurrencySymbol] [nvarchar](10) NULL,
	[CurrencyDecimalCode] [nvarchar](50) NULL,
	[CurrencyHexaCode] [nvarchar](50) NULL,
	[CurrencyCode] [nvarchar](10) NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedOn] [datetime] NULL,
	[DeletedBy] [int] NULL,
	[DeletedOn] [datetime] NULL,
	[IsDeleted] [bit] NULL,
	[Priority] [tinyint] NULL,
 CONSTRAINT [PK_CountryCurrency] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MasterModules]    Script Date: 3/12/2018 3:21:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MasterModules](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Module-Name] [nvarchar](100) NULL,
	[Module-Id] [int] NOT NULL,
	[Tab-Id] [int] NOT NULL,
	[Tab-Name] [nvarchar](100) NULL,
	[Order-Id] [int] NOT NULL,
 CONSTRAINT [PK_MasterModules] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Options]    Script Date: 3/12/2018 3:21:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Options](
	[ID] [int] NOT NULL,
	[Date-Format] [nvarchar](30) NULL,
	[Number-Format] [nvarchar](30) NULL,
	[Decimal-Places] [tinyint] NULL,
	[Currency-Code] [nvarchar](10) NULL,
	[Starting-Sales-Inv-No] [nvarchar](10) NULL,
	[Name-to-Print-Sales-Invoice] [nvarchar](100) NULL,
	[Def-Cash-Bank-Acc] [nvarchar](50) NULL,
	[Show-Amount-Inc-GST] [bit] NULL,
	[Show-Account-Balance] [bit] NULL,
	[Cus-Detail-Allow-Chg-Limit] [bit] NULL,
	[PS-Detail-Allow-Chg-Act] [bit] NULL,
	[Allow-to-Create-Sales-Inv] [bit] NULL,
	[Show-PS-Name] [bit] NULL,
	[Show-PS-Name-Desc] [bit] NULL,
	[Allow-Edit-PS-Name-Desc] [bit] NULL,
	[Allow-Edit-PS-Price] [bit] NULL,
	[Allow-Edit-Discount] [bit] NULL,
	[Hide-Discount-Column] [bit] NULL,
	[PS-Qty-Jump-Next-Line] [bit] NULL,
	[Print-PS-Name] [bit] NULL,
	[Print-PS-Name-Desc] [bit] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[Print-Del-Sales-Inv] [bit] NULL,
 CONSTRAINT [PK_Options] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[State]    Script Date: 3/12/2018 3:21:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[State](
	[StateId] [int] NOT NULL,
	[StateName] [nvarchar](50) NULL,
	[StateCode] [nvarchar](5) NULL,
	[CountryId] [int] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[DeletedBy] [int] NULL,
	[DeletedDate] [datetime] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_State] PRIMARY KEY CLUSTERED 
(
	[StateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TaxCodesAndRates]    Script Date: 3/12/2018 3:21:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TaxCodesAndRates](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Tax-Name] [nvarchar](50) NOT NULL,
	[Tax-Description] [nvarchar](100) NULL,
	[Tax-Code] [nvarchar](10) NULL,
	[Tax-Rate] [decimal](16, 2) NOT NULL CONSTRAINT [DF__TaxCodesA__Tax-R__0FB750B3]  DEFAULT ((0)),
	[Tax-Inactive] [char](1) NULL CONSTRAINT [DF_TaxCodesAndRates_Tax-Inactive]  DEFAULT ('N'),
	[Tax-Default] [bit] NULL CONSTRAINT [DF__TaxCodesA__Tax-D__119F9925]  DEFAULT ((0)),
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsDeleted] [bit] NULL CONSTRAINT [DF__TaxCodesA__IsDel__1293BD5E]  DEFAULT ((0)),
	[Predefined] [bit] NULL CONSTRAINT [DF_TaxCodesAndRates_IsFreeze]  DEFAULT ((0)),
 CONSTRAINT [PK_TaxCodesAndRates] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TermsAndConditions]    Script Date: 3/12/2018 3:21:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TermsAndConditions](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Cat-Name] [nvarchar](250) NOT NULL,
	[Cat-Code] [nvarchar](5) NOT NULL,
	[SrNo] [int] NULL,
	[Cat-Content] [nvarchar](max) NULL,
 CONSTRAINT [PK_TermsAndConditions] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 3/12/2018 3:21:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[User-Name] [nvarchar](50) NOT NULL,
	[User-Password] [nvarchar](255) NULL,
	[User-Email] [nvarchar](100) NOT NULL,
	[User-Type] [int] NULL,
	[Active] [bit] NULL CONSTRAINT [DF__Users__Active]  DEFAULT ((1)),
	[CreatedBy] [int] NULL CONSTRAINT [DF__Users__CreatedBy]  DEFAULT ((0)),
	[CreatedDate] [datetime] NOT NULL CONSTRAINT [DF__Users__CreatedDate]  DEFAULT (getdate()),
	[IsDeleted] [bit] NULL CONSTRAINT [DF__Users__IsDeleted]  DEFAULT ((0)),
	[IsSuperAdmin] [bit] NULL CONSTRAINT [DF_Users_IsSuperAdmin]  DEFAULT ((0)),
	[DeletedBy] [int] NULL,
	[DeletedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK__Users__S001] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserSecurity]    Script Date: 3/12/2018 3:21:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserSecurity](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[User-Id] [int] NULL,
	[Tab-Id] [nchar](10) NULL,
 CONSTRAINT [PK_UserSecurity] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Accounts] ON 

INSERT [dbo].[Accounts] ([ID], [Acc-Name], [Acc-Type], [Acc-Open-Bal], [Acc-Cur-Bal], [Acc-Year-to-date], [Acc-Inactive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsDeleted], [IsLinked], [AccountsCode], [AccYearToDate], [IsActive]) VALUES (17, N'Cash', 1, CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), NULL, N'N', NULL, NULL, NULL, NULL, 0, 1, 1, NULL, 0)
INSERT [dbo].[Accounts] ([ID], [Acc-Name], [Acc-Type], [Acc-Open-Bal], [Acc-Cur-Bal], [Acc-Year-to-date], [Acc-Inactive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsDeleted], [IsLinked], [AccountsCode], [AccYearToDate], [IsActive]) VALUES (18, N'Deposits Paid to Suppliers', 2, CAST(0.0000 AS Decimal(18, 4)), NULL, NULL, N'N', NULL, NULL, NULL, NULL, 0, 1, 2, NULL, 0)
INSERT [dbo].[Accounts] ([ID], [Acc-Name], [Acc-Type], [Acc-Open-Bal], [Acc-Cur-Bal], [Acc-Year-to-date], [Acc-Inactive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsDeleted], [IsLinked], [AccountsCode], [AccYearToDate], [IsActive]) VALUES (19, N'Payments Due from Customers', 2, CAST(0.0000 AS Decimal(18, 4)), NULL, NULL, N'N', NULL, NULL, NULL, NULL, 0, 1, 3, NULL, 1)
INSERT [dbo].[Accounts] ([ID], [Acc-Name], [Acc-Type], [Acc-Open-Bal], [Acc-Cur-Bal], [Acc-Year-to-date], [Acc-Inactive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsDeleted], [IsLinked], [AccountsCode], [AccYearToDate], [IsActive]) VALUES (20, N'Stock', 2, CAST(0.0000 AS Decimal(18, 4)), NULL, NULL, N'N', NULL, NULL, NULL, NULL, 0, 1, 4, NULL, 1)
INSERT [dbo].[Accounts] ([ID], [Acc-Name], [Acc-Type], [Acc-Open-Bal], [Acc-Cur-Bal], [Acc-Year-to-date], [Acc-Inactive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsDeleted], [IsLinked], [AccountsCode], [AccYearToDate], [IsActive]) VALUES (21, N'Deposits Paid by Customers', 4, CAST(0.0000 AS Decimal(18, 4)), NULL, NULL, N'N', NULL, NULL, NULL, NULL, 0, 1, 5, NULL, 0)
INSERT [dbo].[Accounts] ([ID], [Acc-Name], [Acc-Type], [Acc-Open-Bal], [Acc-Cur-Bal], [Acc-Year-to-date], [Acc-Inactive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsDeleted], [IsLinked], [AccountsCode], [AccYearToDate], [IsActive]) VALUES (22, N'Payments Due to Suppliers', 4, CAST(0.0000 AS Decimal(18, 4)), NULL, NULL, N'N', NULL, NULL, NULL, NULL, 0, 1, 6, NULL, 1)
INSERT [dbo].[Accounts] ([ID], [Acc-Name], [Acc-Type], [Acc-Open-Bal], [Acc-Cur-Bal], [Acc-Year-to-date], [Acc-Inactive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsDeleted], [IsLinked], [AccountsCode], [AccYearToDate], [IsActive]) VALUES (23, N'GST/VAT Collected', 4, CAST(0.0000 AS Decimal(18, 4)), NULL, NULL, N'N', NULL, NULL, NULL, NULL, 0, 1, 7, NULL, 0)
INSERT [dbo].[Accounts] ([ID], [Acc-Name], [Acc-Type], [Acc-Open-Bal], [Acc-Cur-Bal], [Acc-Year-to-date], [Acc-Inactive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsDeleted], [IsLinked], [AccountsCode], [AccYearToDate], [IsActive]) VALUES (24, N'GST/VAT Paid', 8, CAST(0.0000 AS Decimal(18, 4)), NULL, NULL, N'N', NULL, NULL, NULL, NULL, 0, 1, 8, NULL, 0)
INSERT [dbo].[Accounts] ([ID], [Acc-Name], [Acc-Type], [Acc-Open-Bal], [Acc-Cur-Bal], [Acc-Year-to-date], [Acc-Inactive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsDeleted], [IsLinked], [AccountsCode], [AccYearToDate], [IsActive]) VALUES (25, N'Net GST/VAT', 4, CAST(0.0000 AS Decimal(18, 4)), NULL, NULL, N'N', NULL, NULL, NULL, NULL, 0, 1, 9, NULL, 0)
INSERT [dbo].[Accounts] ([ID], [Acc-Name], [Acc-Type], [Acc-Open-Bal], [Acc-Cur-Bal], [Acc-Year-to-date], [Acc-Inactive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsDeleted], [IsLinked], [AccountsCode], [AccYearToDate], [IsActive]) VALUES (26, N'Capital Invested', 6, CAST(0.0000 AS Decimal(18, 4)), NULL, NULL, N'N', NULL, NULL, NULL, NULL, 0, 1, 10, NULL, 0)
INSERT [dbo].[Accounts] ([ID], [Acc-Name], [Acc-Type], [Acc-Open-Bal], [Acc-Cur-Bal], [Acc-Year-to-date], [Acc-Inactive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsDeleted], [IsLinked], [AccountsCode], [AccYearToDate], [IsActive]) VALUES (27, N'Profit Previous - Years', 6, CAST(0.0000 AS Decimal(18, 4)), NULL, NULL, N'N', NULL, NULL, NULL, NULL, 0, 1, 11, NULL, 0)
INSERT [dbo].[Accounts] ([ID], [Acc-Name], [Acc-Type], [Acc-Open-Bal], [Acc-Cur-Bal], [Acc-Year-to-date], [Acc-Inactive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsDeleted], [IsLinked], [AccountsCode], [AccYearToDate], [IsActive]) VALUES (28, N'Profit - This Year', 6, CAST(0.0000 AS Decimal(18, 4)), NULL, NULL, N'N', NULL, NULL, NULL, NULL, 0, 1, 12, NULL, 0)
INSERT [dbo].[Accounts] ([ID], [Acc-Name], [Acc-Type], [Acc-Open-Bal], [Acc-Cur-Bal], [Acc-Year-to-date], [Acc-Inactive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsDeleted], [IsLinked], [AccountsCode], [AccYearToDate], [IsActive]) VALUES (29, N'Sales', 7, CAST(0.0000 AS Decimal(18, 4)), NULL, NULL, N'N', NULL, NULL, NULL, NULL, 0, 1, 13, NULL, 0)
INSERT [dbo].[Accounts] ([ID], [Acc-Name], [Acc-Type], [Acc-Open-Bal], [Acc-Cur-Bal], [Acc-Year-to-date], [Acc-Inactive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsDeleted], [IsLinked], [AccountsCode], [AccYearToDate], [IsActive]) VALUES (30, N'Discounts from Suppliers', 7, CAST(0.0000 AS Decimal(18, 4)), NULL, NULL, N'N', NULL, NULL, NULL, NULL, 0, 1, 14, NULL, 0)
INSERT [dbo].[Accounts] ([ID], [Acc-Name], [Acc-Type], [Acc-Open-Bal], [Acc-Cur-Bal], [Acc-Year-to-date], [Acc-Inactive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsDeleted], [IsLinked], [AccountsCode], [AccYearToDate], [IsActive]) VALUES (31, N'Purchases', 8, CAST(0.0000 AS Decimal(18, 4)), NULL, NULL, N'N', NULL, NULL, NULL, NULL, 0, 1, 15, NULL, 0)
INSERT [dbo].[Accounts] ([ID], [Acc-Name], [Acc-Type], [Acc-Open-Bal], [Acc-Cur-Bal], [Acc-Year-to-date], [Acc-Inactive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsDeleted], [IsLinked], [AccountsCode], [AccYearToDate], [IsActive]) VALUES (32, N'Discounts to Customers', 8, CAST(0.0000 AS Decimal(18, 4)), NULL, NULL, N'N', NULL, NULL, NULL, NULL, 0, 1, 16, NULL, 0)
INSERT [dbo].[Accounts] ([ID], [Acc-Name], [Acc-Type], [Acc-Open-Bal], [Acc-Cur-Bal], [Acc-Year-to-date], [Acc-Inactive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsDeleted], [IsLinked], [AccountsCode], [AccYearToDate], [IsActive]) VALUES (33, N'Stock used/lost/damaged', 8, CAST(0.0000 AS Decimal(18, 4)), NULL, NULL, N'N', NULL, NULL, NULL, NULL, 0, 1, 17, NULL, 0)
INSERT [dbo].[Accounts] ([ID], [Acc-Name], [Acc-Type], [Acc-Open-Bal], [Acc-Cur-Bal], [Acc-Year-to-date], [Acc-Inactive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsDeleted], [IsLinked], [AccountsCode], [AccYearToDate], [IsActive]) VALUES (34, N'Building', 3, CAST(0.0000 AS Decimal(18, 4)), NULL, NULL, N'N', NULL, NULL, NULL, NULL, 0, NULL, 18, NULL, 0)
INSERT [dbo].[Accounts] ([ID], [Acc-Name], [Acc-Type], [Acc-Open-Bal], [Acc-Cur-Bal], [Acc-Year-to-date], [Acc-Inactive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsDeleted], [IsLinked], [AccountsCode], [AccYearToDate], [IsActive]) VALUES (35, N'ICICI', 1, CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), NULL, N'N', NULL, NULL, NULL, NULL, 0, NULL, 1, NULL, 0)
INSERT [dbo].[Accounts] ([ID], [Acc-Name], [Acc-Type], [Acc-Open-Bal], [Acc-Cur-Bal], [Acc-Year-to-date], [Acc-Inactive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsDeleted], [IsLinked], [AccountsCode], [AccYearToDate], [IsActive]) VALUES (36, N'Hdfc1002', 1, CAST(0.0000 AS Decimal(18, 4)), NULL, NULL, N'N', NULL, NULL, NULL, NULL, 0, NULL, 1, NULL, 0)
INSERT [dbo].[Accounts] ([ID], [Acc-Name], [Acc-Type], [Acc-Open-Bal], [Acc-Cur-Bal], [Acc-Year-to-date], [Acc-Inactive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsDeleted], [IsLinked], [AccountsCode], [AccYearToDate], [IsActive]) VALUES (37, N'SBI', 1, CAST(0.0000 AS Decimal(18, 4)), NULL, NULL, N'N', NULL, NULL, NULL, NULL, 0, NULL, 1, NULL, 0)
INSERT [dbo].[Accounts] ([ID], [Acc-Name], [Acc-Type], [Acc-Open-Bal], [Acc-Cur-Bal], [Acc-Year-to-date], [Acc-Inactive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsDeleted], [IsLinked], [AccountsCode], [AccYearToDate], [IsActive]) VALUES (38, N'PNB', 1, CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), NULL, N'N', NULL, NULL, NULL, NULL, 0, NULL, 1, NULL, 0)
INSERT [dbo].[Accounts] ([ID], [Acc-Name], [Acc-Type], [Acc-Open-Bal], [Acc-Cur-Bal], [Acc-Year-to-date], [Acc-Inactive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsDeleted], [IsLinked], [AccountsCode], [AccYearToDate], [IsActive]) VALUES (39, N'Payment From Supplier', 4, CAST(0.0000 AS Decimal(18, 4)), NULL, NULL, N'N', NULL, NULL, NULL, NULL, 1, NULL, 19, NULL, 0)
INSERT [dbo].[Accounts] ([ID], [Acc-Name], [Acc-Type], [Acc-Open-Bal], [Acc-Cur-Bal], [Acc-Year-to-date], [Acc-Inactive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsDeleted], [IsLinked], [AccountsCode], [AccYearToDate], [IsActive]) VALUES (40, N'bank loan', 4, CAST(0.0000 AS Decimal(18, 4)), NULL, NULL, N'N', NULL, NULL, NULL, NULL, 0, NULL, 19, NULL, 0)
INSERT [dbo].[Accounts] ([ID], [Acc-Name], [Acc-Type], [Acc-Open-Bal], [Acc-Cur-Bal], [Acc-Year-to-date], [Acc-Inactive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsDeleted], [IsLinked], [AccountsCode], [AccYearToDate], [IsActive]) VALUES (41, N'Bank Interest', 7, CAST(0.0000 AS Decimal(18, 4)), NULL, NULL, N'N', NULL, NULL, NULL, NULL, 0, NULL, 21, NULL, 0)
INSERT [dbo].[Accounts] ([ID], [Acc-Name], [Acc-Type], [Acc-Open-Bal], [Acc-Cur-Bal], [Acc-Year-to-date], [Acc-Inactive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsDeleted], [IsLinked], [AccountsCode], [AccYearToDate], [IsActive]) VALUES (42, N'freight', 8, CAST(0.0000 AS Decimal(18, 4)), NULL, NULL, N'N', NULL, NULL, NULL, NULL, 0, NULL, 22, NULL, 0)
INSERT [dbo].[Accounts] ([ID], [Acc-Name], [Acc-Type], [Acc-Open-Bal], [Acc-Cur-Bal], [Acc-Year-to-date], [Acc-Inactive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsDeleted], [IsLinked], [AccountsCode], [AccYearToDate], [IsActive]) VALUES (43, N'Rent', 9, CAST(0.0000 AS Decimal(18, 4)), NULL, NULL, N'N', NULL, NULL, NULL, NULL, 0, NULL, 23, NULL, 0)
INSERT [dbo].[Accounts] ([ID], [Acc-Name], [Acc-Type], [Acc-Open-Bal], [Acc-Cur-Bal], [Acc-Year-to-date], [Acc-Inactive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsDeleted], [IsLinked], [AccountsCode], [AccYearToDate], [IsActive]) VALUES (44, N'return Assets', 2, CAST(0.0000 AS Decimal(18, 4)), NULL, NULL, N'N', NULL, NULL, NULL, NULL, 1, NULL, 18, NULL, 0)
INSERT [dbo].[Accounts] ([ID], [Acc-Name], [Acc-Type], [Acc-Open-Bal], [Acc-Cur-Bal], [Acc-Year-to-date], [Acc-Inactive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsDeleted], [IsLinked], [AccountsCode], [AccYearToDate], [IsActive]) VALUES (47, N'Credit Card', 10, CAST(0.0000 AS Decimal(18, 4)), NULL, NULL, N'N', NULL, NULL, NULL, NULL, 0, NULL, 24, NULL, 0)
INSERT [dbo].[Accounts] ([ID], [Acc-Name], [Acc-Type], [Acc-Open-Bal], [Acc-Cur-Bal], [Acc-Year-to-date], [Acc-Inactive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsDeleted], [IsLinked], [AccountsCode], [AccYearToDate], [IsActive]) VALUES (48, N'Suspense Account', 6, CAST(0.0000 AS Decimal(18, 4)), NULL, NULL, N'N', NULL, NULL, NULL, NULL, 0, 1, 25, NULL, 0)
INSERT [dbo].[Accounts] ([ID], [Acc-Name], [Acc-Type], [Acc-Open-Bal], [Acc-Cur-Bal], [Acc-Year-to-date], [Acc-Inactive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsDeleted], [IsLinked], [AccountsCode], [AccYearToDate], [IsActive]) VALUES (51, N'HDFC loan', 5, CAST(0.0000 AS Decimal(18, 4)), NULL, NULL, N'N', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Accounts] ([ID], [Acc-Name], [Acc-Type], [Acc-Open-Bal], [Acc-Cur-Bal], [Acc-Year-to-date], [Acc-Inactive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsDeleted], [IsLinked], [AccountsCode], [AccYearToDate], [IsActive]) VALUES (52, N'Sbi Loan', 5, CAST(0.0000 AS Decimal(18, 4)), NULL, NULL, N'N', NULL, NULL, NULL, NULL, NULL, NULL, 19, NULL, NULL)
INSERT [dbo].[Accounts] ([ID], [Acc-Name], [Acc-Type], [Acc-Open-Bal], [Acc-Cur-Bal], [Acc-Year-to-date], [Acc-Inactive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsDeleted], [IsLinked], [AccountsCode], [AccYearToDate], [IsActive]) VALUES (53, N'PNB Loan', 5, CAST(0.0000 AS Decimal(18, 4)), NULL, NULL, N'N', NULL, NULL, NULL, NULL, NULL, NULL, 19, NULL, NULL)
INSERT [dbo].[Accounts] ([ID], [Acc-Name], [Acc-Type], [Acc-Open-Bal], [Acc-Cur-Bal], [Acc-Year-to-date], [Acc-Inactive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsDeleted], [IsLinked], [AccountsCode], [AccYearToDate], [IsActive]) VALUES (54, N'ULoan', 5, CAST(0.0000 AS Decimal(18, 4)), NULL, NULL, N'N', NULL, NULL, NULL, NULL, NULL, NULL, 19, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Accounts] OFF
SET IDENTITY_INSERT [dbo].[AccountsIdentity] ON 

INSERT [dbo].[AccountsIdentity] ([ID], [Acc-Type-Name], [Acc-Type-Code]) VALUES (1, N'Cash', 1)
INSERT [dbo].[AccountsIdentity] ([ID], [Acc-Type-Name], [Acc-Type-Code]) VALUES (2, N'Deposits Paid to Suppliers', 2)
INSERT [dbo].[AccountsIdentity] ([ID], [Acc-Type-Name], [Acc-Type-Code]) VALUES (3, N'Payments Due from Customers', 3)
INSERT [dbo].[AccountsIdentity] ([ID], [Acc-Type-Name], [Acc-Type-Code]) VALUES (4, N'Stock', 4)
INSERT [dbo].[AccountsIdentity] ([ID], [Acc-Type-Name], [Acc-Type-Code]) VALUES (5, N'Deposits Paid by Customers', 5)
INSERT [dbo].[AccountsIdentity] ([ID], [Acc-Type-Name], [Acc-Type-Code]) VALUES (6, N'Payments Due to Suppliers', 6)
INSERT [dbo].[AccountsIdentity] ([ID], [Acc-Type-Name], [Acc-Type-Code]) VALUES (7, N'GST/VAT Collected', 7)
INSERT [dbo].[AccountsIdentity] ([ID], [Acc-Type-Name], [Acc-Type-Code]) VALUES (8, N'GST/VAT Paid', 8)
INSERT [dbo].[AccountsIdentity] ([ID], [Acc-Type-Name], [Acc-Type-Code]) VALUES (9, N'Net GST/VAT', 9)
INSERT [dbo].[AccountsIdentity] ([ID], [Acc-Type-Name], [Acc-Type-Code]) VALUES (10, N'Capital Invested', 10)
INSERT [dbo].[AccountsIdentity] ([ID], [Acc-Type-Name], [Acc-Type-Code]) VALUES (11, N'Profit Previous - Years', 11)
INSERT [dbo].[AccountsIdentity] ([ID], [Acc-Type-Name], [Acc-Type-Code]) VALUES (12, N'Profit - This Year', 12)
INSERT [dbo].[AccountsIdentity] ([ID], [Acc-Type-Name], [Acc-Type-Code]) VALUES (13, N'Sales', 13)
INSERT [dbo].[AccountsIdentity] ([ID], [Acc-Type-Name], [Acc-Type-Code]) VALUES (14, N'Discounts from Suppliers', 14)
INSERT [dbo].[AccountsIdentity] ([ID], [Acc-Type-Name], [Acc-Type-Code]) VALUES (15, N'Purchases', 15)
INSERT [dbo].[AccountsIdentity] ([ID], [Acc-Type-Name], [Acc-Type-Code]) VALUES (16, N'Discounts to Customers', 16)
INSERT [dbo].[AccountsIdentity] ([ID], [Acc-Type-Name], [Acc-Type-Code]) VALUES (17, N'Stock used/lost/damaged', 17)
INSERT [dbo].[AccountsIdentity] ([ID], [Acc-Type-Name], [Acc-Type-Code]) VALUES (18, N'User​ ​created​ ​Asset​', 18)
INSERT [dbo].[AccountsIdentity] ([ID], [Acc-Type-Name], [Acc-Type-Code]) VALUES (19, N'User​ ​created​ ​Liabilities', 19)
INSERT [dbo].[AccountsIdentity] ([ID], [Acc-Type-Name], [Acc-Type-Code]) VALUES (20, N'User​ ​created​ ​Capital', 20)
INSERT [dbo].[AccountsIdentity] ([ID], [Acc-Type-Name], [Acc-Type-Code]) VALUES (21, N'User​ ​created​ ​Income', 21)
INSERT [dbo].[AccountsIdentity] ([ID], [Acc-Type-Name], [Acc-Type-Code]) VALUES (22, N'User​ ​created​ ​Cost', 22)
INSERT [dbo].[AccountsIdentity] ([ID], [Acc-Type-Name], [Acc-Type-Code]) VALUES (23, N'User​ ​created​ ​Expenses', 23)
INSERT [dbo].[AccountsIdentity] ([ID], [Acc-Type-Name], [Acc-Type-Code]) VALUES (24, N'Credit Card', 24)
INSERT [dbo].[AccountsIdentity] ([ID], [Acc-Type-Name], [Acc-Type-Code]) VALUES (25, N'Suspense Account', 25)
SET IDENTITY_INSERT [dbo].[AccountsIdentity] OFF
SET IDENTITY_INSERT [dbo].[AccountType] ON 

INSERT [dbo].[AccountType] ([ID], [Acc-Type-Name], [Acc-Type-Code], [AccountsOrder]) VALUES (2, N'Cash and Bank', N'1', 1)
INSERT [dbo].[AccountType] ([ID], [Acc-Type-Name], [Acc-Type-Code], [AccountsOrder]) VALUES (3, N'Current Assets', N'2', 2)
INSERT [dbo].[AccountType] ([ID], [Acc-Type-Name], [Acc-Type-Code], [AccountsOrder]) VALUES (4, N'Fixed Assets', N'3', 3)
INSERT [dbo].[AccountType] ([ID], [Acc-Type-Name], [Acc-Type-Code], [AccountsOrder]) VALUES (5, N'Current Liabilities', N'4', 5)
INSERT [dbo].[AccountType] ([ID], [Acc-Type-Name], [Acc-Type-Code], [AccountsOrder]) VALUES (6, N'Long Term Liabilities', N'5', 6)
INSERT [dbo].[AccountType] ([ID], [Acc-Type-Name], [Acc-Type-Code], [AccountsOrder]) VALUES (7, N'Capital', N'6', 7)
INSERT [dbo].[AccountType] ([ID], [Acc-Type-Name], [Acc-Type-Code], [AccountsOrder]) VALUES (8, N'Income', N'7', 8)
INSERT [dbo].[AccountType] ([ID], [Acc-Type-Name], [Acc-Type-Code], [AccountsOrder]) VALUES (9, N'Costs', N'8', 9)
INSERT [dbo].[AccountType] ([ID], [Acc-Type-Name], [Acc-Type-Code], [AccountsOrder]) VALUES (10, N'Expenses', N'9', 10)
INSERT [dbo].[AccountType] ([ID], [Acc-Type-Name], [Acc-Type-Code], [AccountsOrder]) VALUES (12, N'Credit Card', N'10', 4)
SET IDENTITY_INSERT [dbo].[AccountType] OFF
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([ID], [Cat-Name], [Cat-Code], [Content-Type]) VALUES (1, N'Customer Type', N'CT', N'Type')
INSERT [dbo].[Categories] ([ID], [Cat-Name], [Cat-Code], [Content-Type]) VALUES (2, N'Salesman', N'SM', N'Name')
INSERT [dbo].[Categories] ([ID], [Cat-Name], [Cat-Code], [Content-Type]) VALUES (3, N'Customer Credit Limit - Days', N'CCLD', N'Days')
INSERT [dbo].[Categories] ([ID], [Cat-Name], [Cat-Code], [Content-Type]) VALUES (4, N'Customer Credit Limit - Amount', N'CCLA', N'Amount')
INSERT [dbo].[Categories] ([ID], [Cat-Name], [Cat-Code], [Content-Type]) VALUES (5, N'Customer Discount', N'CD', N'Discount(%)')
INSERT [dbo].[Categories] ([ID], [Cat-Name], [Cat-Code], [Content-Type]) VALUES (9, N'Products and Services Category 1', N'PSC01', N'P&S CAT1')
INSERT [dbo].[Categories] ([ID], [Cat-Name], [Cat-Code], [Content-Type]) VALUES (10, N'Products and Services Category 2', N'PSC02', N'P&S CAT2')
SET IDENTITY_INSERT [dbo].[Categories] OFF

SET IDENTITY_INSERT [dbo].[MasterModules] ON 

INSERT [dbo].[MasterModules] ([ID], [Module-Name], [Module-Id], [Tab-Id], [Tab-Name], [Order-Id]) VALUES (76, N'File', 1, 1, N'Open Company File', 1)
INSERT [dbo].[MasterModules] ([ID], [Module-Name], [Module-Id], [Tab-Id], [Tab-Name], [Order-Id]) VALUES (77, N'', 1, 2, N'Import Data', 2)
INSERT [dbo].[MasterModules] ([ID], [Module-Name], [Module-Id], [Tab-Id], [Tab-Name], [Order-Id]) VALUES (78, N'', 1, 3, N'Export Data', 3)
INSERT [dbo].[MasterModules] ([ID], [Module-Name], [Module-Id], [Tab-Id], [Tab-Name], [Order-Id]) VALUES (79, N'', 1, 4, N'Backup Data', 4)
INSERT [dbo].[MasterModules] ([ID], [Module-Name], [Module-Id], [Tab-Id], [Tab-Name], [Order-Id]) VALUES (80, N'', 1, 5, N'Restore Data', 5)
INSERT [dbo].[MasterModules] ([ID], [Module-Name], [Module-Id], [Tab-Id], [Tab-Name], [Order-Id]) VALUES (81, N'Settings', 2, 6, N'Company Details', 6)
INSERT [dbo].[MasterModules] ([ID], [Module-Name], [Module-Id], [Tab-Id], [Tab-Name], [Order-Id]) VALUES (82, N'', 2, 7, N'Categories', 7)
INSERT [dbo].[MasterModules] ([ID], [Module-Name], [Module-Id], [Tab-Id], [Tab-Name], [Order-Id]) VALUES (83, N'', 2, 8, N'Options', 8)
INSERT [dbo].[MasterModules] ([ID], [Module-Name], [Module-Id], [Tab-Id], [Tab-Name], [Order-Id]) VALUES (84, N'', 2, 9, N'GST/VAT Codes & Rates', 9)
INSERT [dbo].[MasterModules] ([ID], [Module-Name], [Module-Id], [Tab-Id], [Tab-Name], [Order-Id]) VALUES (85, N'', 2, 10, N'Users & Security', 10)
INSERT [dbo].[MasterModules] ([ID], [Module-Name], [Module-Id], [Tab-Id], [Tab-Name], [Order-Id]) VALUES (86, N'Customers', 3, 11, N'Customers Details', 11)
INSERT [dbo].[MasterModules] ([ID], [Module-Name], [Module-Id], [Tab-Id], [Tab-Name], [Order-Id]) VALUES (87, N'', 3, 12, N'Customers History', 12)
INSERT [dbo].[MasterModules] ([ID], [Module-Name], [Module-Id], [Tab-Id], [Tab-Name], [Order-Id]) VALUES (88, N'', 3, 13, N'Customers Statement', 13)
INSERT [dbo].[MasterModules] ([ID], [Module-Name], [Module-Id], [Tab-Id], [Tab-Name], [Order-Id]) VALUES (89, N'', 3, 14, N'P & S Sold', 14)
INSERT [dbo].[MasterModules] ([ID], [Module-Name], [Module-Id], [Tab-Id], [Tab-Name], [Order-Id]) VALUES (90, N'', 3, 15, N'Top Customers', 15)
INSERT [dbo].[MasterModules] ([ID], [Module-Name], [Module-Id], [Tab-Id], [Tab-Name], [Order-Id]) VALUES (91, N'Sales', 4, 16, N'Sales Quotation', 16)
INSERT [dbo].[MasterModules] ([ID], [Module-Name], [Module-Id], [Tab-Id], [Tab-Name], [Order-Id]) VALUES (92, N'', 4, 17, N'Sales Order', 17)
INSERT [dbo].[MasterModules] ([ID], [Module-Name], [Module-Id], [Tab-Id], [Tab-Name], [Order-Id]) VALUES (93, N'', 4, 18, N'Sales Invoice', 18)
INSERT [dbo].[MasterModules] ([ID], [Module-Name], [Module-Id], [Tab-Id], [Tab-Name], [Order-Id]) VALUES (94, N'', 4, 19, N'Credit Note', 19)
INSERT [dbo].[MasterModules] ([ID], [Module-Name], [Module-Id], [Tab-Id], [Tab-Name], [Order-Id]) VALUES (95, N'', 4, 20, N'Adjust Credit Note', 20)
INSERT [dbo].[MasterModules] ([ID], [Module-Name], [Module-Id], [Tab-Id], [Tab-Name], [Order-Id]) VALUES (96, N'', 4, 21, N'Payment from Customer', 21)
INSERT [dbo].[MasterModules] ([ID], [Module-Name], [Module-Id], [Tab-Id], [Tab-Name], [Order-Id]) VALUES (97, N'Suppliers', 5, 22, N'Suppliers Details', 22)
INSERT [dbo].[MasterModules] ([ID], [Module-Name], [Module-Id], [Tab-Id], [Tab-Name], [Order-Id]) VALUES (98, N'', 5, 23, N'Suppliers History', 23)
INSERT [dbo].[MasterModules] ([ID], [Module-Name], [Module-Id], [Tab-Id], [Tab-Name], [Order-Id]) VALUES (99, N'', 5, 24, N'Suppliers Statement', 24)
INSERT [dbo].[MasterModules] ([ID], [Module-Name], [Module-Id], [Tab-Id], [Tab-Name], [Order-Id]) VALUES (100, N'', 5, 25, N'P & S Purchased', 25)
INSERT [dbo].[MasterModules] ([ID], [Module-Name], [Module-Id], [Tab-Id], [Tab-Name], [Order-Id]) VALUES (101, N'', 5, 26, N'Top Suppliers', 26)
INSERT [dbo].[MasterModules] ([ID], [Module-Name], [Module-Id], [Tab-Id], [Tab-Name], [Order-Id]) VALUES (102, N'Purchases', 6, 27, N'Purchase Quotation', 27)
INSERT [dbo].[MasterModules] ([ID], [Module-Name], [Module-Id], [Tab-Id], [Tab-Name], [Order-Id]) VALUES (103, N'', 6, 28, N'Purchase Order', 28)
INSERT [dbo].[MasterModules] ([ID], [Module-Name], [Module-Id], [Tab-Id], [Tab-Name], [Order-Id]) VALUES (104, N'', 6, 29, N'Purchases Invoice (P & S)', 29)
INSERT [dbo].[MasterModules] ([ID], [Module-Name], [Module-Id], [Tab-Id], [Tab-Name], [Order-Id]) VALUES (105, N'', 6, 30, N'Purchases Invoice (Business Expenses)', 30)
INSERT [dbo].[MasterModules] ([ID], [Module-Name], [Module-Id], [Tab-Id], [Tab-Name], [Order-Id]) VALUES (106, N'', 6, 31, N'Debit Note', 31)
INSERT [dbo].[MasterModules] ([ID], [Module-Name], [Module-Id], [Tab-Id], [Tab-Name], [Order-Id]) VALUES (107, N'', 6, 32, N'Adjust Debit Note', 32)
INSERT [dbo].[MasterModules] ([ID], [Module-Name], [Module-Id], [Tab-Id], [Tab-Name], [Order-Id]) VALUES (108, N'', 6, 33, N'Payment to Suplier', 33)
INSERT [dbo].[MasterModules] ([ID], [Module-Name], [Module-Id], [Tab-Id], [Tab-Name], [Order-Id]) VALUES (109, N'P & S', 7, 34, N'P & S Details', 34)
INSERT [dbo].[MasterModules] ([ID], [Module-Name], [Module-Id], [Tab-Id], [Tab-Name], [Order-Id]) VALUES (110, N'', 7, 35, N'P & S Details List', 35)
INSERT [dbo].[MasterModules] ([ID], [Module-Name], [Module-Id], [Tab-Id], [Tab-Name], [Order-Id]) VALUES (111, N'', 7, 36, N'P & S Cost Prices & Stock Value List', 36)
INSERT [dbo].[MasterModules] ([ID], [Module-Name], [Module-Id], [Tab-Id], [Tab-Name], [Order-Id]) VALUES (112, N'', 7, 37, N'P&S History', 37)
INSERT [dbo].[MasterModules] ([ID], [Module-Name], [Module-Id], [Tab-Id], [Tab-Name], [Order-Id]) VALUES (113, N'', 7, 38, N'Stock in/out card', 38)
INSERT [dbo].[MasterModules] ([ID], [Module-Name], [Module-Id], [Tab-Id], [Tab-Name], [Order-Id]) VALUES (114, N'', 7, 39, N'Count & Adjust Stock', 39)
INSERT [dbo].[MasterModules] ([ID], [Module-Name], [Module-Id], [Tab-Id], [Tab-Name], [Order-Id]) VALUES (115, N'', 7, 40, N'P & S Sold', 40)
INSERT [dbo].[MasterModules] ([ID], [Module-Name], [Module-Id], [Tab-Id], [Tab-Name], [Order-Id]) VALUES (116, N'', 7, 41, N'P & S Purchased', 41)
INSERT [dbo].[MasterModules] ([ID], [Module-Name], [Module-Id], [Tab-Id], [Tab-Name], [Order-Id]) VALUES (117, N'', 7, 42, N'Top Products & Services', 42)
INSERT [dbo].[MasterModules] ([ID], [Module-Name], [Module-Id], [Tab-Id], [Tab-Name], [Order-Id]) VALUES (118, N'Cash & Bank', 8, 43, N'Cash & Bank Statement', 43)
INSERT [dbo].[MasterModules] ([ID], [Module-Name], [Module-Id], [Tab-Id], [Tab-Name], [Order-Id]) VALUES (119, N'', 8, 44, N'Refund To Customer', 44)
INSERT [dbo].[MasterModules] ([ID], [Module-Name], [Module-Id], [Tab-Id], [Tab-Name], [Order-Id]) VALUES (120, N'', 8, 45, N'Refund to Supplier', 45)
INSERT [dbo].[MasterModules] ([ID], [Module-Name], [Module-Id], [Tab-Id], [Tab-Name], [Order-Id]) VALUES (121, N'', 8, 46, N'Recieve Money', 46)
INSERT [dbo].[MasterModules] ([ID], [Module-Name], [Module-Id], [Tab-Id], [Tab-Name], [Order-Id]) VALUES (122, N'', 8, 47, N'Pay Money', 49)
INSERT [dbo].[MasterModules] ([ID], [Module-Name], [Module-Id], [Tab-Id], [Tab-Name], [Order-Id]) VALUES (123, N'', 8, 48, N'Transfer Money', 50)
INSERT [dbo].[MasterModules] ([ID], [Module-Name], [Module-Id], [Tab-Id], [Tab-Name], [Order-Id]) VALUES (124, N'Accounts', 9, 49, N'Accounts Details', 51)
INSERT [dbo].[MasterModules] ([ID], [Module-Name], [Module-Id], [Tab-Id], [Tab-Name], [Order-Id]) VALUES (125, N'', 9, 50, N'Accounts Transactions', 52)
INSERT [dbo].[MasterModules] ([ID], [Module-Name], [Module-Id], [Tab-Id], [Tab-Name], [Order-Id]) VALUES (126, N'', 9, 51, N'Journal', 53)
INSERT [dbo].[MasterModules] ([ID], [Module-Name], [Module-Id], [Tab-Id], [Tab-Name], [Order-Id]) VALUES (127, N'', 9, 52, N'Ledger', 54)
INSERT [dbo].[MasterModules] ([ID], [Module-Name], [Module-Id], [Tab-Id], [Tab-Name], [Order-Id]) VALUES (129, N'', 9, 53, N'Trail Balance', 56)
INSERT [dbo].[MasterModules] ([ID], [Module-Name], [Module-Id], [Tab-Id], [Tab-Name], [Order-Id]) VALUES (130, N'', 9, 54, N'Profit & Loss Statement', 57)
INSERT [dbo].[MasterModules] ([ID], [Module-Name], [Module-Id], [Tab-Id], [Tab-Name], [Order-Id]) VALUES (131, N'', 9, 55, N'Balance Sheet', 58)
INSERT [dbo].[MasterModules] ([ID], [Module-Name], [Module-Id], [Tab-Id], [Tab-Name], [Order-Id]) VALUES (132, N'', 9, 56, N'GST Reports', 59)
INSERT [dbo].[MasterModules] ([ID], [Module-Name], [Module-Id], [Tab-Id], [Tab-Name], [Order-Id]) VALUES (133, N'Home Screen', 10, 57, N'Notifications', 60)
INSERT [dbo].[MasterModules] ([ID], [Module-Name], [Module-Id], [Tab-Id], [Tab-Name], [Order-Id]) VALUES (134, N'', 10, 58, N'To Do List', 61)
INSERT [dbo].[MasterModules] ([ID], [Module-Name], [Module-Id], [Tab-Id], [Tab-Name], [Order-Id]) VALUES (135, N'', 10, 59, N'Audit Trail', 62)
SET IDENTITY_INSERT [dbo].[MasterModules] OFF

INSERT [dbo].[Options] ([ID], [Date-Format], [Number-Format], [Decimal-Places], [Currency-Code], [Starting-Sales-Inv-No], [Name-to-Print-Sales-Invoice], [Def-Cash-Bank-Acc], [Show-Amount-Inc-GST], [Show-Account-Balance], [Cus-Detail-Allow-Chg-Limit], [PS-Detail-Allow-Chg-Act], [Allow-to-Create-Sales-Inv], [Show-PS-Name], [Show-PS-Name-Desc], [Allow-Edit-PS-Name-Desc], [Allow-Edit-PS-Price], [Allow-Edit-Discount], [Hide-Discount-Column], [PS-Qty-Jump-Next-Line], [Print-PS-Name], [Print-PS-Name-Desc], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [Print-Del-Sales-Inv]) VALUES (0, N'dd/MM/yy', N'en-US', 2, N'INR12', N'2', N'Tax Invoice', N'17', 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 1, 0, 0, CAST(N'2017-03-23 19:33:59.953' AS DateTime), 0, CAST(N'2018-02-13 10:33:34.593' AS DateTime), 0)

SET IDENTITY_INSERT [dbo].[TaxCodesAndRates] ON 

INSERT [dbo].[TaxCodesAndRates] ([ID], [Tax-Name], [Tax-Description], [Tax-Code], [Tax-Rate], [Tax-Inactive], [Tax-Default], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsDeleted], [Predefined]) VALUES (1, N'GST', N'GST Free', N'GST-0', CAST(0.00 AS Decimal(16, 2)), N'N', 0, NULL, CAST(getdate() AS DateTime), NULL, CAST(getdate() AS DateTime), 0, 1)

SET IDENTITY_INSERT [dbo].[TaxCodesAndRates] OFF
SET IDENTITY_INSERT [dbo].[TermsAndConditions] ON 

INSERT [dbo].[TermsAndConditions] ([ID], [Cat-Name], [Cat-Code], [SrNo], [Cat-Content]) VALUES (1, N'Sales Quotation - Terms & Conditions', N'SQTC', 1, N'Quotation which is created will be ordered by Retailers and Quantity will be informed')
INSERT [dbo].[TermsAndConditions] ([ID], [Cat-Name], [Cat-Code], [SrNo], [Cat-Content]) VALUES (2, N'Sales Order - Terms & Conditions', N'SOTC', 2, N'These are the Terms and Conditions of Service ("Terms") under which SAS
')
INSERT [dbo].[TermsAndConditions] ([ID], [Cat-Name], [Cat-Code], [SrNo], [Cat-Content]) VALUES (3, N'Sales Invoice - Terms & Conditions', N'SITC', 3, N'Unpacked item will not be returned')
INSERT [dbo].[TermsAndConditions] ([ID], [Cat-Name], [Cat-Code], [SrNo], [Cat-Content]) VALUES (4, N'Purchase Quotation - Terms & Conditions', N'PQTC', 4, N'Valid till 30 days')
INSERT [dbo].[TermsAndConditions] ([ID], [Cat-Name], [Cat-Code], [SrNo], [Cat-Content]) VALUES (5, N'Purchase Order - Terms & Conditions', N'POTC', 5, N'Unpacked item will not be accepted')
INSERT [dbo].[TermsAndConditions] ([ID], [Cat-Name], [Cat-Code], [SrNo], [Cat-Content]) VALUES (6, N'Purchase Invoice - Terms & Conditions', N'PITC', 6, N'Unpacked item will not be accepted')
INSERT [dbo].[TermsAndConditions] ([ID], [Cat-Name], [Cat-Code], [SrNo], [Cat-Content]) VALUES (7, N'Debit Note - Reason', N'DNR', 7, N'Service charges deducted in actual price')
INSERT [dbo].[TermsAndConditions] ([ID], [Cat-Name], [Cat-Code], [SrNo], [Cat-Content]) VALUES (8, N'Credit Note - Reason', N'CNR', 8, N'Interest will be credited into account')
SET IDENTITY_INSERT [dbo].[TermsAndConditions] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserId], [FirstName], [LastName], [User-Name], [User-Password], [User-Email], [User-Type], [Active], [CreatedBy], [CreatedDate], [IsDeleted], [IsSuperAdmin], [DeletedBy], [DeletedDate], [ModifiedBy], [ModifiedDate]) 
VALUES (1, NULL, NULL, N'Admin', N'jWqiENuTZHPXtZFGSih39g==', N'Simple@accounting.com', NULL, 0, NULL, CAST(getdate() AS DateTime), 0, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Users] OFF
SET IDENTITY_INSERT [dbo].[UserSecurity] ON 
INSERT [dbo].[UserSecurity] ([ID], [User-Id], [Tab-Id]) VALUES (1, 1, N'1         ')
INSERT [dbo].[UserSecurity] ([ID], [User-Id], [Tab-Id]) VALUES (2, 1, N'2         ')
INSERT [dbo].[UserSecurity] ([ID], [User-Id], [Tab-Id]) VALUES (3, 1, N'3         ')
INSERT [dbo].[UserSecurity] ([ID], [User-Id], [Tab-Id]) VALUES (4, 1, N'4         ')
INSERT [dbo].[UserSecurity] ([ID], [User-Id], [Tab-Id]) VALUES (5, 1, N'5         ')
INSERT [dbo].[UserSecurity] ([ID], [User-Id], [Tab-Id]) VALUES (6, 1, N'6         ')
INSERT [dbo].[UserSecurity] ([ID], [User-Id], [Tab-Id]) VALUES (7, 1, N'7         ')
INSERT [dbo].[UserSecurity] ([ID], [User-Id], [Tab-Id]) VALUES (8, 1, N'8         ')
INSERT [dbo].[UserSecurity] ([ID], [User-Id], [Tab-Id]) VALUES (9, 1, N'9         ')
INSERT [dbo].[UserSecurity] ([ID], [User-Id], [Tab-Id]) VALUES (10, 1, N'10        ')
INSERT [dbo].[UserSecurity] ([ID], [User-Id], [Tab-Id]) VALUES (11, 1, N'11        ')
INSERT [dbo].[UserSecurity] ([ID], [User-Id], [Tab-Id]) VALUES (12, 1, N'12        ')
INSERT [dbo].[UserSecurity] ([ID], [User-Id], [Tab-Id]) VALUES (13, 1, N'13        ')
INSERT [dbo].[UserSecurity] ([ID], [User-Id], [Tab-Id]) VALUES (14, 1, N'14        ')
INSERT [dbo].[UserSecurity] ([ID], [User-Id], [Tab-Id]) VALUES (15, 1, N'15        ')
INSERT [dbo].[UserSecurity] ([ID], [User-Id], [Tab-Id]) VALUES (16, 1, N'16        ')
INSERT [dbo].[UserSecurity] ([ID], [User-Id], [Tab-Id]) VALUES (17, 1, N'17        ')
INSERT [dbo].[UserSecurity] ([ID], [User-Id], [Tab-Id]) VALUES (18, 1, N'18        ')
INSERT [dbo].[UserSecurity] ([ID], [User-Id], [Tab-Id]) VALUES (19, 1, N'19        ')
INSERT [dbo].[UserSecurity] ([ID], [User-Id], [Tab-Id]) VALUES (20, 1, N'20        ')
INSERT [dbo].[UserSecurity] ([ID], [User-Id], [Tab-Id]) VALUES (21, 1, N'21        ')
INSERT [dbo].[UserSecurity] ([ID], [User-Id], [Tab-Id]) VALUES (22, 1, N'22        ')
INSERT [dbo].[UserSecurity] ([ID], [User-Id], [Tab-Id]) VALUES (23, 1, N'23        ')
INSERT [dbo].[UserSecurity] ([ID], [User-Id], [Tab-Id]) VALUES (24, 1, N'24        ')
INSERT [dbo].[UserSecurity] ([ID], [User-Id], [Tab-Id]) VALUES (25, 1, N'25        ')
INSERT [dbo].[UserSecurity] ([ID], [User-Id], [Tab-Id]) VALUES (26, 1, N'26        ')
INSERT [dbo].[UserSecurity] ([ID], [User-Id], [Tab-Id]) VALUES (27, 1, N'27        ')
INSERT [dbo].[UserSecurity] ([ID], [User-Id], [Tab-Id]) VALUES (28, 1, N'28        ')
INSERT [dbo].[UserSecurity] ([ID], [User-Id], [Tab-Id]) VALUES (29, 1, N'29        ')
INSERT [dbo].[UserSecurity] ([ID], [User-Id], [Tab-Id]) VALUES (30, 1, N'30        ')
INSERT [dbo].[UserSecurity] ([ID], [User-Id], [Tab-Id]) VALUES (31, 1, N'31        ')
INSERT [dbo].[UserSecurity] ([ID], [User-Id], [Tab-Id]) VALUES (32, 1, N'32        ')
INSERT [dbo].[UserSecurity] ([ID], [User-Id], [Tab-Id]) VALUES (33, 1, N'33        ')
INSERT [dbo].[UserSecurity] ([ID], [User-Id], [Tab-Id]) VALUES (34, 1, N'34        ')
GO															
INSERT [dbo].[UserSecurity] ([ID], [User-Id], [Tab-Id]) VALUES (35, 1, N'35        ')
INSERT [dbo].[UserSecurity] ([ID], [User-Id], [Tab-Id]) VALUES (36, 1, N'36        ')
INSERT [dbo].[UserSecurity] ([ID], [User-Id], [Tab-Id]) VALUES (37, 1, N'37        ')
INSERT [dbo].[UserSecurity] ([ID], [User-Id], [Tab-Id]) VALUES (38, 1, N'38        ')
INSERT [dbo].[UserSecurity] ([ID], [User-Id], [Tab-Id]) VALUES (39, 1, N'39        ')
INSERT [dbo].[UserSecurity] ([ID], [User-Id], [Tab-Id]) VALUES (40, 1, N'40        ')
INSERT [dbo].[UserSecurity] ([ID], [User-Id], [Tab-Id]) VALUES (41, 1, N'41        ')
INSERT [dbo].[UserSecurity] ([ID], [User-Id], [Tab-Id]) VALUES (42, 1, N'42        ')
INSERT [dbo].[UserSecurity] ([ID], [User-Id], [Tab-Id]) VALUES (43, 1, N'43        ')
INSERT [dbo].[UserSecurity] ([ID], [User-Id], [Tab-Id]) VALUES (44, 1, N'44        ')
INSERT [dbo].[UserSecurity] ([ID], [User-Id], [Tab-Id]) VALUES (45, 1, N'45        ')
INSERT [dbo].[UserSecurity] ([ID], [User-Id], [Tab-Id]) VALUES (46, 1, N'46        ')
INSERT [dbo].[UserSecurity] ([ID], [User-Id], [Tab-Id]) VALUES (47, 1, N'47        ')
INSERT [dbo].[UserSecurity] ([ID], [User-Id], [Tab-Id]) VALUES (48, 1, N'48        ')
INSERT [dbo].[UserSecurity] ([ID], [User-Id], [Tab-Id]) VALUES (49, 1, N'49        ')
INSERT [dbo].[UserSecurity] ([ID], [User-Id], [Tab-Id]) VALUES (50, 1, N'50        ')
INSERT [dbo].[UserSecurity] ([ID], [User-Id], [Tab-Id]) VALUES (51, 1, N'51        ')
INSERT [dbo].[UserSecurity] ([ID], [User-Id], [Tab-Id]) VALUES (52, 1, N'52        ')
INSERT [dbo].[UserSecurity] ([ID], [User-Id], [Tab-Id]) VALUES (53, 1, N'53        ')
INSERT [dbo].[UserSecurity] ([ID], [User-Id], [Tab-Id]) VALUES (54, 1, N'54        ')
INSERT [dbo].[UserSecurity] ([ID], [User-Id], [Tab-Id]) VALUES (55, 1, N'55        ')
INSERT [dbo].[UserSecurity] ([ID], [User-Id], [Tab-Id]) VALUES (56, 1, N'56        ')
INSERT [dbo].[UserSecurity] ([ID], [User-Id], [Tab-Id]) VALUES (57, 1, N'57        ')
INSERT [dbo].[UserSecurity] ([ID], [User-Id], [Tab-Id]) VALUES (58, 1, N'58        ')
INSERT [dbo].[UserSecurity] ([ID], [User-Id], [Tab-Id]) VALUES (59, 1, N'59        ')

SET IDENTITY_INSERT [dbo].[UserSecurity] OFF
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Customer does not have credit facility or exceeded credit limit amount' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Options', @level2type=N'COLUMN',@level2name=N'Allow-to-Create-Sales-Inv'
GO
