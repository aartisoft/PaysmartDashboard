var app = angular.module('myApp1', ['ngStorage', 'ui.bootstrap'])

var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage, $uibModal) {

    $scope.GetDistanceBasePricing = function () {
        var countryId = $scope.ct.Id;
        if (countryId == null) return;

        var vgId = $scope.vg.Id;
        if (vgId == null) return;

        $http.get('/api/VehicleDistPricing/GetDistanceBasePricing?ctryId=' + countryId + '&vgId=' + vgId).then(function (response, req) {
            $scope.VPricing = response.data;

            for (i = 0; i < $scope.initdata.Table.length; i++) {
                if ($scope.initdata.Table[i].Id == $scope.VPricing[0].VehicleGroupId) {
                    $scope.v = $scope.initdata.Table[i];
                    break;
                }
            }
            for (i = 0; i < $scope.initdata.Table1.length; i++) {
                if ($scope.initdata.Table1[i].Id == $scope.VPricing[0].PricingType) {
                    $scope.PricingType = $scope.initdata.Table1[i];
                    break;
                }
            }
            for (i = 0; i < $scope.initdata.Table2.length; i++) {
                if ($scope.initdata.Table2[i].Id == $scope.VPricing[0].VehicleTypeId) {
                    $scope.vt = $scope.initdata.Table2[i];
                    break;
                }
            }
            for (i = 0; i < $scope.initdata.Table3.length; i++) {
                if ($scope.initdata.Table3[i].Id == $scope.VPricing[0].CountryId) {
                    $scope.c = $scope.initdata.Table3[i];
                    break;
                }
            }
            
        });
    }
    $scope.SavePricing = function (Dist, flag) {

        if (Dist == null) {
            alert('Please enter Pricing.');
            return;
        }
        if ($scope.vt.Id == null || $scope.vt.Id == "") {
            alert('Please enter VehicleType.');
            return;
        }
        if (Dist.FromKm == null || Dist.FromKm == "") {
            alert('Please enter FromKm.');
            return;
        }
        //emailid
        if (Dist.ToKm == null) {
            alert('Please enter ToKm.');
            return;
        }

        if (Dist.PricingType == null) {
            alert('Please enter Pricing.');
            return;
        }
        if (Dist.FromDate == null) {
            alert('Please enter FromDate.');
            return;
        }
        if (Dist.ToDate == null) {
            alert('Please enter ToDate.');
            return;
        }

        if (Dist.c.Id == null) {
            alert('Please enter Country.');
            return;
        }
        if (Dist.v.Id == null) {
            alert('Please enter VehicleGroup.');
            return;
        }

        var Pricing = {

            Id: -1,
            VehicleTypeId: $scope.vt.Id,
            FromKm: Dist.FromKm,
            ToKm: Dist.ToKm,
            PricingType: Dist.PricingType.Id,
            FromDate: Dist.FromDate,
            ToDate: Dist.ToDate,
            Amount: Dist.Amount,
            PerUnitPrice: Dist.PerUnitPrice,
            CountryId: Dist.c.Id,
            VehicleGroupId: Dist.v.Id,
            insupddelflag: 'I'
        }


        var req = {
            method: 'POST',
            url: '/api/VehicleDistPricing/SaveVehicleDistPricing',
            data: Pricing
        }
        $http(req).then(function (response) {

            alert("Saved successfully!!");
            $scope.GetDistanceBasePricing();
            $scope.Group = null;
            //$scope.GetCompanys();

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "Your details are incorrect";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            // $scope.showDialog(errmssg);
            alert(errmssg);
        });
        $scope.currGroup = null;
    };

    $scope.Changes = null;

    $scope.GetVehicleConfig = function () {

        var vc = {
            // needfleetowners:'1',
            needvehicleMake: '1'

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

    $scope.GetConfigData = function () {

        var vc = {
            includePricingType:'1',
            includeActiveCountry: '1',
            includeVehicleGroup: '1',
            includeVehicleType: '1'

        };

        var req = {
            method: 'POST',
            url: '/api/Types/ConfigData',
            data: vc
        }

        $http(req).then(function (res) {
            $scope.initdata = res.data;
            $scope.ct = $scope.initdata.Table3[0];
            $scope.vg = $scope.initdata.Table[0];
            $scope.GetDistanceBasePricing();
        });
    }

    $scope.Save = function (Changes) {
        if (Changes == null) {
            alert('Please enter Pricing.');
            return;
        }
        if ($scope.vt.Id == null || $scope.vt.Id == "") {
            alert('Please enter VehicleType.');
            return;
        }
        if (Changes.FromKm == null || Changes.FromKm == "") {
            alert('Please enter FromKm.');
            return;
        }
        //emailid
        if (Changes.ToKm == null) {
            alert('Please enter ToKm.');
            return;
        }

        if ($scope.PricingType.Id == null) {
            alert('Please enter Pricing.');
            return;
        }
        if (Changes.FromDate == null) {
            alert('Please enter FromDate.');
            return;
        }
        if (Changes.ToDate == null) {
            alert('Please enter ToDate.');
            return;
        }
        if ($scope.c.Id == null) {
            alert('Please enter Country.');
            return;
        }
        if ($scope.v.Id == null) {
            alert('Please enter VehicleGroup.');
            return;
        }

        var Changes = {

            Id: Changes.Id,
            VehicleTypeId: $scope.vt.Id,
            FromKm: Changes.FromKm,
            ToKm: Changes.ToKm,
            PricingType: $scope.PricingType.Id,
            FromDate: Changes.FromDate,
            ToDate: Changes.ToDate,
            Amount: Changes.Amount,
            PerUnitPrice: Changes.PerUnitPrice,
            CountryId: $scope.c.Id,
            VehicleGroupId: $scope.v.Id,
            insupddelflag: 'U'
        }



        var req = {
            method: 'POST',
            url: '/api/VehicleDistPricing/SaveVehicleDistPricing',
            data: Changes
        }
        $http(req).then(function (response) {

            alert("Updated successfully!");
            $scope.GetDistanceBasePricing();
            $scope.Group = null;

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            $scope.showDialog(errmssg);
        });
        $scope.currGroup = null;
    };

    $scope.PricingChanges = null;

    $scope.setVPricing = function (vp) {
        $scope.Changes = vp;
    };

    $scope.clearDist = function () {
        $scope.vp = null;
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