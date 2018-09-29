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
    $http.get('/api/typegroups/gettypegroups').then(function (res, data) {
        $scope.TypeGroups = res.data;
    });

    $scope.save = function (TypeGroup) {
      
        if (TypeGroup == null) {
            alert('Please enter name.');
            return;
        }

        if (TypeGroup.Name == null) {
            alert('Please enter name.');
            return;
        }

        var SelTypeGroup = {
            Name: TypeGroup.Name,
            Description: TypeGroup.Description,
            Active: TypeGroup.Active,
            Update: TypeGroup.Update,
            Id: TypeGroup.Id,
            insupddelflag:'U'
        };

        var req = {
            method: 'POST',
            url: '/api/typegroups/savetypegroups',
            //headers: {
            //    'Content-Type': undefined
            data: SelTypeGroup
        }
        $http(req).then(function (response) {

            alert("Saved successfully!");

            $scope.Group = null;

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "TypeGroup is Not Saved";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            alert(errmssg);
        });
        $scope.TypeGroups();
        $scope.currGroup = null;

    };


    $scope.saveNew = function (TypeGroup) {

        if (TypeGroup == null) {
            alert('Please enter name.');
            return;
        }

        if (TypeGroup.Name == null) {
            alert('Please enter name.');
            return;
        }

        var SelTypeGroup = {
            Name: TypeGroup.Name,
            Description: TypeGroup.Description,
            Active: TypeGroup.Active,
            Update: TypeGroup.Update,
            Id: -1,
            insupddelflag:'I'
        };

        var req = {
            method: 'POST',
            url: '/api/typegroups/savetypegroups',
            //headers: {
            //    'Content-Type': undefined
            data: SelTypeGroup
        }
        $http(req).then(function (response) {
            $scope.Group = null;

            alert("Saved successfully!");

            

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "Your details are incorrect";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            alert(errmssg);
        });       
        $scope.currGroup = null;
    };


    $scope.setTypeGroup = function (grp) {
        $scope.currGroup = grp;
    };

    $scope.clearGroup = function () {
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




