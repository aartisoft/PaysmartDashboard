var app = angular.module('myApp', ['ngStorage', 'ui.bootstrap'])
var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage, $uibModal) {
    if ($localStorage.uname == null) {
        window.location.href = "login.html";
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.Roleid = $scope.userdetails[0].roleid;

    $scope.dashboardDS = $localStorage.dashboardDS;

        $scope.GetLicenseCategories = function () {
            $http.get('/api/Types/TypesByGroupId?groupid=3').then(function (res, data) {
                $scope.lcat = res.data;
            });

            $http.get('/api/Types/TypesByGroupId?groupid=9').then(function (res, data) {
                $scope.Types = res.data;
            });
        }
    
        $scope.getLicenseTypes = function () {

            var selCat = $scope.s;

            if (selCat == null) {
                $scope.lTypes = null;
                return;
            }

            $http.get('/api/License/GetLicenseTypes?catid=' + selCat.Id).then(function (res, data) {
                $scope.lTypes = res.data;
            });
        }

        $scope.GetLicenseFeatures = function () {
            var selCat = $scope.l;

            if (selCat == null) {
                $scope.ldetails = null;
                return;
            }

            $http.get('/api/LicenseDetails/getLicenseDetails?catId=' + selCat.Id).then(function (res, data) {
                $scope.ldetails = res.data;
            });
        }
    
        $scope.currLicense = function (L) {
            $scope.currSelLicense = L;            
        }
        $scope.Save = function (currSelLicense,flag) {

            if (currSelLicense.LicenseTypeId == null) {
                $scope.showDialog('Please select the Feature name');
                return
            }
            if (currSelLicense.FeatureTypeId == null) {
                $scope.showDialog('Please select the Feature name');
                return
            }
            if (currSelLicense.FeatureValue == null) {
                $scope.showDialog('Please select the Feature name');
                return
            }
            if (currSelLicense.FeatureLabel == null) {
                $scope.showDialog('Please select the Feature name');
                return
            }
            var currSelLicense = {
                LicenseTypeId: currSelLicense.LicenseTypeId,
                FeatureTypeId: currSelLicense.FeatureTypeId,
                FeatureValue: currSelLicense.FeatureValue,
                FeatureLabel: currSelLicense.FeatureLabel,               
                //LabelClass: currSelLicense.LabelClass,                
                //fromDate: currSelLicense.fromDate,
                //toDate: currSelLicense.toDate
                insupddelflag:flag
              };

            var req = {
                method: 'POST',
                url: ('/api/LicenseDetails/SaveLicenseDetails'),
                //headers: {
                //    'Content-Type': undefined

                data: currSelLicense


            }
            $http(req).then(function (response) {

                $scope.currSelLicense = null;
                $scope.GetLicenseFeatures();

            }, function (errres) {
                var errdata = errres.data;
                var errmssg = "";
                errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
                $scope.showDialog(errmssg);
            });
            $scope.currSelLicense = null;
        };

        $scope.SaveNewFeature = function (currSelLicense, flag) {

            var selCat = $scope.l;

            if (selCat == null) {
                $scope.showDialog('Please select license type.');
                return;
            }

            if ($scope.f == null) {
                $scope.showDialog('Please select the Feature name');
                return
            }
            
            if (currSelLicense.FeatureValue == null) {
                $scope.showDialog('Please select the Feature name');
                return
            }
            if (currSelLicense.FeatureLabel == null) {
                $scope.showDialog('Please select the Feature name');
                return
            }


            var currSelLicense = {
                LicenseTypeId: selCat.Id,
                FeatureTypeId: $scope.f.Id,
                FeatureValue: currSelLicense.FeatureValue,
                FeatureLabel: currSelLicense.FeatureLabel,
                //LabelClass: currSelLicense.LabelClass,                
                //fromDate: currSelLicense.fromDate,
                //toDate: currSelLicense.toDate
                insupddelflag: flag
            };

            var req = {
                method: 'POST',
                url: ('/api/LicenseDetails/SaveLicenseDetails'),
                //headers: {
                //    'Content-Type': undefined

                data: currSelLicense


            }
            $http(req).then(function (response) {

              //  $scope.showDialog("Saved successfully!");

                $scope.currSelLicense = null;
                $scope.GetLicenseFeatures();

            }, function (errres) {
                var errdata = errres.data;
                var errmssg = "";
                errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
                $scope.showDialog(errmssg);
            });
            $scope.currSelLicense = null;
        };

        $scope.GetConfigData = function () {

            var vc = {
                includeLicenseFeatures: '1',


            };

            var req = {
                method: 'POST',
                url: '/api/Types/ConfigData',
                data: vc
            }

            $http(req).then(function (res) {
                $scope.initdata = res.data;

                //$scope.ctry = $scope.initdata.Table1[0];

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



app.controller('ModalInstanceCtrl', function ($scope, $uibModalInstance, mssg) {

    $scope.mssg = mssg;
    $scope.ok = function () {
        $uibModalInstance.close('test');
    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };
});


   


        