var app = angular.module('myApp', ['ngStorage'])
var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage, $filter) {
    if ($localStorage.uname == null) {
        window.location.href = "login.html";
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.Roleid = $scope.userdetails[0].roleid;

    $scope.dashboardDS = $localStorage.dashboardDS;

    $scope.GetAssignedDocuments = function () {

        var ctryId = ($scope.ctry == null || $scope.ctry.Id == null) ? -1 : $scope.ctry.Id;
        var vgroup = ($scope.vgroup == null || $scope.vgroup.Id == null) ? -1 : $scope.vgroup.Id;
        $http.get('/api/GetMandatoryVehicleDocs?ctryId=' + ctryId + '&vgId=' + vgroup).then(function (res, data) {
            $scope.doctypes = res.data;
            $scope.checkedArr = $filter('filter')($scope.doctypes, { selected: "1" });
            $scope.uncheckedArr = $filter('filter')($scope.doctypes, { selected: "0" });

        });

    }
    $scope.GetConfigData = function () {

        var vc = {
            //includeDocumentType:'1',
            includeActiveCountry: '1',
            includeVehicleGroup:'1'
        };

        var req = {
            method: 'POST',
            url: '/api/Types/ConfigData',
            data: vc
        }

        $http(req).then(function (res) {
            $scope.initdata = res.data;
            $scope.ctry = ($scope.initdata.Table1 != null) ? $scope.initdata.Table1[0] : '';
            $scope.vgroup = ($scope.initdata.Table != null) ? $scope.initdata.Table[0] : '';
            $scope.GetAssignedDocuments();
        });
    }

   
    $scope.checkedArr = new Array();
    $scope.uncheckedArr = new Array();
    

    $scope.saveVehicleDoc = function (ctry,vgroup) {

        if (ctry == null||ctry.Id==null)
        {
            alert("Select Country");
            return;
        }
        if (vgroup == null||vgroup.Id==null) {
            alert("Select Vehicle Group");
            return;
        }

        var VehicleDocs = [];
      
        for (var cnt = 0; cnt < $scope.checkedArr.length; cnt++) {
            if ($scope.checkedArr[cnt].selected == 0) {
                var fr = {
                    flag: 'I',
                    Id:-1,
                    CountryId: ctry.Id,
                    VehicleGroupId: vgroup.Id,
                    DocTypeId: $scope.checkedArr[cnt].Id,
                    FileContent: $scope.checkedArr[cnt].FileContent,
                    IsMandatory: $scope.checkedArr[cnt].IsMandatory,
                  
                }
                VehicleDocs.push(fr);
            }
            else {
                if ($scope.checkedArr[cnt].IsChanged) {
                    var fr = {
                        flag: 'U',
                        Id: -1,
                        CountryId: ctry.Id,
                        VehicleGroupId: vgroup.Id,
                        DocTypeId: $scope.checkedArr[cnt].Id,
                        FileContent: $scope.checkedArr[cnt].FileContent,
                        IsMandatory: $scope.checkedArr[cnt].IsMandatory,
                        
                    }
                    VehicleDocs.push(fr);
                }
            }
        }

        for (var cnt = 0; cnt < $scope.uncheckedArr.length; cnt++) {
            if ($scope.uncheckedArr[cnt].selected == 1) {
                var fr = {
                    flag: 'D',
                    Id: $scope.uncheckedArr[cnt].Docid,
                    CountryId: ctry.Id,
                    VehicleGroupId: vgroup.Id,
                    DocTypeId: $scope.uncheckedArr[cnt].Id,
                    FileContent: $scope.uncheckedArr[cnt].FileContent,
                    IsMandatory: $scope.uncheckedArr[cnt].IsMandatory,
                  
                }
                VehicleDocs.push(fr);
            }
        }

        $http({
            url: '/api/SaveMandatoryVehicleDocs',
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            data: VehicleDocs,

        }).success(function (data, status, headers, config) {
            alert('Documenents details Saved Successfully');
            $scope.GetAssignedDocuments();
        }).error(function (ata, status, headers, config) {
            alert(ata);
        });
    };

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

    $scope.toggleMandatory = function (item) {
        var idx = $scope.checkedArr.indexOf(item);
        if (idx > -1) {
            //$scope.checkedArr.splice(idx, 1);
            $scope.checkedArr[idx].IsMandatory = ($scope.checkedArr[idx].IsMandatory == null || $scope.checkedArr[idx].IsMandatory == 0) ? 1 : 0;
            $scope.checkedArr[idx].IsChanged = 1;
        }
        else {
            item.IsMandatory = 1;
            item.IsChanged = 1;
            $scope.checkedArr.push(item);
        }
    };
    $scope.existsMandatory = function (item, list) {
        if (list == null) return false;
        if (list.indexOf(item) > -1 && item.IsMandatory == 1)
            return true;
        else
            false;
    };
    $scope.exists = function (item, list) {
        if (list == null) return false;
        return list.indexOf(item) > -1;
    };

    $scope.isChecked = function () {
        return $scope.checkedArr.length === $scope.VehicleDocs.length;
    };

});