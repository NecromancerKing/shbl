(function ()
{
    'use strict';

    angular
        .module('app.controllers.account')
        .controller("loginSocialController", loginSocialController);

    loginSocialController.$inject = ['model', '$scope', 'webAuthService', 'authService'];

    function loginSocialController(model, $scope, webAuthService, authService)
    {
        $scope.authExternalProvider = function (provider)
        {
            authService.externalLogin(provider);
            window.$windowScope = $scope;
        };
    };
})();