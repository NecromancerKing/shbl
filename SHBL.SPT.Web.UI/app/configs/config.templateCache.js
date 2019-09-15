(function ()
{
    'use strict';

    angular
        .module('app')
        .run(templateCacheConfig);

    templateCacheConfig.$inject = ['$templateCache'];

    function templateCacheConfig($templateCache)
    {
        $templateCache.put("pages/template/tabs/tabset.html",
            "<div>\n" +
            "  <ul class=\"nav-tabs-linetriangle nav nav-{{tabset.type || 'tabs'}}\" ng-class=\"{'nav-stacked': vertical, 'nav-justified': justified}\" ng-transclude></ul>\n" +
            "  <div class=\"tab-content\">\n" +
            "	<div class=\"tab-pane\"\n" +
            "		 ng-repeat=\"tab in tabset.tabs\"\n" +
            "		 ng-class=\"{active: tabset.active === tab.index}\"\n" +
            "		 uib-tab-content-transclude=\"tab\">\n" +
            "	</div>\n" +
            "  </div>\n" +
            "</div>");

        $templateCache.put("pages/template/tabs/ui-router-tabs.html",
            '<div>\n' +
            '	<uib-tabset active="tabs.active" class="tab-container {{class}}" type="{{type}}" vertical="{{vertical}}" justified="{{justified}}" template-url="pages/template/tabs/tabset.html">\n' +
            '		<uib-tab class="tab {{tab.class}}" ng-repeat="tab in tabs" disable="tab.disable" select="go(tab)">\n' +
            '			<uib-tab-heading ng-bind-html="tab.heading"></uib-tab-heading>\n' +
            '		</uib-tab>\n' +
            '	</uib-tabset>\n' +
            '	<div class="tab-content" ui-view>\n' +
            '	</div>\n' +
            '</div>');
    }
})();