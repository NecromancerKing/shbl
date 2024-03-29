/* ============================================================
 * Directive: skycons
 * AngularJS directive for skycons plugin
 * http://darkskyapp.github.io/skycons/
 * ============================================================ */
(function ()
{
    'use strict';

    angular.module('app.common.directives')
        .directive('skycons', function ()
        {
            return {
                restrict: 'A',
                link: function (scope, element, attrs)
                {
                    var skycons = new Skycons();
                    skycons.add($(element).get(0), attrs.class);
                    skycons.play();
                }
            }
        });
})();