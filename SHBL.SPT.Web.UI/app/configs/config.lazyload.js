/* ============================================================
 * File: config.lazyload.js
 * Configure modules for ocLazyLoader. These are grouped by 
 * vendor libraries. 
 * ============================================================ */

(function ()
{
    'use strict';

    angular.module('app')
        .config(['$ocLazyLoadProvider', 'URL', function ($ocLazyLoadProvider, URL)
        {
            //var modulesObject = [];
            //var jsonFile = 'app/configs/config.lazyload' + APPLICATION_VERSION + '.json';

            //$.ajax({
            //    dataType: 'json',
            //    url: jsonFile,
            //    async: false,
            //    success: function (data) 
            //    {
            //        modulesObject = data;
            //    }
            //});

            $ocLazyLoadProvider.config({
                debug: false,
                events: true,
                modules: LAZY_LOAD_MODULES
            });
        }]);
})();