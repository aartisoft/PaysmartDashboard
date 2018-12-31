//var myapp1 = angular.module('myApp', ['timepicker'])
var myapp1 = angular.module('myApp', ['ngStorage', 'ui.bootstrap'])

angular.module('myApp').directive('ngOnFinishRender', function ($timeout, $localStorage) {

    return {
        restrict: 'A',
        link: function (scope, element, attr) {
            if (scope.$last === true) {
                $timeout(function () {
                    scope.$emit(attr.broadcastEventName ? attr.broadcastEventName : 'ngRepeatFinished');
                });
            }
        }
    };

});

var mycrtl1 = myapp1.controller('myCtrl', function ($scope, $http, $localStorage, $uibModal) {
    if ($localStorage.uname == null) {
        window.location.href = "login.html";
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.Roleid = $scope.userdetails[0].roleid;

    $scope.dashboardDS = $localStorage.dashboardDS;
    fovslist = [];
    $scope.StopCount = [];

    $scope.GetCompanies = function () {

        var vc = {
            needCompanyName: '1'
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
            $scope.showdialogue("Saved successfully")

        });

    }
    
    $scope.GetFleetOwners = function () {
        if ($scope.cmp == null) {
            $scope.FleetOwners = null;
            return;
        }
        var vc = {
            needfleetowners: '1',
            cmpId: $scope.cmp.Id
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
            $scope.showdialogue("Saved successfully")
        });
    }

    $scope.GetFORoutes = function () {


        if ($scope.s == null) {
            $scope.routes = null;
            return;
        }

        var vc = {
            needFleetOwnerRoutes: '1',
            fleetownerId: $scope.s.Id
        };

        var req = {
            method: 'POST',
            url: '/api/VehicleConfig/VConfig',
            //headers: {
            //    'Content-Type': undefined

            data: vc


        }
        $http(req).then(function (res) {
            $scope.sdata = res.data;
            $scope.showdialogue("Saved successfully")
            // GetRouteDetails1();
        });
    }

    $scope.GetRouteFleet = function () {

        var selCmp = $scope.cmp;

        if (selCmp == null) {
            $scope.FleetRoute = null;
            return;
        }
        var cmpId = (selCmp == null) ? -1 : selCmp.Id;

        var fr = {
            cmpId: selCmp.Id,
            routeid: $scope.r.RouteId,
            fleetownerId: $scope.s.Id,
        };

        var req = {
            method: 'POST',
            url: '/api/FleetRoutes/getFleetRoutesList',
            //headers: {
            //    'Content-Type': undefined
            data: fr
        }
        $http(req).then(function (res) {
            $scope.RouteFleet = res.data;
        });
    }

    $scope.getFORVehicleSchedule = function () {
        $scope.RouteVehicleSchedule = [];
        if ($scope.r == null || $scope.r.RouteId == null) {
            //alert('Please select a route.');
            $scope.RouteVehicleSchedule = [];
            return;
        }
        $http.get('/api/FleetOwnerVehicleSchedule/getFORVehicleSchedule?fleetownerid=' + $scope.s.Id + '&routeid='
            + $scope.r.RouteId + '&vehicleId=' + $scope.v.VehicleId).then(function (res, data) {
                $scope.RouteVehicleSchedule = res.data;
            });
    }

    $scope.SetCurrStop = function (currStop, indx) {
        //alert(currStop.StopName);
        $scope.currStop = currStop;
        $scope.currStopIndx = indx;
    }

    $scope.GetshowDivStopDetails = function () {

        if (StopCount > 0) {

            document.getElementById("Stopdetails").style.display = 'inline';
        }
        else {
            document.getElementById("StopDetails").style.display = 'none';
        }
    }
    
    $scope.$on('ngRepeatFinished', function () {

        $("input[id*='Date']").datetimepicker({
            pickDate: false
        });


    });

    $scope.GetData = function () {
        $scope.StopNo = '1';
        $scope.StopName = "Hyderabad";
        $scope.StopCode = "HYD";

        //  $http(req).then(function (res) {
        //  $scope.Data = res.data;
        // GetRouteDetails1();
        // });

    }
       
    $scope.updateTime = function (s) {
        var aid = s.stopid + 'ADate';
        var did = s.stopid + 'DDate';

        s.arrivaltime = document.getElementById(aid).value;
        s.departuretime = document.getElementById(did).value;
    }   

    $scope.save = function () {
        var FleetOwnerVS = [];
        var configFareList = $scope.RouteVehicleSchedule;

        var foSchedule = new Object();
        foSchedule.VehicleId = $scope.v.VehicleId;
        foSchedule.RouteId = $scope.r.RouteId;
        foSchedule.FleetOwnerId = $scope.s.Id;

        for (var cnt = 0; cnt < configFareList.length; cnt++) {
            var arrTime = configFareList[cnt].arrivaltime; //12:00 AM

            var atimeAtt = arrTime.split(' ')
            var atArr = atimeAtt[0].split(':');

            var depTime = configFareList[cnt].departuretime; //12:00 AM

            var dtimeAtt = depTime.split(' ')
            var dtArr = dtimeAtt[0].split(':');


            var FVS = {
               
                StopId : configFareList[cnt].stopid,
                ArrivalHr: atArr[0],
                DepartureHr: dtArr[0],
                
                ArrivalMin: atArr[1],
                DepartureMin: dtArr[1],
                ArrivalAMPM: atimeAtt[1],
                DepartureAmPm: dtimeAtt[1],
                Duration: stop.Duration,

                arrivaltime: arrTime,
                departuretime: depTime,

                insupddelflag: 'U'
        }
            FleetOwnerVS.push(FVS);
    }
        foSchedule.VSchedule = FleetOwnerVS;
        $http({
            url: '/api/FleetOwnerVehicleSchedule/saveFORSchedule',
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            data: foSchedule,

        }).success(function (data, status, headers, config) {
            //alert('Fleet owner Vehicle Schedule Saved successfully');
            $scope.GetFORoutes();
        }).error(function (ata, status, headers, config) {
            alert(ata);
        });
    }
    
    /*vehicle schedule list*/

    $scope.GetVehicleScheduleList = function () {

        var rid, vid;
        if ($scope.cmp == null) {
            $scope.cmpdata = null;
            return;
        }

        if ($scope.s == null) {
            $scope.Fleet = null;
            return;
        }
        if ($scope.r == null) {
            rid = -1;            
        }
        if ($scope.v == null) {
            vid = -1;
        }

        $http.get('/api/FleetOwnerVehicleSchedule/getVehicleScheduleList?&routeId=' + $scope.r.Id + '&vehicleId=' + $scope.v.Id).then(function (res, data) {
            $scope.VScheduleList = res.data.Table;
        });
    }

    /*end of  vehicle schedule list*/
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

myapp1.controller('ModalInstanceCtrl', function ($scope, $uibModalInstance, mssg) {

    $scope.mssg = mssg;
    $scope.ok = function () {
        $uibModalInstance.close('test');
    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };
});

