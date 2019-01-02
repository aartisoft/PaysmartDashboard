var app = angular.module('myApp1', ['ngStorage', 'ui.bootstrap'])

var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage, $uibModal) {


    $scope.Getvech = function () {
        $http.get("/api/Vehiclelogin/Getvech?VechId=1").then(function (response, req) {
            $scope.Vechin = response.data;
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
            needvehicleMake: '1',
            
            
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

    $scope.saveNew = function (vhlogin, flag) {

        if (vhlogin == null) {
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
        if ($scope.vhlogin.m.DId == null || $scope.vhlogin.m.DId == "") {
            alert('Please enter MobileNo.');
            return;
        }
        if ($scope.vt.Id == null || $scope.vt.Id == "") {
            alert('Please enter VehicleType.');
            return;
        }
        if (vhlogin.LoginLandMark == null) {
            alert('Please enter LoginLandMark.');
            return;
        }      
        if (vhlogin.CurrentLandMark == null) {
            alert('Please enter CurrentLandMark.');
            return;
        }

        if (vhlogin.StartKiloMtr == null) {
            alert('Please enter StartKiloMtr.');
            return;
        }
        if (vhlogin.CurStatus == null) {
            alert('Please enter CurStatus.');
            return;
        }       
        
        if (vhlogin.NoofTimesLogin == null) {
            alert('Please enter NoofTimesLogin.');
            return;
        }
       

        var vhlogin = {
            Id: -1,
            VechID: $scope.vm.Id,
            CompanyId: $scope.c.Id,
            VechType: $scope.vt.Id,
            DriverMobileNo: $scope.vhlogin.m.DId,
            LoginLandMark:vhlogin.LoginLandMark,
            CurrentLandMark: vhlogin.CurrentLandMark,
            StartKiloMtr: vhlogin.StartKiloMtr,
            CurStatus: vhlogin.CurStatus,  
            NoofTimesLogin:vhlogin.NoofTimesLogin,
            RegNo: $scope.vm.Id,
            DriverName: vhlogin.DriverName,            
            flag: "I"
        }


        var req = {
            method: 'POST',
            url: '/api/Vehiclelogin/vechile',
            data: vhlogin
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

    $scope.vhlogin = null;
   

    $scope.Save = function (login, flag) {
        if (login == null) {
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
        if ($scope.login.m.DId == null || $scope.login.m.DId == "") {
            alert('Please enter MobileNo.');
            return;
        }
        if ($scope.vt.Id == null || $scope.vt.Id == "") {
            alert('Please enter VehicleType.');
            return;
        }
        if (login.LoginLandMark == null) {
            alert('Please enter LoginLandMark.');
            return;
        }       
        if (login.CurrentLandMark == null) {
            alert('Please enter CurrentLandMark.');
            return;
        }

        if (login.StartKiloMtr == null) {
            alert('Please enter StartKiloMtr.');
            return;
        }
        if (login.CurStatus == null) {
            alert('Please enter CurStatus.');
            return;
        }

        if (login.NoofTimesLogin1 == null) {
            alert('Please enter NoofTimesLogin.');
            return;
        }


        var login = {
            Id: login.Id,
            VechID: $scope.vm.Id,
            CompanyId: $scope.c.Id,
            VechType: $scope.vt.Id,
            DriverMobileNo: $scope.login.m.DId,
            LoginLandMark: login.LoginLandMark,
            CurrentLandMark: login.CurrentLandMark,
            StartKiloMtr: login.StartKiloMtr,
            CurStatus: login.CurStatus,
            NoofTimesLogin: login.NoofTimesLogin1,
            RegNo: $scope.vm.Id,
            DriverName: login.DriverName,
            flag: "U"
        }


        var req = {
            method: 'POST',
            url: '/api/Vehiclelogin/vechile',
            data: login
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

    $scope.login = null;

    $scope.setVechin = function (vi) {
        $scope.login = vi;
    };

    $scope.clearvhlogin = function () {
        $scope.vi = null;
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