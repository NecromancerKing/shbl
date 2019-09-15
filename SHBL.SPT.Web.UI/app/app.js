/* ============================================================
 * File: app.js
 * Configure global module dependencies. Page specific modules
 * will be loaded on demand using ocLazyLoad
 * ============================================================ */

(function ()
{
    'use strict';

    angular.module('app.common', []);
    angular.module('app.common.configs', []);
    angular.module('app.common.directives', []);
    angular.module('app.common.services', []);
    angular.module('app.services.api', []);
    angular.module('app.services.misc', []);
    angular.module('app.directives', []);
    angular.module('app.directives.activity', []);
    angular.module('app.controllers', []);
    angular.module('app.controllers.account', []);
    angular.module('app.controllers.home', []);
    angular.module('app.controllers.activity', []);


    angular.module('app', [
        'ui.bootstrap',
        'ui.router',
        'ui.router.tabs',
        'LocalStorageModule',
        'ui.utils',
        'oc.lazyLoad',
        'angular-loading-bar',
        'ngAnimate',
        'ngTouch',
        'ngAudio',
        'mgo-angular-wizard',
        'ngSanitize',
        'ng-eatclickif',
        'app.common',
        'app.common.configs',
        'app.common.directives',
        'app.common.services',
        'app.services.api',
        'app.services.misc',
        'app.directives',
        'app.directives.activity',
        'app.controllers',
        'app.controllers.account',
        'app.controllers.home',
        'app.controllers.activity'
    ]);
})();