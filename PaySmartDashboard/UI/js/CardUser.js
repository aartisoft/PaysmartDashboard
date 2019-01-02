// JavaScript source code
var myapp1 = angular.module('myApp', ['ngStorage', 'ui.bootstrap'])
var mycrtl1 = myapp1.controller('myCtrl', function ($scope, $http, $localStorage, $uibModal, $filter) {
    if ($localStorage.uname == null) { window.location.href = "../login.html"; }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.isSuperUser = $localStorage.isSuperUser;
    $scope.roleLocations = $localStorage.roleLocation;
    $scope.isAdminSupervisor = $localStorage.isAdminSupervisor;
    $scope.dashboardDS = $localStorage.dashboardDS;

    $scope.parseLocation = function (location) {
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
    $scope.selCardId = $scope.parseLocation(window.location.search)['Id'];
    $scope.init = function () {

      /*  $http.get('/api/Cards/GetCustomers').then(function (res, data) {
            $scope.Customers = res.data;
        });

        $http.get('/api/Cards/GetCardStatus').then(function (res, data) {
            $scope.CardStatus = res.data;
        });*/
        $http.get('/api/Cards/GetCardUsers').then(function (res, data) {

            $scope.CardTypes = res.data.Table;

            //$scope.CardNumber = res.data.Table1;

        });
        $http.get('/api/Cards/GetCardNumbers').then(function (res, data) {
            $scope.CardNumbers = res.data;

        });

       /* $http.get('/api/Cards/GetCardNumbers').then(function (res, data) {
            $scope.effectiveFrom = res.data;
        });*/

    }

    //$http.get('/api/location/getlocations').then(function (res, data) {
    //    $scope.Locations = res.data;
    //});
    
    $http.get('/api/Cards/GetCardsList').then(function (res, data) {
        $scope.CardsList = res.data;
        $scope.CardsList1 = $scope.CardsList;
        // window.alert($scope.CardsList.length)
       // document.writeln($scope.selCardId);
        // if no selected then populate first Card by default

        if ($scope.selCardId == null) {
            if ($scope.CardsList.length > 0) {
                $scope.getCardDetails($scope.CardsList[0].Id);
                $scope.selCardId = $scope.CardsList[0].Id;
                return;
            }
        }
        else {
            $scope.getCardDetails($scope.selected);
        }

    });

    //$scope.getCardListByStatus = function ()
    //{

    //        $scope.CardsList1 = null;
    //}

    ////$scope.getCardDetails = function (selCardbId)
    ////{

    ////        $scope.currCard = null;
    ////        $scope.Cardusers = [];
    ////        $scope.resources = [];
    ////        $scope.tresources = [];
    ////        $scope.Carddocs = [];
    ////        if (selCardId == null) {
    ////            return;
    ////        }

    //        $http.get('/api/Cards/GetCardDetails?Id=' + selCardId).then(function (res, data) {
    //            $scope.currCard = res.data.Table;

    ////            $scope.currCard.EstStartDt = getdateFormat($scope.currCard.EstStartDt);
    ////            $scope.currCard.EstEndDt = getdateFormat($scope.currCard.EstEndDt);
    ////            $scope.currCard.ActualEndDt = getdateFormat($scope.currCard.ActualEndDt);
    ////            $scope.currCard.ActualStartDt = getdateFormat($scope.currCard.ActualStartDt);

    ////            $scope.resources = res.data.Table1;
    ////            $scope.Cardusers = res.data.Table2;
    ////            $scope.tresources = res.data.Table3;
    ////            $scope.Carddocs = res.data.Table4;
    ////            $scope.assetHistory = res.data.Table5;

    ////            if ($scope.Carddocs) {
    ////                if ($scope.Carddocs.length > 0) {
    ////                    for (i = 0; i < $scope.Carddocs.length; i++) {
    ////                        $scope.Carddocs[i].expiryDate = getdateFormat($scope.Carddocs[i].expiryDate);

    ////                    }
    ////                }
    ////            }

    //            if ($scope.CardsList != null && $scope.CardsList.length > 0) {
    //                for (i = 0; i < $scope.CardsList.length; i++) {
    //                    if ($scope.CardsList[i].Id == $scope.currCard.Id) {
    //                        $scope.j = $scope.CardsList[i];
    //                        break;
    //                    }
    //                }
    //            }

    ////            //set Card status
    //            if ($scope.CardStatus) {
    //                if ($scope.CardStatus.length > 0) {
    //                    for (i = 0; i < $scope.CardStatus.length; i++) {
    //                        if ($scope.CardStatus[i].Id == $scope.currCard.StatusId) {
    //                            $scope.js = $scope.CardStatus[i];
    //                            $scope.a = $scope.CardStatus[i];
    //                            break;
    //                        }
    //                    }
    //                }
    //            }
    //            // set customer
    //            if ($scope.Customers) {
    //                if ($scope.Customers.length > 0) {
    //                    for (i = 0; i < $scope.Customers.length; i++) {
    //                        if ($scope.Customers[i].Id == $scope.currCard.CustomerId) {
    //                            $scope.jc = $scope.Customers[i];
    //                            $scope.c = $scope.Customers[i];
    //                            break;
    //                        }
    //                    }
    //                }
    //            }

    ////            set location
    ////            if ($scope.cardtype) 
    ////            {
    ////                if ($scope.cardtype.length > 0)
    ////                {
    ////                    for (i = 0; i < $scope.cardtype.length; i++)
    ////                    {
    ////                        if ($scope.cardtype[i].id == $scope.currCard.cardtypeID)
    ////                        {
    ////                            $scope.jl = $scope.cardtype[i];
    ////                            $scope.s = $scope.cardtype[i];
    ////                            break;
    ////                        }
    ////                    }
    ////                }
    ////            }

    ////            check if he is a location admin and accordingly enable assets and jobs creation for his location
    ////            check the loction of the selected asset
    ////            if user is not super user then compare with the location of the user
    ////            if location is mismatching then disable the save button
    ////            $scope.CanEdit = ($scope.isSuperUser == 1) ? 1 : 0;
    ////            if ($scope.isSuperUser == 0 && $scope.roleLocations != null) {

    ////                $scope.CanEdit = 0;

    ////                for (cnt = 0; cnt < $scope.roleLocations.length; cnt++) {
    ////                    if ($scope.jl.id == $scope.roleLocations[cnt].LocationId) {
    ////                        $scope.CanEdit = ($scope.roleLocations[cnt].roleid == 2) ? 1 : 0;
    ////                        break;
    ////                    }
    ////                }
    ////            }
    ////        });
    ////    }

    ////    $scope.Cardusers = [];
    ////    $scope.resources = [];
    ////    $scope.tresources = [];
    ////    $scope.comments = [];
    ////    $scope.pre = [];
    ////    $scope.post = [];
    ////    $scope.Carddocs = [];

    ////    $scope.deletedDocs = [];
    ////    $scope.addedUpdatedDocs = [];

    //    function getdateFormat(date) {
    //        var formateddate = date;

    //        if (date) {
    //            formateddate = $filter('date')(date, 'yyyy-MM-dd');
    //        }

    //        return formateddate;
    //    }

    ////    $scope.Editresources = function (u) {
    ////        $scope.currUser = u;
    ////        $scope.currUser.FromDate = (u.FromDate == null) ? null : getdateFormat(u.FromDate);
    ////        $scope.currUser.ToDate = (u.ToDate == null) ? null : getdateFormat(u.ToDate);
    ////    }

    ////    $scope.AddUser = function (addUser, selU) {
    ////        var fromdate = null;
    ////        var todate = null;
    ////        if ($scope.JobUsers && $scope.JobUsers.fromDt) {
    ////            fromdate = GetFormattedDate($scope.JobUsers.fromDt);
    ////        }

    ////        if ($scope.JobUsers && $scope.JobUsers.toDt) {
    ////            todate = GetFormattedDate($scope.JobUsers.toDt);
    ////        }
    ////        $scope.currUser = null;
    ////        switch (addUser) {
    ////            insertion
    ////            case 1:
    ////                if ($scope.ju == null) {
    ////                    alert('Please select a user to add.');
    ////                    $event.stopPropagation();
    ////                    $event.preventDefault();
    ////                    return;
    ////                }
    ////                var idx = IsExists($scope.ju.Id, $scope.jobusers);
    ////                if (idx == -1) {
    ////                    var nuser = {
    ////                        "Name": $scope.ju.Name
    ////                        , "CardId": $scope.currCard.ID
    ////                         , "UserId": $scope.ju.Id
    ////                         , "CreatedById": ($scope.userdetails.Id == null) ? 1 : $scope.userdetails.Id
    ////                         , "UpdatedById": ($scope.userdetails.Id == null) ? 1 : $scope.userdetails.Id
    ////                         , "FromDate": ($scope.CardUsers == null) ? null : getdateFormat($scope.CardUsers.fromDt)
    ////                         , "ToDate": ($scope.CardUsers == null) ? null : getdateFormat($scope.CardUsers.toDt)
    ////                         , "insupddelflag": "I"
    ////                    };
    ////                     $scope.jobusers.push(nuser);
    ////                }
    ////                $scope.currUser = nuser;
    ////                break;
    ////                updation
    ////            case 2:
    ////                 selU.insupddelflag = 'U';
    ////                var idx = IsExists(selU.UserId, $scope.Cardusers);
    ////                if (idx > -1) {
    ////                    selU.CreatedById = ($scope.userdetails.Id == null) ? 1 : $scope.userdetails.Id
    ////                    selU.UpdatedById = ($scope.userdetails.Id == null) ? 1 : $scope.userdetails.Id
    ////                    selU.CardId = $scope.currCard.ID;
    ////                    $scope.currUser = selU;
    ////                    $scope.currUser.insupddelflag = 'U';
    ////                }

    ////                 $scope.currUser = null;

    ////                break;
    ////                deletion
    ////            case 0:
    ////                var idx = IsExists(selU.UserId, $scope.jobusers);
    ////                if (idx > -1) {
    ////                    selU.CreatedById = ($scope.userdetails.Id == null) ? 1 : $scope.userdetails.Id
    ////                    selU.UpdatedById = ($scope.userdetails.Id == null) ? 1 : $scope.userdetails.Id
    ////                    selU.CardId = $scope.currCard.ID;
    ////                    $scope.currUser = selU;
    ////                    $scope.currUser.insupddelflag = 'D';
    ////                }
    ////                break;
    ////        }

    ////        if ($scope.currUser != null) {
    ////            var req = {
    ////                method: 'POST',
    ////                url: '/api/Cards/SaveCardUsers',
    ////                data: $scope.currUser
    ////            }
    ////            $http(req).then(function (response) {

    ////                $scope.showDialog("Saved successfully!");
    ////                 $scope.getJobDetails($scope.modifiedJob.JobId);

    ////                $scope.Cardusers = response.data.Table;
    ////                $scope.assetHistory = response.data.Table1;

    ////                if ($scope.Cardusers) {
    ////                    if ($scope.Cardusers.length > 0) {
    ////                        for (i = 0; i < $scope.Cardusers.length; i++) {
    ////                            $scope.Cardusers[i].expiryDate = getdateFormat($scope.Cardusers[i].expiryDate);

    ////                        }
    ////                    }
    ////                }

    ////                $scope.currUser = null;
    ////                $scope.ju = null;

    ////            }, function (errres) {
    ////                var errdata = errres.data;
    ////                var errmssg = "";
    ////                errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
    ////                $scope.currUser = null;
    ////                $scope.ju = null;
    ////                $scope.showDialog(errmssg);
    ////            });
    ////        }
    ////    }

    ////    $scope.EditCardEquipment = function (equip) {
    ////        $scope.CurrCardResources = equip;

    ////        $scope.CurrCardResources.FromDate = (equip.FromDate == null) ? null : getdateFormat(equip.FromDate);
    ////        $scope.CurrCardResources.ToDate = (equip.ToDate == null) ? null : getdateFormat(equip.ToDate);

    ////    }
    ////    $scope.Addresources = function (addres, selU) {

    ////        var fromdate = null;
    ////        var todate = null;
    ////        if ($scope.CardResources && $scope.CardResources.fromDt) {
    ////            fromdate = GetFormattedDate($scope.CardResources.fromDt);
    ////        }

    ////        if ($scope.CardResources && $scope.CardResources.toDt) {
    ////            todate = GetFormattedDate($scope.CardResources.toDt);
    ////        }

    ////        var nuser = null;
    ////        switch (addres) {
    ////            insertion
    ////            case 1:
    ////                var idx = IsExists($scope.jr.ID, $scope.resources);
    ////                if (idx == -1) {
    ////                    nuser = {
    ////                        "Name": $scope.jr.Name
    ////                        , "CardId": $scope.currCard.ID
    ////                        , "AssetModel": $scope.amid.name
    ////                        , "AssetId": $scope.jr.ID
    ////                        , "CreatedById": ($scope.userdetails.Id == null) ? 1 : $scope.userdetails.Id
    ////                        , "UpdatedById": ($scope.userdetails.Id == null) ? 1 : $scope.userdetails.Id
    ////                        , "FromDate": fromdate
    ////                        , "ToDate": todate
    ////                        , "insupddelflag": "I"
    ////                    };
    ////                    $scope.CardResources = nuser;
    ////                }
    ////                $scope.JobEquip = null;
    ////                break;
    ////                updation
    ////            case 2:
    ////                selU.insupddelflag = 'U';
    ////                var idx = IsAExists(selU.AssetId, $scope.resources);
    ////                if (idx > -1) {
    ////                    selU.CreatedById = ($scope.userdetails.Id == null) ? 1 : $scope.userdetails.Id
    ////                    selU.UpdatedById = ($scope.userdetails.Id == null) ? 1 : $scope.userdetails.Id
    ////                    selU.CardId = $scope.currCard.ID;
    ////                    $scope.CardResources = selU;
    ////                }

    ////                $scope.JobEquip = null;

    ////                break;
    ////                deletion
    ////            case 0:
    ////                var idx = IsAExists(selU.AssetId, $scope.resources);
    ////                if (idx > -1) {
    ////                    selU.CreatedById = ($scope.userdetails.Id == null) ? 1 : $scope.userdetails.Id
    ////                    selU.UpdatedById = ($scope.userdetails.Id == null) ? 1 : $scope.userdetails.Id
    ////                    selU.CardId = $scope.currCard.ID;
    ////                    $scope.CardResources = selU;
    ////                    $scope.CardResources.insupddelflag = "D";
    ////                }
    ////                break;
    ////        }

    ////        if ($scope.CardResources != null) {
    ////            var req = {
    ////                method: 'POST',
    ////                url: '/api/Cards/SaveCardEquipment',
    ////                data: $scope.CardResources
    ////            }
    ////            $http(req).then(function (response) {

    ////                $scope.showDialog("Saved successfully!");
    ////                 $scope.getJobDetails($scope.modifiedJob.JobId);

    ////                $scope.resources = response.data.Table;
    ////                $scope.assetHistory = response.data.Table1;

    ////                if ($scope.resources) {
    ////                    if ($scope.resources.length > 0) {
    ////                        for (i = 0; i < $scope.resources.length; i++) {
    ////                            $scope.resources[i].expiryDate = getdateFormat($scope.resources[i].expiryDate);

    ////                        }
    ////                    }
    ////                }

    ////                $scope.CardResources = null;
    ////                $scope.jr = null;

    ////            }, function (errres) {
    ////                var errdata = errres.data;
    ////                var errmssg = "";
    ////                errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
    ////                $scope.CardResources = null;
    ////                $scope.jr = null;
    ////                $scope.showDialog(errmssg);
    ////            });
    ////        }
    ////    }

    ////    $scope.Delresources = function (addres, selU) {
    ////        selU.insupddelflag = 'D';
    ////        var fromdate = null;
    ////        var todate = null;
    ////        if ($scope.JobResources.fromDt) {
    ////            fromdate = getdateFormat($scope.JobResources.fromDt);
    ////        }

    ////        if ($scope.JobResources.toDt) {
    ////            todate = getdateFormat($scope.JobResources.toDt);
    ////        }


    ////        var nuser = (addres == 0) ? selU : { "Name": $scope.jr.Name, "AssetModel": $scope.amid.name, "AssetId": $scope.jr.ID, "CreatedById": $scope.UserId, "UpdatedById": $scope.UserId, "FromDate": fromdate, "ToDate": todate, "insupddelflag": "I" };

    ////        var idx = IsAExists(nuser.AssetId, $scope.resources);

    ////        if (idx == -1) {
    ////            if (addres == 1)
    ////                $scope.resources.push(nuser);
    ////        }

    ////        if (addres == 0) {
    ////            $scope.resources.splice(idx, 1);
    ////        }
    ////    }

    ////    $scope.EditTPresources = function (u) {
    ////        $scope.currtpRes = u;
    ////        $scope.currtpRes.FromDate = (u.FromDate == null) ? null : getdateFormat(u.FromDate);
    ////        $scope.currtpRes.ToDate = (u.ToDate == null) ? null : getdateFormat(u.ToDate);
    ////    }
    ////    $scope.AddTresources = function (addTres, selU) {

    ////        var fromdate = null;
    ////        var todate = null;
    ////        if ($scope.tpRes && $scope.tpRes.fromDt) {
    ////            fromdate = GetFormattedDate($scope.tpRes.fromDt);
    ////        }

    ////        if ($scope.tpRes && $scope.tpRes.toDt) {
    ////            todate = GetFormattedDate($scope.tpRes.toDt);
    ////        }

    ////        var nuser = null;
    ////        switch (addTres) {
    ////            insertion
    ////            case 1:

    ////                if ($scope.tpRes.Name == null) {
    ////                    alert('Please enter Third party resource name.');
    ////                    return;
    ////                }
    ////                if ($scope.tpRes.VName == null) {
    ////                    alert('Please enter Third party resource name.');
    ////                    return;
    ////                }

    ////                var idx = IsTExists($scope.tpRes, $scope.tresources);
    ////                if (idx == -1) {
    ////                    nuser = {
    ////                        "Name": $scope.tpRes.Name
    ////                        , "VName": $scope.tpRes.VName
    ////                         , "Id": $scope.currCard.ID
    ////                        , "TPResourceId": $scope.tpRes.Id
    ////                        , "CreatedById": ($scope.userdetails.Id == null) ? 1 : $scope.userdetails.Id
    ////                        , "UpdatedById": ($scope.userdetails.Id == null) ? 1 : $scope.userdetails.Id
    ////                        , "FromDate": fromdate
    ////                        , "ToDate": todate
    ////                        , "insupddelflag": "I"
    ////                    };
    ////                    $scope.currtpRes = nuser;
    ////                }

    ////                break;
    ////                updation
    ////            case 2:

    ////                if (selU.Name == null) {
    ////                    alert('Please enter Third party resource name.');
    ////                    return;
    ////                }
    ////                if (selU.VName == null) {
    ////                    alert('Please enter Third party resource name.');
    ////                    return;
    ////                }

    ////                selU.insupddelflag = 'U';
    ////                var idx = IsTExists(selU, $scope.tresources);
    ////                if (idx > -1) {
    ////                    selU.CreatedById = ($scope.userdetails.Id == null) ? 1 : $scope.userdetails.Id
    ////                    selU.UpdatedById = ($scope.userdetails.Id == null) ? 1 : $scope.userdetails.Id
    ////                    selU.CardId = $scope.currCard.ID;
    ////                    $scope.CardResources = selU;
    ////                }

    ////                break;
    ////                deletion
    ////            case 0:
    ////                var idx = IsTExists(selU, $scope.tresources);
    ////                if (idx > -1) {
    ////                    selU.CreatedById = ($scope.userdetails.Id == null) ? 1 : $scope.userdetails.Id
    ////                    selU.UpdatedById = ($scope.userdetails.Id == null) ? 1 : $scope.userdetails.Id
    ////                    selU.CardId = $scope.currCard.ID;
    ////                    $scope.currtpRes = selU;
    ////                    $scope.currtpRes.insupddelflag = "D";
    ////                }
    ////                break;
    ////        }

    ////        if ($scope.currtpRes != null) {
    ////            var req = {
    ////                method: 'POST',
    ////                url: '/api/Cards/SaveCardTPResource',
    ////                data: $scope.currtpRes
    ////            }
    ////            $http(req).then(function (response) {

    ////                $scope.tresources = response.data.Table;
    ////                $scope.assetHistory = response.data.Table1;

    ////                if ($scope.tresources) {
    ////                    if ($scope.tresources.length > 0) {
    ////                        for (i = 0; i < $scope.tresources.length; i++) {
    ////                            $scope.tresources[i].expiryDate = getdateFormat($scope.tresources[i].expiryDate);

    ////                        }
    ////                    }
    ////                }

    ////                $scope.currtpRes = null;
    ////                $scope.tpRes = null;

    ////            }, function (errres) {
    ////                var errdata = errres.data;
    ////                var errmssg = "";
    ////                errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
    ////                $scope.currtpRes = null;
    ////                $scope.tpRes = null;
    ////                $scope.showDialog(errmssg);
    ////            });
    ////        }
    ////    }

    ////    function IsAExists(itemId, arr) {
    ////        var idx = -1;
    ////        for (i = 0; i < arr.length; i++) {
    ////            if (arr[i].AssetId == itemId) {
    ////                idx = i;
    ////                break
    ////            }
    ////        }
    ////        return idx;
    ////    }
    ////    function IsTExists(itemId, arr) {
    ////        var idx = -1;
    ////        for (i = 0; i < arr.length; i++) {
    ////            if (arr[i].Name == itemId.Name && arr[i].VName == itemId.VName) {
    ////                idx = i;
    ////                break
    ////            }
    ////        }
    ////        return idx;
    ////    }

    ////    function IsExists(itemId, arr) {
    ////        var idx = -1;
    ////        for (i = 0; i < arr.length; i++) {
    ////            if (arr[i].UserId == itemId) {
    ////                idx = i;
    ////                break
    ////            }
    ////        }
    ////        return idx;
    ////    }

    //    $scope.AddNewCard = function () {
    //        $scope.Cards = null;
    //        $scope.Cardname = null;
    //    }

    ////    $scope.addComments = function () { $scope.comments.push({ "Name": $scope.comment }); }
    ////    $scope.addPreComments = function () { $scope.pre.push({ "Name": $scope.prec }); }
    ////    $scope.addPostComments = function () { $scope.post.push({ "Name": $scope.postc }); }

        $scope.save = function (currCard) {

            if (currCard == null) {
                alert('Please enter cardUser name.');
                return;
            }
    //FirstName
            if (currCard.FirstName == null) {
                alert('Please enter First name.');
                return;
            }
    //LastName
            if (currCard.LastName == null) {
                alert('Please enter LastName.');
                return;
            }
        // EmailId
            if (currCard.EmailId == null)
            {
                alert('Please Enter Emailid .');
                return;
           }

   // MobileNumber
            if (currCard.MobileNumber == null)
            {
               alert('Please Enter MobileNumber..');
               return;
           }


   //Address
            if (currCard.AddressId == null) {
               alert('Please Enter Address..');
               return;
            }
   //MiddleName
            if (currCard.MiddleName == null)
            {
                alert('Please enter MiddleName..');
                return;
            }


    // LocationID
    //       if ($scope.jl == null || $scope.jl.id == null) {
    //           alert('Please select location.');
    //           return;
    //       }
    //CustPOC
    //if (newCard.CustPOC == null) {
    //    alert('Please enter Customer POC.');
    //    return;
    //       }
    // EstStartDt
    //        if (newCard.EstStartDt == null) {
    //            alert('Please select estimated start date.');
    //            return;
    //        }
    //  EstEndDt
    //        if (newCard.EstEndDt == null) {
    //            alert('Please select estimated end date.');
    //            return;
    //        }
    // ProjDesc
    //        if (newCard.ProjDesc == null) {
    //            alert('Please enter project description.');
    //            return;
    //        }
    //         StatusId
    //        if ($scope.js == null || $scope.js.Id == null) {
    //            alert('Please select status.');
    //            return;
    //        }



            var currCard = {

                FirstName: currCard.FirstName,
                LastName: currCard.LastName,
                EmailId: currCard.EmailId,
                MobileNumber: currCard.MobileNumber,
                Address: currCard.AddressId,
                CardType: currCard.Name.Id,
                CardNumber: currCard.CardNumber.CardNumber,
                MiddleName: currCard.MiddleName,
                flag: 'I'
                  }

            var req = {
                method: 'POST',
                url: '/api/Cards/SaveCardUser',
                data: currCard
            }
            $http(req).then(function (response) {

                $scope.showDialog("Saved successfully!");
                $scope.getCardDetails(currCard.Id);
                $scope.currCard = null;

            }, function (errres) {
                var errdata = errres.data;
                var errmssg = "";
                errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
                $scope.showDialog(errmssg);
            });
            $scope.currGroup = null;
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

    ////    $scope.GetUsersForCard = function () {
    ////        $http.get('/api/Cards/GetUsersForCards?jobId=' + $scope.j.ID).then(function (res, data) {
    ////            $scope.Users = res.data;
    ////        });
    ////    }

    ////    $scope.GetAssetsModels = function () {
    ////        $http.get('/api/AssetModel/GetAssetModels?locId=-1').then(function (res, data) {
    ////            $scope.Models = res.data;
    ////        });
    ////    }

    ////    $scope.GetAssets = function () {
    ////        $http.get('/api/Jobs/GetEquipmentForJob?modelId=' + $scope.amid.id + '&locationId=' + $scope.currJob.LocationID + '&jobId=' + $scope.j.ID).then(function (res, data) {
    ////            $scope.Assets = res.data;
    ////        });
    ////    }

    ////    $scope.validateFile = function ($event) {
    ////    }

    ////    $scope.onFileSelect = function (files, $event) {
    ////        $scope.modifiedJob = null;
    ////        var found = false;
    ////        check if job already exists 
    ////        for (cnt = 0; cnt < $scope.CardDocs.length; cnt++) {
    ////            if ($scope.CardDocs[cnt].DocName == files[0].name) {
    ////                found = true;
    ////            }
    ////        }

    ////        if (found) {
    ////            alert('Cannot add duplicte documents. Document with the same name already exists.');
    ////            $event.stopPropagation();
    ////            $event.preventDefault();
    ////            return;
    ////        }

    ////        var ext = files[0].name.split('.').pop();
    ////        fileReader.readAsDataUrl(files[0], $scope, (ext == 'csv') ? 1 : 4).then(function (result) {

    ////            if (result.length > 2097152) {
    ////                alert('Cannot upload file greater than 2 MB.');
    ////                $event.stopPropagation();
    ////                $event.preventDefault();
    ////                return;
    ////            }

    ////            var doc =
    ////                {
    ////                    Id: ($scope.CardDoc == null) ? -1 : $scope.CardDoc.Id,
    ////                    CardId: $scope.currCard.ID,
    ////                    createdById: ($scope.userdetails.Id == null) ? 1 : $scope.userdetails.Id,
    ////                    UpdatedById: ($scope.userdetails.Id == null) ? 1 : $scope.userdetails.Id,
    ////                    FromDate: null,
    ////                    ToDate: null,
    ////                      docCatId: $scope.currobj.Id,
    ////                    docTypeId: ($scope.CardDoc == null || $scope.CardDoc.docType == null) ? null : $scope.CardDoc.docType.Id,
    ////                    DocType: ($scope.CardDoc == null || $scope.CardDoc.docType == null) ? null : $scope.CardDoc.docType.Name,//
    ////                    DocName: files[0].name,
    ////                    docContent: result,

    ////                    ExpiryDate: ($scope.CardDoc == null || $scope.CardDoc.ExpiryDate == null) ? null : GetFormattedDate($scope.CardDoc.ExpiryDate),
    ////                    DueDate: ($scope.CardDoc == null || $scope.CardDoc.DueDate == null) ? null : GetFormattedDate($scope.CardDoc.DueDate),

    ////                    insupddelflag: 'I'
    ////                }
    ////            $scope.modifiedJob = doc;

    ////        });
    ////    };

    ////    $scope.EditCardDoc = function (f) {

    ////        for (cnt = 0; cnt < $scope.CardDocs.length; cnt++) {
    ////            if ($scope.CardDocs[cnt].DocName == f.DocName) {
    ////                $scope.assetDoc = $scope.CardDocs[cnt];
    ////                $scope.assetDoc.ExpiryDate = getdateFormat(f.ExpiryDate);
    ////                for (dcnt = 0; dcnt < $scope.docTypes.length; dcnt++) {
    ////                    if ($scope.docTypes[dcnt].Id == f.DocTypeId) {
    ////                        {
    ////                            $scope.assetDoc.dt = $scope.docTypes[dcnt];
    ////                        }
    ////                    }
    ////                }
    ////                break;
    ////            }
    ////        }
    ////    }

    ////    $scope.cancelNewDoc = function () {
    ////        $scope.CardDoc = null;
    ////    }

    ////    $scope.updateDoc = function () {
    ////        if ($scope.assetDoc.dt != null) {
    ////            $scope.assetDoc.docTypeId = $scope.assetDoc.dt.Id;
    ////            $scope.assetDoc.DocType = $scope.assetDoc.dt.Name;
    ////        }
    ////        $scope.assetDoc.insupddelflag = ($scope.assetDoc.Id == -1) ? 'I' : 'U';
    ////        $scope.modifiedJob = $scope.assetDoc;
    ////        $scope.SaveCardDoc();
    ////    }

    ////    $scope.DeleteDoc = function (d) {

    ////        if (d == -1) {
    ////            $scope.assetDoc.slice(d);
    ////        }
    ////        else {
    ////            d.insupddelflag = "D";
    ////            $scope.modifiedJob = d;
    ////            $scope.SaveCardDoc();
    ////        }


    ////    }
    ////    $scope.updateDocType = function () {
    ////        if ($scope.CardDoc != null) {
    ////            $scope.CardDoc.docTypeId = $scope.CardDoc.docType.Id;
    ////            $scope.CardDoc.DocType = $scope.CardDoc.docType.Name;

    ////            $scope.modifiedJob.docTypeId = $scope.CardDoc.docType.Id;
    ////            $scope.modifiedJob.DocType = $scope.CardDoc.docType.Name;
    ////        }
    ////    }
    ////    $scope.updateDocExpDate = function () {

    ////        if ($scope.CardDoc != null) {
    ////            $scope.CardDoc.ExpiryDate = getdateFormat($scope.CardDoc.ExpiryDate);
    ////            $scope.modifiedJob.ExpiryDate = getdateFormat($scope.CardDoc.ExpiryDate);
    ////        }
    ////    }

    ////    $scope.GetFileContent = function (f) {
    ////         var data = $scope.currobj.files1[0];  
    ////        if (f.DocContent != null) {
    ////            openPDF(f.DocContent, f.DocName);
    ////            return;
    ////        }
    ////        else {
    ////            get the file content from db
    ////            $http.get('/api/Cards/GetCardFileContent?CardId=' + f.Id).then(function (res, data) {
    ////                $scope.docDetails = res.data[0];
    ////                openPDF($scope.docDetails.DocContent, res.data[0].DocName);
    ////            });
    ////        }
    ////    }

    ////    function openPDF(resData, fileName) {

    ////        var blob = null;
    ////        var ext = fileName.split('.').pop();
    ////        if (ext == 'csv') {
    ////            blob = new Blob([resData], { type: "text/csv" });
    ////            saveAs(blob, fileName);
    ////        }
    ////        else {

    ////            var ieEDGE = navigator.userAgent.match(/Edge/g);
    ////            var ie = navigator.userAgent.match(/.NET/g); // IE 11+
    ////            var oldIE = navigator.userAgent.match(/MSIE/g);

    ////            if (ie || oldIE || ieEDGE) {
    ////                blob = b64toBlob(resData, (ext == 'csv') ? 'text/csv' : 'application/pdf');
    ////                 window.open(blob, '_blank');
    ////                  window.navigator.msSaveBlob(blob, fileName);
    ////                saveAs(blob, fileName);
    ////                openReportWindow('test', resData, 1000, 700);
    ////                window.open(resData, '_blank');
    ////                  var a = document.createElement("a");
    ////                  document.body.appendChild(a);
    ////                  a.style = "display: none";
    ////                  a.href = resData;
    ////                  a.download = fileName;
    ////                  a.onclick = "window.open(" + fileURL + ", 'mywin','left=200,top=20,width=1000,height=800,toolbar=1,resizable=0')";
    ////                  a.click(); 

    ////            }
    ////            else {

    ////                openReportWindow(fileName, resData, 1000, 700);
    ////                 newWindow =   window.open(resData, 'newwin', 'left=200,top=20,width=1000,height=700,toolbar=1,resizable=0');
    ////                   timerObj = window.setInterval("ResetTitle('"+fileName+"')", 10);
    ////            }
    ////        }
    ////    }

    ////    var winLookup;
    ////    var showToolbar = false;
    ////    function openReportWindow(m_title, m_url, m_width, m_height) {
    ////        var strURL;
    ////        var intLeft, intTop;

    ////        strURL = m_url;

    ////         Check if we've got an open window.
    ////        if ((winLookup) && (!winLookup.closed))
    ////            winLookup.close();

    ////         Set up the window so that it's centered.
    ////        intLeft = (screen.width) ? ((screen.width - m_width) / 2) : 0;
    ////        intTop = 20;//(screen.height) ? ((screen.height - m_height) / 2) : 0;

    ////         Open the window.
    ////        winLookup = window.open('', 'winLookup', 'scrollbars=no,resizable=yes,toolbar=' + (showToolbar ? 'yes' : 'no') + ',height=' + m_height + ',width=' + m_width + ',top=' + intTop + ',left=' + intLeft);
    ////        checkPopup(m_url, m_title);

    ////         Set the window opener.
    ////        if ((document.window != null) && (!winLookup.opener))
    ////            winLookup.opener = document.window;

    ////         Set the focus.
    ////        if (winLookup.focus)
    ////            winLookup.focus();
    ////    }

    ////    function checkPopup(m_url, m_title) {
    ////        if (winLookup.document) {
    ////            identify the file type and display accordingly
    ////            var ext = m_title.split('.').pop();
    ////            switch (ext) {
    ////                case 'pdf':
    ////                    winLookup.document.write('<html><head><title>' + m_title + '</title></head><body height="100%" width="100%"><embed type="application/pdf" src="' + m_url + '" height="100%" width="100%" /></body></html>');
    ////                    break;
    ////                default:
    ////                    winLookup.document.write('<html><head><title>' + m_title + '</title></head><body height="100%" width="100%"><img src="' + m_url + '" height="100%" width="100%" /></body></html>');
    ////                    break;
    ////            }

    ////        } else {
    ////             if not loaded yet
    ////            setTimeout(checkPopup(m_url, m_title), 10); // check in another 10ms
    ////        }
    ////    }

    ////    function b64toBlob(b64Data, contentType) {
    ////        contentType = contentType || '';
    ////        var sliceSize = 512;
    ////        b64Data = b64Data.replace(/^[^,]+,/, '');
    ////        b64Data = b64Data.replace(/\s/g, '');
    ////        var byteCharacters = window.atob(b64Data);
    ////        var byteArrays = [];

    ////        for (var offset = 0; offset < byteCharacters.length; offset += sliceSize) {
    ////            var slice = byteCharacters.slice(offset, offset + sliceSize);

    ////            var byteNumbers = new Array(slice.length);
    ////            for (var i = 0; i < slice.length; i++) {
    ////                byteNumbers[i] = slice.charCodeAt(i);
    ////            }

    ////            var byteArray = new Uint8Array(byteNumbers);

    ////            byteArrays.push(byteArray);
    ////        }

    ////        var blob = new Blob(byteArrays, { type: contentType });
    ////        return blob;
    ////    }

    ////    function GetFormattedDate(date) {
    ////        if (date == null) return '';
    ////        var todayTime = new Date(date);
    ////        var month = todayTime.getMonth() + 1;
    ////        var day = todayTime.getDate();
    ////        var year = todayTime.getFullYear();
    ////        return new Date(month + "/" + day + "/" + year);
    ////    }

    ////    function getdateFormat(date) {
    ////        var formateddate = date;

    ////        if (date) {
    ////            formateddate = $filter('date')(date, 'MM-dd-yyyy');
    ////        }

    ////        return formateddate;
    ////    }

    ////    $scope.GetDetailsEditHistory = function (hist) {
    ////        $http.get('/api/Cards/GetCardHistoryDetails?ehId=' + hist.Id).then(function (res, data) {
    ////            $scope.detailedhist = res.data;
    ////        });
    ////    }

    ////    /*save job documents */
    ////    $scope.SaveCardDoc = function (jdoc) {

    ////        if ($scope.modifiedJob == null) {

    ////            alert('Select a job to modify.');
    ////            return;
    ////        }

    ////         $scope.modifiedJob.createdById = ($scope.userdetails.Id == null) ? 1 : $scope.userdetails.Id;
    ////        $scope.modifiedCard.UpdatedById = ($scope.userdetails.Id == null) ? 1 : $scope.userdetails.Id;

    ////        var req = {
    ////            method: 'POST',
    ////            url: '/api/Cards/SaveCardDocs',
    ////            data: $scope.modifiedJob
    ////        }
    ////        $http(req).then(function (response) {

    ////            $scope.showDialog("Saved successfully!");
    ////             $scope.getJobDetails($scope.modifiedJob.JobId);

    ////            $scope.CardDocs = response.data.Table;
    ////            $scope.assetHistory = response.data.Table1;

    ////            if ($scope.CardDocs) {
    ////                if ($scope.CardDocs.length > 0) {
    ////                    for (i = 0; i < $scope.CardDocs.length; i++) {
    ////                        $scope.CardDocs[i].expiryDate = getdateFormat($scope.CardDocs[i].expiryDate);

    ////                    }
    ////                }
    ////            }

    ////            $scope.modifiedJob = null;
    ////            $scope.assetDoc = null;

    ////        }, function (errres) {
    ////            var errdata = errres.data;
    ////            var errmssg = "";
    ////            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
    ////            $scope.modifiedJob = null;
    ////            $scope.assetDoc = null;
    ////            $scope.showDialog(errmssg);
    ////        });
    ////    }
    ////    myapp1.controller('ModalInstanceCtrl', function ($scope, $uibModalInstance, mssg) {

    ////        $scope.mssg = mssg;
    ////        $scope.ok = function () {
    ////            $uibModalInstance.close('test');
    ////        };

    ////        $scope.cancel = function () {
    ////            $uibModalInstance.dismiss('cancel');
    ////        };

    ////        $scope.showDialog = function (message) {

    ////            var modalInstance = $uibModal.open({
    ////                animation: $scope.animationsEnabled,
    ////                templateUrl: 'myModalContent.html',
    ////                controller: 'ModalInstanceCtrl',
    ////                resolve: {
    ////                    mssg: function () {
    ////                        return message;
    ////                    }
    ////                }
    ////            });
    ////        }


});