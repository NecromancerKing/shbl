(function () {
    'use strict';

    angular
        .module('app.controllers.account')
        .controller("userProfileController", userProfileController);

    userProfileController.$inject = ['model', '$scope', 'accountService', 'stateService', 'generalService', 'notificationService', 'NOTIFICATION_SETTINGS'];

    function userProfileController(model, $scope, accountService, stateService, generalService, notificationService, NOTIFICATION_SETTINGS) {
        $scope.model = model;
        $scope.imgPath = null;

        $scope.updateProfile = function () {
            var request = {
                FirstName: $scope.model.FirstName,
                LastName: $scope.model.LastName
            };

            accountService.updateProfile(request).then(function (data) {
                var eventData = {
                    Username: $scope.model.FirstName + ' ' + $scope.model.LastName,
                    Image: null
                };

                generalService.profileUpdatedEvent.publish(eventData);
                notificationService.show("User Profile updated successfully!", NOTIFICATION_SETTINGS.TYPE.SUCCESS, NOTIFICATION_SETTINGS.POSITION.BOTTOM_RIGHT, 6000);
            }, function (error) {
                notificationService.show("An error has been occured while updating data.", NOTIFICATION_SETTINGS.TYPE.DANGER, NOTIFICATION_SETTINGS.POSITION.BOTTOM_RIGHT, 6000);
            });
        }
    };
})();