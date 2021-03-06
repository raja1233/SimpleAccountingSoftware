
GO
/****** Object:  Table [dbo].[AccountsTransactions]    Script Date: 3/5/2018 5:53:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AccountsTransactions](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Acc-Id] [int] NULL,
	[Trans-Type] [nvarchar](50) NULL,
	[Name] [nvarchar](100) NULL,
	[No] [nvarchar](50) NULL,
	[Trans-Date] [datetime] NULL,
	[Trans-Amount] [decimal](18, 4) NULL,
	[Year-to-Date] [datetime] NULL,
	[Opening-Balance] [decimal](18, 4) NULL,
	[Closing-Balance] [decimal](18, 4) NULL,
	[In-Active] [char](1) NULL,
	[Invoice-Type] [nvarchar](5) NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [int] NULL,
 CONSTRAINT [PK_AccountsTransactions] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AdjustedCreditNote]    Script Date: 3/5/2018 5:53:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdjustedCreditNote](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NULL,
	[CreditNoteNumber] [nvarchar](20) NULL,
	[CreditNoteDate] [datetime] NULL,
	[CreditNoteAmount] [decimal](18, 4) NULL,
	[AdjustCreditNoteNumber] [nvarchar](20) NULL,
	[AdjustCreditNoteDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_AdjustedCreditNote] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AdjustedCreditNoteDetails]    Script Date: 3/5/2018 5:53:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdjustedCreditNoteDetails](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ACN_ID] [int] NULL,
	[SalesInvoiceNo] [nvarchar](20) NULL,
	[SalesInvoiceDate] [datetime] NULL,
	[PaymentDueDate] [datetime] NULL,
	[SalesInvoiceAmount] [decimal](18, 4) NULL,
	[AmountDue] [decimal](18, 4) NULL,
	[AmountAdjusted] [decimal](18, 4) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_AdjustedCreditNoteDetails] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AdjustedDebitNote]    Script Date: 3/5/2018 5:53:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdjustedDebitNote](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SupplierID] [int] NULL,
	[DebitNoteNumber] [nvarchar](50) NULL,
	[DebitNoteDate] [datetime] NULL,
	[DebitNoteAmount] [decimal](18, 4) NULL,
	[AdjustDebitNoteNumber] [nvarchar](50) NULL,
	[AdjustDebitNoteDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_AdjustedDebitNote] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AdjustedDebitNoteDetails]    Script Date: 3/5/2018 5:53:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdjustedDebitNoteDetails](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ADN_ID] [int] NULL,
	[PurchaseInvoiceNo] [nchar](10) NULL,
	[PurchaseInvoiceDate] [datetime] NULL,
	[PaymentDueDate] [datetime] NULL,
	[PurchaseInvoiceAmount] [decimal](18, 4) NULL,
	[AmountDue] [decimal](18, 4) NULL,
	[AmountAdjusted] [decimal](18, 4) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_AdjustedDebitNoteDetails] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BusinessExpenses]    Script Date: 3/5/2018 5:53:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BusinessExpenses](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PI-No] [nvarchar](50) NOT NULL,
	[PI-Date] [date] NOT NULL CONSTRAINT [DF_BusinessExpenses_PI-Date]  DEFAULT (getdate()),
	[PI-Pmt-Due-Date] [date] NULL,
	[Our-PO-No] [nvarchar](50) NULL,
	[Exc-Inc-GST] [bit] NULL,
	[Sup-Id] [int] NOT NULL,
	[PI-Tot-bef-Tax] [decimal](18, 4) NULL,
	[PI-GST-Amt] [decimal](18, 4) NULL,
	[PI-Tot-aft-Tax] [decimal](18, 4) NULL,
	[PI-TandC] [nvarchar](max) NULL,
	[PI-Status] [tinyint] NULL CONSTRAINT [DF_BusinessExpenses_PI-Status]  DEFAULT ((0)),
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsDeleted] [bit] NULL CONSTRAINT [DF_BusinessExpenses_IsDeleted]  DEFAULT ((0)),
 CONSTRAINT [PK_BusinessExpenses] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BusinessExpensesDetails]    Script Date: 3/5/2018 5:53:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BusinessExpensesDetails](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PI-ID] [int] NOT NULL,
	[PI-Amount] [decimal](18, 4) NULL,
	[GST-Code] [nvarchar](10) NULL,
	[GST-Rate] [decimal](18, 4) NULL,
	[Bus-Expenses-Desc] [nvarchar](200) NULL,
	[Bus-Expenses-Acc-Name] [nvarchar](100) NULL,
 CONSTRAINT [PK_BusinessExpensesDetails] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CashAndBank]    Script Date: 3/5/2018 5:53:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CashAndBank](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Acc-Id] [int] NULL,
	[Acc-Name] [nvarchar](100) NULL,
	[Opening-Balance] [decimal](18, 4) NULL,
	[Current-Balance] [decimal](18, 4) NULL,
	[Year-to-Date] [date] NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [int] NULL,
 CONSTRAINT [PK_CashAndBank] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CashAndBankDetails]    Script Date: 3/5/2018 5:53:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CashAndBankDetails](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Cus-Id] [int] NOT NULL,
	[Cus-Name] [nvarchar](100) NOT NULL,
	[Year] [tinyint] NULL,
	[Quarter] [tinyint] NULL,
	[Month] [tinyint] NULL,
	[Start-Date] [date] NULL,
	[End-Date] [date] NULL,
	[Cash-Cheq-No] [nvarchar](20) NULL,
	[Cash-Cheq-Date] [date] NULL,
	[Cash-Cheq-Amount] [decimal](18, 4) NULL,
	[SO-SI-No] [nvarchar](50) NULL,
	[SO-SI-Date] [date] NULL,
	[SO-SI-Amount] [decimal](18, 4) NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [int] NULL,
 CONSTRAINT [PK_CashAndBankDetails] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CashAndBankHistory]    Script Date: 3/5/2018 5:53:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CashAndBankHistory](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Acc-Id] [int] NULL,
	[Acc-Name] [nvarchar](100) NULL,
	[Year1] [tinyint] NULL,
	[Year2] [tinyint] NULL,
	[Quater] [tinyint] NULL,
	[Col1-Amt] [decimal](18, 4) NULL,
	[Col2-Amt] [decimal](18, 4) NULL,
	[Col3-Amt] [decimal](18, 4) NULL,
	[Total] [decimal](18, 4) NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [int] NULL,
 CONSTRAINT [PK_CashAndBankHistory] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CashAndBankStatement]    Script Date: 3/5/2018 5:53:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CashAndBankStatement](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Acc-Id] [int] NULL,
	[Acc-Name] [nvarchar](100) NULL,
	[Year] [tinyint] NULL,
	[Quarter] [tinyint] NULL,
	[Month] [tinyint] NULL,
	[Start-Date] [date] NULL,
	[End-Date] [date] NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Cash-Cheq-No] [nvarchar](20) NULL,
	[Cash-Cheq-Date] [date] NULL,
	[Deposit] [decimal](18, 4) NULL,
	[Withdrawal] [decimal](18, 4) NULL,
	[Balance] [decimal](18, 4) NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [int] NULL,
 CONSTRAINT [PK_CashAndBankStatement] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CashAndBankTransactions]    Script Date: 3/5/2018 5:53:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CashAndBankTransactions](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Cus-Sup-Id] [int] NULL,
	[Name] [nvarchar](100) NULL,
	[Type] [nchar](1) NULL,
	[Acc-Id] [int] NULL,
	[Is-Cheque] [bit] NULL,
	[Cash-Cheque-No] [nvarchar](20) NULL,
	[Cash-Cheque-Date] [date] NULL,
	[Amount] [decimal](18, 4) NULL,
	[Remarks] [nvarchar](200) NULL,
	[Cheque-Photo] [varchar](max) NULL,
	[SO-CN-PO-DN-No] [nvarchar](50) NULL,
	[SO-CN-PO-DN-Date] [datetime] NULL,
	[SO-CN-PO-DN-Amt] [decimal](18, 4) NULL,
	[Amt-Due] [decimal](18, 4) NULL,
	[Discount] [decimal](18, 4) NULL,
	[Amt-Refunded] [decimal](18, 4) NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[DN-CN-No] [varchar](50) NULL,
	[AD_AC_NO] [varchar](50) NULL,
 CONSTRAINT [PK_CashAndBankTransactions] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CashFlowCalendar]    Script Date: 3/5/2018 5:53:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CashFlowCalendar](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Year1] [tinyint] NULL,
	[Year2] [tinyint] NULL,
	[Cash-Flow-Month] [tinyint] NULL,
	[Amt-Mon] [decimal](18, 4) NULL,
	[Amt-Tue] [decimal](18, 4) NULL,
	[Amt-Wed] [decimal](18, 4) NULL,
	[Amt-Thu] [decimal](18, 4) NULL,
	[Amt-Fri] [decimal](18, 4) NULL,
	[Amt-Sat] [decimal](18, 4) NULL,
	[Amt-Sun] [decimal](18, 4) NULL,
	[Row-Type] [nchar](3) NULL,
	[View-Type] [nchar](2) NOT NULL,
	[Payment-To-Cus] [decimal](18, 4) NULL,
	[Payment-To-Sup] [decimal](18, 4) NULL,
	[LV-Net-Amt] [decimal](18, 4) NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [int] NULL,
 CONSTRAINT [PK_CashFlowCalendar] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CategoriesContent]    Script Date: 3/5/2018 5:53:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CategoriesContent](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Cat-Id] [int] NULL,
	[Content-Limit] [decimal](18, 0) NULL,
	[Cat-Contents] [nvarchar](200) NULL,
	[Set-Default] [bit] NULL CONSTRAINT [DF_CategoriesContent_Set-Default]  DEFAULT ((0)),
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsDeleted] [bit] NULL CONSTRAINT [DF_CategoriesContent_IsDeleted]  DEFAULT ((0)),
	[Predefined] [bit] NULL,
 CONSTRAINT [PK_CategoriesContent] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CompanyDetails]    Script Date: 3/5/2018 5:53:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CompanyDetails](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Comp-Name] [nvarchar](70) NOT NULL,
	[Comp-Reg-No] [nvarchar](50) NULL,
	[Comp-GST-Reg-No] [nvarchar](50) NULL,
	[Comp-GST-Reg-Date] [datetime] NULL,
	[Comp-GST-Dereg-Date] [datetime] NULL,
	[Comp-Tel] [nvarchar](30) NULL,
	[Comp-Fax] [nvarchar](30) NULL,
	[Comp-Email] [nvarchar](100) NULL,
	[Comp-year-start-date] [date] NULL,
	[Comp-year-end-date] [date] NULL,
	[Comp-Logo] [varbinary](max) NULL,
	[Software-Ser-No] [nvarchar](100) NULL,
	[Comp-Bill-to-line1] [nvarchar](100) NULL,
	[Comp-Bill-to-line2] [nvarchar](100) NULL,
	[Comp-Bill-to-city] [nvarchar](50) NULL,
	[Comp-Bill-to-state] [nvarchar](50) NULL,
	[Comp-Bill-to-country] [nvarchar](50) NULL,
	[Comp-Bill-to-post-code] [nvarchar](10) NULL,
	[Comp-Ship-to-line1] [nvarchar](100) NULL,
	[Comp-Ship-to-line2] [nvarchar](100) NULL,
	[Comp-Ship-to-city] [nvarchar](50) NULL,
	[Comp-Ship-to-state] [nvarchar](50) NULL,
	[Comp-Ship-to-country] [nvarchar](50) NULL,
	[Comp-Ship-to-post-code] [nvarchar](10) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsDeleted] [bit] NULL,
	[GST_Registered] [bit] NULL,
 CONSTRAINT [PK_CompanyDetails] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CreditNotes]    Script Date: 3/5/2018 5:53:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CreditNotes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CN-No] [nvarchar](50) NOT NULL,
	[CN-Date] [datetime] NULL CONSTRAINT [DF_CreditNotes_CN-Date]  DEFAULT (getdate()),
	[Cus-DN-No] [nvarchar](50) NULL,
	[Cus-DN-Date] [datetime] NULL,
	[Salesman] [int] NULL,
	[Cus-DN-Amount] [decimal](18, 4) NULL,
	[Cus-Id] [int] NOT NULL,
	[SI-Id] [int] NOT NULL,
	[CN-Status] [tinyint] NULL,
	[CN-Reason] [nvarchar](200) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsDeleted] [bit] NULL CONSTRAINT [DF_CreditNotes_IsDeleted]  DEFAULT ((0)),
	[CN-Amount] [decimal](18, 4) NULL,
 CONSTRAINT [PK_CreditNotes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CustomerDetails]    Script Date: 3/5/2018 5:53:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CustomerDetails](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Cus-Id] [int] NOT NULL,
	[Cus-Name] [nvarchar](100) NULL,
	[Cus-Inactive] [char](1) NULL,
	[Cus-Company-Reg-no] [nvarchar](50) NULL,
	[Cus-Type] [int] NULL,
	[Cus-Salesman] [int] NULL,
	[Cus-Credit-Limit-Days] [int] NULL,
	[Cus-Credit-Limit-Amount] [int] NULL,
	[Cus-Discount] [int] NULL,
	[Cus-Telephone] [nvarchar](30) NULL,
	[Cus-Fax] [nvarchar](30) NULL,
	[Cus-Email] [nvarchar](100) NULL,
	[Cus-Contact-Person] [nvarchar](100) NULL,
	[Cus-GST-Reg-No] [nvarchar](50) NULL,
	[Cus-Charge-GST] [bit] NULL,
	[Cus-Remarks] [nvarchar](max) NULL,
	[Cus-Bill-to-line1] [nvarchar](100) NULL,
	[Cus-Bill-to-line2] [nvarchar](100) NULL,
	[Cus-Bill-to-city] [nvarchar](50) NULL,
	[Cus-Bill-to-state] [nvarchar](50) NULL,
	[Cus-Bill-to-country] [nvarchar](50) NULL,
	[Cus-Bill-to-post-code] [nvarchar](10) NULL,
	[Cus-Ship-to-line1] [nvarchar](100) NULL,
	[Cus-Ship-to-line2] [nvarchar](100) NULL,
	[Cus-Ship-to-city] [nvarchar](50) NULL,
	[Cus-Ship-to-state] [nvarchar](50) NULL,
	[Cus-Ship-to-country] [nvarchar](50) NULL,
	[Cus-Ship-to-post-code] [nvarchar](10) NULL,
	[UpdatedBy] [nvarchar](100) NULL,
	[LastUpdateDate] [datetime] NULL,
	[IsDeleted] [bit] NULL,
	[Cus-Balance] [decimal](18, 4) NULL,
 CONSTRAINT [PK_CustomerDetails] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 3/5/2018 5:53:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Customers](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Cus-Name] [nvarchar](100) NULL,
	[Cus-Inactive] [char](1) NULL CONSTRAINT [DF_Customers_Cus-Inactive]  DEFAULT ('N'),
	[Cus-Company-Reg-no] [nvarchar](50) NULL,
	[Cus-Type] [nvarchar](10) NULL,
	[Cus-Salesman] [int] NULL,
	[Cus-Credit-Limit-Days] [int] NULL,
	[Cus-Credit-Limit-Amount] [int] NULL,
	[Cus-Discount] [int] NULL,
	[Cus-Telephone] [nvarchar](30) NULL,
	[Cus-Fax] [nvarchar](30) NULL,
	[Cus-Email] [nvarchar](100) NULL,
	[Cus-Contact-Person] [nvarchar](100) NULL,
	[Cus-GST-Reg-No] [nvarchar](50) NULL,
	[Cus-Charge-GST] [bit] NULL CONSTRAINT [DF_Customers_Cus-Charge-GST]  DEFAULT ((0)),
	[Cus-Remarks] [nvarchar](max) NULL,
	[Cus-Bill-to-line1] [nvarchar](100) NULL,
	[Cus-Bill-to-line2] [nvarchar](100) NULL,
	[Cus-Bill-to-city] [nvarchar](50) NULL,
	[Cus-Bill-to-state] [nvarchar](50) NULL,
	[Cus-Bill-to-country] [nvarchar](50) NULL,
	[Cus-Bill-to-post-code] [nvarchar](10) NULL,
	[Cus-Ship-to-line1] [nvarchar](100) NULL,
	[Cus-Ship-to-line2] [nvarchar](100) NULL,
	[Cus-Ship-to-city] [nvarchar](50) NULL,
	[Cus-Ship-to-state] [nvarchar](50) NULL,
	[Cus-Ship-to-country] [nvarchar](50) NULL,
	[Cus-Ship-to-post-code] [nvarchar](10) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsDeleted] [bit] NULL CONSTRAINT [DF_Customers_IsDeleted]  DEFAULT ((0)),
	[Cus-Balance] [decimal](18, 0) NULL,
	[IsRefreshed] [bit] NULL,
	[RefreshedDate] [datetime] NULL,
	[TaxId] [int] NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CustomersBusinessCard]    Script Date: 3/5/2018 5:53:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CustomersBusinessCard](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Cus-Id] [int] NULL,
	[Cus-Bus-Card-Name] [nvarchar](100) NULL,
	[Cus-Bus-Card-Photos] [varbinary](max) NULL,
 CONSTRAINT [PK_CustomersBusinessCard] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CustomersCreditDaysPaidInDays]    Script Date: 3/5/2018 5:53:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomersCreditDaysPaidInDays](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Cus-Id] [int] NOT NULL,
	[Cus-Name] [nvarchar](100) NOT NULL,
	[Year] [tinyint] NULL,
	[Quarter] [tinyint] NULL,
	[Month] [tinyint] NULL,
	[Start-Date] [date] NULL,
	[End-Date] [date] NULL,
	[Inv-No] [nvarchar](50) NULL,
	[Inv-Amount] [decimal](18, 4) NULL,
	[Inv-Date] [datetime] NULL,
	[Payment-Due-Date] [datetime] NULL,
	[Paid-Date] [datetime] NULL,
	[Credit-Days] [int] NULL,
	[Paidin-Days] [int] NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [int] NULL,
 CONSTRAINT [PK_CustomersCreditDaysPaidInDays] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CustomersHistory]    Script Date: 3/5/2018 5:53:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomersHistory](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Cus-Id] [int] NOT NULL,
	[Cus-Name] [nvarchar](100) NOT NULL,
	[Col1-Amount] [decimal](18, 4) NULL,
	[Col2-Amount] [decimal](18, 4) NULL,
	[Col3-Amount] [decimal](18, 4) NULL,
	[Total-Sales-Amount] [decimal](18, 4) NULL,
	[Year1] [tinyint] NULL,
	[Year2] [tinyint] NULL,
	[Quarter] [tinyint] NULL,
	[[Inc-GST] [bit] NULL,
	[LastUpdated] [datetime] NULL,
	[UpdatedBy] [int] NULL,
 CONSTRAINT [PK_CustomersHistory] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CustomersPaymentDueDays]    Script Date: 3/5/2018 5:53:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomersPaymentDueDays](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Cus-Id] [int] NOT NULL,
	[Cus-Name] [nvarchar](100) NOT NULL,
	[Balance] [decimal](18, 4) NULL,
	[1-30Days] [decimal](18, 4) NULL,
	[31-60Days] [decimal](18, 4) NULL,
	[61-90Days] [decimal](18, 4) NULL,
	[GreaterThen-90Days] [decimal](18, 4) NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [int] NULL,
 CONSTRAINT [PK_CustomersPaymentDueDays] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CustomersStatement]    Script Date: 3/5/2018 5:53:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomersStatement](
	[ID] [int] NOT NULL,
	[Cus-Id] [int] NOT NULL,
	[Cus-Name] [nvarchar](100) NOT NULL,
	[Statement-Date] [date] NULL,
	[Balance] [decimal](18, 4) NULL,
	[1-30Days] [decimal](18, 4) NULL,
	[31-60Days] [decimal](18, 4) NULL,
	[61-90Days] [decimal](18, 4) NULL,
	[GreaterThen-90Days] [decimal](18, 4) NULL,
	[Inv-No] [nvarchar](50) NULL,
	[Inv-Date] [datetime] NULL,
	[Payment-Due-Date] [datetime] NULL,
	[Inv-Amount] [decimal](18, 4) NULL,
	[Amount-Paid] [decimal](18, 4) NULL,
	[Amount-Due] [decimal](18, 4) NULL,
	[LastUpdatedDate] [datetime] NULL,
	[UpdatedBy] [int] NULL,
 CONSTRAINT [PK_CustomersStatement] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DebitNotes]    Script Date: 3/5/2018 5:53:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DebitNotes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DN-No] [nvarchar](50) NOT NULL,
	[DN-Date] [datetime] NULL CONSTRAINT [DF_DebitNotes_DN-Date]  DEFAULT (getdate()),
	[Sup-CN-No] [nvarchar](50) NULL,
	[Sup-CN-Date] [datetime] NULL,
	[Sup-CN-Amount] [decimal](18, 4) NULL,
	[Sup-Id] [int] NOT NULL,
	[PI-Id] [int] NOT NULL,
	[DN-Reason] [nvarchar](200) NULL,
	[DN-Status] [tinyint] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsDeleted] [bit] NULL CONSTRAINT [DF_DebitNotes_IsDeleted]  DEFAULT ((0)),
	[DN-Amount] [decimal](18, 4) NULL,
 CONSTRAINT [PK_DebitNotes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[InvoicesCreditNotesPayments]    Script Date: 3/5/2018 5:53:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InvoicesCreditNotesPayments](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Cus-Id] [int] NOT NULL,
	[Cus-Name] [nvarchar](100) NOT NULL,
	[Year] [tinyint] NULL,
	[Quarter] [tinyint] NULL,
	[Month] [tinyint] NULL,
	[Start-Date] [date] NULL,
	[End-Date] [date] NULL,
	[Transaction-Type] [nvarchar](30) NULL,
	[Transaction-No] [nvarchar](50) NULL,
	[Trans-Date] [datetime] NULL,
	[Amount] [decimal](18, 4) NULL,
	[Balance] [decimal](18, 4) NULL,
	[Opening-Balance] [decimal](18, 4) NULL,
	[Closing-Balance] [decimal](18, 4) NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [int] NULL,
 CONSTRAINT [PK_InvoicesCreditNotesPayments] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[InvoicesDebitNotesPayments]    Script Date: 3/5/2018 5:53:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InvoicesDebitNotesPayments](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Sup-Id] [int] NOT NULL,
	[Sup-Name] [nvarchar](100) NOT NULL,
	[Year] [tinyint] NULL,
	[Quarter] [tinyint] NULL,
	[Month] [tinyint] NULL,
	[Start-Date] [date] NULL,
	[End-Date] [date] NULL,
	[Transaction-Type] [nvarchar](30) NULL,
	[Transaction-No] [nvarchar](50) NULL,
	[Trans-Date] [datetime] NULL,
	[Amount] [decimal](18, 4) NULL,
	[Balance] [decimal](18, 4) NULL,
	[Opening-Balance] [decimal](18, 4) NULL,
	[Closing-Balance] [decimal](18, 4) NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [int] NULL,
 CONSTRAINT [PK_InvoicesDebitNotesPayments] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Journal]    Script Date: 3/5/2018 5:53:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Journal](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[J_No] [nchar](20) NULL,
	[J_Date] [datetime] NULL,
	[J_CreatedBy] [int] NULL,
	[J_ModifiedBy] [int] NULL,
	[J_ModifiedDate] [datetime] NULL,
	[J_IsDeleted] [bit] NULL,
	[J_CreatedDate] [datetime] NULL,
 CONSTRAINT [PK_Journal] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[JournalDetails]    Script Date: 3/5/2018 5:53:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JournalDetails](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[JO-ID ] [int] NOT NULL,
	[JO-No] [nchar](10) NULL,
	[JO-Date] [datetime] NULL,
	[Acc-ID] [int] NULL,
	[JO-Debit ] [decimal](18, 4) NULL,
	[JO-Credit ] [decimal](18, 4) NULL,
	[JO_CreatedBy ] [int] NULL,
	[JO_ModifiedBy ] [int] NULL,
	[JO_ModifiedDate ] [datetime] NULL,
	[JO_IsDeleted ] [bit] NULL,
 CONSTRAINT [PK_JournalDetails] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LastSelectionHistory]    Script Date: 3/5/2018 5:53:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LastSelectionHistory](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Screen-Id] [int] NOT NULL,
	[Screen-Name] [nvarchar](50) NOT NULL,
	[Last-Selection] [nvarchar](max) NULL,
	[Last-Updated] [datetime] NULL,
	[Last-UpdatedBy] [int] NULL,
 CONSTRAINT [PK_LastSelectionHistory] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PandSHistory]    Script Date: 3/5/2018 5:53:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[PandSHistory](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PandS-Code] [nvarchar](30) NOT NULL,
	[P&S-Name] [nvarchar](50) NOT NULL,
	[Col1-Sal-Amount] [decimal](18, 4) NULL,
	[Col1-Pur-Amount] [decimal](18, 4) NULL,
	[Col2-Sal-Amount] [decimal](18, 4) NULL,
	[Col2-Pur-Amount] [decimal](18, 4) NULL,
	[Col3-Sal-Amount] [decimal](18, 4) NULL,
	[Col3-Pur-Amount] [decimal](18, 4) NULL,
	[PandS-Cat1] [nvarchar](10) NULL,
	[PandS-Cat2] [nvarchar](10) NULL,
	[Year1] [tinyint] NULL,
	[Year2] [tinyint] NULL,
	[Quarter] [tinyint] NULL,
	[Inc-GST] [bit] NULL,
	[PandS-Type] [char](1) NULL,
	[LastUpdated] [datetime] NULL,
	[UpdatedBy] [int] NULL,
 CONSTRAINT [PK_PandSHistory] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PandSPurchase]    Script Date: 3/5/2018 5:53:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PandSPurchase](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Sup-Id] [int] NOT NULL,
	[Sup-Name] [nvarchar](100) NOT NULL,
	[Year] [tinyint] NULL,
	[Quarter] [tinyint] NULL,
	[Month] [tinyint] NULL,
	[Start-Date] [date] NULL,
	[End-Date] [date] NULL,
	[PandS-Cat1] [nvarchar](10) NULL,
	[PandS-Cat2] [nvarchar](10) NULL,
	[PandS-Code] [nvarchar](30) NULL,
	[PandS-Name] [nvarchar](30) NULL,
	[Qty] [int] NULL,
	[Price] [decimal](18, 4) NULL,
	[Amount] [decimal](18, 4) NULL,
	[Inc-GST] [bit] NULL,
	[PandS-Type] [char](1) NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[InvoiceID] [int] NULL,
 CONSTRAINT [PK_PandSPurchase] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PandSPurchasedFromSuppliers]    Script Date: 3/5/2018 5:53:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PandSPurchasedFromSuppliers](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Sup-Id] [int] NOT NULL,
	[Sup-Name] [nvarchar](100) NOT NULL,
	[Year] [tinyint] NULL,
	[Quarter] [tinyint] NULL,
	[Month] [tinyint] NULL,
	[Start-Date] [date] NULL,
	[End-Date] [date] NULL,
	[Inv-No] [nvarchar](50) NULL,
	[Inv-Date] [datetime] NULL,
	[PandS-Code] [nvarchar](30) NULL,
	[PandS-Name] [nvarchar](30) NULL,
	[Qty] [int] NULL,
	[Price] [decimal](18, 4) NULL,
	[Amount] [decimal](18, 4) NULL,
	[Inc-GST] [bit] NULL,
	[PandS-Type] [char](1) NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [int] NULL,
 CONSTRAINT [PK_PandSPurchasedFromSuppliers] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PandSSold]    Script Date: 3/5/2018 5:53:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PandSSold](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Cus-Id] [int] NOT NULL,
	[Cus-Name] [nvarchar](100) NULL,
	[Year] [int] NULL,
	[Quarter] [tinyint] NULL,
	[Month] [tinyint] NULL,
	[Start-Date] [date] NULL,
	[End-Date] [date] NULL,
	[PandS-Cat1] [nvarchar](10) NULL,
	[PandS-Cat2] [nvarchar](10) NULL,
	[PandS-Code] [nvarchar](30) NULL,
	[PandS-Name] [nvarchar](30) NULL,
	[Qty] [int] NULL,
	[Price] [decimal](18, 4) NULL,
	[Amount] [decimal](18, 4) NULL,
	[Inc-GST] [bit] NULL,
	[PandS-Type] [char](1) NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[TaxRate] [decimal](18, 4) NULL,
 CONSTRAINT [PK_PandSSold] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PandSSoldToCustomer]    Script Date: 3/5/2018 5:53:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PandSSoldToCustomer](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Cus-Id] [int] NOT NULL,
	[Cus-Name] [nvarchar](100) NOT NULL,
	[Year] [tinyint] NULL,
	[Quarter] [tinyint] NULL,
	[Month] [tinyint] NULL,
	[Start-Date] [date] NULL,
	[End-Date] [date] NULL,
	[Inv-No] [nvarchar](50) NULL,
	[Inv-Date] [datetime] NULL,
	[PandS-Code] [nvarchar](30) NULL,
	[PandS-Name] [nvarchar](30) NULL,
	[Qty] [int] NULL,
	[Price] [decimal](18, 4) NULL,
	[Amount] [decimal](18, 4) NULL,
	[Inc-GST] [bit] NULL,
	[PandS-Type] [char](1) NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [int] NULL,
 CONSTRAINT [PK_PandSSoldToCustomer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PayMoney]    Script Date: 3/5/2018 5:53:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PayMoney](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[LinkedAccountID] [int] NULL,
	[CashBankAccountID] [int] NULL,
	[CashChequeNo] [nvarchar](20) NULL,
	[CashChequeDate] [date] NULL,
	[IsCheque] [bit] NULL,
	[TotalBeforeTax] [decimal](18, 4) NULL,
	[TotalAfterTax] [decimal](18, 4) NULL,
	[TotalTax] [decimal](18, 4) NULL,
	[TaxID] [int] NULL,
	[Remarks] [nvarchar](200) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_PayMoney] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProductsAndServices]    Script Date: 3/5/2018 5:53:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ProductsAndServices](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PandS-Type] [char](1) NOT NULL CONSTRAINT [DF_ProductsAndServices_PandS-Type]  DEFAULT ('P'),
	[PandS-Inactive] [char](1) NULL CONSTRAINT [DF_ProductsAndServices_PandS-Inactive]  DEFAULT ('N'),
	[PandS-Code] [nvarchar](30) NOT NULL,
	[PandS-Name] [nvarchar](30) NOT NULL,
	[PandS-Cat1] [int] NULL,
	[PandS-Cat2] [int] NULL,
	[PandS-Description] [nvarchar](max) NULL,
	[Income-Account] [int] NULL,
	[Cost-Account] [int] NULL,
	[Asset-Account] [int] NULL,
	[Tax-ID] [int] NULL,
	[Tax-Rate] [decimal](18, 4) NULL,
	[PandS-Std-Sell-Price-bef-GST] [decimal](18, 4) NULL,
	[PandS-Std-Sell-Price-aft-GST] [decimal](18, 4) NULL,
	[PandS-Ave-Sell-Price-bef-GST] [decimal](18, 4) NULL,
	[PandS-Ave-Sell-Price-aft-GST] [decimal](18, 4) NULL,
	[PandS-Last-Sold-Price-bef-GST] [decimal](18, 4) NULL,
	[PandS-Last-Sold-Price-aft-GST] [decimal](18, 4) NULL,
	[PandS-Std-Cost-Price-bef-GST] [decimal](18, 4) NULL,
	[PandS-Std-Cost-Price-aft-GST] [decimal](18, 4) NULL,
	[PandS-Ave-Cost-Price-bef-GST] [decimal](18, 4) NULL,
	[PandS-Ave-Cost-Price-aft-GST] [decimal](18, 4) NULL,
	[PandS-Last-Pur-Price-bef-GST] [decimal](18, 4) NULL,
	[PandS-Last-Pur-Price-aft-GST] [decimal](18, 4) NULL,
	[PandS-Min-Qty] [int] NULL,
	[PandS-Qty-in-stock] [int] NULL,
	[PandS-Qty-for-SO] [int] NULL,
	[PandS-Qty-on-PO] [int] NULL,
	[PandS-Stock-Value] [decimal](18, 4) NULL,
	[PandS-Stock-Picture] [varbinary](max) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsDeleted] [bit] NULL,
	[IsRefresh] [bit] NULL DEFAULT ((0)),
	[RefreshDate] [datetime] NULL,
 CONSTRAINT [PK_ProductsAndServices] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PurchaseAndSales_Categories]    Script Date: 3/5/2018 5:53:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchaseAndSales_Categories](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Cat-Name] [nvarchar](100) NULL,
	[Cat-Code] [nvarchar](5) NULL,
	[Content-Type] [nvarchar](20) NULL,
 CONSTRAINT [PK_PurchaseAndSalesCategories] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PurchaseAndSales_CategoriesContent]    Script Date: 3/5/2018 5:53:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchaseAndSales_CategoriesContent](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Cat-Id] [int] NULL,
	[Cat-Contents] [nvarchar](max) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsDeleted] [bit] NULL CONSTRAINT [DF_PurchaseAndSales_CategoriesContent_IsDeleted]  DEFAULT ((0)),
 CONSTRAINT [PK_PurchaseAndSalesCategoriesContent] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PurchaseInvoice]    Script Date: 3/5/2018 5:53:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchaseInvoice](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PI-No] [nvarchar](50) NOT NULL,
	[PI-Date] [date] NOT NULL CONSTRAINT [DF_PurchaseInvoice_PI-Date]  DEFAULT (getdate()),
	[PI-Pmt-Due-Date] [date] NULL,
	[Our-PO-No] [nvarchar](50) NULL,
	[Exc-Inc-GST] [bit] NULL,
	[Sup-Id] [int] NOT NULL,
	[Ship-to-address] [int] NULL,
	[PI-Tot-bef-Tax] [decimal](18, 4) NULL,
	[PI-GST-Amt] [decimal](18, 4) NULL,
	[PI-Tot-aft-Tax] [decimal](18, 4) NULL,
	[PI-TandC] [nvarchar](max) NULL,
	[BusinessExpenses] [bit] NULL,
	[PI-Status] [tinyint] NULL CONSTRAINT [DF_PurchaseInvoice_PI-Status]  DEFAULT ((0)),
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsDeleted] [bit] NULL CONSTRAINT [DF_PurchaseInvoice_IsDeleted]  DEFAULT ((0)),
 CONSTRAINT [PK_PurchaseInvoice] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PurchaseInvoiceDetails]    Script Date: 3/5/2018 5:53:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchaseInvoiceDetails](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PI-ID] [int] NOT NULL,
	[PI-No] [nvarchar](50) NULL,
	[PandS-Code] [nvarchar](50) NULL,
	[PandS-Name] [nvarchar](50) NULL,
	[PI-Qty] [int] NULL,
	[PI-Price] [decimal](18, 4) NULL,
	[PI-Amount] [decimal](18, 4) NULL,
	[PI-Discount] [decimal](12, 4) NULL,
	[GST-Code] [nvarchar](10) NULL,
	[GST-Rate] [decimal](18, 4) NULL,
	[Bus-Expenses-Desc] [nvarchar](200) NULL,
	[Bus-Expenses-Acc-Name] [nvarchar](100) NULL,
	[Type] [nvarchar](5) NULL,
 CONSTRAINT [PK_PurchaseInvoiceDetails] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PurchaseOrder]    Script Date: 3/5/2018 5:53:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchaseOrder](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PO-No] [nvarchar](50) NOT NULL,
	[PO-Date] [datetime] NOT NULL CONSTRAINT [DF_PurchaseOrder_PO-Date]  DEFAULT (getdate()),
	[PO-Del-Date] [datetime] NOT NULL,
	[Exc-Inc-GST] [bit] NULL,
	[Sup-Id] [int] NOT NULL,
	[Ship-to-address] [int] NULL,
	[PO-Tot-bef-Tax] [decimal](18, 4) NULL,
	[PO-GST-Amt] [decimal](18, 4) NULL,
	[PO-Tot-aft-Tax] [decimal](18, 4) NULL,
	[PO-TandC] [nvarchar](max) NULL,
	[PO-Conv-to-PI] [bit] NULL,
	[PO-Status] [tinyint] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsDeleted] [bit] NULL CONSTRAINT [DF_PurchaseOrder_IsDeleted]  DEFAULT ((0)),
	[Conv-to-No] [nvarchar](50) NULL,
 CONSTRAINT [PK_PurchaseOrder] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PurchaseOrderDetails]    Script Date: 3/5/2018 5:53:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchaseOrderDetails](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PO-ID] [int] NOT NULL,
	[PO-No] [nvarchar](50) NULL,
	[PandS-Code] [nvarchar](50) NULL,
	[PandS-Name] [nvarchar](50) NULL,
	[PO-Qty] [int] NULL,
	[PO-Price] [decimal](18, 4) NULL,
	[PO-Amount] [decimal](18, 4) NULL,
	[PO-Discount] [decimal](12, 4) NULL,
	[GST-Code] [nvarchar](10) NULL,
	[GST-Rate] [decimal](18, 4) NULL,
 CONSTRAINT [PK_PurchaseOrderDetails] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PurchaseQuotation]    Script Date: 3/5/2018 5:53:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchaseQuotation](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PQ-No] [nvarchar](50) NOT NULL,
	[PQ-Date] [datetime] NOT NULL CONSTRAINT [DF_PurchaseQuotation_PQ-Date]  DEFAULT (getdate()),
	[PQ-Valid-for] [int] NULL,
	[Exc-Inc-GST] [bit] NULL,
	[Sup-Id] [int] NOT NULL,
	[Ship-to-address] [int] NULL,
	[PQ-Tot-bef-Tax] [decimal](18, 4) NULL,
	[PQ-GST-Amt] [decimal](18, 4) NULL,
	[PQ-Tot-aft-Tax] [decimal](18, 4) NULL,
	[PQ-TandC] [nvarchar](max) NULL,
	[PQ-Conv-to-PO] [bit] NULL,
	[PQ-Conv-to-PI] [bit] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsDeleted] [bit] NULL CONSTRAINT [DF_PurchaseQuotation_IsDeleted]  DEFAULT ((0)),
	[Conv-to-No] [nvarchar](50) NULL,
 CONSTRAINT [PK_PurchaseQuotation] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PurchaseQuotationDetails]    Script Date: 3/5/2018 5:53:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchaseQuotationDetails](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PQ-ID] [int] NOT NULL,
	[PQ-No] [nvarchar](50) NULL,
	[PandS-Code] [nvarchar](50) NULL,
	[PandS-Name] [nvarchar](100) NULL,
	[PQ-Qty] [int] NULL,
	[PQ-Price] [decimal](18, 4) NULL,
	[PQ-Amount] [decimal](18, 4) NULL,
	[PQ-Discount] [decimal](12, 4) NULL,
	[GST-Code] [nvarchar](10) NULL,
	[GST-Rate] [decimal](18, 4) NULL,
 CONSTRAINT [PK_PurchaseQuotationDetails] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ReceiveMoney]    Script Date: 3/5/2018 5:53:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReceiveMoney](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[LinkedAccountID] [int] NULL,
	[CashBankAccountID] [int] NULL,
	[CashChequeNo] [nvarchar](20) NULL,
	[CashChequeDate] [date] NULL,
	[IsCheque] [bit] NULL,
	[TotalBeforeTax] [decimal](18, 4) NULL,
	[TotalAfterTax] [decimal](18, 4) NULL,
	[TotalTax] [decimal](18, 4) NULL,
	[TaxID] [int] NULL,
	[Remarks] [nvarchar](200) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_ReceiveMoney] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Roles]    Script Date: 3/5/2018 5:53:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NULL,
	[Active] [bit] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[IsDeleted] [bit] NULL,
	[DeletedBy] [int] NULL,
	[DeletedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SalesInvoice]    Script Date: 3/5/2018 5:53:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalesInvoice](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SI-No] [nvarchar](50) NOT NULL,
	[SI-Date] [date] NOT NULL CONSTRAINT [DF_SalesInvoice_SI-Date]  DEFAULT (getdate()),
	[SI-Credit-Days] [int] NULL,
	[Cus-PO-No] [nvarchar](50) NULL,
	[Salesman] [int] NULL,
	[Exc-Inc-GST] [bit] NULL,
	[Cus-Id] [int] NOT NULL,
	[SI-Tot-bef-Tax] [decimal](18, 4) NULL,
	[SI-GST-Amt] [decimal](18, 4) NULL,
	[SI-Tot-aft-Tax] [decimal](18, 4) NULL,
	[SI-TandC] [nvarchar](max) NULL,
	[SI-Status] [tinyint] NULL CONSTRAINT [DF_SalesInvoice_SI-Status]  DEFAULT ((0)),
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsDeleted] [bit] NULL CONSTRAINT [DF_SalesInvoice_IsDeleted]  DEFAULT ((0)),
 CONSTRAINT [PK_SalesInvoice] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SalesInvoiceDetails]    Script Date: 3/5/2018 5:53:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalesInvoiceDetails](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SI-ID] [int] NOT NULL,
	[SI-No] [nvarchar](50) NULL,
	[PandS-Code] [nvarchar](50) NULL,
	[PandS-Name] [nvarchar](50) NULL,
	[SI-Qty] [int] NULL,
	[SI-Price] [decimal](18, 4) NULL,
	[SI-Amount] [decimal](18, 4) NULL,
	[SI-Discount] [decimal](18, 4) NULL,
	[GST-Code] [nvarchar](10) NULL,
	[GST-Rate] [decimal](18, 4) NULL,
 CONSTRAINT [PK_SalesInvoiceDetails] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SalesOrder]    Script Date: 3/5/2018 5:53:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalesOrder](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SO-No] [nvarchar](50) NOT NULL,
	[SO-Date] [datetime] NOT NULL CONSTRAINT [DF_SalesOrder_SO-Date]  DEFAULT (getdate()),
	[SO-Del-Date] [datetime] NOT NULL,
	[Cus-PO-No] [nvarchar](50) NULL,
	[Salesman] [int] NULL,
	[Exc-Inc-GST] [bit] NULL,
	[Cus-Id] [int] NOT NULL,
	[Ship-to-address] [int] NULL,
	[SO-Tot-bef-Tax] [decimal](18, 4) NULL,
	[SO-GST-Amt] [decimal](18, 4) NULL,
	[SO-Tot-aft-Tax] [decimal](18, 4) NULL,
	[SO-TandC] [nvarchar](max) NULL,
	[SO-Conv-to-SI] [bit] NULL,
	[SO-Status] [tinyint] NULL CONSTRAINT [DF_SalesOrder_SO-Status]  DEFAULT ((0)),
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsDeleted] [bit] NULL CONSTRAINT [DF_SalesOrder_IsDeleted]  DEFAULT ((0)),
	[Conv-to-No] [nvarchar](50) NULL,
 CONSTRAINT [PK_SalesOrder] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SalesOrderDetails]    Script Date: 3/5/2018 5:53:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalesOrderDetails](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SO-ID] [int] NOT NULL,
	[SO-No] [nvarchar](50) NULL,
	[PandS-Code] [nvarchar](50) NULL,
	[PandS-Name] [nvarchar](50) NULL,
	[SO-Qty] [int] NULL,
	[SO-Price] [decimal](18, 4) NULL,
	[SO-Amount] [decimal](18, 4) NULL,
	[SO-Discount] [decimal](18, 4) NULL,
	[GST-Code] [nvarchar](10) NULL,
	[GST-Rate] [decimal](18, 4) NULL,
 CONSTRAINT [PK_SalesOrderDetails] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SalesQuotation]    Script Date: 3/5/2018 5:53:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalesQuotation](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SQ-No] [nvarchar](50) NOT NULL,
	[SQ-Date] [datetime] NOT NULL CONSTRAINT [DF_SalesQuotation_SQ-Date]  DEFAULT (getdate()),
	[SQ-Valid-for] [int] NULL,
	[Salesman] [int] NULL,
	[Exc-Inc-GST] [bit] NULL,
	[Cus-Id] [int] NOT NULL,
	[Ship-to-address] [int] NULL,
	[SQ-Tot-bef-Tax] [decimal](18, 4) NULL,
	[SQ-GST-Amt] [decimal](18, 4) NULL,
	[SQ-Tot-aft-Tax] [decimal](18, 4) NULL,
	[SQ-TandC] [nvarchar](max) NULL,
	[SQ-Conv-to-SO] [bit] NULL,
	[SQ-Conv-to-SI] [bit] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsDeleted] [bit] NULL CONSTRAINT [DF_SalesQuotation_IsDeleted]  DEFAULT ((0)),
	[Conv-to-No] [nvarchar](50) NULL,
 CONSTRAINT [PK_SalesQuotation] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SalesQuotationDetails]    Script Date: 3/5/2018 5:53:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalesQuotationDetails](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SQ-ID] [int] NOT NULL,
	[SQ-No] [nvarchar](50) NULL,
	[PandS-Code] [nvarchar](50) NULL,
	[PandS-Name] [nvarchar](50) NULL,
	[SQ-Qty] [int] NULL,
	[SQ-Price] [decimal](18, 4) NULL,
	[SQ-Amount] [decimal](18, 4) NULL,
	[SQ-Discount] [decimal](12, 4) NULL,
	[GST-Code] [nvarchar](10) NULL,
	[GST-Rate] [decimal](18, 4) NULL,
 CONSTRAINT [PK_SalesQuotationDetails] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ShippingAddress]    Script Date: 3/5/2018 5:53:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShippingAddress](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EntityId] [int] NOT NULL,
	[EntityType] [nvarchar](50) NOT NULL,
	[Ship-to-line1] [nvarchar](100) NOT NULL,
	[Ship-to-line2] [nvarchar](100) NULL,
	[Ship-to-city] [nvarchar](50) NULL,
	[Ship-to-state] [nvarchar](50) NULL,
	[Ship-to-country] [nvarchar](50) NULL,
	[Ship-to-post-code] [nvarchar](10) NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_ShippingAddress] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Stock]    Script Date: 3/5/2018 5:53:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stock](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Product-ID] [int] NULL,
	[Quantity-In-Stock] [int] NULL,
	[Average-Cost] [decimal](18, 4) NULL,
	[Amount] [decimal](18, 4) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Stock] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StockCounts]    Script Date: 3/5/2018 5:53:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StockCounts](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PandS-Code] [nvarchar](30) NULL,
	[PandS-Name] [nvarchar](30) NULL,
	[SysQty] [int] NULL,
	[CountQty] [int] NULL,
	[Difference] [int] NULL,
	[Average-Cost] [decimal](18, 4) NULL,
	[Amount] [decimal](18, 4) NULL,
	[Adjusted-Amount] [decimal](18, 4) NULL,
	[Stock-count-no] [nvarchar](50) NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[StockDate] [datetime] NULL,
	[StockType] [smallint] NULL,
	[PSID] [int] NULL,
 CONSTRAINT [PK_StockCounts] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StockInOutCard]    Script Date: 3/5/2018 5:53:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StockInOutCard](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SI-PI] [int] NULL,
	[Cus-Sup-Name] [nvarchar](100) NULL,
	[Trans-Type] [nvarchar](30) NULL,
	[Trans-No] [nvarchar](50) NULL,
	[Price] [decimal](18, 4) NULL,
	[QtyIn] [int] NULL,
	[Qtyout] [int] NULL,
	[Trans-Date] [datetime] NULL,
	[Balance] [decimal](18, 4) NULL,
	[Inc-GST] [bit] NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [int] NULL,
 CONSTRAINT [PK_StockInOutCard] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SupplierDetails]    Script Date: 3/5/2018 5:53:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SupplierDetails](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Sup-Id] [int] NOT NULL,
	[Sup-Name] [nvarchar](100) NULL,
	[Sup-Inactive] [char](1) NULL,
	[Sup-Company-Reg-no] [nvarchar](50) NULL,
	[Sup-Type] [nvarchar](10) NULL,
	[Sup-Salesman] [nvarchar](100) NULL,
	[Sup-Credit-Limit-Days] [int] NULL,
	[Sup-Credit-Limit-Amount] [decimal](18, 4) NULL,
	[Sup-Discount] [decimal](18, 4) NULL,
	[Sup-Telephone] [nvarchar](30) NULL,
	[Sup-Fax] [nvarchar](30) NULL,
	[Sup-Email] [nvarchar](100) NULL,
	[Sup-Contact-Person] [nvarchar](100) NULL,
	[Sup-GST-Reg-No] [nvarchar](50) NULL,
	[Sup-Charge-GST] [bit] NULL,
	[Sup-Remarks] [nvarchar](max) NULL,
	[Sup-Bill-to-line1] [nvarchar](100) NULL,
	[Sup-Bill-to-line2] [nvarchar](100) NULL,
	[Sup-Bill-to-city] [nvarchar](50) NULL,
	[Sup-Bill-to-state] [nvarchar](50) NULL,
	[Sup-Bill-to-country] [nvarchar](50) NULL,
	[Sup-Bill-to-post-code] [nvarchar](10) NULL,
	[Sup-Ship-to-line1] [nvarchar](100) NULL,
	[Sup-Ship-to-line2] [nvarchar](100) NULL,
	[Sup-Ship-to-city] [nvarchar](50) NULL,
	[Sup-Ship-to-state] [nvarchar](50) NULL,
	[Sup-Ship-to-country] [nvarchar](50) NULL,
	[Sup-Ship-to-post-code] [nvarchar](10) NULL,
	[UpdatedBy] [nvarchar](100) NULL,
	[LastUpdateDate] [datetime] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_SupplierDetails] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Suppliers]    Script Date: 3/5/2018 5:53:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Suppliers](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Sup-Name] [nvarchar](100) NULL,
	[Sup-Inactive] [char](1) NULL CONSTRAINT [DF_Suppliers_Sup-Inactive]  DEFAULT ('N'),
	[Sup-Company-Reg-no] [nvarchar](50) NULL,
	[Sup-Credit-Limit-Days] [int] NULL,
	[Sup-Credit-Limit-Amount] [decimal](18, 4) NULL,
	[Sup-Telephone] [nvarchar](30) NULL,
	[Sup-Fax] [nvarchar](30) NULL,
	[Sup-Email] [nvarchar](100) NULL,
	[Sup-Contact-Person] [nvarchar](100) NULL,
	[Sup-GST-Reg-No] [nvarchar](50) NULL,
	[Sup-Charge-GST] [bit] NULL,
	[Sup-Remarks] [nvarchar](max) NULL,
	[Sup-Bill-to-line1] [nvarchar](100) NULL,
	[Sup-Bill-to-line2] [nvarchar](100) NULL,
	[Sup-Bill-to-city] [nvarchar](50) NULL,
	[Sup-Bill-to-state] [nvarchar](50) NULL,
	[Sup-Bill-to-country] [nvarchar](50) NULL,
	[Sup-Bill-to-post-code] [nvarchar](10) NULL,
	[Sup-Ship-to-line1] [nvarchar](100) NULL,
	[Sup-Ship-to-line2] [nvarchar](100) NULL,
	[Sup-Ship-to-city] [nvarchar](50) NULL,
	[Sup-Ship-to-state] [nvarchar](50) NULL,
	[Sup-Ship-to-country] [nvarchar](50) NULL,
	[Sup-Ship-to-post-code] [nvarchar](10) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsDeleted] [bit] NULL CONSTRAINT [DF_Suppliers_IsDeleted]  DEFAULT ((0)),
	[IsRefreshed] [bit] NULL,
	[RefreshedDate] [datetime] NULL,
	[TaxId] [int] NULL,
 CONSTRAINT [PK_Suppliers] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SuppliersBusinessCard]    Script Date: 3/5/2018 5:53:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SuppliersBusinessCard](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Sup-Id] [int] NULL,
	[Sup-Bus-Card-Name] [nvarchar](100) NULL,
	[Sup-Bus-Card-Photos] [varbinary](max) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[DeletedBy] [int] NULL,
	[DeletedDate] [datetime] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_SuppliersBusinessCard] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SuppliersCreditDaysPaidInDays]    Script Date: 3/5/2018 5:53:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SuppliersCreditDaysPaidInDays](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Sup-Id] [int] NOT NULL,
	[Sup-Name] [nvarchar](100) NOT NULL,
	[Year] [tinyint] NULL,
	[Quarter] [tinyint] NULL,
	[Month] [tinyint] NULL,
	[Start-Date] [date] NULL,
	[End-Date] [date] NULL,
	[Inv-No] [nvarchar](50) NULL,
	[Inv-Amount] [decimal](18, 4) NULL,
	[Inv-Date] [datetime] NULL,
	[Payment-Due-Date] [datetime] NULL,
	[Paid-Date] [datetime] NULL,
	[Credit-Days] [int] NULL,
	[Paidin-Days] [int] NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [int] NULL,
 CONSTRAINT [PK_SuppliersCreditDaysPaidInDays] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SuppliersHistory]    Script Date: 3/5/2018 5:53:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SuppliersHistory](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Sup-Id] [int] NOT NULL,
	[Sup-Name] [nvarchar](100) NOT NULL,
	[Col1-Amount] [decimal](18, 4) NULL,
	[Col2-Amount] [decimal](18, 4) NULL,
	[Col3-Amount] [decimal](18, 4) NULL,
	[Total-Purchase-Amount] [decimal](18, 4) NULL,
	[Year1] [tinyint] NULL,
	[Year2] [tinyint] NULL,
	[Quarter] [tinyint] NULL,
	[[Inc-GST] [bit] NULL,
	[LastUpdated] [datetime] NULL,
	[UpdatedBy] [int] NULL,
 CONSTRAINT [PK_SuppliersHistory] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SuppliersStatement]    Script Date: 3/5/2018 5:53:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SuppliersStatement](
	[ID] [int] NOT NULL,
	[Sup-Id] [int] NOT NULL,
	[Sup-Name] [nvarchar](100) NOT NULL,
	[Statement-Date] [date] NULL,
	[Balance] [decimal](18, 4) NULL,
	[1-30Days] [decimal](18, 4) NULL,
	[31-60Days] [decimal](18, 4) NULL,
	[61-90Days] [decimal](18, 4) NULL,
	[GreaterThen-90Days] [decimal](18, 4) NULL,
	[Inv-No] [nvarchar](50) NULL,
	[Inv-Date] [datetime] NULL,
	[Payment-Due-Date] [datetime] NULL,
	[Inv-Amount] [decimal](18, 4) NULL,
	[Amount-Paid] [decimal](18, 4) NULL,
	[Amount-Due] [decimal](18, 4) NULL,
	[LastUpdatedDate] [datetime] NULL,
	[UpdatedBy] [int] NULL,
 CONSTRAINT [PK_SuppliersStatement] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ToDoList]    Script Date: 3/5/2018 5:53:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ToDoList](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](10) NULL,
	[Name] [nvarchar](50) NULL,
	[InvoiceNo] [nvarchar](50) NULL,
	[AmountDue] [decimal](14, 4) NULL,
	[InvoiceDate] [datetime] NULL,
	[PaymentDueDate] [datetime] NULL,
	[CreditDays] [int] NULL,
	[OverdueDays] [int] NULL,
	[PromisedDate] [datetime] NULL,
 CONSTRAINT [PK_ToDoList] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TopCustomers]    Script Date: 3/5/2018 5:53:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TopCustomers](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Cus-Id] [int] NOT NULL,
	[Cus-Name] [nvarchar](100) NOT NULL,
	[Year] [tinyint] NULL,
	[Quarter] [tinyint] NULL,
	[Month] [tinyint] NULL,
	[Start-Date] [date] NULL,
	[End-Date] [date] NULL,
	[Inc-GST] [bit] NULL,
	[Sales-Amount] [decimal](18, 4) NULL,
	[Sales-Percentage] [decimal](18, 4) NULL,
	[Payment-Amount] [decimal](18, 4) NULL,
	[Payment-Percentage] [decimal](18, 4) NULL,
	[Profit-Amount] [decimal](18, 4) NULL,
	[Profit-Percentage] [decimal](18, 4) NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [int] NULL,
 CONSTRAINT [PK_TopCustomers] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TopPandS]    Script Date: 3/5/2018 5:53:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TopPandS](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Year] [tinyint] NULL,
	[Quarter] [tinyint] NULL,
	[Month] [tinyint] NULL,
	[Start-Date] [date] NULL,
	[End-Date] [date] NULL,
	[PandS-Cat1] [nvarchar](10) NULL,
	[PandS-Cat2] [nvarchar](10) NULL,
	[PandS-Code] [nvarchar](30) NULL,
	[PandS-Name] [nvarchar](30) NULL,
	[Sales-Amt] [decimal](18, 4) NULL,
	[Sales-Per] [decimal](18, 4) NULL,
	[Purchase-Amt] [decimal](18, 4) NULL,
	[Purchase-Per] [decimal](18, 4) NULL,
	[Profit-Amt] [decimal](18, 4) NULL,
	[Profit-Per] [decimal](18, 4) NULL,
	[Inc-GST] [bit] NULL,
	[PandS-Type] [char](1) NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [int] NULL,
 CONSTRAINT [PK_TopPandS] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TopSuppliers]    Script Date: 3/5/2018 5:53:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TopSuppliers](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Sup-Id] [int] NOT NULL,
	[Sup-Name] [nvarchar](100) NOT NULL,
	[Year] [tinyint] NULL,
	[Quarter] [tinyint] NULL,
	[Month] [tinyint] NULL,
	[Start-Date] [date] NULL,
	[End-Date] [date] NULL,
	[Inc-GST] [bit] NULL,
	[Sales-Amount] [decimal](18, 4) NULL,
	[Sales-Percentage] [decimal](18, 4) NULL,
	[Payment-Amount] [decimal](18, 4) NULL,
	[Payment-Percentage] [decimal](18, 4) NULL,
	[Profit-Amount] [decimal](18, 4) NULL,
	[Profit-Percentage] [decimal](18, 4) NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [int] NULL,
 CONSTRAINT [PK_TopSuppliers] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TransferMoney]    Script Date: 3/5/2018 5:53:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TransferMoney](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[From-Acc-Id] [int] NOT NULL,
	[To-Acc-Id] [int] NOT NULL,
	[Cheque] [bit] NULL,
	[Cheque-No] [nvarchar](20) NULL,
	[Cheque-Date] [date] NULL,
	[Amount] [decimal](18, 0) NULL,
	[Remarks] [nvarchar](100) NULL,
	[Cheque-Photo] [varbinary](max) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
 CONSTRAINT [PK_TransferMoney] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UndeliveredPurchaseOrdersWithDeposits]    Script Date: 3/5/2018 5:53:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UndeliveredPurchaseOrdersWithDeposits](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[S-ID] [int] NULL,
	[UPurchaseOrder-No] [nchar](20) NULL,
	[UPurchaseOrder-Date] [datetime] NULL,
	[UPurchaseOrder-Amount] [decimal](18, 4) NULL,
	[UPurchaseOrderDeposit-Amount] [decimal](18, 4) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_UndeliveredPurchaseOrdersWithDeposits] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UndeliveredSalesOrderWithDeposits]    Script Date: 3/5/2018 5:53:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UndeliveredSalesOrderWithDeposits](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[C-ID] [int] NULL,
	[USalesOrder-No] [nchar](20) NULL,
	[USalesOrder-Date] [datetime] NULL,
	[USalesOrder-Amount] [decimal](18, 4) NULL,
	[USalesOrderDeposit-Amount] [decimal](18, 4) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_UndeliveredSalesOrder] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UnpaidPurchaseInvoice]    Script Date: 3/5/2018 5:53:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UnpaidPurchaseInvoice](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[S-ID] [int] NULL,
	[UnpaidPI-No] [nchar](20) NULL,
	[UnpaidPI-Date] [datetime] NULL,
	[UnpaidPI-Amount] [decimal](18, 4) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_UnpaidPurchaseInvoice] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UnpaidSalesInvoice]    Script Date: 3/5/2018 5:53:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UnpaidSalesInvoice](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[C-ID] [int] NULL,
	[UnpaidSI-No] [nchar](50) NULL,
	[UnpaidSI-Date] [datetime] NULL,
	[UnpaidSI-Amount] [decimal](18, 4) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsDeleted] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 3/5/2018 5:53:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoles](
	[UserRoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NULL,
	[UserId] [int] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[IsDeleted] [bit] NULL,
	[DeletedBy] [int] NULL,
	[DeletedDate] [datetime] NULL,
 CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED 
(
	[UserRoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[CustomerDetails] ADD  CONSTRAINT [DF_CustomerDetails_Cus-Inactive]  DEFAULT ('N') FOR [Cus-Inactive]
GO
ALTER TABLE [dbo].[CustomerDetails] ADD  CONSTRAINT [DF_CustomerDetails_Cus-Charge-GST]  DEFAULT ((0)) FOR [Cus-Charge-GST]
GO
ALTER TABLE [dbo].[CustomerDetails] ADD  CONSTRAINT [DF_CustomerDetails_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[SupplierDetails] ADD  CONSTRAINT [DF_SupplierDetails_Sup-Inactive]  DEFAULT ('N') FOR [Sup-Inactive]
GO
ALTER TABLE [dbo].[SupplierDetails] ADD  CONSTRAINT [DF_SupplierDetails_Sup-Charge-GST]  DEFAULT ((0)) FOR [Sup-Charge-GST]
GO
ALTER TABLE [dbo].[SupplierDetails] ADD  CONSTRAINT [DF_SupplierDetails_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[AdjustedCreditNoteDetails]  WITH CHECK ADD  CONSTRAINT [FK_AdjustedCreditNoteDetails_AdjustedCreditNote] FOREIGN KEY([ACN_ID])
REFERENCES [dbo].[AdjustedCreditNote] ([ID])
GO
ALTER TABLE [dbo].[AdjustedCreditNoteDetails] CHECK CONSTRAINT [FK_AdjustedCreditNoteDetails_AdjustedCreditNote]
GO
ALTER TABLE [dbo].[AdjustedDebitNoteDetails]  WITH CHECK ADD  CONSTRAINT [FK_AdjustedDebitNoteDetails_AdjustedDebitNote] FOREIGN KEY([ADN_ID])
REFERENCES [dbo].[AdjustedDebitNote] ([ID])
GO
ALTER TABLE [dbo].[AdjustedDebitNoteDetails] CHECK CONSTRAINT [FK_AdjustedDebitNoteDetails_AdjustedDebitNote]
GO
ALTER TABLE [dbo].[BusinessExpensesDetails]  WITH CHECK ADD  CONSTRAINT [FK_BusinessExpensesDetails_PurchaseInvoice] FOREIGN KEY([PI-ID])
REFERENCES [dbo].[BusinessExpenses] ([ID])
GO
ALTER TABLE [dbo].[BusinessExpensesDetails] CHECK CONSTRAINT [FK_BusinessExpensesDetails_PurchaseInvoice]
GO
ALTER TABLE [dbo].[CategoriesContent]  WITH CHECK ADD  CONSTRAINT [FK_CategoriesContent_Categories] FOREIGN KEY([Cat-Id])
REFERENCES [dbo].[Categories] ([ID])
GO
ALTER TABLE [dbo].[CategoriesContent] CHECK CONSTRAINT [FK_CategoriesContent_Categories]
GO
ALTER TABLE [dbo].[CreditNotes]  WITH CHECK ADD  CONSTRAINT [FK_CreditNotes_SalesInvoice] FOREIGN KEY([SI-Id])
REFERENCES [dbo].[SalesInvoice] ([ID])
GO
ALTER TABLE [dbo].[CreditNotes] CHECK CONSTRAINT [FK_CreditNotes_SalesInvoice]
GO
ALTER TABLE [dbo].[CustomersBusinessCard]  WITH CHECK ADD  CONSTRAINT [FK_CustomersBusinessCard_Customers] FOREIGN KEY([Cus-Id])
REFERENCES [dbo].[Customers] ([ID])
GO
ALTER TABLE [dbo].[CustomersBusinessCard] CHECK CONSTRAINT [FK_CustomersBusinessCard_Customers]
GO
ALTER TABLE [dbo].[DebitNotes]  WITH CHECK ADD  CONSTRAINT [FK_DebitNotes_PurchaseInvoice] FOREIGN KEY([PI-Id])
REFERENCES [dbo].[PurchaseInvoice] ([ID])
GO
ALTER TABLE [dbo].[DebitNotes] CHECK CONSTRAINT [FK_DebitNotes_PurchaseInvoice]
GO
ALTER TABLE [dbo].[DebitNotes]  WITH CHECK ADD  CONSTRAINT [FK_DebitNotes_Suppliers] FOREIGN KEY([Sup-Id])
REFERENCES [dbo].[Suppliers] ([ID])
GO
ALTER TABLE [dbo].[DebitNotes] CHECK CONSTRAINT [FK_DebitNotes_Suppliers]
GO
ALTER TABLE [dbo].[JournalDetails]  WITH CHECK ADD  CONSTRAINT [FK_JournalDetails_Journal] FOREIGN KEY([JO-ID ])
REFERENCES [dbo].[Journal] ([ID])
GO
ALTER TABLE [dbo].[JournalDetails] CHECK CONSTRAINT [FK_JournalDetails_Journal]
GO
ALTER TABLE [dbo].[PurchaseAndSales_CategoriesContent]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseAndSales_CategoriesContent_PurchaseAndSales_Categories] FOREIGN KEY([Cat-Id])
REFERENCES [dbo].[PurchaseAndSales_Categories] ([ID])
GO
ALTER TABLE [dbo].[PurchaseAndSales_CategoriesContent] CHECK CONSTRAINT [FK_PurchaseAndSales_CategoriesContent_PurchaseAndSales_Categories]
GO
ALTER TABLE [dbo].[PurchaseInvoiceDetails]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseInvoiceDetails_PurchaseInvoice] FOREIGN KEY([PI-ID])
REFERENCES [dbo].[PurchaseInvoice] ([ID])
GO
ALTER TABLE [dbo].[PurchaseInvoiceDetails] CHECK CONSTRAINT [FK_PurchaseInvoiceDetails_PurchaseInvoice]
GO
ALTER TABLE [dbo].[PurchaseOrder]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseOrder_ShippingAddress] FOREIGN KEY([Ship-to-address])
REFERENCES [dbo].[ShippingAddress] ([ID])
GO
ALTER TABLE [dbo].[PurchaseOrder] CHECK CONSTRAINT [FK_PurchaseOrder_ShippingAddress]
GO
ALTER TABLE [dbo].[PurchaseOrder]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseOrder_Suppliers] FOREIGN KEY([Sup-Id])
REFERENCES [dbo].[Suppliers] ([ID])
GO
ALTER TABLE [dbo].[PurchaseOrder] CHECK CONSTRAINT [FK_PurchaseOrder_Suppliers]
GO
ALTER TABLE [dbo].[PurchaseOrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseOrderDetails_PurchaseOrder] FOREIGN KEY([PO-ID])
REFERENCES [dbo].[PurchaseOrder] ([ID])
GO
ALTER TABLE [dbo].[PurchaseOrderDetails] CHECK CONSTRAINT [FK_PurchaseOrderDetails_PurchaseOrder]
GO
ALTER TABLE [dbo].[PurchaseQuotationDetails]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseQuotationDetails_PurchaseQuotation] FOREIGN KEY([PQ-ID])
REFERENCES [dbo].[PurchaseQuotation] ([ID])
GO
ALTER TABLE [dbo].[PurchaseQuotationDetails] CHECK CONSTRAINT [FK_PurchaseQuotationDetails_PurchaseQuotation]
GO
ALTER TABLE [dbo].[SalesInvoiceDetails]  WITH CHECK ADD  CONSTRAINT [FK_SalesInvoiceDetails_SalesInvoice] FOREIGN KEY([SI-ID])
REFERENCES [dbo].[SalesInvoice] ([ID])
GO
ALTER TABLE [dbo].[SalesInvoiceDetails] CHECK CONSTRAINT [FK_SalesInvoiceDetails_SalesInvoice]
GO
ALTER TABLE [dbo].[SalesOrder]  WITH CHECK ADD  CONSTRAINT [FK_SalesOrder_Customers] FOREIGN KEY([Cus-Id])
REFERENCES [dbo].[Customers] ([ID])
GO
ALTER TABLE [dbo].[SalesOrder] CHECK CONSTRAINT [FK_SalesOrder_Customers]
GO
ALTER TABLE [dbo].[SalesOrder]  WITH CHECK ADD  CONSTRAINT [FK_SalesOrder_ShippingAddress] FOREIGN KEY([Ship-to-address])
REFERENCES [dbo].[ShippingAddress] ([ID])
GO
ALTER TABLE [dbo].[SalesOrder] CHECK CONSTRAINT [FK_SalesOrder_ShippingAddress]
GO
ALTER TABLE [dbo].[SalesOrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_SalesOrderDetails_SalesOrder] FOREIGN KEY([SO-ID])
REFERENCES [dbo].[SalesOrder] ([ID])
GO
ALTER TABLE [dbo].[SalesOrderDetails] CHECK CONSTRAINT [FK_SalesOrderDetails_SalesOrder]
GO
ALTER TABLE [dbo].[SalesQuotationDetails]  WITH CHECK ADD  CONSTRAINT [FK_SalesQuotationDetails_SalesQuotation] FOREIGN KEY([SQ-ID])
REFERENCES [dbo].[SalesQuotation] ([ID])
GO
ALTER TABLE [dbo].[SalesQuotationDetails] CHECK CONSTRAINT [FK_SalesQuotationDetails_SalesQuotation]
GO
ALTER TABLE [dbo].[SuppliersBusinessCard]  WITH CHECK ADD  CONSTRAINT [FK_SuppliersBusinessCard_Suppliers] FOREIGN KEY([Sup-Id])
REFERENCES [dbo].[Suppliers] ([ID])
GO
ALTER TABLE [dbo].[SuppliersBusinessCard] CHECK CONSTRAINT [FK_SuppliersBusinessCard_Suppliers]
GO
ALTER TABLE [dbo].[TransferMoney]  WITH CHECK ADD  CONSTRAINT [FK_TransferMoney_Accounts] FOREIGN KEY([From-Acc-Id])
REFERENCES [dbo].[Accounts] ([ID])
GO
ALTER TABLE [dbo].[TransferMoney] CHECK CONSTRAINT [FK_TransferMoney_Accounts]
GO
ALTER TABLE [dbo].[TransferMoney]  WITH CHECK ADD  CONSTRAINT [FK_TransferMoney_Accounts1] FOREIGN KEY([To-Acc-Id])
REFERENCES [dbo].[Accounts] ([ID])
GO
ALTER TABLE [dbo].[TransferMoney] CHECK CONSTRAINT [FK_TransferMoney_Accounts1]
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_Roles] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([RoleId])
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_Roles]
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_Users]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Sales invoice =S,Purchase Invoice=P,Payment from customer,refund from suppliers etc.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AccountsTransactions', @level2type=N'COLUMN',@level2name=N'Invoice-Type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'C=Customer,S=Suppliers' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CashAndBankTransactions', @level2type=N'COLUMN',@level2name=N'Type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'CV=Calendar View , LV=List View' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CashFlowCalendar', @level2type=N'COLUMN',@level2name=N'View-Type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Reference from Categories & Content table' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CreditNotes', @level2type=N'COLUMN',@level2name=N'Salesman'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1=Adjusted,2=Refunded' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CreditNotes', @level2type=N'COLUMN',@level2name=N'CN-Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1=Adjusted,2=Refunded' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DebitNotes', @level2type=N'COLUMN',@level2name=N'DN-Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'null,B=both,P=Product,S=Services' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PandSPurchase', @level2type=N'COLUMN',@level2name=N'PandS-Type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'null,B=both,P=Product,S=Services' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PandSPurchasedFromSuppliers', @level2type=N'COLUMN',@level2name=N'PandS-Type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'null,B=both,P=Product,S=Services' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PandSSold', @level2type=N'COLUMN',@level2name=N'PandS-Type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'null,B=both,P=Product,S=Services' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PandSSoldToCustomer', @level2type=N'COLUMN',@level2name=N'PandS-Type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1=Paid,2=Adjusted,3=Canceled' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PurchaseInvoice', @level2type=N'COLUMN',@level2name=N'PI-Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1=Deposited,2=Deposited Payed,3=Refund' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PurchaseOrder', @level2type=N'COLUMN',@level2name=N'PO-Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'null or 0=Unpaid,1=Paid,2=Adjusted,3=Canceled' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SalesInvoice', @level2type=N'COLUMN',@level2name=N'SI-Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1=Deposited,2=Collect Deposite,3=Refund' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SalesOrder', @level2type=N'COLUMN',@level2name=N'SO-Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'null,B=both,P=Product,S=Services' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TopPandS', @level2type=N'COLUMN',@level2name=N'PandS-Type'
GO
