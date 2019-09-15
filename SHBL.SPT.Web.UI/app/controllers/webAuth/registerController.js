(function () {
    'use strict';

    angular
        .module('app.controllers.account')
        .controller("registerController", registerController);

    registerController.$inject = ['model', '$scope', '$interval', 'webAuthService', 'authService', 'errorHandler', 'notificationService', 'NOTIFICATION_SETTINGS'];

    function registerController(model, $scope, $interval, webAuthService, authService, errorHandler, notificationService, NOTIFICATION_SETTINGS) {
        $scope.registerModel = {};
        $scope.registerModel.gender = 1;
        $scope.registerModel.ageGroup = 1;
        $scope.registerModel.proficiencyLevel = 1;

        $scope.submit = function (registerModel) {
            authService.register(registerModel).error(function (error) {
                if (error && error.Message && error.Message === 'Email address is not available!') {
                    notificationService.show(error.Message, NOTIFICATION_SETTINGS.TYPE.DANGER, NOTIFICATION_SETTINGS.POSITION.BOTTOM_RIGHT, 8000);
                }
                else {
                    notificationService.show('Error in account creation!', NOTIFICATION_SETTINGS.TYPE.DANGER, NOTIFICATION_SETTINGS.POSITION.BOTTOM_RIGHT, 8000);
                }
            });
        };
    };
})();