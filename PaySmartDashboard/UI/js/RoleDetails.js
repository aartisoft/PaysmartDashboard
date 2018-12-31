var app = angular.module('myApp', ['ngStorage', 'ui.bootstrap'])

app.directive('onFinishRender', function ($timeout) {

    return {
        restrict: 'A',
        link: function (scope, element, attr) {
            if (scope.$last === true) {
                $timeout(function () {
                    scope.$emit('ngRepeatFinished');
                });

            }
        }
    }
});

var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage, $uibModal) {
    if ($localStorage.uname == null) {
        window.location.href = "login.html";
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.Roleid = $scope.userdetails[0].roleid;

    $scope.dashboardDS = $localStorage.dashboardDS;

    //$http.get('/api/Roledetails/getroledetails').then(function (res, data) {
    //    $scope.Roledetails = res.data;
    //});

    $scope.example1model = [];
    $scope.example1data = [{ id: 1, label: "View" }, { id: 2, label: "Edit" }, { id: 3, label: "Delete" }, , { id: 4, label: "Create" }];
    $scope.example13settings = { smartButtonMaxItems: 5, smartButtonTextConverter: function (itemText, originalItem) { if (itemText === 'Jhon') { return 'Jhonny!'; } return itemText; } };

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
            $scope.initdata = res.data;
        });

        $scope.getRolesForCompany = function (seltype) {
            if (seltype == null) {
                $scope.cmproles = null;
                return;
            }
            var cmpId = (seltype) ? seltype.Id : -1;

            $http.get('/api/Roles/GetCompanyRoles?companyId=' + cmpId).then(function (res, data) {
                $scope.cmproles = res.data;
            });
        }

    }

    $scope.getRoleDetails = function (r) {
        if (r == null) {
            $scope.roleobjects = null;
            return;
        }
        var cmpId = (r) ? r.id : -1;

        $http.get('/api/RoleDetails/GetRoleDetails?roleId=' + cmpId).then(function (res, data) {
            $scope.roleobjects = res.data.Table;
        });
    }

    $scope.save = function (Roledetails) {
        alert("ok");
        var Roledetails = {
            ObjectName: Roledetails.ObjectName,
            Path: Roledetails.Path,
         

        }

        var req = {
            method: 'POST',
            url: '/api/Roledetails/saveroledetails',
            data: Roledetails
        }
        $http(req).then(function (response) {

            //$scope.showDialog("Saved successfully!");

            $scope.Group = null;

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "";
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

    $scope.$on('ngRepeatFinished', function (ngRepeatFinishedEvent) {
        //you also get the actual event object
        //do stuff, execute functions -- whatever...
        //alert("ng-repeat finished");
        $("#example-advanced").treetable({ initialState: 'expanded', expandable: true }, true);
        $("#example-advanced tbody tr:first").toggleClass("selected");


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






