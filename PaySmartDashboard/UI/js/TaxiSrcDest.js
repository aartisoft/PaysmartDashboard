var app = angular.module('myApp', ['ngStorage'])
var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage, $filter) {
    if ($localStorage.uname == null) {
        window.location.href = "login.html";
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.Roleid = $scope.userdetails[0].roleid;

    //$scope.dashboardDS = $localStorage.dashboardDS;
    $scope.StopsList = null;

    $scope.GetTaxiStops = function () {
        $http.get("/api/GetTaxiStopsList?ctryid=" + $scope.Countries.Id).then(function (response, req) {
            $scope.StopsList = response.data;
        });
    }
    $scope.checkedArr = new Array();
    $scope.uncheckedArr = new Array();

    $scope.GetCountries = function () {

        $scope.checkedArr = [];
        $scope.uncheckedArr = [];

        $http.get('/api/Countries/GetCountries').then(function (response, req) {
            $scope.Countries = response.data;
            $scope.checkedArr = $filter('filter')($scope.Countries, { HasOperations: "1" });
            $scope.uncheckedArr = $filter('filter')($scope.Countries, { HasOperations: "0" });
        });
    }


    $scope.GetConfigData = function () {

        var vc = {            
            includeActiveCountry: '1',
           
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
        if ($scope.checkedArr.length === $scope.Countries.length) {
            $scope.uncheckedArr = $scope.checkedArr.slice(0);
            $scope.checkedArr = [];

        } else if ($scope.checkedArr.length === 0 || $scope.Countries.length > 0) {
            $scope.checkedArr = $scope.Countries.slice(0);
            $scope.uncheckedArr = [];
        }

    };

    $scope.exists = function (item, list) {
        return list.indexOf(item) > -1;
    };


    $scope.isChecked = function () {
        return $scope.checkedArr.length === $scope.Countries.length;
    };


});