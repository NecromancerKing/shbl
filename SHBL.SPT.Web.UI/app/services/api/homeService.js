(function () {
    'use strict';

    angular
        .module("app.services.api")
        .factory("homeService", homeService);

    homeService.$inject = ['$http', 'ngSettings'];

    function homeService($http, ngSettings) {
        var serviceBase = ngSettings.apiServiceBaseUri + "Home";

        var homeServiceFactory = {};

        //API Methods//

        var _getDashboard = function () {
            return $http.get(serviceBase + "/Dashboard").then(function (response) {
                return response.data;
            });
        };

        var _getHeader = function () {
            return $http.get(serviceBase + "/Header").then(function (response) {
                homeServiceFactory.header = response.data;
                return response.data;
            });
        };

        var _getIndicators = function () {
            return $http.get(serviceBase + "/GetIndicators").then(function (response) {
                return response.data;
            });
        };

        //API Methods//

        //Proxy//

        homeServiceFactory.getDashboard = _getDashboard;
        homeServiceFactory.getHeader = _getHeader;
        homeServiceFactory.getIndicators = _getIndicators;

        //Proxy//

        return homeServiceFactory;
    };
})();