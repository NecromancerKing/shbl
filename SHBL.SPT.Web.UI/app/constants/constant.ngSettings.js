(function ()
{
    'use strict';

    angular
        .module('app')
        .constant('ngSettings',
        {
            //apiServiceBaseUri: 'http://oratio-api.dotframework.net/',
            apiServiceBaseUri: 'http://localhost:9000/',
            //dynamicAssetsUri: 'http://oratio.dotframework.net/DynamicAsset/'
            dynamicAssetsUri: 'http://localhost:9000/DynamicAsset/'
        });
})();