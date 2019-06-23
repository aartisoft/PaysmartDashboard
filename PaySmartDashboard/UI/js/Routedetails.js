// JavaScript source code
var myapp1 = angular.module('myApp', ['ngStorage', 'ui.bootstrap'])

var mycrtl1 = myapp1.controller('myCtrl', function ($scope, $http, $localStorage, $uibModal) {
    if ($localStorage.uname == null) {
        window.location.href = "login.html";
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.Roleid = $scope.userdetails[0].roleid;

    $scope.dashboardDS = $localStorage.dashboardDS;

    stopsList = [];
    $scope.RouteDetails = [];

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

            //$scope.ctry = $scope.initdata.Table1[0];

        });
    }

    $scope.GetRoutes = function () {
        $http.get('/api/Routes/GetRoutes').then(function (res, data) {
            $scope.routes = res.data;
            // GetRouteDetails($scope.routes[0].Id);
        });

        $http.get('/api/Stops/GetStops').then(function (res, data) {
            $scope.Stops = res.data;
        });

    }

    $scope.GetRouteDetails = function (route) {
        if (route == null || route.Id == null) {
            //alert('Please select a route.');
            $scope.RouteDetails = [];
            return;
        }
        $http.get('/api/routedetails/getroutedetails?routeid=' + route.Id).then(function (res, data) {
            $scope.RouteDetails = res.data;
            $scope.getDirections();
        });

    }

    $scope.SetCurrStop = function (currStop, indx) {
        //alert(currStop.StopName);
        $scope.currStop = currStop;
        $scope.currStopIndx = indx;
    }

    $scope.setNewStopCode = function (stp) {
        $scope.newNextStop.StopCode = stp.Code;
    }

    //This will hide the DIV by default.
    $scope.IsHidden = true;

    $scope.ShowHide = function () {
        //If DIV is hidden it will be visible and vice versa.
        $scope.IsHidden = $scope.IsHidden ? false : true;
    }

    $scope.save = function (RouteDetails) {


        var req = {
            method: 'POST',
            url: '/api/routedetails/saveroutedetails',
            //headers: {
            //    'Content-Type': undefined

            data: RouteDetails.Table1
        }
        $http(req).then(function (response) {

            $scope.showDialog("Saved successfully!");

            $scope.Group = null;

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            $scope.showDialog(errmssg);
        });
        $scope.currGroup = null;
    };

    $scope.addPrevStop = function (stop) {
        //  stopsList.splice(index, 0, stop);
        var newStop = {
            StopName: stop.stp.Name,
            StopCode: stop.StopCode,
            RouteId: $scope.s.Id,
            stopid: stop.stp.Id,
            PreviousStopId: $scope.currStop.PreviousStopId,
            prevstop: $scope.currStop.prevstop,
            nextstop: $scope.currStop.StopName,
            NextStopId: $scope.currStop.stopid,
            DistanceFromSource: stop.DistanceFromSource,
            DistanceFromDestination: stop.DistanceFromDestination,
            DistanceFromPreviousStop: stop.DistanceFromPreviousStop,
            DistanceFromNextStop: stop.DistanceFromNextStop,
            StopNo: $scope.currStop.StopNo,
            insupddelflag: 'I'
        }

        $scope.RouteDetails.Table1.splice($scope.currStopIndx, 0, newStop);

        for (var cnt = 0; cnt < $scope.RouteDetails.Table1.length; cnt++) {
            if ($scope.RouteDetails.Table1[cnt].insupddelflag == null || $scope.RouteDetails.Table1[cnt].insupddelflag != 'I') {

                $scope.RouteDetails.Table1[cnt].insupddelflag = 'U';
            }
            $scope.RouteDetails.Table1[cnt].StopNo = cnt + 1;
        }
        $scope.currStop.PreviousStopId = stop.stp.Id;
        $scope.currStop.prevstop = stop.stp.Name;

        var prvStop = $scope.RouteDetails.Table1[$scope.currStopIndx - 1];
        prvStop.NextStopId = stop.stp.Id;
        prvStop.nextstop = stop.stp.Name;

    }

    $scope.addNextStop = function (stop) {
        //stopsList.splice(index, 0, stop);
        var newStop = {
            StopName: stop.stp.Name,
            StopCode: stop.StopCode,
            RouteId: $scope.s.Id,
            stopid: stop.stp.Id,
            PreviousStopId: $scope.currStop.stopid,
            prevstop: $scope.currStop.StopName,
            nextstop: $scope.currStop.nextstop,
            NextStopId: $scope.currStop.NextStopId,
            DistanceFromSource: stop.DistanceFromSource,
            DistanceFromDestination: stop.DistanceFromDestination,
            DistanceFromPreviousStop: stop.DistanceFromPreviousStop,
            DistanceFromNextStop: stop.DistanceFromNextStop,
            StopNo: $scope.currStop.StopNo + 1,
            insupddelflag: 'I'
        }
        $scope.currStop.NextStopId = stop.stp.Id;
        $scope.currStop.nextstop = stop.stp.Name;

        $scope.RouteDetails.Table1.splice($scope.currStopIndx + 1, 0, newStop);

        var nxtStop = $scope.RouteDetails.Table1[$scope.currStopIndx + 2];
        nxtStop.PreviousStopId = stop.stp.Id;
        nxtStop.prevstop = stop.stp.Name;


        for (var cnt = 0; cnt < $scope.RouteDetails.Table1.length; cnt++) {
            if ($scope.RouteDetails.Table1[cnt].insupddelflag == null || $scope.RouteDetails.Table1[cnt].insupddelflag != 'I') {
                $scope.RouteDetails.Table1[cnt].insupddelflag = 'U';
            }
            $scope.RouteDetails.Table1[cnt].StopNo = cnt + 1;
        }

    }

    $scope.delStop = function (stop) {
        stopsList.splice(index, 0, stop);
    }

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

    $scope.map = {
        control: {},
        center: {
            latitude: 17.3850,
            longitude: 78.4867
        },
        zoom: 16
    };


    var directionsDisplay = new google.maps.DirectionsRenderer();
    var directionsService = new google.maps.DirectionsService();
    var geocoder = new google.maps.Geocoder();

    $scope.distval = 0;
    $scope.unitprice = 0;

    $scope.getDirections = function () {
        //get the source latitude and longitude
        //get the target latitude and longitude
        $scope.srcLat = $scope.RouteDetails.Latitude;
        $scope.srcLon = $scope.RouteDetails.Longitude;
        $scope.destLat = $scope.RouteDetails.Latitude;
        $scope.destLon = $scope.RouteDetails.Longitude;

        $scope.srcName = $scope.RouteDetails.StopName;
        $scope.destName = $scope.RouteDetails.StopName;
        //alert($scope.dropPoint.place.geometry.location.lat);
        var request = {
            origin: new google.maps.LatLng($scope.srcLat, $scope.srcLon),//$scope.directions.origin,
            destination: new google.maps.LatLng($scope.destLat, $scope.destLon),//$scope.directions.destination,
            travelMode: google.maps.DirectionsTravelMode.DRIVING
        };
        directionsService.route(request, function (response, status) {
            if (status == google.maps.DirectionsStatus.OK) {
                directionsDisplay.setDirections(response);
                directionsDisplay.setMap($scope.map.control.getGMap());
                // directionsDisplay.setPanel(document.getElementById('distance').innerHTML += response.routes[0].legs[0].distance.value + " meters");

                $scope.distval = response.routes[0].legs[0].distance.value / 1000;
                $scope.distText = $scope.distval + " KM";

                //response.routes[0].bounds["f"].b
                //17.43665
                //response.routes[0].bounds["b"].b
                //78.41263000000001


                //response.routes[0].bounds["f"].f
                //17.45654
                //response.routes[0].bounds["b"].f
                //78.44829                

                //$scope.srcLat = response.routes[0].bounds["f"].b;
                //$scope.srcLon = response.routes[0].bounds["b"].b;
                //$scope.destLat = response.routes[0].bounds["f"].f;
                //$scope.destLon = response.routes[0].bounds["b"].f;              

                //$scope.directions.showList = true;
            } else {
                alert('Google route unsuccesfull!');
            }

        });
    }

    $scope.CenterMap = function (ctry) {
        var lat = (ctry.latitude == null) ? 17.499800 : ctry.latitude;
        var long = (ctry.longitude == null) ? 78.399597 : ctry.longitude;
        var mapOptions = {
            zoom: 15,
            center: new google.maps.LatLng(lat, long),
            mapTypeId: google.maps.MapTypeId.ROADMAP
        }

        $scope.map = new google.maps.Map(document.getElementById('map'), mapOptions);

        var infoWindow = new google.maps.InfoWindow();

        google.maps.event.addListener($scope.map, 'click', function (e) {
            createMarkerWithLatLon(e.latLng.lat(), e.latLng.lng());
            //$scope.lat = e.latLng.lat();
            //$scope.lag = e.latLng.lng();

            //alert("Latitude: " + e.latLng.lat() + "\r\nLongitude: " + e.latLng.lng());
        });
        $http.get('/api/DriverStatus/GetDriverlocation?ctnyId=' + $scope.ctry.Id).then(function (res, data) {
            $scope.currentloc = res.data;

            $scope.currentloc.forEach(function (loc) {
                createMarker(loc);

            });

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






