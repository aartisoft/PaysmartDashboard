var app = angular.module('myApp', ['ngStorage'])
var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage) {
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
            if ($scope.Companies.length > 0) {
                $scope.cmp = $scope.Companies[0];
                $scope.GetCompanies($scope.cmp);
            }
            if ($scope.userCmpId != 1) {
                //loop throug the companies and identify the correct one
                for (i = 0; i < res.data.length; i++) {
                    if (res.data[i].Id == $scope.userCmpId) {
                        $scope.cmp = res.data[i];
                        document.getElementById('test').disabled = true;
                        break
                    }
                }
            }
            else {
                document.getElementById('test').disabled = false;
            }
           
           
        });
    }
    
   

    $scope.GetFleetOwners = function () {      

       

        if ($scope.cmp == null || $scope.cmp.Id == null)
        {
            $scope.FleetOwner = null;
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
            $scope.FleetOwner = res.data;

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
          //  $scope.getFleetOwnerRoute($scope.s);

        });
       
       // if ($scope.Fleetownerid != 1) { $scope.cmpId = $scope.UserCmpid; }
    }
    
    $scope.getFleetOwnerRoute = function () {
        if ($scope.cmp == null) {
            $scope.Companies = null;
            $scope.cmpdata = null;
            $scope.FleetOwner = null;
            return;
        }

        //if ($scope.s == null) {
        //    $scope.cmpdata = null;
        //    return;
        //}
        //var cmpId = ($scope.cmp == null || $scope.cmp.Id == null) ? -1 : $scope.cmp.Id;
        //var fId = ($scope.s == null || $scope.s.Id == null) ? -1 : $scope.s.Id;
        $http.get('/api/FleetOwner/getFleetOwner?cmpId=' + $scope.cmp.Id + '&fleetOwnerId=' + $scope.s.Id).then(function (res, data) {
            $scope.FleetOwner = res.data;
           
        });

    }
    $scope.setUsers = function (usr) {
        $scope.User1 = usr;
    };

    $scope.clearUsers = function () {
        $scope.User1 = null;
    }

    

    $scope.saveCmpChanges = function (FleetOwner) {

       
        var FleetOwner = {
            Id: FleetOwner.Id,
            FirstName: FleetOwner.FirstName,
            LastName: FleetOwner.LastName,
            MiddleName: FleetOwner.MiddleName,
           EmpNo: FleetOwner.EmpNo,
            Email: FleetOwner.Email,
            MobileNo: FleetOwner.MobileNo,
            Active: FleetOwner.Active,
            UserName: FleetOwner.UserName,
            Password: FleetOwner.Password,
            RePassword: FleetOwner.Password,
            insupdflag: 'U'


        }

        var req = {
            method: 'POST',
            url: '/api/users/saveusers',
            data:  FleetOwner
        }
       

        $http(req).then(function (response) {
            $scope.showDialog("Saved successfully")

        })
     , function (errres) {
         var errdata = errres.data;
         var errmssg = "Your details are incorrect";
         errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
         $scope.showDialog(errmssg);


         $scope.GetFleetOwner();
         $scope.User1 = null;
     };


        $scope.setCompany = function (grp) {
            $scope.User1 = grp;
        };
    }
    

    $scope.filterValue = function ($event) {
        if (isNaN(String.fromCharCode($event.keyCode))) {
            $event.preventDefault();
        }
    }; 
});




      

    

   