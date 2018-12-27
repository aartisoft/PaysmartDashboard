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

    $scope.GetVehiclePrices = function () {
        $http.get('/api/VehiclePricing/GetVehiclePrices').then(function (res, data) {
            $scope.pricedetails = res.data;
        });
    }

    $scope.saveNewprice = function (price) {
        if (price == null) {
            alert('Please Enter Name');
            return;
        }
        if (price.SrNo == null) {
            alert('Please Enter SrNo');
            return;
        }
        if (price.Duration == null) {
            alert('Please Enter Duration');
            return;
        }
        if (price.KiloMtr == null) {
            alert('Please Enter KiloMtr');
            return;
        }
        if (price.IndicaRate == null) {
            alert('Please Enter IndicaRate');
            return;
        }
        if (price.IndigoRate == null) {
            alert('Please Enter IndigoRate');
            return;
        }
        if (price.InnovaRate == null) {
            alert('Please Enter InnovaRate');
            return;
        }
        if (price.Tag == null) {
            alert('Please Enter Tag');
            return;
        }
      

        var price = {
            SrNo:price.SrNo,
            Duration: price.Duration,
            Description: price.Description,
            KiloMtr: price.KiloMtr,
            IndicaRate: price.IndicaRate,
            IndigoRate: price.IndigoRate,
            InnovaRate: price.InnovaRate,
            Tag: price.Tag,

            Active: (price.Active == true) ? 1 : 0,

           
        }

        var req = {
            method: 'POST',
            url: '/api/VehiclePricing/VehiclePrices',
            data: price
        }
        $http(req).then(function (response) {

            alert("Saved successfully!");

            $scope.Group = null;

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "Your Details Are Not Saved";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            $scope.showDialog(errmssg);
        });
        $scope.currGroup = null;
    };

    $scope.pricing = null;


    $scope.save = function (pricing, flag) {
        if (pricing == null) {
            alert('Please Enter Name');
            return;
        }
        if (pricing.SrNo == null) {
            alert('Please Enter SrNo');
            return;
        }
        if (pricing.Duration == null) {
            alert('Please Enter Duration');
            return;
        }
        if (pricing.KiloMtr == null) {
            alert('Please Enter KiloMtr');
            return;
        }
        if (pricing.IndicaRate == null) {
            alert('Please Enter IndicaRate');
            return;
        }
        if (pricing.IndigoRate == null) {
            alert('Please Enter IndigoRate');
            return;
        }
        if (pricing.InnovaRate == null) {
            alert('Please Enter InnovaRate');
            return;
        }
        if (pricing.Tag == null) {
            alert('Please Enter Tag');
            return;
        }

        var pricing = {
            SrNo: pricing.SrNo,
            Duration: pricing.Duration,
            Description: pricing.Description,
            KiloMtr: pricing.KiloMtr,
            IndicaRate: pricing.IndicaRate,
            IndigoRate: pricing.IndigoRate,
            InnovaRate: pricing.InnovaRate,
            Tag: pricing.Tag,

            Active: (pricing.Active == true) ? 1 : 0,

            flag: "U"

        }

        var req = {
            method: 'POST',
            url: '/api/VehiclePricing/VehiclePrices',
            data: pricing
        }
        $http(req).then(function (response) {

            alert("Updated successfully!");

            $scope.Group = null;

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "Your Details Are Not Updated";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            $scope.showDialog(errmssg);
        });
        $scope.currGroup = null;
    };

    $scope.pricing = null;

    $scope.setpricedetails = function (usr) {
        $scope.pricing = usr;
    };

    $scope.clearprice = function () {
        $scope.pricing = null;
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








