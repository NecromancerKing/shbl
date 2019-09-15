/* ============================================================
 * File: config.js
 * Configure routing
 * ============================================================ */

(function () {
    'use strict';

    angular
        .module('app')
        .config(routeConfig);

    routeConfig.$inject = ['$stateProvider', '$urlRouterProvider', '$ocLazyLoadProvider', '$locationProvider', 'URL', 'ngSettings'];

    function routeConfig($stateProvider, $urlRouterProvider, $ocLazyLoadProvider, $locationProvider, URL, ngSettings) {
        $urlRouterProvider.when('/', ['$state', '$rootScope', 'stateService', 'storageService', function ($state, $rootScope, stateService, storageService) {
            var authData = storageService.authData.get();

            if (authData && authData.isAuthenticated) {
                stateService.go('app.dashboard');
            }
            else {
                $rootScope.redirectToLogin();
            }
        }]);

        $stateProvider
            .state('auth',
            {
                url: '/auth',
                template: '<div class="full-height" ui-view></div>',
                abstract: true,
                resolve:
                {
                    auth_module: ['$ocLazyLoad', function ($ocLazyLoad) {
                        return $ocLazyLoad.load(['webAuth-module'],
                            {
                                insertBefore: '#lazyload_placeholder'
                            });
                    }]
                }
            })

            .state('auth.home',
            {
                url: '',
                templateUrl: URL.WEB_AUTH.TPL + 'authHome.html',
                abstract: true,
                controller: 'authHomeController',
                resolve:
                {
                    model: ['auth_module', '$ocLazyLoad', 'webAuthService', function (auth_module, $ocLazyLoad, webAuthService) {
                        return $ocLazyLoad.load([],
                            {
                                insertBefore: '#lazyload_placeholder'
                            }).then(function () {
                                return webAuthService.getAuthHome();
                            });
                    }]
                }
            })

            .state('auth.home.login',
            {
                url: '/login',
                template: '<div class="full-height" ui-view></div>',
                abstract: true
            })

            .state('auth.home.login.default',
            {
                url: '',
                templateUrl: URL.WEB_AUTH.TPL + 'login.html',
                controller: 'loginController',
                resolve:
                {
                    model: ['auth_module', '$ocLazyLoad', 'webAuthService', function (auth_module, $ocLazyLoad, webAuthService) {
                        return $ocLazyLoad.load([],
                            {
                                insertBefore: '#lazyload_placeholder'
                            })
                            .then(function () {
                                return webAuthService.getLogin();
                            });
                    }]
                }
            })

            .state('auth.home.login.social',
            {
                url: '/social',
                templateUrl: URL.WEB_AUTH.TPL + 'loginSocial.html',
                controller: 'loginSocialController',
                resolve:
                {
                    model: ['auth_module', '$ocLazyLoad', 'webAuthService', function (auth_module, $ocLazyLoad, webAuthService) {
                        return $ocLazyLoad.load([],
                            {
                                insertBefore: '#lazyload_placeholder'
                            })
                            .then(function () {
                                return webAuthService.getLoginSocial();
                            });
                    }]
                }
            })

            .state('auth.home.register',
            {
                url: '/register',
                templateUrl: URL.WEB_AUTH.TPL + 'register.html',
                controller: 'registerController',
                resolve:
                {
                    model: ['auth_module', '$ocLazyLoad', 'webAuthService', function (auth_module, $ocLazyLoad, webAuthService) {
                        return $ocLazyLoad.load([],
                            {
                                insertBefore: '#lazyload_placeholder'
                            })
                            .then(function () {
                                return webAuthService.getRegister();
                            });
                    }]
                }
            })

            .state('auth.home.forgetPassword',
            {
                url: '/forgetPassword',
                templateUrl: URL.WEB_AUTH.TPL + 'forgetPassword.html',
                controller: 'forgetPasswordController',
                resolve:
                {
                    model: ['auth_module', '$ocLazyLoad', 'webAuthService', function (auth_module, $ocLazyLoad, webAuthService) {
                        return $ocLazyLoad.load([],
                            {
                                insertBefore: '#lazyload_placeholder'
                            })
                            .then(function () {
                                return webAuthService.getForgetPassword();
                            });
                    }]
                }
            })

            .state('auth.complete',
            {
                url: '/complete',
                template: '<div class="full-height truncate"></div>',
                controller: 'authCompleteController'
            })

            .state('app',
            {
                abstract: true,
                url: '',
                templateUrl: URL.HOME.TPL + 'layout.html',
                controller: 'layoutController',
                resolve:
                {
                    home_module: ['$ocLazyLoad', '$injector', function ($ocLazyLoad, $injector) {
                        return $ocLazyLoad.load(['common.directives-module', 'home-module'],
                            {
                                insertBefore: '#lazyload_placeholder'
                            }).then(function () {
                                var homeService = $injector.get('homeService');
                                var generalService = $injector.get('generalService');
                                var storageService = $injector.get('storageService');

                                homeService.getHeader();
                                generalService.GetClientInfo().then(function (data) {
                                    storageService.activityInfo.set(data);
                                });
                            });
                    }]
                }
            })

            .state('app.dashboard',
            {
                url: '/dashboard',
                templateUrl: URL.HOME.TPL + 'dashboard.html',
                controller: 'dashboardController',
                resolve:
                {
                    model: ['home_module', '$ocLazyLoad', 'homeService', function (home_module, $ocLazyLoad, homeService) {
                        return $ocLazyLoad.load([],
                            {
                                insertBefore: '#lazyload_placeholder'
                            }).then(function () {
                                return homeService.getDashboard();
                            });
                    }]
                }
            })

            .state('app.activity',
            {
                url: '',
                templateUrl: URL.ACTIVITY.TPL + 'activity.html',
                controller: 'activityController',
                abstract: true,
                resolve:
                {
                    activity_module: ['$ocLazyLoad', '$injector', function ($ocLazyLoad, $injector)
                    {
                        return $ocLazyLoad.load(['activity-module'],
                            {
                                insertBefore: '#lazyload_placeholder'
                            }).then(function () {
                                var generalService = $injector.get('generalService');
                                return generalService.GetClientInfo();
                            });
                    }]
                }
            })

            .state('app.activity.pretest',
            {
                url: '',
                templateUrl: URL.ACTIVITY.TPL + 'activityDetail.html',
                resolve:
                {
                    model: ['$ocLazyLoad', '$injector', 'activity_module', function ($ocLazyLoad, $injector, activity_module)
                    {
                        return $ocLazyLoad.load(['wizard'],
                            {
                                insertBefore: '#lazyload_placeholder'
                            });
                    }]
                }
            })

            .state('app.activity.training',
            {
                url: '',
                templateUrl: URL.ACTIVITY.TPL + 'activityDetail.html',
                resolve:
                {
                    model: ['$ocLazyLoad', '$injector', 'activity_module', function ($ocLazyLoad, $injector, activity_module) {
                        return $ocLazyLoad.load(['wizard'],
                            {
                                insertBefore: '#lazyload_placeholder'
                            });
                    }]
                }
            })

            .state('app.activity.posttest',
            {
                url: '',
                templateUrl: URL.ACTIVITY.TPL + 'activityDetail.html',
                resolve:
                {
                    model: ['$ocLazyLoad', '$injector', 'activity_module', function ($ocLazyLoad, $injector, activity_module) {
                        return $ocLazyLoad.load(['wizard'],
                            {
                                insertBefore: '#lazyload_placeholder'
                            });
                    }]
                }
            })

            .state('app.account',
            {
                url: '/account',
                template: '<div class="full-height" ui-view></div>',
                abstract: true,
                resolve:
                {
                    account_module: ['$ocLazyLoad', '$injector', function ($ocLazyLoad, $injector) {
                        return $ocLazyLoad.load(['account-module'],
                            {
                                insertBefore: '#lazyload_placeholder'
                            });
                    }]
                }
            })

            .state('app.account.userProfile',
            {
                url: '/userProfile',
                templateUrl: URL.ACCOUNT.TPL + 'userProfile.html',
                controller: 'userProfileController',
                resolve:
                {
                    model: ['account_module', '$ocLazyLoad', 'accountService', function (account_module, $ocLazyLoad, accountService) {
                        return $ocLazyLoad.load([],
                            {
                                insertBefore: '#lazyload_placeholder'
                            }).then(function () {
                                return accountService.getUserProfile();
                            });
                    }]
                }
            })

            .state('app.account.adduser',
            {
                url: '/adduser',
                templateUrl: URL.ACCOUNT.TPL + 'adduser.html',
                controller: 'addUserController',
                resolve:
                {
                    model: ['account_module', '$ocLazyLoad', 'accountService', function (account_module, $ocLazyLoad, accountService) {
                        return $ocLazyLoad.load([],
                            {
                                insertBefore: '#lazyload_placeholder'
                            }).then(function () {
                                return accountService.getAddUser();
                            });
                    }]
                }
            })

            .state('app.error',
            {
                template: '<div class="full-height" ui-view></div>',
                abstract: true
            })
            .state('app.error.403',
            {
                templateUrl: URL.ERROR.TPL + '403.html',
            })

            .state('error',
            {
                template: '<div class="full-height" ui-view></div>',
                abstract: true
            })
            .state('error.404',
            {
                templateUrl: URL.ERROR.TPL + '404.html',
            })

            .state('error.500',
            {
                templateUrl: URL.ERROR.TPL + '500.html',
            })

        $locationProvider.html5Mode(true);

        $urlRouterProvider.otherwise(function ($injector, $location) {
            $injector.invoke(['$state', function ($state) {
                $state.go('error.404');
            }]);
        });
    }
})();