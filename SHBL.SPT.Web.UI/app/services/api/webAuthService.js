(function ()
{
    'use strict';

    angular
        .module("app.services.api")
        .factory("webAuthService", webAuthService);

    webAuthService.$inject = ['$http', 'ngSettings'];

    function webAuthService($http, ngSettings)
    {
        var serviceBase = ngSettings.apiServiceBaseUri + "WebAuth";

        var webAuthServiceFactory = {};

        //API Methods//

        var _getAuthHome = function ()
        {
            return $http.get(serviceBase + "/AuthHome").then(function (response)
            {
                return response.data;
            });
        };

        var _getLogin = function ()
        {
            return $http.get(serviceBase + "/Login").then(function (response)
            {
                return response.data;
            });
        };

        var _getForgetPassword = function ()
        {
            return $http.get(serviceBase + "/ForgetPassword").then(function (response)
            {
                return response.data;
            });
        };

        var _getLoginSocial = function ()
        {
            return $http.get(serviceBase + "/LoginSocial").then(function (response)
            {
                return response.data;
            });
        };

        var _getRegister = function ()
        {
            return $http.get(serviceBase + "/Register").then(function (response)
            {
                return response.data;
            });
        };

        //API Methods//

        //Proxy//

        webAuthServiceFactory.getAuthHome = _getAuthHome;
        webAuthServiceFactory.getLogin = _getLogin;
        webAuthServiceFactory.getForgetPassword = _getForgetPassword;
        webAuthServiceFactory.getLoginSocial = _getLoginSocial;
        webAuthServiceFactory.getRegister = _getRegister;

        //Proxy//

        return webAuthServiceFactory;
    };
})();