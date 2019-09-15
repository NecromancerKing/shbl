(function ()
{
    'use strict';

    angular.module('app.common.directives')
        .directive('compareTo', function ()
        {
            return {
                require: "ngModel",
                restrict: 'A',
                scope:
                {
                    otherModelValue: "=compareTo"
                },
                link: function (scope, element, attributes, ngModel)
                {
                    ngModel.$validators.compareTo = function (modelValue)
                    {
                        return modelValue == scope.otherModelValue;
                    };

                    scope.$watch("otherModelValue", function ()
                    {
                        ngModel.$validate();
                    });
                }
            };
        })
})();