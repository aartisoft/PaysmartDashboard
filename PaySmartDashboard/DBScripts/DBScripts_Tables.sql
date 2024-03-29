ALTER TABLE [dbo].[VehicleDocuments] DROP CONSTRAINT [DF__VehicleDo__UserT__59904A2C]
GO
ALTER TABLE [dbo].[VehicleDocuments] DROP CONSTRAINT [DF__VehicleDo__IsApp__589C25F3]
GO
ALTER TABLE [dbo].[Users] DROP CONSTRAINT [DF_Users_Active]
GO
ALTER TABLE [dbo].[MandatoryVehicleDocs] DROP CONSTRAINT [DF__Mandatory__IsMan__56B3DD81]
GO
ALTER TABLE [dbo].[MandatoryUserDocuments] DROP CONSTRAINT [DF__Mandatory__IsMan__55BFB948]
GO
ALTER TABLE [dbo].[LicenseDetails] DROP CONSTRAINT [DF_LicenseDetails_Active]
GO
ALTER TABLE [dbo].[DriverDocuments] DROP CONSTRAINT [DF__DriverDoc__IsApp__54CB950F]
GO
ALTER TABLE [dbo].[DriverDocuments] DROP CONSTRAINT [DF__DriverDoc__IsVer__53D770D6]
GO
ALTER TABLE [dbo].[Country] DROP CONSTRAINT [DF__Country__HasOper__52E34C9D]
GO
ALTER TABLE [dbo].[BusinessAppusers] DROP CONSTRAINT [DF_BusinessAppusers_Active]
GO
ALTER TABLE [dbo].[BusinessAppusers] DROP CONSTRAINT [DF_BusinessAppusers_Amount]
GO
ALTER TABLE [dbo].[Appusers] DROP CONSTRAINT [DF__Appusers__Active__50FB042B]
GO
/****** Object:  Table [dbo].[VehicleLayout]    Script Date: 6/28/2019 4:47:16 PM ******/
DROP TABLE [dbo].[VehicleLayout]
GO
/****** Object:  Table [dbo].[VehicleDocuments]    Script Date: 6/28/2019 4:47:16 PM ******/
DROP TABLE [dbo].[VehicleDocuments]
GO
/****** Object:  Table [dbo].[VehicleDistancePrice]    Script Date: 6/28/2019 4:47:16 PM ******/
DROP TABLE [dbo].[VehicleDistancePrice]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 6/28/2019 4:47:16 PM ******/
DROP TABLE [dbo].[Users]
GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 6/28/2019 4:47:16 PM ******/
DROP TABLE [dbo].[UserRoles]
GO
/****** Object:  Table [dbo].[Userpreferences]    Script Date: 6/28/2019 4:47:16 PM ******/
DROP TABLE [dbo].[Userpreferences]
GO
/****** Object:  Table [dbo].[UserLogins]    Script Date: 6/28/2019 4:47:16 PM ******/
DROP TABLE [dbo].[UserLogins]
GO
/****** Object:  Table [dbo].[Types]    Script Date: 6/28/2019 4:47:16 PM ******/
DROP TABLE [dbo].[Types]
GO
/****** Object:  Table [dbo].[TypeGroups]    Script Date: 6/28/2019 4:47:16 PM ******/
DROP TABLE [dbo].[TypeGroups]
GO
/****** Object:  Table [dbo].[TripPayments]    Script Date: 6/28/2019 4:47:16 PM ******/
DROP TABLE [dbo].[TripPayments]
GO
/****** Object:  Table [dbo].[TaxiSrcDest]    Script Date: 6/28/2019 4:47:16 PM ******/
DROP TABLE [dbo].[TaxiSrcDest]
GO
/****** Object:  Table [dbo].[SubCategory]    Script Date: 6/28/2019 4:47:16 PM ******/
DROP TABLE [dbo].[SubCategory]
GO
/****** Object:  Table [dbo].[Stops]    Script Date: 6/28/2019 4:47:16 PM ******/
DROP TABLE [dbo].[Stops]
GO
/****** Object:  Table [dbo].[Routes]    Script Date: 6/28/2019 4:47:16 PM ******/
DROP TABLE [dbo].[Routes]
GO
/****** Object:  Table [dbo].[RouteFare]    Script Date: 6/28/2019 4:47:16 PM ******/
DROP TABLE [dbo].[RouteFare]
GO
/****** Object:  Table [dbo].[RouteDetails]    Script Date: 6/28/2019 4:47:16 PM ******/
DROP TABLE [dbo].[RouteDetails]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 6/28/2019 4:47:16 PM ******/
DROP TABLE [dbo].[Roles]
GO
/****** Object:  Table [dbo].[PSVehicleMaster]    Script Date: 6/28/2019 4:47:16 PM ******/
DROP TABLE [dbo].[PSVehicleMaster]
GO
/****** Object:  Table [dbo].[PSVehicleBookingHistory]    Script Date: 6/28/2019 4:47:16 PM ******/
DROP TABLE [dbo].[PSVehicleBookingHistory]
GO
/****** Object:  Table [dbo].[PSVehicleBookingDetails]    Script Date: 6/28/2019 4:47:16 PM ******/
DROP TABLE [dbo].[PSVehicleBookingDetails]
GO
/****** Object:  Table [dbo].[PSVehicleAssign]    Script Date: 6/28/2019 4:47:16 PM ******/
DROP TABLE [dbo].[PSVehicleAssign]
GO
/****** Object:  Table [dbo].[PSTrackVehicle]    Script Date: 6/28/2019 4:47:16 PM ******/
DROP TABLE [dbo].[PSTrackVehicle]
GO
/****** Object:  Table [dbo].[PSHoursBasePricing]    Script Date: 6/28/2019 4:47:16 PM ******/
DROP TABLE [dbo].[PSHoursBasePricing]
GO
/****** Object:  Table [dbo].[PSDriverMaster]    Script Date: 6/28/2019 4:47:16 PM ******/
DROP TABLE [dbo].[PSDriverMaster]
GO
/****** Object:  Table [dbo].[PSDriverLogin]    Script Date: 6/28/2019 4:47:16 PM ******/
DROP TABLE [dbo].[PSDriverLogin]
GO
/****** Object:  Table [dbo].[PSDriverBankingDetails]    Script Date: 6/28/2019 4:47:16 PM ******/
DROP TABLE [dbo].[PSDriverBankingDetails]
GO
/****** Object:  Table [dbo].[PSDistancePricing]    Script Date: 6/28/2019 4:47:16 PM ******/
DROP TABLE [dbo].[PSDistancePricing]
GO
/****** Object:  Table [dbo].[PSCurrentLocationStatus]    Script Date: 6/28/2019 4:47:16 PM ******/
DROP TABLE [dbo].[PSCurrentLocationStatus]
GO
/****** Object:  Table [dbo].[Notifications]    Script Date: 6/28/2019 4:47:16 PM ******/
DROP TABLE [dbo].[Notifications]
GO
/****** Object:  Table [dbo].[MandatoryVehicleDocs]    Script Date: 6/28/2019 4:47:16 PM ******/
DROP TABLE [dbo].[MandatoryVehicleDocs]
GO
/****** Object:  Table [dbo].[MandatoryUserDocuments]    Script Date: 6/28/2019 4:47:16 PM ******/
DROP TABLE [dbo].[MandatoryUserDocuments]
GO
/****** Object:  Table [dbo].[LicenseTypes]    Script Date: 6/28/2019 4:47:16 PM ******/
DROP TABLE [dbo].[LicenseTypes]
GO
/****** Object:  Table [dbo].[LicensePricing]    Script Date: 6/28/2019 4:47:16 PM ******/
DROP TABLE [dbo].[LicensePricing]
GO
/****** Object:  Table [dbo].[LicenseDetails]    Script Date: 6/28/2019 4:47:16 PM ******/
DROP TABLE [dbo].[LicenseDetails]
GO
/****** Object:  Table [dbo].[InventoryItem]    Script Date: 6/28/2019 4:47:16 PM ******/
DROP TABLE [dbo].[InventoryItem]
GO
/****** Object:  Table [dbo].[Hourly_Tariff]    Script Date: 6/28/2019 4:47:16 PM ******/
DROP TABLE [dbo].[Hourly_Tariff]
GO
/****** Object:  Table [dbo].[FORouteFleetSchedule]    Script Date: 6/28/2019 4:47:16 PM ******/
DROP TABLE [dbo].[FORouteFleetSchedule]
GO
/****** Object:  Table [dbo].[FORouteFare]    Script Date: 6/28/2019 4:47:16 PM ******/
DROP TABLE [dbo].[FORouteFare]
GO
/****** Object:  Table [dbo].[FleetScheduleList]    Script Date: 6/28/2019 4:47:16 PM ******/
DROP TABLE [dbo].[FleetScheduleList]
GO
/****** Object:  Table [dbo].[FleetRoutes]    Script Date: 6/28/2019 4:47:16 PM ******/
DROP TABLE [dbo].[FleetRoutes]
GO
/****** Object:  Table [dbo].[FleetOwnerRouteStop]    Script Date: 6/28/2019 4:47:16 PM ******/
DROP TABLE [dbo].[FleetOwnerRouteStop]
GO
/****** Object:  Table [dbo].[FleetOwnerRoute]    Script Date: 6/28/2019 4:47:16 PM ******/
DROP TABLE [dbo].[FleetOwnerRoute]
GO
/****** Object:  Table [dbo].[FleetOwnerRequestDetails]    Script Date: 6/28/2019 4:47:16 PM ******/
DROP TABLE [dbo].[FleetOwnerRequestDetails]
GO
/****** Object:  Table [dbo].[FleetOwner]    Script Date: 6/28/2019 4:47:16 PM ******/
DROP TABLE [dbo].[FleetOwner]
GO
/****** Object:  Table [dbo].[EwalletTransactions]    Script Date: 6/28/2019 4:47:16 PM ******/
DROP TABLE [dbo].[EwalletTransactions]
GO
/****** Object:  Table [dbo].[Ewallet]    Script Date: 6/28/2019 4:47:16 PM ******/
DROP TABLE [dbo].[Ewallet]
GO
/****** Object:  Table [dbo].[EditHistoryDetails]    Script Date: 6/28/2019 4:47:16 PM ******/
DROP TABLE [dbo].[EditHistoryDetails]
GO
/****** Object:  Table [dbo].[EditHistory]    Script Date: 6/28/2019 4:47:16 PM ******/
DROP TABLE [dbo].[EditHistory]
GO
/****** Object:  Table [dbo].[DriverEwallet]    Script Date: 6/28/2019 4:47:16 PM ******/
DROP TABLE [dbo].[DriverEwallet]
GO
/****** Object:  Table [dbo].[DriverDocuments]    Script Date: 6/28/2019 4:47:16 PM ******/
DROP TABLE [dbo].[DriverDocuments]
GO
/****** Object:  Table [dbo].[DriveEwalletTrans]    Script Date: 6/28/2019 4:47:16 PM ******/
DROP TABLE [dbo].[DriveEwalletTrans]
GO
/****** Object:  Table [dbo].[DemoRequest]    Script Date: 6/28/2019 4:47:16 PM ******/
DROP TABLE [dbo].[DemoRequest]
GO
/****** Object:  Table [dbo].[CustomerAccountDetails]    Script Date: 6/28/2019 4:47:16 PM ******/
DROP TABLE [dbo].[CustomerAccountDetails]
GO
/****** Object:  Table [dbo].[CurrentState]    Script Date: 6/28/2019 4:47:16 PM ******/
DROP TABLE [dbo].[CurrentState]
GO
/****** Object:  Table [dbo].[Country]    Script Date: 6/28/2019 4:47:16 PM ******/
DROP TABLE [dbo].[Country]
GO
/****** Object:  Table [dbo].[CompanyRoles]    Script Date: 6/28/2019 4:47:16 PM ******/
DROP TABLE [dbo].[CompanyRoles]
GO
/****** Object:  Table [dbo].[Company]    Script Date: 6/28/2019 4:47:16 PM ******/
DROP TABLE [dbo].[Company]
GO
/****** Object:  Table [dbo].[BusinessAppusers]    Script Date: 6/28/2019 4:47:16 PM ******/
DROP TABLE [dbo].[BusinessAppusers]
GO
/****** Object:  Table [dbo].[BTPOSDetails]    Script Date: 6/28/2019 4:47:16 PM ******/
DROP TABLE [dbo].[BTPOSDetails]
GO
/****** Object:  Table [dbo].[Appusers]    Script Date: 6/28/2019 4:47:16 PM ******/
DROP TABLE [dbo].[Appusers]
GO
/****** Object:  Table [dbo].[AppUserCards]    Script Date: 6/28/2019 4:47:16 PM ******/
DROP TABLE [dbo].[AppUserCards]
GO
/****** Object:  Table [dbo].[AppStates]    Script Date: 6/28/2019 4:47:16 PM ******/
DROP TABLE [dbo].[AppStates]
GO
/****** Object:  Table [dbo].[Alerts]    Script Date: 6/28/2019 4:47:16 PM ******/
DROP TABLE [dbo].[Alerts]
GO
/****** Object:  Table [dbo].[AddNewCard]    Script Date: 6/28/2019 4:47:16 PM ******/
DROP TABLE [dbo].[AddNewCard]
GO
/****** Object:  Table [dbo].[AddNewCard]    Script Date: 6/28/2019 4:47:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AddNewCard](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CardNumber] [varchar](50) NOT NULL,
	[CardModel] [int] NOT NULL,
	[CardType] [int] NOT NULL,
	[CardCategory] [int] NOT NULL,
	[StatusId] [int] NULL,
	[UserId] [int] NULL,
	[Customer] [varchar](50) NULL,
	[EffectiveFrom] [date] NULL,
	[EffectiveTo] [date] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Alerts]    Script Date: 6/28/2019 4:47:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Alerts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NULL,
	[UserId] [int] NULL,
	[Title] [varchar](150) NULL,
	[Message] [varchar](500) NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedOn] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[StateId] [int] NULL,
	[StatusId] [int] NULL,
	[CategoryId] [int] NULL,
	[SubCategoryId] [int] NULL,
	[Active] [int] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AppStates]    Script Date: 6/28/2019 4:47:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AppStates](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Response] [varchar](50) NULL,
	[Description] [varchar](150) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AppUserCards]    Script Date: 6/28/2019 4:47:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AppUserCards](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CardNumber] [varchar](50) NOT NULL,
	[CardModel] [int] NULL,
	[CardType] [int] NULL,
	[CardCategory] [int] NULL,
	[StatusId] [int] NULL,
	[UserId] [int] NULL,
	[Customer] [varchar](50) NULL,
	[EffectiveFrom] [date] NULL,
	[EffectiveTo] [date] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Appusers]    Script Date: 6/28/2019 4:47:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Appusers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Mobilenumber] [varchar](20) NULL,
	[Password] [varchar](50) NULL,
	[Mobileotp] [varchar](10) NULL,
	[Emailotp] [varchar](10) NULL,
	[Passwordotp] [varchar](10) NULL,
	[StatusId] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[Mobileotpsenton] [datetime] NULL,
	[emailotpsenton] [datetime] NULL,
	[noofattempts] [int] NULL,
	[Firstname] [varchar](20) NULL,
	[lastname] [varchar](20) NULL,
	[AuthTypeId] [int] NULL,
	[AltPhonenumber] [varchar](20) NULL,
	[Altemail] [varchar](50) NULL,
	[AccountNo] [varchar](50) NULL,
	[Amount] [decimal](18, 2) NULL,
	[UserPhoto] [varchar](max) NULL,
	[Gender] [int] NULL,
	[CurrentStateId] [int] NULL,
	[CountryId] [int] NULL,
	[PaymentModeId] [int] NULL,
	[Active] [int] NULL,
	[CCode] [varchar](10) NULL,
	[UserAccountNo] [varchar](15) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BTPOSDetails]    Script Date: 6/28/2019 4:47:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BTPOSDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NULL,
	[POSID] [varchar](20) NOT NULL,
	[StatusId] [int] NOT NULL,
	[IMEI] [varchar](50) NULL,
	[ipconfig] [varchar](20) NULL,
	[active] [int] NULL,
	[FleetOwnerId] [int] NULL,
	[PerUnitPrice] [decimal](18, 2) NULL,
	[POSTypeId] [int] NULL,
	[ActivatedOn] [datetime] NULL,
	[PONum] [varchar](15) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BusinessAppusers]    Script Date: 6/28/2019 4:47:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[BusinessAppusers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Mobilenumber] [varchar](20) NULL,
	[Password] [varchar](50) NULL,
	[Mobileotp] [varchar](10) NULL,
	[Emailotp] [varchar](10) NULL,
	[Passwordotp] [varchar](10) NULL,
	[StatusId] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[Mobileotpsenton] [datetime] NULL,
	[emailotpsenton] [datetime] NULL,
	[noofattempts] [int] NULL,
	[Firstname] [varchar](20) NULL,
	[lastname] [varchar](20) NULL,
	[AuthTypeId] [int] NULL,
	[AltPhonenumber] [varchar](20) NULL,
	[Altemail] [varchar](50) NULL,
	[AccountNo] [varchar](50) NULL,
	[Amount] [decimal](18, 2) NULL,
	[UserPhoto] [varchar](max) NULL,
	[Gender] [int] NULL,
	[CurrentStateId] [int] NULL,
	[CountryId] [int] NULL,
	[PaymentModeId] [int] NULL,
	[Active] [int] NULL,
	[CCode] [varchar](10) NULL,
	[UserAccountNo] [varchar](15) NULL,
	[usertypeid] [int] NULL,
	[OwnerId] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Company]    Script Date: 6/28/2019 4:47:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Company](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Code] [varchar](50) NOT NULL,
	[Desc] [varchar](50) NULL,
	[Active] [int] NOT NULL,
	[Address] [varchar](500) NOT NULL,
	[ContactNo1] [varchar](50) NOT NULL,
	[ContactNo2] [varchar](50) NULL,
	[Fax] [varchar](50) NULL,
	[EmailId] [varchar](50) NOT NULL,
	[Title] [varchar](50) NULL,
	[Caption] [varchar](50) NULL,
	[Country] [varchar](50) NULL,
	[ZipCode] [varchar](10) NULL,
	[State] [varchar](50) NULL,
	[FleetSize] [int] NULL,
	[StaffSize] [int] NULL,
	[AlternateAddress] [varchar](500) NULL,
	[ShippingAddress] [varchar](500) NULL,
	[AddressId] [int] NULL,
	[Logo] [varchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CompanyRoles]    Script Date: 6/28/2019 4:47:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompanyRoles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
	[Active] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Country]    Script Date: 6/28/2019 4:47:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Country](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Latitude] [varchar](15) NULL,
	[Longitude] [varchar](15) NULL,
	[ISOCode] [varchar](5) NULL,
	[HasOperations] [int] NULL,
	[flag] [varchar](50) NULL,
	[Code] [varchar](10) NULL,
	[FlagLocation] [varchar](100) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CurrentState]    Script Date: 6/28/2019 4:47:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CurrentState](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](50) NULL,
	[Active] [int] NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CustomerAccountDetails]    Script Date: 6/28/2019 4:47:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CustomerAccountDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[PaymentModeId] [int] NULL,
	[AccountNumber] [varchar](250) NULL,
	[Type] [int] NULL,
	[HolderName] [varchar](250) NULL,
	[code] [varchar](50) NULL,
	[ExpMonth] [varchar](50) NULL,
	[ExpYear] [varchar](50) NULL,
	[AccountCode] [varchar](50) NULL,
	[AccountType] [varchar](150) NULL,
	[IsPrimary] [varchar](15) NULL,
	[IsVerified] [varchar](50) NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedOn] [datetime] NULL,
	[Otp] [varchar](50) NULL,
	[OtpVerfied] [varchar](50) NULL,
	[Active] [varchar](50) NULL,
	[CountryId] [varchar](50) NULL,
	[UserTypeId] [int] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DemoRequest]    Script Date: 6/28/2019 4:47:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DemoRequest](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Datetime] [datetime] NULL,
	[BusinessName] [varchar](250) NULL,
	[Email] [varchar](150) NULL,
	[MobileNumber] [varchar](50) NULL,
	[CountryId] [int] NULL,
	[LoginNo] [varchar](50) NULL,
	[Emailsenton] [datetime] NULL,
	[Otpsent] [datetime] NULL,
	[Reviewed] [varchar](50) NULL,
	[Notification] [varchar](50) NULL,
	[DashboardUsername] [varchar](50) NULL,
	[DashboardPwd] [varchar](50) NULL,
	[CustomerAppUsername] [varchar](50) NULL,
	[BusinessAppUsername] [varchar](50) NULL,
	[CustomerAppPwd] [varchar](50) NULL,
	[BusinessAppPwd] [varchar](50) NULL,
	[OtpBusinessApp] [varchar](50) NULL,
	[OtpCustomerApp] [varchar](50) NULL,
	[Emailsent] [datetime] NULL,
	[Otpsenton] [datetime] NULL,
	[ReviewedOn] [datetime] NULL,
	[NotifiedOn] [datetime] NULL,
	[ReviewedBy] [int] NULL,
	[EmailSentBy] [int] NULL,
	[StatusId] [int] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DriveEwalletTrans]    Script Date: 6/28/2019 4:47:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DriveEwalletTrans](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [date] NULL,
	[Time] [time](7) NULL,
	[Mobilenumber] [varchar](50) NULL,
	[GatewayId] [varchar](50) NULL,
	[Amount] [decimal](18, 0) NULL,
	[Comments] [varchar](50) NULL,
	[TransactionId] [varchar](50) NULL,
	[TransactionMode] [int] NULL,
	[StatusId] [int] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DriverDocuments]    Script Date: 6/28/2019 4:47:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DriverDocuments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DriverId] [int] NOT NULL,
	[FileName] [varchar](100) NOT NULL,
	[DocTypeId] [int] NULL,
	[ExpiryDate] [date] NULL,
	[CreatedById] [int] NULL,
	[UpdatedById] [int] NULL,
	[DueDate] [date] NULL,
	[FileContent] [varchar](max) NULL,
	[DocumentNo] [varchar](50) NULL,
	[DocumentNo2] [varchar](50) NULL,
	[IsVerified] [int] NULL,
	[IsApproved] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DriverEwallet]    Script Date: 6/28/2019 4:47:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DriverEwallet](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserAccountNo] [varchar](50) NULL,
	[Mobilenumber] [varchar](20) NULL,
	[Status] [int] NULL,
	[Mobileotp] [varchar](10) NULL,
	[Createdon] [datetime] NULL,
	[MOTPSentOn] [datetime] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EditHistory]    Script Date: 6/28/2019 4:47:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EditHistory](
	[Field] [varchar](50) NOT NULL,
	[SubItem] [varchar](50) NOT NULL,
	[Comment] [varchar](50) NOT NULL,
	[Date] [datetime] NOT NULL,
	[ChangedBy] [varchar](50) NOT NULL,
	[ChangedType] [varchar](50) NOT NULL,
	[Task] [varchar](50) NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EditHistoryDetails]    Script Date: 6/28/2019 4:47:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EditHistoryDetails](
	[EditHistoryId] [int] NOT NULL,
	[FromValue] [varchar](50) NULL,
	[ToValue] [varchar](50) NULL,
	[ChangeType] [varchar](50) NOT NULL,
	[Field1] [varchar](50) NULL,
	[Field2] [varchar](50) NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Ewallet]    Script Date: 6/28/2019 4:47:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ewallet](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserAccountNo] [varchar](50) NULL,
	[Mobilenumber] [varchar](20) NULL,
	[Status] [int] NULL,
	[Mobileotp] [varchar](10) NULL,
	[Createdon] [datetime] NULL,
	[MOTPSentOn] [datetime] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EwalletTransactions]    Script Date: 6/28/2019 4:47:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EwalletTransactions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [date] NULL,
	[Time] [time](7) NULL,
	[Mobilenumber] [varchar](50) NULL,
	[GatewayId] [varchar](50) NULL,
	[Amount] [decimal](18, 0) NULL,
	[Comments] [varchar](50) NULL,
	[TransactionId] [varchar](50) NULL,
	[TransactionMode] [int] NULL,
	[StatusId] [int] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FleetOwner]    Script Date: 6/28/2019 4:47:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FleetOwner](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[CompanyId] [int] NOT NULL,
	[Active] [int] NOT NULL,
	[FleetOwnerCode] [varchar](15) NOT NULL,
	[IsEmailVerified] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[EmailId] [varchar](50) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FleetOwnerRequestDetails]    Script Date: 6/28/2019 4:47:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FleetOwnerRequestDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[MiddleName] [varchar](50) NULL,
	[LastName] [varchar](50) NOT NULL,
	[PhoneNo] [varchar](50) NOT NULL,
	[AltPhoneNo] [varchar](50) NULL,
	[EmailAddress] [varchar](50) NOT NULL,
	[Address] [varchar](50) NOT NULL,
	[Gender] [int] NOT NULL,
	[CompanyName] [varchar](50) NOT NULL,
	[CmpEmailAddress] [varchar](50) NOT NULL,
	[CmpTitle] [varchar](20) NULL,
	[CmpCaption] [varchar](20) NULL,
	[FleetSize] [int] NOT NULL,
	[StaffSize] [int] NOT NULL,
	[Country] [int] NOT NULL,
	[Code] [varchar](50) NOT NULL,
	[CmpFax] [varchar](50) NULL,
	[CmpAddress] [varchar](500) NOT NULL,
	[CmpAltAddress] [varchar](500) NULL,
	[state] [int] NOT NULL,
	[ZipCode] [varchar](20) NULL,
	[CmpPhoneNo] [varchar](50) NOT NULL,
	[CmpAltPhoneNo] [varchar](50) NULL,
	[CurrentSystemInUse] [varchar](50) NULL,
	[howdidyouhearaboutus] [varchar](50) NULL,
	[SendNewProductsEmails] [bit] NOT NULL,
	[Agreetotermsandconditions] [bit] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[IsNewCompany] [int] NULL,
	[userPhoto] [varchar](max) NULL,
	[CmpLogo] [varchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FleetOwnerRoute]    Script Date: 6/28/2019 4:47:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FleetOwnerRoute](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FleetOwnerId] [int] NOT NULL,
	[CompanyId] [int] NOT NULL,
	[RouteId] [int] NOT NULL,
	[FromDate] [datetime] NULL,
	[ToDate] [datetime] NULL,
	[Active] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FleetOwnerRouteStop]    Script Date: 6/28/2019 4:47:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FleetOwnerRouteStop](
	[FleetOwnerId] [int] NOT NULL,
	[RouteStopId] [int] NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FleetRoutes]    Script Date: 6/28/2019 4:47:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FleetRoutes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[VehicleId] [int] NOT NULL,
	[RouteId] [int] NOT NULL,
	[EffectiveFrom] [datetime] NULL,
	[EffectiveTill] [datetime] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FleetScheduleList]    Script Date: 6/28/2019 4:47:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FleetScheduleList](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ScheduleName] [varchar](50) NOT NULL,
	[FleetId] [int] NOT NULL,
	[RouteId] [int] NOT NULL,
	[StartTime] [datetime] NULL,
	[EndTime] [datetime] NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedOn] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[UpdatedBy] [int] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FORouteFare]    Script Date: 6/28/2019 4:47:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FORouteFare](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[VehicleId] [int] NOT NULL,
	[RouteId] [int] NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[PricingTypeId] [int] NOT NULL,
	[FromDate] [datetime] NULL,
	[ToDate] [datetime] NULL,
	[UnitPrice] [decimal](18, 2) NOT NULL,
	[SourceId] [int] NOT NULL,
	[DestinationId] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FORouteFleetSchedule]    Script Date: 6/28/2019 4:47:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FORouteFleetSchedule](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[VehicleId] [int] NOT NULL,
	[RouteId] [int] NOT NULL,
	[FleetOwnerId] [int] NOT NULL,
	[StopId] [int] NOT NULL,
	[ArrivalHr] [int] NULL,
	[DepartureHr] [int] NULL,
	[Duration] [decimal](18, 2) NULL,
	[ArrivalMin] [int] NULL,
	[DepartureMin] [int] NULL,
	[ArrivalAMPM] [varchar](2) NULL,
	[DepartureAMPM] [varchar](2) NULL,
	[ArrivalTime] [datetime] NULL,
	[DepartureTime] [datetime] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Hourly_Tariff]    Script Date: 6/28/2019 4:47:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hourly_Tariff](
	[SrNo] [int] IDENTITY(1,1) NOT NULL,
	[Duration] [nvarchar](50) NULL,
	[KiloMtr] [int] NULL,
	[IndicaRate] [int] NULL,
	[IndigoRate] [int] NULL,
	[InnovaRate] [int] NULL,
	[Tag] [nvarchar](255) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[InventoryItem]    Script Date: 6/28/2019 4:47:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[InventoryItem](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ItemName] [varchar](50) NOT NULL,
	[Code] [varchar](50) NOT NULL,
	[Description] [varchar](50) NULL,
	[CategoryId] [int] NOT NULL,
	[SubCategoryId] [int] NOT NULL,
	[ReOrderPoint] [int] NOT NULL,
	[ItemImage] [varchar](max) NULL,
	[Price] [decimal](18, 2) NULL,
	[ItemModel] [varchar](50) NULL,
	[Features] [varchar](50) NULL,
	[PublishDate] [datetime] NULL,
	[ExpiryDate] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LicenseDetails]    Script Date: 6/28/2019 4:47:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LicenseDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LicenseTypeId] [int] NOT NULL,
	[FeatureTypeId] [int] NOT NULL,
	[FeatureLabel] [varchar](50) NULL,
	[FeatureValue] [varchar](100) NULL,
	[LabelClass] [varchar](50) NULL,
	[Active] [int] NOT NULL,
	[fromDate] [datetime] NULL,
	[toDate] [datetime] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LicensePricing]    Script Date: 6/28/2019 4:47:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LicensePricing](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LicenseId] [int] NOT NULL,
	[RenewalFreqTypeId] [int] NOT NULL,
	[RenewalFreq] [int] NOT NULL,
	[UnitPrice] [decimal](18, 2) NOT NULL,
	[fromdate] [datetime] NULL,
	[todate] [datetime] NULL,
	[Active] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LicenseTypes]    Script Date: 6/28/2019 4:47:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LicenseTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LicenseType] [varchar](50) NOT NULL,
	[LicenseCode] [varchar](55) NOT NULL,
	[LicenseCatId] [int] NOT NULL,
	[Description] [varchar](500) NULL,
	[Active] [int] NOT NULL,
	[EffectiveFrom] [datetime] NULL,
	[EffectiveTill] [datetime] NULL,
	[OpCode] [int] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MandatoryUserDocuments]    Script Date: 6/28/2019 4:47:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[MandatoryUserDocuments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserTypeId] [int] NOT NULL,
	[DocTypeId] [int] NOT NULL,
	[CountryId] [int] NOT NULL,
	[Active] [int] NOT NULL,
	[FileContent] [varchar](max) NULL,
	[IsMandatory] [int] NOT NULL,
	[VehicleGroupId] [int] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MandatoryVehicleDocs]    Script Date: 6/28/2019 4:47:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[MandatoryVehicleDocs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CountryId] [int] NOT NULL,
	[DocTypeId] [int] NOT NULL,
	[VehicleGroupId] [int] NOT NULL,
	[Active] [int] NOT NULL,
	[FileContent] [varchar](max) NULL,
	[IsMandatory] [int] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Notifications]    Script Date: 6/28/2019 4:47:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Notifications](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NULL,
	[UserId] [int] NULL,
	[Title] [varchar](150) NULL,
	[Message] [varchar](500) NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedOn] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[StateId] [int] NULL,
	[StatusId] [int] NULL,
	[CategoryId] [int] NULL,
	[SubCategoryId] [int] NULL,
	[Active] [int] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PSCurrentLocationStatus]    Script Date: 6/28/2019 4:47:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PSCurrentLocationStatus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[VId] [int] NULL,
	[DId] [int] NULL,
	[Latitude] [numeric](10, 6) NULL,
	[Longitude] [numeric](10, 6) NULL,
	[Date] [date] NULL,
	[Time] [time](7) NULL,
	[Status] [varchar](50) NULL,
	[DriverNo] [varchar](20) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PSDistancePricing]    Script Date: 6/28/2019 4:47:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PSDistancePricing](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[VehicleTypeId] [int] NULL,
	[FromKm] [int] NULL,
	[ToKm] [int] NULL,
	[PricingType] [int] NULL,
	[FromDate] [date] NULL,
	[ToDate] [date] NULL,
	[PerUnitPrice] [decimal](18, 2) NULL,
	[Amount] [decimal](18, 2) NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[CountryId] [int] NULL,
	[VehicleGroupId] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PSDriverBankingDetails]    Script Date: 6/28/2019 4:47:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PSDriverBankingDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Accountnumber] [varchar](50) NULL,
	[BankName] [varchar](50) NULL,
	[BankCode] [varchar](50) NULL,
	[BranchAddress] [varchar](50) NULL,
	[CountryId] [int] NULL,
	[IsActive] [int] NULL,
	[DriverId] [int] NULL,
	[DRCode] [varchar](20) NULL,
	[QRCode] [varchar](max) NULL,
	[IsPrimary] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PSDriverLogin]    Script Date: 6/28/2019 4:47:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PSDriverLogin](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DId] [int] NULL,
	[VId] [int] NULL,
	[LoginDate] [date] NULL,
	[LoginTime] [time](7) NULL,
	[LogoutDate] [date] NULL,
	[LogoutTime] [time](7) NULL,
	[Reason] [varchar](500) NULL,
	[Status] [varchar](50) NULL,
	[LoginLatitude] [numeric](18, 6) NULL,
	[LoginLongitude] [numeric](18, 6) NULL,
	[LogoutLatitude] [numeric](18, 6) NULL,
	[LogoutLongitude] [numeric](18, 6) NULL,
	[CompanyId] [int] NULL,
	[DriverNo] [varchar](20) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PSDriverMaster]    Script Date: 6/28/2019 4:47:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PSDriverMaster](
	[DId] [int] IDENTITY(1,1) NOT NULL,
	[NAme] [nvarchar](50) NULL,
	[Address] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[Pin] [nvarchar](50) NULL,
	[PAddress] [nvarchar](50) NULL,
	[PCity] [nvarchar](50) NULL,
	[PPin] [nvarchar](50) NULL,
	[OffMobileNo] [float] NULL,
	[PMobNo] [nvarchar](255) NULL,
	[DOB] [date] NULL,
	[DOJ] [date] NULL,
	[BloodGroup] [nvarchar](50) NULL,
	[Remarks] [nvarchar](50) NULL,
	[CompanyId] [int] NULL,
	[Photo] [varchar](max) NULL,
	[VehicleModelId] [int] NULL,
	[Status] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Mobileotp] [varchar](10) NULL,
	[Emailotp] [varchar](10) NULL,
	[Passwordotp] [varchar](10) NULL,
	[CreatedOn] [datetime] NULL,
	[Mobileotpsenton] [datetime] NULL,
	[emailotpsenton] [datetime] NULL,
	[noofattempts] [int] NULL,
	[Firstname] [varchar](20) NULL,
	[lastname] [varchar](20) NULL,
	[AuthTypeId] [int] NULL,
	[AltPhonenumber] [varchar](20) NULL,
	[Altemail] [varchar](50) NULL,
	[AccountNo] [varchar](50) NULL,
	[DriverCode] [varchar](15) NULL,
	[VehicleGroupId] [int] NULL,
	[CountryId] [int] NULL,
	[StatusId] [int] NULL,
	[CurrentStateId] [int] NOT NULL,
	[IsPEmailVerified] [int] NULL,
	[IsApproved] [int] NULL,
	[IsVerified] [int] NULL,
	[PaymentTypeId] [int] NULL,
	[UserAccountNo] [varchar](50) NULL,
	[UserTypeId] [int] NULL,
	[FleetOwnerId] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PSHoursBasePricing]    Script Date: 6/28/2019 4:47:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PSHoursBasePricing](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[VehicleTypeId] [int] NULL,
	[Hours] [int] NULL,
	[FromTime] [time](7) NULL,
	[ToTime] [time](7) NULL,
	[FromDate] [date] NULL,
	[ToDate] [date] NULL,
	[PricingType] [int] NULL,
	[Price] [decimal](18, 2) NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[CountryId] [int] NULL,
	[VehicleGroupId] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PSTrackVehicle]    Script Date: 6/28/2019 4:47:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PSTrackVehicle](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Mobilenumber] [varchar](50) NULL,
	[Latitude] [numeric](10, 6) NULL,
	[Longitude] [numeric](10, 6) NULL,
	[Date] [date] NULL,
	[Time] [time](7) NULL,
	[Status] [varchar](50) NULL,
	[city] [varchar](50) NULL,
	[description] [varchar](50) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PSVehicleAssign]    Script Date: 6/28/2019 4:47:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PSVehicleAssign](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NULL,
	[EntryDate] [datetime] NULL,
	[BookingNo] [int] NULL,
	[ReqDate] [datetime] NULL,
	[ReqTime] [datetime] NULL,
	[CallTime] [datetime] NULL,
	[CustomerName] [nvarchar](255) NULL,
	[CusID] [nvarchar](255) NULL,
	[PhoneNo] [nvarchar](255) NULL,
	[AltPhoneNo] [nvarchar](255) NULL,
	[Address] [nvarchar](max) NULL,
	[PickupAddress] [nvarchar](max) NULL,
	[LandMark] [nvarchar](255) NULL,
	[PickupPlace] [nvarchar](255) NULL,
	[DropPlace] [nvarchar](255) NULL,
	[Package] [nvarchar](255) NULL,
	[VehicleType] [nvarchar](255) NULL,
	[NoofVehicle] [int] NULL,
	[VechID] [int] NULL,
	[RegistrationNo] [nvarchar](255) NULL,
	[DriverName] [nvarchar](255) NULL,
	[PresentDriverLandMark] [nvarchar](255) NULL,
	[ExecutiveName] [nvarchar](255) NULL,
	[EffectiveDate] [date] NULL,
	[EffectiveTill] [date] NULL,
	[DriverId] [int] NULL,
	[VehicleModelId] [int] NULL,
	[ServiceTypeId] [int] NULL,
	[VehicleGroupId] [int] NULL,
	[Status] [varchar](50) NULL,
	[IsVerified] [int] NULL,
	[IsApproved] [int] NULL,
	[FleetId] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PSVehicleBookingDetails]    Script Date: 6/28/2019 4:47:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PSVehicleBookingDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BNo] [varchar](20) NULL,
	[BookedDate] [date] NULL,
	[BookedTime] [time](7) NULL,
	[DepartueDate] [date] NULL,
	[DepartureTime] [time](7) NULL,
	[BookingType] [varchar](50) NULL,
	[Src] [varchar](50) NULL,
	[Dest] [varchar](50) NULL,
	[SrcId] [int] NULL,
	[DestId] [int] NULL,
	[SrcLatitude] [numeric](18, 6) NULL,
	[SrcLongitude] [numeric](18, 6) NULL,
	[DestLatitude] [numeric](18, 6) NULL,
	[DestLongitude] [numeric](18, 6) NULL,
	[VechId] [int] NULL,
	[PackageId] [int] NULL,
	[Pricing] [decimal](18, 2) NULL,
	[DriverId] [int] NULL,
	[DriverPhoneNo] [varchar](20) NULL,
	[CustomerPhoneNo] [varchar](20) NULL,
	[CustomerId] [int] NULL,
	[BookingStatus] [varchar](50) NULL,
	[NoofVehicles] [int] NULL,
	[NoofSeats] [int] NULL,
	[ClosingDate] [date] NULL,
	[ClosingTime] [time](7) NULL,
	[CancelledOn] [datetime] NULL,
	[CancelledBy] [varchar](50) NULL,
	[BookingChannel] [varchar](50) NULL,
	[Reasons] [varchar](500) NULL,
	[CompanyId] [int] NULL,
	[BooKingOTP] [varchar](20) NULL,
	[Amount] [decimal](18, 2) NULL,
	[PaymentStatus] [varchar](50) NULL,
	[Rating] [float] NULL,
	[RatedBy] [int] NULL,
	[Comments] [varchar](250) NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedUserId] [int] NULL,
	[DriverRating] [float] NULL,
	[DriverRated] [int] NULL,
	[DriverComments] [varchar](250) NULL,
	[TripCount] [int] NULL,
	[SeatsOccupied] [int] NULL,
	[VehicleGroupId] [int] NULL,
	[Distance] [decimal](18, 2) NULL,
	[PaymentTypeId] [int] NULL,
	[OrderNo] [int] NULL,
	[WithLuggage] [int] NULL,
	[LuggageWeight] [int] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PSVehicleBookingHistory]    Script Date: 6/28/2019 4:47:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PSVehicleBookingHistory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BookingId] [int] NULL,
	[Vid] [int] NULL,
	[Date] [date] NULL,
	[Time] [time](7) NULL,
	[Status] [varchar](50) NULL,
	[ExpirationTime] [time](7) NULL,
	[BNo] [varchar](10) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PSVehicleMaster]    Script Date: 6/28/2019 4:47:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PSVehicleMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NULL,
	[RegistrationNo] [varchar](50) NOT NULL,
	[ChasisNo] [varchar](50) NULL,
	[Engineno] [varchar](50) NULL,
	[FleetOwnerId] [int] NULL,
	[VehicleTypeId] [int] NULL,
	[ModelYear] [varchar](5) NULL,
	[EntryDate] [date] NULL,
	[VehicleModelId] [int] NULL,
	[HasAC] [int] NULL,
	[VehicleGroupId] [int] NOT NULL,
	[StatusId] [int] NOT NULL,
	[IsVerified] [int] NULL,
	[VehicleCode] [varchar](10) NOT NULL,
	[IsDriverOwned] [int] NOT NULL,
	[DriverId] [int] NULL,
	[CountryId] [int] NULL,
	[VehicleMakeId] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[Approved] [int] NULL,
	[VID] [int] NULL,
	[Photo] [varchar](max) NULL,
	[IsApproved] [int] NULL,
	[FrontImage] [varchar](max) NULL,
	[BackImage] [varchar](max) NULL,
	[RightImage] [varchar](max) NULL,
	[LeftImage] [varchar](max) NULL,
	[NoofSeats] [int] NULL,
	[LayoutTypeId] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 6/28/2019 4:47:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](500) NULL,
	[Active] [int] NOT NULL,
	[IsPublic] [int] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RouteDetails]    Script Date: 6/28/2019 4:47:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RouteDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RouteId] [int] NOT NULL,
	[StopId] [int] NOT NULL,
	[DistanceFromSource] [decimal](18, 2) NULL,
	[DistanceFromDestination] [decimal](18, 2) NULL,
	[DistanceFromPreviousStop] [decimal](18, 2) NULL,
	[DistanceFromNextStop] [decimal](18, 2) NULL,
	[PreviousStopId] [int] NOT NULL,
	[NextStopId] [int] NOT NULL,
	[StopNo] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RouteFare]    Script Date: 6/28/2019 4:47:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RouteFare](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RouteId] [int] NOT NULL,
	[VehicleTypeId] [int] NOT NULL,
	[SourceStopId] [int] NOT NULL,
	[DestinationStopId] [int] NOT NULL,
	[Distance] [decimal](18, 2) NOT NULL,
	[PerUnitPrice] [decimal](18, 2) NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[FareTypeId] [int] NOT NULL,
	[RouteStopId] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Routes]    Script Date: 6/28/2019 4:47:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Routes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RouteName] [varchar](50) NOT NULL,
	[Code] [varchar](10) NOT NULL,
	[Description] [varchar](50) NULL,
	[Active] [int] NOT NULL,
	[SourceId] [int] NOT NULL,
	[DestinationId] [int] NOT NULL,
	[Distance] [decimal](18, 2) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Stops]    Script Date: 6/28/2019 4:47:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Stops](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](30) NOT NULL,
	[Description] [varchar](30) NULL,
	[Code] [varchar](50) NOT NULL,
	[Active] [int] NULL,
	[Latitude] [numeric](18, 6) NULL,
	[Longitude] [numeric](18, 6) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SubCategory]    Script Date: 6/28/2019 4:47:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[SubCategory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](150) NULL,
	[CategoryId] [int] NOT NULL,
	[Active] [int] NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TaxiSrcDest]    Script Date: 6/28/2019 4:47:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TaxiSrcDest](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Description] [varchar](50) NULL,
	[Latitude] [decimal](18, 6) NULL,
	[Longitude] [decimal](18, 6) NULL,
	[PlaceId] [varchar](20) NULL,
	[ShortName] [varchar](50) NULL,
	[LongName] [varchar](100) NULL,
	[CountryId] [int] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TripPayments]    Script Date: 6/28/2019 4:47:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TripPayments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BNo] [int] NULL,
	[Amount] [decimal](18, 2) NULL,
	[GatewayTransId] [varchar](20) NULL,
	[StatusId] [int] NULL,
	[TransDate] [datetime] NULL,
	[PaymentModeId] [int] NULL,
	[Comments] [varchar](250) NULL,
	[CustAccountId] [int] NULL,
	[AppUserId] [int] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TypeGroups]    Script Date: 6/28/2019 4:47:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TypeGroups](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](50) NULL,
	[Active] [int] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Types]    Script Date: 6/28/2019 4:47:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Types](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](50) NULL,
	[Active] [int] NOT NULL,
	[TypeGroupId] [int] NOT NULL,
	[listkey] [varchar](10) NULL,
	[listvalue] [varchar](20) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserLogins]    Script Date: 6/28/2019 4:47:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[UserLogins](
	[LoginInfo] [nvarchar](50) NOT NULL,
	[PassKey] [nvarchar](50) NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[salt] [varchar](50) NULL,
	[Active] [int] NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Userpreferences]    Script Date: 6/28/2019 4:47:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Userpreferences](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[userid] [int] NULL,
	[email] [varchar](50) NULL,
	[Address] [varchar](250) NULL,
	[Accountid] [int] NULL,
	[preferenceTypeId] [int] NULL,
	[preferenceId] [int] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 6/28/2019 4:47:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
	[CompanyId] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 6/28/2019 4:47:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[MiddleName] [varchar](50) NULL,
	[EmpNo] [varchar](20) NOT NULL,
	[EmailId] [varchar](50) NOT NULL,
	[RoleId] [int] NULL,
	[CompanyId] [int] NOT NULL,
	[Active] [int] NOT NULL,
	[GenderId] [int] NOT NULL,
	[ManagerId] [int] NULL,
	[CountryId] [int] NULL,
	[StateId] [int] NULL,
	[ZipCode] [varchar](10) NULL,
	[ContactNo1] [varchar](20) NULL,
	[ContactNo2] [varchar](20) NULL,
	[Address] [varchar](500) NULL,
	[AltAddress] [varchar](500) NULL,
	[photo] [varchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[VehicleDistancePrice]    Script Date: 6/28/2019 4:47:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[VehicleDistancePrice](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SourceLoc] [varchar](200) NULL,
	[DestinationLoc] [varchar](200) NULL,
	[SourceLat] [numeric](10, 6) NULL,
	[SourceLng] [numeric](10, 6) NULL,
	[DestinationLat] [numeric](10, 6) NULL,
	[DestinationLng] [numeric](10, 6) NULL,
	[VehicleGroupId] [int] NULL,
	[VehicleTypeId] [int] NULL,
	[PricingTypeId] [int] NULL,
	[Distance] [decimal](18, 2) NULL,
	[UnitPrice] [money] NULL,
	[Amount] [money] NULL,
	[SrcId] [int] NULL,
	[DestId] [int] NULL,
	[CountryId] [int] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[VehicleDocuments]    Script Date: 6/28/2019 4:47:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[VehicleDocuments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[VehicleId] [int] NOT NULL,
	[FileName] [varchar](100) NOT NULL,
	[DocTypeId] [int] NULL,
	[ExpiryDate] [date] NULL,
	[CreatedById] [int] NULL,
	[UpdatedById] [int] NULL,
	[DueDate] [date] NULL,
	[FileContent] [varchar](max) NULL,
	[DocumentNo] [varchar](50) NULL,
	[DocumentNo2] [varchar](50) NULL,
	[IsVerified] [int] NULL,
	[IsApproved] [int] NULL,
	[UserTypeId] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[VehicleLayout]    Script Date: 6/28/2019 4:47:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[VehicleLayout](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[VehicleLayoutTypeId] [int] NOT NULL,
	[RowNo] [int] NOT NULL,
	[ColNo] [int] NOT NULL,
	[VehicleTypeId] [int] NOT NULL,
	[label] [varchar](10) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Appusers] ADD  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[BusinessAppusers] ADD  CONSTRAINT [DF_BusinessAppusers_Amount]  DEFAULT ((0)) FOR [Amount]
GO
ALTER TABLE [dbo].[BusinessAppusers] ADD  CONSTRAINT [DF_BusinessAppusers_Active]  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[Country] ADD  DEFAULT ((0)) FOR [HasOperations]
GO
ALTER TABLE [dbo].[DriverDocuments] ADD  DEFAULT ((0)) FOR [IsVerified]
GO
ALTER TABLE [dbo].[DriverDocuments] ADD  DEFAULT ((0)) FOR [IsApproved]
GO
ALTER TABLE [dbo].[LicenseDetails] ADD  CONSTRAINT [DF_LicenseDetails_Active]  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[MandatoryUserDocuments] ADD  DEFAULT ((0)) FOR [IsMandatory]
GO
ALTER TABLE [dbo].[MandatoryVehicleDocs] ADD  DEFAULT ((0)) FOR [IsMandatory]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_Active]  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[VehicleDocuments] ADD  DEFAULT ((0)) FOR [IsApproved]
GO
ALTER TABLE [dbo].[VehicleDocuments] ADD  DEFAULT ((0)) FOR [UserTypeId]
GO
