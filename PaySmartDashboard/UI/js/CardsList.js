// JavaScript source code
var myapp1 = angular.module('myApp', ['ngStorage', 'ui.bootstrap']);

var mycrtl1 = myapp1.controller('myCtrl', function ($scope, $http, $localStorage, $uibModal, $filter) {
    if ($localStorage.uname == null) {
        window.location.href = "login.html";
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.isSuperUser = $localStorage.isSuperUser;
    $scope.roleLocations = $localStorage.roleLocation;
    $scope.isAdminSupervisor = $localStorage.isAdminSupervisor;

    $scope.init = function ()
    {
        $http.get('/api/Cards/GetCategoriesLists').then(function (res, data) {
            $scope.CategoriesLists = res.data;
            $scope.CardListData();
        });
    }

    $scope.CardListData = function ()
    {
        $http.get('/api/Cards/CardListData').then(function (res, data) {
            $scope.CardListData = res.data;
           $scope.CardList = res.data;
        });
    } 

   // $scope.CardListData1 = function ()
   // {
   //    // $scope.CardList = null;

   //     // var locId = ($scope.s == null || $scope.s.id == null) ? -1 : $scope.s.id;
   //     var Id = ($scope.c == null || $scope.c.Id == null) ? -1 : $scope.c.Id;
   //     var statusId = ($scope.a == null || $scope.a.Id == null) ? -1 : $scope.a.Id;

   //     $http.get('/api/Cards/GetCardList?statusId=' + statusId +/* '&locationId=' + locId + */'&Id=' + custId).then(function (res, data) {
   //         $scope.CardList1 = res.data;
   //         $scope.CardList = res.data;
   //     });
   //     //  $scope.CheckCanCreate(locId);   
   //}

    //$scope.CardModelData = function ()
    //{
    //    $http.get('/api/Cards/CardModelData').then(function (res, data) {
    //        $scope.CardModelData = res.data;
    //        $scope.CardList = res.data;
    //    });
    //}
    //$scope.CardModelData1 = function ()
    //{
    //    $scope.CardList = null;

    //     var locId = ($scope.s == null || $scope.s.id == null) ? -1 : $scope.s.id;
    //    var Id = ($scope.c == null || $scope.c.Id == null) ? -1 : $scope.c.Id;
    //    var statusId = ($scope.a == null || $scope.a.Id == null) ? -1 : $scope.a.Id;



    //    $http.get('/api/Cards/GetCardList?statusId=' + statusId +/* '&locationId=' + locId + */'&Id=' + custId).then(function (res, data) {
    //        $scope.CardList1 = res.data;
    //        $scope.CardList = res.data;
    //    });
    //      $scope.CheckCanCreate(locId);   
    //}
    //$scope.CardTypeData = function () {
    //    $http.get('/api/Cards/CardTypeData').then(function (res, data) {
    //        $scope.CardTypeData = res.data;
    //        $scope.CardList = res.data;
    //    });
    //}

    //$scope.CardTypeData1 = function () {
    //    $scope.CardList = null;

    //     var locId = ($scope.s == null || $scope.s.id == null) ? -1 : $scope.s.id;
    //    var Id = ($scope.c == null || $scope.c.Id == null) ? -1 : $scope.c.Id;
    //    var statusId = ($scope.a == null || $scope.a.Id == null) ? -1 : $scope.a.Id;



    //    $http.get('/api/Cards/GetCardList?statusId=' + statusId +/* '&locationId=' + locId + */'&Id=' + custId).then(function (res, data) {
    //        $scope.CardList1 = res.data;
    //        $scope.CardList = res.data;
    //    });
    //      $scope.CheckCanCreate(locId);   
    //}
    $scope.GetCategoriesLists = function () {
        $http.get('/api/Cards/GetCategoriesLists').then(function (res, data) {
            $scope.CategoriesLists = res.data;
            $scope.CardList = res.data;
        });
    }

    //$scope.GetCategoriesLists1= function () {
    //    $scope.CardList = null;

    //     var locId = ($scope.s == null || $scope.s.id == null) ? -1 : $scope.s.id;
    //    var Id = ($scope.c == null || $scope.c.Id == null) ? -1 : $scope.c.Id;
    //    var statusId = ($scope.a == null || $scope.a.Id == null) ? -1 : $scope.a.Id;



    // $http.get('/api/Cards/GetCardList?statusId=' + statusId +/* '&locationId=' + locId + */'&Id=' + custId).then(function (res, data) {
    //        $scope.CardList1 = res.data;
    //        $scope.CardList = res.data;
    //    });
    //      $scope.CheckCanCreate(locId);   
    //}

    $scope.GetAllCardOptions = function ()
    {
        $http.get('/api/Cards/GetAllCardOptions').then(function (res, data) {
            $scope.cardcat = res.data.Table;
            $scope.cardmodel = res.data.Table1;
            $scope.cardtype = res.data.Table2;
        });

       
        $scope.getselectval = function (seltype)
        {
                var grpid = (seltype) ? seltype.Id : -1;
                //to save new inventory item
                $http.get('/api/Cards/GetAllCardOptions?Id=' + grpid).then(function (res, data) 
                {
                    $scope.cardcat = res.data.Table;
                    $scope.cardmodel = res.data.Table1;
                    $scope.cardtype = res.data.Table2;
                });
        }

        $scope.saveNew = function (list) {

            var list = {

                CardNumber: list.CardNumber,
                CardModel: list.CardModel.Id,
                CardType: list.CardType.Id,
                CardCategory: list.CardCategory.Id,
                flag: 'I'

            }
       

            var req = {
                method: 'POST',
                url: '/api/Cards/AddNewCardData3',
                //headers: {
                // 'Content-Type': undefined
                data: list
            }
            $http(req).then(function (res)
            {
                $scope.list = null;

            }, function (errres) {
                var errdata = errres.data;
                var errmssg = errdata.ExceptionMessage;
                errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
                $scope.showDialog(errmssg);
            });
            $scope.currGroup = null;
        };
    }
//});

    //$scope.save = function (Cards)
    //{
    //    var Cards = {

    //        CardNum: Cards.CardNumber,
    //        CardModel: Cards.CardModel,
    //        CardType: Cards.CardType,
    //        CardCategory: Cards.CardCategory,
    //        flag: 'I'
    //    };

    //    var req = {
    //        method:'POST',
    //        url:'../api/Cards/AddNewCardData3',
    //        //headers: {
    //        // 'Content-Type': undefined
    //        data: Cards
    //    }

    //    $http(req).then(function (response) {



    //       $scope.Group = null;

    //    }, function (errres) {
    //        var errdata = errres.data;
    //        var errmssg = "";
    //        errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
    //        $scope.showDialog(errmssg);
    //    });
    //       $scope.currGroup = null;
    //};

    

  //$scope.showDialog = function (message)
  //{

  //          var modalInstance = $uibModal.open(
  //              {
  //                  animation: $scope.animationsEnabled,
  //                  templateUrl: 'myModalContent.html',
  //                  controller: 'ModalInstanceCtrl',
  //                  resolve:
  //                  {
  //                      mssg: function () {
  //                          return message;
  //                      }
  //                  }
  //              });
  //}
        //  myapp1.controller('ModalInstanceCtrl', function ($scope, $uibModalInstance, mssg)
        //{

        //    $scope.mssg = mssg;
        //    $scope.ok = function () {
        //        $uibModalInstance.close('test');
        //    };

        //    $scope.cancel = function () {
        //        $uibModalInstance.dismiss('cancel');
        //    };

        //    $scope.showDialog = function (message) {

        //        var modalInstance = $uibModal.open(
        //            {
        //                animation: $scope.animationsEnabled,
        //                templateUrl: 'myModalContent.html',
        //                controller: 'ModalInstanceCtrl',
        //                resolve: {
        //                    mssg: function ()
        //                    {
        //                        return message;
        //                    }
        //                }
        //            });
        //    }
        //  });
});