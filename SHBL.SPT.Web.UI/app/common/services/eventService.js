(function ()
{
    'use strict';

    angular
        .module('app.common.services')
        .factory('eventService', eventService);

    eventService.$inject = ['$rootScope'];

    function eventService($rootScope)
    {
        var eventServiceFactory = {};

        var _event = function (eventName)
        {
            return {
                subscribe: function (scope, callback)
                {
                    var handler = scope.$on(eventName, callback);
                    scope.$on('$destroy', handler);

                    return callback;
                },

                unsubscribe: function (scope, callback)
                {
                    var eventArr = scope.$$listeners[eventName];
                    console.log(handler.name);
                    console.log($rootScope.$$listeners[eventName]);
                    for (var i = 0; i < eventArr.length; i++)
                    {
                        if (eventArr[i] === callback)
                        {
                            eventArr.splice(i, 1);
                            break;
                        }
                    }
                },

                publish: function (data)
                {
                    $rootScope.$emit(eventName, data);
                }
            }
        };

        eventServiceFactory.createEvent = function (eventName)
        {
            return _event(eventName);
        }

        //eventServiceFactory.getEvent = function (eventName)
        //{
        //    var event;

        //    if (false)
        //    {
        //        event = _event(eventName);
        //    }

        //    return event;
        //}

        return eventServiceFactory;
    };
})();