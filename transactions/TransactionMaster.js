var app = angular.module('myApp', ['ngStorage', 'ui.bootstrap', 'angularFileUpload']);

var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage, $uibModal, $upload) {
    if ($localStorage.uname == null) {
        window.location.href = "login.html";
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.Roleid = $scope.userdetails[0].roleid;

    $scope.dashboardDS = $localStorage.dashboardDS;

    $scope.GetTransactionMaster = function () {      

        $http.get('/api/TransactionMaster/GetTransactionMaster').then(function (res, data) {
            $scope.transmaster = res.data;

            for (i = 0; i < $scope.initdata.Table.length; i++) {
                if ($scope.initdata.Table[i].Id == $scope.transmaster[0].PaymentTypeId) {
                    $scope.p = $scope.initdata.Table[i];
                    break;
                }
            }

        });
    }

    $scope.AddChargesDiscounts = function (Addcharges, flag) {


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



        var Addcharges = {

            flag: "I",
            Id: -1,
            Code: Addcharges.Code,
            Title: Addcharges.Title,
            Description: Addcharges.Description,
            cdTypeId: Addcharges.cdType.Id,
            CategoryId: Addcharges.Category.Id,
            ApplyAsId: Addcharges.ApplyAs.Id,
            cdValue: Addcharges.cdValue,
            FromDate: Addcharges.FromDate,
            ToDate: Addcharges.ToDate,
            Active: (Addcharges.Active == true) ? 1 : 0,
        }

        var req = {
            method: 'POST',
            url: '/api/ChargesDiscounts/SaveChargesDiscounts',
            data: Addcharges
        }
        $http(req).then(function (response) {

            alert("Saved successfully!");

            $scope.Addchargesors = null;

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "Your Details Are Incorrect";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            $scope.showDialog(errmssg);
        });
        $scope.currGroup = null;

    }

    $scope.EditChargesDiscounts = function (Editcharges) {


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
            Title: Editcharges.Title,
            Description: Editcharges.Description,
            cdType: Editcharges.cdType.Id,
            Category: Editcharges.Category.Id,
            ApplyAs: Editcharges.ApplyAs.Id,
            cdValue: Editcharges.cdValue,
            FromDate: Editcharges.FromDate,
            ToDate: Editcharges.ToDate,



            Active: (Editcharges.Active == true) ? 1 : 0,
        }

        var req = {
            method: 'POST',
            url: '/api/SaveChargesDiscounts',
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
            includePaymentType: '1',            
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