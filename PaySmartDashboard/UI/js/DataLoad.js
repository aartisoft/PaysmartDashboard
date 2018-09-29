/// <reference path="DataLoad.js" />
var app = angular.module('myApp', ['ngStorage', 'ui.bootstrap'])

app.directive('fileReader', function () {
    return {
        scope: {
            fileReader: "="
        },
        link: function (scope, element) {
            $(element).on('change', function (changeEvent) {
                var files = changeEvent.target.files;
                if (files.length) {
                    var r = new FileReader();
                    r.onload = function (e) {
                        var contents = e.target.result;
                        scope.$apply(function () {
                            scope.fileReader = contents;
                        });
                    };

                    r.readAsText(files[0]);
                }
            });
        }
    };
});

app.controller('myCtrl', function ($scope, $http, $localStorage, $uibModal) {

    $scope.compCol = 'Name, Code,	Description, Address, ContactNo1, ContactNo2, EmailId, Active, Fax, Title, Caption,	Country, ZipCode, State, FleetSize,	StaffSize, AlternateAddress, ShippingAddress, AddressId, Logo';
    $scope.compArr = [{"Id":1,"Name":"CompanyName"},
    {"Id":2,"Name":"Active"}]

    $scope.userCol = 'FirstName, LastName, MiddleName, EmpNo,	EmailId, Address, RoleId, CmpId, ContactNo1, ContactNo2';
    $scope.UserArr = [{"Id":1,"Name":"FirsName"},
                        { "Id": 2, "Name": "LastName" }]

    $scope.userroleCol = 'FirstName,LastName,Emailid,Role';
    $scope.UserroleArr = [{ "Id": 1, "Name": "FirsName" },
                        { "Id": 2, "Name": "LastName" }]

    $scope.fleetCol = 'VehicleRegno,FleetownerId,Active';
    $scope.fleetArr = [{ "Id": 1, "VehicleRegno": "FleetownerId" },
                        { "Id": 2, "VehicleRegno": "FleetownerId" }]

    $scope.stopCol = 'Name,Code,Active';
    $scope.stopArr = [{ "Id": 1, "Name": "Code" },
                        { "Id": 2, "Name": "Code" }]

    $scope.routesCol = 'RouteName,,Code,Active';
    $scope.routesArr = [{ "Id": 1, "RouteName": "Code" },
                        { "Id": 2, "RouteName": "Code" }]

    $scope.btposCol = 'POSId,FleetOwnerId,StatusId';
    $scope.btposArr = [{ "Id": 1, "POSId": "FleetOwnerId" },
                        { "Id": 2, "POSId": "FleetOwnerId" }]

    $scope.InveCol = 'Name,Category,Active';
    $scope.InveArr = [{ "Id": 1, "Name": "Category" },
                        { "Id": 2, "Name": "Category" }]

    $scope.DriverCol = 'First Name,Last Name,Mobile Number,Fleet Owner,Address,Permanent Address,Pin,Permanent Pin,EmailId,Driver Code,Country';
    $scope.DriverArr = [{ "Id": 1, "NAme": "Address" },
                        { "Id": 2, "NAme": "Address" }]

    $scope.VehiclesCol = 'Registration No,Chasis No,Vehicle Group,Vehicle Model,Country,Vehicle Code,Fleet Owner,Engine No,Vehicle Type,Vehicle Make,Driver,Model Year,Has AC,IsDriverOwned';
    $scope.VehiclesArr = [{ "Id": 1, "VechMobileNo": "OwnerName" },
                        { "Id": 2, "VechMobileNo": "OwnerName" }]

    $scope.CardsCol = 'CardNumber,	CardModel, CardType, CardCategory, StatusId, UserId, Customer, EffectiveFrom, EffectiveTo';
    $scope.CardsArr = [{ "Id": 1, "CardNumber": "CardCategory" },
                        { "Id": 2, "CardNumber": "CardCategory" }]

    $scope.DriverVehicleAssignCol = 'Registration No,Chasis No,Vehicle Group,Vehicle Model,Country,Vehicle Code,Fleet Owner,Engine No,Vehicle Type,Vehicle Make,Driver,Model Year,Has AC,IsDriverOwned,First Name,Last Name,Mobile Number,Fleet Owner,Address,Permanent Address,Pin,Permanent Pin,EmailId,Driver Code'
    $scope.DriverVehicleAssignArr = [{ "Id": 1, "Registration No": "Mobile Number" },
                        { "Id": 2, "Registration No": "Mobile Number" }]

    if ($localStorage.uname == null) {
        window.location.href = "login.html";
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.Roleid = $scope.userdetails[0].roleid;

    $scope.dashboardDS = $localStorage.dashboardDS;

    //$scope.GetDataLoad = function () {

    //    $http.get('/api/DataLoad/GetDataLoad').then(function (response, req) {
    //        $scope.list = response.data;
    //    });
    //}
    $scope.csv_link = 'DataUploadTemplates/CompanyList.csv';// + $window.location.search;

    $scope.SetOptionSettings = function () {
        switch ($scope.seloption) {
            case "1":
                
                $scope.mandatoryCols = $scope.compCol;
                //  $scope.optionsCols = 'Address,phone,emailid';

                $scope.importData = function () {
                    $scope.processData($scope.fileContent);
                }


                $scope.processData = function (allText) {
                    if (allText == null) {
                        alert('Please insert file.');
                        return;
                    }
                    // split content based on new line
                    var allTextLines = allText.split(/\r\n|\n/);

                    var headers = allTextLines[0].split(',');
                    
                    //validate header

                    var header = [$scope.seloption];          

                    //    switch ($scope.seloption) {
                    //        case "1":
                    //            //company                                              
                    //            $scope.mandatoryCols = $scope.compCol;

                    //            alert("Colums are not matching");
                    //            if (seloption == "CompanyName")


                    //            break;

                    //}

                    var lines = [];

                    for (var i = 1; i < allTextLines.length; i++) {
                        // split content based on comma
                        var data = allTextLines[i].split(',');
                        if (data == '' || data == null) continue;
                        lines.push(GetCompany(data));

                        if (data.length == headers.length) {
                        var tarr = [];
                        for (var j = 0; j < headers.length; j++) {
                            tarr.push(data[j]);
                        }
                        //lines.push(GetCompany(data));
                        }
                    }

                    //list
                    var req = {
                        method: 'POST',
                        url: '/api/DataLoad/SaveCompanyGroups1',
                        data: lines
                    }
                    $http(req).then(function (res) {
                        $scope.initdata = res.data;
                        alert("Saved successfully");
                    });

                     //$scope.logdata = list;
                };


                function GetCompany(data) {

                    var list = {
                        Name: data[0],
                        code: data[1],
                        Description: data[2],
                        Address: data[3],
                        ContactNo1: data[4],
                        ContactNo2: data[5],
                        EmailId: data[6],
                        active: 1,
                        insupdflag: 'I'
                    }
                    return list;
                }

                $scope.save = function () {
                    if (active == null) {
                        return;
                    }
                    if (Name == null) {
                        return;
                    }
                    if (Code == null) {
                        return;
                    }
                    if (Address == null) {
                        return;
                    }
                    if (EmailId == null) {
                        return;
                    }
                    if (ContactNo1 == null) {
                        return;
                    }

                    $http(req).then(function (response) {

                        alert("Saved successfully!!");

                        $scope.data = null;
                        //$scope.GetCompanys();

                    }, function (errres) {
                        var errdata = errres.data;
                        var errmssg = "Your details are incorrect";
                        errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
                        // $scope.showDialog(errmssg);
                        alert(errmssg);
                    });

                    //var req = {
                    //    method: 'POST',
                    //    url: '/api/DataLoad/SaveUsersGroup1',
                    //    data: lines
                    //}
                    //$http(req).then(function (res) {
                    //    $scope.initdata = res.data;
                    //});

                    // $scope.logdata = lines;
                };
                break;
            case "2":
                //users
                $scope.mandatoryCols = $scope.userCol;
                $scope.importData = function () {
                    $scope.processData($scope.fileContent);
                }

                $scope.processData = function (allText) {
                    if (allText == null) {
                        alert('Please insert file.');
                        return;
                    }
                    // split content based on new line
                    var allTextLines = allText.split(/\r\n|\n/);

                    var headers = allTextLines[0].split(',');

                    //validate header

                    //var header = [$scope.seloption];          

                    //    switch ($scope.seloption) {
                    //        case "1":
                    //            //company                                              
                    //            $scope.mandatoryCols = $scope.compCol;

                    //            alert("Colums are not matching");
                    //            if (seloption == "CompanyName")


                    //            break;


                    //}


                    var lines = [];

                    for (var i = 1; i < allTextLines.length; i++) {
                        // split content based on comma
                        var data = allTextLines[i].split(',');
                        if (data == '' || data == null) continue;
                        lines.push(GetUser(data));

                        //if (data.length == headers.length) {
                        //var tarr = [];
                        //for (var j = 0; j < headers.length; j++) {
                        //    tarr.push(data[j]);
                        //}
                        //lines.push(GetCompany(data));
                        //}
                    }

                    //list
                    var req = {
                        method: 'POST',
                        url: '/api/DataLoad/SaveUsersGroup1',
                        data: lines
                    }
                    $http(req).then(function (res) {
                        $scope.initdata = res.data;
                        alert("Saved successfully");
                    });

                    // $scope.logdata = lines;
                };


                function GetUser(data) {

                    var U = {

                        FirstName: data[0],
                        LastName: data[1],
                        MiddleName: data[2],
                        EmpNo: data[3],
                        Email: data[4],
                        Address: data[5],
                        RoleId: data[6],
                        cmpId: data[7],
                        ContactNo1: data[8],
                        ContactNo2: data[9],
                        Active: 1,
                        insupdflag: 'I'
                    }
                    return U;
                }

                $scope.save = function () {
                    if (FirstName == null) {
                        return;
                    }
                    if (LastName == null) {
                        return;
                    }
                    if (MiddleName == null) {
                        return;
                    }
                    if (Email == null) {
                        return;
                    }
                    if (ContactNo1 == null) {
                        return;
                    }
                    if (ContactNo2 == null) {
                        return;
                    }


                    $http(req).then(function (response) {

                        alert("Saved successfully!!");

                        $scope.data = null;
                        //$scope.GetCompanys();

                    }, function (errres) {

                        var errdata = errres.data;
                        var errmssg = "Your details are incorrect";
                        errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
                        // $scope.showDialog(errmssg);

                    });


                }

                break;
            case "3":
                //User Roles
                $scope.mandatoryCols = $scope.userroleCol;
                break;
            case "4":
                $scope.mandatoryCols = $scope.fleetCol;
                break;

            case "5":
                $scope.mandatoryCols = $scope.stopCol;
                break;

            case "6":
                $scope.mandatoryCols = $scope.routesCol;
                break;
           
            case "7":
                $scope.mandatoryCols = $scope.btposCol;
                break;

            case "8":
                $scope.mandatoryCols = $scope.InveCol;
                break;

            case "9":
                $scope.mandatoryCols = $scope.DriverCol;

                $scope.importData = function () {
                    $scope.processData($scope.fileContent);
                }

                $scope.processData = function (allText) {
                    if (allText == null) {
                        alert('Please insert file.');
                        return;
                    }
                    // split content based on new line
                    var allTextLines = allText.split(/\r\n|\n/);

                    var headers = allTextLines[0].split(',');

                    var lines = [];

                    for (var i = 1; i < allTextLines.length; i++) {
                        // split content based on comma
                        var data = allTextLines[i].split(',');
                        if (data == '' || data == null) continue;
                        lines.push(GetDrivers(data));

                        if (data.length == headers.length) {
                        var tarr = [];
                        for (var j = 0; j < headers.length; j++) {
                            tarr.push(data[j]);
                        }
                        //lines.push(GetDrivers(data));
                        }
                    }

                    //list
                    var req = {
                        method: 'POST',
                        url: '/api/DataLoad/SaveDriverGroups1',
                        data: lines
                    }
                    $http(req).then(function (res) {
                        $scope.initdata = res.data;
                        alert("Saved successfully")

                    }, function (errres) {
                        var errdata = errres.data;
                        var errmssg = "Your Details Are Incorrect";
                        errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
                        alert(errmssg);
                    });
                    

                    // $scope.logdata = lines;
                };

                function GetDrivers(data) {

                    var list = {
                        FirstName: data[0],
                        LastName: data[1],
                        MobileNumber: data[2],
                        FleetOwner:data[3],
                        Address: data[4],
                        PermanentAddress: data[5],                       
                        Pin: data[6],
                        PermanentPin: data[7],
                        EmailId: data[8],
                        DriverCode: data[9],                        
                        CurrentStateId: data[10],
                        Country: data[11],
                        flag: 'I'
                    }
                    return list;


                }

                $scope.save = function () {
                    if (Remarks == null) {
                        return;
                    }
                    if (NAme == null) {
                        return;
                    }
                    if (CompanyId == null) {
                        return;
                    }
                    if (Address == null) {
                        return;
                    }
                    if (BloodGroup == null) {
                        return;
                    }
                    if (City == null) {
                        return;
                    }

                    $http(req).then(function (response) {

                        alert("Saved successfully!!");

                        $scope.data = null;
                        //$scope.GetCompanys();

                    }, function (errres) {
                        var errdata = errres.data;
                        var errmssg = "Your details are incorrect";
                        errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
                        alert(errmssg);
                        alert(errmssg);
                    });

                    //var req = {
                    //    method: 'POST',
                    //    url: '/api/DataLoad/SaveUsers',
                    //    data: lines
                    //}
                    //$http(req).then(function (res) {
                    //    $scope.initdata = res.data;
                    //});

                    // $scope.logdata = lines;
                };
                break;

            case "10":
                $scope.mandatoryCols = $scope.VehiclesCol;

                $scope.importData = function () {
                    $scope.processData($scope.fileContent);
                }


                $scope.processData = function (allText) {
                    if (allText == null) {
                        alert('Please insert file.');
                        return;
                    }
                    // split content based on new line
                    var allTextLines = allText.split(/\r\n|\n/);

                    var headers = allTextLines[0].split(',');

                    //var header = [$scope.seloption];                  
                    var lines = [];

                    for (var i = 1; i < allTextLines.length; i++) {
                        // split content based on comma
                        var data = allTextLines[i].split(',');
                        if (data == '' || data == null) continue;
                        lines.push(GetVehicles(data));

                        if (data.length == headers.length) {
                        var tarr = [];
                        for (var j = 0; j < headers.length; j++) {
                            tarr.push(data[j]);
                        }
                        //lines.push(GetVehicles(data));
                        }
                    }

                    //list
                    var req = {
                        method: 'POST',
                        url: '/api/DataLoad/SaveVehicleGroups1',
                        data: lines
                    }
                    $http(req).then(function (res) {
                        $scope.initdata = res.data;                        
                        alert("Saved successfully");

                    }, function (errres) {
                        var errdata = errres.data;
                        var errmssg = "Your details are incorrect";
                        errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
                        alert(errmssg);
                        alert(errmssg);
                    });
                
                     //$scope.logdata = lines;
                };

              

                $scope.save = function () {
                    if (CompanyId == null) {
                        return;
                    }
                    if (VID == null) {
                        return;
                    }
                    if (RegistrationNo == null) {
                        return;
                    }
                    if (Type == null) {
                        return;
                    }
                    if (OwnerName == null) {
                        return;
                    }
                    if (ChasisNo == null) {
                        return;
                    }

                    $http(req).then(function (response) {

                        alert("Saved successfully!!");

                        $scope.data = null;
                        //$scope.GetCompanys();

                    }, function (errres) {
                        var errdata = errres.data;
                        var errmssg = "Your details are incorrect";
                        errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
                        $scope.alert(errmssg);
                        alert(errmssg);
                    });
                };
                break;

            case "11":
                $scope.mandatoryCols = $scope.CardsCol;

                $scope.importData = function () {
                    $scope.processData($scope.fileContent);
                }
               
                $scope.processData = function (allText) {
                    if (allText == null) {
                        alert('Please insert file.');
                        return;
                    }
                    // split content based on new line
                    var allTextLines = allText.split(/\r\n|\n/);

                    var headers = allTextLines[0].split(',');

                    //validate header

                    var header = [$scope.seloption];          

                    //    switch ($scope.seloption) {
                    //        case "1":
                    //            //company                                              
                    //            $scope.mandatoryCols = $scope.compCol;

                    //            alert("Colums are not matching");
                    //            if (seloption == "CompanyName")


                    //            break;
                    //}

                    var lines = [];

                    for (var i = 1; i < allTextLines.length; i++) {
                        // split content based on comma
                        var data = allTextLines[i].split(',');
                        lines.push(GetCards(data));

                        if (data.length == headers.length) {
                            var tarr = [];
                            for (var j = 0; j < headers.length; j++) {
                                tarr.push(data[j]);
                            }
                            //lines.push(GetCards(data));
                        }
                    }
                    //list
                    var req = {
                        method: 'POST',
                        url: '/api/DataLoad/SaveCardsGroup',
                        data: lines
                    }
                    $http(req).then(function (res) {
                        $scope.initdata = res.data;
                        alert("Saved successfully");
                    });

                    //$scope.logdata = list;
                };

                function GetCards(data) {

                    var list = {
                        CardNumber: data[0],
                        CardModel: data[1],
                        CardType: data[2],
                        CardCategory: data[3],
                        Status: data[4],
                        UserId: data[5],
                        Customer: data[6],
                        EffectiveFrom: data[7],
                        EffectiveTo: data[8],
                        //active: 1,
                        insupdflag: 'I'
                    }
                    return list;
                }

                $scope.save = function () {
                    if (active == null) {
                        return;
                    }
                    if (CardNumber == null) {
                        return;
                    }
                    if (CardModel == null) {
                        return;
                    }
                    if (CardType == null) {
                        return;
                    }
                 
                    $http(req).then(function (response) {

                        alert("Saved successfully!!");

                        $scope.data = null;
                        //$scope.GetCompanys();

                    }, function (errres) {
                        var errdata = errres.data;
                        var errmssg = "Your details are incorrect";
                        errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
                        // $scope.showDialog(errmssg);
                        alert(errmssg);
                    });

                    //var req = {
                    //    method: 'POST',
                    //    url: '/api/DataLoad/SaveUsersGroup1',
                    //    data: lines
                    //}
                    //$http(req).then(function (res) {
                    //    $scope.initdata = res.data;
                    //});

                    // $scope.logdata = lines;
                };
                break;

            case "12":
                $scope.mandatoryCols = $scope.DriverVehicleAssignCol;
                //  $scope.optionsCols = 'Address,phone,emailid';

                $scope.importData = function () {
                    $scope.processData($scope.fileContent);
                }


                $scope.processData = function (allText) {
                    if (allText == null) {
                        alert('Please insert file.');
                        return;
                    }
                    // split content based on new line
                    var allTextLines = allText.split(/\r\n|\n/);

                    var headers = allTextLines[0].split(',');

                    //validate header

                    var header = [$scope.seloption];

                    //    switch ($scope.seloption) {
                    //        case "1":
                    //            //company                                              
                    //            $scope.mandatoryCols = $scope.compCol;

                    //            alert("Colums are not matching");
                    //            if (seloption == "CompanyName")


                    //            break;

                    //}

                    var lines = [];

                    for (var i = 1; i < allTextLines.length; i++) {
                        // split content based on comma
                        var data = allTextLines[i].split(',');
                        if (data == '') continue;
                        lines.push(GetDriversVehicleAssign(data));

                        if (data.length == headers.length) {
                            var tarr = [];
                            for (var j = 0; j < headers.length; j++) {
                                tarr.push(data[j]);
                            }
                            //lines.push(GetCompany(data));
                        }
                    }

                    //list
                    var req = {
                        method: 'POST',
                        url: '/api/DataLoad/SaveDriverVehicleAssignGroup',
                        data: lines
                    }
                    $http(req).then(function (res) {                        
                        
                        alert("Saved successfully!!");

                        $scope.data = null;
                        //$scope.GetCompanys();

                    }, function (errres) {
                        var errdata = errres.data;
                        var errmssg = "Your details are incorrect";
                        errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
                        // $scope.showDialog(errmssg);
                        alert(errmssg);
                    });

                    //$scope.logdata = list;
                };


                function GetDriversVehicleAssign(data) {

                    var list = {
                        RegistrationNo: data[0],
                        ChasisNo: data[1],
                        VehicleGroup: data[2],
                        VehicleModel: data[3],
                        Country: data[4],
                        VehicleCode: data[5],
                        FleetOwner: data[6],
                        Engineno: data[7],
                        VehicleType: data[8],
                        VehicleMake: data[9],
                        Driver: data[10],
                        ModelYear: data[11],
                        HasAC: data[12],
                        IsDriverowned: data[13],  
                        FirstName: data[14],
                        LastName: data[15],
                        MobileNumber: data[16],                        
                        Address: data[17],
                        PermanentAddress: data[18],
                        Pin: data[19],
                        PermanentPin: data[20],
                        EmailId: data[21],
                        DriverCode: data[22],
                        CurrentStateId: data[23],
                        
                        inspudflag: 'I'
                    }
                    return list;
                    
                }

                $scope.save = function () {
                    //if (active == null) {
                    //    return;
                    //}
                    //if (Name == null) {
                    //    return;
                    //}
                    //if (Code == null) {
                    //    return;
                    //}
                    if (Name == null) {
                        return;
                    }
                    //if (EmailId == null) {
                    //    return;
                    //}
                    //if (ContactNo1 == null) {
                    //    return;
                    //}

                    $http(req).then(function (response) {

                        alert("Saved successfully!!");

                        $scope.data = null;
                        //$scope.GetCompanys();

                    }, function (errres) {
                        var errdata = errres.data;
                        var errmssg = "Your details are incorrect";
                        errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
                        // $scope.showDialog(errmssg);
                        alert(errmssg);
                    });

                    //var req = {
                    //    method: 'POST',
                    //    url: '/api/DataLoad/SaveUsersGroup1',
                    //    data: lines
                    //}
                    //$http(req).then(function (res) {
                    //    $scope.initdata = res.data;
                    //});

                    // $scope.logdata = lines;
                };
        }
    }
    function GetVehicles(data) {

        var list = {
            RegistrationNo: data[0],
            ChasisNo: data[1],
            VehicleGroup: data[2],
            VehicleModel: data[3],
            Country: data[4],
            VehicleCode: data[5],
            FleetOwner: data[6],
            Engineno: data[7],
            VehicleType: data[8],
            VehicleMake: data[9],
            DriverId: data[10],
            ModelYear: data[11],
            HasAC: data[12],
            IsDriverowned: data[13],
            RoadTaxDate: data[14],
            InsDate: data[15],
            PolutionNo: data[16],
            PolExpDate: data[17],
            RCBookNo: data[18],
            RCExpDate: data[19],
            StatusId: data[20],
            IsVerified: data[21],
            EntryDate: data[22],





            flag: 'I'

        }
        return list;
    }
    $scope.downloadTemplate = function () {

        switch ($scope.seloption) {
            case "1":
                $scope.downloadFile('DataUploadTemplates/CompanyList.csv','CompanyList.csv');
                break;
            case "2":
                //users
                $scope.downloadFile('DataUploadTemplates/Users.csv', 'Users.csv');
                break;
            case "3":
                //User Roles
                $scope.downloadFile('DataUploadTemplates/UserRoles.csv', 'UserRoles.csv');
                break;
            case "4":
                $scope.downloadFile('DataUploadTemplates/FleetDetails.csv', 'FleetDetails.csv');
                break;

            case "5":
                $scope.downloadFile('DataUploadTemplates/Stops.csv', 'Stops.csv');
                break;

            case "6":
                $scope.downloadFile('DataUploadTemplates/Routes.csv', 'Routes.csv');
                break;

            case "7":
                $scope.downloadFile('DataUploadTemplates/BtposDetails.csv', 'BtposDetails.csv');
                break;

            case "8":
                $scope.downloadFile('DataUploadTemplates/Inventory.csv', 'Inventory.csv');
                break;

            case "9":
                $scope.downloadFile('DataUploadTemplates/DriversList.csv', 'DriversList.csv');
                break;

            case "10":
                $scope.downloadFile('DataUploadTemplates/VehiclesList.csv');
                break;

            case "11":
                $scope.downloadFile('DataUploadTemplates/CardsList.csv', 'CardsList.csv');
                break;

            case "12":
                $scope.downloadFile('DataUploadTemplates/DriverVehicleAssignList.csv', 'DriverVehicleAssignList.csv');
                break;
        }
    }

    $scope.downloadFile = function (fileloc,filename) {
        var downloadLink = angular.element('<a></a>');
        downloadLink.attr('href', fileloc);
        downloadLink.attr('download', filename);
        downloadLink[0].click();
    }

    $scope.saveJSON = function () {       
        var blob = new Blob([$scope.logdata], { type: "application/csv;charset=utf-8;" });
        var downloadLink = angular.element('<a></a>');
        downloadLink.attr('href', window.URL.createObjectURL(blob));
        downloadLink.attr('download', 'CompanyList_log.csv');
        downloadLink[0].click();
    };


    
    //Recent Change
    //function GetUser(data) {

    //    var U = {
    //        Id: ((flag == 'I') ? User.Id : -1),
    //        FirstName: data[1],
    //        LastName: data[2],
    //        MiddleName: data[3],
    //        Email: data[4],
    //        ContactNo1: data[5],
    //        ContactNo2: data[6],
    //        Active: 1,
    //        insupdflag: flag
    //    }
    //    return U;
    //}
    
    //     $scope.save = function () {
    //         if (FirstName == null) {
    //             return;
    //         }
    //         if (LastName == null) {
    //             return;
    //         }
    //         if (MiddleName == null) {
    //             return;
    //         }
    //         if (Email == null) {
    //             return;
    //         }
    //         if (ContactNo1 == null) {
    //             return;   
    //         }
    //         if (ContactNo2 == null) {
    //             return;
    //         }
    //         if (Active == null) {
    //             return;
    //         }
            

    //         $http(req).then(function (response) {

    //            $scope.showDialog("Saved successfully!!");
               
    //             $scope.data = null;
    //             //$scope.GetCompanys();

    //         }, function (errres) {
         
    //         var errdata = errres.data;
    //         var errmssg = "Your details are incorrect";
    //         errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
    //         // $scope.showDialog(errmssg);
     
    //     });

       
    //     }
    //Recent Change
   







});




