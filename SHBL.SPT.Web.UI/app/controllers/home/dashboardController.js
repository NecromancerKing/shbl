(function () {
    'use strict';

    angular
        .module('app.controllers.home')
        .controller("dashboardController", dashboardController);

    dashboardController.$inject = ['$scope', '$timeout', 'homeService', 'storageService', 'generalService', 'stateService'];

    function dashboardController($scope, $timeout, homeService, storageService) {
        var model = homeService.dashboard;
        $scope.lang = 'en';

        $timeout(function () {
            $scope.activityRoute = null;
            $scope.activity = storageService.activityInfo.get();

            if ($scope.activity !== null && $scope.activity.ActivityName !== null) {
                switch ($scope.activity.ActivityName) {
                    case 'PreTest':
                        $scope.activityRoute = 'app.activity.pretest';
                        break;
                    case 'Training':
                        $scope.activityRoute = 'app.activity.training';
                        break;
                    case 'PostTest':
                        $scope.activityRoute = 'app.activity.posttest';
                        break;
                }
            }
        });

        homeService.getIndicators().then(function (data) {
            $scope.indicators = data.Indicators;
        }, function (error) {

        });

        $scope.switchLang = function (lang) {
            $scope.lang = lang;
        }
    };
})();