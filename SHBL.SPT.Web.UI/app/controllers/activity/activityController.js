(function ()
{
    'use strict';

    angular
        .module('app.controllers.activity')
        .controller("activityController", activityController);

    activityController.$inject = ['activity_module', '$scope', 'storageService'];

    function activityController(activity_module, $scope, storageService)
    {
        $scope.model = activity_module;
        storageService.activityInfo.set(activity_module);
    };
})();