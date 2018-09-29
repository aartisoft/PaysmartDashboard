/****** Object:  StoredProcedure [dbo].[PSValidateCred]    Script Date: 29-09-2018 18:27:53 ******/
DROP PROCEDURE [dbo].[PSValidateCred]
GO
/****** Object:  StoredProcedure [dbo].[PSTrackVehicleHistory]    Script Date: 29-09-2018 18:27:53 ******/
DROP PROCEDURE [dbo].[PSTrackVehicleHistory]
GO
/****** Object:  StoredProcedure [dbo].[PSProcessPayment]    Script Date: 29-09-2018 18:27:53 ******/
DROP PROCEDURE [dbo].[PSProcessPayment]
GO
/****** Object:  StoredProcedure [dbo].[PSPasswordverification]    Script Date: 29-09-2018 18:27:53 ******/
DROP PROCEDURE [dbo].[PSPasswordverification]
GO
/****** Object:  StoredProcedure [dbo].[PSMOTPverifying]    Script Date: 29-09-2018 18:27:53 ******/
DROP PROCEDURE [dbo].[PSMOTPverifying]
GO
/****** Object:  StoredProcedure [dbo].[PSInsUpdVehicleBookingDetails]    Script Date: 29-09-2018 18:27:53 ******/
DROP PROCEDURE [dbo].[PSInsUpdVehicleBookingDetails]
GO
/****** Object:  StoredProcedure [dbo].[PSInsUpdDriverLogin]    Script Date: 29-09-2018 18:27:53 ******/
DROP PROCEDURE [dbo].[PSInsUpdDriverLogin]
GO
/****** Object:  StoredProcedure [dbo].[PSInsUpdDelPasswordverification]    Script Date: 29-09-2018 18:27:53 ******/
DROP PROCEDURE [dbo].[PSInsUpdDelPasswordverification]
GO
/****** Object:  StoredProcedure [dbo].[PSInsUpdCustomerAccountDetails]    Script Date: 29-09-2018 18:27:53 ******/
DROP PROCEDURE [dbo].[PSInsUpdCustomerAccountDetails]
GO
/****** Object:  StoredProcedure [dbo].[PSInsUpdAppusers]    Script Date: 29-09-2018 18:27:53 ******/
DROP PROCEDURE [dbo].[PSInsUpdAppusers]
GO
/****** Object:  StoredProcedure [dbo].[PSInsUpdAppDrivers]    Script Date: 29-09-2018 18:27:53 ******/
DROP PROCEDURE [dbo].[PSInsUpdAppDrivers]
GO
/****** Object:  StoredProcedure [dbo].[PSGetbookingStatus]    Script Date: 29-09-2018 18:27:53 ******/
DROP PROCEDURE [dbo].[PSGetbookingStatus]
GO
/****** Object:  StoredProcedure [dbo].[PSEOTPverification]    Script Date: 29-09-2018 18:27:53 ******/
DROP PROCEDURE [dbo].[PSEOTPverification]
GO
/****** Object:  StoredProcedure [dbo].[InsupdTripPayments]    Script Date: 29-09-2018 18:27:53 ******/
DROP PROCEDURE [dbo].[InsupdTripPayments]
GO
/****** Object:  StoredProcedure [dbo].[InsUpdDelNotifications]    Script Date: 29-09-2018 18:27:53 ******/
DROP PROCEDURE [dbo].[InsUpdDelNotifications]
GO
/****** Object:  StoredProcedure [dbo].[HVRateTheTrip]    Script Date: 29-09-2018 18:27:53 ******/
DROP PROCEDURE [dbo].[HVRateTheTrip]
GO
/****** Object:  StoredProcedure [dbo].[HVGetRideDetails]    Script Date: 29-09-2018 18:27:53 ******/
DROP PROCEDURE [dbo].[HVGetRideDetails]
GO
/****** Object:  StoredProcedure [dbo].[HVgetnearvehicle]    Script Date: 29-09-2018 18:27:53 ******/
DROP PROCEDURE [dbo].[HVgetnearvehicle]
GO
/****** Object:  StoredProcedure [dbo].[HVgetnearestvehicles]    Script Date: 29-09-2018 18:27:53 ******/
DROP PROCEDURE [dbo].[HVgetnearestvehicles]
GO
/****** Object:  StoredProcedure [dbo].[GetTripStatus]    Script Date: 29-09-2018 18:27:53 ******/
DROP PROCEDURE [dbo].[GetTripStatus]
GO
/****** Object:  StoredProcedure [dbo].[GetConfigurationData]    Script Date: 29-09-2018 18:27:53 ******/
DROP PROCEDURE [dbo].[GetConfigurationData]
GO
/****** Object:  StoredProcedure [dbo].[DriverCredentials]    Script Date: 29-09-2018 18:27:53 ******/
DROP PROCEDURE [dbo].[DriverCredentials]
GO
/****** Object:  StoredProcedure [dbo].[DriverCredentials]    Script Date: 29-09-2018 18:28:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[DriverCredentials] 
@DriverNo varchar(20),
@Password varchar(20)
as
	begin

declare @did int = null,@count int,@DriverId int

select @did=DId,@count = [noofattempts] from dbo.PSDriverMaster where PMobNo = @DriverNo and [Password]=@Password
	if @did is null 
		begin
	           --check if the attempts exceeded 3
	           if @count > 2 
	           begin
	             
	             update dbo.PSDriverMaster 
	             set CurrentStateId = 20
	             where PMobNo = @DriverNo
	            
	             RAISERROR ('Account is locked due to more than 3 invalid attempts',16,1);
				return;	

	           end
	           else	             
	           begin
	              update dbo.PSDriverMaster 
	             set [noofattempts] = ([noofattempts] +1)
	             where PMobNo = @DriverNo
	            
	             RAISERROR ('Invalid mobile number or password',16,1);
				 return;	
	           end 
 
		end   
		else
		begin
		      update dbo.PSDriverMaster 
	             set [noofattempts] = 0
	             where PMobNo = @DriverNo and [Password]=@Password
 --select @DriverId = DriverId from PSVehicleAssign where PhoneNo = @DriverNo
 --if @DriverId is null 
 --begin
 -- RAISERROR ('Driver is not assign to any vehicle',16,1);
 --   return;	
	-- end
 
SELECT [Id]
      ,did
      ,[VechID] as VehicleId
      ,[EffectiveDate]  fromdate
      ,[EffectiveTill] todate
      ,d.[IsVerified] 
	  ,d.[IsApproved]
  FROM [dbo].[PSDriverMaster] d 
  left outer join [dbo].[PSVehicleAssign] v
  on d.did = v.DriverId
		  where [DId] = @did

            
 
 end
 
  
		  
 end


GO
/****** Object:  StoredProcedure [dbo].[GetConfigurationData]    Script Date: 29-09-2018 18:28:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[GetConfigurationData] 
	@includeStatus int = 0
,@includeCategories int = 0
,@includeLicenseCategories int = 0
,@includeVehicleGroup int = 0
,@includeGender int = 0
,@includeFrequency int = 0
,@includePricingType int = 0
,@includeTransactionType int = 0
,@includeApplicability int = 0
,@includeFeeCategory int = 0
,@includeTransChargeType int = 0
,@includeVehicleType int = 0
,@includeVehicleModel int = 0
,@includeVehicleMake int = 0
,@includeDocumentType int = 0
,@includePaymentType int = 0
,@includeMiscellaneousTypes int = 0
,@includeCardCategories int = 0
,@includeCardTypes int = 0
,@includeVehicleLayoutType int = 0
,@includeLicenseFeatures int = 0
,@includeCardModels int = 0
,@includeCards int = 0
,@includeTransactions int = 0
,@includeCountry int = 0
,@includeActiveCountry int = 0
,@includeFleetOwner int = 0
,@includeUserType int =0
,@includeAuthType int =0
,@includeState int=0
,@includePackageTypeName int =0
,@includePackageNames int=0
--,@needCompanyName int=0
,@includeUnitType int=0
,@includeUnit int=0
,@includeApplicabilityType int=0
,@includeOperationName int = 0
,@includeValueType int=0
,@includeApplyOn int=0
AS
BEGIN
	if @includeStatus  = 1
	  SELECT [Id]
      ,[Name]
      ,[Description]
      ,[Active]
      ,[TypeGroupId]
      ,[listkey]
      ,[listvalue]
  FROM [dbo].[Types] where [TypeGroupId] =  1

 
	if @includeCategories  = 1
	SELECT [Id]
      ,[Name]
      ,[Description]
      ,[Active]
      ,[TypeGroupId]
      ,[listkey]
      ,[listvalue]
  FROM [dbo].[Types] where [TypeGroupId] =  2
  
	if @includeLicenseCategories  = 1
	SELECT [Id]
      ,[Name]
      ,[Description]
      ,[Active]
      ,[TypeGroupId]
      ,[listkey]
      ,[listvalue]
  FROM [dbo].[Types] where [TypeGroupId] =  3
  
	if @includeVehicleGroup  = 1
	SELECT [Id]
      ,[Name]
      ,[Description]
      ,[Active]
      ,[TypeGroupId]
      ,[listkey]
      ,[listvalue]
  FROM [dbo].[Types] where [TypeGroupId] =  4

	if @includeGender  = 1
	SELECT [Id]
      ,[Name]
      ,[Description]
      ,[Active]
      ,[TypeGroupId]
      ,[listkey]
      ,[listvalue]
  FROM [dbo].[Types] where [TypeGroupId] =  5

	if @includeFrequency  = 1
	SELECT [Id]
      ,[Name]
      ,[Description]
      ,[Active]
      ,[TypeGroupId]
      ,[listkey]
      ,[listvalue]
  FROM [dbo].[Types] where [TypeGroupId] =  6



	if @includePricingType  = 1
	SELECT [Id]
      ,[Name]
      ,[Description]
      ,[Active]
      ,[TypeGroupId]
      ,[listkey]
      ,[listvalue]
  FROM [dbo].[Types] where [TypeGroupId] =  7

	if @includeTransactionType  = 1
	SELECT [Id]
      ,[Name]
      ,[Description]
      ,[Active]
      ,[TypeGroupId]
      ,[listkey]
      ,[listvalue]
  FROM [dbo].[Types] where [TypeGroupId] =  8
  
	if @includeApplicability  = 1
	SELECT [Id]
      ,[Name]
      ,[Description]
      ,[Active]
      ,[TypeGroupId]
      ,[listkey]
      ,[listvalue]
  FROM [dbo].[Types] where [TypeGroupId] =  9
  
	if @includeFeeCategory  = 1
	SELECT [Id]
      ,[Name]
      ,[Description]
      ,[Active]
      ,[TypeGroupId]
      ,[listkey]
      ,[listvalue]
  FROM [dbo].[Types] where [TypeGroupId] =  10
  
	if @includeTransChargeType  = 1
	SELECT [Id]
      ,[Name]
      ,[Description]
      ,[Active]
      ,[TypeGroupId]
      ,[listkey]
      ,[listvalue]
  FROM [dbo].[Types] where [TypeGroupId] =  11
  
	if @includeVehicleType  = 1
	SELECT [Id]
      ,[Name]
      ,[Description]
      ,[Active]
      ,[TypeGroupId]
      ,[listkey]
      ,[listvalue]
  FROM [dbo].[Types] where [TypeGroupId] =  12
  
	if @includeVehicleModel  = 1
	SELECT [Id]
      ,[Name]
      ,[Description]
      ,[Active]
      ,[TypeGroupId]
      ,[listkey]
      ,[listvalue]
  FROM [dbo].[Types] where [TypeGroupId] =  13
  
	if @includeVehicleMake  = 1
	SELECT [Id]
      ,[Name]
      ,[Description]
      ,[Active]
      ,[TypeGroupId]
      ,[listkey]
      ,[listvalue]
  FROM [dbo].[Types] where [TypeGroupId] =  14
  
	if @includeDocumentType  = 1
	SELECT [Id]
      ,[Name]
      ,[Description]
      ,[Active]
      ,[TypeGroupId]
      ,[listkey]
      ,[listvalue]
  FROM [dbo].[Types] where [TypeGroupId] =  15
  
	if @includePaymentType  = 1
	SELECT [Id]
      ,[Name]
      ,[Description]
      ,[Active]
      ,[TypeGroupId]
      ,[listkey]
      ,[listvalue]
  FROM [dbo].[Types] where [TypeGroupId] =  16
  
	if @includeMiscellaneousTypes  = 1
	SELECT [Id]
      ,[Name]
      ,[Description]
      ,[Active]
      ,[TypeGroupId]
      ,[listkey]
      ,[listvalue]
  FROM [dbo].[Types] where [TypeGroupId] =  17
  
	if @includeCardCategories  = 1
	SELECT [Id]
      ,[Name]
      ,[Description]
      ,[Active]
      ,[TypeGroupId]
      ,[listkey]
      ,[listvalue]
  FROM [dbo].[Types] where [TypeGroupId] =  18
  
	if @includeCardTypes  = 1
	SELECT [Id]
      ,[Name]
      ,[Description]
      ,[Active]
      ,[TypeGroupId]
      ,[listkey]
      ,[listvalue]
  FROM [dbo].[Types] where [TypeGroupId] =  19
  
	if @includeVehicleLayoutType  = 1
	SELECT [Id]
      ,[Name]
      ,[Description]
      ,[Active]
      ,[TypeGroupId]
      ,[listkey]
      ,[listvalue]
  FROM [dbo].[Types] where [TypeGroupId] =  20
  
	if @includeLicenseFeatures  = 1
	SELECT [Id]
      ,[Name]
      ,[Description]
      ,[Active]
      ,[TypeGroupId]
      ,[listkey]
      ,[listvalue]
  FROM [dbo].[Types] where [TypeGroupId] =  21
  
	if @includeCardModels  = 1
	SELECT [Id]
      ,[Name]
      ,[Description]
      ,[Active]
      ,[TypeGroupId]
      ,[listkey]
      ,[listvalue]
  FROM [dbo].[Types] where [TypeGroupId] =  22
  
	if @includeCards  = 1
	SELECT [Id]
      ,[Name]
      ,[Description]
      ,[Active]
      ,[TypeGroupId]
      ,[listkey]
      ,[listvalue]
  FROM [dbo].[Types] where [TypeGroupId] =  23
  
	if @includeTransactions  = 1
	SELECT [Id]
      ,[Name]
      ,[Description]
      ,[Active]
      ,[TypeGroupId]
      ,[listkey]
      ,[listvalue]
  FROM [dbo].[Types] where [TypeGroupId] =  24
  
	if @includeCountry  = 1
	SELECT [Id]
      ,[Name]
      ,[Latitude]
      ,[Longitude]
      ,[ISOCode]
      ,[HasOperations]
  FROM [dbo].[Country]

	if @includeActiveCountry  = 1
	SELECT [Id]
      ,[Name]
      ,[Latitude]
      ,[Longitude]
      ,[ISOCode]
      ,[HasOperations]
  FROM [dbo].[Country] where HasOperations = 1
  
	if @includeFleetOwner  = 1
	select u.FirstName+' '+u.LastName as Name,
	c.Name as CompanyName
	,FO.FleetOwnerCode
	,FO.CompanyId
	,FO.Id
	,FO.UserId
	 from FleetOwner FO
	inner join Users u on  u.Id =  FO.UserId
	inner join Company c on c.Id =  FO.companyId
    --where (FO.company[TypeGroupId] =  @cmpId or @cmp[TypeGroupId] = -1)
	order by u.FirstName,u.LastName

if @includeUserType = 1
SELECT [Id]
      ,[Name]
      ,[Description]
      ,[Active]
      ,[TypeGroupId]
      ,[listkey]
      ,[listvalue]
  FROM [dbo].[Types] where [TypeGroupId] = 25	
  
  if @includeAuthType = 1
SELECT [Id]
      ,[Name]
      ,[Description]
      ,[Active]
      ,[TypeGroupId]
      ,[listkey]
      ,[listvalue]
  FROM [dbo].[Types] where [TypeGroupId] = 27
  
  if @includeState  = 1
SELECT [Id]
      ,[Name]
      ,[Description]
      ,[Active]
      ,[TypeGroupId]
      ,[listkey]
      ,[listvalue]
  FROM [dbo].[Types] where [TypeGroupId] = 28
  	
	If @includePackageTypeName=1
  	SELECT [Id]
      ,[PackageId]
      ,[Name]      
  FROM [dbo].[PackagesTypes]
  
  if @includePackageNames =1
  SELECT [Id]
      ,[VehicleGroupId]
      ,[Name]      
  FROM [dbo].[Packages]

 -- if @needCompanyName = 1
	--select Name,Id from Company order by Name
	
	if @includeApplicabilityType = 1
SELECT [Id]
      ,[Name]
      ,[Description]
      ,[Active]
      ,[TypeGroupId]
      ,[listkey]
      ,[listvalue]
  FROM [dbo].[Types] where [TypeGroupId] = 26	
  
  if @includeUnitType = 1
SELECT [Id]
      ,[Name]
      ,[Description]
      ,[Active]
      ,[TypeGroupId]
      ,[listkey]
      ,[listvalue]
  FROM [dbo].[Types] where [TypeGroupId] = 29	
  
   if @includeUnit = 1
SELECT [Id]
      ,[Name]
      ,[Description]
      ,[Active]
      ,[TypeGroupId]
      ,[listkey]
      ,[listvalue]
  FROM [dbo].[Types] where [TypeGroupId] = 30	
  
  if @includeOperationName = 1
  SELECT [Id]
      ,[Name]
      ,[Description]
      ,[Active]
      ,[TypeGroupId]
      ,[listkey]
      ,[listvalue]
  FROM [dbo].[Types] where [TypeGroupId] = 35	
  
   if @includeValueType = 1
  SELECT [Id]
      ,[Name]
      ,[Description]
      ,[Active]
      ,[TypeGroupId]
      ,[listkey]
      ,[listvalue]
  FROM [dbo].[Types] where [TypeGroupId] = 34
  
   if @includeApplyOn = 1
  SELECT [Id]
      ,[Name]
      ,[Description]
      ,[Active]
      ,[TypeGroupId]
      ,[listkey]
      ,[listvalue]
  FROM [dbo].[Types] where [TypeGroupId] = 31

END

GO
/****** Object:  StoredProcedure [dbo].[GetTripStatus]    Script Date: 29-09-2018 18:28:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetTripStatus]
@BNo varchar(20)
as
begin

declare @cnt int


select @cnt = Count(*) from PSVehicleBookingDetails where BNo = @BNo

 if @cnt = 0
   begin
          RAISERROR('Invalid Booking Number',18,6);
          return;

end
else 
begin

SELECT p.[Id]
      ,[BNo]
	  ,t.Latitude
	  ,t.Longitude
	  ,t.Status
  FROM [dbo].[PSVehicleBookingDetails] p
  inner join PSCurrentLocationStatus t on t.DId = p.DriverId

where BNo=@BNo and BookingStatus = 'OnTrip'
end
end


GO
/****** Object:  StoredProcedure [dbo].[HVgetnearestvehicles]    Script Date: 29-09-2018 18:28:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[HVgetnearestvehicles]
@VehicleGroupId int,@UserId int,@lat numeric(10,6),@lng numeric(10,6)
as
begin 

 select [Name]
  from Types where TypeGroupId = 12


  select  top 10  l.Latitude,l.Longitude,VM.VehicleGroupId,l.Status,vm.RegistrationNo
 from PSCurrentLocationStatus l
inner join  PSVehicleMaster VM on l.VId = VM.Id
inner join PSDriverMaster d on d.Did = l.Did
where (VM.VehicleGroupId = @VehicleGroupId or @VehicleGroupId = -1) and l.Status = 19
 order by ((l.Latitude) - @lat),((l.Longitude) - @lng) 


SELECT [Id]
      ,[Username]
      ,[Email]
      ,[Mobilenumber]
      ,[Password]
      ,[Mobileotp]
      ,[Emailotp]
      ,[Passwordotp]
      ,[StatusId]
      ,[CreatedOn]
      ,[Mobileotpsenton]
      ,[emailotpsenton]
      ,[noofattempts]
      ,[Firstname]
      ,[lastname]
      ,[AuthTypeId]
      ,[AltPhonenumber]
      ,[Altemail]
      ,[AccountNo]
      ,[Amount]
      ,[UserPhoto]
      ,[Gender]
      ,[CurrentStateId]
      ,[CountryId]
      ,[PaymentModeId]
  FROM [dbo].[Appusers]
  where Id = @UserId 

 

end


GO
/****** Object:  StoredProcedure [dbo].[HVgetnearvehicle]    Script Date: 29-09-2018 18:28:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[HVgetnearvehicle]
@bno varchar(10)
as
begin
select ps.Latitude,ps.Longitude,BookingStatus,[PaymentTypeId],[Pricing]+'30' as Amount from PSVehicleBookingDetails vb
inner join PSCurrentLocationStatus ps on ps.VId = VechId and ps.DId = vb.DriverId
where BNo = @bno

end


GO
/****** Object:  StoredProcedure [dbo].[HVGetRideDetails]    Script Date: 29-09-2018 18:28:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[HVGetRideDetails]
@BNo varchar(20)
as
begin

SELECT b.[Id]
      ,b.[BNo]
      ,[BookedDate]
      ,[BookedTime]
      ,[DepartueDate]
      ,[DepartureTime]
      ,[BookingType]
      ,[Src]
      ,[Dest]
      ,[SrcId]
      ,[DestId]
      ,[SrcLatitude]
      ,[SrcLongitude]
      ,[DestLatitude]
      ,[DestLongitude]
      ,[VechId]
      ,[PackageId]
      ,[Pricing]
      ,b.[DriverId]
      ,[DriverPhoneNo]
      ,[CustomerPhoneNo]
      ,[CustomerId]
      ,[BookingStatus]
      ,[NoofVehicles]
      ,b.[NoofSeats]
      ,[ClosingDate]
      ,[ClosingTime]
      ,[CancelledOn]
      ,[CancelledBy]
      ,[BookingChannel]
      ,[Reasons]
      ,b.[CompanyId]
      ,[BooKingOTP]
      ,t.[Amount] as Amount
      ,[PaymentStatus]
      ,[Rating]
      ,[RatedBy]
      ,b.[Comments]
      ,[UpdatedBy]
      ,[UpdatedUserId]
      ,d.NAme driver
      ,d.Photo as DPhoto
      ,vm.RegistrationNo  
      ,vm.Photo as VPhoto 
      ,t.PaymentModeId as PaymentModeId
      ,t.GatewayTransId as GatewayTransId  
      from PSVehicleBookingDetails b
      inner join PSVehicleMaster vm on vm.Id = b.VechId
      inner join PSDriverMaster d on d.DId = b.DriverId 
      inner join TripPayments t on t.BNo = b.BNo     
       where b.BNo= @BNo
      
end


GO
/****** Object:  StoredProcedure [dbo].[HVRateTheTrip]    Script Date: 29-09-2018 18:28:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[HVRateTheTrip]
@Mobilenumber varchar(20),@BNo varchar(20),@rating float,@RatedBy int,@Comment varchar(250)--,@DriverPhoneNo varchar(20)
as
begin
update dbo.PSVehicleBookingDetails 
set [Rating] = @Rating,
 [RatedBy] = @RatedBy, 
[Comments]=@Comment
where BNo = @BNo

select [BNo],[CustomerPhoneNo],[Rating],[RatedBy] from PSVehicleBookingDetails  where BNo = @BNo
end


GO
/****** Object:  StoredProcedure [dbo].[InsUpdDelNotifications]    Script Date: 29-09-2018 18:28:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create procedure [dbo].[InsUpdDelNotifications]
(@flag varchar, @Id int=-1,@RoleId int=null
           ,@UserId int=null
           ,@Title varchar(150)=null
           ,@Message varchar(500)=null
           ,@CreatedOn datetime=null
           ,@UpdatedOn datetime=null
           ,@UpdatedBy int=null
           ,@StateId int=null
           ,@StatusId int=null
           ,@CategoryId int=null
           ,@SubCategoryId int=null
           ,@Active int=null)
 as
 begin 
 if(@flag='I')
 begin           
 INSERT INTO [dbo].[Notifications]
           ([RoleId]
           ,[UserId]
           ,[Title]
           ,[Message]
           ,[CreatedOn]
           ,[UpdatedOn]
           ,[UpdatedBy]
           ,[StateId]
           ,[StatusId]
           ,[CategoryId]
           ,[SubCategoryId]
           ,[Active])
     VALUES
           (@RoleId 
           ,@UserId 
           ,@Title 
           ,@Message 
           ,@CreatedOn
           ,@UpdatedOn
           ,@UpdatedBy 
           ,@StateId
           ,@StatusId
           ,@CategoryId
           ,@SubCategoryId
           ,@Active )
     end
   else if(@flag='U')
   begin
   UPDATE [dbo].[Notifications]
   SET [RoleId] = @RoleId
      ,[UserId] = @UserId
      ,[Title] = @Title
      ,[Message] = @Message
      ,[CreatedOn] = @CreatedOn
      ,[UpdatedOn] = @UpdatedOn
      ,[UpdatedBy] = @UpdatedBy
      ,[StateId] = @StateId
      ,[StatusId] = @StatusId
      ,[CategoryId] = @CategoryId
      ,[SubCategoryId] = @SubCategoryId
      ,[Active] = @Active
 WHERE Id=@Id
   end
   else if(@flag='D')
   begin
   delete from Notifications where Id=@Id
   end 
   end



GO
/****** Object:  StoredProcedure [dbo].[InsupdTripPayments]    Script Date: 29-09-2018 18:28:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[InsupdTripPayments]
(@Flag varchar
  ,@Id int = -1
,@BNo int
,@Amount decimal
,@StatusId int =null
,@GatewayTransId varchar(20)=null
,@TransDate datetime =null
,@PaymentModeId int 
,@Comments varchar(250) =null
,@CustAccountId int = null
 ,@AppUserId int = null)
      As 
      Begin
  declare @dt datetime,@cnt int
  set @dt = GETDATE()
  
  select @cnt = COUNT(*) from Appusers where Id  = @AppUserId 
  if @cnt = 0 
  begin
  RAISERROR('No Registered User',18,6);
  return;
  end   
     If @Flag = 'I'
     Begin
      INSERT INTO [dbo].[TripPayments]
           ([BNo]
           ,[Amount]
           ,[GatewayTransId]
           ,[StatusId]
           ,[TransDate]
           ,[PaymentModeId]
           ,[Comments]
           ,[CustAccountId]
           ,[AppUserId])
     VALUES
           (@BNo
           ,@Amount
           ,@GatewayTransId
           ,@StatusId
           ,@dt
           ,@PaymentModeId
           ,@Comments
           ,@CustAccountId
           ,@AppUserId)
           
           select [Id] from TripPayments where BNo = @BNo  
End
If @Flag ='U'
begin
UPDATE [dbo].[TripPayments]
   SET [BNo] = @BNo
      ,[Amount] = @Amount
      ,[GatewayTransId] = @GatewayTransId
      ,[StatusId] = @StatusId
      ,[TransDate] = @dt
      ,[PaymentModeId] = @PaymentModeId
      ,[Comments] = @Comments
      ,[CustAccountId] = @CustAccountId
      ,[AppUserId] = @AppUserId
 WHERE Id=@Id
 select Id,[GatewayTransId],[PaymentModeId] from TripPayments where Id  = @Id
End
if @Flag = 'D'
Begin
 DELETE FROM [dbo].[TripPayments]
      WHERE Id=@Id
End

End


GO
/****** Object:  StoredProcedure [dbo].[PSEOTPverification]    Script Date: 29-09-2018 18:28:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[PSEOTPverification]
@Email varchar(50),@Emailotp varchar(10),@UserId int
as
begin

declare @cnt int

select @cnt = COUNT(*) from Appusers where Email = @Email and Id = @UserId

if @cnt = 0
   begin
  
				RAISERROR ('Invalid Email address or mobile number',16,1);
				return;
   end

else

begin

  select @cnt = COUNT(*) from Appusers where Email = @Email and [Emailotp] = @Emailotp and Id = @UserId
  if @cnt = 0
	begin
	  
					RAISERROR ('Invalid Email address or Email OTP',16,1);
					return;
	end
 
  else
 
   begin
     update Appusers set Emailotp  = null where Email  = @Email  and [Emailotp]  = @Emailotp and Id = @UserId
   
     select [Username] ,[Email] ,[Mobilenumber] ,[Password] ,[Mobileotp] ,[Emailotp] ,[Passwordotp] ,[StatusId] ,[CreatedOn] ,[Mobileotpsenton] ,[emailotpsenton] ,[noofattempts] 
      from Appusers where Email  = @Email and Id = @UserId
      --select 1
   end
 
end

end


GO
/****** Object:  StoredProcedure [dbo].[PSGetbookingStatus]    Script Date: 29-09-2018 18:28:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[PSGetbookingStatus]
@BNo varchar(50), @requestType int = 0
as
begin
if @requestType = 0
begin
	select b.BooKingOTP,d.Name,d.PMobNo,d.Photo as img,v.Id, v.RegistrationNo,V.Photo VPhoto,'Indica' as VModel
	 from PSVehicleBookingDetails b
	inner join PSDriverMaster d on d.DId = b.DriverId
	inner join PSVehicleMaster v on v.Id = b.VechId
	--inner join Types t on t.Id = v.VehicleGroupId
	where BNo = @BNo and BookingStatus = 'accepted'
end

end


GO
/****** Object:  StoredProcedure [dbo].[PSInsUpdAppDrivers]    Script Date: 29-09-2018 18:28:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE  [dbo].[PSInsUpdAppDrivers]
@flag varchar
,@Mobilenumber varchar(20)
,@Email varchar(50) = null
,@Password varchar(50) = null
,@Firstname varchar(20)
,@lastname varchar(20)
,@AuthTypeId int
,@Id int=-1
,@CountryId int = null
,@bioMetricData varchar(max) = null
,@DPhoto varchar(max) = null
,@VehicleGroupId int = null

,@RegistrationNo VarChar(50) = null
,@VehicleTypeId int = null
,@isDriverOwned int = null
,@VPhoto varchar(max) = null
                    
AS
BEGIN

declare @cnt int, @m varchar(4), @p varchar(4),@e varchar(4),@Did int = null, @Vid int = null
declare @dt datetime
set @dt = GETDATE()

select @m = replace(CONVERT(VARCHAR(1), GETDATE(), 114),':','')+ CONVERT(VARCHAR(3),DATEPART(millisecond,GETDATE()))

--otp only when email id is given
	if @Email is not null
select @e = replace(CONVERT(VARCHAR(1), GETDATE(), 114),':','')+ CONVERT(VARCHAR(3),DATEPART(millisecond,GETDATE()))+5

   

	if @flag = 'I'
	begin
	
	select @cnt = COUNT(*) from PSDriverMaster where PMobNo = @Mobilenumber 

	if @cnt > 0
		begin
				RAISERROR ('Already user registered with given mobile number',16,1);
				return;	
		end
		
		if @Email is not null
		begin
		select @cnt = COUNT(*) from PSDriverMaster where Email = @Email
		
		if @cnt > 0
		begin
				RAISERROR ('Already user registered with given Email Address',16,1);
				return;	
		end
		end
		
		if @RegistrationNo is not null
    begin
				select @cnt = COUNT(*) from [PSVehicleMaster] where RegistrationNo = @RegistrationNo 
				if @cnt > 0
				begin
						RAISERROR ('RegistrationNo Already exists',16,1);
						return;	
				end			
	    end
    
	
	insert into dbo.PSDriverMaster 
			([NAme],[Firstname],[lastname] ,[Email],[PMobNo] ,[Password],[AuthTypeId],[CountryId]  ,[Mobileotp] ,[Emailotp],[CreatedOn],[Mobileotpsenton] ,[emailotpsenton],[AccountNo]
			,				[DriverCode],[VehicleGroupId],[StatusId], [Photo],[CurrentStateId])
	values
			(@Firstname+@lastname,@Firstname,@lastname,@Email ,@Mobilenumber ,@Password,@AuthTypeId,@CountryId,@m ,@e ,@dt ,@dt ,@dt,@Mobilenumber,'D'+@Mobilenumber, @VehicleGroupId, 1 ,@DPhoto,1)
			
			 
            --get the inserted driver id
            
            
SELECT @DId = SCOPE_IDENTITY()
declare @mss varchar(100)  = 'a new driver ' +@Mobilenumber+' is created through app'

	 exec [InsUpdDelNotifications]  'I',-1,1,1,'new driver creation',@mss,@dt,@dt,1,1,1,1,1,1 
            if @Did is not null
            begin
	
	--declare @mss varchar(100)  = 'a new driver <a href="DriverDetails.html?DId='+ cast(@DId as varchar(7)) +'">' +@Mobilenumber+'</a> is created through app'
	
           INSERT INTO [dbo].[DriverDocuments]
           ([DriverId]
           ,[FileName]
           ,[DocTypeId]
           )
			 select @Did,t.name,DocTypeId 
			 from [dbo].[MandatoryUserDocuments]
			 inner join types t on t.id = DocTypeId
           where CountryId = @CountryId and UserTypeId = 109 and VehicleGroupId = @VehicleGroupId

           end
            
            if @RegistrationNo is not null
            begin
				select @cnt = COUNT(*) from [PSVehicleMaster] where RegistrationNo = @RegistrationNo 
				if @cnt > 0
				begin
						RAISERROR ('RegistrationNo Already exists',16,1);
						return;	
	end
				else
				begin
				   
						 --insert the vehicle
							INSERT INTO [dbo].[PSVehicleMaster]
							 ([RegistrationNo],[VehicleGroupId],[StatusId],[VehicleCode],[IsDriverOwned],[DriverId],[CountryId],[VehicleTypeId],[Photo])
							VALUES
							 (@RegistrationNo,@VehicleGroupId,1,'V'+@RegistrationNo,@IsDriverOwned,@Did,@CountryId,@VehicleTypeId,@VPhoto)
	         
							--get the vehicle id
							SELECT @VId = SCOPE_IDENTITY()
							if @Vid is not null 
							begin
							--declare @vmssg varchar(100) = 'a new vehicle <a href="VehicleDetails.html?VID='+ cast(@VId as varchar(7)) +'">' +@RegistrationNo+'</a> is created through app' 
	declare @vmssg varchar(100) = 'a new vehicle ' +@RegistrationNo+' is created through app' 
								exec [InsUpdDelNotifications]  'I',-1,1,1,'new vehicle creation',@vmssg,@dt,@dt,1,1,1,1,1,1 
	
							   INSERT INTO [dbo].[VehicleDocuments]
							   ([VehicleId]
							   ,[FileName]
							   ,[DocTypeId]
							   )
								 select @Vid,t.name,DocTypeId 
								 from [dbo].[MandatoryVehicleDocs]
								 inner join types t on t.id = DocTypeId
							   where CountryId = @CountryId and VehicleGroupId = @VehicleGroupId
							end
						--insert vehicle driver assignment
	
						INSERT INTO [dbo].[PSVehicleAssign] ([DriverId],[VechID],[EffectiveDate],[EffectiveTill],[IsVerified],PhoneNo,[RegistrationNo])
						VALUES(@Did,@Vid,@dt,null,0,@Mobilenumber,@RegistrationNo)


		end
            end
	
	end
	else
	
	
	if @flag ='U'
    begin
		--select @cnt = COUNT(*) from PSDriverMaster where (upper(NAme) = upper(@Drivername) or PMobNo = @Mobilenumber
		--or Email = @Email) and DId <> @Id
	
		--if @cnt = 0
		--	begin
		--			RAISERROR ('No user registered with given mobile number',16,1);
		--			return;
		--	end
		--else
		--	begin
	
	
		--	Update dbo.PSDriverMaster 
		--	set NAme= @Drivername ,	
		--	[Email]= @Email,	
		--	[Password]= @Password,
		--	[Mobileotp]=@Mobileotp ,
		--	[Emailotp]= @Emailotp,
		--	[Passwordotp]= @Passwordotp,
		--	[Status]=@StatusId,
		--	[CreatedOn]= @CreatedOn,
		--	[Mobileotpsenton]= @Mobileotpsenton,
		--	[emailotpsenton]= @emailotpsenton,
		--	[noofattempts]= @noofattempts,
		--	[Firstname] =@Firstname,
		--	[lastname] =@lastname,
		--	[AuthTypeId] =@AuthTypeId,
		--	[AltPhonenumber] =@AltPhonenumber,
		--	[Altemail] =@Altemail,
		--	[AccountNo] =@Mobilenumber
		--	where PMobNo = @Mobilenumber 
	
		--end
	 select 1
	end
	
	
	select [Firstname]+lastname as Name ,[Email] ,[PMobNo] ,[Password] ,[Mobileotp] ,[Emailotp] ,[Passwordotp] ,[Status] ,[CreatedOn] ,[Mobileotpsenton] ,[emailotpsenton] ,[noofattempts],[Firstname],[lastname],[AuthTypeId],[AltPhonenumber],[Altemail],[AccountNo],@Did DriverId,@Vid VehicleId from PSDriverMaster where PMobNo = @Mobilenumber
	

END


GO
/****** Object:  StoredProcedure [dbo].[PSInsUpdAppusers]    Script Date: 29-09-2018 18:28:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE  [dbo].[PSInsUpdAppusers]
@flag varchar,@Id int=-1,@Username varchar(50) = null,@Email varchar(50) = null
,@Mobilenumber varchar(20),@Password varchar(50) = null,@Mobileotp varchar(10) = null
,@Emailotp varchar(10) = null,@Passwordotp varchar(10) = null,@Status int = null
,@CreatedOn datetime = null,
@Mobileotpsenton datetime = null,
@emailotpsenton datetime = null,
@noofattempts int = null,
@Firstname varchar(20) = null,@lastname varchar(20)= null,
@AuthTypeId int= null,@AltPhonenumber varchar(20)= null,
@Altemail varchar(50)= null,@AccountNo varchar(50)= null,
@Amount decimal = null,@UserPhoto varchar(max) = null,@Gender int = null,@PaymentModeId int =null
,@AccountNumber varchar(50)=null
,@HolderName varchar(50)=null
,@code varchar(50)=null
,@ExpMonth varchar(20)=null
,@ExpYear varchar(20)=null,
@AccountCode varchar(50)=null
,@AccountType varchar(50)=null
,@CountryId int=null
,@CurrentStateId int=null

AS
BEGIN

declare @cnt int, @m varchar(4), @p varchar(4),@e varchar(4),@nid int,@cotp varchar(5)
declare @dt datetime
set @dt = GETDATE()


select @m = replace(CONVERT(VARCHAR(1), GETDATE(), 114),':','')+ CONVERT(VARCHAR(3),DATEPART(millisecond,GETDATE()))
select @e = replace(CONVERT(VARCHAR(1), GETDATE(), 114),':','')+ CONVERT(VARCHAR(3),DATEPART(millisecond,GETDATE()))+5
select @cotp = replace(CONVERT(VARCHAR(1), GETDATE(), 114),':','')+ CONVERT(VARCHAR(3),DATEPART(millisecond,GETDATE()))+20

	if @flag = 'I'
	begin
	
	select @cnt = COUNT(*) from Appusers where Mobilenumber = @Mobilenumber  and  Email = @Email

	if @cnt > 0
		begin
				RAISERROR ('Already user registered with given mobile number or Email Address',16,1);
				return;	
		end
		
		
		
	else
    begin
    
	
	insert into dbo.Appusers 
	([Username] ,[Email] ,[Mobilenumber] ,[Password] ,[Mobileotp] ,[Emailotp] ,
	[Passwordotp] ,[StatusId] ,[CreatedOn] ,[Mobileotpsenton] ,[emailotpsenton] ,
	[noofattempts],[Firstname],[lastname],[AuthTypeId],[AltPhonenumber],[Altemail],[AccountNo],[UserPhoto] ,[Gender],[Amount],[CountryId],[CurrentStateId],[PaymentModeId] )
	values
	(@Username ,@Email ,@Mobilenumber ,@Password ,@m ,@e ,null ,@Status ,
	@dt ,@dt ,@dt ,0,@Firstname,@lastname,@AuthTypeId,@AltPhonenumber,@Altemail,@AccountNumber,@UserPhoto,@Gender,0,@CountryId,@CurrentStateId,@PaymentModeId)
	
	exec [InsUpdDelNotifications]  'I',-1,1,1,'New User','a new user is created through app','10/28/2017','10/28/2017',1,1,1,1,1,1 
	select @nid = SCOPE_IDENTITY()
	exec [PSInsUpdCustomerAccountDetails]  'I',-1,@nid,@PaymentModeId,@AccountNumber,@HolderName,@code,@ExpMonth,@ExpYear,@AccountCode,@AccountType,null,null,@dt,@dt,@cotp,null,null,@CountryId
exec [PSInsUpdCustomerAccountDetails]  'I',-1,@nid,@PaymentModeId,@AccountNumber,@HolderName,@code,@ExpMonth,@ExpYear,@AccountCode,@AccountType,null,null,@dt,@dt,@cotp,null,null,@CountryId

	end
	
	
	
	end
	
	else
	
	if @flag ='U'
	begin
	select @cnt = COUNT(*) from Appusers where (upper(UserName) = upper(@UserName) or Mobilenumber = @Mobilenumber
	or Email = @Email) and Id <> @Id

	if @cnt = 0
		begin
				RAISERROR ('No user registered with given mobile number',16,1);
				return;
		end
	else
    begin
	
	
	Update dbo.Appusers 
	set [Username]= @Username ,	
	[Email]= @Email,	
	[Password]= @Password,
	[Mobileotp]=@Mobileotp ,
	[Emailotp]= @Emailotp,
	[Passwordotp]= @Passwordotp,
	[StatusId]=@Status,
	[CreatedOn]= @CreatedOn,
	[Mobileotpsenton]= @Mobileotpsenton,
	[emailotpsenton]= @emailotpsenton,
	[noofattempts]= @noofattempts,
	[Firstname] =@Firstname,
	[lastname] =@lastname,
	[AuthTypeId] =@AuthTypeId,
	[AltPhonenumber] =@AltPhonenumber,
	[Altemail] =@Altemail,
	[AccountNo] =@AccountNo,
	[Amount] = @Amount,
    [UserPhoto] = @UserPhoto,
    [Gender] = @Gender,
    [CountryId]=@CountryId,
	[CurrentStateId]=@CurrentStateId,
	[PaymentModeId]=@PaymentModeId
	where Mobilenumber =@Mobilenumber	 
	
	end
	
	end
	SELECT [Id]
      ,[Username]
      ,[Email]
      ,[Mobilenumber]
      ,[Password]            
      ,[Firstname]
      ,[lastname]
      ,[AuthTypeId]
      ,[AltPhonenumber]
      ,[Altemail]
      ,[AccountNo]
      ,[Amount]
      ,[UserPhoto]
      ,[Gender]
      ,[Emailotp]
      ,[Mobileotp] 
	  ,[CountryId]
	  ,CurrentStateId
	  ,PaymentModeId
  FROM [dbo].[Appusers]
 where Mobilenumber = @Mobilenumber

	--select [Username] ,[Email] ,[Mobilenumber] ,[Password] ,[Mobileotp] ,[Emailotp] ,[Passwordotp] ,[StatusId] ,[CreatedOn] ,[Mobileotpsenton] ,[emailotpsenton] ,[noofattempts],[Firstname],[lastname],[AuthTypeId],[AltPhonenumber],[Altemail],[AccountNo]  from Appusers where Mobilenumber = @Mobilenumber
	

END

GO
/****** Object:  StoredProcedure [dbo].[PSInsUpdCustomerAccountDetails]    Script Date: 29-09-2018 18:28:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[PSInsUpdCustomerAccountDetails]
@insUpdDelFlag varchar,
@Id int = -1 
,@UserId int
,@PaymentModeId int
,@AccountNumber varchar(250)=null
,@HolderName varchar(250)=null
,@code varchar(50)=null
,@ExpMonth varchar(50)=null
,@ExpYear varchar(50)=null
,@AccountCode varchar(50)=null
,@AccountType varchar(150)=null
,@IsPrimary varchar(15)=null
,@IsVerified varchar(15)=null
,@CreatedOn datetime=null
,@UpdatedOn datetime=null
,@Otp varchar(50)=null
,@OtpVerfied varchar(50)=null
,@Active varchar(50)=null
,@CountryId varchar(50)=null
,@UserTypeId int=null
           As
           Begin
           if @insUpdDelFlag = 'I'
           begin
INSERT INTO [dbo].[CustomerAccountDetails]
          ( [UserId]
           ,[PaymentModeId]
           ,[AccountNumber]           
           ,[HolderName]
           ,[code]
           ,[ExpMonth]
           ,[ExpYear]
           ,[AccountCode]
           ,[AccountType]
           ,[IsPrimary]
           ,[IsVerified]
           ,[CreatedOn]
           ,[UpdatedOn]
           ,[Otp]
           ,[OtpVerfied]
           ,[Active]
           ,[CountryId]
           ,[UserTypeId])
     VALUES
           (@UserId
           , @PaymentModeId 
           ,@AccountNumber          
           ,@HolderName 
           ,@code 
           ,@ExpMonth 
           ,@ExpYear 
           ,@AccountCode 
           ,@AccountType 
           ,@IsPrimary 
           ,@IsVerified 
           ,@CreatedOn 
           ,@UpdatedOn 
           ,@Otp 
           ,@OtpVerfied 
           ,@Active 
           ,@CountryId
           ,@UserTypeId )
end
if @insUpdDelFlag = 'U'
Begin
UPDATE [dbo].[CustomerAccountDetails]
   SET [UserId] = @UserId
        ,[PaymentModeId] = @PaymentModeId
      ,[AccountNumber] = @AccountNumber      
      ,[HolderName] = @HolderName
      ,[code] = @code
      ,[ExpMonth] = @ExpMonth
      ,[ExpYear] = @ExpYear
      ,[AccountCode] = @AccountCode
      ,[AccountType] = @AccountType
      ,[IsPrimary] = @IsPrimary
      ,[IsVerified] = @IsVerified
      ,[CreatedOn] = @CreatedOn
      ,[UpdatedOn] = @UpdatedOn
      ,[Otp] = @Otp
      ,[OtpVerfied] = @OtpVerfied
      ,[Active] = @Active
      ,[CountryId] = @CountryId
      ,[UserTypeId]=@UserTypeId
 WHERE Id=@Id
 End
 if @insUpdDelFlag = 'D'
 Begin
 DELETE FROM [dbo].[CustomerAccountDetails]
      WHERE  Id=@Id

end

end



GO
/****** Object:  StoredProcedure [dbo].[PSInsUpdDelPasswordverification]    Script Date: 29-09-2018 18:28:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[PSInsUpdDelPasswordverification]
@Mobilenumber varchar(20) = null,
@Email varchar(50) =null,@CountryId int = null
as
begin


declare @cnt int,@p varchar(5)
declare @dt datetime
 
set @dt = GETDATE()
select @p = replace(CONVERT(VARCHAR(1), GETDATE(), 114),':','')+ CONVERT(VARCHAR(3),DATEPART(millisecond,GETDATE()))


	select @cnt = COUNT(*) from Appusers where Mobilenumber = @Mobilenumber and Email = @Email
	if @cnt = 0
	begin
	            RAISERROR ('Invalid mobile number or email address',16,1);
				return;	
	end
	else
	begin
	    update dbo.Appusers 
	    set [Passwordotp] = @p  
	    where Mobilenumber = @Mobilenumber and Email = @Email
		 
	end

   select [Passwordotp]  from Appusers where  Mobilenumber = @Mobilenumber 
end


GO
/****** Object:  StoredProcedure [dbo].[PSInsUpdDriverLogin]    Script Date: 29-09-2018 18:28:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[PSInsUpdDriverLogin]
(@loginlogout int = null
,@Reason varchar(500)=null
,@DriverNo varchar(20) 
,@LoginLatitude numeric(18,6)=null
,@LoginLongitude numeric(18,6)=null
)
as
begin

declare @dt date,@t time(7),@Did int = null, @Vid int = null,@count int,@IsApproved int
SET @dt = GETDATE()
SET @t = GETDATE()

select @Vid = vechId, @Did = DriverId from PSVehicleAssign where PhoneNo = @DriverNo 



if @Did is null or @Vid is null 
begin
  RAISERROR ('Driver not assign to any vehicle',16,1);
  return
end

select @IsApproved  = ISApproved from PSDriverMaster where PMobNo = @DriverNo 
if @IsApproved is null  or @IsApproved = 0
begin
 RAISERROR ('Driver has been not approved',16,1);
  return
end  

if @loginlogout = 1
begin
   UPDATE [dbo].[PSDriverLogin]
   SET [LoginDate] = @dt
      ,[LoginTime] = @t     
      ,[Reason] = @Reason      
      ,[LoginLatitude] = @LoginLatitude
      ,[LoginLongitude] = @LoginLongitude 
      ,[Status] = 19           
 WHERE DriverNo = @DriverNo and (logoutlatitude is null and logoutlongitude is null)
 
if @@rowcount = 0
begin
   INSERT INTO [dbo].[PSDriverLogin]
           ([DId]
           ,[VId]
           ,[LoginDate]
           ,[LoginTime]          
           ,[Reason]           
           ,[LoginLatitude]
           ,[LoginLongitude]
           ,DriverNo          
           ,Status)
     VALUES
           (@DId 
           ,@VId 
           ,@dt 
           ,@t          
           ,@Reason            
           ,@LoginLatitude 
           ,@LoginLongitude
           ,@DriverNo           
           ,19) 
end
  update [PSDriverMaster]
  set StatusId = 19
  where PMobNo = @DriverNo
  
  update dbo.PSCurrentLocationStatus
  set [Status] = 19
  where DriverNo = @DriverNo
   
end
else
begin
   UPDATE [dbo].[PSDriverLogin]
   SET [LogoutDate] = @dt
      ,[LogoutTime] = @t
      ,[Reason] = @Reason         
      ,[LogoutLatitude] = @LoginLatitude
      ,[LogoutLongitude] = @LoginLongitude  
      ,Status = 17    
 WHERE DriverNo = @DriverNo and (loginlatitude is not null and loginlongitude is not null)
 
  update [PSDriverMaster]
  set StatusId = 17
  where PMobNo = @DriverNo
  
  update dbo.PSCurrentLocationStatus
  set [Status] = 17
  where DriverNo = @DriverNo
  
end

select 1 as status
end


GO
/****** Object:  StoredProcedure [dbo].[PSInsUpdVehicleBookingDetails]    Script Date: 29-09-2018 18:28:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[PSInsUpdVehicleBookingDetails]
(
@id int = null
,@BNo varchar(20) = null
           ,@BookedDate date =null
           ,@BookedTime time(7) =null
           ,@DepartureDate date  = null
           ,@DepartureTime time(7) = null 
           ,@BookingType varchar(50)=null 
           ,@Src varchar(50)
           ,@Dest varchar(50)
           ,@SrcId int=null
           ,@DestId int=null
           ,@SrcLatitude numeric(18,6)= null 
           ,@SrcLongitude numeric(18,6) = null
           ,@DestLatitude numeric(18,6) = null
           ,@DestLongitude numeric(18,6) = null
           ,@VechId int =null
           ,@PackageId int = null
           ,@Pricing decimal(10,0) = null
           ,@DriverId int =null
           ,@DriverPhoneNo varchar(20) =null
           ,@CustomerPhoneNo varchar(20) 
           ,@CustomerId int=null 
           ,@BookingStatus varchar(50) =null
           ,@NoofVehicles int=null 
           ,@NoofSeats int =null
           ,@ClosingDate date =null
           ,@ClosingTime time(7)=null 
           ,@CancelledOn datetime =null
           ,@CancelledBy varchar(50)=null 
           ,@BookingChannel varchar(50)= null 
           ,@Reasons varchar(500)= null
           ,@CompanyId int =null
           ,@BooKingOTP varchar(20)=null           
           ,@Amount decimal(18, 0)=null
           ,@PaymentStatus varchar(50)=null
           ,@distance decimal(18,0)=null
           ,@PaymentTypeId int =null
           ,@flag varchar(1) = null
		   ,@withluggage int =null
		   ,@luggageweight int= null
		   ,@VehicleGroupId int =null)
as
begin

begin try

declare @b varchar(5),@selVid int = null
, @selDid int = null, @newBookId int, @driverNo varchar(20),@dt datetime, @m varchar(5),@price varchar(10)

set @dt = getdate()
set @price = '300'

select @b = replace(CONVERT(VARCHAR(1), @dt, 114),':','')+ CONVERT(VARCHAR(3),DATEPART(millisecond,@dt))+5 

if @flag = 'I'
begin


INSERT INTO [dbo].[PSVehicleBookingDetails]
           ([BNo]
           ,[BookedDate]
           ,[BookedTime]
           ,[DepartueDate]
           ,[DepartureTime]
           ,[BookingType]
           ,[Src]
           ,[Dest]
           ,[SrcId]
           ,[DestId]
           ,[SrcLatitude]
           ,[SrcLongitude]
           ,[DestLatitude]
           ,[DestLongitude]
           ,[VechId]
           ,[PackageId]
           ,[Pricing]
           ,[DriverId]
           ,[DriverPhoneNo]
           ,[CustomerPhoneNo]
           ,[CustomerId]
           ,[BookingStatus]
           ,[NoofVehicles]
           ,[NoofSeats]
           ,[ClosingDate]
           ,[ClosingTime]
           ,[CancelledOn]
           ,[CancelledBy]
           ,[BookingChannel]
           ,[CompanyId]
           ,[Reasons]
           ,[BooKingOTP]      
           ,[Amount]
           ,[PaymentStatus]
           ,[Distance]
           ,[PaymentTypeId]
		   ,[VehicleGroupId]
		   ,[WithLuggage]
		   ,[LuggageWeight])
     VALUES
           (@b
           ,@dt
           ,@dt 
           ,@DepartureDate
           ,@DepartureTime 
           ,@BookingType 
           ,@Src 
           ,@Dest 
           ,@SrcId
           ,@DestId 
           ,@SrcLatitude
           ,@SrcLongitude 
           ,@DestLatitude
           ,@DestLongitude 
           ,@VechId
           ,@PackageId
           ,@Pricing 
           ,@DriverId
           ,@DriverPhoneNo
           ,@CustomerPhoneNo 
           ,@CustomerId
           ,@BookingStatus 
           ,@NoofVehicles
           ,@NoofSeats
           ,@ClosingDate
           ,@ClosingTime
           ,@CancelledOn
           ,@CancelledBy 
           ,@BookingChannel 
           ,@Reasons 
           ,@CompanyId
           ,null           
           ,@Amount
           ,@PaymentStatus
           ,@distance
           ,90
		   ,@VehicleGroupId
		   ,@withluggage
		   ,@luggageweight)          
           	     
           
end

  if @flag = 'U' 
  begin
  UPDATE [dbo].[PSVehicleBookingDetails]
   SET 
      [BookedDate] = @BookedDate
      ,[BookedTime] = @BookedTime
      ,[DepartueDate] = @DepartureDate
      ,[DepartureTime] = @DepartureTime
      ,[BookingType] = @BookingType
      ,[Src] = @Src
      ,[Dest] = @Dest
      ,[SrcId] = @SrcId
      ,[DestId] = @DestId
      ,[SrcLatitude] = @SrcLatitude
      ,[SrcLongitude] = @SrcLongitude
      ,[DestLatitude] = @DestLatitude
      ,[DestLongitude] = @DestLongitude
      ,[VechId] = @VechId
      ,[PackageId] = @PackageId
      ,[Pricing] = @Pricing
      ,[DriverId] = @DriverId
      ,[DriverPhoneNo] = @DriverPhoneNo
      ,[CustomerPhoneNo] = @CustomerPhoneNo
      ,[CustomerId] = @CustomerId
      ,[BookingStatus] = @BookingStatus
      ,[NoofVehicles] = @NoofVehicles
      ,[NoofSeats] = @NoofSeats
      ,[ClosingDate] = @ClosingDate
      ,[ClosingTime] = @ClosingTime
      ,[CancelledOn] = @CancelledOn
      ,[CancelledBy] = @CancelledBy
      ,[BookingChannel] = @BookingChannel
      ,[Reasons] = @Reasons
      ,[CompanyId]=@CompanyId      
      ,[Amount] = @Amount
      ,[PaymentStatus] = @PaymentStatus
      ,[Distance] = @distance
 WHERE [BNo]=@BNo



  end
  select @b as bookingNumber,@price as estprice
  end try
begin catch
 DECLARE @ErrorMessage NVARCHAR(4000);  
    DECLARE @ErrorSeverity INT;  
    DECLARE @ErrorState INT;  

    SET @ErrorMessage = ERROR_MESSAGE();  
    SET @ErrorSeverity = ERROR_SEVERITY();  
    SET @ErrorState = ERROR_STATE();  

    -- Use RAISERROR inside the CATCH block to return error		
    -- information about the original error that caused  
    -- execution to jump to the CATCH block.  
    RAISERROR (@ErrorMessage, -- Message text.  
               @ErrorSeverity, -- Severity.  
               @ErrorState -- State.  
               ); 
end catch
end


GO
/****** Object:  StoredProcedure [dbo].[PSMOTPverifying]    Script Date: 29-09-2018 18:28:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[PSMOTPverifying]
@Mobilenumber varchar(20),@Mobileotp varchar(10),@UserId int
as
begin

declare @cnt int

select @cnt = COUNT(*) from Appusers where Mobilenumber = @Mobilenumber and Id = @UserId

if @cnt = 0
begin
  
				RAISERROR ('Invalid mobile number',16,1);
				return;
end
else
begin

  select @cnt = COUNT(*) from Appusers where Mobilenumber = @Mobilenumber and [Mobileotp] = @Mobileotp and Id = @UserId
  if @cnt = 0
	begin
	  
					RAISERROR ('Invalid mobile OTP',16,1);
					return;
	end
  else
  begin
     update Appusers set Mobileotp = null where Mobilenumber = @Mobilenumber and [Mobileotp] = @Mobileotp and Id = @UserId
     select [Mobilenumber],[Username],[StatusId] from Appusers where Mobilenumber = @Mobilenumber
     --select 1
  end
 
end

end


GO
/****** Object:  StoredProcedure [dbo].[PSPasswordverification]    Script Date: 29-09-2018 18:28:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[PSPasswordverification]
@Password varchar(50),@Passwordotp varchar(10),@Email varchar(50), @mobileno varchar(15)
as
begin

declare @otp varchar(10) = null

select @otp = @Passwordotp from Appusers where Mobilenumber = @mobileno and Email = @Email 

if @otp is null
begin
  
				RAISERROR ('Invalid mobile number or email address',16,1);
				return;
end
else
begin

  select @otp = COUNT(*) from Appusers where Mobilenumber = @mobileno and Passwordotp = @Passwordotp
  if @otp = 0
	begin
	  
					RAISERROR ('Invalid mobile OTP',16,1);
					return;
	end
  else
  begin
      update Appusers set Passwordotp  = null,Password = @Password where Mobilenumber = @mobileno and Email = @Email  
     select [Username] ,[Email] ,[Mobilenumber],[Password] from Appusers where Mobilenumber = @mobileno and Email = @Email
  end
 
end
end


GO
/****** Object:  StoredProcedure [dbo].[PSProcessPayment]    Script Date: 29-09-2018 18:28:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[PSProcessPayment]
@BNo varchar(20),@Amount decimal(18,0)
as
begin

update dbo.PSVehicleBookingDetails 
set [PaymentStatus] = 'Paid', Amount = @Amount, UpdatedBy = 0
where BNo = @BNo

end


GO
/****** Object:  StoredProcedure [dbo].[PSTrackVehicleHistory]    Script Date: 29-09-2018 18:28:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[PSTrackVehicleHistory](
@Mobilenumber varchar(50),
@Latitude numeric(10,6),
@Longitude numeric(10,6),
@Status varchar(50) = null)
as
begin
declare @did int = null,@vid int = null,
@lat numeric(10,6) = 0,
@long numeric(10,6) = 0

select top 1 @vid = VId, @did = DId from [PSDriverLogin] 
where DriverNo = @Mobilenumber and (logoutlatitude is null and logoutlongitude is null)


if @did is null or @vid is null 
begin
  RAISERROR ('Driver did not login yet',16,1);
  return
end
  else		
	begin	

		select top 1 @lat = Latitude,@long = longitude from PSTrackVehicle where Mobilenumber = @Mobilenumber 
		order by id desc 

		if @lat <> @Latitude or @long <> @Longitude
		begin
			Insert into PSTrackVehicle(Mobilenumber, Latitude, Longitude, Date, Time,Status) 
			values (@Mobilenumber, @Latitude,@Longitude,convert(date,GETDATE()), CONVERT(time,GETDATE()),@Status)
		end	
			update dbo.PSCurrentLocationStatus set Latitude  = @Latitude, Longitude = @Longitude
			,[Date] = GETDATE(), [Time]= CONVERT(time,GETDATE()) 
			, DriverNo = @Mobilenumber where vid = @vid and did = @did
			
			if @@ROWCOUNT = 0
			begin
			  INSERT INTO [dbo].[PSCurrentLocationStatus]
           ([VId],[DId],[Latitude],[Longitude],[Date],[Time],[Status],[DriverNo])
			VALUES(@vid,@did,@latitude,@longitude,GETDATE(), CONVERT(time,GETDATE()),1,@Mobilenumber)			
		end
    
	END
	
	---check if any trips are there to be accepted and if yes then send the list
	SELECT l.[Id],[BookingId],b.BNo,[Vid],[DriverId],[Date],[Time],[Status],[EXpirationTime]
	, DestLatitude, DestLongitude,SrcLatitude,SrcLongitude
  FROM [dbo].[PSVehicleBookingHistory] l
  inner join [PSVehicleBookingDetails] b on b.Id = [BookingId] and [Status] = 'To be accepted' 
  where vid = @vid 
	
end


GO
/****** Object:  StoredProcedure [dbo].[PSValidateCred]    Script Date: 29-09-2018 18:28:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[PSValidateCred]
@Mobilenumber varchar(20),@Password varchar(50),@CountryId int=null
as
begin

declare @cnt int

select @cnt = COUNT(*) from Appusers where Mobilenumber = @Mobilenumber and Password = @Password 

if @cnt = 0
   begin
  
				RAISERROR ('Invalid Mobilenumber or Password',16,1);
				return;
   end
   
else

begin

  select @cnt = COUNT(*) from Appusers where Mobilenumber = @Mobilenumber and Password = @Password  
  if @cnt = 1
	begin
	
	select
	[Id]
      ,[Username]
      ,[Email]
      ,[Mobilenumber]    
      ,[StatusId]     
      ,[Firstname]
      ,[lastname]
      ,[AuthTypeId]
      from Appusers where Mobilenumber = @Mobilenumber and Password = @Password  		
	
	end 
end
end



GO
