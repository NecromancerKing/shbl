(function ()
{
    'use strict';

    angular
        .module('app.common')
        .config(localStorageServiceConfig);

    localStorageServiceConfig.$inject = ['$provide', 'localStorageServiceProvider'];

    function localStorageServiceConfig($provide, localStorageServiceProvider)
    {
        localStorageServiceProvider.setPrefix('oratio');

        $provide.decorator('localStorageService', ['$delegate', function ($delegate)
        {

            //store original get & set methods
            var originalGet = $delegate.get,
                originalSet = $delegate.set;

            /**
             * extending the localStorageService get method
             *
             * @param key
             * @returns {*}
             */
            $delegate.get = function (key)
            {
                if (originalGet(key))
                {
                    var data = originalGet(key);

                    if (data.expiryDate)
                    {
                        var now = Date.now();

                        // return null if it timed out
                        if (data.expiryDate < now)
                        {
                            $delegate.remove(key);
                            return null;
                        }
                        else
                        {
                            //Renew expiryDate
                            if (data.expires)
                            {
                                $delegate.remove(key);
                                data.expiryDate = Date.now() + (1000 * 60 * data.expires);
                                originalSet(key, data);
                            }

                            return data.data;
                        }
                    }
                    else
                    {
                        return data;
                    }
                }
                else
                {
                    return null;
                }
            };

            /**
             * set
             * @param key               key
             * @param val               value to be stored
             * @param {int} expires     minutes until the localStorage expires
             * @param {bool} renew      renew on get
             */
            $delegate.set = function (key, val, expires, renew)
            {
                var expiryDate = null;

                if (angular.isNumber(expires))
                {
                    expiryDate = Date.now() + (1000 * 60 * expires);

                    var data =
                        {
                            data: val,
                            expiryDate: expiryDate,
                        };

                    if (renew === true)
                    {
                        data.expires = expires;
                    }

                    originalSet(key, data);
                }
                else
                {
                    originalSet(key, val);
                }
            };

            return $delegate;
        }]);
    }

})();