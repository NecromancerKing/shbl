(function ()
{
    'use strict';

    angular
        .module('app.common.services')
        .factory('dateTimeHelper', dateTimeHelper);

    dateTimeHelper.$inject = [];

    function dateTimeHelper()
    {
        var dateTimeHelperFactory = {};

        var monthNames = [
            "January", "February", "March",
            "April", "May", "June",
            "July", "August", "September",
            "October", "November", "December"
        ];

        var _getDate = function (dateTime)
        {
            if (dateTime == null)
            {
                return null;
            }

            var date = new Date(dateTime);
            return _formatDate(date, 'yyyy-MM-dd');
        };

        var _formatDate = function date2str(date, format)
        {
            var z =
                {
                    M: date.getMonth() + 1,
                    d: date.getDate(),
                    h: date.getHours(),
                    m: date.getMinutes(),
                    s: date.getSeconds()
                };

            format = format.replace('MMM', 'XXX');

            format = format.replace(/(M+|d+|h+|m+|s+)/g, function (v)
            {
                return ((v.length > 1 ? "0" : "") + eval('z.' + v.slice(-1))).slice(-2)
            });

            format = format.replace(/(y+)/g, function (v)
            {
                return date.getFullYear().toString().slice(-v.length)
            });
            
            return format.replace('XXX', _getMonthName(date.getMonth() + 1));
        };

        var _getMonthName = function (monthIndex)
        {
            return monthNames[monthIndex - 1];
        };

        var _getFullMonthName = function (dateTime)
        {
            var date = new Date(dateTime);
            return String.Format('{0} {1}', monthNames[date.getMonth()], date.getFullYear());
        };

        dateTimeHelperFactory.getDate = _getDate;
        dateTimeHelperFactory.formatDate = _formatDate;
        dateTimeHelperFactory.getMonthName = _getMonthName;
        dateTimeHelperFactory.getFullMonthName = _getFullMonthName;

        return dateTimeHelperFactory;
    };
})();