(function ()
{
    'use strict';

    angular
        .module('app.common.services')
        .factory('urlHelper', urlHelper);

    urlHelper.$inject = [];

    function urlHelper()
    {
        var urlHelperFactory = {};

        var _getFragment = function ()
        {
            if (window.location.hash.indexOf("#") === 0)
            {
                return _parseQueryString(window.location.hash.substr(1));
            }
            else
            {
                return {};
            }
        };

        var _parseQueryString = function (queryString)
        {
            var data = {}, pairs, pair, separatorIndex, escapedKey, escapedValue, key, value;

            if (queryString === null)
            {
                return data;
            }

            pairs = queryString.split("&");

            for (var i = 0; i < pairs.length; i++)
            {
                pair = pairs[i];
                separatorIndex = pair.indexOf("=");

                if (separatorIndex === -1)
                {
                    escapedKey = pair;
                    escapedValue = null;
                }
                else
                {
                    escapedKey = pair.substr(0, separatorIndex);
                    escapedValue = pair.substr(separatorIndex + 1);
                }

                key = decodeURIComponent(escapedKey);
                value = decodeURIComponent(escapedValue);

                data[key] = value;
            }

            return data;
        };

        urlHelperFactory.getFragment = _getFragment;
        urlHelperFactory.parseQueryString = _parseQueryString;

        return urlHelperFactory;
    };
})();