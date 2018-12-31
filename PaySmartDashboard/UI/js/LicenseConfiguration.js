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

    $scope.checkedArr = new Array();
    $scope.uncheckedArr = new Array();
    $scope.FORoutes = [];

    $scope.GetLicenseCat = function () {
        $http.get('/api/License/GetLicenceCatergories').then(function (res, data) {
            $scope.LicenseCat = res.data;
            if ($scope.LicenseCat.length > 0) {
                $scope.s = $scope.LicenseCat[0];
                $scope.GetLicenseCat($scope.s);
            }
            var range = [];

            for (var i = 1; i <= 100; i++) {
                range.push(i);
            }
            $scope.range = range;

        });
    }

    $scope.setLCCode = function () {

        $scope.FORoutes = null;
        $scope.checkedArr = [];
        $scope.uncheckedArr = [];

        var date = new Date();
        var components = [
            date.getHours(),
            date.getMinutes(),
            date.getSeconds()
        ];

        var id = components.join("");
        $scope.lcCode = 'LC' + id;
    }

    $scope.toggle = function (item) {
        var idx = $scope.checkedArr.indexOf(item);
        if (idx > -1) {
            $scope.checkedArr.splice(idx, 1);
        }
        else {
            $scope.checkedArr.push(item);
        }

        var idx = $scope.uncheckedArr.indexOf(item);
        if (idx > -1) {
            $scope.uncheckedArr.splice(idx, 1);
        }
        else {
            $scope.uncheckedArr.push(item);
        }
    };


    $scope.getLicenseTypes = function (selCat) {

        if (selCat == null) {
            $scope.LicenseTypes = null;
            return;
        }

        $http.get('/api/License/GetLicenseTypes?catid=' + selCat.Id).then(function (res, data) {
            $scope.LicenseTypes = res.data;
        });
    }

    $scope.GetLicenseConfigDetails = function (licTypeId) {
        $http.get('/api/License/GetLicenseConfigDetails?licTypeId=' + licTypeId).then(function (res, data) {
            $scope.LicenseConfigDetails = res.data;
        });
    }


    $scope.saveLicenseType = function (licenseType, flag) {

        if (licenseType == null) {
            alert('Please enter values.');
            return;
        }

        if (licenseType.LicenseType == null) {
            alert('Please enter license type.');
            return;
        }
        if ($scope.s == null) {
            alert('Please select category.');
            return;
        }

        //if (FreqTypes == null) {
        //    alert('Please enter values.');
        //    return;
        //}

        var currLicenseType = {

            Id: (flag == 'I') ? '-1' : licenseType.Id,
            LicenseType: licenseType.LicenseType,
            Desc: licenseType.Description,
            LicenseCategoryId: $scope.s.Id,
            Active: 1, // licenseType.Active
            //LicenseId: licenseType.LicenseId,
            //LicenseFrequency: ftype.LicenseFrequency,
            //Renewalfrequency: freq.Renewalfrequency,
            //UnitPrice: newUnitPrice.UnitPrice,
            // FromDate: nfd.FromDate,
            // ToDate: ntd.ToDate,
            //FeatureName: L.FeatureName,
            //FeatureValue: L.FeatureValue,
            //FeatureLabel:L.FeatureLabel

        };

        var req = {
            method: 'POST',
            url: '/api/License/SaveLicenseType',
            data: currLicenseType
        }
        $http(req).then(function (response) {

           alert("Updated successfully!");

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

    $scope.currLicenseType = null;

    $scope.saveNewLicense = function (License) {

        if (License == null) {
            alert('Please enter values.');
            return;
        }

        //if (License.FeatureName == null) {
        //    alert('Please enter Featurename.');
        //    return;
        //}
        //if (License.FeatureValue == null) {
        //    alert('Please enter Value.');
        //    return;
        //}
        var pos = null;
        for (i = 0 ; i < $scope.LicenseCat.Table3.length; i++) {
            if ($scope.LicenseCat.Table3[i]) {
                pos = $scope.LicenseCat.Table3[i];
                break;
            }
        }

        var licenseDetails1 = [];

        for (var cnt = 0; cnt < $scope.checkedArr.length; cnt++) {

            if ($scope.checkedArr[cnt]) {
                var fr = {
                    Id: $scope.checkedArr[cnt].Id,
                    FeatureName: $scope.checkedArr[cnt].FeatureName,
                    FeatureValue: $scope.checkedArr[cnt].FeatureValue,
                    FeatureLabel: $scope.checkedArr[cnt].FeatureLabel,
                    Active: 1
                }

                licenseDetails1.push(fr);
            }
        }

        var NewLicense = {

            Id: -1,
            LicenseType: License.LicenseType,
            LicenseCode: $scope.lcCode,
            LicenseCategoryId: $scope.s.Id,
            Active: 1,
            Desc: License.desc,
            fromDate: $scope.nfd,
            toDate: $scope.ntd,

            RenewalFreqTypeId: $scope.ftype.Id,
            RenewalFreq: $scope.freq,
            UnitPrice: License.unitprice,
            Pfromdate: $scope.npfd,
            Ptodate: $scope.nptd,
            PActive: 1,
            insupddelflag: 'I',

            LPOSId: -1,
            BTPOSTypeId: pos.Id,
            NoOfUnits: pos.FeatureValue,
            POSLabel: pos.FeatureLabel,
            POSLabelClass: null,
            POSfromdate: null,
            POStodate: null,
            POSActive: 1,
            licenseDetails: licenseDetails1
        };




        var req = {
            method: 'POST',
            url: '/api/License/SaveLicenseConfigDetails',
            data: NewLicense
        }

        $http(req).then(function (response) {

          //  $scope.showDialog("Saved successfully!");

            $scope.Group = null;

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            $scope.showDialog(errmssg);
        });


        $scope.currRole = null;

    };
    $scope.Save = function (currSelLicense) {

        var newLicensePricing = {
            Id: currSelLicense.Id,
            LicenseId: currSelLicense.LicenseId,
            RenewalFreqTypeId: currSelLicense.ftype.Id,
            RenewalFreq: currSelLicense.freq,
            UnitPrice: currSelLicense.UnitPrice,
            fromdate: currSelLicense.fd,
            todate: currSelLicense.td,
            insupddelflag: 'U'
        }

        var req = {
            method: 'POST',
            url: ('/api/LicensePricing/SaveLicensePricing'),
            //headers: {
            //    'Content-Type': undefined

            data: newLicensePricing


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

    $scope.setCurrLicenseType = function (lt) {
        $scope.currLicenseType = lt;
    };

    $scope.clearCurrLicenseType = function () {
        $scope.currLicenseType = null;
    };

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


