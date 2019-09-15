(function ()
{
    'use strict';

    angular
        .module('app.controllers.account')
        .controller("forgetPasswordController", forgetPasswordController);

    forgetPasswordController.$inject = ['model', '$scope', 'webAuthService', 'authService'];

    function forgetPasswordController(model, $scope, webAuthService, authService)
    {
        var model = webAuthService.forgetPassword;
    };
})();