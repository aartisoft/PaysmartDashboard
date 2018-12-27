$(document).ready(function () {

    $('.star').on('click', function () {
        $(this).toggleClass('star-checked');
    });

    $('.ckbox label').on('click', function () {
        $(this).parents('tr').toggleClass('selected');
    });

    $('.btn-filter').on('click', function () {
        var $target = $(this).data('target');
        if ($target != 'all') {
            $('.table tr').css('display', 'none');
            $('.table tr[data-status="' + $target + '"]').fadeIn('slow');
        } else {
            $('.table tr').css('display', 'none').fadeIn('slow');
        }
    });

});

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
            });
        }
    };
});

var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage, $uibModal, $upload, $timeout, fileReader, $filter) {
    if ($localStorage.uname == null) {
        window.location.href = "login.html";
    }


    $scope.GetUsers = function () {
        $http.get('/api/AppUsers/GetUsers').then(function (res, data) {
            $scope.users = res.data;
        });
        // $scope.imageSrc = $scope.VehiclesList.Photo;

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


    $scope.GetUserdetails = function () {      

        $scope.selectedUser = parseLocation(window.location.search)['UId'];

        $http.get('/api/AppUsers/UserDetails?id=' + $scope.selectedUser).then(function (res, data) {
            $scope.User = res.data[0];
            $scope.imageSrc = $scope.User.UserPhoto;

            for (i = 0; i < $scope.initdata.Table.length; i++) {
                if ($scope.initdata.Table[i].Id == $scope.User.Status) {
                    $scope.User.Status = $scope.initdata.Table[i];
                    break;
                }
            }
            for (i = 0; i < $scope.initdata.Table1.length; i++) {
                if ($scope.initdata.Table1[i].Id == $scope.User.Gender) {
                    $scope.User.Gender = $scope.initdata.Table1[i];
                    break;
                }
            }

        });
    }

    $scope.saveNew = function (app, flag) {
       
        if (app.Username == null) {
            alert('Please Enter Username');
            return;
        }

        if (app.Firstname == null) {
            alert('Please Enter Firstname');
            return;
        }
        if (app.lastname == null) {
            alert('Please Enter lastname');
            return;
        }
        if (app.Email == null) {
            alert('Please Enter Email');
            return;
        }
        if (app.Mobilenumber == null) {
            alert('Please Enter Mobilenumber');
            return;
        }

        var app = {

            flag: 'I',
            Id: -1,
            Username: app.Username,
            Firstname: app.Firstname,
            lastname: app.lastname,
            Email: app.Email,
            Mobilenumber: app.Mobilenumber,
            Photo: $scope.imageSrc,
            Altemail: app.Altemail,
            Gender:app.Gender.Id,
            Status:app.Status.Id

        }

        var req = {
            method: 'POST',
            url: '/api/RegisterUser/Appusers',
            data: app
        }
        $http(req).then(function (response) {

            alert("Saved successfully!");
            $scope.GetUsers();
            $scope.Group = null;
            //$scope.GetVehcileMaster('VID=1');
            //window.location.href = "vehicleDetails.html?VID=1";
        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "Your Details Are Incorrect";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            alert(errmssg);
        });
        $scope.currGroup = null;
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

    $scope.onFileSelect1 = function () {
        fileReader.readAsDataUrl($scope.file, $scope).then(function (result) { $scope.imageSrc = result; });

    }

    $scope.clearImg = function () {
        $scope.imageSrc = null;
        document.getElementById('cmpLogo').src = "";
        document.getElementById('cmpNewLogo').src = "";

    }

    

    $scope.newVehicle = null;


    $scope.save = function (User, flag) {
        if (User.Username == null) {
            alert('Please Enter Username');
            return;
        }

        if (User.Firstname == null) {
            alert('Please Enter Firstname');
            return;
        }
        if (User.lastname == null) {
            alert('Please Enter lastname');
            return;
        }
        if (User.Email == null) {
            alert('Please Enter Email');
            return;
        }
        if (User.Mobilenumber == null) {
            alert('Please Enter Mobilenumber');
            return;
        }

        var User = {

            flag: 'U',
            Id: User.Id,
            Username: User.Username,
            Firstname: User.Firstname,
            lastname: User.lastname,
            Email: User.Email,
            Mobilenumber: User.Mobilenumber,
            Photo: $scope.imageSrc,
            Altemail: User.Altemail,
            Gender: User.Gender.Id,
            Amount: User.Amount,
            Status: User.Status.Id,
            AltPhonenumber:User.AltPhonenumber

        }

        var req = {
            method: 'POST',
            url: '/api/AppUsers/Appusers',
            data: User
        }
        $http(req).then(function (response) {

            alert("Saved successfully!");
            $scope.GetUserdetails();

            $scope.Group = null;

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "Your Details Are Incorrect";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            alert(errmssg);
        });
        $scope.currGroup = null;

    };

    $scope.GetConfigData = function () {

        var vc = {
            
            includeGender: '1',
            includeStatus:'1'
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

    $scope.SetBiggerPhoto = function (a) {
        $scope.biggetPhoto = a.UserPhoto;
    }

});