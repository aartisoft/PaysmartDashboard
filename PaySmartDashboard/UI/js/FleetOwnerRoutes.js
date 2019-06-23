var app = angular.module('myApp', ['ngStorage']);


//app.directive('ngOnFinishRender', function ($timeout) {
//    return {
//        restrict: 'A',
//        link: function (scope, element, attr) {
//            if (scope.$last === true) {
//                $timeout(function () {
//                    scope.$emit(attr.broadcastEventName ? attr.broadcastEventName : 'ngRepeatFinished');
//                });
//            }
//        }
//    };
//});

angular.module('myApp').directive('ngOnFinishRender', function ($timeout) {
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


    $scope.checkedArr = new Array();
    $scope.uncheckedArr = new Array();
    $scope.FORoutes = [];


    $scope.getFleetOwnerRoute = function () {

        if ($scope.s == null) {
            $scope.FORoutes = null;
            $scope.checkedArr = [];
            $scope.uncheckedArr = [];
            return;
        }

        $http.get('/api/FleetOwnerRoute/getFleetOwnerRoute?cmpId=' + $scope.cmp.Id + '&fleetownerId=' + $scope.s.Id).then(function (res, data) {
            $scope.FORoutes = res.data;
            $scope.checkedArr = $filter('filter')($scope.FORoutes, { assigned: "1" });
            $scope.uncheckedArr = $filter('filter')($scope.FORoutes, { assigned: "0" });
        });
    }

    $scope.GetCompanies = function () {

        $http.get('/api/company/getCompanies?userid=-1').then(function (res, data) {
            $scope.Companies = res.data.Table;

            if ($scope.userCmpId != 1) {
                //loop throug the companies and identify the correct one
                for (i = 0; i < res.data.length; i++) {
                    if (res.data[i].Id == $scope.userCmpId) {
                        $scope.cmp = res.data[i];
                        document.getElementById('test').disabled = true;
                        break
                    }
                }
            }
            else {
                document.getElementById('test').disabled = false;
            }
            $scope.GetFleetOwners($scope.cmp);
        });

    }

    $scope.GetFleetOwners = function () {


        if ($scope.cmp == null) {
            $scope.cmpdata = null;
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

            if ($scope.userSId != 1) {
                //loop throug the fleetowners and identify the correct one
                for (i = 0; i < res.data.Table.length; i++) {
                    if (res.data.Table[i].UserId == $scope.userSId) {
                        $scope.s = res.data.Table[i];
                        document.getElementById('test1').disabled = true;
                        break
                    }
                }
            }
            else {
                document.getElementById('test1').disabled = false;
            }
            $scope.getFleetOwnerRoute($scope.s);

        });
    }

    $scope.saveFORoutes = function () {

        //from the checked and unchecked array get the actuallly records to be saved
        //from checked array take the records which have assigned = 0 as there are new assignements
        //from unchecked array take assgined = 1 as these need to be removed


        var FleetOwnerRoutes = [];

        for (var cnt = 0; cnt < $scope.checkedArr.length; cnt++) {

            if ($scope.checkedArr[cnt].assigned == 0) {
                var fr = {
                    Id: -1,
                    FleetOwnerId: $scope.s.Id,
                    CompanyId: $scope.cmp.Id,
                    RouteId: $scope.checkedArr[cnt].RouteId,
                    From: $scope.checkedArr[cnt].FromDate,
                    To: $scope.checkedArr[cnt].ToDate,
                    Active: 1,
                    insupddelflag: 'I'
                }

                FleetOwnerRoutes.push(fr);
            }
        }
        for (var cnt = 0; cnt < $scope.checkedArr.length; cnt++) {

            if ($scope.checkedArr[cnt].assigned == 1) {
                var fr = {
                    Id: -1,
                    FleetOwnerId: $scope.s.Id,
                    CompanyId: $scope.cmp.Id,
                    RouteId: $scope.checkedArr[cnt].RouteId,
                    From: $scope.checkedArr[cnt].FromDate,
                    To: $scope.checkedArr[cnt].ToDate,
                    Active: 1,
                    insupddelflag: 'U'
                }

                FleetOwnerRoutes.push(fr);
            }
        }
        for (var cnt = 0; cnt < $scope.uncheckedArr.length; cnt++) {

            if ($scope.uncheckedArr[cnt].assigned == 1) {
                var fr = {
                    Id: -1,
                    FleetOwnerId: $scope.s.Id,
                    CompanyId: $scope.cmp.Id,
                    RouteId: $scope.uncheckedArr[cnt].RouteId,
                    From: $scope.uncheckedArr[cnt].FromDate,
                    To: $scope.uncheckedArr[cnt].ToDate,
                    Active: 1,
                    insupddelflag: 'D'
                }

                FleetOwnerRoutes.push(fr);
            }
        }

        $http({
            url: '/api/FleetOwnerRoute/saveFleetOwnerRoute',
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            data: FleetOwnerRoutes,

        }).success(function (data, status, headers, config) {
            alert("Saved successfully")
            $scope.getFleetOwnerRoute();
        }).error(function (ata, status, headers, config) {
            alert(ata);
        });
    };


    $scope.toggle = function (item) {
        var idx = $scope.checkedArr.indexOf(item);
        if (idx > -1) {
            $scope.checkedArr.splice(idx, 1);
        }
        else {
            $scope.checkedArr.push(item);
        }

        var idx = $scope.uncheckedArr.indexOf(item);
        if (idx > -1) {
            $scope.uncheckedArr.splice(idx, 1);
        }
        else {
            $scope.uncheckedArr.push(item);
        }
    };


    $scope.toggleAll = function () {
        if ($scope.checkedArr.length === $scope.FORoutes.length) {
            $scope.uncheckedArr = $scope.checkedArr.slice(0);
            $scope.checkedArr = [];

        } else if ($scope.checkedArr.length === 0 || $scope.FORoutes.length > 0) {
            $scope.checkedArr = $scope.FORoutes.slice(0);
            $scope.uncheckedArr = [];
        }

    };

    $scope.exists = function (item, list) {
        return list.indexOf(item) > -1;
    };


    $scope.isChecked = function () {
        return $scope.checkedArr.length === $scope.FORoutes.length;
    };

    $scope.$on('ngRepeatFinished', function () {
        $("input[id*='date']").datepicker({
            dateFormat: "dd/mm/yy"
        });
    });

});
