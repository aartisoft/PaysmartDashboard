// JavaScript source code
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
    
    $scope.Getdriverdetails = function () {

        $scope.Dl = null;

        $scope.selectedlistdrivers = parseLocation(window.location.search)['DId'];

        $http.get('/api/DriverMaster/Getdriverdetails?DId=' + $scope.selectedlistdrivers).then(function (res, data) {            
            $scope.Dl = res.data.Table[0];
            $scope.DocFiles = res.data.Table1;
            $scope.VehicleList = res.data.Table2;
            $scope.bankdetails = res.data.Table3;
            $scope.PendDocFiles = res.data.Table4;
            $scope.transactions = res.data.Table5;
            $scope.imageSrc = $scope.Dl.Photo;

            //assign fleet owner
            //assign country
            //assign vehicle group
            //assign state
            //assign blood group
            for (i = 0; i < $scope.initdata.Table.length; i++) {
                if ($scope.initdata.Table[i].Id == $scope.Dl.Status) {
                    $scope.Dl.StatusId = $scope.initdata.Table[i];
                    break;
                }
            }

            for (i = 0; i < $scope.initdata.Table1.length; i++) {
                if ($scope.initdata.Table1[i].Id == $scope.Dl.VehicleGroupId) {
                    $scope.Dl.vg = $scope.initdata.Table1[i];
                    break;
                }
            }

            for (i = 0; i < $scope.initdata.Table2.length; i++) {
                if ($scope.initdata.Table2[i].Id == $scope.Dl.VehicleTypeId) {
                    $scope.Dl.vt = $scope.initdata.Table2[i];
                    break;
                }
            }

            for (i = 0; i < $scope.initdata.Table3.length; i++) {
                if ($scope.initdata.Table3[i].Id == $scope.Dl.PaymentTypeId) {
                    $scope.Dl.pt = $scope.initdata.Table3[i];
                    break;
                }
            }

            for (i = 0; i < $scope.initdata.Table4.length; i++) {
                if ($scope.initdata.Table4[i].Id == $scope.Dl.CountryId) {
                    $scope.Dl.Country = $scope.initdata.Table4[i];
                    break;
                }
            }

            for (i = 0; i < $scope.initdata.Table5.length; i++) {
                if ($scope.initdata.Table5[i].Id == $scope.Dl.FleetOwnerId) {
                    $scope.Dl.Dl.fleetowner = $scope.initdata.Table5[i];
                    break;
                }
            }

            for (i = 0; i < $scope.initdata.Table6.length; i++) {
                if ($scope.initdata.Table6[i].Id == $scope.Dl.CurrentStateId) {
                    $scope.Dl.CurrentStateId = $scope.initdata.Table6[i];
                    break;
                }
            }         

            
            //for (i = 0; i < $scope.initdata.Table3.length; i++) {
            //    if ($scope.initdata.Table3[i].Id == $scope.Dl.VehicleModelId) {
            //        $scope.Dl.vmo = $scope.initdata.Table3[i];
            //        break;
            //    }
            //}

            //for (i = 0; i < $scope.initdata.Table4.length; i++) {
            //    if ($scope.initdata.Table4[i].Id == $scope.Dl.VehicleMakeId) {
            //        $scope.Dl.vm = $scope.initdata.Table4[i];
            //        break;
            //    }
            //}          


        });
    }
    
    $scope.GetMaster = function () {
        $http.get('/api/DriverMaster/GetMaster?DId=1').then(function (res, data) {
            $scope.listdrivers = res.data;
        });
        // $scope.imageSrc = $scope.listdrivers.Photo;
    }
    $scope.DocFiles = [];
    $scope.PendDocFiles = [];
    $scope.GetCountry = function () {
        $http.get('/api/Users/GetCountry?active=1').then(function (response, req) {
            $scope.Countries = response.data;
        });
    }

    $scope.GetBankdetails = function () {
        $http.get('/api/DriverMaster/GetBankdetails?DId='+$scope.selectedlistdrivers).then(function (response, req) {
            $scope.bankdetails = response.data;
            
        });
    }

    $scope.GetAvailableDV = function () {
        var vgId = ($scope.vg == null || $scope.vg.Id == null) ? '-1' : $scope.vg.Id;
        $http.get('/api/allocatedriver/AvailableVDList?vGroupId=' + vgId).then(function (res1, data) {
            $scope.vdlist = res1.data;
        });

    }

    $scope.CurrentState = function () {
        $http.get('/api/DriverMaster/CurrentState').then(function (response, req) {
            $scope.CurrentState = response.data;
        });
    }

    $scope.GetFileContent = function (f) {
        if (f.Id == -1) {
            //this is newly added document, hence show without going to db
            for (cnt = 0; cnt < $scope.currobj.files1.length; cnt++) {
                if ($scope.currobj.files1[cnt].docName == f.docName) {
                    openPDF(f.docContent, f.docName);
                }
            }

        }
        else {
            // var data = $scope.currobj.files1[0];  

            //get the file content from db
            $http.get('/api/DriverMaster/FileContent?docId=' + f.Id + '&docCategoryId=1').then(function (res, data) {
                $scope.docDetails = res.data[0];
                openPDF($scope.docDetails.FileContent, res.data[0].FileName);
            });
        }
    }

    function openPDF(resData, fileName) {

        var blob = null;
        var ext = fileName.split('.').pop();
        if (ext == 'csv') {
            blob = new Blob([resData], { type: "text/csv" });
            saveAs(blob, fileName);
        }
        else {

            var ieEDGE = navigator.userAgent.match(/Edge/g);
            var ie = navigator.userAgent.match(/.NET/g); // IE 11+
            var oldIE = navigator.userAgent.match(/MSIE/g);

            if (ie || oldIE || ieEDGE) {
                blob = b64toBlob(resData, (ext == 'csv') ? 'text/csv' : 'application/pdf');
                // window.open(blob, '_blank');
                //  window.navigator.msSaveBlob(blob, fileName);
                saveAs(blob, fileName);
                //openReportWindow('test', resData, 1000, 700);
                //window.open(resData, '_blank');
                //  var a = document.createElement("a");
                //  document.body.appendChild(a);
                //  a.style = "display: none";
                //  a.href = resData;
                //  a.download = fileName;
                ////  a.onclick = "window.open(" + fileURL + ", 'mywin','left=200,top=20,width=1000,height=800,toolbar=1,resizable=0')";
                //  a.click(); 

            }
            else {

                if (ext == 'csv' || ext == 'pdf') {
                    blob = b64toBlob(resData, (ext == 'csv') ? 'text/csv' : 'application/pdf');
                    saveAs(blob, fileName);
                }
                else {
                    openReportWindow(fileName, resData, 1000, 700);
                }
                // newWindow =   window.open(resData, 'newwin', 'left=200,top=20,width=1000,height=700,toolbar=1,resizable=0');
                //   timerObj = window.setInterval("ResetTitle('"+fileName+"')", 10);
            }
        }
    }


    var winLookup;
    var showToolbar = false;
    function openReportWindow(m_title, m_url, m_width, m_height) {
        var strURL;
        var intLeft, intTop;

        strURL = m_url;

        // Check if we've got an open window.
        if ((winLookup) && (!winLookup.closed))
            winLookup.close();

        // Set up the window so that it's centered.
        intLeft = (screen.width) ? ((screen.width - m_width) / 2) : 0;
        intTop = 20;//(screen.height) ? ((screen.height - m_height) / 2) : 0;

        // Open the window.
        winLookup = window.open('', 'winLookup', 'scrollbars=no,resizable=yes,toolbar=' + (showToolbar ? 'yes' : 'no') + ',height=' + m_height + ',width=' + m_width + ',top=' + intTop + ',left=' + intLeft);
        checkPopup(m_url, m_title);

        // Set the window opener.
        if ((document.window != null) && (!winLookup.opener))
            winLookup.opener = document.window;

        // Set the focus.
        if (winLookup.focus)
            winLookup.focus();
    }

    function checkPopup(m_url, m_title) {
        if (winLookup.document) {
            // winLookup.document.write('<html><head><title>' + m_title + '</title></head><body height="100%" width="100%"><embed src="' + m_url + '" height="100%" width="100%" /></body></html>');

            var ext = m_title.split('.').pop();
            switch (ext) {
                case 'pdf':

                    var objbuilder = '';
                    objbuilder += ('<object width="100%" height="100%"      data="');
                    objbuilder += (m_url);
                    objbuilder += ('" type="application/pdf" class="internal">');
                    objbuilder += ('<embed src="');
                    objbuilder += (m_url);
                    objbuilder += ('" type="application/pdf" />');
                    objbuilder += ('</object>');

                    // winLookup.document.write('<html><head><title>' + m_title + '</title></head><body height="100%" width="100%"><object  data="' + m_url + '" height="100%" width="100%" ></object></body></html>');
                    winLookup.document.write('<html><head><title>' + m_title + '</title></head><body height="100%" width="100%">' + objbuilder + '</body></html>');
                    //winLookup.document.href = m_url;
                    break;
                default:
                    winLookup.document.write('<html><head><title>' + m_title + '</title></head><body height="100%" width="100%"><img src="' + m_url + '" height="100%" width="100%" /></body></html>');
                    break;
            }

        } else {
            // if not loaded yet
            setTimeout(checkPopup(m_url, m_title), 10); // check in another 10ms
        }
    }


    function b64toBlob(b64Data, contentType) {
        contentType = contentType || '';
        var sliceSize = 512;
        b64Data = b64Data.replace(/^[^,]+,/, '');
        b64Data = b64Data.replace(/\s/g, '');
        var byteCharacters = window.atob(b64Data);
        var byteArrays = [];

        for (var offset = 0; offset < byteCharacters.length; offset += sliceSize) {
            var slice = byteCharacters.slice(offset, offset + sliceSize);

            var byteNumbers = new Array(slice.length);
            for (var i = 0; i < slice.length; i++) {
                byteNumbers[i] = slice.charCodeAt(i);
            }

            var byteArray = new Uint8Array(byteNumbers);

            byteArrays.push(byteArray);
        }

        var blob = new Blob(byteArrays, { type: contentType });
        return blob;
    }

    $scope.Driverlist = null;


    $scope.saveNew = function (Driverlist, flag) {


        //if (Driverlist.Id == null) {
        //    alert('Please Enter CompanyId');
        //    return;
        //}
        //if (Driverlist.NAme == null) {
        //    alert('Please Enter NAme');
        //    return;
        //}
        //if (Driverlist.Address == null) {
        //    alert('Please Enter Address');
        //    return;
        //}
        //if (Driverlist.City == null) {
        //    alert('Please Enter City');
        //    return;
        //}
        //if (Driverlist.Pin == null) {
        //    alert('Please Enter Pin');
        //    return;
        //}
        //if (Driverlist.PAddress == null) {
        //    alert('Please Enter PAddress');
        //    return;
        //}
        //if (Driverlist.PCity == null) {
        //    alert('Please Enter PCity');
        //    return;
        //}
        //if (Driverlist.PPin == null) {
        //    alert('Please Enter PPin');
        //    return;
        //}
        //if (Driverlist.OffMobileNo == null) {
        //    alert('Please Enter OffMobileNo');
        //    return;
        //}
        //if (Driverlist.PMobNo == null) {
        //    alert('Please Enter PMobNo');
        //    return;
        //}
        //if (Driverlist.DOB == null) {
        //    alert('Please Enter DOB');
        //    return;
        //}
        //if (Driverlist.DOJ == null) {
        //    alert('Please Enter DOJ');
        //    return;
        //}
        //if (Driverlist.BloodGroup == null) {
        //    alert('Please Enter BloodGroup');
        //    return;
        //}       



        var Driverlist = {

            flag: 'I',
            DId: -1,
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
            Photo: $scope.imageSrc,
            drivercode: Driverlist.DriverCode,
            FirstName: Driverlist.firstname,
            LastName: Driverlist.Lname,
            EmailId: Driverlist.Email,
            Status: Driverlist.Status.Id,
            VehicleGroup: Driverlist.vg.Id
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

    $scope.save = function (Dl, flag) {

       

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

            flag: ($scope.selectedlistdrivers == -1) ? 'I' : 'U',
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
            VehicleGroup: Dl.vg.Id,
            PaymentTypeId:Dl.pt.Id,
            IsVerified: Dl.Isverified,
            IsApproved:Dl.IsApproved


        }

        var req = {
            method: 'POST',
            url: '/api/DriverMaster/Driverlist',
            data: driver
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
            BankName: b.BankName,
            Bankcode: b.BankCode,
            BranchAddress: b.BranchAddress,
            Country: b.Country.Id,
            IsActive: b.IsActive,
            DriverId: $scope.selectedlistdrivers,
            qrcode: $scope.imageSrc1
        }

        var req = {
            method: 'POST',
            url: '/api/DriverMaster/Bankingdetails',
            data: bank
        }
        $http(req).then(function (response) {
            var res = response.data;
            alert("Saved successfully");
            $scope.GetBankdetails();
            $scope.Getdriverdetails();
           // window.location.href = "DriverDetails.html?DId=" + res[0].DId;

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "Your Details Are Incorrect";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            alert(errmssg);
        });

    };

    $scope.updatebank = function (b, flag) {


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

            flag: 'U',
            Id: $scope.b.Id,
            Accountnumber: b.AccountNumber,
            BankName: b.BankName,
            Bankcode: b.BankCode,
            BranchAddress: b.BranchAddress,
            Country: b.Country.Id,
            IsActive: b.IsActive,
            DriverId: $scope.selectedlistdrivers,
            qrcode: $scope.imageSrc1
        }

        var req = {
            method: 'POST',
            url: '/api/DriverMaster/Bankingdetails',
            data: bank
        }
        $http(req).then(function (response) {
            var res = response.data;
            alert("Saved successfully");
            $scope.GetBankdetails();
            $scope.Getdriverdetails();
            //window.location.href = "DriverDetails.html?DId=" + res[0].DId;

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "Your Details Are Incorrect";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            alert(errmssg);
        });

    };

    $scope.AssignVehicle = function (newVehicle, flag) {

        if ($scope.vm.RegistrationNo == null) {
            alert('Please Enter vechid');
            return;
        }
        if ($scope.vm.Id == null) {
            alert('Please Enter vechid');
            return;
        }
        //if ($scope.c.Id == null) {
        //    alert('Please Enter CompanyId');
        //    return;
        //}      

        if ($scope.d.DId == null || $scope.d.DId.DId == null) {
            alert('Please Enter DriverName');
            return;
        }
        if (newVehicle == null || newVehicle.EffectiveDate == null) {
            alert('Please Enter EffectiveDate');
            return;
        }
        if (newVehicle == null || newVehicle.EffectiveTill == null) {
            alert('Please Enter EffectiveTill');
            return;
        }


        var newVehicle1 = {
            Id: -1,
            VechID: $scope.vm.Id,
            CompanyId: $scope.c.Id,
            VehicleType: $scope.vm.Type,
            PhoneNo: $scope.d.DId.PMobNo,
            AltPhoneNo: $scope.d.DId.AltPhoneNo,
            RegistrationNo: $scope.vm.RegistrationNo,
            DriverName: $scope.d.DId.NAme,
            DriverId: $scope.d.DId.DId,
            EffectiveDate: newVehicle.EffectiveDate,
            EffectiveTill: newVehicle.EffectiveTill,
            VehicleModelId: $scope.vm.VehicleModelId,
            ServiceTypeId: $scope.vm.ServiceTypeId,
            VehicleGroupId: $scope.vm.VehicleGroupId,
            flag: "I"
        }

        var req = {
            method: 'POST',
            url: '/api/allocatedriver/AllocateDriver',
            data: newVehicle1
        }
        $http(req).then(function (response) {

            alert("Saved successfully!");

            $scope.Group = null;
            //$scope.Getallocatedriver('VID=1');
        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "your Details Are Incorrect";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            alert(errmssg);
        });
        $scope.currGroup = null;
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

    $scope.setbankdetails = function (bl) {
        $scope.b = bl;
    }


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


    $scope.SetBiggerPhoto = function (b) {
        $scope.biggetPhoto = b.QRCode;
    }
    $scope.SetQRPhoto = function () {
        $scope.SetQRPhoto = Qp.Photo;
    }

    $scope.GetVehicleConfig = function () {

        var vc = {
            needfleetowners: '1'//,
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

    $scope.UpdateIsVerified = function (d) {

        DriverId: d.DriverId;
        isVerified: d.IsVerified;
        IsApproved: d.IsApproved;
        DocType: d.docType;


        var Docs = {
            DriverId: d.DriverId,
            isVerified: d.IsVerified,
            IsApproved: d.IsApproved,
            DocType: d.docType,
            insupddelflag: '2'

        }

        var req = {
            method: 'POST',
            url: '/api/DriverMaster/DocumentVerification',
            data: Docs
        }
        $http(req).then(function (response) {
            var res = response.data;
            alert("Saved Successfully");
        });
    }

    $scope.Approval = function (Dl) {
        //alert();
        MobileNo: Dl.PMobNo;
        IsApproved: Dl.IsApproved;
        


        var Approve = {

            MobileNo: Dl.PMobNo,
            IsApproved: Dl.IsApproved,
            change: '1'

        }

        var req = {
            method: 'POST',
            url: '/api/DriverMaster/SaveDriverApprovals',
            data: Approve
        }
        $http(req).then(function (response) {
            var res = response.data;
            
            alert("Saved Successfully");
        
        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "Your Details Are Incorrect";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            alert(errmssg);
            $scope.Getdriverdetails();
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
                    insupddelflag: 'U' 
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
            $scope.Getdriverdetails();
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
            includeDocumentType: '1',
            includeVehicleGroup: '1',
            includeState: '1',
            includePaymentType:'1',
        };

        var req = {
            method: 'POST',
            url: '/api/Types/ConfigData',
            data: vc
        }

        $http(req).then(function (res) {
            $scope.initdata = res.data;
            $scope.Getdriverdetails();
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
       
    $scope.printDiv = function (bl) {

        var printContents = bl.QRCode;//document.getElementById(divName).innerHTML;
        var originalContents = document.body.innerHTML;

        if (navigator.userAgent.toLowerCase().indexOf('chrome') > -1) {
            var popupWin = window.open('', '_blank', 'width=800,height=610,scrollbars=no,menubar=no,toolbar=no,location=no,status=no,titlebar=no');
            popupWin.window.focus();
            popupWin.document.write('<!DOCTYPE html><html><head>' +
                '<link rel="stylesheet" type="text/css" href="style.css" />' +
                '</head><body onload="window.print()"><div class="reward-body"> <img src="' + printContents + '"/></div></html>');
            popupWin.onbeforeunload = function (event) {
                popupWin.close();
                return '.\n';
            };
            popupWin.onabort = function (event) {
                popupWin.document.close();
                popupWin.close();
            }
           
        } else {
            var popupWin = window.open('', '_blank', 'width=800,height=800');
            popupWin.document.open();
            popupWin.document.write('<html><head><link rel="stylesheet" type="text/css" href="style.css" /></head><body onload="window.print()"><img src="' + printContents + '"/></html>');
            popupWin.document.close();
        }
        popupWin.document.close();

        return false;
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











 