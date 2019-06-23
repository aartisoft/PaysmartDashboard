var app = angular.module('myApp', ['ngStorage', 'ui.bootstrap', 'angularFileUpload']);

var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage, $uibModal, $upload) {
    if ($localStorage.uname == null) {
        window.location.href = "login.html";
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.Roleid = $scope.userdetails[0].roleid;

    $scope.dashboardDS = $localStorage.dashboardDS;

    $scope.GetPackages = function () {
        $http.get('/api/Packages/GetPackages').then(function (res, data) {
            $scope.package = res.data;
        });
    }

    $scope.GetPackageCharges = function () {
        $http.get('/api/ChargesDiscounts/GetPackageCharges').then(function (res, data) {
            $scope.Charge = res.data;

            //for (i = 0; i < $scope.package.length; i++) {
            //    if ($scope.package[i].Id == $scope.Charge.TypeId) {
            //        $scope.pp = $scope.package[i];
            //        break;
            //    }
            //}

            //for (i = 0; i < $scope.initdata.Table.length; i++) {
            //    if ($scope.initdata.Table[i].Id == $scope.Charge.ApplyOn) {
            //        $scope.ApplyOn = $scope.initdata.Table[i];
            //        break;
            //    }
            //}          

            //for (i = 0; i < $scope.initdata.Table1.length; i++) {
            //    if ($scope.initdata.Table1[i].Id == $scope.Charge.ChargeTypeId) {
            //        $scope.chargetype = $scope.initdata.Table1[i];
            //        break;
            //    }
            //}
            //for (i = 0; i < $scope.initdata.Table2.length; i++) {
            //    if ($scope.initdata.Table2[i].Id == $scope.Charge.TypeId) {
            //        $scope.pp = $scope.initdata.Table2[i];
            //        break;
            //    }
            //}
            //for (i = 0; i < $scope.initdata.Table3.length; i++) {
            //    if ($scope.initdata.Table3[i].Id == $scope.Charge.UnitTypeId) {
            //        $scope.UnitType = $scope.initdata.Table3[i];
            //        break;
            //    }
            //}
            //for (i = 0; i < $scope.initdata.Table4.length; i++) {
            //    if ($scope.initdata.Table4[i].Id == $scope.Charge.UnitId) {
            //        $scope.Unit = $scope.initdata.Table4[i];
            //        break;
            //    }
            //}


        });
    }    

    $scope.SaveNew = function (charges, flag) {

        if (charges == null) {
            alert('Please Enter Name');
            return;
        }
        if (charges.Code == null) {
            alert('Please Enter Code');
            return;
        }
        if ($scope.p == null || $scope.p.Id == null) {
            alert('Please Enter Package');
            return;
        }
        if ($scope.t == null || $scope.t.Id == null) {
            alert('Please Enter Type');
            return;
        }
        if ($scope.ApplyOn == null || $scope.ApplyOn.Id == null) {
            alert('Please Enter Apply On');
            return;
        }        
        if ($scope.u == null || $scope.u.Id == null) {
            alert('Please Enter Unit');
            return;
        }
        if ($scope.ut == null || $scope.ut.Id == null) {
            alert('Please Enter Unit Type');
            return;
        }       
        if ($scope.c == null || $scope.c.Id == null) {
            alert('Please Enter Charge Type');
            return;
        }
        if (charges.ChargeCode == null) {
            alert('Please Enter Charge Code');
            return;
        }
        if (charges.FromValue == null) {
            alert('Please Enter From Value');
            return;
        }
        if (charges.ToValue == null) {
            alert('Please Enter To Value');
            return;
        }
        if (charges.EffectiveDate == null) {
            alert('Please Enter Effective Date');
            return;
        }
        if (charges.ExpiryDate == null) {
            alert('Please Enter Expiry Date');
            return;
        }
        if (charges.Value == null) {
            alert('Please Enter Value');
            return;
        }
       
      
        var Addcharges = {

            flag: "I",
            Id: -1,
            Code: charges.Code,
            PackageId: $scope.p.Id,
            TypeId: $scope.t.Id,
            ApplyOn: $scope.ApplyOn.Id,
            Value: charges.Value,
            UnitTypeId: $scope.ut.Id,
            UnitId: $scope.u.Id,
            FromValue: charges.FromValue,
            ToValue: charges.ToValue,
            EffectiveDate: charges.EffectiveDate,
            ExpiryDate: charges.ExpiryDate,
            ChargeTypeId: $scope.c.Id,
            ChargeCode: charges.ChargeCode
            
        }

        var req = {
            method: 'POST',
            url: '/api/ChargesDiscounts/SavePackageCharges',
            data: Addcharges
        }
        $http(req).then(function (response) {

            alert("Saved successfully!");            
            $scope.GetPackageCharges();

            $scope.Addchargesors = null;

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "Your Details Are Incorrect";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            $scope.showDialog(errmssg);
        });
        $scope.currGroup = null;

    }

    $scope.Save = function (Editcharges) {


        //if (Addcharges == null) {
        //    alert('Please Enter Name');
        //    return;
        //}
        //if (Addcharges.EntryDate == null) {
        //    alert('Please Enter EntryDate');
        //    return;
        //}
        //if (Addcharges.VechID == null) {
        //    alert('Please Enter VechID');
        //    return;
        //}
        //if (Addcharges.RegistrationNo == null) {
        //    alert('Please Enter RegistrationNo');
        //    return;
        //}
        //if (Addcharges.DriverName == null) {
        //    alert('Please Enter DriverName');
        //    return;
        //}
        //if (Addcharges.PartyName == null) {
        //    alert('Please Enter PartyName');
        //    return;
        //}
        //if (Addcharges.PickupPlace == null) {
        //    alert('Please Enter PickupPlace');
        //    return;
        //}
        //if (Addcharges.DropPlace == null) {
        //    alert('Please Enter DropPlace');
        //    return;
        //}
        //if (Addcharges.StartMeter == null) {
        //    alert('Please Enter StartMeter');
        //    return;
        //}
        //if (Addcharges.EndMeter == null) {
        //    alert('Please Enter EndMeter');
        //    return;
        //}
        //if (Addcharges.OtherExp == null) {
        //    alert('Please Enter OtherExp');
        //    return;
        //}
        //if (Addcharges.GeneratedAmount == null) {
        //    alert('Please Enter GeneratedAmount');
        //    return;
        //}
        //if (Addcharges.ActualAmount == null) {
        //    alert('Please Enter ActualAmount');
        //    return;
        //}

        //if (Addcharges.ExecutiveName == null) {
        //    alert('Please Enter ExecutiveName');
        //    return;
        //}
        //if (Addcharges.BNo == null) {
        //    alert('Please Enter BNo');
        //    return;
        //}
        //if (Addcharges.DropTime == null) {
        //    alert('Please Enter DropTime');
        //    return;
        //}
        //if (Addcharges.PickupTime == null) {
        //    alert('Please Enter PickupTime');
        //    return;
        //}
        //if (Addcharges.EntryTime == null) {
        //    alert('Please Enter EntryTime');
        //    return;
        //}       

        var Editcharges = {

            flag: "U",
            Id: Editcharges.Id,
            Code: Editcharges.Code,
            PackageId: $scope.pp.Id,
            TypeId: $scope.TypeId.Id,
            ApplyOn: $scope.ApplyOn.Id,
            Value: Editcharges.Value,
            UnitTypeId: $scope.UnitType.Id,
            UnitId: $scope.Unit.Id,
            FromValue: Editcharges.FromValue,
            ToValue: Editcharges.ToValue,
            EffectiveDate: Editcharges.EffectiveDate,
            ExpiryDate: Editcharges.ExpiryDate,
            ChargeTypeId: $scope.chargetype.Id,
            ChargeCode: Editcharges.ChargeCode



           
        }

        var req = {
            method: 'POST',
            url: '/api/ChargesDiscounts/SavePackageCharges',
            data: Editcharges
        }
        $http(req).then(function (response) {

            alert("Updated successfully!");

            $scope.Editcharges = null;

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "Your Details Are Incorrect";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            $scope.showDialog(errmssg);
        });

        $scope.currGroup = null;

    }


    $scope.DeleteCharge = function (cd, flag) {
        var val = {
            flag: 'D',

            Id: cd.Id,
            Code: cd.Code,
            Title: cd.Title,
            Description: cd.Description,
            cdType: cd.cdType.Id,
            Category: cd.Category.Id,
            ApplyAs: cd.ApplyAs.Id,
            cdValue: cd.cdValue,
            FromDate: cd.FromDate,
            ToDate: cd.ToDate,
            Active: (cd.Active == true) ? 1 : 0,
        }
        var req = {
            method: 'POST',
            url: '/api/SaveChargesDiscounts',
            data: val
        }
        $http(req).then(function (response) {

            alert("Deleted successfully!");

            $scope.currGroup = null;

        });
    };

    $scope.setCharges = function (cd) {
        $scope.Editcharges = cd;
    };

    $scope.GetConfigData = function () {

        var vc = {
            includeApplicability: '1',
            includeApplicabilityType: '1',
            includeUnitType: '1',
            includeUnit: '1',
            includeFeeCategory:'1',
        };

        var req = {
            method: 'POST',
            url: '/api/Types/ConfigData',
            data: vc
        }

        $http(req).then(function (res) {
            $scope.initdata = res.data;            
        });
    }
});