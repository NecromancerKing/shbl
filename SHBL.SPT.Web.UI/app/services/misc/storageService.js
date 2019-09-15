(function ()
{
    'use strict';

    angular
        .module("app.services.misc")
        .factory("storageService", storageService);

    storageService.$inject = ['localStorageService'];

    function storageService(localStorageService)
    {
        var storageServiceFactory = {};

        //BEGIN Variables//

        var _authDataKey = 'authData';
        var _authDataExpires = 120;

        var _redirectObjectKey = 'redirectObject';
        var _activityInfoKey = 'activityInfor';

        //END Variables//

        //BEGIN PROPERTIES//

        var _authData =
            {
                set: function (val)
                {
                    localStorageService.set(_authDataKey, val, _authDataExpires, true);
                },
                get: function ()
                {
                    return localStorageService.get(_authDataKey);
                },
                clear: function ()
                {
                    localStorageService.remove(_authDataKey);
                }
            };

        var _redirectObject =
            {
                set: function (val)
                {
                    localStorageService.set(_redirectObjectKey, val);
                },
                get: function ()
                {
                    return localStorageService.get(_redirectObjectKey);
                },
                clear: function ()
                {
                    localStorageService.remove(_redirectObjectKey);
                }
            };

        var _activityInfo =
            {
                set: function (val) {
                    localStorageService.set(_activityInfoKey, val);
                },
                get: function () {
                    return localStorageService.get(_activityInfoKey);
                },
                clear: function () {
                    localStorageService.remove(_activityInfoKey);
                }
            };

        //END PROPERTIES//

        storageServiceFactory.authData = _authData;
        storageServiceFactory.redirectObject = _redirectObject;
        storageServiceFactory.activityInfo = _activityInfo;

        return storageServiceFactory;
    };
})();