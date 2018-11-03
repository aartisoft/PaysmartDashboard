var app = angular.module('myApp', ['ngStorage']);
app.directive('ngOnFinishRender', function ($timeout) {
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

var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage, $filter) {

    if ($localStorage.uname == null) {
        window.location.href = "login.html";
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.userCmpId = $scope.userdetails[0].CompanyId;
    $scope.userSId = $scope.userdetails[0].UserId;
    $scope.Roleid = $scope.userdetails[0].roleid;
    var configFareList = '';
    $scope.dashboardDS = $localStorage.dashboardDS;


    $scope.checkedArr = new Array();
    $scope.uncheckedArr = new Array();
    $scope.FORoutes = [];

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
           // $scope.showDialog("Saved successfully");
        });

        $scope.pricingType = [{ "Id": "1", "Name": "Per unit pricing" }, { "Id": "2", "Name": "Stage to Stage" }]
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
            //$scope.showDialog("Saved successfully");
        });
    }

    $scope.getFleetOwnerRoute = function () {

        if ($scope.s == null) {
            $scope.FORoutes = null;
            return;
        }

        $http.get('/api/FleetOwnerRoute/GetFleetOwnerRouteAssigned?fleetownerId=' + $scope.s.Id).then(function (res, data) {
            $scope.FORoutes = res.data;

        });
    }

    $scope.getFOFleetforRoute = function () {

        var selCmp = $scope.cmp;

        if (selCmp == null) {
            $scope.fleet = null;
            return;
        }
        var cmpId = (selCmp == null) ? -1 : selCmp.Id;

        var fr = {
            cmpId: selCmp.Id,
            routeid: $scope.r.RouteId,
            fleetownerId: $scope.s.Id
        };

        var req = {
            method: 'POST',
            url: '/api/FleetRoutes/getFleetRoutesList',
            //headers: {
            //    'Content-Type': undefined
            data: fr
        }
        $http(req).then(function (res) {
            $scope.fleet = res.data;
            //$scope.showDialog("Saved successfully");
        });

    }



    //This will hide the DIV by default.
    $scope.IsHidden = true;
    $scope.ShowHide = function () {
        //If DIV is hidden it will be visible and vice versa.
        $scope.IsHidden = $scope.IsHidden ? false : true;
    }

    $scope.getVehicleFareConfig = function () {

        if ($scope.v == null) {
            $scope.FOVFareConfig = null;
            return;
        }

        $http.get('/api/FleetOwnerRouteFare/GetFOVehicleFareConfig?vehicleId=' + $scope.v.VehicleId + '&routeId=' + $scope.r.RouteId).then(function (res, data) {
            $scope.FOVFare = res.data.Table;
            $scope.FOVFareConfig = res.data.Table1;
            $scope.puprc = $scope.FOVFare[0].UnitPrice;
            $scope.prc = $scope.FOVFare[0].PricingTypeId;
           
            angular.element('pt').value = $scope.prc;
        });

    }

    $scope.SetPrice = function () {
        if ($scope.prc == 20) {
            // var configFareList = $scope.FOVFareConfig;        

            for (var cnt = 0; cnt < $scope.FOVFareConfig.length; cnt++) {
                $scope.FOVFareConfig[cnt].Amount = ($scope.prc == 20) ? eval($scope.puprc) * eval($scope.FOVFareConfig[cnt].Distance) : $scope.FOVFareConfig[cnt].Amount;
            }
        }
    }
    $scope.saveFORouteFare = function () {

        if ($scope.prc == null) return;
        var FleetOwnerRouteFare1 = [];
       var configFareList = $scope.FOVFareConfig;

        for (var cnt = 0; cnt < configFareList.length; cnt++) {

            var fr = {
                RouteId: $scope.r.RouteId,
                VehicleTypeId: $scope.v.VehicleTypeId,
                FromStopId: configFareList[cnt].FromStopId,
                ToStopId: configFareList[cnt].ToStopId,
                Distance: configFareList[cnt].Distance,
                PerUnitPrice: $scope.puprc,
                Amount: ($scope.prc == 20) ? eval($scope.puprc) * eval(configFareList[cnt].Distance) : configFareList[cnt].Amount,
                FareTypeId: configFareList[cnt].FareTypeId,
                VehicleId: $scope.v.VehicleId,
                Active: 1,
                FromDate: configFareList[cnt].FromDate,
                ToDate: configFareList[cnt].ToDate
            }

            FleetOwnerRouteFare1.push(fr);

        }

        var RouteFareConfig = {
            VehicleId: $scope.v.VehicleId,
            RouteId: $scope.r.RouteId,
            PriceTypeId: $scope.prc,
            UnitPrice: $scope.puprc,
            Amount: eval($scope.puprc) * eval($scope.r.distance),
            SourceId: $scope.r.srcId,
            DestinationId: $scope.r.destId,
            //  FromDate: configFareList[cnt].FromDate,
            // ToDate: configFareList[cnt].ToDate,
            insupddelflag: 'I',
            routeFare: FleetOwnerRouteFare1
        }

        $http({
            url: '/api/FleetOwnerRouteFare/saveFleetOwnerRoutefare',
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            data: RouteFareConfig,

        }).success(function (data, status, headers, config) {
            alert('Fleet owner routes successfully');
            $scope.GetFORouteFare();
        }).error(function (ata, status, headers, config) {
            alert(ata);
        });
    }


    $scope.$on('ngRepeatFinished', function () {
        $("input[id*='date']").datepicker({
            dateFormat: "dd/mm/yy"
        });
    });


});
app.controller('ModalInstanceCtrl', function ($scope, $uibModalInstance, mssg) {

    $scope.mssg = mssg;
    $scope.ok = function () {
        $uibModalInstance.close('test');
    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };

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
