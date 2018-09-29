var app = angular.module('faqs', ['ngStorage', 'ui.bootstrap']);

var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage, $uibModal) {

    if ($localStorage.uname == null) {
        window.location.href = "login.html";
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.userCmpId = $scope.userdetails[0].CompanyId;
    $scope.userSId = $scope.userdetails[0].UserId;
    $scope.Roleid = $scope.userdetails[0].roleid;

    $scope.GetAllPrices = function () {
        $http.get("/api/faqs/Getlist").then(function (response, req) {
            $scope.FAQlist = response.data;
        });
    }
});