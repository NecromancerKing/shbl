/// <binding BeforeBuild='debug' />

module.exports = function (grunt)
{
    var pkg = grunt.file.readJSON('package.json');
    var timestamp = grunt.template.today("yyyymmdd.HHMMss");
    var version = pkg.version + '.' + timestamp;
    var buildRootDestination = 'Build/SHBL.SPT.Web.UI/<%= pkg.version %>/';
    var backupPath = 'Build/SHBL.SPT.Web.UI/~/' + timestamp + '.tgz'
    var lazyloadModulesSrc = 'app/configs/config.lazyload.modules.js';

    var vendorCssSrc =
        [
            'assets/plugins/bootstrapv3/css/bootstrap.min.css',
            'assets/plugins/jquery-scrollbar/jquery.scrollbar.css',
            'assets/plugins/angular-loading-bar/loading-bar.css'
        ];

    var themeCssSrc =
        [
            'assets/theme/css/pages-icons.css',
            'assets/theme/css/pages.css',
        ];

    var siteCssSrc =
        [
            'assets/css/style.css',
            'assets/css/progress-wizard.min.css'
        ];

    var blindFilesSrc =
        [
            'assets/theme/css/ie9.css',
            'assets/plugins/mapplic/css/mapplic-ie.css',
            'assets/theme/css/windows.chrome.fix.css',
            'app/constants/constant.ngSettings.js'
        ];

    var blindRootFilesSrc =
        [
            'Web.config'
        ];

    var jquerylibSrc =
        [
            'assets/plugins/jquery/jquery-1.11.1.js',
            'assets/plugins/jquery-helper/jquery.helper.js',
            'assets/plugins/modernizr.custom.js'
        ];

    var vendorlibSrc =
        [
            'assets/plugins/jquery-ui/jquery-ui.min.js',
            'assets/plugins/bootstrapv3/js/bootstrap.min.js',
            'assets/plugins/jquery/jquery-easy.js',
            'assets/plugins/jquery-unveil/jquery.unveil.min.js',
            'assets/plugins/jquery-bez/jquery.bez.min.js',
            'assets/plugins/jquery-ios-list/jquery.ioslist.min.js',
            'assets/plugins/jquery-actual/jquery.actual.min.js',
            'assets/plugins/jquery-scrollbar/jquery.scrollbar.min.js',
            'assets/plugins/classie/classie.js',
            'assets/plugins/angular/angular.js',
            'assets/plugins/angular-touch/angular-touch.js',
            'assets/plugins/angular-sanitize/angular-sanitize.js',
            'assets/plugins/angular-local-storage/angular-local-storage.js',
            'assets/plugins/angular-animate/angular-animate.js',
            'assets/plugins/angular-bootstrap/ui-bootstrap-tpls.min.js',
            'assets/plugins/angular-ui-router/angular-ui-router.js',
            'assets/plugins/angular-ui-router-tabs/ui-router-tabs.js',
            'assets/plugins/angular-ui-util/ui-utils.js',
            'assets/plugins/angular-oc-lazyload/ocLazyLoad.js',
            'assets/plugins/angular-loading-bar/loading-bar.js',
            'assets/plugins/angular-audio/angular.audio.js',
            'assets/plugins/angular-wizard/angular-wizard.min.js',
            'assets/plugins/ng-eatclick/ng-eatclick.js'
        ];

    var themelibSrc =
        [
            'assets/theme/js/pages.js',
        ];

    var applibSrc =
        [
            'app/app.js',
            lazyloadModulesSrc,
            'app/constants/constant.url.js',
            'app/configs/config.lazyload.js',
            'app/configs/config.routes.js',
            'app/configs/config.startup.js',
            'app/configs/config.templateCache.js',
            'app/controllers/appController.js',
            'app/common/configs/config.localStorageService.js',
            'app/common/services/eventService.js',
            'app/common/services/stateService.js',
            'app/common/services/notificationService.js',
            'app/common/services/errorHandler.js',
            'app/common/services/urlHelper.js',
            'app/common/services/dateTimeHelper.js',
            "app/common/directives/cs-select.js",
            'app/services/misc/storageService.js',
            'app/services/misc/authService.js',
            'app/services/misc/authInterceptorService.js',
            'app/services/misc/generalService.js'
        ];

    var vendorCssDest = 'assets/css/vendor.<%= version %>.min.css';
    var themeCssDest = 'assets/theme/css/theme.<%= version %>.min.css';
    var siteCssDest = 'assets/css/site.<%= version %>.min.css';
    var jquerylibDest = 'assets/js/vendor.<%= version %>.min.js';
    var vendorlibDest = 'assets/js/j.<%= version %>.min.js';
    var themelibDest = 'assets/theme/js/theme.<%= version %>.min.js';
    var applibDest = 'app/app.<%= version %>.min.js';

    grunt.initConfig({
        pkg: pkg,
        version: version,
        config:
        {
            debug:
            {
                options:
                {
                    variables:
                    {
                        environment: 'debug'
                    }
                }
            },
            release:
            {
                options:
                {
                    variables:
                    {
                        environment: 'release'
                    }
                }
            }
        },
        backup:
        {
            release:
            {
                src: buildRootDestination,
                dest: backupPath
            },
        },
        cssmin:
        {
            options:
            {
                banner: '/*! <%= pkg.name %> <%= pkg.version %> - <%= grunt.template.today("yyyy-mm-dd HH:MM:ss") %> */\n',
                processImport: false
            },
            vendorCss:
            {
                src: vendorCssSrc,
                dest: vendorCssDest
            },
            themeCss:
            {
                src: themeCssSrc,
                dest: themeCssDest
            },
            siteCss:
            {
                src: siteCssSrc,
                dest: siteCssDest
            }
        },
        uglify_parallel:
        {
            options:
            {
                banner: '/*! <%= pkg.name %> <%= pkg.version %> - <%= grunt.template.today("yyyy-mm-dd HH:MM:ss") %> */\n',
                mangle: true,
                compress:
                {
                    sequences: true,
                    dead_code: true,
                    conditionals: true,
                    booleans: true,
                    unused: true,
                    if_return: true,
                    join_vars: true,
                    drop_console: true,
                    drop_debugger: true,
                }
            },
            jquerylib:
            {
                src: jquerylibSrc,
                dest: jquerylibDest
            },
            vendorlib:
            {
                src: vendorlibSrc,
                dest: vendorlibDest
            },
            themelib:
            {
                src: themelibSrc,
                dest: themelibDest
            },
            applib:
            {
                src: applibSrc,
                dest: applibDest
            }
        },
        clean:
        {
            options:
            {
                force: true
            },
            debug:
            {
                src: ['index.html']
            },
            release:
            {
                src: [buildRootDestination]
            },
            afterRelease:
            {
                src:
                [
                    vendorCssDest,
                    themeCssDest,
                    siteCssDest,
                    jquerylibDest,
                    vendorlibDest,
                    themelibDest,
                    applibDest
                ]
            }
        },
        ngindex:
        {
            options:
            {
                vars:
                {
                    pkg: grunt.file.readJSON('package.json'),
                    environment: grunt.config.get("environment"),
                    version: version
                }
            },
            debug:
            {
                options:
                {
                    template: 'index.debug.html',
                    vars:
                    {
                        vendorCssFiles: grunt.file.expand(vendorCssSrc),
                        themeCssFiles: grunt.file.expand(themeCssSrc),
                        siteCssFiles: grunt.file.expand(siteCssSrc),

                        jquerylibFiles: grunt.file.expand(jquerylibSrc),
                        vendorlibFiles: grunt.file.expand(vendorlibSrc),
                        themelibFiles: grunt.file.expand(themelibSrc),
                        applibFiles: grunt.file.expand(applibSrc),
                    },
                    dest: 'index.html'
                }
            },
            release:
            {
                options:
                {
                    template: 'index.release.html',
                    vars:
                    {
                        vendorCssDest: '<%= cssmin.vendorCss.dest %>',
                        themeCssDest: '<%= cssmin.themeCss.dest %>',
                        siteCssDest: '<%= cssmin.siteCss.dest %>',

                        jquerylibDest: '<%= uglify_parallel.jquerylib.dest %>',
                        vendorlibDest: '<%= uglify_parallel.vendorlib.dest %>',
                        themelibDest: '<%= uglify_parallel.themelib.dest %>',
                        applibDest: '<%= uglify_parallel.applib.dest %>',
                    },
                    dest: buildRootDestination + 'index.html'
                }
            }
        },
        copy:
        {
            release:
            {
                files:
                [
                    //css
                    { src: [vendorCssDest], dest: buildRootDestination, filter: 'isFile' },
                    { src: [themeCssDest], dest: buildRootDestination, filter: 'isFile' },
                    { src: [siteCssDest], dest: buildRootDestination, filter: 'isFile' },

                    //js
                    { src: [jquerylibDest], dest: buildRootDestination, filter: 'isFile' },
                    { src: [vendorlibDest], dest: buildRootDestination, filter: 'isFile' },
                    { src: [themelibDest], dest: buildRootDestination, filter: 'isFile' },
                    { src: [applibDest], dest: buildRootDestination, filter: 'isFile' },

                    //img
                    { src: ['assets/img/**'], dest: buildRootDestination },
                    { src: ['assets/theme/img/**'], dest: buildRootDestination },
                    { src: ['assets/theme/ico/**'], dest: buildRootDestination },
                    { src: ['app/directives/**/*.jpg'], dest: buildRootDestination },
                    { src: ['app/directives/**/*.png'], dest: buildRootDestination },
                    { src: ['app/directives/**/*.gif'], dest: buildRootDestination },

                    //fonts
                    { src: ['assets/theme/fonts/**'], dest: buildRootDestination },
                    { src: ['assets/fonts/**'], dest: buildRootDestination },

                    //others
                    { src: blindFilesSrc, dest: buildRootDestination },
                    { src: blindRootFilesSrc, dest: buildRootDestination },
                ]
            }
        },
        htmlmin:
        {
            options:
            {
                removeComments: true,
                collapseWhitespace: true,
                caseSensitive: true,
            },
            index:
            {
                src: [buildRootDestination + 'index.html'],
                dest: buildRootDestination + 'index.html'
            },
            views:
            {
                expand: true,
                src: ['tpl/**/*.html'],
                dest: buildRootDestination + version + '/'
            },
            directives:
            {
                expand: true,
                src: ['app/directives/**/*.html'],
                dest: buildRootDestination + version + '/'
            }
        },
        lazyload:
        {
            debug:
            {
                src: 'app/configs/config.lazyload.json',
                dest: lazyloadModulesSrc,
                tmpl: 'grunt/config.lazyload.modules.js.tmpl',
            },
            release:
            {
                src: 'app/configs/config.lazyload.json',
                dest: lazyloadModulesSrc,
                tmpl: 'grunt/config.lazyload.modules.js.tmpl',
                modulesDest: 'app/modules/',
                buildRootDest: buildRootDestination,
                version: version,
            }
        }
    });

    grunt.loadNpmTasks('grunt-config');
    grunt.loadNpmTasks('grunt-backup');
    grunt.loadNpmTasks('grunt-contrib-cssmin');
    grunt.loadNpmTasks('grunt-uglify-parallel');
    grunt.loadNpmTasks('grunt-contrib-clean');
    grunt.loadNpmTasks('grunt-ngindex');
    grunt.loadNpmTasks('grunt-contrib-copy');
    grunt.loadNpmTasks('grunt-contrib-htmlmin');

    grunt.task.registerMultiTask('lazyload', 'Create Lazy Load Modules For Release', function ()
    {
        var target = this.target;
        var src = this.data.src;
        var dest = this.data.dest;
        var tmpl = this.data.tmpl;
        var modulesDest = this.data.modulesDest;
        var buildRootDest = this.data.buildRootDest;
        var version = this.data.version;

        if (grunt.file.exists(dest))
        {
            grunt.file.delete(dest, { force: true });
        }

        var tmplText = grunt.file.read(tmpl);

        if (target === 'debug')
        {
            var modulesText = grunt.file.read(src);

            var text = tmplText.replace('%MODULES%', modulesText).replace('%VERSION%', '');
            grunt.file.write(dest, text);
        }
        else if (target === 'release')
        {
            var modules = grunt.file.readJSON(src);
            var modules_new = [];

            var uglifyConfig = grunt.config.get('uglify_parallel');
            var cssminConfig = grunt.config.get('cssmin');

            for (var i = 0; i < modules.length; i++)
            {
                var module = modules[i];
                var module_new = {};

                module_new.name = module.name;
                module_new.files = [];

                var jsFiles = module.files.filter(function (file)
                {
                    return file.endsWith('.js');
                });

                var cssFiles = module.files.filter(function (file)
                {
                    return file.endsWith('.css');
                });

                if (jsFiles.length != 0)
                {
                    var jsFile = modulesDest + module.name + '.' + version + '.module.js';
                    module_new.files.push(jsFile);

                    uglifyConfig[module.name.replace('-', '_') + '_lib'] = { src: jsFiles, dest: buildRootDest + jsFile };
                }

                if (cssFiles.length != 0)
                {
                    var first = cssFiles[0];
                    var firstDir = first.substring(0, first.lastIndexOf('/') + 1);

                    var cssFile = firstDir + module.name + '.' + version + '.module.css';
                    module_new.files.push(cssFile);

                    cssminConfig[module.name.replace('-', '_') + '_css'] = { src: cssFiles, dest: buildRootDest + cssFile };
                }

                modules_new.push(module_new);
            }

            grunt.config.set('uglify_parallel', uglifyConfig);
            grunt.config.set('cssmin', cssminConfig);

            var modulesText = JSON.stringify(modules_new);

            var text = tmplText.replace('%MODULES%', modulesText).replace('%VERSION%', version);
            grunt.file.write(dest, text);
        }
    });

    //Debug Task
    grunt.registerTask('debug', ['config:debug', 'clean:debug', 'ngindex:debug', 'lazyload:debug']);

    //Release Task
    grunt.registerTask('release', ['config:release', 'backup:release', 'clean:release', 'lazyload:release', 'cssmin', 'uglify_parallel', 'ngindex:release', 'copy:release', 'htmlmin', 'lazyload:debug', 'clean:afterRelease']);
};