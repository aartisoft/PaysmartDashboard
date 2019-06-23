// JavaScript source code
// JavaScript source code
var app = angular.module('myApp', ['ngStorage', 'ui.bootstrap', 'google-maps', 'vsGoogleAutocomplete'])
var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage, $uibModal, $document) {
    if ($localStorage.uname == null) {
        window.location.href = "login.html";
    }
    $scope.options = {
        types: ['(geocode)'],
        componentRestrictions: { country: 'FR' }
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.Roleid = $scope.userdetails[0].roleid;

    $scope.dashboardDS = $localStorage.dashboardDS;

    $scope.GetStops = function () {
        $http.get('/api/Stops/GetStops').then(function (res, data) {
            $scope.Stops = res.data;
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

            //$scope.ctry = $scope.initdata.Table1[0];

        });
    }



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



    $scope.GetPricinglist = function () {
        $scope.DistPricelist = null;

        $scope.selectedprice = parseLocation(window.location.search)['vdpid'];

        $http.get("/api/VehiclePricing/GetPricinglist?vdpid=" + $scope.selectedprice).then(function (response, req) {
            $scope.Pricelist = response.data;
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
        var request = {
            origin: $scope.directions.origin,
            destination: $scope.directions.destination,
            travelMode: google.maps.DirectionsTravelMode.DRIVING
        };
        directionsService.route(request, function (response, status) {
            if (status == google.maps.DirectionsStatus.OK) {
                directionsDisplay.setDirections(response);
                directionsDisplay.setMap($scope.map);
                // directionsDisplay.setPanel(document.getElementById('distance').innerHTML += response.routes[0].legs[0].distance.value + " meters");
                $scope.distText = response.routes[0].legs[0].distance.text;
                $scope.distval = response.routes[0].legs[0].distance.value;
                //response.routes[0].bounds["f"].b
                //17.43665
                //response.routes[0].bounds["b"].b
                //78.41263000000001


                //response.routes[0].bounds["f"].f
                //17.45654
                //response.routes[0].bounds["b"].f
                //78.44829                

                $scope.srcLat = response.routes[0].bounds["f"].b;
                $scope.srcLon = response.routes[0].bounds["b"].b;
                $scope.destLat = response.routes[0].bounds["f"].f;
                $scope.destLon = response.routes[0].bounds["b"].f;
                $scope.directions.showList = true;
            } else {
                alert('Google route unsuccesfull!');
            }

        });
    }

    var infoWindow = new google.maps.InfoWindow();

    $scope.getDirections = function () {
        //get the source latitude and longitude
        //get the target latitude and longitude
        $scope.srcLat = $scope.pickupPoint.place.geometry.location.lat();
        $scope.srcLon = $scope.pickupPoint.place.geometry.location.lng();
        //$scope.destLat = $scope.dropPoint.place.geometry.location.lat();
        //$scope.destLon = $scope.dropPoint.place.geometry.location.lng();

        $scope.srcName = $scope.pickupPoint.place.name;
        // $scope.destName = $scope.dropPoint.place.name;
        //alert($scope.dropPoint.place.geometry.location.lat);
        var request = {
            origin: new google.maps.LatLng($scope.srcLat, $scope.srcLon),//$scope.directions.origin,
            //destination: new google.maps.LatLng($scope.destLat, $scope.destLon),//$scope.directions.destination,
            travelMode: google.maps.DirectionsTravelMode.DRIVING
        };
        directionsService.route(request, function (response, status) {
            if (status == google.maps.DirectionsStatus.OK) {
                directionsDisplay.setDirections(response);
                directionsDisplay.setMap($scope.map);
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
        $scope.location();

    }

    $scope.location = function () {
        srcLat: $scope.srcLat;
        srcLon: $scope.srcLon;

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


    $scope.SaveNew = function (newStop) {
        //if (newStop == null)
        //{
        //    alert('Please Enter Name');
        //    return;
        //}
        //if ($scope.srcName == null)
        //{
        //    alert('Please Enter source');
        //    return;
        //}       
        if ($scope.srcName == null) {
            alert('Please Enter stop');
            return;
        }

        var newStop = {
            Id: -1,
            Name: $scope.srcName,
            Description: $scope.srcName,
            Code: $scope.srcName,
            srcLat: $scope.srcLat,
            srcLon: $scope.srcLon,
            //Active: (newStop.Active == true) ? 1 : 0,

            insupdflag: "I"
        }

        var req = {
            method: 'POST',
            url: '/api/Stops/saveStops',
            data: newStop
        }
        $http(req).then(function (response) {

            alert("Stop Created Successfully!");

            $scope.Group = null;
            $scope.GetStops();

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            alert(errmssg);
        });
        $scope.currGroup = null;
    };

    $scope.Stops1 = null;

    //-----------------Hidestart-------------------
    $scope.IsVisible = false;
    $scope.ShowHide = function () {
        //If DIV is visible it will be hidden and vice versa.
        $scope.IsVisible = $scope.IsVisible ? false : true;
    }
    //-----------------Hideend-------------------





    $scope.save = function (Stops, flag) {
        if (Stops == null) {
            alert('Please Enter Name');
            return;
        }
        if (Stops.Name == null) {
            alert('Please Enter Nmae');
            return;
        }
        if (Stops.Code == null) {
            alert('Please Enter Code');
            return;
        }

        var Stops = {
            Id: Stops.Id,
            Name: Stops.Name,
            Description: Stops.Description,
            Code: Stops.Code,

            Active: (Stops.Active == true) ? 1 : 0,


            insupdflag: "U"
        }

        var req = {
            method: 'POST',
            url: '/api/Stops/saveStops',
            data: Stops
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

    $scope.Stops = null;

    $scope.setStops = function (usr) {
        $scope.Stops1 = usr;
    };

    $scope.clearStops = function () {
        $scope.Stops1 = null;
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

app.controller('mapCtrl', function ($scope, $http) {

    $scope.markers = [];
    $scope.location = [];





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

    //var createMarkerWithLatLon = function (lat, long) {
    //    var marker = new google.maps.Marker({
    //        map: $scope.map,
    //        position: new google.maps.LatLng(lat, long),
    //        //title: loc.loc

    //        icon: marker
    //    });

    //    google.maps.event.addListener(marker, 'click', function () {
    //        alert();
    //        infoWindow.setContent('<h2>' + marker.title + '</h2>' + marker.content);
    //        infoWindow.setContent(marker.content);
    //        infoWindow.open($scope.map, marker);
    //    });

    //    $scope.markers.push(marker);
    //};

    var createMarker = function (loc) {
        var marker = new google.maps.Marker({
            map: $scope.map,
            position: new google.maps.LatLng(loc.Latitude, loc.Longitude),
            //title: loc.loc

            icon: marker
        });
        marker.content = '<div class="infoWindow"</div>' + 'Driver Name: ' + loc.NAme + '<br> Driver Number: ' + loc.DriverNo + '<br> Vehicle Group: ' + loc.VehicleGroupId + '</div>';;

        var infoWindow = new google.maps.InfoWindow();

        google.maps.event.addListener(marker, 'click', function () {

            infoWindow.setContent('<h2>' + marker.title + '</h2>' + marker.content);
            infoWindow.setContent(marker.content);
            infoWindow.open($scope.map, marker);
        });

        $scope.markers.push(marker);
    };



});







