(function ()
{
    'use strict';

    angular
        .module('app.controllers.account')
        .controller("addUserController", addUserController);

    addUserController.$inject = ['model', '$scope', 'accountService', 'notificationService', 'NOTIFICATION_SETTINGS'];

    function addUserController(model, $scope, accountService, notificationService, NOTIFICATION_SETTINGS)
    {
        $scope.model = model;
        $scope.model.Gender = 1;
        $scope.model.AgeGroup = 1;
        $scope.model.ProficiencyLevel = 1;
        $scope.model.CFType = 1;

        $scope.addUser = function () {
            var request = {
                Email: $scope.model.Email,
                Password: $scope.model.Password,
                IsAdmin: $scope.model.IsAdmin,
                FirstName: $scope.model.FirstName,
                LastName: $scope.model.LastName,
                Gender: $scope.model.Gender,
                AgeGroup: $scope.model.AgeGroup,
                ProficiencyLevel: $scope.model.ProficiencyLevel,
                CFType: $scope.model.CFType
            };

            accountService.addUser(request).then(function (data)
            {
                $scope.model = {};
                $scope.model.Gender = 1;
                $scope.model.AgeGroup = 1;
                $scope.model.ProficiencyLevel = 1;
                $scope.model.CFType = 1;
                $scope.userInfo.$setPristine(true);
                notificationService.show('User was added successfully!', NOTIFICATION_SETTINGS.TYPE.SUCCESS, NOTIFICATION_SETTINGS.POSITION.BOTTOM_RIGHT, 6000);
            }, function (error) {
                notificationService.show("An error has been occured while updating data." , NOTIFICATION_SETTINGS.TYPE.DANGER, NOTIFICATION_SETTINGS.POSITION.BOTTOM_RIGHT, 6000);
            });
        }
    };
})();