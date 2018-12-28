var app = angular.module('myApp', ['ngStorage', 'ui.bootstrap']);

var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage, $uibModal) {

    if ($localStorage.uname == null) {
        window.location.href = "login.html";
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.userCmpId = $scope.userdetails[0].CompanyId;
    $scope.userSId = $scope.userdetails[0].UserId;
    $scope.Roleid = $scope.userdetails[0].roleid;

    $scope.GetDistancePrices = function () {
        $http.get("/api/GetVehicleDistancePrices").then(function (response, req) {
            $scope.DistPricelist = response.data;
        });
    }
});