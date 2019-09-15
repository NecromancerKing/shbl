(function () {
    'use strict';

    angular
        .module('app.controllers.home')
        .controller("headerController", headerController);

    headerController.$inject = ['$scope', 'homeService', 'authService', 'generalService', '$rootScope', '$timeout', 'storageService'];

    function headerController($scope, homeService, authService, generalService, $rootScope, $timeout, storageService) {
        if (homeService.header)
        {
            $timeout(function () {
                $scope.model = homeService.header;
            });
        }

        generalService.profileUpdatedEvent.subscribe($rootScope, function (event, data) {
            $timeout(function () {
                $scope.model = data;
            });
        });

        $scope.logout = function () {
            storageService.activityInfo.clear();
            authService.logout();
        }
    };
})();