(function () {
    'use strict';

    angular
        .module("app.services.api")
        .factory("accountService", accountService);

    accountService.$inject = ['$http', 'ngSettings'];

    function accountService($http, ngSettings) {
        var serviceBase = ngSettings.apiServiceBaseUri + "Account";

        var accountServiceFactory = {};

        //API Methods//

        var _getUserProfile = function () {
            return $http.get(serviceBase + "/UserProfile").then(function (response) {
                return response.data;
            });
        };

        var _getAddUser = function () {
            return $http.get(serviceBase + "/GetAddUser").then(function (response) {
                return response.data;
            });
        };

        var _updateProfile = function (request) {
            return $http.post(serviceBase + "/UpdateProfile", request).then(function (response) {
                return response.data;
            });
        };

        var _addUser = function (request) {
            return $http.post(serviceBase + "/AddUser", request).then(function (response) {
                return response.data;
            });
        };

        //API Methods//

        //Proxy//

        accountServiceFactory.getUserProfile = _getUserProfile;
        accountServiceFactory.getAddUser = _getAddUser;
        accountServiceFactory.updateProfile = _updateProfile;
        accountServiceFactory.addUser = _addUser;

        //Proxy//

        return accountServiceFactory;
    };
})();