var app = angular.module('myApp', ['ngStorage'])
var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage, $filter) {
    if ($localStorage.uname == null) {
        window.location.href = "login.html";
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.Roleid = $scope.userdetails[0].roleid;

    $scope.dashboardDS = $localStorage.dashboardDS;

    $scope.checkedArr = new Array();
    $scope.uncheckedArr = new Array();

    $scope.GetCountries = function () {

        $scope.checkedArr = [];
        $scope.uncheckedArr = [];

        $http.get('/api/Countries/GetCountries').then(function (response, req) {
            $scope.Countries = response.data;
            $scope.checkedArr = $filter('filter')($scope.Countries, { HasOperations: "1" });
            $scope.uncheckedArr = $filter('filter')($scope.Countries, { HasOperations: "0" });
            //$scope.Flag = $scope.Countries.Flag[0];
        });
    }

    $scope.saveCountries = function() {

        //from the checked and unchecked array get the actuallly records to be saved
        //from checked array take the records which have assigned = 0 as there are new assignements
        //from unchecked array take assgined = 1 as these need to be removed               
      
        var countries = [];

        for (var cnt = 0; cnt < $scope.checkedArr.length; cnt++) {
            if ($scope.checkedArr[cnt].HasOperations == 0) {
                var fr = {
                    Id: $scope.checkedArr[cnt].Id,
                    HasOperations: 1
                }
                countries.push(fr);
            }
        }

        for (var cnt = 0; cnt < $scope.uncheckedArr.length; cnt++) {
            if ($scope.uncheckedArr[cnt].HasOperations == 1) {
                var fr = {
                    Id: $scope.uncheckedArr[cnt].Id,
                    HasOperations: 0
                }
                countries.push(fr);
            }
        }
        
        $http({
            url: '/api/Countries/SaveCountries',
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            data: countries,

        }).success(function (data, status, headers, config) {
            alert('Country details Saved Successfully');
            
        }).error(function (ata, status, headers, config) {
            alert('Country details NotSaved Successfully');
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