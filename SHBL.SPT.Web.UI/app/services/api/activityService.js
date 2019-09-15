(function ()
{
    'use strict';

    angular
        .module("app.services.api")
        .factory("activityService", activityService);

    activityService.$inject = ['$http', 'ngSettings'];


    function activityService($http, ngSettings)
    {
        var serviceBase = ngSettings.apiServiceBaseUri + "Activity";

        var activityServiceFactory = {};

        //API Methods//

        var _populateActivity = function (request)
        {
            return $http.post(serviceBase + "/PopulateActivity", request).then(function (response)
            {
                return response.data;
            });
        };

        var _getNextWord = function (request)
        {
            return $http.post(serviceBase + "/GetNextWord", request).then(function (response) {
                return response.data;
            });
        };

        var _updateQuestion = function (request) {
            return $http.post(serviceBase + "/UpdateQuestion", request).then(function (response) {
                return response.data;
            });
        };

        var _getTestResult = function (request) {
            return $http.get(serviceBase + "/GetTestResult").then(function (response) {
                return response.data;
            });
        };

        //API Methods//

        //Proxy//

        activityServiceFactory.populateActivity = _populateActivity;
        activityServiceFactory.getNextWord = _getNextWord;
        activityServiceFactory.updateQuestion = _updateQuestion;
        activityServiceFactory.getTestResult = _getTestResult;

        //Proxy//

        return activityServiceFactory;
    };
})();