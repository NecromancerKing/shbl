(function ()
{
    'use strict';

    var _root = APPLICATION_VERSION + '/';

    angular
        .module('app')
        .constant('URL',
        {
            TPL: _root + 'tpl/',
            HOME:
            {
                TPL: _root + 'tpl/home/',
                CTRL: 'app/controllers/home/'
            },
            WEB_AUTH:
            {
                TPL: _root + 'tpl/webAuth/',
                CTRL: 'app/controllers/webAuth/'
            },
            ACCOUNT:
            {
                TPL: _root + 'tpl/account/',
                CTRL: 'app/controllers/account/'
            },
            ACTIVITY:
            {
                TPL: _root + 'tpl/activity/',
                CTRL: 'app/controller/activity/',

            },
            ACTIVITY_WIZARD:
            {
                TPL: _root + 'app/directives/activityWizard/'
            },
            ERROR:
            {
                TPL: _root + 'tpl/error/',
                CTRL: 'app/controllers/error/'
            },
            SERVICES:
            {
                API: 'app/services/api/',
                MISC: 'app/services/misc/',
            },
            PLUGINES: 'assets/plugins/',
            DIRECTIVES: _root + 'app/directives/',
            CONFIGS: 'app/configs/',
            CONSTANTS: 'app/constants/',
            COMMON:
            {
                CONFIGS: 'app/common/configs/',
                DIRECTIVES: 'app/common/directives/',
                SERVICES: 'app/common/services/',
            }
        });
})();