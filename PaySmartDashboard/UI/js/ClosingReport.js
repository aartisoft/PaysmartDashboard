
var app = angular.module('myApp', ['ngStorage', 'ui.bootstrap'])
var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage, $uibModal) {
    if ($localStorage.uname == null) {
        window.location.href = "login.html";
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.Roleid = $scope.userdetails[0].roleid;

    $scope.dashboardDS = $localStorage.dashboardDS;

    //$scope.GetReports = function () {
    //    $http.get('/api/ClosingReport/GetReports').then(function (res, data) {
    //        $scope.reportors = res.data;
    //    });
    //}

    $scope.GetReports = function () {
        $http.get('/api/ClosingReport/GetReports').then(function (res, data) {
            $scope.reportors = res.data;

        });
    }


    $scope.saveNew = function (report) {
        if (report == null) {
            alert('Please Enter Name');
            return;
        }       
        if (report.EntryDate == null) {
            alert('Please Enter EntryDate');
            return;
        }
        if (report.VechID == null) {
            alert('Please Enter VechID');
            return;
        }
        if (report.RegistrationNo == null) {
            alert('Please Enter RegistrationNo');
            return;
        }
        if (report.DriverName == null) {
            alert('Please Enter DriverName');
            return;
        }
        if (report.PartyName == null) {
            alert('Please Enter PartyName');
            return;
        }
        if (report.PickupPlace == null) {
            alert('Please Enter PickupPlace');
            return;
        }
        if (report.DropPlace == null) {
            alert('Please Enter DropPlace');
            return;
        }
        if (report.StartMeter == null) {
            alert('Please Enter StartMeter');
            return;
        }
        if (report.EndMeter == null) {
            alert('Please Enter EndMeter');
            return;
        }
        if (report.OtherExp == null) {
            alert('Please Enter OtherExp');
            return;
        }
        if (report.GeneratedAmount == null) {
            alert('Please Enter GeneratedAmount');
            return;
        }
        if (report.ActualAmount == null) {
            alert('Please Enter ActualAmount');
            return;
        }

        if (report.ExecutiveName == null) {
            alert('Please Enter ExecutiveName');
            return;
        }
        if (report.BNo == null) {
            alert('Please Enter BNo');
            return;
        }
        if (report.DropTime == null) {
            alert('Please Enter DropTime');
            return;
        }
        if (report.PickupTime == null) {
            alert('Please Enter PickupTime');
            return;
        }
        if (report.EntryTime == null) {
            alert('Please Enter EntryTime');
            return;
        }



        var report = {

            flag: "I",
            SlNo: report.SlNo,
            EntryDate: report.EntryDate,
            VechID: report.VechID,
            RegistrationNo: report.RegistrationNo,
            DriverName: report.DriverName,
            PartyName: report.PartyName,
            PickupPlace: report.PickupPlace,
            DropPlace: report.DropPlace,
            StartMeter: report.StartMeter,
            EndMeter: report.EndMeter,
            OtherExp: report.OtherExp,
            GeneratedAmount: report.GeneratedAmount,
            ActualAmount: report.ActualAmount,
            ExecutiveName: report.ExecutiveName,
            BNo: report.BNo,
            DropTime: report.DropTime,
            PickupTime: report.PickupTime,
            EntryTime: report.EntryTime,


            Active: (report.Active == true) ? 1 : 0,
        }

        var req = {
            method: 'POST',
            url: '/api/ClosingReport/closerprt',
            data: report
        }
        $http(req).then(function (response) {

            alert("Saved successfully!");

            $scope.reportors = null;

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "Your Details Are Incorrect";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            $scope.showDialog(errmssg);
        });
        $scope.currGroup = null;
    };

    $scope.reportors = null;


    $scope.save = function (report, flag) {
        if (report == null) {
            alert('Please Enter Name');
            return;
        }       
        if (report.EntryDate == null) {
            alert('Please Enter EntryDate');
            return;
        }
        if (report.VechID == null) {
            alert('Please Enter VechID');
            return;
        }
        if (report.RegistrationNo == null) {
            alert('Please Enter RegistrationNo');
            return;
        }
        if (report.DriverName == null) {
            alert('Please Enter DriverName');
            return;
        }
        if (report.PartyName == null) {
            alert('Please Enter PartyName');
            return;
        }
        if (report.PickupPlace == null) {
            alert('Please Enter PickupPlace');
            return;
        }
        if (report.DropPlace == null) {
            alert('Please Enter DropPlace');
            return;
        }
        if (report.StartMeter == null) {
            alert('Please Enter StartMeter');
            return;
        }
        if (report.EndMeter == null) {
            alert('Please Enter EndMeter');
            return;
        }
        if (report.OtherExp == null) {
            alert('Please Enter OtherExp');
            return;
        }
        if (report.GeneratedAmount == null) {
            alert('Please Enter GeneratedAmount');
            return;
        }
        if (report.ActualAmount == null) {
            alert('Please Enter ActualAmount');
            return;
        }
       
        if (report.ExecutiveName == null) {
            alert('Please Enter ExecutiveName');
            return;
        }
        if (report.BNo == null) {
            alert('Please Enter BNo');
            return;
        }
        if (report.DropTime == null) {
            alert('Please Enter DropTime');
            return;
        }
        if (report.PickupTime == null) {
            alert('Please Enter PickupTime');
            return;
        }
        if (report.EntryTime == null) {
            alert('Please Enter EntryTime');
            return;
        }
       


        var report = {

            flag: "U",           
            EntryDate: report.EntryDate,
            VechID: report.VechID,
            RegistrationNo: report.RegistrationNo,
            DriverName: report.DriverName,
            PartyName: report.PartyName,
            PickupPlace: report.PickupPlace,
            DropPlace: report.DropPlace,
            StartMeter: report.StartMeter,
            EndMeter: report.EndMeter,
            OtherExp: report.OtherExp,
            GeneratedAmount: report.GeneratedAmount,
            ActualAmount: report.ActualAmount,
            ExecutiveName: report.ExecutiveName,
            BNo: report.BNo,
            DropTime: report.DropTime,
            PickupTime: report.PickupTime,
            EntryTime: report.EntryTime,


            Active: (report.Active == true) ? 1 : 0,
        }

        var req = {
            method: 'POST',
            url: '/api/ClosingReport/closerprt',
            data: report
        }
        $http(req).then(function (response) {

            alert("Saved successfully!");

            $scope.Group = null;

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "Your Details Are Incorrect";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            $scope.showDialog(errmssg);
        });
        $scope.currGroup = null;
    };

    $scope.reportors = null;

    $scope.setreportors = function (reporting) {
        $scope.reportors = reporting;
    };

    $scope.clearreporting = function () {
        $scope.reporting = null;
    }


    $scope.showDialog = function (message) {

        var modalInstance = $uibModal.open({
            animation: $scope.animationsEnabled,
            templateUrl: 'myModalContent.html',
            controller: 'ModalInstanceCtrl',
            resolve: {
                mssg: function () {
                    return message;
                }
            }
        });
    }


});
app.controller('ModalInstanceCtrl', function ($scope, $uibModalInstance, mssg) {

    $scope.mssg = mssg;
    $scope.ok = function () {
        $uibModalInstance.close('test');
    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };
});








