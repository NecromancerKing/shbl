(function ()
{
    'use strict';

    angular
        .module('app.common.services')
        .factory('stateService', stateService);

    stateService.$inject = ['$state'];

    function stateService($state)
    {
        var stateServiceFactory = {};

        var _go = function (state, search)
        {
            $state.is(state) ? $state.reload() : $state.go(state, search);
        }

        stateServiceFactory.go = _go;

        return stateServiceFactory;
    };
})();