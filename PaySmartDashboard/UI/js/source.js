var app = angular.module('myApp', ['ngStorage', 'ui.bootstrap']);
var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage, $interval) {
    if ($localStorage.uname == null) {
        window.location.href = "login.html";
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
            center: new google.maps.LatLng(lat,long), //17.8252° S, 31.0335° E
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

        $http.get('/api/dashboard/getdashboard?userid=-1&roleid=' + roleid + '&ctryId=' + $scope.nn.Id).then(function (res, data) {
            
            $scope.dashboardDS = res.data;
            $localStorage.dashboardDS = res.data;            
        });
        
    //   $scope.GetConfigData();
     
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
            $scope.GetDashboardDS();
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
    $interval(function(){
        if($scope.activeRefresh){
            $scope.GetDashboardDS();
          //$scope.mssg = 'this is call no:'+ $scope.c++;
        }
    },10000);
    $scope.$on('$destroy', function() {
        $scope.activeRefresh = false; // STOP THE REFRESH
    });

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



    //$scope.currentlocation = function () {
    //    $http.get('/api/DriverStatus/GetDriverlocation').then(function (res, data) {
    //       $scope.currentloc = res.data;          
    //       $scope.CenterMap();
    //    });
        
    //}


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
        $http.get('/api/DriverStatus/GetDriverlocation?ctnyId='+$scope.ctry.Id).then(function (res, data) {
            $scope.currentloc = res.data;
            
            $scope.currentloc.forEach(function (loc) {
                createMarker(loc);
            });
            
        });

        
    }   
    
    var createMarkerWithLatLon = function (lat,long) {
        var marker = new google.maps.Marker({
            map: $scope.map,
            position: new google.maps.LatLng(lat, long),
            //title: loc.loc

            icon: marker
        });
       
        google.maps.event.addListener(marker, 'click', function () {
            alert();
            infoWindow.setContent('<h2>' + marker.title + '</h2>' + marker.content);
            infoWindow.setContent(marker.content);
            infoWindow.open($scope.map, marker);
        });

        $scope.markers.push(marker);
    };

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



//JAGAN UPDATED START
var mycrtl1 = app.controller('myCtrl1', function ($scope, $http, $localStorage, $uibModal) {
    if ($localStorage.uname == null) {
        window.location.href = "login.html";
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.userCmpId = $scope.userdetails[0].CompanyId;
    $scope.userSId = $scope.userdetails[0].UserId;
    $scope.Roleid = $scope.userdetails[0].roleid;

    $scope.dashboardDS = $localStorage.dashboardDS;



    $scope.GetCompanies = function () {

        $http.get('/api/GetCompanyGroups?userid=-1').then(function (res, data) {
            $scope.Companies = res.data;
            $scope.Companies1 = res.data;


            if ($scope.userCmpId != 1) {
                //loop throug the companies and identify the correct one
                for (i = 0; i < res.data.length; i++) {
                    if (res.data[i].Id == $scope.userCmpId) {
                        $scope.cmp = res.data[i];
                        document.getElementById('test').disabled = true;
                        break
                    }
                }
                // $scope.GetFleetOwners();
            }
            else {
                document.getElementById('test').disabled = false;
            }
            $scope.GetFleetOwners($scope.cmp);
        });

    }



    $scope.GetFleetOwners = function () {



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
            $scope.cmpdata = res.data;
            $scope.showdialogue("Saved successfully")


            if ($scope.userSId != 1) {
                //loop throug the fleetowners and identify the correct one
                for (i = 0; i < res.data.Table.length; i++) {
                    if (res.data.Table[i].UserId == $scope.userSId) {
                        $scope.s = res.data.Table[i];
                        document.getElementById('test1').disabled = true;
                        break
                    }
                }
            }
            else {
                document.getElementById('test1').disabled = false;
            }
            $scope.GetFleetStaff($scope.s);

        });
    }

    $scope.getUsersnRoles = function () {
        var s = $scope.cmp;

        if (s == null) {
            $scope.userRoles = null;
            return;
        }
        var cmpId = (s == null) ? -1 : s.Id;

       
        $http.get('/api/Users/GetUserRoles?cmpId=' + $scope.cmp.Id).then(function (res, data) {
            $scope.userRoles = res.data;
        });
    }

    $scope.savenewfleetStaffdetails = function () {
        var newVD = $scope.f;
        if (newVD == null) {
            alert('Please select VehicleRegNo.');
            return;
        }

        if (newVD.Id == null) {
            alert('Please select VehicleRegNo.');
            return;
        }
        //validate user, company and role also      


        var Fleet = {
            Id: -1,
            vehicleId: newVD.Id,
            roleId: newVD.uu.RoleId,
            UserId: newVD.uu.Id,
            cmpId: $scope.cmp.Id,
            FromDate: newVD.fd,
            ToDate: newVD.td,
            // Active:1,
            insupddelflag: 'I'
        };


        var req = {
            method: 'POST',
            url: '/api/FleetStaff/NewFleetStaff',
            //headers: {
            //    'Content-Type': undefined

            data: Fleet
        }

        $http(req).then(function (response) {

            $scope.showDialog("Saved successfully!");

            $scope.Group = null;

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "Your details are incorrect";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            $scope.showDialog(errmssg);
        });
        $scope.currGroup = null;
    };
    $scope.savefleetStaff = function () {
        var FleetStaff = $scope.f1;
        if (FleetStaff == null) {
            alert('Please select VehicleRegNo.');
            return;
        }

        if (FleetStaff.Id == null) {
            alert('Please select VehicleRegNo.');
            return;
        }


        var FleetS = {

            Id: -1,
            vehicleId: FleetStaff.Id,
            roleId: FleetStaff.uu.RoleId,
            UserId: FleetStaff.uu.Id,
            cmpId: $scope.cmp.Id,
            FromDate: FleetStaff.fd,
            ToDate: FleetStaff.td,
            // Active:1,
            insupddelflag: 'U'
        };

        var req = {
            method: 'POST',
            url: '/api/FleetStaff/NewFleetStaff',
            //headers: {
            //    'Content-Type': undefined

            data: FleetS


        }
        $http(req).then(function (res) {
            $scope.showDialog("Updated successfully!");
            GetFleetDetails();
        });


    }
    //jagan updated on 10-08-2017 start
    $scope.GetVehicleConfig = function () {

        var vc = {
            // needfleetowners:'1',
            //needvehicleType: '1',
            //needServiceType: '1',
            //needCompanyName: '1',
            //needVehicleMake: '1',
            needVehicleGroup: '1',
        };

        var req = {
            method: 'POST',
            url: '/api/VehicleConfig/VConfig',
            //headers: {
            //    'Content-Type': undefined

            data: vc


        }
        $http(req).then(function (res) {
            $scope.initdata = res.data;
        });

    }

    

    $scope.GetFleetStaff = function () {
        if ($scope.cmp == null || $scope.cmp.Id == null) {
            $scope.FleetStaff = null;
            return;
        }

        if ($scope.s == null || $scope.s.Id == null) {
            $scope.FleetStaff = null;
            return;
        }

        $http.get('/api/FleetStaff/GetFleetStaff?foId=' + $scope.s.Id + '&cmpId=' + $scope.cmp.Id).then(function (res, data) {
            $scope.FleetStaff = res.data;
        });
    }


    $scope.setFleet = function (Fleet) {
        $scope.currFleet = Fleet;
    };
    $scope.testdel = function (Fleet) {
        var FRoutes = {

            Id: -1,
            vehicleId: Fleet.Id,
            roleId: Fleet.RoleId,
            UserId: Fleet.UserId,
            cmpId: $scope.cmp.Id,
            FromDate: Fleet.fd,
            ToDate: Fleet.td,
            // Active:1,
            insupddelflag: 'D'
        };

        var req = {
            method: 'POST',
            url: '/api/FleetStaff/NewFleetStaff',
            data: FRoutes
        }
        $http(req).then(function (response) {
            $scope.showdialogue("Saved successfully")

            $http.get('/api/FleetStaff/GetFleetStaff?roleid=' + Fleet.RoleId).then(function (res, data) {
                $scope.FleetStaff = res.data;
            });

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



});







