var app = angular.module('myApp', ['ngStorage', 'ui.bootstrap'])
var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage, $uibModal) {
    if ($localStorage.uname == null) {
        window.location.href = "login.html";
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.Roleid = $scope.userdetails[0].roleid;

    $scope.dashboardDS = $localStorage.dashboardDS;

    var range = [];

    $scope.GetLicenseCategories = function ()
    {
        $http.get('/api/Types/TypesByGroupId?groupid=3').then(function (res, data) {
            $scope.lcat = res.data;
            document.getElementById('btnAdd').disabled = true;
        });

        $http.get('/api/Types/TypesByGroupId?groupid=7').then(function (res, data) {
            $scope.FreqTypes = res.data;
        });
     
        
        for (var i = 1; i <= 100; i++) {
            range.push(i);
        }
        $scope.range = range;
    }

    $scope.getLicensePricing = function () {

        var selCat = $scope.s;

        document.getElementById('btnAdd').disabled = false;

        if (selCat == null) {
            $scope.lpricing = null;
            document.getElementById('btnAdd').disabled = true;
            return;
        }

        $http.get('/api/LicensePricing/LicensePricing?categoryid=' + selCat.Id).then(function (res, data) {
            $scope.lpricing = res.data;

        });

        $http.get('/api/License/GetLicenseTypes?catid=' + selCat.Id).then(function (res, data) {
            $scope.lTypes = res.data;
        });
    }
    

    $scope.currLicense = function (L) {
        $scope.currSelLicense = L;
    }

    $scope.filterValue = function ($event) {
        if (isNaN(String.fromCharCode($event.keyCode)) && $event.keyCode != 46) {
            $event.preventDefault();
        }
        else
        {
            if ($event.keyCode == 46 && $scope.newUnitPrice.indexOf('.') > -1)
                $event.preventDefault();
        }
    };

    $scope.SaveNewPricing = function () {

        if ($scope.l == null) {
            $scope.showDialog('Please select license type.');
            return;
        }

        //if ($scope.ftype == null) {
        //    $scope.showDialog('Please select license frequency.');
        //    return;
        //}

        if ($scope.freq == null) {
            $scope.showDialog('Please select license renewal frequency.');
            return;
        }
        if ($scope.newUnitPrice == null) {
            $scope.showDialog('Please enter unit price.');
            return;
        }

        var newLicensePricing = {
            Id:-1,
            LicenseId: $scope.l.Id,
            RenewalFreqTypeId: $scope.ftype.Id,
            RenewalFreq: $scope.freq,
            UnitPrice: $scope.newUnitPrice,
            fromdate: $scope.nfd,
            todate: $scope.ntd,
            insupddelflag: 'I'           
        }
    
        var req = {
            method: 'POST',
            url: ('/api/LicensePricing/SaveLicensePricing'),
            //headers: {
            //    'Content-Type': undefined

            data: newLicensePricing


        }
        $http(req).then(function (response) {
            $scope.Group = null;
            $scope.getLicensePricing();

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            $scope.showDialog(errmssg);
        });
        $scope.currGroup = null;
    };

    $scope.Save = function (currSelLicense) {

        if (currSelLicense.LicenseId == null) {
            $scope.showDialog('Please select license type.');
            return;
        }

        if (currSelLicense.ftype == null) {
            $scope.showDialog('Please select license frequency.');
            return;
        }

        if (currSelLicense.freq == null) {
            $scope.showDialog('Please select license renewal frequency.');
            return;
        }
        if (currSelLicense.newUnitPrice == null) {
            $scope.showDialog('Please enter unit price.');
            return;
        }

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

            //$scope.showDialog("Saved successfully!");

            $scope.Group = null;
            $scope.getLicensePricing();

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

   










   


    