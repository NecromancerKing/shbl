(function ()
{
    'use strict';

    angular
        .module("app.services.misc")
        .factory("authInterceptorService", authInterceptorService);

    authInterceptorService.$inject = ['$q', '$injector', '$location', 'ngSettings', 'storageService'];

    function authInterceptorService($q, $injector, $location, ngSettings, storageService)
    {
        var inflightAuthRequest = null;
        var refreshTokenUrl = ngSettings.apiServiceBaseUri + 'Auth/RefreshToken';

        var authInterceptorServiceFactory = {};
        //BEGIN Methods//

        var _request = function (config)
        {
            if (config.url.toLowerCase().startsWith(ngSettings.apiServiceBaseUri.toLowerCase()))
            {
                config.headers = config.headers || {};

                var authData = storageService.authData.get();

                if (authData && authData.isAuthenticated)
                {
                    config.headers.Authorization = 'Bearer ' + authData.accessToken;
                }
            }

            return config;
        }

        var _responseError = function (response)
        {
            var config = response.config;

            if (config.url.toLowerCase() === refreshTokenUrl.toLowerCase())
            {
                return $q.reject(response);
            }

            var authService = $injector.get("authService");

            if (config.url.toLowerCase().startsWith(ngSettings.apiServiceBaseUri.toLowerCase()))
            {
                switch (response.status)
                {
                    case 401:
                        var authData = storageService.authData.get();

                        var deferred = $q.defer();

                        if (authData && authData.isAuthenticated)
                        {
                            if (!inflightAuthRequest)
                            {
                                inflightAuthRequest = $injector.get("$http").post(refreshTokenUrl, { RefreshToken: authData.refreshToken }, { ignoreLoadingBar: true });
                            }

                            inflightAuthRequest.then(function (r)
                            {
                                inflightAuthRequest = null;

                                if (r.status == 200)
                                {
                                    console.log("TOKEN REFRESHED");

                                    if (r && r.data && authService.setAuthData(r.data))
                                    {
                                        $injector.get("$http")(response.config).then(function (resp)
                                        {
                                            deferred.resolve(resp);
                                        },
                                        function (resp)
                                        {
                                            deferred.reject();
                                            return;
                                        });
                                    }
                                    else
                                    {
                                        deferred.reject();
                                        authService.logout();
                                    }
                                }
                                else
                                {
                                    console.log("TOKEN REFRESH FAILED");

                                    deferred.reject();
                                    authService.logout();
                                }
                            },
                            function (response)
                            {
                                inflightAuthRequest = null;

                                console.log("TOKEN REFRESH FAILED");

                                deferred.reject();
                                authService.logout();
                            });

                            return deferred.promise;
                        }
                        else
                        {
                            deferred.reject();
                            authService.logout();
                            //return;
                        }
                        break;
                    case 403:
                        var stateService = $injector.get('stateService');
                        stateService.go('app.error.403');
                        break;
                    default:
                        return $q.reject(response);
                }
            }

            return response || $q.when(response);
        }

        //END Methods//

        //BEGIN Proxy//

        authInterceptorServiceFactory.request = _request;
        authInterceptorServiceFactory.responseError = _responseError;

        //END Proxy//

        return authInterceptorServiceFactory;
    }
})();