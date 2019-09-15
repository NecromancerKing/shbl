(function () {
    'use strict';

    angular
        .module('app.controllers.home')
        .controller("sidebarController", sidebarController);

    sidebarController.$inject = ['$scope', '$rootScope', 'homeService', 'storageService', 'generalService', '$timeout', 'notificationService', 'NOTIFICATION_SETTINGS'];

    function sidebarController($scope, $rootScope, homeService, storageService, generalService, $timeout, notificationService, NOTIFICATION_SETTINGS) {
        $timeout(function () {
            $scope.model = storageService.activityInfo.get();
        });

        generalService.activityCompletedEvent.subscribe($rootScope, function (event, data) {
            $timeout(function () {
                $scope.model = data;
            });
        });
    };
})();