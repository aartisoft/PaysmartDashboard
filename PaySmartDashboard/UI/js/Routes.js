// JavaScript source code

var myapp1 = angular.module('myApp', ['ngStorage', 'ui.bootstrap', 'google-maps', 'vsGoogleAutocomplete'])
var mycrtl1 = myapp1.controller('myCtrl', function ($scope, $http, $localStorage, $uibModal) {
    if ($localStorage.uname == null) {
        window.location.href = "login.html";
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.Roleid = $scope.userdetails[0].roleid;

    $scope.dashboardDS = $localStorage.dashboardDS;
    $scope.GetRoutes = function () {
        $http.get('/api/Routes/GetRoutes').then(function (res, data) {
            $scope.routes = res.data;
        });
    }
    //This will hide the DIV by default.
    $scope.IsVisible = false;
    $scope.ShowHide = function () {
        //If DIV is visible it will be hidden and vice versa.
        $scope.IsVisible = $scope.ShowPassport;
    }
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

    //$scope.myVar = false;
    //$scope.toggle = function () {
    //    $scope.myVar = !$scope.myVar;
    //};
    $scope.save = function (routes) {

        if (routes == null) {
            alert('Please enter Route');
            return;
        }
        if (routes.RouteName == null) {
            alert('plaease enter Route');
            return;

        }

        if (routes.Code == null) {
            alert('Please enter Code');
            return;
        }

        if ($scope.src.Id == null) {
            alert('Please enter Source');
            return;
        }

        if ($scope.dest.Id == null) {
            alert('Please enter Destination');
            return;
        }

        if ($scope.distval == null) {
            alert('Please enter Distance');
            return;
        }


        var newroute = {
            RouteName: routes.RouteName,
            Code: routes.Code,
            Description: routes.Description,
            Active: 1,//(routes.Active==true)?1:0,
            //BTPOSGroupId: routes.BTPOSGroupId,
            SourceId: $scope.src.Id,
            DestinationId: $scope.dest.Id,
            Distance: $scope.distval
        };

        var req = {
            method: 'POST',
            url: '/api/Routes/SaveRoutes',
            //headers: {
            //    'Content-Type': undefined
            data: newroute
        }

        $http(req).then(function (res) {
            alert('Route created successfully');
            $scope.GetRoutes();
        });

        //insert the return route details if provided
        var needReturnRoute = document.getElementById('rtn').checked;

        if (needReturnRoute) {
            var retroutes = {
                RouteName: routes.ReturnRouteName,
                Code: routes.ReturnCode,
                Description: routes.Description,
                Active: 1,//(routes.Active==true)?1:0,
                //BTPOSGroupId: routes.BTPOSGroupId,
                SourceId: routes.Destination.Id,
                DestinationId: routes.Source.Id,
                Distance: routes.Distance
            };

            var req = {
                method: 'POST',
                url: '/api/Routes/SaveRoutes',
                //headers: {
                //    'Content-Type': undefined
                data: retroutes
            }

            $http(req).then(function (res) {
                // alert('Route created successfully');
            });
        }
        $http(req).then(function (response) {

            // $scope.showDialog("Saved successfully!");

            $scope.Group = null;

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            $scope.showDialog(errmssg);
        });
        $scope.currGroup = null;
    };
    //    alert('saved successfully.');
    //    $scope.routes = null;


    //};

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
        $scope.srcLat = $scope.src.Latitude;
        $scope.srcLon = $scope.src.Longitude;
        $scope.destLat = $scope.dest.Latitude;
        $scope.destLon = $scope.dest.Longitude;

        $scope.srcName = $scope.src.Id;
        $scope.destName = $scope.dest.Id;
        //alert($scope.dropPoint.place.geometry.location.lat);
        var request = {
            origin: new google.maps.LatLng($scope.srcLat, $scope.srcLon),//$scope.directions.origin,
            destination: new google.maps.LatLng($scope.destLat, $scope.destLon),//$scope.directions.destination,
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

    }

    $scope.SetTotal = function () {
        $scope.total = eval($scope.unitprice) * eval($scope.distval);
    }

    //-----------------Hidestart-------------------
    $scope.IsVisible = false;
    $scope.ShowHide = function () {
        //If DIV is visible it will be hidden and vice versa.
        $scope.IsVisible = $scope.IsVisible ? false : true;
    }
    //-----------------Hideend-------------------

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
        //$http.get('/api/DriverStatus/GetDriverlocation?ctnyId=' + $scope.ctry.Id).then(function (res, data) {
        //    $scope.currentloc = res.data;

        //    $scope.currentloc.forEach(function (loc) {
        //        createMarker(loc);
        //    });

        //});

        $scope.createMarker();
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
    //var map;
    //$(document).ready(function () {
    //    prettyPrint();
    //    map = new GMaps({
    //        div: '#map',
    //        lat: -12.043333,
    //        lng: -77.028333
    //    });
    //    map.setContextMenu({
    //        control: 'map',
    //        options: [{
    //            title: 'Add marker',
    //            name: 'add_marker',
    //            action: function (e) {
    //                this.addMarker({
    //                    lat: e.latLng.lat(),
    //                    lng: e.latLng.lng(),
    //                    title: 'New marker'
    //                });
    //                this.hideContextMenu();
    //            }
    //        }, {
    //            title: 'Center here',
    //            name: 'center_here',
    //            action: function (e) {
    //                this.setCenter(e.latLng.lat(), e.latLng.lng());
    //            }
    //        }]
    //    });
    //});

    $scope.SetMap = function () {
        $scope.map = new GMaps({
            div: '#map',
            lat: -20.1325066,
            lng: 28.626479000000018,
            enableNewStyle: true
        });

        $scope.map.setContextMenu({
            control: 'map',
            options: [{
                title: 'Add Stop',
                name: 'add_marker',
                action: function (e) {

                    this.addMarker({
                        lat: e.latLng.lat(),
                        lng: e.latLng.lng(),
                        title: 'New marker'
                        //,icon : {
                        //    size : new google.maps.Size(32, 32),
                        //    url : icon
                        //}
                       , click: function (e) {
                           if (console.log)
                               console.log(e);
                           alert('You clicked in this marker');
                       }

                    });
                }
            }, {
                title: 'Center here',
                name: 'center_here',
                action: function (e) {
                    this.setCenter(e.latLng.lat(), e.latLng.lng());
                }
            }]
        });

        // angular.getElementById('map') = $scope.map;
        //lat : item.location.lat,
        //lng : item.location.lng,
        //title : item.name,
        //icon : {
        //    size : new google.maps.Size(32, 32),
        //    url : icon
        //}




    }

    $scope.test = function () {
        alert();
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
