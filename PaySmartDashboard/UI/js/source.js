var app = angular.module('myApp', ['google-maps','ngStorage', 'ui.bootstrap']);
var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage, $interval, $rootScope) {
    if ($localStorage.uname == null) {
        window.location.href = "login.html";
    }

    $rootScope.spinner = {
        active: false,
        on: function () {
            this.active = true;
        },
        off: function () {
            this.active = false;
        }

    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.Roleid = $scope.userdetails[0].roleid;
    //$scope.canShow = ($scope.Roleid == 1 || $scope.roleid == 6 || $scope.roleid == 13);

    $scope.GetCountry = function () {

        $http.get('/api/Users/GetCountry?active=1').then(function (response, req) {
            $scope.Countries = response.data;

        });
    }

    $scope.GetDemoRequest = function () {
        $http.get('/api/DemoRequest/GetDemoRequest').then(function (response, req) {
            $scope.demoreq = response.data;

        });
    }
        
    $scope.GetFleetDetails = function () {

        if ($scope.cmp == null) {
            $scope.cmpdata = null;
            return;
        }

        if ($scope.s == null) {
            $scope.Fleet = null;
            return;
        }

        $http.get('/api/Fleet/getFleetList?cmpId=' + $scope.cmp.Id + '&fleetOwnerId=' + $scope.s.Id).then(function (res, data) {
            $scope.Fleet = res.data.Table;
        });
    }

    $scope.GetCompanies = function () {

        var vc = {
            needCompanyName: '1'
        };

        var req = {
            method: 'POST',
            url: '/api/VehicleConfig/VConfig',
            //headers: {
            //    'Content-Type': undefined
            data: vc
        }
        $http(req).then(function (res) {
            //$scope.initdata = res.data;
            $scope.companies = res.data;
        });

    }

    $scope.GetFleetOwners = function () {
        if ($scope.cmp == null) {
            $scope.cmpdata = null;
            $scope.Fleet = null;
            return;
        }
        var vc = {
            needfleetowners: '1',
            cmpId: $scope.cmp.Id
        };

        var req = {
            method: 'POST',
            url: '/api/VehicleConfig/VConfig',
            //headers: {
            //    'Content-Type': undefined

            data: vc


        }
        $http(req).then(function (res) {
            $scope.cmpdata = res.data.Table;
        });
    }

    $scope.displocations = function () {
        var maplocations = $scope.locations;

        var map = new google.maps.Map(document.getElementById('gmap_canvas'), {
            zoom: 15,
            center: new google.maps.LatLng(lat, long), //17.8252° S, 31.0335° E
            mapTypeId: google.maps.MapTypeId.ROADMAP
        });


        var infowindow = new google.maps.InfoWindow();


        var marker, i;


        for (i = 0; i < maplocations.length; i++) {
            marker = new google.maps.Marker({
                position: new google.maps.LatLng(maplocations[i]['Xcoordinate'], maplocations[i]['Ycoordinate']),
                map: map
            });


            google.maps.event.addListener(marker, 'click', (function (marker, i) {
                return function () {
                    infowindow.setContent(maplocations[i][0]);
                    infowindow.open(map, marker);
                }
            })(marker, i));
        }

    }
    
    $scope.getBTPOSMonitoring = function () {
        $http.get('/api/BTPOSMonitoringPage/GetBTPOSMonitoring').then(function (response, data) {
            $scope.BTPOSMonitoring = response.data;

            $scope.locations = response.data;
            $scope.displocations();
        });
    }
    
    $scope.GetDashboardDS = function () {
        //retive the userid and roleid
        var roleid = $localStorage.userdetails[0].roleid;
        $rootScope.spinner.on();
        $http.get('/api/dashboard/getdashboard?userid=-1&roleid=' + roleid + '&ctryId=' + $scope.nn.Id).then(function (res, data) {

            $scope.dashboardDS = res.data;
            $localStorage.dashboardDS = res.data;

           // $scope.GetDemoRequest();
            $rootScope.spinner.off();
        }, function (errres) {
            // alert(errres);
            $rootScope.spinner.off();
        });
    }

    $scope.GetConfigData = function () {

        var vc = {
            includeActiveCountry: '1',
            includeVehicleGroup: '1',
            includeFleetOwner: '1'

        };

        var req = {
            method: 'POST',
            url: '/api/Types/ConfigData',
            data: vc
        }

        $http(req).then(function (res) {
            $scope.initdata = res.data;
            $scope.nn = $scope.initdata.Table1[0];
            $scope.ctry = $scope.initdata.Table1[0];

            $scope.GetDashboardDS();
            $scope.CenterMap($scope.ctry);
        });

    }

    $scope.myVar = false;
    $scope.toggle = function () {
        $scope.myVar = !$scope.myVar;
        document.getElementById('btposstatus').innerHTML = ($scope.myVar) ? "Hide" : "Show";
    };
    $scope.show = function () {

    }

    $scope.GetInventoryItems = function () {
        $scope.Group = null;
        $http.get('/api/InventoryItem/GetInventoryItem?subCatId=1').then(function (response, req) {
            $scope.InventoryItem = response.data;

        });
    }

    $scope.savepurchases = function (Group) {
        if (Group == null) {
            alert('please select Item')
            return;
        }
        if (Group.Item.ItemName == null) {
            alert('please enter Item name')
            return;
        }
        if (Group.PerUnitPrice == null) {
            alert('please enter the Per Unit Price');
            return;
        }
        if (Group.Quantity == null) {
            alert('please enter the quantity');
            return;
        }
        if (Group.PurchaseOrderNumber == null) {
            alert('please enter Purchase Order Number');
            return;
        }

        if (Group.PurchaseDate == null) {
            alert('please enter the purchase order date');
            return;
        }
        var Group = {
            Id: -1,
            ItemName: Group.Item.ItemName,
            subCategoryId: Group.Item.SubCategoryId,
            Quantity: Group.Quantity,
            PerUnitPrice: Group.PerUnitPrice,
            PurchaseDate: Group.PurchaseDate,
            PurchaseOrderNumber: Group.PurchaseOrderNumber,
            ItemTypeId: Group.Item.Id
        }

        var req = {
            method: 'POST',
            url: '/api/InventoryPurchase/SaveInventoryPurchases',
            data: Group
        }
        $http(req).then(function (response) {

            $scope.showDialog("Saved successfully! ");

            $scope.Group = null;
            //  $scope.FirstPage();

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "Your details are incorrect";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            $scope.showDialog(errmssg);
        });
        $scope.currGroup = null;
    };

    $scope.SendDemoMail = function (d) {

        var demo = {

            Id: d.Id,
            email: d.Email,
            Mobile: d.MobileNumber,
            statusid: d.Status,
            flag: 'U',
        }

        var req = {
            method: 'POST',
            url: '/api/DemoRequest/SaveDemoDetails',
            data: demo
        }
        $http(req).then(function (response) {
            alert("Saved successfully! ");
            $scope.GetDemoRequest();

            $scope.Group = null;
            // $scope.FirstPage();

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "Your details are incorrect";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            $scope.showDialog(errmssg);
        });
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

    $scope.activeRefresh = true;
    $scope.c = 0;
    $interval(function () {
        if ($scope.activeRefresh) {
            $scope.GetDashboardDS();
            //$scope.mssg = 'this is call no:'+ $scope.c++;
        }
    }, 10000);
    $scope.$on('$destroy', function () {
        $scope.activeRefresh = false; // STOP THE REFRESH
    });


    $scope.CenterMap = function (ctry) {

    //get the source latitude and longitude
    //get the target latitude and longitude
    $scope.srcLat = (ctry.Latitude == null) ? 17.499800 : ctry.Latitude;
    $scope.srcLon = (ctry.Longitude == null) ? 78.399597 : ctry.Longitude;
        
   
    var LatLng = new google.maps.LatLng($scope.srcLat, $scope.srcLon);
    var mapOptions = {
        center: LatLng,
        zoom: 10,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };
    var map = new google.maps.Map(document.getElementById("dvMap1"), mapOptions);
    var infowindow = new google.maps.InfoWindow;
    var geocoder = new google.maps.Geocoder;
    var marker = new google.maps.Marker({
        position: LatLng,
        map: map,
        title: "<div style = 'height:60px;width:200px'><b>Your location:</b><br />Latitude: " + $scope.srcLat + "<br />Longitude: " + $scope.srcLon
    });
    geocodeLatLng($scope.srcLat + ',' + $scope.srcLon, geocoder, map, infowindow);
    function geocodeLatLng(dd, geocoder, map, infowindow) {
        //var input = document.getElementById('latlng').value;
        var latlngStr = dd.split(',', 2);
        var latlng = { lat: parseFloat(latlngStr[0]), lng: parseFloat(latlngStr[1]) };
        geocoder.geocode({ 'location': latlng }, function (results, status) {
            if (status === 'OK') {
                if (results[0]) {
                    //map.setZoom(11);
                    var marker = new google.maps.Marker({
                        position: latlng,
                        map: map
                    });
                    infowindow.setContent(results[0].formatted_address);
                    infowindow.open(map, marker);
                  //  d = results[0].formatted_address;
                  //  document.getElementById("editdrop").value = d;
                  //  document.getElementById("dropPoint").value = d;
                   // $scope.droppoint_name = d;
                    //$scope.pickupPoint_name = d;
                    //$scope.pickupPoint_name1 = d;
                } else {
                    window.alert('No results found');
                }
            } else {
                window.alert('Geocoder failed due to: ' + status);
            }
        });
    }

    google.maps.event.addListener(marker, "click", function (e) {
        var infoWindow = new google.maps.InfoWindow();
        infoWindow.setContent(marker.title);
        infoWindow.open(map, marker);

    });   
}
  
        function mapOld() {

            //$scope.currentlocation = function () {
            //    $http.get('/api/DriverStatus/GetDriverlocation').then(function (res, data) {
            //       $scope.currentloc = res.data;          
            //       $scope.CenterMap();
            //    });

            //}


            //$scope.CenterMap = function (ctry) {
            //    var lat = (ctry.Latitude == null) ? 17.499800 : ctry.latitude;
            //    var long = (ctry.Longitude == null) ? 78.399597 : ctry.longitude;
            //    var mapOptions = {
            //        zoom: 15,
            //        center: new google.maps.LatLng(lat, long),
            //        mapTypeId: google.maps.MapTypeId.ROADMAP
            //    }

            //    $scope.map = new google.maps.Map(document.getElementById('map'), mapOptions);

            //    var infoWindow = new google.maps.InfoWindow();
            //    infoWindow.open($scope.map, null);
            //    //google.maps.event.addListener($scope.map, 'click', function (e) {
            //    //    createMarkerWithLatLon(e.latLng.lat(), e.latLng.lng());
            //    //    //$scope.lat = e.latLng.lat();
            //    //    //$scope.lag = e.latLng.lng();

            //    //    //alert("Latitude: " + e.latLng.lat() + "\r\nLongitude: " + e.latLng.lng());
            //    //});
            //    //$http.get('/api/DriverStatus/GetDriverlocation?ctnyId=' + $scope.ctry.Id).then(function (res, data) {
            //    //    $scope.currentloc = res.data;

            //    //    $scope.currentloc.forEach(function (loc) {
            //    //        createMarker(loc);
            //    //    });

            //    //});


            //}

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

            //var createMarker = function (loc) {
            //    var marker = new google.maps.Marker({
            //        map: $scope.map,
            //        position: new google.maps.LatLng(loc.Latitude, loc.Longitude),
            //        //title: loc.loc

            //        icon: marker
            //    });
            //    marker.content = '<div class="infoWindow"</div>' + 'Driver Name: ' + loc.NAme + '<br> Driver Number: ' + loc.DriverNo + '<br> Vehicle Group: ' + loc.VehicleGroupId + '</div>';;

            //    var infoWindow = new google.maps.InfoWindow();

            //    google.maps.event.addListener(marker, 'click', function () {

            //        infoWindow.setContent('<h2>' + marker.title + '</h2>' + marker.content);
            //        infoWindow.setContent(marker.content);
            //        infoWindow.open($scope.map, marker);
            //    });

            //    $scope.markers.push(marker);
            //};
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







