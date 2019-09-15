(function ()
{
    'use strict';

    angular
        .module('app.common.services')
        .constant('NOTIFICATION_SETTINGS',
        {
            TYPE:
            {
                INFO: 'info',
                WARNING: 'warning',
                SUCCESS: 'success',
                DANGER: 'danger',
                DEFAULT: 'default'
            },
            STYLE:
            {
                SIMPLE: 'simple',
                BAR: 'bar',
                FLIP: 'flip',
                CIRCLE: 'circle'
            },
            POSITION:
            {
                TOP: 'top',
                BOTTOM: 'bottom',
                TOP_LEFT: 'top-left',
                TOP_RIGHT: 'top-right',
                BOTTOM_LEFT: 'bottom-left',
                BOTTOM_RIGHT: 'bottom-right'
            },
        });

    angular
        .module('app.common')
        .factory('notificationService', notificationService);

    notificationService.$inject = ['NOTIFICATION_SETTINGS'];

    function notificationService(NOTIFICATION_SETTINGS)
    {
        var notificationServiceFactory = {};

        var _show = function (message, type, position, timeout)
        {
            if (!type)
            {
                type = NOTIFICATION_SETTINGS.TYPE.INFO;
            }

            if (!position)
            {
                position = NOTIFICATION_SETTINGS.POSITION.TOP_RIGHT;
            }

            if (!timeout)
            {
                timeout = 0;
            }

            $('body').pgNotification({
                style: NOTIFICATION_SETTINGS.STYLE.SIMPLE,
                message: message,
                position: position,
                timeout: timeout,
                type: type
            }).show();
        };

        var _showBar = function (message, type, position, timeout)
        {
            if (!type)
            {
                type = NOTIFICATION_SETTINGS.TYPE.INFO;
            }

            if (!position)
            {
                position = NOTIFICATION_SETTINGS.POSITION.TOP;
            }

            if (!timeout)
            {
                timeout = 0;
            }

            $('body').pgNotification({
                style: NOTIFICATION_SETTINGS.STYLE.BAR,
                message: message,
                position: position,
                timeout: timeout,
                type: type
            }).show();
        };

        var _showFlip = function (message, type, position, timeout)
        {
            if (!type)
            {
                type = NOTIFICATION_SETTINGS.TYPE.INFO;
            }

            if (!position)
            {
                position = NOTIFICATION_SETTINGS.POSITION.TOP_RIGHT;
            }

            if (!timeout)
            {
                timeout = 0;
            }

            $('body').pgNotification({
                style: NOTIFICATION_SETTINGS.STYLE.FLIP,
                message: message,
                position: position,
                timeout: timeout,
                type: type
            }).show();
        };

        var _showCircle = function (message, title, thumbnail, type, position, timeout, thumbnail2x)
        {
            if (!type)
            {
                type = NOTIFICATION_SETTINGS.TYPE.INFO;
            }

            if (!position)
            {
                position = NOTIFICATION_SETTINGS.POSITION.TOP_RIGHT;
            }

            if (!timeout)
            {
                timeout = 0;
            }

            if (!thumbnail2x)
            {
                thumbnail2x = thumbnail;
            }

            var tumbnailHtml = String.Format('<img width="40" height="40" style="display: inline-block;" src="{0}" data-src="{1}" ui-jq="unveil" data-src-retina="{0}" alt="">', thumbnail2x, thumbnail);

            $('body').pgNotification({
                style: NOTIFICATION_SETTINGS.STYLE.CIRCLE,
                title: title,
                message: message,
                position: position,
                timeout: timeout,
                type: type,
                thumbnail: tumbnailHtml
            }).show();
        };

        notificationServiceFactory.show = _show;
        notificationServiceFactory.showBar = _showBar;
        notificationServiceFactory.showFlip = _showFlip;
        notificationServiceFactory.showCircle = _showCircle;

        return notificationServiceFactory;
    };
})();