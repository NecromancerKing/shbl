(function ()
{
    'use strict';

    angular
        .module('app.controllers.account')
        .controller("authCompleteController", authCompleteController);

    authCompleteController.$inject = ['$scope', 'urlHelper', 'authService'];

    function authCompleteController($scope, urlHelper, authService)
    {
        var fragment = urlHelper.getFragment();

        window.location.hash = fragment.state || '';
        authService.obtainLocalAccessToken(fragment.provider, fragment.external_access_token);
    };
})();