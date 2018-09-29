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

var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage, $uibModal, $upload, fileReader, $filter) {
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

    $scope.GetVehicleDetails = function () {

        $scope.selectedVehicle = parseLocation(window.location.search)['VID']; 

        $http.get('/api/VehicleMaster/GetVehcileDetails?VID=' + $scope.selectedVehicle).then(function (res, data) {
            $scope.vDetails = res.data.Table[0];           
            $scope.DocFiles = res.data.Table1;
            $scope.PendDocFiles = res.data.Table2;
            $scope.v = res.data.Table3[0];
            $scope.imageSrc = $scope.vDetails.Photo;
            $scope.imageSrc1 = $scope.vDetails.FrontImage;
            $scope.imageSrc2 = $scope.vDetails.BackImage;
            $scope.imageSrc3 = $scope.vDetails.RightImage;
            $scope.imageSrc4 = $scope.vDetails.LeftImage;

            for (i = 0; i < $scope.initdata.Table.length; i++) {
                if ($scope.initdata.Table[i].Id == $scope.vDetails.StatusId) {
                    $scope.vDetails.StatusId = $scope.initdata.Table[i];
                    break;
                }
            }

            for (i = 0; i < $scope.initdata.Table1.length; i++) {
                if ($scope.initdata.Table1[i].Id == $scope.vDetails.VehicleGroupId) {
                    $scope.vDetails.vg = $scope.initdata.Table1[i];
                    break;
                }
            }

            for (i = 0; i < $scope.initdata.Table2.length; i++) {
                if ($scope.initdata.Table2[i].Id == $scope.vDetails.VehicleTypeId) {
                    $scope.vDetails.vt = $scope.initdata.Table2[i];
                    break;
                }
            }

            for (i = 0; i < $scope.initdata.Table3.length; i++) {
                if ($scope.initdata.Table3[i].Id == $scope.vDetails.VehicleModelId) {
                    $scope.vDetails.vmo = $scope.initdata.Table3[i];
                    break;
                }
            }

            for (i = 0; i < $scope.initdata.Table4.length; i++) {
                if ($scope.initdata.Table4[i].Id == $scope.vDetails.VehicleMakeId) {
                    $scope.vDetails.vm = $scope.initdata.Table4[i];
                    break;
                }
            }

            for (i = 0; i < $scope.initdata.Table6.length; i++) {
                if ($scope.initdata.Table6[i].Id == $scope.vDetails.CountryId) {
                    $scope.vDetails.cn = $scope.initdata.Table6[i];
                    break;
                }
            }

            for (i = 0; i < $scope.initdata.Table7.length; i++) {
                if ($scope.initdata.Table7[i].Id == $scope.vDetails.FleetOwnerId) {
                    $scope.vDetails.f = $scope.initdata.Table7[i];
                    break;
                }
            }
        });
        
      //  $scope.GetConfigData();
    }

    $scope.GetMaster = function () {
        $http.get('/api/DriverMaster/GetMaster?ctryId=' + $scope.cn.Id).then(function (res, data) {
            $scope.listdrivers = res.data;
        });
        // $scope.imageSrc = $scope.listdrivers.Photo;
    }

    $scope.GetConfigData = function () {

        var vc = {
            includeFleetOwner: '1',
            includeVehicleType: '1',
            includeVehicleGroup: '1',
            includeVehicleModel: '1',
            includeVehicleMake: '1',
            includeActiveCountry: '1',
            includeStatus: '1',
            includeDocumentType: '1'
        };

        var req = {
            method: 'POST',
            url: '/api/Types/ConfigData',
            data: vc
        }

        $http(req).then(function (res) {
            $scope.initdata = res.data;
            $scope.GetVehicleDetails();
        });       
    }

    $scope.PendDocFiles = [];
    $scope.SetMissingDocTypes = function () {

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
                    Id: ($scope.vehicleDoc == null) ? -1 : $scope.vehicleDoc.Id,
                    VehicleId: $scope.selectedVehicle,
                    createdById: ($scope.userdetails.Id == null) ? 1 : $scope.userdetails.Id,
                    UpdatedById: ($scope.userdetails.Id == null) ? 1 : $scope.userdetails.Id,
                    expiryDate: ($scope.vehicleDoc == null || $scope.vehicleDoc.expiryDate == null) ? null : getdate($scope.vehicleDoc.expiryDate),
                    dueDate: ($scope.vehicleDoc == null || $scope.vehicleDoc.dueDate == null) ? null : getdate($scope.vehicleDoc.dueDate),
                    DocumentNo: ($scope.vehicleDoc.docNo == null) ? null : $scope.vehicleDoc.docNo,
                    DocumentNo2:($scope.vehicleDoc.docNo2 == null) ? null : $scope.vehicleDoc.docNo2,
                    docTypeId: ($scope.vehicleDoc == null) ? null : $scope.vehicleDoc.docType.Id,                    
                    FileName: files[0].name,
                    FileContent: result,
                    isVerified:0,
                    insupddelflag: 'I'
                }

            $scope.modifiedDoc = doc;
        });
    };


    function getdate(date) {
        var formateddate = date;

        if (date) {
            formateddate = $filter('date')(date, 'yyyy-MM-dd');
        }

        return formateddate;
    }

    $scope.EditVehicleDoc = function (f) {
    
        for (cnt = 0; cnt < $scope.currobj.files1.length; cnt++) {
            if ($scope.currobj.files1[cnt].docName == f.docName) {
                $scope.assetDoc = $scope.currobj.files1[cnt];

                for (dcnt = 0; dcnt < $scope.docTypes.length; dcnt++) {
                    if ($scope.docTypes[dcnt].Id == f.docTypeId) {
                        {
                            $scope.assetDoc.dt = $scope.docTypes[dcnt];
                        }
                    }
                }

                break;
            }
        }

    }
    $scope.updateDoc = function () {
        if ($scope.assetDoc.dt != null) {
            $scope.assetDoc.docTypeId = $scope.assetDoc.dt.Id;
            $scope.assetDoc.docType = $scope.assetDoc.dt.Name;
        }
        $scope.assetDoc.insupddelflag = ($scope.assetDoc.Id == -1) ? 'I' : 'U';

        $scope.modifiedDoc = $scope.assetDoc;
        $scope.SaveAssetDoc();
    }
    $scope.DeleteDoc = function (d) {

        if (d == -1) {
            $scope.currobj.files1.slice(d);
        }
        else {
            d.insupddelflag = "D";
            $scope.modifiedDoc = d;
            $scope.SaveAssetDoc();
        }


        //for (cnt = 0; cnt < $scope.currobj.files1.length; cnt++) {
        //    if ($scope.currobj.files1[cnt].docName == d.docName) {
        //         $scope.assetDoc = $scope.currobj.files1[cnt];
        //        $scope.currobj.files1[cnt].insupddelflag = 'D';
        //        break;
        //    }
        //}
    }

    $scope.cancelNewDoc = function () {
        $scope.modifiedDoc = null;
    }

    $scope.updateDocType = function () {
        if ($scope.assetDoc != null) {
            $scope.assetDoc.docTypeId = $scope.assetDoc.docType.Id;
            $scope.assetDoc.DocType = $scope.assetDoc.docType.Name;

            $scope.modifiedDoc.docTypeId = $scope.assetDoc.docType.Id;
            $scope.modifiedDoc.DocType = $scope.assetDoc.docType.Name;
        }
    }
    $scope.updateDocExpDate = function () {

        if ($scope.assetDoc != null) {
            $scope.assetDoc.expiryDate = getdateFormat($scope.assetDoc.expiryDate);
            $scope.modifiedDoc.ExpiryDate = getdateFormat($scope.assetDoc.expiryDate);
        }
    }

    $scope.SetParentDoc = function (a) {
        $scope.docOrderNo = a.OrderNo;
        $scope.CurrDocdocCatId = a.docCatId;
    }

    /*save job documents */
    $scope.SaveVehicleDoc = function () {

        if ($scope.modifiedDoc == null) {

            alert('Select a document to modify.');
            return;
        }
        $scope.modifiedDoc.UpdatedById = ($scope.userdetails.Id == null) ? 1 : $scope.userdetails.Id;
        var req = {
            method: 'POST',
            url: '/api/VehicleMaster/SaveVehicleDoc',
            data: $scope.modifiedDoc
        }
        $http(req).then(function (response) {
            
            //  $scope.DocFiles = response.data.Table;
            //alert("Saved Successfully");
            $scope.GetVehicleDetails();
            $scope.DocFiles = response.data;          

            if ($scope.DocFiles)  {
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
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            $scope.modifiedDoc = null;
            $scope.showDialog(errmssg);
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
            $http.get('/api/VehicleMaster/FileContent?docId=' + f.Id+'&docCategoryId=2').then(function (res, data) {
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

    $scope.UpdateIsVerified = function (d) {
       // alert();
        
        VehicleId: d.VehicleId;
        IsVerified: d.isVerified;       
        IsApproved: d.isApproved;
        DocType: d.docType;


        var Docs = {
            VehicleId: d.VehicleId,
            IsVerified: d.isVerified,            
            IsApproved: d.isApproved,
            DocType: d.docType,
            insupddelflag: '2'

        }

        var req = {
            method: 'POST',
            url: '/api/VehicleMaster/DocumentVerification',
            data: Docs
        }
        $http(req).then(function (response) {
            var res = response.data;
            alert("Saved Successfully");
        });
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

    $scope.save = function (vDetails, flag) {

        if (vDetails.RegistrationNo == null) {
            alert('Please Enter RegistrationNo');
            return;
        }

        //if (vDetails.ChasisNo == null || vDetails.ChasisNo == '') {
        //    alert('Please Enter chasis number');
        //    return;
        //}
        //if (vDetails.Engineno == null || vDetails.Engineno == '') {
        //    alert('Please Enter Engine number');
        //    return;
        //}
        if (vDetails.vt == null || vDetails.vt.Id == null) {
            alert('Please select type');
            return;
        }
        //if (newVehicle.vm == null || newVehicle.vm.Id == null) {
        //    alert('Please select make');
        //    return;
        //}
        //if (newVehicle.vmo == null || newVehicle.vmo.Id == null) {
        //    alert('Please select model');
        //    return;
        //}
        if (vDetails.vg == null || vDetails.vg.Id == null) {
            alert('Please select group');
            return;
        }


        //if (vDetails.ModelYear == null) {
        //    alert('Please Enter ModelYear');
        //    return;
        //}


        var vDetails = {

            flag: 'U',
            Id: vDetails.Id,
            VehicleCode: vDetails.VehicleCode,
            OwnerId: (vDetails.f == null || vDetails.f.Id == '') ? null : vDetails.f.Id,
            RegistrationNo: vDetails.RegistrationNo,
            ChasisNo: vDetails.ChasisNo,
            Engineno: vDetails.Engineno,
            VehicleGroupId: vDetails.vg.Id,
            VehicleTypeId: vDetails.vt.Id,
            VehicleModelId: 13,//newVehicle.vmo.Id,
            VehicleMakeId: 21,//newVehicle.vm.Id,
            ModelYear: vDetails.ModelYear,
            StatusId: vDetails.StatusId.Id,    
            HasAC: 1,
            isDriverOwned: 1,
            CountryId: (vDetails.cn == null || vDetails.cn.Id == '') ? null : vDetails.cn.Id,
            DriverId: ($scope.d != null && $scope.d.Id != null) ? $scope.d.Id : null,
            Photo: $scope.imageSrc,
            FrontImage: $scope.imageSrc1,
            BackImage: $scope.imageSrc2,
            RightImage: $scope.imageSrc3,
            LeftImage:$scope.imageSrc4

        }

        var req = {
            method: 'POST',
            url: '/api/VehicleMaster/Vehicle',
            data: vDetails
        }
        $http(req).then(function (res) {

            alert("Updated successfully!");
            $scope.GetVehicleDetails();
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


    $scope.saveAssetDetails = function () {

        if ($scope.currobj == null) {
            alert('Please enter equipment name');
            return;
        }
        if ($scope.currobj.Name == null || $scope.currobj.Name.trim() == "") {
            alert('Please enter equipment name');
            return;
        }
        var a = {
            Id: $scope.currobj.ID,
            Name: $scope.currobj.Name,
            Description: $scope.currobj.Description,
            Active: $scope.currobj.Active,
            AsstMDLHierarID: $scope.currobj.AsstMDLHierarID,
            AssetModelId: $scope.currobj.AssetModelId,
            ParentID: $scope.currobj.ParentID,
            RootAssetID: $scope.currobj.RootAssetID,
            LocationId: $scope.a.LocationId,
            AssetTypeId: $scope.currobj.AssetTypeId,
            changedById: $scope.userdetails.Id,
            CurrLocation: $scope.currobj.CurrLocation,
            insupddelflag: 'U'
        };


        var req = {
            method: 'POST',
            url: '/api/Asset/SaveAsset',
            data: a
        }
        $http(req).then(function (response) {
            $scope.currAsset = null;
            $scope.showDialog("Saved successfully!");
        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            $scope.showDialog(errmssg);
            $scope.currAsset = null;
        });

        var adetails = a;

        adetails.ChangedById = $scope.userdetails.Id;
        adetails.FieldAssetsList = $scope.FieldAssetsList;
        //adetails.AssetDocuments = $filter('filter')($scope.currobj.files1, { insupddelflag: '' });

        if ($scope.FieldAssetsList.length > 0) {
            var req1 = {
                method: 'POST',
                url: '/api/Asset/SaveAssetDetails',
                //headers: {
                //    'Content-Type': 'application/json'
                //},
                data: adetails
            }
            $http(req1).then(function (response) {
                ///$scope.showDialog("Saved successfully!");

                $timeout(function () {
                    $scope.getassetDetails($scope.a.Id);
                }, 500);

            }, function (errres) {
                var errdata = errres.data;
                var errmssg = "";
                errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
                $scope.showDialog(errmssg);
            });
        }
    }

    $scope.t = function (divId) {

        var p = document.getElementById('DIV_' + divId);
        p.style.display = (p.style.display == 'none') ? "inline" : 'none';

        var ielem = document.getElementById('I_' + divId);
        if ($(ielem).hasClass('fa-chevron-up')) {
            $(">.portlet-body", this).slideUp('fast');
            $(ielem).removeClass('fa-chevron-up').addClass('fa-chevron-down');
        }
        else if ($(ielem).hasClass('fa-chevron-down')) {
            $(">.portlet-body", this).slideDown('fast');
            $(ielem).removeClass('fa-chevron-down').addClass('fa-chevron-up');
        }

    }

    $scope.SetDocdocCatId = function (docCatId) {
        $scope.assetDoc = null;

        document.getElementById('fileInput').value = null;

        $scope.CurrDocdocCatId = docCatId;
    }

    $scope.Approval = function (vDetails) {
        //alert();
        RegistrationNo: vDetails.RegistrationNo;
        IsApproved: vDetails.Approved;



        var Approve = {

            RegistrationNo: vDetails.RegistrationNo,
            IsApproved: vDetails.Approved,
            change: '1'

        }

        var req = {
            method: 'POST',
            url: '/api/VehicleMaster/SaveVehicleApprovals',
            data: Approve
        }
        $http(req).then(function (response) {
            var res = response.data;

            //alert("Saved Successfully");
        });
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


    $scope.UploadImg1 = function () {
        var fileinput1 = document.getElementById('fileInput1');
        fileinput1.click();

        //  
        //if ($scope.file == null)
        //{ $scope.file = fileinput.files[0]; }
        //fileReader.readAsDataUrl($scope.file, $scope).then(function (result) { $scope.imageSrc = result; });
        //fileReader.onLoad($scope.file, $scope).then(function (result) { $scope.imageSrc = result; });
    };
    $scope.onFileSelect2 = function () {

        fileReader.readAsDataUrl($scope.file, $scope).then(function (result) {

            $scope.imageSrc1 = result;
        });
    }


    $scope.UploadImg2 = function () {
        var fileinput2 = document.getElementById('fileInput2');
        fileinput2.click();

        //  
        //if ($scope.file == null)
        //{ $scope.file = fileinput.files[0]; }
        //fileReader.readAsDataUrl($scope.file, $scope).then(function (result) { $scope.imageSrc = result; });
        //fileReader.onLoad($scope.file, $scope).then(function (result) { $scope.imageSrc = result; });
    };
    $scope.onFileSelect3 = function () {

        fileReader.readAsDataUrl($scope.file, $scope).then(function (result) {

            $scope.imageSrc2 = result;
        });
    }

    $scope.UploadImg3 = function () {
        var fileinput3 = document.getElementById('fileInput3');
        fileinput3.click();

        //  
        //if ($scope.file == null)
        //{ $scope.file = fileinput.files[0]; }
        //fileReader.readAsDataUrl($scope.file, $scope).then(function (result) { $scope.imageSrc = result; });
        //fileReader.onLoad($scope.file, $scope).then(function (result) { $scope.imageSrc = result; });
    };
    $scope.onFileSelect4 = function () {

        fileReader.readAsDataUrl($scope.file, $scope).then(function (result) {

            $scope.imageSrc3 = result;
        });
    }

    $scope.UploadImg4 = function () {
        var fileinput4 = document.getElementById('fileInput4');
        fileinput4.click();

        //  
        //if ($scope.file == null)
        //{ $scope.file = fileinput.files[0]; }
        //fileReader.readAsDataUrl($scope.file, $scope).then(function (result) { $scope.imageSrc = result; });
        //fileReader.onLoad($scope.file, $scope).then(function (result) { $scope.imageSrc = result; });
    };
    $scope.onFileSelect5 = function () {

        fileReader.readAsDataUrl($scope.file, $scope).then(function (result) {

            $scope.imageSrc4 = result;
        });
    }

    
});