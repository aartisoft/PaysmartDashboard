// JavaScript source code
var app = angular.module('myApp', ['ngStorage', 'ui.bootstrap'])
var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage, $uibModal) {
    if ($localStorage.uname == null) {
        window.location.href = "login.html";
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.userCmpId = $scope.userdetails[0].CompanyId;
    $scope.userSId = $scope.userdetails[0].UserId;
    $scope.Roleid = $scope.userdetails[0].roleid;

    $scope.dashboardDS = $localStorage.dashboardDS;
    $scope.GetCountry = function () {
        $http.get('/api/Users/GetCountry?active=1').then(function (response, req) {
            $scope.Countries = response.data;
            if ($scope.Countries.length > 0) {
                $scope.ctry = $scope.Countries[0];
                //$scope.GetCountry($scope.ctry);
            }
        });
    }

    $scope.GetFleeBTPosDetails = function () {

        $http.get('/api/FleetBtpos/GetFleebtDetails?foId=-1&cmpid=-1&initdata.newfleet.fdid=-1').then(function (res, data) {
            $scope.FleetBtposList = res.data;
        });
    }

    $scope.GetCompanies = function () {

        $http.get('/api/company/getCompanies?userid=-1').then(function (res, data) {
            $scope.Companies = res.data.Table;
            $scope.Companies1 = res.data.Table;


            //if ($scope.userCmpId != 1) {

            //    for (i = 0; i < res.data.length; i++) {
            //        if (res.data[i].Id == $scope.userCmpId) {
            //            $scope.cmp = res.data[i];
            //            document.getElementById('test').disabled = true;
            //            break
            //        }
            //    }
            //}
            //else {
            //    document.getElementById('test').disabled = false;
            //}
            $scope.GetFleetOwners();
        });

    }


    $scope.GetFleetOwners = function () {


        var vc = {
            needfleetowners: '1',
            cmpId: ($scope.cmp == null) ? null : $scope.cmp.Id
        };

        var req = {
            method: 'POST',
            url: '/api/VehicleConfig/VConfig',
            //headers: {
            //    'Content-Type': undefined

            data: vc


        }
        $http(req).then(function (res) {
            $scope.cmpdata = res.data;
            $scope.cmpdata1 = res.data;

            //if ($scope.userSId != 1) {
            //    //loop throug the fleetowners and identify the correct one
            //    for (i = 0; i < res.data.Table.length; i++) {
            //        if (res.data.Table[i].UserId == $scope.userSId) {
            //            $scope.s = res.data.Table[i];
            //            document.getElementById('test1').disabled = true;
            //            break
            //        }
            //    }
            //}
            //else {
            //    document.getElementById('test1').disabled = false;
            //}
            //$scope.GetFleetRoutes($scope.s);

        });
    }

    $scope.GetRoutesForFO = function () {

        $scope.vehicles = null;

        var fleetowner = $scope.s1;

        if (fleetowner == null) {
            return;
        }


        var vc = {
            needvehicleRegno: '1',
            fleetownerId: fleetowner.Id,
            needfleetownerroutes: '1'
        };

        var req = {
            method: 'POST',
            url: '/api/VehicleConfig/VConfig',
            //headers: {
            //    'Content-Type': undefined
            data: vc
        }
        $http(req).then(function (res) {
            $scope.vehicles = res.data;
        });

    }

    $scope.GetFleetRoutes = function () {

        var selCmp = $scope.cmp;

        if (selCmp == null) {
            $scope.FleetRoute = null;
            return;
        }
        var cmpId = (selCmp == null) ? -1 : selCmp.Id;

        var fr = {
            cmpId: selCmp.Id,
            routeid: '-1',
            fleetownerId: $scope.s.Id,
            regno: '-1'
        };

        var req = {
            method: 'POST',
            url: '/api/FleetRoutes/getFleetRoutesList',
            //headers: {
            //    'Content-Type': undefined
            data: fr
        }
        $http(req).then(function (res) {
            $scope.FleetRoute = res.data;

            for (i = 0; i < $scope.Companies.length; i++) {
                if ($scope.Companies[i].Id == $scope.FleetRoute[0].CompanyId) {
                    $scope.cmp1 = $scope.Companies[i];
                    break;
                }
            }
            for (i = 0; i < $scope.cmpdata.Table.length; i++) {
                if ($scope.cmpdata.Table[i].Id == $scope.FleetRoute[0].FleetOwnerId) {
                    $scope.s1 = $scope.cmpdata.Table[i];
                    break;
                }
                $scope.GetRoutesForFO(s1);
            }
            for (i = 0; i < $scope.vehicles.Table.length; i++) {
                if ($scope.vehicles.Table[i].Id == $scope.FleetRoute[0].VehicleId) {
                    $scope.currFR.newfleet.v = $scope.vehicles.Table[i];
                    break;
                }

            }
        });
    }

    //$scope.GetFleetOwners = function () {
    //    if ($scope.cmp == null) {
    //        $scope.FleetOwners = null;
    //        return;
    //    }
    //    var vc = {
    //        needfleetowners: '1',
    //        cmpId: $scope.cmp.Id
    //    };

    //    var req = {
    //        method: 'POST',
    //        url: '/api/VehicleConfig/VConfig',
    //        //headers: {
    //        //    'Content-Type': undefined

    //        data: vc


    //    }
    //    $http(req).then(function (res) {
    //        $scope.FleetOwners = res.data;          
    //    });
    //}$scope.saveNewFleetRoutes = function (initdata) {


    $scope.save = function (currFR) {
        var FleetRoute = currFR.newfleet;
        if (FleetRoute == null || FleetRoute.v == null) {
            alert('Please select a type VehicleId');
            return;
        }
        if (FleetRoute.v == null) {
            alert('Please select Vehicle.');
            return;
        }
        if (FleetRoute.r == null) {
            alert('Please select a type  RouteId ');
            return;
        }
        var FleetRoutes = {
            Id: -1,
            VehicleId: FleetRoute.v.Id,
            RouteId: FleetRoute.r.RouteId,
            EffectiveFrom: FleetRoute.fd,
            EffectiveTill: FleetRoute.td,
            Active: FleetRoute.Active,
            insupddelflag: 'U'

        };

        var req = {
            method: 'POST',
            url: '/api/FleetRoutes/NewFleetRoutes',
            //headers: {
            //    'Content-Type': undefined

            data: FleetRoutes


        }
        $http(req).then(function (res) { });
        //$scope.showDialog("Updated successfully!");

    }



    $scope.saveNewFleetRoutes = function (initdata) {

        var newFR = initdata.newfleet;

        if (newFR == null || newFR.v == null) {
            alert('Please select VehicleRegNo.');
            return;
        }

        if (newFR.v == null) {
            alert('Please select Vehicle.');
            return;
        }

        if (newFR.r == null) {
            alert('Please select route.');
            return;
        }

        var FleetRoutes = {
            Id: -1,
            VehicleId: newFR.v.Id,
            RouteId: newFR.r.RouteId,
            EffectiveFrom: newFR.fd,
            EffectiveTill: newFR.td,
            insupddelflag: 'I'
        };

        var req = {
            method: 'POST',
            url: '/api/FleetRoutes/NewFleetRoutes',
            //headers: {
            //    'Content-Type': undefined

            data: FleetRoutes
        }

        $http(req).then(function (response) {

            alert("Saved successfully!");
            $('#Modal-header-new').modal('hide');
            $scope.Group = null;

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage :

    errdata.Message;
            $scope.showDialog(errmssg);
        });

        $scope.currGroup = null;
    };

    $scope.testdel = function (R) {
        var FRoutes = {

            Id: -1,
            VehicleId: R.VehicleId,
            RouteId: R.RouteId,
            EffectiveFrom: R.fd,
            EffectiveTill: R.td,
            insupddelflag: 'D'
        };

        var req = {
            method: 'POST',
            url: '/api/FleetRoutes/NewFleetRoutes',
            data: FRoutes
        }
        $http(req).then(function (response) {
            // alert('Removed successfully.');

            $http.get('/api/FleetRoutes/getFleetRoutesList?VehicleId=' + R.VehicleId).then(function (res, data) {
                $scope.FleetRoute = res.data;
            });

        });

    }

    $scope.setRoute = function (R) {
        $scope.currFR = R;
        $scope.currFR.VehicleTypeId = 9;
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



//$http.get('/api/Getfleet').then(function (res, data) {
//    $scope.fleet = res.data;

//    if ($scope.userSId != 1) {
//        //loop throug the companies and identify the correct one
//        for (i = 0; i < res.data.length; i++) {
//            if (res.data[i].Id == $scope.userSId) {
//                $scope.s = res.data[i];
//                document.getElementById('test1').disabled = true;
//                break
//            }
//        }
//    }
//    else {
//        document.getElementById('test1').disabled = false;
//    }
// //   $scope.GetFleetDetails($scope.s);
//});
