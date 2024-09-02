
USE [PlayGround]
GO
/****** Object:  UserDefinedTableType [dbo].[InvoiceItem]    Script Date: 2/9/2024 12:42:47 AM ******/
CREATE TYPE [dbo].[InvoiceItem] AS TABLE(
	[Id] [int] NOT NULL,
	[Code] [nvarchar](30) NULL,
	[Description] [nvarchar](3000) NULL,
	[Price] [decimal](10, 2) NULL,
	[Qty] [int] NULL,
	[Total] [decimal](10, 2) NULL,
	PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  UserDefinedTableType [dbo].[SearchResultsType]    Script Date: 2/9/2024 12:42:47 AM ******/
CREATE TYPE [dbo].[SearchResultsType] AS TABLE(
	[Id] [int] NOT NULL,
	[WebTitle] [nvarchar](1000) NULL,
	[WebAddress] [nvarchar](2000) NULL,
	[SearchDescription] [nvarchar](max) NULL,
	PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 2/9/2024 12:42:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerName] [nvarchar](100) NULL,
	[CustomerAddress] [nvarchar](3000) NULL,
	[isActive] [bit] NULL,
	[CreatedOn] [datetime] NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InvoiceItems]    Script Date: 2/9/2024 12:42:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InvoiceItems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceId] [int] NULL,
	[Code] [nvarchar](30) NULL,
	[Desc] [nvarchar](2000) NULL,
	[Price] [decimal](10, 2) NULL,
	[Qty] [int] NULL,
	[Total] [int] NULL,
 CONSTRAINT [PK_InvoiceItems] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Invoices]    Script Date: 2/9/2024 12:42:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoices](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NULL,
	[InvNo] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[Total] [decimal](10, 2) NULL,
	[DiscPercentage] [int] NULL,
	[Discount] [decimal](10, 2) NULL,
	[GrandTotal] [decimal](10, 2) NULL,
	[isActive] [bit] NULL,
 CONSTRAINT [PK_Invoces] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SearchHistory]    Script Date: 2/9/2024 12:42:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SearchHistory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[WebTitle] [nvarchar](1000) NULL,
	[WebAddress] [nvarchar](2000) NULL,
	[SearchDescription] [nvarchar](max) NULL,
	[IsActive] [bit] NULL,
	[CreatedOn] [datetime] NULL,
 CONSTRAINT [PK_SearchHistory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SpLog]    Script Date: 2/9/2024 12:42:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SpLog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ObjName] [nvarchar](150) NULL,
	[Data] [nvarchar](max) NULL,
	[CreatedOn] [datetime] NULL,
 CONSTRAINT [PK_SpLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Customers] ON 
GO
INSERT [dbo].[Customers] ([Id], [CustomerName], [CustomerAddress], [isActive], [CreatedOn]) VALUES (1, N'Umar Shareef', N'Olaya, Riyadh', 1, CAST(N'2024-09-01T23:07:57.670' AS DateTime))
GO
INSERT [dbo].[Customers] ([Id], [CustomerName], [CustomerAddress], [isActive], [CreatedOn]) VALUES (2, N'Abdul Rahman', N'Hara, Riyadh', 1, CAST(N'2024-09-01T23:07:57.670' AS DateTime))
GO
INSERT [dbo].[Customers] ([Id], [CustomerName], [CustomerAddress], [isActive], [CreatedOn]) VALUES (3, N'Abdul Samad', N'Smad, Hara, Riyadh', 1, CAST(N'2024-09-01T23:07:57.670' AS DateTime))
GO
INSERT [dbo].[Customers] ([Id], [CustomerName], [CustomerAddress], [isActive], [CreatedOn]) VALUES (4, N'Kaleem', N'Ghubera, Riyadh', 1, CAST(N'2024-09-01T23:07:57.670' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Customers] OFF
GO
SET IDENTITY_INSERT [dbo].[InvoiceItems] ON 
GO
INSERT [dbo].[InvoiceItems] ([Id], [InvoiceId], [Code], [Desc], [Price], [Qty], [Total]) VALUES (1, 1, N'PC2@D', N'Developer Computer High Conf', CAST(4600.00 AS Decimal(10, 2)), 5, 23000)
GO
INSERT [dbo].[InvoiceItems] ([Id], [InvoiceId], [Code], [Desc], [Price], [Qty], [Total]) VALUES (2, 1, N'MUS4', N'Regular Mouse with cable', CAST(6.00 AS Decimal(10, 2)), 90, 540)
GO
INSERT [dbo].[InvoiceItems] ([Id], [InvoiceId], [Code], [Desc], [Price], [Qty], [Total]) VALUES (3, 1, N'WMUS', N'wireless mouse goes here', CAST(120.00 AS Decimal(10, 2)), 8, 960)
GO
INSERT [dbo].[InvoiceItems] ([Id], [InvoiceId], [Code], [Desc], [Price], [Qty], [Total]) VALUES (4, 2, N'2564', N'Domain Registration', CAST(80.00 AS Decimal(10, 2)), 1, 80)
GO
SET IDENTITY_INSERT [dbo].[InvoiceItems] OFF
GO
SET IDENTITY_INSERT [dbo].[Invoices] ON 
GO
INSERT [dbo].[Invoices] ([Id], [CustomerId], [InvNo], [CreatedOn], [Total], [DiscPercentage], [Discount], [GrandTotal], [isActive]) VALUES (1, 2, 0, CAST(N'2024-09-01T23:43:08.427' AS DateTime), CAST(120040.00 AS Decimal(10, 2)), 12, CAST(14404.80 AS Decimal(10, 2)), CAST(105635.20 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[Invoices] ([Id], [CustomerId], [InvNo], [CreatedOn], [Total], [DiscPercentage], [Discount], [GrandTotal], [isActive]) VALUES (2, 3, 0, CAST(N'2024-09-02T00:39:39.880' AS DateTime), CAST(160.00 AS Decimal(10, 2)), 5, CAST(8.00 AS Decimal(10, 2)), CAST(152.00 AS Decimal(10, 2)), 1)
GO
SET IDENTITY_INSERT [dbo].[Invoices] OFF
GO
SET IDENTITY_INSERT [dbo].[SearchHistory] ON 
GO
INSERT [dbo].[SearchHistory] ([Id], [WebTitle], [WebAddress], [SearchDescription], [IsActive], [CreatedOn]) VALUES (1, N'Healthcare System in the Kingdom of Saudi Arabia: An Expat ...', N'https://www.ncbi.nlm.nih.gov/pmc/articles/PMC10250784/', N'May 9, 2023 ... Abstract. Saudi Arabia has made significant progress in its healthcare system through increased healthcare spending, improved healthcare ...', 1, CAST(N'2024-08-31T20:00:00.000' AS DateTime))
GO
INSERT [dbo].[SearchHistory] ([Id], [WebTitle], [WebAddress], [SearchDescription], [IsActive], [CreatedOn]) VALUES (2, N'Healthcare System in the Kingdom of Saudi Arabia: An Expat ...', N'https://www.ncbi.nlm.nih.gov/pmc/articles/PMC10250784/', N'May 9, 2023 ... Abstract. Saudi Arabia has made significant progress in its healthcare system through increased healthcare spending, improved healthcare ...', 1, CAST(N'2024-08-31T01:32:10.603' AS DateTime))
GO
INSERT [dbo].[SearchHistory] ([Id], [WebTitle], [WebAddress], [SearchDescription], [IsActive], [CreatedOn]) VALUES (3, N'Salman of Saudi Arabia - Wikipedia', N'https://en.wikipedia.org/wiki/Salman_of_Saudi_Arabia', N'Salman bin Abdulaziz Al Saud is King of Saudi Arabia, reigning since 2015, and was also Prime Minister of Saudi Arabia from 2015 to 2022.', 1, CAST(N'2024-08-31T01:36:11.890' AS DateTime))
GO
INSERT [dbo].[SearchHistory] ([Id], [WebTitle], [WebAddress], [SearchDescription], [IsActive], [CreatedOn]) VALUES (4, N'King Saud University: Home Page', N'https://www.ksu.edu.sa/en', N'KSU published 23% of academic research in Saudi Arabia · Latest News · Excellence Ceremony for the Graduation of the 60th Batch of Female Students at King Saud ...', 1, CAST(N'2024-08-31T01:36:11.890' AS DateTime))
GO
INSERT [dbo].[SearchHistory] ([Id], [WebTitle], [WebAddress], [SearchDescription], [IsActive], [CreatedOn]) VALUES (5, N'King of Saudi Arabia - Wikipedia', N'https://en.wikipedia.org/wiki/King_of_Saudi_Arabia', N'King of Saudi Arabia ; Salman bin Abdulaziz Al Saud since 23 January 2015 ; Salman bin Abdulaziz Al Saud since 23 January 2015.', 1, CAST(N'2024-08-31T01:36:11.890' AS DateTime))
GO
INSERT [dbo].[SearchHistory] ([Id], [WebTitle], [WebAddress], [SearchDescription], [IsActive], [CreatedOn]) VALUES (6, N'Salman of Saudi Arabia | King, Father, Siblings, & Son | Britannica', N'https://www.britannica.com/biography/Salman-of-Saudi-Arabia', N'Aug 20, 2024 ... Salman is king of Saudi Arabia (2015– ) and the last of the sons of Abdulaziz ibn Saud to rule the country. His son Mohammed bin Salman has ...', 1, CAST(N'2024-08-31T01:36:11.890' AS DateTime))
GO
INSERT [dbo].[SearchHistory] ([Id], [WebTitle], [WebAddress], [SearchDescription], [IsActive], [CreatedOn]) VALUES (7, N'KAUST: King Abdullah University of Science and Technology', N'https://www.kaust.edu.sa/', N'KAUST aspires to be a destination for scientific and technological education and research. By inspiring discoveries to address global challenges, ...', 1, CAST(N'2024-08-31T01:36:11.890' AS DateTime))
GO
INSERT [dbo].[SearchHistory] ([Id], [WebTitle], [WebAddress], [SearchDescription], [IsActive], [CreatedOn]) VALUES (8, N'History | The Embassy of The Kingdom of Saudi Arabia', N'https://www.saudiembassy.net/history', N'Saudi Leaders: King Abdulaziz; King Saud; King Faisal; King Khalid; King Fahd; King Abdullah; King Salman; Crown Prince Mohammad bin Salman bin ...', 1, CAST(N'2024-08-31T01:36:11.890' AS DateTime))
GO
INSERT [dbo].[SearchHistory] ([Id], [WebTitle], [WebAddress], [SearchDescription], [IsActive], [CreatedOn]) VALUES (9, N'President Kennedy visits Saud bin Abdul Aziz, King of Saudi Arabia ...', N'https://www.jfklibrary.org/asset-viewer/archives/jfkwhp-1962-01-27-a', N'President Kennedy visits Saud bin Abdul Aziz, King of Saudi Arabia, 11:00AM. Collection: White House Photographs.', 1, CAST(N'2024-08-31T01:36:11.890' AS DateTime))
GO
INSERT [dbo].[SearchHistory] ([Id], [WebTitle], [WebAddress], [SearchDescription], [IsActive], [CreatedOn]) VALUES (10, N'Saudi Arabia''s King Abdullah bin Abdulaziz dies - BBC News', N'https://www.bbc.com/news/world-middle-east-30945324', N'Jan 23, 2015 ... Saudi King Abdullah bin Abdulaziz has died in hospital, royal officials announce, weeks after being admitted with a lung infection.', 1, CAST(N'2024-08-31T01:36:11.890' AS DateTime))
GO
INSERT [dbo].[SearchHistory] ([Id], [WebTitle], [WebAddress], [SearchDescription], [IsActive], [CreatedOn]) VALUES (11, N'75 years after a historic meeting on the USS Quincy, US-Saudi ...', N'https://www.brookings.edu/.../75-years-after-a-historic-meeting-on-the-uss-...', N'Feb 10, 2020 ... On Valentine''s Day 1945, President Franklin D. Roosevelt met with Saudi King Abdul Aziz Ibn Saud on an American cruiser, the USS Quincy, in the Suez Canal.', 1, CAST(N'2024-08-31T01:36:11.890' AS DateTime))
GO
INSERT [dbo].[SearchHistory] ([Id], [WebTitle], [WebAddress], [SearchDescription], [IsActive], [CreatedOn]) VALUES (12, N'Ten ways that Saudi Arabia violates human rights', N'https://www.amnesty.org.uk/saudi-arabia-human-rights-raif-badawi-king-sa...', N'Mar 5, 2024 ... The reality for people living in Saudi Arabia, is one where their basic human rights are ignored, their freedoms are restricted and punishment is severe.', 1, CAST(N'2024-08-31T01:36:11.890' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[SearchHistory] OFF
GO
/****** Object:  StoredProcedure [dbo].[CreateInvoice]    Script Date: 2/9/2024 12:42:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateInvoice] 
	@Items InvoiceItem  readonly,
	@invNo int,
	@GrandTotal decimal(10,2),
	@CustomerId int,
	@dPercentage int,
	@Discount decimal(10,2),
	@Total decimal(10,2)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	insert into Invoices(CustomerId, InvNo,CreatedOn, Total, Discpercentage, Discount,GrandTotal, isActive)
	values(@CustomerId,@invNo, getdate(), @Total, @dPercentage, @Discount, @GrandTotal, 1)

	declare @invId int = SCOPE_IDENTITY()
	
	insert into invoiceItems(InvoiceId, Code, [Desc],Price, Qty, Total)
	Select @invId, Code ,[Description], Price, Qty, Total from @items


END
GO
/****** Object:  StoredProcedure [dbo].[listInvoices]    Script Date: 2/9/2024 12:42:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[listInvoices] 
	AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	select i.Id, InvNo, convert(varchar(30), cast(i.CreatedOn as Date), 113) InvoiceDate, Total,
	DiscPercentage, Discount, GrandTotal ,
	c.CustomerName
	from Invoices i inner join Customers c on i.customerId = c.Id and i.isactive = 1
END
GO
/****** Object:  StoredProcedure [dbo].[LoadCustomers]    Script Date: 2/9/2024 12:42:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LoadCustomers] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	select Id, CustomerName, CustomerAddress 
		from Customers where isactive = 1

END
GO
/****** Object:  StoredProcedure [dbo].[loadOneInvoice]    Script Date: 2/9/2024 12:42:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[loadOneInvoice]
	@Id int 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    select * from invoices where id = @Id
	select * from invoiceItems where invoiceId = @Id


END
GO
/****** Object:  StoredProcedure [dbo].[LoadSearchHistory]    Script Date: 2/9/2024 12:42:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[LoadSearchHistory] 
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	select isnull(WebTitle,'')WebTitle,
	isnull(WebAddress,'') WebAddress,
	isnull(SearchDescription,'') SearchDescription 
	from SearchHistory
	where isactive = 1

END
GO
/****** Object:  StoredProcedure [dbo].[SaveBulkResults]    Script Date: 2/9/2024 12:42:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SaveBulkResults] 
(
	@searchResults AS [dbo].[SearchResultsType] READONLY
)
AS
BEGIN
	BEGIN TRY

		
		insert into SearchHistory(WebTitle, WebAddress, SearchDescription, IsActive, CreatedOn)
		select WebTitle, WebAddress, SearchDescription,1,getdate() from @searchResults

		select 'Success' as dataResponse
	END TRY
	BEGIN CATCH
		
		select 'Failure' as dataResponse
	END CATCH
END
GO

