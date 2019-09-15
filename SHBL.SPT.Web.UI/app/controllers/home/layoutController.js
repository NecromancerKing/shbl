/* ============================================================
 * File: main.js
 * Main Controller to set global scope variables. 
 * ============================================================ */

(function ()
{
    'use strict';

    angular
        .module('app.controllers.home')
        .controller("layoutController", layoutController);

    layoutController.$inject = ['$scope', 'URL'];

    function layoutController($scope, URL)
    {
        $scope.sidebarTemplate = URL.HOME.TPL + 'sidebar.html';
        $scope.headerTemplate = URL.HOME.TPL + 'header.html';
        $scope.footerTemplate = URL.HOME.TPL + 'footer.html';
    };
})();