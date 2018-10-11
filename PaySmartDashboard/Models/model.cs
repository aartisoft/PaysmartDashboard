using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaySmartDashboard.Models
{
    public class UserLogin
    {
        public int Id { set; get; }
        public int UserId { set; get; }
        public string LoginInfo { set; get; }
        public string Passkey { set; get; }
        public string Salt { set; get; }
        public string Active { set; get; }

    }
    public class allocatedriver
    {
        public string flag { get; set; }
        public int Id { get; set; }


        public int CompanyId { get; set; }
        public int BookingNo { get; set; }

        public string CustomerName { get; set; }
        public string CusID { get; set; }
        public string PhoneNo { get; set; }
        public string AltPhoneNo { get; set; }
        public string Address { get; set; }
        public string PickupAddress { get; set; }
        public string LandMark { get; set; }
        public string PickupPlace { get; set; }
        public string DropPlace { get; set; }
        public string Package { get; set; }
        public string VehicleType { get; set; }
        public int NoofVehicle { get; set; }
        public int VechID { get; set; }
        public string RegistrationNo { get; set; }
        public string DriverName { get; set; }
        public int DriverId { get; set; }
        public string PresentDriverLandMark { get; set; }
        public string ExecutiveName { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime EffectiveTill { get; set; }
        public string VehicleModelId { get; set; }
        public string ServiceTypeId { get; set; }
        public string VehicleGroupId { get; set; }
    }
    public class VehicleDocuments
    {

        public int Id { get; set; }
        public int VehicleId { get; set; }
        public int createdById { get; set; }
        public int UpdatedById { get; set; }
        public int docTypeId { get; set; }
        public string docType { get; set; }
        public string FileName { get; set; }
        public int IsExpired { get; set; }
        public string FileContent { get; set; }
        public DateTime? expiryDate { get; set; }
        public DateTime? dueDate { get; set; }
        public string insupddelflag { get; set; }
        public string DocumentNo { get; set; }
        public string DocumentNo2 { get; set; }
        public int isVerified { get; set; }
        public int IsApproved { get; set; }
        public int DriverId { get; set; }

    }

    public class DriverDocuments
    {

        public int Id { get; set; }
        public int DriverId { get; set; }
        public int createdById { get; set; }
        public int UpdatedById { get; set; }

        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }

        public int docTypeId { get; set; }
        public string docType { get; set; }
        public string docName { get; set; }
        public int IsExpired { get; set; }
        public string docContent { get; set; }

        public DateTime? expiryDate { get; set; }
        public DateTime? dueDate { get; set; }
        public string insupddelflag { get; set; }
        public string DocumentNo { get; set; }
        public string DocumentNo2 { get; set; }
        public int isVerified { get; set; }
        public int IsApproved { get; set; }
    }
    public class vehiclemas
    {
        public string flag { get; set; }
        public int Id { get; set; }
        public int VID { get; set; }
        public int CompanyId { get; set; }
        public int OwnerId { get; set; }
        public int VehicleTypeId { get; set; }
        public string RegistrationNo { get; set; }
        public int HasAC { get; set; }
        public int StatusId { get; set; }
        public int IsVerified { get; set; }
        public string VehicleCode { get; set; }
        public string Type { get; set; }
        public string OwnerName { get; set; }
        public string ChasisNo { get; set; }
        public string Engineno { get; set; }
        public float RoadNo { get; set; }
        public DateTime RoadTaxDate { get; set; }
        public string InsuranceNo { get; set; }
        public DateTime InsDate { get; set; }
        public string PolutionNo { get; set; }
        public DateTime PolExpDate { get; set; }
        public string RCBookNo { get; set; }
        public DateTime RCExpDate { get; set; }
        public int CompanyVechile { get; set; }
        public string OwnerPhoneNo { get; set; }
        public string HomeLandmark { get; set; }
        public string ModelYear { get; set; }
        public string DayOnly { get; set; }
        public string VechMobileNo { get; set; }
        public DateTime EntryDate { get; set; }
        public string NewEntry { get; set; }
        public int VehicleModelId { get; set; }
        public int ServiceTypeId { get; set; }
        public int VehicleGroupId { get; set; }
        public string photo { get; set; }
        public string Status { get; set; }
        public string Fleetcode { get; set; }
        public int isDriverOwned { get; set; }
        public int VehicleMakeId { get; set; }
        public string Photo { get; set; }
        public int CountryId { get; set; }
        public string FrontImage { get; set; }
        public string BackImage { get; set; }
        public string RightImage { get; set; }
        public string LeftImage { get; set; }
    }
    public class VehicleConfig
    {
        public int? needFleetDetails { get; set; }
        public int? needRoutes { get; set; }
        public int? needRoles { get; set; }
        public int? needusers { get; set; }
        public int? needfleetowners { get; set; }
        public int? needvehicleType { get; set; }
        public int? needvehicleRegno { get; set; }
        public int? needServiceType { get; set; }
        public int? needCompanyName { get; set; }
        public int? needVehicleLayout { get; set; }
        public int? needFleetRoute { get; set; }
        public int? needRouteName { get; set; }
        public int? needHireVehicle { get; set; }
        public int? needbtpos { get; set; }
        public int? cmpId { get; set; }
        public int? fleetownerId { get; set; }
        public int? needfleetownerroutes { get; set; }
        public int? needvehicleMake { get; set; }
        public int? needVehicleGroup { get; set; }

        public int? needDocuments { get; set; }


    }
    public class Approvals
    {
        public string change { get; set; }
        public int IsApproved { get; set; }
        public int DId { get; set; }
        public string RegistrationNo { get; set; }
        public string MobileNo { get; set; }
        public int VID { get; set; }
    }
    public class ChargesDiscounts
    {
        public string Type;
        public string Value;

        public int Id { get; set; }

        public string Code { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
        public int cdTypeId { get; set; }
        public int CategoryId { get; set; }

        public int ApplyAsId { get; set; }

        public string cdType { get; set; }
        public string Category { get; set; }

        public string ApplyAs { get; set; }
        public decimal cdValue { get; set; }
        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public string Flag { get; set; }
    }
    public class Country
    {
        //Id, Name, Latitude, Longitude,ISOCode, HasOperations
        public int Id { get; set; }
        public string Name { get; set; }
        public string ISOCode { get; set; }
        public string HasOperations { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }


        public string Flag { get; set; }

        public string Code { get; set; }

        public string flg { get; set; }
    }
    public class Promotionaldisc
    {
        public string flag { get; set; }
        public int Id { get; set; }
        public int OpCode { get; set; }
        public string Condition { get; set; }
        public int ValueType { get; set; }
        public int FromValue { get; set; }
        public string ToValue { get; set; }
        public int TypeId { get; set; }
        public int ApplyOn { get; set; }
        public int Value { get; set; }
        public int Applicability { get; set; }
        public string Code { get; set; }
    }
    public class CompanyGroups
    {
        public CompanyGroups[] m = null;
        //public List<CompanyGroups> list { get; set; }
        public int active { get; set; }

        public string admin { get; set; }

        public int adminId { get; set; }

        public string code { get; set; }

        public string desc { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }
        public string ContactNo1 { get; set; }
        public string ContactNo2 { get; set; }
        public string Fax { get; set; }
        public string EmailId { get; set; }
        public string Title { get; set; }
        public string Caption { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string State { get; set; }

        public int FleetSize { get; set; }
        public int StaffSize { get; set; }
        public string AlternateAddress { get; set; }
        //public string TemporaryAddress{get;set;} 
        public string Logo { get; set; }

        public string insupdflag { get; set; }

    }


    //Jagan Updated On18th Aug Start
    public class DriversGroups
    {

        public DriversGroups[] p = null;
        //public List<DriversGroups> list { get; set; }
        public string flag { get; set; }
        public int DId { get; set; }
        public string CompanyId { get; set; }
        public string NAme { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Pin { get; set; }
        public string PAddress { get; set; }
        public string PCity { get; set; }
        public string PPin { get; set; }
        public string OffMobileNo { get; set; }
        public string PMobNo { get; set; }
        public DateTime? DOB { get; set; }
        public DateTime? DOJ { get; set; }
        public string BloodGroup { get; set; }
        public string LicenceNo { get; set; }
        public DateTime? LiCExpDate { get; set; }
        public string BadgeNo { get; set; }
        public DateTime? BadgeExpDate { get; set; }
        public string Remarks { get; set; }
        public string VehicleModelId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNumber { get; set; }
        public string PermanentAddress { get; set; }
        public string PermanentPin { get; set; }
        public string EmailId { get; set; }
        public string DriverCode { get; set; }
        public string FleetOwner { get; set; }
        public int CurrentStateId { get; set; }
        public string Country { get; set; }

    }
    //Jagan Updated On18th Aug End

    public class VehiclesGroups
    {

        public VehiclesGroups[] o = null;
        //public List<VehiclesGroups> list3 { get; set; }
        public string flag { get; set; }
        public int Id { get; set; }
        public string CompanyId { get; set; }
        public int VID { get; set; }
        public int Company { get; set; }
        public string RegistrationNo { get; set; }
        public string vehicleType { get; set; }
        public int FleetOwner { get; set; }
        public string ChasisNo { get; set; }
        public string Engineno { get; set; }
        public DateTime? RoadTaxDate { get; set; }
        public int HasAC { get; set; }
        public DateTime? InsDate { get; set; }
        public string PolutionNo { get; set; }
        public DateTime? PolExpDate { get; set; }
        public string RCBookNo { get; set; }
        public DateTime? RCExpDate { get; set; }
        public string StatusId { get; set; }
        public int IsVerified { get; set; }
        public string VehicleCode { get; set; }
        public string ModelYear { get; set; }
        public int IsDriverowned { get; set; }
        public int DriverId { get; set; }
        public DateTime? EntryDate { get; set; }
        public string Country { get; set; }
        public string VehicleModel { get; set; }
        public string VehicleMake { get; set; }
        public string VehicleGroup { get; set; }
        public string LayoutType { get; set; }
    }
    public class faqs
    {

        public string flag { get; set; }
        public int Id { get; set; }
        public string Question { get; set; }

        public string Answer { get; set; }
        public string CreatedBy { get; set; }
        public int AppType { get; set; }
        public int Category { get; set; }
        public int SubCategory { get; set; }
        public int active { get; set; }
        public int category { get; set; }

    }
    public class TypeGroups
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Active { get; set; }
        public string insupddelflag { get; set; }
    }

    public class Types
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Active { get; set; }



        public string TypeGroupId { get; set; }

        public string ListKey { get; set; }

        public string Listvalue { get; set; }
        public string insupddelflag { get; set; }
    }
    public class PackageCharges
    {
        public string flag { get; set; }
        public int Id { get; set; }
        public int PackageId { get; set; }
        public int TypeId { get; set; }
        public int ApplyOn { get; set; }
        public int Value { get; set; }
        public string Code { get; set; }
        public int UnitTypeId { get; set; }
        public int UnitId { get; set; }
        public int FromValue { get; set; }
        public int ToValue { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public int ChargeTypeId { get; set; }
        public string ChargeCode { get; set; }
    }
    public class PackageDiscount
    {
        public string flag { get; set; }
        public int Id { get; set; }
        public int PackageId { get; set; }
        public int TypeId { get; set; }
        public int ApplyOn { get; set; }
        public int Value { get; set; }
        public string Code { get; set; }
        public int UnitTypeId { get; set; }
        public int UnitId { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public int DiscountTypeId { get; set; }

    }
    public class UsersGroup
    {

        //public UsersGroup[] U = null;
        public List<UsersGroup> U { get; set; }
        public int Id { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string MiddleName { set; get; }
        public string EmpNo { set; get; }
        public string Email { set; get; }
        public string ContactNo1 { set; get; }
        public string ContactNo2 { set; get; }
        public int? mgrId { set; get; }
        public int ManagerName { set; get; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string State { get; set; }
        public int StateId { set; get; }
        public int CountryId { set; get; }
        public int Active { get; set; }
        public int GenderId { get; set; }
        public string UserType { set; get; }
        public int UserTypeId { set; get; }
        public string Address { set; get; }
        public string AltAdress { set; get; }
        public string Photo { get; set; }
        public string Role { set; get; }
        public int RoleId { set; get; }
        public DateTime? RFromDate { get; set; }
        public DateTime? RToDate { get; set; }
        public string DUserName { get; set; }
        public string DPassword { get; set; }
        public string WUserName { get; set; }
        public string WPassword { get; set; }
        public string insupdflag { get; set; }
        public int cmpId { set; get; }
        public string Company { set; get; }

    }
    public class CardsGroup
    {

        public CardsGroup[] cg = null;
        //public List<VehiclesGroups> list3 { get; set; }
        public int Id { get; set; }
        public string CardNumber { get; set; }
        public string CardModel { get; set; }
        public string CardType { get; set; }
        public string CardCategory { get; set; }
        public int Status { get; set; }
        public int UserId { get; set; }
        public string Customer { get; set; }
        public DateTime? EffectiveFrom { get; set; }
        public DateTime? EffectiveTo { get; set; }
        public string insupdflag { get; set; }
    }

    public class DriverVehicleAssignGroup
    {
        public DriverVehicleAssignGroup[] dva = null;
        public string inspudflag { get; set; }
        public string RegistrationNo { get; set; }
        public string vehicleType { get; set; }
        public int FleetOwner { get; set; }
        public string ChasisNo { get; set; }
        public string Engineno { get; set; }
        public int HasAC { get; set; }
        public string StatusId { get; set; }
        public int IsVerified { get; set; }
        public string VehicleCode { get; set; }
        public string ModelYear { get; set; }
        public int IsDriverowned { get; set; }
        public int DriverId { get; set; }
        public DateTime? EntryDate { get; set; }
        public string Country { get; set; }
        public string VehicleModel { get; set; }
        public string VehicleMake { get; set; }
        public string VehicleGroup { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public DateTime? EffectiveTill { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNumber { get; set; }
        public string PermanentAddress { get; set; }
        public string PermanentPin { get; set; }
        public string EmailId { get; set; }
        public string DriverCode { get; set; }
        public string Address { get; set; }
        public string Pin { get; set; }
        public int CurrentStateId { get; set; }
        public string LayoutType { get; set; }
        public string Company { get;set;}

    }
    public class driverdetails
    {
        public string flag { get; set; }
        public int DId { get; set; }
        public int Country { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Pin { get; set; }
        public string PermanentAddress { get; set; }
        public string PCity { get; set; }
        public string PermanentPin { get; set; }
        public float OffMobileNo { get; set; }
        public string Mobilenumber { get; set; }
        public DateTime? DOB { get; set; }
        public DateTime? DOJ { get; set; }
        public string BloodGroup { get; set; }
        public string LicenceNo { get; set; }
        public DateTime LiCExpDate { get; set; }
        public string BadgeNo { get; set; }
        public DateTime BadgeExpDate { get; set; }
        public string Remarks { get; set; }
        public string Photo { get; set; }
        public string licenseimage { get; set; }
        public string badgeimage { get; set; }
        public string drivercode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public int Status { get; set; }
        public int VehicleGroup { get; set; }
        public int IsVerified { get; set; }
        public int IsApproved { get; set; }
        public int CurrentStateId { get; set; }

        public int PaymentTypeId { get; set; }
    }
    public class bankdetails
    {
        public string flag { get; set; }
        public int Id { get; set; }
        public string Accountnumber { get; set; }
        public string BankName { get; set; }
        public string BranchAddress { get; set; }
        public string Bankcode { get; set; }
        public string Country { get; set; }
        public int IsActive { get; set; }
        public int DriverId { get; set; }
        public string DriverCode { get; set; }
        public string qrcode { get; set; }
    }
    public class ConfigData
    {
        public int includeStatus { get; set; }
        public int includeCategories { get; set; }
        public int includeLicenseCategories { get; set; }
        public int includeVehicleGroup { get; set; }
        public int includeGender { get; set; }
        public int includeFrequency { get; set; }
        public int includePricingType { get; set; }
        public int includeTransactionType { get; set; }
        public int includeApplicability { get; set; }
        public int includeFeeCategory { get; set; }
        public int includeTransChargeType { get; set; }
        public int includeVehicleType { get; set; }
        public int includeVehicleModel { get; set; }
        public int includeVehicleMake { get; set; }
        public int includeDocumentType { get; set; }
        public int includePaymentType { get; set; }
        public int includeMiscellaneousTypes { get; set; }
        public int includeCardCategories { get; set; }
        public int includeCardTypes { get; set; }
        public int includeVehicleLayoutType { get; set; }
        public int includeLicenseFeatures { get; set; }
        public int includeCardModels { get; set; }
        public int includeCards { get; set; }
        public int includeTransactions { get; set; }
        public int includeCountry { get; set; }
        public int includeActiveCountry { get; set; }
        public int includeFleetOwner { get; set; }
        public int includeUserType { get; set; }
        public int includeAuthType { get; set; }
        public int includeState { get; set; }

        public int includePackageNames { get; set; }

        public int includePackageTypeName { get; set; }
    }
    public class MandUserDocs
    {
        public int VehicleGroupId { get; set; }
        public string flag { get; set; }

        public int Id { get; set; }

        public int DocTypeId { get; set; }

        public int Countryid { get; set; }

        public int UserTypeId { get; set; }

        public string FileContent { get; set; }

        public int IsMandatory { get; set; }
    }

    public class MandVehicleDocs
    {

        public string flag { get; set; }

        public int Id { get; set; }

        public int Countryid { get; set; }

        public int VehicleGroupId { get; set; }

        public int DocTypeId { get; set; }
        public string FileContent { get; set; }
        public int IsMandatory { get; set; }
    }
    public class UserAccount
    {
        public string flag { get; set; }
        public int id { get; set; }
        public int userId { get; set; }
        public string Username { get; set; }

        public string Email { get; set; }
        public string Mobilenumber { get; set; }
        public string Password { get; set; }
        public String EVerificationCode { get; set; }
        public DateTime EVerifiedOn { get; set; }
        public int IsEmailVerified { get; set; }
        public String MVerificationCode { get; set; }
        public string Passwordotp { get; set; }
        public DateTime MVerifiedOn { get; set; }
        public int IsMobileVerified { get; set; }

        public DateTime CreatedOn { get; set; }
        public int ENoOfAttempts { get; set; }
        public int MNoOfAttempts { get; set; }
        public string Firstname { get; set; }
        public string lastname { get; set; }
        public int AuthTypeId { get; set; }
        public string AltPhonenumber { get; set; }
        public string Altemail { get; set; }
        public string AccountNo { get; set; }
        public string NewPassword { get; set; }
        public object Mobileotp { get; set; }

        public object Emailotp { get; set; }

        public int Gender { get; set; }
        public string UserPhoto { get; set; }

        public decimal Amount { get; set; }
        public int CountryId { get; set; }
        public int PaymentModeId { get; set; }
        public int CurrentStateId { get; set; }
        public int Active { get; set; }
        public string CCode { get; set; }
        public string UserAccountNo { get; set; }

    }
    public class DemoRequest
    {
        public string flag { get; set; }
        public int Id { get; set; }
        public string Businessname { get; set; }
        public string email { get; set; }
        public string mobile { get; set; }
        public int countryid { get; set; }
        public string LoginNo { get; set; }
        public string Reviewed { get; set; }
        public string notification { get; set; }
        public int statusid { get; set; }

    }
    public class UserLocation
    {
        public string flag { get; set; }

        public int BNo { get; set; }
        public string BookingType { get; set; }

        public string ReqVehicle { get; set; }
        public string Customername { get; set; }
        public string CusID { get; set; }
        public string PhoneNo { get; set; }
        public string AltPhoneNo { get; set; }
        public string CAddress { get; set; }
        public string PickupAddress { get; set; }
        public string LandMark { get; set; }
        public string Package { get; set; }
        public string PickupPalce { get; set; }
        public string DropPalce { get; set; }
        public string ReqType { get; set; }
        public int ExtraCharge { get; set; }
        public int NoofVehicle { get; set; }
        public string ExecutiveName { get; set; }
        public int VID { get; set; }
        public string BookingStatus { get; set; }
        public string CustomerSMS { get; set; }
        public string CancelReason { get; set; }
        public decimal CBNo { get; set; }
        public string ModifiedBy { get; set; }
        public string CancelBy { get; set; }
        public string ReconfirmedBy { get; set; }
        public string AssignedBy { get; set; }

        public float lat { get; set; }
        public float lng { get; set; }

        public object Mobileotp { get; set; }
    }
    public class stops
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public int Active { get; set; }
        public float latitude { get; set; }
        public float longitude { get; set; }
        public string insupdflag { get; set; }
        public string srcLat { get; set; }
        public string srcLon { get; set; }
    }
    public class LicenseTypes
    {
        public int Id { set; get; }
        public string LicenseType { set; get; }
        public string LicenseCode { set; get; }
        public int LicenseCategoryId { set; get; }
        public int Active { set; get; }
        public string Desc { set; get; }
        public string LicenseCategory { set; get; }
        public DateTime? fromDate { get; set; }
        public DateTime? toDate { get; set; }
        public int LicenseId { get; set; }
        public int LicensePricingId { get; set; }
        public String RenewalFreqType { get; set; }
        public int RenewalFreqTypeId { get; set; }
        public int RenewalFreqUnit { get; set; }
        public string RenewalFreq { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime? Pfromdate { get; set; }
        public DateTime? Ptodate { get; set; }

        public int PActive { get; set; }
        public string insupddelflag { get; set; }

        //license pos      
        public int LPOSId { get; set; }
        public int BTPOSTypeId { get; set; }
        public int NoOfUnits { get; set; }
        public string POSType { get; set; }
        public String POSLabel { get; set; }
        public String POSLabelClass { get; set; }
        public DateTime? POSfromdate { get; set; }
        public DateTime? POStodate { get; set; }
        public int POSActive { get; set; }
      
    }
    public class LicensePricing
    {
        public int LicenseId { get; set; }
        public String RenewalFreqType { get; set; }
        public int RenewalFreqTypeId { get; set; }
        public int RenewalFreqUnit { get; set; }
        public string RenewalFreq { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime? fromdate { get; set; }
        public DateTime? todate { get; set; }
        public int Id { get; set; }

        public int categoryid { get; set; }
        public int Active { get; set; }
        public string insupddelflag { get; set; }
    }
    public class FleetOwnerRequest
    {
        //user details

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string PhoneNo { get; set; }
        public string AltPhoneNo { get; set; }
        public string EmailAddress { get; set; }
        public string Address { get; set; }
        public int Gender { set; get; }

        public string userPhoto { get; set; }

        //Company details
        public string CompanyName { get; set; }
        public string CmpEmailAddress { get; set; }
        public string CmpTitle { get; set; }
        public string CmpCaption { get; set; }
        public string FleetSize { set; get; }
        public int StaffSize { get; set; }
        public string Country { get; set; }
        public string Code { get; set; }
        public string CmpFax { get; set; }
        public string CmpAddress { get; set; }
        public string CmpAltAddress { get; set; }
        public string state { get; set; }
        public string ZipCode { get; set; }
        public string CmpPhoneNo { set; get; }
        public string CmpAltPhoneNo { set; get; }
        public string CurrentSystemInUse { set; get; }
        public string howdidyouhearaboutus { get; set; }
        public string SendNewProductsEmails { set; get; }
        public int Agreetotermsandconditions { get; set; }


        public string CmpLogo { get; set; }

        public string insupdflag { get; set; }
    }
    public class ULLicense
    {
        public int Id { set; get; }
        public int ULId { set; get; }
        public string TransId { set; get; }
        public DateTime? CreatedOn { set; get; }
        public decimal Amount { set; get; }
        public decimal UnitPrice { set; get; }
        public decimal Units { set; get; }
        public int StatusId { set; get; }
        public int LicensePymtTransId { set; get; }
        public int IsRenewal { set; get; }
        public string insupddelflag { set; get; }
    }
}