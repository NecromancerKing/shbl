(function ()
{
    'use strict';

    angular
        .module("app.services.misc")
        .factory("generalService", generalService);

    generalService.$inject = ['$http', 'eventService', 'ngSettings'];

    function generalService($http, eventService, ngSettings)
    {
        var generalServiceFactory = {};

        var _profileUpdatedEvent = eventService.createEvent('profileUpdatedEvent');
        var _activityCompletedEvent = eventService.createEvent('activityCompletedEvent');

        var _GetClientInfo = function () {
            var serviceBase = ngSettings.apiServiceBaseUri + "Home";
            return $http.get(serviceBase + "/ClientInfo").then(function (response) {
                return response.data;
            });
        };

        var _getUserProfile = function () {
            var serviceBase = ngSettings.apiServiceBaseUri + "Account";
            return $http.get(serviceBase + "/UserProfile").then(function (response) {
                return response.data;
            });
        };

        generalServiceFactory.profileUpdatedEvent = _profileUpdatedEvent;
        generalServiceFactory.activityCompletedEvent = _activityCompletedEvent;
        generalServiceFactory.GetClientInfo = _GetClientInfo;
        generalServiceFactory.getUserProfile = _getUserProfile;

        return generalServiceFactory;
    }

})();