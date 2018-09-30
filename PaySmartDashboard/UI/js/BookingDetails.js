// JavaScript source code
// JavaScript source code
var app = angular.module('myApp', ['ngStorage', 'ui.bootstrap'])
var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage, $uibModal) {
    if ($localStorage.uname == null) {
        window.location.href = "login.html";
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.Roleid = $scope.userdetails[0].roleid;

    $scope.dashboardDS = $localStorage.dashboardDS;


    var parseLocation = function (location) {
        var pairs = location.substring(1).split("&");
        var obj = {};
        var pair;
        var i;

        for (i in pairs) {
            if (pairs[i] === "") continue;

            pair = pairs[i].split("=");
            obj[decodeURIComponent(pair[0])] = decodeURIComponent(pair[1]);
        }

        return obj;
    };


    $scope.GetBookingdetails = function () {

        $scope.bookings = null;

        $scope.selectedbookings = parseLocation(window.location.search)['BNo'];

        $http.get('/api/BookAVehicle/Bookingdetails?BNo=' + $scope.selectedbookings).then(function (res, data) {
            $scope.b = res.data[0];

            //if ($scope.bookings.length > 0) {
            //    if ($scope.selectedbookings != null) {
            //        for (i = 0; i < $scope.bookings.length; i++) {
            //            if ($scope.bookings[i].id == $scope.selectedbookings) {
            //                $scope.v = $scope.bookings[i];
            //                break;
            //            }
            //        }
            //    }
            //    else {
            //        $scope.s = $scope.bookings[0];
            //        $scope.selectedbookings = $scope.bookings[0].id;
            //    }

            //    $scope.getselectval($scope.selectedbookings);
            //}
            mapping($scope.b);
        });
    }
    $scope.getselectval = function (v) {

        $http.get('/api/BookAVehicle/GetBookingdetails?VID=' + $scope.selectedbookings).then(function (res, data) {
            $scope.bookings = res.data;
        });

    }

    $scope.markers = [];
                                                          
    $scope.mapping = function myMap(b) {

             
        var mapOptions = {
         
        center: new google.maps.LatLng(17.3850, 78.4867),
        zoom: 10,      
        mapTypeId: google.maps.MapTypeId.HYBRID
    }
        var map = new google.maps.Map(document.getElementById("map"), mapOptions);
        createMarker($scope.b);
}
                                                    
    
    var createMarker = function (b) {
        var marker = new google.maps.Marker({
            map: $scope.map,
            position: new google.maps.LatLng(b.SrcLatitude, b.SrcLongitude,b.DestLatitude,b.DestLongitude),
            //title: loc.loc

            icon: marker
        });
        marker.content = '<div class="infoWindow"</div>' + 'Driver Name: ' + b.NAme + '<br> Driver Number: ' + b.DriverNo + '<br> Vehicle Group: ' + b.VehicleGroupId + '</div>';;

        var infoWindow = new google.maps.InfoWindow();

        google.maps.event.addListener(marker, 'click', function () {

            infoWindow.setContent('<h2>' + marker.title + '</h2>' + marker.content);
            infoWindow.setContent(marker.content);
            infoWindow.open($scope.map, marker);
        });

        $scope.markers.push(marker);
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
app.controller('ModalInstanceCtrl', function ($scope, $uibModalInstance, mssg) {

    $scope.mssg = mssg;
    $scope.ok = function () {
        $uibModalInstance.close('test');
    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };
});








