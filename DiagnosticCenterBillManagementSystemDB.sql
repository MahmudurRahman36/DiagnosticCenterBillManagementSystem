USE [master]
GO
/****** Object:  Database [DiagnosticCenterBillManagementSystemDB]    Script Date: 1/12/2017 1:56:06 PM ******/
CREATE DATABASE [DiagnosticCenterBillManagementSystemDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DiagnosticCenterBillManagementSystemDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\DiagnosticCenterBillManagementSystemDB.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DiagnosticCenterBillManagementSystemDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\DiagnosticCenterBillManagementSystemDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystemDB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DiagnosticCenterBillManagementSystemDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystemDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystemDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystemDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystemDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystemDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystemDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystemDB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystemDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystemDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystemDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystemDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystemDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystemDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystemDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystemDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystemDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystemDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystemDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystemDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystemDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystemDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystemDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystemDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystemDB] SET RECOVERY FULL 
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystemDB] SET  MULTI_USER 
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystemDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystemDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystemDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystemDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'DiagnosticCenterBillManagementSystemDB', N'ON'
GO
USE [DiagnosticCenterBillManagementSystemDB]
GO
/****** Object:  Table [dbo].[Patients]    Script Date: 1/12/2017 1:56:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Patients](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[DateOfBirth] [varchar](50) NULL,
	[MobileNo] [varchar](50) NULL,
 CONSTRAINT [PK_Patients] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TestRequests]    Script Date: 1/12/2017 1:56:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TestRequests](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PatientID] [int] NOT NULL,
	[TestID] [int] NOT NULL,
	[BillNumber] [varchar](50) NULL,
	[PrintDate] [varchar](50) NULL,
	[PaymentStatus] [varchar](50) NULL,
 CONSTRAINT [PK_TestRequests] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tests]    Script Date: 1/12/2017 1:56:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tests](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TestName] [varchar](50) NOT NULL,
	[Fee] [decimal](18, 0) NOT NULL,
	[TestTypeID] [int] NOT NULL,
 CONSTRAINT [PK_TestSetup] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Types]    Script Date: 1/12/2017 1:56:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Types](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TypeName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TestType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[TestRequestView]    Script Date: 1/12/2017 1:56:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[TestRequestView]
as
select t.PatientID as ID,p.Name,p.MobileNo,t.BillNumber,t.PrintDate,t.PaymentStatus,t.TestID,te.TestName,te.Fee,te.TestTypeID ,ty.TypeName as TestTypeName
from TestRequests t 
Join Patients p on t.PatientID=p.ID
join Tests te on t.TestID=te.ID
join Types ty on te.TestTypeID=ty.ID

GO
/****** Object:  View [dbo].[TestView]    Script Date: 1/12/2017 1:56:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[TestView]
as
select te.TestTypeID as ID,te.TestName as Name,te.Fee,ty.TypeName as TypeName
from Tests te
join Types ty on te.TestTypeID=ty.ID

GO
/****** Object:  View [dbo].[TestWiseReportView]    Script Date: 1/12/2017 1:56:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE view [dbo].[TestWiseReportView]
as
select te.ID,te.TestName as TestName,te.Fee ,isnull(t.PrintDate,'1-1-1000') "PrintDate"
from Tests te
full join TestRequests t  on t.TestID=te.ID



GO
/****** Object:  View [dbo].[TypeWiseReportView]    Script Date: 1/12/2017 1:56:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE view [dbo].[TypeWiseReportView]
as
select ty.ID,ty.TypeName as TypeName,isnull(te.Fee,0) Fee ,isnull(t.PrintDate,'1-1-1000') "PrintDate"
from Types ty
full join Tests te on te.TestTypeID=ty.ID
full join TestRequests t  on t.TestID=te.ID


GO
SET IDENTITY_INSERT [dbo].[Patients] ON 

INSERT [dbo].[Patients] ([ID], [Name], [DateOfBirth], [MobileNo]) VALUES (12, N'Musfiqur Rahman', N'07-01-2017', N'0998588898')
INSERT [dbo].[Patients] ([ID], [Name], [DateOfBirth], [MobileNo]) VALUES (13, N'Musfiqur Rahman', N'05-01-2017', N'0998588898')
SET IDENTITY_INSERT [dbo].[Patients] OFF
SET IDENTITY_INSERT [dbo].[TestRequests] ON 

INSERT [dbo].[TestRequests] ([ID], [PatientID], [TestID], [BillNumber], [PrintDate], [PaymentStatus]) VALUES (17, 12, 7, N'1001', N'12-1-2017', N'0')
INSERT [dbo].[TestRequests] ([ID], [PatientID], [TestID], [BillNumber], [PrintDate], [PaymentStatus]) VALUES (18, 12, 1006, N'1001', N'12-1-2017', N'0')
INSERT [dbo].[TestRequests] ([ID], [PatientID], [TestID], [BillNumber], [PrintDate], [PaymentStatus]) VALUES (19, 13, 3, N'1002', N'12-1-2017', N'0')
INSERT [dbo].[TestRequests] ([ID], [PatientID], [TestID], [BillNumber], [PrintDate], [PaymentStatus]) VALUES (20, 13, 3, N'1003', N'12-1-2017', N'0')
INSERT [dbo].[TestRequests] ([ID], [PatientID], [TestID], [BillNumber], [PrintDate], [PaymentStatus]) VALUES (21, 13, 3, N'1003', N'12-1-2017', N'0')
SET IDENTITY_INSERT [dbo].[TestRequests] OFF
SET IDENTITY_INSERT [dbo].[Tests] ON 

INSERT [dbo].[Tests] ([ID], [TestName], [Fee], [TestTypeID]) VALUES (3, N'RBS', CAST(150 AS Decimal(18, 0)), 1)
INSERT [dbo].[Tests] ([ID], [TestName], [Fee], [TestTypeID]) VALUES (4, N'Lower Abdomen', CAST(550 AS Decimal(18, 0)), 2)
INSERT [dbo].[Tests] ([ID], [TestName], [Fee], [TestTypeID]) VALUES (5, N'Hand X-ray', CAST(200 AS Decimal(18, 0)), 4)
INSERT [dbo].[Tests] ([ID], [TestName], [Fee], [TestTypeID]) VALUES (6, N'Whole Abdomen', CAST(800 AS Decimal(18, 0)), 2)
INSERT [dbo].[Tests] ([ID], [TestName], [Fee], [TestTypeID]) VALUES (7, N'ECG', CAST(550 AS Decimal(18, 0)), 3)
INSERT [dbo].[Tests] ([ID], [TestName], [Fee], [TestTypeID]) VALUES (8, N'Leg X-ray', CAST(250 AS Decimal(18, 0)), 4)
INSERT [dbo].[Tests] ([ID], [TestName], [Fee], [TestTypeID]) VALUES (1006, N'Blood Pressure', CAST(50 AS Decimal(18, 0)), 1)
SET IDENTITY_INSERT [dbo].[Tests] OFF
SET IDENTITY_INSERT [dbo].[Types] ON 

INSERT [dbo].[Types] ([ID], [TypeName]) VALUES (1, N'BLOOD')
INSERT [dbo].[Types] ([ID], [TypeName]) VALUES (2, N'USG')
INSERT [dbo].[Types] ([ID], [TypeName]) VALUES (3, N'ECG')
INSERT [dbo].[Types] ([ID], [TypeName]) VALUES (4, N'X-Ray')
SET IDENTITY_INSERT [dbo].[Types] OFF
ALTER TABLE [dbo].[TestRequests]  WITH CHECK ADD  CONSTRAINT [FK_TestRequests_Patients] FOREIGN KEY([PatientID])
REFERENCES [dbo].[Patients] ([ID])
GO
ALTER TABLE [dbo].[TestRequests] CHECK CONSTRAINT [FK_TestRequests_Patients]
GO
ALTER TABLE [dbo].[TestRequests]  WITH CHECK ADD  CONSTRAINT [FK_TestRequests_Tests] FOREIGN KEY([TestID])
REFERENCES [dbo].[Tests] ([ID])
GO
ALTER TABLE [dbo].[TestRequests] CHECK CONSTRAINT [FK_TestRequests_Tests]
GO
ALTER TABLE [dbo].[Tests]  WITH CHECK ADD  CONSTRAINT [FK_Tests_Types] FOREIGN KEY([TestTypeID])
REFERENCES [dbo].[Types] ([ID])
GO
ALTER TABLE [dbo].[Tests] CHECK CONSTRAINT [FK_Tests_Types]
GO
USE [master]
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystemDB] SET  READ_WRITE 
GO
