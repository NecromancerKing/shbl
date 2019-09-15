(function ()
{
    'use strict';

    angular
        .module('app.controllers.home')
        .controller("searchController", searchController);

    searchController.$inject = ['$scope'];

    function searchController($scope)
    {
        $scope.liveSearch = function ()
        {
            console.log("Live search for: " + $scope.search.query);
        }
    };
})();