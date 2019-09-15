(function ()
{
    'use strict';

    angular.module('app.common.directives')
        .directive('submitButton', function ()
        {
            return {
                require: '^form',
                restrict: 'A',
                link: function (scope, element, attrs, modelCtrl)
                {
                    element.on('click', clickHandler);

                    function clickHandler()
                    {
                        formCtrl.$setDirty(true);
                        formCtrl.$setSubmitted(true);
                        angular.element(element[0].form).triggerHandler('submit');
                    }
                }
            };
        })
})();