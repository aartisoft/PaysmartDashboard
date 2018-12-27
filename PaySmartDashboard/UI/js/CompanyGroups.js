var app = angular.module('myApp', ['ngStorage', 'ui.bootstrap', 'angularFileUpload'])

app.directive('file-input', function ($parse)
{
    return {
        restrict: "EA",
        template: "<input type='file' />",
        replace: true,
        link: function (scope, element, attrs)
        {

            var modelGet = $parse(attrs.fileInput);
            var modelSet = modelGet.assign;
            var onChange = $parse(attrs.onChange);

            var updateModel = function ()
            {
                scope.$apply(function ()
                {
                    modelSet(scope, element[0].files[0]);
                    onChange(scope);
                });
            };

            element.bind('change', updateModel);
        }
    };
});

app.directive("ngFileSelect", function ()
{

    return {

        link: function ($scope, el)
        {

            el.on('click', function ()
            {

                this.value = '';

            });

            el.bind("change", function (e)
            {

                $scope.file = (e.srcElement || e.target).files[0];



                var allowed = ["jpeg", "png", "gif", "jpg"];

                var found = false;

                var img;

                img = new Image();

                allowed.forEach(function (extension)
                {

                    if ($scope.file.type.match('image/' + extension))
                    {

                        found = true;

                    }

                });

                if (!found)
                {

                    alert('file type should be .jpeg, .png, .jpg, .gif');

                    return;

                }

                img.onload = function ()
                {

                    var dimension = $scope.selectedImageOption.split(" ");

                    if (dimension[0] == this.width && dimension[2] == this.height)
                    {

                        allowed.forEach(function (extension)
                        {

                            if ($scope.file.type.match('image/' + extension))
                            {

                                found = true;

                            }

                        });

                        if (found)
                        {

                            if ($scope.file.size <= 1048576)
                            {

                                $scope.getFile();

                            } else
                            {

                                alert('file size should not be grater then 1 mb.');

                            }

                        } else
                        {

                            alert('file type should be .jpeg, .png, .jpg, .gif');

                        }

                    } else
                    {

                        alert('selected image dimension is not equal to size drop down.');

                    }

                };

              //  img.src = _URL.createObjectURL($scope.file);



            });

        }

    };

});


var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage, $uibModal, $upload, $timeout, fileReader)
{

    $scope.cmpCode = null;

    $scope.setCMPCode = function () {
        
        $scope.imageSrc = null;
        document.getElementById('cmpLogo').src = "";

        var date = new Date();
        var components = [           
            date.getHours(),
            date.getMinutes(),
            date.getSeconds()           
        ];

        var id = components.join("");
        $scope.cmpCode = 'CMP'+id;
    }

    $scope.getFile = function ()
    {

        var dimension = $scope.selectedImageOption.split(" ");

        fileReader.readAsDataUrl($scope.file, $scope)

                      .then(function (result)
                      {

                          $scope.imagePreview = true;

                          $scope.upladButtonDivErrorFlag = false;

                          $('#uploadButtonDiv').css('border-color', '#999');

                          $scope.imageSrc = result;

                          var data = {

                              "height": dimension[2],

                              "weight": dimension[0],

                              "imageBean": {

                                  "imgData": result,

                                  "imgName": $scope.file.name

                              }

                          }

                          $scope.imagePreviewDataObject = data;

                      });

    }


    if ($localStorage.uname == null)
    {
        window.location.href = "login.html";
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.Roleid = $scope.userdetails[0].roleid;

    $scope.dashboardDS = $localStorage.dashboardDS;    

    $scope.GetCompanys = function () {
        $http.get('/api/GetCompanyGroups?userid=-1').then(function (response, data) {
            $scope.Companies = response.data;

        });
    }
    $scope.GetConfigData = function () {

        var vc = {
            includeActiveCountry: '1',
            

        };

        var req = {
            method: 'POST',
            url: '/api/Types/ConfigData',
            data: vc
        }

        $http(req).then(function (res) {
            $scope.initdata = res.data;
            $scope.nn = $scope.initdata.Table1;
            //$scope.ctry = $scope.initdata.Table1[0];

        });
    }
    $scope.save = function (Group, flag) {

        if (Group == null) {
            alert('Please enter Company name.');
            return;
        }
        if (Group.Name == null || Group.Name == "") {
            alert('Please enter Company name.');
            return;
        }        
        if ($scope.cmpCode == null || $scope.cmpCode == "") {
            alert('Please enter Company code.');
            return;
        }
        //emailid
        if (Group.EmailId == null) {
            alert('Please enter email-id.');
            return;
        }
        //contact no
        if (Group.ContactNo1 == null) {
            alert('Please enter ContactNo1.');
            return;
        }
        //address
        if (Group.Address == null) {
            alert('Please enter Address.');
            return;
        }
        //country
        if (Group.Country.Id == null) {
            alert('Please select Country.');
            return;
        }
        //state
        if (Group.State == null) {
            alert('Please select State.');
            return;
        }

        //if (!angular.element('EmailId').$valid)
        //{
        //    alert('invalid email id');
        //}
        var newCmp = {

            Id: Group.Id,
            Name: Group.Name,           
            code: $scope.cmpCode,
            desc: Group.desc,            
            Address: Group.Address,
            ContactNo1: Group.ContactNo1,
            ContactNo2: Group.ContactNo2,
            Fax:Group.Fax,
            EmailId:Group.EmailId,
            Title:Group.Title,
            Caption:Group.Caption,
            Country:Group.Country.Id,
            ZipCode:Group.ZipCode,
            State: Group.State,
            FleetSize:Group.FleetSize,
            StaffSize:Group.StaffSize,
            AlternateAddress: Group.AlternateAddress,
          //  TemporaryAddress:Group.TemporaryAddress,
            Logo: $scope.imageSrc,
            active: 1,
            insupdflag:flag 
        }
        

        var req = {
            method: 'POST',
            url: '/api/CompanyGroups/SaveCompanyGroups',
            data: newCmp
        }
        $http(req).then(function (response) {

            $scope.showDialog("Saved successfully!!");
          
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

    $scope.saveCmpChanges = function (Group, flag) {

        if (Group == null) {
            alert('Please enter Company name.');
            return;
        }
        if (Group.Name == null || Group.Name == "") {
            alert('Please enter Company name.');
            return;
        }
        if (Group.Code == null || Group.Code == "") {
            alert('Please enter Company Code.');
            return;
        }
        //emailid
        if (Group.EmailId == null) {
            alert('Please enter email-id.');
            return;
        }
        //contact no
        if (Group.ContactNo1 == null) {
            alert('Please enter ContactNo1.');
            return;
        }
        //address
        if (Group.Address == null) {
            alert('Please enter Address.');
            return;
        }
        //country
        if (Group.Country == null) {
            alert('Please select Country.');
            return;
        }
        //state
        if (Group.State == null) {
            alert('Please select State.');
            return;
        }


        
        var Group = {
            Id: Group.Id,
            Name: Group.Name,
            code: Group.Code,
            desc: Group.desc,
            Address: Group.Address,
            EmailId: Group.EmailId,
            ContactNo1: Group.ContactNo1,
            ContactNo2: Group.ContactNo2,
            Fax: Group.Fax,
            Title: Group.Title,
            Caption: Group.Caption,
            Country: Group.Country,
            ZipCode: Group.ZipCode,
            State: Group.State,
            FleetSize: Group.FleetSize,
            StaffSize: Group.StaffSize,
            AlternateAddress: Group.AlternateAddress,
            Logo: $scope.imageSrc,
            active: (document.getElementById('cmpactive').checked) ? 1 : 0,
            insupdflag: flag

        }


        var req = {
            method: 'POST',
            url: '/api/CompanyGroups/SaveCompanyGroups',
            data: Group
        }
        $http(req).then(function (response) {

            alert("Saved successfully!!");
           
            $scope.GetCompanys();
            $scope.currGroup = null;
            
        }
        , function (errres) {
            var errdata = errres.data;
            var errmssg = "Your details are incorrect";            
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;            
         
        });
        
    };
      
    $scope.GetId = function () {
        $scope.imageSrc = null;
        document.getElementById('cmpLogo').src = "";

        var date = new Date();
        var components = [
            date.getYear(),
            date.getMonth(),
            date.getDate(),
            date.getHours(),
            date.getMinutes(),
            date.getSeconds(),
            date.getMilliseconds()
        ];

        var id = components.join("");
        return id;
        //this.length = 8;
        //this.timestamp = +new Date;

        //var _getRandomInt = function (min, max) {
        //    return Math.floor(Math.random() * (max - min + 1)) + min;
        //}

        //this.generate = function () {
        //    var ts = this.timestamp.toString();
        //    var parts = ts.split("").reverse();
        //    var id = "";

        //    for (var i = 0; i < this.length; ++i) {
        //        var index = _getRandomInt(0, parts.length - 1);
        //        id += parts[index];
        //    }

        //    return id;
        //}
    }

    $scope.setCompany = function (cmp) {
        $scope.imageSrc = null;
        document.getElementById('cmpNewLogo').src = "";

        $http.get('/api/GetCompanyDetails?cmpId='+cmp.Id).then(function (response, data) {
            $scope.currGroup = response.data[0];
            $scope.imageSrc = $scope.currGroup.Logo;
            document.getElementById('cmpactive').checked = ($scope.currGroup.Active == 1);
        });
       
    };

    $scope.clearGroup = function () {        
        $scope.currGroup = null;
    };

    $scope.showDialog = function (message) {

        var modalInstance = $uibModal.open({
            animation: $scope.animationsEnabled,
            backdrop:false,
            templateUrl: 'SavePopup.html',
          //  controller: 'ModalInstanceCtrl',            
            resolve: {
                mssg: function () {
                    return message;
                }
            }
        });
    }

    $scope.filterValue = function ($event) {
        if (isNaN(String.fromCharCode($event.keyCode))) {
            $event.preventDefault();
        }
    };   

    $scope.UploadImg = function ()
    {
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
