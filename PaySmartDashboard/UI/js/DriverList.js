// JavaScript source code
// JavaScript source code
var app = angular.module('myApp', ['ngStorage', 'ui.bootstrap',  'angularFileUpload'])

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

var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage, $uibModal, fileReader, $upload, $filter) {
    if ($localStorage.uname == null) {
        window.location.href = "login.html";
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.Roleid = $scope.userdetails[0].roleid;

    $scope.dashboardDS = $localStorage.dashboardDS;


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

    
    $scope.GetMaster = function () {
        $http.get('/api/DriverMaster/GetMaster?ctryId='+$scope.ct.Id).then(function (res, data) {
            $scope.listdrivers = res.data;            
        });
       // $scope.imageSrc = $scope.listdrivers.Photo;
    }
    $scope.DocFiles = [];    

    $scope.GetCountry = function () {
        $http.get('/api/Users/GetCountry?active=1').then(function (response, req) {
            $scope.Countries = response.data;            
        });
    }

    $scope.GetBankdetails = function () {
        $http.get('/api/DriverMaster/GetBankdetails?DId=21').then(function (response, req) {
            $scope.bankdetails = response.data;
        });
    }

    $scope.CurrentState = function () {
        $http.get('/api/DriverMaster/CurrentState').then(function (response, req) {
            $scope.CurrentState = response.data;
        });
    }

    $scope.setDCode = function () {
        $scope.Driverlist.DriverCode = 'D'+$scope.Driverlist.PMobNo;
    }

    $scope.saveNew = function (Driverlist, flag) {

        if (Driverlist == null) {
            alert('Please Enter Details');
            return;
        }
        if (Driverlist.firstname == null) {
            alert('Please Enter FirstName');
            return;
        }       
       
        if (Driverlist.Address == null) {
            alert('Please Enter Address');
            return;
        }       
        if (Driverlist.Pin == null) {
            alert('Please Enter Pin');
            return;
        }
        if (Driverlist.PAddress == null) {
            alert('Please Enter PermanentAddress');
            return;
        }       
        if (Driverlist.PPin == null) {
            alert('Please Enter PermanentPin');
            return;
        }       
        if (Driverlist.PMobNo == null) {
            alert('Please Enter Mobilenumber');
            return;
        }
        if (Driverlist.DOB == null) {
            alert('Please Enter DOB');
            return;
        }
        if (Driverlist.DOJ == null) {
            alert('Please Enter DOJ');
            return;
        }
        if (Driverlist.BloodGroup == null) {
            alert('Please Enter BloodGroup');
            return;
        }
        if (Driverlist.Country.Id == null) {
            alert('Please Enter Country');
            return;
        }
        if (Driverlist.Vg.Id == null) {
            alert('Please Enter VehicleGroup');
            return;
        }
        if (Driverlist.pt.Id == null) {
            alert('Please Enter Payment Type');
            return;
        }

        var Driverlist = {

            flag:'I',
            DId:-1,
            Country: Driverlist.Country.Id,
            NAme: Driverlist.NAme,
            Address: Driverlist.Address,
            City: Driverlist.City,
            Pin: Driverlist.Pin,
            PermanentAddress: Driverlist.PAddress,
            PCity: Driverlist.PCity,
            PermanentPin: Driverlist.PPin,
            OffMobileNo: Driverlist.OffMobileNo,
            Mobilenumber: Driverlist.PMobNo,
            DOB: Driverlist.DOB,
            DOJ: Driverlist.DOJ,
            BloodGroup: Driverlist.BloodGroup,          
            Remarks: Driverlist.Remarks,
            Photo: $scope.imageSrc ,
            drivercode: 'D'+Driverlist.PMobNo,
            FirstName: Driverlist.firstname,
            LastName: Driverlist.Lname,
            EmailId: Driverlist.Email,
            Status: Driverlist.Status.Id,
            VehicleGroup: Driverlist.Vg.Id,
            PaymentTypeId: Driverlist.pt.Id,
            CuurentStateId:1
        }

        var req = {
            method: 'POST',
            url: '/api/DriverMaster/Driverlist',
            data: Driverlist
        }
        $http(req).then(function (response) {
           
            var res = response.data;            
            window.location.href = "DriverDetails.html?DId=" + res[0].DId;

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "Your Details Are Incorrect";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            alert(errmssg);
        });
        $scope.currGroup = null;
    };   

    $scope.Driverlist = null;

    $scope.save = function (Dl,flag) {

        
        //if (Dl.CompanyId.Id == null) {
        //    alert('Please Enter CompanyId');
        //    return;
        //}
        //if (Dl.NAme == null) {
        //    alert('Please Enter NAme');
        //    return;
        //}
        //if (Dl.City == null) {
        //    alert('Please Enter City');
        //    return;
        //}
        //if (Dl.Pin == null) {
        //    alert('Please Enter Pin');
        //    return;
        //}
        //if (Dl.PAddress == null) {
        //    alert('Please Enter PAddress');
        //    return;
        //}
        //if (Dl.PCity == null) {
        //    alert('Please Enter PCity');
        //    return;
        //}
        //if (Dl.PPin == null) {
        //    alert('Please Enter PPin');
        //    return;
        //}
        //if (Dl.OffMobileNo == null) {
        //    alert('Please Enter OffMobileNo');
        //    return;
        //}
        //if (Dl.PMobNo == null) {
        //    alert('Please Enter MobileNo');
        //    return;
        //}
        //if (Dl.DOB == null) {
        //    alert('Please Enter DOB');
        //    return;
        //}
        //if (Dl.DOJ == null) {
        //    alert('Please Enter DOJ');
        //    return;
        //}
        //if (Dl.BloodGroup == null) {
        //    alert('Please Enter BloodGroup');
        //    return;
        //}
       
        //if (Dl.Remarks == null) {
        //    alert('Please Enter Remarks');
        //    return;
        //}



        var driver = {          

            flag: ($scope.selectedlistdrivers == -1)?'I':'U',
            DId: Dl.DId,
            Country: Dl.Country.Id,
            NAme: Dl.NAme,
            Address: Dl.Address,            
            Pin: Dl.Pin,
            PermanentAddress: Dl.PAddress,            
            PermanentPin: Dl.PPin,            
            Mobilenumber: Dl.PMobNo,
            DOB: Dl.DOB,
            DOJ: Dl.DOJ,
            BloodGroup: Dl.BloodGroup,
            Photo: $scope.imageSrc,
            drivercode: Dl.DriverCode,
            Status: Dl.StatusId.Id,
            FirstName: Dl.Firstname,
            LastName: Dl.lastname,
            VehicleGroup: Dl.Vg.Id
            

        }

        var req = {
            method: 'POST',
            url: '/api/DriverMaster/Driverlist',
            data: driver
        }
        $http(req).then(function (response) {
            var res = response.data;
            window.location.href = "DriverDetails.html?DId="+res[0].DId;

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "Your Details Are Incorrect";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            alert(errmssg);
        });
       
    };


    $scope.savebank = function (b, flag) {


        if (b.AccountNumber == null) {
            alert('Please Enter AccountNumber');
            return;
        }
        if (b.BankName == null) {
            alert('Please Enter BankName');
            return;
        }
        if (b.BankCode == null) {
            alert('Please Enter BankCode');
            return;
        }
        if (b.BranchAddress == null) {
            alert('Please Enter BranchAddress');
            return;
        }
        if (b.Country.Id == null) {
            alert('Please Enter Country');
            return;
        }
        if (b.IsActive == null) {
            alert('Please Enter IsActive');
            return;
        }
       

        var bank = {

            flag: 'I',           
            Id: -1,
            Accountnumber: b.AccountNumber,
            BankName:b.BankName,
            Bankcode: b.BankCode,
            BranchAddress: b.BranchAddress,
            Country: b.Country.Id,
            IsActive: b.IsActive,
            DriverId:$scope.selectedlistdrivers,
            qrcode: $scope.imageSrc1
        }

        var req = {
            method: 'POST',
            url: '/api/DriverMaster/Bankingdetails',
            data: bank
        }
        $http(req).then(function (response) {
            var res = response.data;
            //window.location.href = "DriverDetails.html?DId=" + res[0].DId;

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "Your Details Are Incorrect";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            alert(errmssg);
        });

    };

    $scope.sendemail = function (m, flag) {
       
        if (m.ToMailId == null) {
            alert('Please Enter Email Id');
            return;
        }
       
        if (m.Subject == null) {
            alert('Please Enter Subject');
            return;
        }
        //if (m.CarbonCopy == null) {
        //    alert('Please Enter cc');
        //    return;
        //}
        //if (m.BlindCarbonCopy == null) {
        //    alert('Please Enter bcc');
        //    return;
        //}
        if (m.Text == null) {
            alert('Please Enter Text');
            return;
        }
        
       

        var bank = {

            flag: 'I',
            Id: -1,
            ToMailId: m.ToMailId,
            Subject: m.Subject,
            CarbonCopy: m.CarbonCopy,
            BlindCarbonCopy: m.BlindCarbonCopy,
            Text: m.Text,
            Attachments: m.Attachments
        }

        var req = {
            method: 'POST',
            url: '/api/EmailBox/Email',
            data: bank
        }
        $http(req).then(function (response) {
            var res = response.data;           

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "Your Details Are Incorrect";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            alert(errmssg);
        });

    };
    $scope.driver = null;

    $scope.setlistdrivers = function (Dl) {
        $scope.driver = Dl;
        $scope.imageSrc = null;
        document.getElementById('cmpNewLogo').src = "";
        $scope.imageSrc = Dl.photo;
        document.getElementById('uactive').checked = (Dl.Active == 1);
    };

    $scope.clearDriverlist = function () {
        $scope.Dl = null;
        $scope.imageSrc = null;
    }
    
    

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
      
        fileReader.readAsDataUrl($scope.file, $scope).then(function (result) {
           
            $scope.imageSrc = result;
        });
    }
       

    $scope.SetBiggerPhoto = function (dl) {
        $scope.biggetPhoto = dl.photo;
    }
    $scope.SetQRPhoto = function () {
        $scope.SetQRPhoto = Qp.Photo;
    }

    $scope.GetVehicleConfig = function () {

        var vc = {
             needfleetowners:'1'//,
            //needvehicleType: '1',
            //needServiceType: '1',
            ////needCompanyName: '1',
            //needVehicleMake: '1',
            //needVehicleGroup: '1',
            //needDocuments: '1'
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


    $scope.onFileSelect = function (files, $event) {
        $scope.modifiedDoc = null;
        var found = false;
        //check if doc already exists 
        for (cnt = 0; cnt < $scope.DocFiles.length; cnt++) {
            if ($scope.DocFiles[cnt].docName == files[0].name) {
                found = true;
            }
        }

        if (found) {
            alert('Cannot add duplicte documents. Document with the same name already exists.');
            $event.stopPropagation();
            $event.preventDefault();
            return;
        }

        fileReader.readAsDataUrl(files[0], $scope, 4).then(function (result) {
            //if (result.length > 2097152) {
            //    alert('Cannot upload file greater than 2 MB.');
            //    $event.stopPropagation();
            //    $event.preventDefault();
            //    return;
            //}          
            
            var doc =
                {
                    Id: ($scope.driverDoc == null) ? -1 : $scope.driverDoc.Id,
                    DriverId: $scope.selectedlistdrivers,
                    createdById: ($scope.userdetails.Id == null) ? 1 : $scope.userdetails.Id,
                    UpdatedById: ($scope.userdetails.Id == null) ? 1 : $scope.userdetails.Id,
                    expiryDate: ($scope.driverDoc == null || $scope.driverDoc.expiryDate == null) ? null : getdate($scope.driverDoc.expiryDate),
                    dueDate: ($scope.driverDoc == null || $scope.driverDoc.dueDate == null) ? null : getdate($scope.driverDoc.dueDate),
                    DocumentNo: ($scope.driverDoc.docNo == null) ? null : $scope.driverDoc.docNo,
                    DocumentNo2: ($scope.driverDoc.docNo2 == null) ? null : $scope.driverDoc.docNo2,
                    docTypeId: ($scope.driverDoc == null) ? null : $scope.driverDoc.docType.Id,
                    docName: files[0].name,
                    docContent: result,
                    isVerified: 0,
                    insupddelflag: 'I'
                }

            $scope.modifiedDoc = doc;
        });
    };
    
        $scope.printToCart = function (printSectionId) {
            var innerContents = document.getElementById(printSectionId).innerHTML;
            var popupWinindow = window.open('', '_blank', 'width=600,height=700,scrollbars=no,menubar=no,toolbar=no,location=no,status=no,titlebar=no');
            popupWinindow.document.open();
            popupWinindow.document.write('<html><head><link rel="stylesheet" type="text/css" href="style.css" /></head><body onload="window.print()">' + innerContents + '</html>');
            popupWinindow.document.close();
        }


        $scope.Mobile = function check() {

            var pass1 = document.getElementById('mobile');


            var message = document.getElementById('message');

            var goodColor = "#0C6";
            var badColor = "#FF9B37";

            if (mobile.value.length != 10) {

                mobile.style.backgroundColor = badColor;
                message.style.color = badColor;
                message.innerHTML = "required 10 digits, match requested format!"
            }
        }
        
    /*save job documents */
    $scope.SaveDriverDoc = function () {

        if ($scope.modifiedDoc == null) {

            alert('Select a document to modify.');
            return;
        }
        $scope.modifiedDoc.UpdatedById = ($scope.userdetails.Id == null) ? 1 : $scope.userdetails.Id;
        var req = {
            method: 'POST',
            url: '/api/DriverMaster/SaveDriverDoc',
            data: $scope.modifiedDoc

        }
        $http(req).then(function (response) {
            alert("Saved Successfully");
            //  $scope.DocFiles = response.data.Table;
            $scope.DocFiles = response.data;

            if ($scope.DocFiles) {
                if ($scope.DocFiles.length > 0) {
                    for (i = 0; i < $scope.DocFiles.length; i++) {
                        $scope.DocFiles[i].expiryDate = getdate($scope.DocFiles[i].expiryDate);
                        $scope.DocFiles[i].dueDate = getdate($scope.DocFiles[i].dueDate);
                        // $scope.DocFiles.push($scope.DocFiles[i]);
                    }
                }
            }

            $scope.modifiedDoc = null;
        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "";
           // errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            $scope.modifiedDoc = null;
            $scope.showDialog(errdata);
        });
    }

    function getdate(date) {
        var formateddate = date;

        if (date) {
            formateddate = $filter('date')(date, 'yyyy-MM-dd');
        }

        return formateddate;
    }

    $scope.GetConfigData = function () {

        var vc = {
            includeFleetOwner: '1',         
            includeActiveCountry: '1',
            includeStatus: '1',           
            includeVehicleGroup: '1',
            includePaymentType:'1',
        };

        var req = {
            method: 'POST',
            url: '/api/Types/ConfigData',
            data: vc
        }

        $http(req).then(function (res) {
            $scope.initdata = res.data;
            // $scope.Getdriverdetails();
            $scope.ct = $scope.initdata.Table3[0];
            $scope.GetMaster();
        });
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

    $scope.toggleMandatory = function (item) {
        var idx = $scope.checkedArr.indexOf(item);
        if (idx > -1) {
            //$scope.checkedArr.splice(idx, 1);
            $scope.checkedArr[idx].IsMandatory = ($scope.checkedArr[idx].IsMandatory == 0) ? 1 : 0;
            $scope.checkedArr[idx].IsChanged = 1;
        }
        else {
            item.IsMandatory = 1;
            item.IsChanged = 1;
            $scope.checkedArr.push(item);
        }
    };

    $scope.exists = function (item, list) {
        if (list == null) return false;
        return list.indexOf(item) > -1;
    };

    $scope.existsMandatory = function (item, list) {
        if (list == null) return false;
        if (list.indexOf(item) > -1 && item.IsMandatory == 1)
            return true;
        else
            false;
    };

    $scope.isChecked = function () {
        return $scope.checkedArr.length === $scope.UserDocs.length;
    };
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






 




