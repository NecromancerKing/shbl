(function ()
{
    'use strict';

    angular
        .module('app.controllers.account')
        .controller("authHomeController", authHomeController);

    authHomeController.$inject = ['model', '$scope', 'webAuthService'];

    function authHomeController(model, $scope, webAuthService)
    {
        
    };
})();