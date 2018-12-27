//var app = angular.module('myApp', ['']);

//angular module
var myApp = angular.module('myApp', ['ngStorage']);

//test controller
myApp.controller('myCtrl', function ($scope, $http, $localStorage) {
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.Roleid = $scope.userdetails[0].roleid;

    $scope.dashboardDS = $localStorage.dashboardDS;
    $scope.roleName = null;
    $scope.GetCompanys = function (c) {
        //roleList1 to treeview
        // $scope.roleList = $scope.roleList2;
        //alert();
       
    }

    $scope.roleList1 = [
    {
        "label": "User", "id": "role1", "children": [
          { "label": "subUser1", "id": "role11", "children": [] },
          {
              "label": "subUser2", "id": "role12", "children": [
                {
                    "label": "subUser2-1", "id": "role121", "children": [
                      { "label": "subUser2-1-1", "id": "role1211", "children": [] },
                      { "label": "subUser2-1-2", "id": "role1212", "children": [] }
                    ]
                }
              ]
          }
        ]
    },
    { "label": "Admin", "id": "role2", "children": [] },
    { "label": "Guest", "id": "role3", "children": [] }
    ];

    //test tree model 2
    $scope.roleList2 = [
        {
            "roleName": "User", "roleId": "role1", "collapsed": true, "children": [
          { "roleName" : "subUser1", "roleId" : "role11", "collapsed" : true, "children" : [] },
          { "roleName" : "subUser2", "roleId" : "role12", "collapsed" : true, "children" : [
            { "roleName" : "subUser2-1", "roleId" : "role121", "children" : [
              { "roleName" : "subUser2-1-1", "roleId" : "role1211", "children" : [] },
              { "roleName" : "subUser2-1-2", "roleId" : "role1212", "children" : [] }
            ]}
          ]}
            ]},

        {
            "roleName": "Admin", "roleId": "role2", "collapsed": true, "children": [
          { "roleName" : "subAdmin1", "roleId" : "role11", "collapsed" : true, "children" : [] },
          { "roleName" : "subAdmin2", "roleId" : "role12", "children" : [
            { "roleName" : "subAdmin2-1", "roleId" : "role121", "children" : [
              { "roleName" : "subAdmin2-1-1", "roleId" : "role1211", "children" : [] },
              { "roleName" : "subAdmin2-1-2", "roleId" : "role1212", "children" : [] }
            ]}
          ]}
            ]},

        {
            "roleName": "Guest", "roleId": "role3", "collapsed": true, "children": [
          { "roleName" : "subGuest1", "roleId" : "role11", "children" : [] },
          { "roleName" : "subGuest2", "roleId" : "role12", "collapsed" : true, "children" : [
            { "roleName" : "subGuest2-1", "roleId" : "role121", "children" : [
              { "roleName" : "subGuest2-1-1", "roleId" : "role1211", "children" : [] },
              { "roleName" : "subGuest2-1-2", "roleId" : "role1212", "children" : [] }
            ]}
          ]}
            ]}
    ];


    $scope.list = [
       [{
           "roleName": "User", "roleId": "role1", "collapsed": true, "children": [
         { "roleName": "subUser1", "roleId": "role11", "collapsed": true, "children": [] },
         {
             "roleName": "subUser2", "roleId": "role12", "collapsed": true, "children": [
             {
                 "roleName": "subUser2-1", "roleId": "role121", "children": [
                 { "roleName": "subUser2-1-1", "roleId": "role1211", "children": [] },
                 { "roleName": "subUser2-1-2", "roleId": "role1212", "children": [] }
                 ]
             }
             ]
         }
           ]
       },

       {
           "roleName": "Admin", "roleId": "role2", "collapsed": true, "children": [
         { "roleName": "subAdmin1", "roleId": "role11", "collapsed": true, "children": [] },
         {
             "roleName": "subAdmin2", "roleId": "role12", "children": [
             {
                 "roleName": "subAdmin2-1", "roleId": "role121", "children": [
                 { "roleName": "subAdmin2-1-1", "roleId": "role1211", "children": [] },
                 { "roleName": "subAdmin2-1-2", "roleId": "role1212", "children": [] }
                 ]
             }
             ]
         }
           ]
       }], [{
           "roleName": "User1", "roleId": "role1", "collapsed": true, "children": [
         { "roleName": "subUser1", "roleId": "role11", "collapsed": true, "children": [] },
         {
             "roleName": "subUser2", "roleId": "role12", "collapsed": true, "children": [
             {
                 "roleName": "subUser2-1", "roleId": "role121", "children": [
                 { "roleName": "subUser2-1-1", "roleId": "role1211", "children": [] },
                 { "roleName": "subUser2-1-2", "roleId": "role1212", "children": [] }
                 ]
             }
             ]
         }
           ]
       },

       {
           "roleName": "Admin", "roleId": "role2", "collapsed": true, "children": [
         { "roleName": "subAdmin1", "roleId": "role11", "collapsed": true, "children": [] },
         {
             "roleName": "subAdmin2", "roleId": "role12", "children": [
             {
                 "roleName": "subAdmin2-1", "roleId": "role121", "children": [
                 { "roleName": "subAdmin2-1-1", "roleId": "role1211", "children": [] },
                 { "roleName": "subAdmin2-1-2", "roleId": "role1212", "children": [] }
                 ]
             }
             ]
         }
           ]
       }]
    ]; 
    this.updateChange1 = function (c, scope) {       
        c.children.push({ "roleName": "subGuest2-1-2ddddddddd", "roleId": "role1212", "children": [] });      
        //$scope.r1 = c.roleName;
        scope.$parent.r1 = c.roleName;
    }
});
