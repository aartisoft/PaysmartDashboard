// JavaScript source code
var myapp1 = angular.module('myApp', [])

var mycrtl1 = myapp1.controller('myCtrl', function ($scope, $http) {

    $scope.routefares =
        [
          {
              "Rows": "Hyderabad", "Hyderabad": 0, "Vijaywada": 307, "Kurnool": 400, "Karimnagar": 200
          },
          {
              "Rows": "Vijaywada", "Hyderabad": 307, "Vijaywada": 0, "Kurnool": 100, "Karimnagar": 500
          },
          {
              "Rows": "Kurnool", "Hyderabad": 400, "Vijaywada": 100, "Kurnool": 0, "Karimnagar": 300
          },
          {
              "Rows": "Karimnagar", "Hyderabad": 200, "Vijaywada": 500, "Kurnool": 300, "Karimnagar": 0
          }
        ];

    $scope.GetStops = function () {
        $http.get('/api/Stops/GetStops').then(function (res, data) {
            $scope.Stops = res.data;
        });

    }

    $scope.test = function (dr) {
        alert(dr);
    }

});



