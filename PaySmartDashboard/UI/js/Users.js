
// JavaScript source code
var app = angular.module('myApp', ['ngStorage', 'ui.bootstrap', 'angularFileUpload'])

app.directive('file-input', function ($parse) {
    return {
        restrict: "EA",
        template: "<input type='file' />",
        replace: true,
        link: function (scope, element, attrs) {

            var modelGet = $parse(attrs.fileInput);
            var modelSet = modelGet.assign;
            var onChange = $parse(attrs.onChange);

            var updateModel = function () {
                scope.$apply(function () {
                    modelSet(scope, element[0].files[0]);
                    onChange(scope);
                });
            };

            element.bind('change', updateModel);
        }
    };
});

app.directive("ngFileSelect", function () {

    return {

        link: function ($scope, el) {

            el.on('click', function () {

                this.value = '';

            });

            el.bind("change", function (e) {

                $scope.file = (e.srcElement || e.target).files[0];



                var allowed = ["jpeg", "png", "gif", "jpg"];

                var found = false;

                var img;

                img = new Image();

                allowed.forEach(function (extension) {

                    if ($scope.file.type.match('image/' + extension)) {

                        found = true;

                    }

                });

                if (!found) {

                    alert('file type should be .jpeg, .png, .jpg, .gif');

                    return;

                }

                img.onload = function () {

                    var dimension = $scope.selectedImageOption.split(" ");

                    if (dimension[0] == this.width && dimension[2] == this.height) {

                        allowed.forEach(function (extension) {

                            if ($scope.file.type.match('image/' + extension)) {

                                found = true;

                            }

                        });

                        if (found) {

                            if ($scope.file.size <= 1048576) {

                                $scope.getFile();

                            } else {

                                alert('file size should not be grater then 1 mb.');

                            }

                        } else {

                            alert('file type should be .jpeg, .png, .jpg, .gif');

                        }

                    } else {

                        alert('selected image dimension is not equal to size drop down.');

                    }

                };

                //  img.src = _URL.createObjectURL($scope.file);



            });

        }

    };

});

var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage, $uibModal, $upload, $timeout, fileReader, $filter) {
    if ($localStorage.uname == null) {
        window.location.href = "login.html";
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.Roleid = $scope.userdetails[0].roleid;
    $scope.userCmpId = $scope.userdetails[0].CompanyId;
    $scope.UserCmp = $scope.userdetails[0].companyName;

    $scope.dashboardDS = $localStorage.dashboardDS;
    $scope.checkedArr = new Array();
    $scope.uncheckedArr = new Array();
    $scope.userRoles = [];

    /* user details functions */
    $scope.GetCountry = function () {        
        $http.get('/api/Users/GetCountry?active=1').then(function (response, req) {
            $scope.Countries = response.data;
            if ($scope.Countries.length > 0) {
                $scope.ctry = $scope.Countries[0];
                $scope.GetCountry($scope.ctry);
            }
    });
    }

    var parseLocation = function (location) {
        var pairs = location.substring(1).split("&");
        var obj = {};
        var pair;
        var i;

        for (i in pairs) {
            if (pairs[i] === "") continue;

            pair = pairs[i].split("=");
            obj[decodeURIComponent(pair[0])] = decodeURIComponent(pair[1]);
        }

        return obj;
    };


    $scope.GetUserDetails = function () {

       
        $scope.selectedUser = parseLocation(window.location.search)['UId'];

        $http.get('/api/Users/GetUserDetails?UId=' + $scope.selectedUser).then(function (res, data) {
            $scope.U = res.data[0];           
            //$scope.imageSrc = $scope.U.photo;            
           
        });
        
    }
    $scope.GetCompanies = function () {    
        $http.get('/api/GetCompanyGroups?userid=-1').then(function (response, data) {
            $scope.Companies = response.data;
           
        //    if ($scope.userCmpId != 1) {
        //        //loop throug the companies and identify the correct one
        //        for (i = 0; i < response.data.length; i++) {
        //            if (response.data[i].Id == $scope.userCmpId) {
        //                $scope.cmp = response.data[i];
        //                document.getElementById('test').disabled = true;
        //                break
        //            }
        //        }
        //    }
        //    else {
        //        document.getElementById('test').disabled =false;
        //    }

            //    $scope.getUserRolesForCompany($scope.cmp);
           
        });
        
        //if ($scope.Roleid != 1) { $scope.cmpId = $scope.UserCmpid;}
    }

    $scope.GetUsersForCmp = function () {

        if ($scope.cmp == null) {
            $scope.User = null;
            $scope.MgrUsers = null;
            $scope.cmproles = null;
            return;
        }

        $http.get('/api/Users/GetUsers?cmpId=' + $scope.cmp.Id).then(function (res, data) {
            $scope.User = res.data;
            $scope.MgrUsers = res.data;
        });

        $http.get('/api/Roles/GetCompanyRoles?companyId=' + $scope.cmp.Id).then(function (res, data) {
            $scope.cmproles = res.data;
            
           
        });
    }

    $scope.GetConfigData = function () {

        var vc = {
            includeGender: '1',          
        };

        var req = {
            method: 'POST',
            url: '/api/Types/ConfigData',
            data: vc
        }

        $http(req).then(function (res) {
            $scope.initdata = res.data;            
        });
    }

    $scope.save = function (User, flag, role) {
        if (User == null) {
            alert('Please enter Email.');
            return;
        }

        if (User.FirstName == null) {
            alert('Please enter first name.');
            return;
        }

        if (User.LastName == null) {
            alert('Please enter last name.');
            return;
        }

        if (User.EmailId == null) {
            //alert('Please enter Email.');
            return;
        }

        //if ($scope.EmpNo == null) {
        //    alert('Please enter employee no.');
        //    return;
        //}       

        if ($scope.cmp == null)
        {
            alert('Please select a company.');
            return;
        }

        var U = {
            Id: ((flag == 'U') ? User.Id : -1),
            FirstName: User.FirstName,
            LastName: User.LastName,
            MiddleName: User.MiddleName,
            EmpNo: (flag == 'U') ? User.EmpNo : $scope.EmpNo,
            Email: User.EmailId,
            Country: (flag == 'U') ? User.Country : $scope.Country,
            ContactNo1: User.ContactNo1,
            ContactNo2: User.ContactNo2,
            mgrId: User.ManagerId,//($scope.mgr == null) ? null : $scope.mgr.Id,  
            
            StateId:User.State,
            GenderId:User.Gender,
            Address:User.Address,
            AltAdress:User.AlternateAddress,
            ZipCode: User.ZipCode,
            RoleId: User.RoleId,
            RFromDate: User.RFromDate,
            RToDate: User.RToDate,
            companyId: $scope.cmp.Id,
            Active: 1,
           
            DUserName: User.DUserName,
            DPassword: User.DPassword,

           // WUserName: User.DUserName,
          //  WPassword: User.DPassword,

            Photo: $scope.imageSrc,
        
            insupdflag: flag     
    }

        var req = {
            method: 'POST',
            url: '/api/users/saveusers',
            data: U
        }
        $http(req).then(function (response) {

            alert("Saved successfully!");

            $scope.Group = null;

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "Your details are incorrect";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            alert(errmssg);
        });
        $scope.currGroup = null;
    };


    $scope.saveNew = function (User, flag) {

        if (User == null) {
            alert('Please enter Email.');
            return;
        }

        if (User.FirstName == null) {
            alert('Please enter first name.');
            return;
        }

        if (User.LastName == null) {
            alert('Please enter last name.');
            return;
        }

        if (User.Email == null) {
            //alert('Please enter Email.');
            return;
        }           

        //if ($scope.cmp == null) {
        //    alert('Please select a company.');
        //    return;
        //}


        var User1 = {
            Id: -1,
            FirstName: User.FirstName,
            LastName: User.LastName,
            MiddleName: User.MiddleName,            
            Email: User.Email,            
            ContactNo1: User.MobileNo,           
            mgrId: User.ManagerId,           
            GenderId: User.Gender,
            Address: User.Address,
            companyId: $scope.cmp.Id,
            Active: 1,

        }

        var req = {
            method: 'POST',
            url: '/api/VehicleMaster/Vehicle',
            data: User1
        }
        $http(req).then(function (res) {

            alert("Saved successfully!");
            $scope.GetVehcileList();
            var data = res.data;

            window.location.href = "vehicleDetails.html?VID=" + res.data[0].Id;
        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "Your Details Are Incorrect";
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

    $scope.User1 = null;


    $scope.setUsers = function (usr) {
        $scope.User1 = usr;
        $scope.imageSrc = null;
        document.getElementById('cmpNewLogo').src = "";
        $scope.imageSrc = usr.photo;
        document.getElementById('uactive').checked = (usr.Active == 1);

    }

    $scope.clearUsers = function () {
        $scope.User1 = null;
    }

    /*end of user details functions */

    $scope.getUserRolesForCompany = function (cmp) {

        if (cmp == null) {
            $scope.userRoles = null;
            $scope.checkedArr = [];
            $scope.uncheckedArr = [];
            return;
        }

        $http.get('/api/Users/GetUserRoles?cmpId=1').then(function (res, data) {
            $scope.userRoles = res.data;
            $scope.checkedArr = res.data;
           // $scope.uncheckedArr = $filter('filter')($scope.userRoles, { assigned: "0" });
           
        });
    }

    $scope.GetUsersinitData = function () {

        $scope.imageSrc = null;
        document.getElementById('cmpLogo').src = "";

        var date = new Date();
        var components = [
            date.getHours(),
            date.getMinutes(),
            date.getSeconds()
        ];

        var id = components.join("");
        $scope.EmpNo = 'EMP' + id;

        //get companies list   
        $http.get('/api/GetCompanyGroups?userid=-1').then(function (response, data) {
            $scope.Companies = response.data;
        });
    }

    $scope.getRolesForCompany = function (seltype) {
        if (seltype == null) {
            $scope.cmproles = null;
            $scope.MgrUsers = null;
            return;
        }
        var cmpId = (seltype) ? seltype.Id : -1;

        

        $http.get('/api/Users/GetUsers?cmpId=' + cmpId).then(function (res, data) {
            $scope.MgrUsers = res.data;
        });
            $http.get('/api/Roles/GetCompanyRoles?companyId=' + cmpId).then(function (res, data) {
                $scope.cmproles = res.data;
           
        });
        //get users for the company or all users based on companygetUsersnRoles
    }

    $scope.getUsersnRoles = function () {
        if ($scope.s == null) {
            $scope.cmproles1 = null;
            $scope.cmpUsers1 = null;
            return;
        }
        var cmpId = ($scope.s == null) ? -1 : $scope.s.Id;

        $http.get('/api/Roles/GetCompanyRoles?companyId=' + cmpId).then(function (res, data) {
            $scope.cmproles1 = res.data;
        });

        $http.get('/api/Users/GetUsers?cmpId=' + cmpId).then(function (res, data) {
            $scope.cmpUsers1 = res.data;
        });
    }
    $scope.saveUserRoles = function (flag) {

        if ($scope.s.Id == null) {
            alert('Please select company.');
            return;
        }

        if ($scope.ur.RoleId == null) {
            alert('Please select role.');
            return;
        }
        if ($scope.uu.Id == null) {
            alert('Please select user.');
            return;
        }
        var userrole = {
            Id: -1,
            UserId: $scope.uu.Id,
            CompanyId: $scope.s.Id,
            RoleId: $scope.ur.RoleId,
            insupdflag:'I'
        };

        var req = {
            method: 'POST',
            url: '/api/Users/SaveUserRoles',
            //headers: {
            //    'Content-Type': undefined
            data: userrole
        }
        $http(req).then(function (response) {

            alert("Saved successfully!");

                    $scope.s = null;
                    $scope.ur = null;
                    $scope.uu = null;

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "Your details are incorrect";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            $scope.alert(errmssg);
        });
        
       
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

    //    $http(req).then(function (res) {
    //        alert('Saved successfully');
    //        $scope.s = null;
    //        $scope.ur = null;
    //        $scope.uu = null;
    //    });

    //}
   
    $scope.setUserRoles = function (ur) {
        $scope.UserRoles = ur;
    }

    $scope.clearUsers = function () {
        $scope.UserRoles = null;
    }

    $scope.testdel = function (ur,flag) {
        var userrole = {

            RoleId: ur.RoleId,
            UserId: ur.Id,
            CompanyId: ur.Id,
            Active: 1,
            insupdflag: 'D'
        };

        var req = {
            method: 'POST',
            url: '/api/Users/GetUsers?cmpId=-1',
            data: userrole
        }
        $http(req).then(function (response) {
            alert('Removed successfully.');

            $http.get('/api/Users/GetUsers?cmpId=' + cmpId).then(function (res, data) {
                $scope.userRoles = res.data;
            });

        });
        $scope.currRole = null;
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


    $scope.toggleAll = function () {
        if ($scope.checkedArr.length === $scope.userRoles.length) {
            $scope.uncheckedArr = $scope.checkedArr.slice(0);
            $scope.checkedArr = [];

        } else if ($scope.checkedArr.length === 0 || $scope.userRoles.length > 0) {
            $scope.checkedArr = $scope.userRoles.slice(0);
            $scope.uncheckedArr = [];
        }

    };

    $scope.exists = function (item, list) {
        return list.indexOf(item) > -1;
    };


    $scope.isChecked = function () {
        return $scope.checkedArr.length === $scope.userRoles.length;
    };

    $scope.filterValue = function ($event) {
        if (isNaN(String.fromCharCode($event.keyCode))) {
            $event.preventDefault();
        }
    };


    $scope.UploadImg = function () {
        var fileinput = document.getElementById('fileInput');
        fileinput.click();

        //  
        //if ($scope.file == null)
        //{ $scope.file = fileinput.files[0]; }
        //fileReader.readAsDataUrl($scope.file, $scope).then(function (result) { $scope.imageSrc = result; });
        //fileReader.onLoad($scope.file, $scope).then(function (result) { $scope.imageSrc = result; });
    };

    $scope.onFileSelect = function () {
        fileReader.readAsDataUrl($scope.file, $scope).then(function (result) { $scope.imageSrc = result; });
    }

    $scope.clearImg = function () {
        $scope.imageSrc = null;
        document.getElementById('cmpLogo').src = "";
        document.getElementById('cmpNewLogo').src = "";
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

        

