(function ()
{
    'use strict';

    angular.module('app.common.directives')
        .directive('onKeyup', function ()
        {
            return {
                link: function (scope, element, attrs, modelCtrl)
                {
                    var allowedKeys = scope.$eval(attrs.keys);
                    elm.bind('keydown', function (evt)
                    {
                        angular.forEach(allowedKeys, function (key)
                        {
                            if (key == evt.which)
                            {
                                evt.preventDefault(); // Doesn't work at all
                                window.stop(); // Works in all browsers but IE    
                                document.execCommand("Stop"); // Works in IE
                                return false; // Don't even know why it's here. Does nothing.                     
                            }
                        });
                    });
                }
            };
        })
})();