var app = angular.module('myApp1', ['ngStorage', 'ui.bootstrap'])

var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage, $uibModal) {


    $scope.Getvechout = function () {
        $http.get("/api/VehicleLogout/Getvechout?VechId=1").then(function (response, req) {
            $scope.Vechout = response.data;
        });
    }

    $scope.GetCompanys = function () {
        $http.get('/api/GetCompanyGroups?userid=-1').then(function (response, data) {
            $scope.Companies = response.data;
        });
    }

    $scope.GetMaster = function () {
        $http.get('/api/DriverMaster/GetMaster?DId=1').then(function (res, data) {
            $scope.listdrivers = res.data;
        });
        $http.get('/api/VehicleMaster/GetVehcileMaster?VID=1').then(function (res, data) {
            $scope.Vehicles = res.data;
        });
    }
    $scope.GetVehicleConfig = function () {

        var vc = {
            // needfleetowners:'1',
            needvehicleType: '1',
            needvehicleMake: '1'

        };

        var req = {
            method: 'POST',
            url: '/api/VehicleConfig/VConfig',
            //headers: {
            //    'Content-Type': undefined

            data: vc


        }
        $http(req).then(function (res) {
            $scope.initdata = res.data;
        });

    }

    $scope.saveNew = function (vehlogout, flag) {

        if (vehlogout == null) {
            alert('Please enter Pricing.');
            return;
        }
        if ($scope.c.Id == null) {
            alert('Please Enter Company');
            return;
        }
        if ($scope.vm.Id == null || $scope.vm.Id == "") {
            alert('Please enter VehicleModel.');
            return;
        }
        if ($scope.v.Id == null || $scope.v.Id == "") {
            alert('Please enter RegistrationNo.');
            return;
        }
        if ($scope.vehlogout.m.DId == null || $scope.vehlogout.m.DId == "") {
            alert('Please enter MobileNo.');
            return;
        }
        if ($scope.vt.Id == null || $scope.vt.Id == "") {
            alert('Please enter VehicleType.');
            return;
        }
        if (vehlogout.LoginLandMark == null) {
            alert('Please enter LoginLandMark.');
            return;
        }
        
        if (vehlogout.CurrentLandMark == null) {
            alert('Please enter CurrentLandMark.');
            return;
        }

        if (vehlogout.EndMtr == null) {
            alert('Please enter EndMtr.');
            return;
        }
        if (vehlogout.CurStatus == null) {
            alert('Please enter CurStatus.');
            return;
        }

        if (vehlogout.NoofTimesLogin == null) {
            alert('Please enter NoofTimesLogin.');
            return;
        }
        if (vehlogout.TotalGeneratedAmount == null) {
            alert('Please enter TotalGeneratedAmount.');
            return;
        }

        var vehlogout = {
            Id: -1,
            VechID: $scope.vm.Id,
            CompanyId: $scope.c.Id,
            VechType: $scope.vt.Id,
            DriverMobileNo: $scope.vehlogout.m.DId,
            LoginLandMark: vehlogout.LoginLandMark,
            CurrentLandMark: vehlogout.CurrentLandMark,
            EndMtr: vehlogout.EndMtr,
            CurStatus: vehlogout.CurStatus,
            NoofTimesLogin: vehlogout.NoofTimesLogin,
            RegNo: $scope.vm.Id,
            DriverName: vehlogout.DriverName,
            TotalGeneratedAmount: vehlogout.TotalGeneratedAmount,
            LogoutDate:vehlogout.LogoutDate,
            LogoutTime:vehlogout.LogoutTime,
            flag: "I"
        }


        var req = {
            method: 'POST',
            url: '/api/VehicleLogout/vechileout',
            data: vehlogout
        }
        $http(req).then(function (response) {

            alert("Saved successfully!!");

            $scope.Group = null;
            //$scope.GetCompanys();

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "Your details are incorrect";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            // $scope.showDialog(errmssg);
            alert(errmssg);
        });
        $scope.currGroup = null;
    };

    $scope.vehlogout = null;


    $scope.Save = function (logout, flag) {
        if (logout == null) {
            alert('Please enter Pricing.');
            return;
        }
        if ($scope.c.Id == null) {
            alert('Please Enter Company');
            return;
        }
        if ($scope.vm.Id == null || $scope.vm.Id == "") {
            alert('Please enter VehicleModel.');
            return;
        }
        if ($scope.v.Id == null || $scope.v.Id == "") {
            alert('Please enter RegistrationNo.');
            return;
        }
        if ($scope.logout.m.DId == null || $scope.logout.m.DId == "") {
            alert('Please enter MobileNo.');
            return;
        }
        if ($scope.vt.Id == null || $scope.vt.Id == "") {
            alert('Please enter VehicleType.');
            return;
        }
        if (logout.LoginLandMark == null) {
            alert('Please enter LoginLandMark.');
            return;
        }
        if (logout.CurrentLandMark == null) {
            alert('Please enter CurrentLandMark.');
            return;
        }

        if (logout.EndMtr == null) {
            alert('Please enter EndMtr.');
            return;
        }
        if (logout.CurStatus == null) {
            alert('Please enter CurStatus.');
            return;
        }

        if (logout.NoofTimesLogin1 == null) {
            alert('Please enter NoofTimesLogin.');
            return;
        }
        if (logout.TotalGeneratedAmount == null) {
            alert('Please enter TotalGeneratedAmount.');
            return;
        }

        var logout = {
            Id: logout.Id,
            VechID: $scope.vm.Id,
            CompanyId: $scope.c.Id,
            VechType: $scope.vt.Id,
            DriverMobileNo: $scope.logout.m.DId,
            LoginLandMark: logout.LoginLandMark,
            CurrentLandMark: logout.CurrentLandMark,
            EndMtr: logout.EndMtr,
            CurStatus: logout.CurStatus,
            NoofTimesLogin: logout.NoofTimesLogin1,
            RegNo: $scope.vm.Id,
            DriverName: logout.DriverName,
            TotalGeneratedAmount: logout.TotalGeneratedAmount,
            flag: "U"
        }


        var req = {
            method: 'POST',
            url: '/api/VehicleLogout/vechileout',
            data: logout
        }
        $http(req).then(function (response) {

            alert("Updated successfully!");

            $scope.Group = null;

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "Not Updated";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            $scope.showDialog(errmssg);
        });
        $scope.currGroup = null;
    };

    $scope.logout = null;

    $scope.setVechout = function (vl) {
        $scope.logout = vl;
    };

    $scope.clearvehlogout = function () {
        $scope.logout = null;
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