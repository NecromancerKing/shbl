(function ()
{
    'use strict';

    angular
        .module('app.controllers.account')
        .controller("loginController", loginController);

    loginController.$inject = ['model', '$scope', 'webAuthService', 'authService', 'notificationService', 'NOTIFICATION_SETTINGS'];

    function loginController(model, $scope, webAuthService, authService, notificationService, NOTIFICATION_SETTINGS)
    {
        $scope.submit = function (loginModel)
        {
            authService.login(loginModel).error(function (error)
            {
                notificationService.show("Username or passowrd is incorrect!", NOTIFICATION_SETTINGS.TYPE.DANGER, NOTIFICATION_SETTINGS.POSITION.BOTTOM_RIGHT, 6000);
            });
        };
    };
})();