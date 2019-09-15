(function ()
{
    'use strict';

    angular
        .module('app.common.services')
        .factory('errorHandler', errorHandler);

    errorHandler.$inject = [];

    function errorHandler()
    {
        var errorHandlerFactory = {};

        var _parseErrors = function (response)
        {
            var errors = [];

            for (var key in response.ModelState)
            {
                for (var i = 0; i < response.ModelState[key].length; i++)
                {
                    errors.push(response.ModelState[key][i]);
                }
            }

            return errors;
        };

        errorHandlerFactory.parseErrors = _parseErrors;

        return errorHandlerFactory;
    };
})();