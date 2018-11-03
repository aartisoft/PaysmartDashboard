// JavaScript source code
var myapp1 = angular.module('myApp', ['ngStorage', 'ui.bootstrap'])
var mycrtl1 = myapp1.controller('myCtrl', function ($scope, $http, $localStorage, $uibModal) {
    if ($localStorage.uname == null) {
        window.location.href = "login.html";
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.Roleid = $scope.userdetails[0].roleid;

    $scope.GetLicenseCat = function () {
        $http.get('/api/Types/TypesByGroupId?groupid=3').then(function (res, data) {
            $scope.LicenseCat = res.data;

            if ($scope.LicenseCat.length > 0) {
                $scope.s = $scope.LicenseCat[0];
                $scope.getLicenseTypes($scope.s);
            }
        });
    }
    $scope.getLicenseTypes = function (selCat) {
        if (selCat == null) {
            $scope.LicenseTypes = null;
            return;
        }
        $http.get('/api/License/GetLicenseTypes?catid=' + selCat.Id).then(function (res, data) {
            $scope.LicenseTypes = res.data;
        });
    }
    $scope.saveLicenseType = function (licenseType, flag) {
        if (licenseType == null) {
            alert('Please enter values.');
            return;
        }

        if (licenseType.LicenseType == null) {
            alert('Please enter license type.');
            return;
        }
        var currLicenseType = {
            Id: (flag == 'I') ? '-1' : licenseType.Id,
            LicenseType: licenseType.LicenseType,
            Desc: licenseType.Description,
            LicenseCategoryId: $scope.s.Id,
            Active: 1,
        };

        var req = {
            method: 'POST',
            url: '/api/License/SaveLicenseType',
            data: currLicenseType
        }
        $http(req).then(function (response) {

            $scope.Group = null;
            $scope.getLicenseTypes($scope.s);

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            $scope.showDialog(errmssg);
        });
        $scope.currGroup = null;
    };
   
   
    $scope.setCurrLicenseType = function (lt) {
        $scope.currLicenseType = lt;
    };
   
});



