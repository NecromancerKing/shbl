/* ============================================================
 * File: main.js
 * Main Controller to set global scope variables. 
 * ============================================================ */

(function ()
{
    'use strict';

    angular
        .module('app.controllers')
        .controller("appController", appController);

    appController.$inject = ['$scope', '$rootScope', '$state'];

    function appController($scope, $rootScope, $state)
    {
        // Checks if the given state is the current state
        var _is = function (name)
        {
            return $state.is(name);
        }

        // Checks if the given state/child states are present
        var _includes = function (name)
        {
            return $state.includes(name);
        }

        // Broadcasts a message to pgSearch directive to toggle search overlay
        var _showSearchOverlay = function ()
        {
            $scope.$broadcast('toggleSearchOverlay', {
                show: true
            })
        }

        // App globals
        var _app = {
            name: 'Speech Percecption Training',
            author: 'Sian00r',
            description: 'Speech Perception Training',
            layout: {
                menuPin: true,
                menuBehind: false,
                theme: 'assets/theme/css/pages.css'
            },
            author: 'Sian00r'
        }

        var _bodyClass = {
            'bg-master-lighter': _is('app.extra.timeline'),
            'no-header': _is('app.social') || _is('app.calendar') || _is('app.maps.vector') || _is('app.maps.google'),
            'menu-pin': _app.layout.menuPin,
            'menu-behind': _app.layout.menuBehind,
            'auth-screen': _includes('auth')
        }

        $scope.app = _app;
        $scope.bodyClass = _bodyClass;
        $scope.is = _is;
        $scope.includes = _includes;
        $scope.showSearchOverlay = _showSearchOverlay;
    };
})();