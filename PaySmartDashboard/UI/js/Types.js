// JavaScript source code
var myapp1 = angular.module('myApp', ['ngStorage', 'ui.bootstrap'])
var mycrtl1 = myapp1.controller('myCtrl', function ($scope, $http, $localStorage, $uibModal) {
    if ($localStorage.uname == null) {
        window.location.href = "login.html";
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.Roleid = $scope.userdetails[0].roleid;
    $scope.page = 1;
    $scope.pagesize = $localStorage.pagesize;
    $scope.dashboardDS = $localStorage.dashboardDS;
    $http.get('/api/typegroups/gettypegroups').then(function (res, data) {
        $scope.TypeGroups = res.data;
        $scope.getselectval();

    });

    $scope.getselectval = function (seltype, flag) {
        var grpid = (seltype) ? seltype.Id : -1;
        var curpage = $scope.page;
        if (flag == 'n') {
            $scope.page++;
            curpage = $scope.page;
        } else if (flag == 'p') {
            $scope.page--
            curpage = $scope.page;
        }
        else {
            $scope.page = 1;
            curpage = $scope.page;
        }

        $http.get('/api/Types/TypesPaging?groupid=' + grpid + '&curpage=' + curpage + '&maxrows=' + 10).then(function (res, data) {
            $scope.Types = res.data.Table;
            $scope.paging = res.data.Table1;

            ///loop to fill seltype
        });

        // $scope.selectedvalues = 'Name: ' + $scope.selitem.name + ' Id: ' + $scope.selitem.Id;

    }


    $scope.save = function (Types) {

        if (Types == null) {
            alert('Please enter name.');
            return;
        }

        if (Types.Name == null) {
            alert('Please enter name.');


            return;
        }
        if (Types.TypeGroupId == null) {
            alert('Please select a type group');
            return;
        }

        var Types = {

            Id: Types.Id,
            Name: Types.Name,
            Description: Types.Description,
            Active: Types.Active,
            TypeGroupId: Types.TypeGroupId,
            ListKey: Types.ListKey,
            Listvalue: Types.Listvalue,
            insupddelflag: 'U'
        };

        var req = {
            method: 'POST',
            url: '/api/Types/SaveType',
            //headers: {
            //    'Content-Type': undefined
            data: Types
        }

        $http(req).then(function (response) {

            alert("Saved successfully!");



            $scope.Group = null;

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            $scope.showDialog(errmssg);
        });
        $scope.currGroup = null;
    };


    $scope.saveNewType = function (newType) {

        if (newType == null) {
            alert('Please enter name.');
            return;
        }

        if (newType.Name == null) {
            alert('Please enter name.');
            return;
        }

        if (newType.group == null || newType.group.Id == null) {
            alert('Please select a type group');
            return;
        }

        var newTypeData = {

            Id: '-1',
            Name: newType.Name,
            Description: newType.Description,
            Active: 1,//newType.Active,
            TypeGroupId: newType.group.Id,
            ListKey: newType.ListKey,
            Listvalue: newType.Listvalue,
            insupddelflag: 'I'
        };

        var req = {
            method: 'POST',
            url: '/api/Types/SaveType',
            data: newTypeData
        }

        $http(req).then(function (response) {

            alert("Saved successfully!");


            $scope.Group = null;

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            alert(errmssg);
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




    $scope.setCompany = function (grp) {
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