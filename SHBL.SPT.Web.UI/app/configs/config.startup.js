(function ()
{
    'use strict';

    angular
        .module('app')
        .config(appConfig);

    appConfig.$inject = ['$httpProvider'];

    function appConfig($httpProvider)
    {
        $httpProvider.interceptors.push('authInterceptorService');
    }

    angular
        .module('app')
        .config(['cfpLoadingBarProvider', function (cfpLoadingBarProvider)
        {
            cfpLoadingBarProvider.spinnerTemplate = '<div id="loading-bar-spinner-custom"></div>';
        }])

    angular
        .module('app')
        .run(appRunFirst);

    appRunFirst.$inject = ['$window', '$rootScope', '$templateCache'];

    function appRunFirst($window, $rootScope, $templateCache, eventService)
    {
        $rootScope.is_mobile = ($window.innerWidth < 480)

        $rootScope.logger = function ()
        {
            var oldConsoleLog = null;
            var pub = {};

            pub.enableLogger = function enableLogger() 
            {
                if (oldConsoleLog == null)
                    return;

                window['console']['log'] = oldConsoleLog;
            };

            pub.disableLogger = function disableLogger()
            {
                oldConsoleLog = console.log;
                window['console']['log'] = function () { };
            };

            return pub;
        }();
    }

    angular
        .module('app')
        .run(appRunSecond);

    appRunSecond.$inject = ['$rootScope', '$state', '$stateParams', '$location', 'cfpLoadingBar', 'stateService', 'storageService', 'authService'];

    function appRunSecond($rootScope, $state, $stateParams, $location, cfpLoadingBar, stateService, storageService, authService)
    {
        $rootScope.$state = $state;
        $rootScope.$stateParams = $stateParams;

        $rootScope.$on('$stateChangeStart', function (event, toState, toParams, fromState, fromParams)
        {
            //console.log(fromState.name, ' -> ', toState.name);

            var authData = storageService.authData.get();

            if (authData && authData.isAuthenticated)
            {
                if (toState.name.includes('auth.'))
                {
                    event.preventDefault();
                    stateService.go('app.dashboard');
                }
            }
            else
            {
                //if (!toState.name.includes('auth.') && !toState.name.includes('error.'))
                //{
                //    authService.setRedirectObject(toState, toParams, $location.search());

                //    event.preventDefault();
                //    $rootScope.redirectToLogin();
                //}
            }
        });

        $rootScope.$on('$stateChangeSuccess', function (event, toState, toParams, fromState, fromParams)
        {
            
        });

        $rootScope.$on('ocLazyLoad.fileLoading', function (e, file)
        {
            //console.log('event file loading', file);
            //console.log(new Date().getTime());
            cfpLoadingBar.lazyLoadingStart();
        });

        $rootScope.$on('ocLazyLoad.fileLoaded', function (e, file)
        {
            //console.log('event file loaded', file);
            //console.log(new Date().getTime());
            cfpLoadingBar.lazyLoadingComplete();
        });

        $rootScope.redirectToLogin = function ()
        {
            if ($rootScope.is_mobile === false)
            {
                stateService.go('auth.home.login.default');
            }
            else
            {
                stateService.go('auth.home.login.social');
            }
        }
    }
})();