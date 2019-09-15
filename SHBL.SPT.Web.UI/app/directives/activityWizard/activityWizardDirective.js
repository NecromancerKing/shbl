(function () {
    'use strict';

    angular
        .module('app.directives.activity')
        .directive("activityWizard", activityWizardDirective);

    activityWizardDirective.$inject = ['WizardHandler', 'ngSettings', 'URL', 'storageService', '$timeout', 'activityService', 'stateService', 'notificationService', 'NOTIFICATION_SETTINGS', 'generalService'];

    function activityWizardDirective(WizardHandler, ngSettings, URL, storageService, $timeout, activityService, stateService, notificationService, NOTIFICATION_SETTINGS, generalService) {
        var baseWordAudio = ngSettings.dynamicAssetsUri + 'Words/';
        var baseCfAudio = ngSettings.dynamicAssetsUri + 'Feedback/';
        var audioObj = new Audio();

        return {
            restrict: 'EA',
            replace: true,
            scope: true,
            templateUrl: URL.ACTIVITY_WIZARD.TPL + 'activityWizardDirective.html',
            link: link
        };

        function link(scope, element, attributes) {
            initWizard(scope);
            initScope(scope);
        }

        function initScope(dScope) {
            dScope.wizardIntro = URL.DIRECTIVES + 'activityWizard/wizardIntro.html';
            dScope.wizardActivity = URL.DIRECTIVES + 'activityWizard/wizardActivity.html';
            dScope.wizardSummary = URL.DIRECTIVES + 'activityWizard/wizardSummary.html';

            dScope.model = {};
            dScope.model.cf = {}
            dScope.model.activityInfo = storageService.activityInfo.get();
            dScope.disablePlay = false;

            if (dScope.model.activityInfo.QuestionId == null) {
                dScope.model.IntroState = 'Start';
            }
            else {
                dScope.model.IntroState = 'Resume';
            }

            dScope.handleKey = function ($event) {
                switch ($event.keyCode) {
                    case 32:
                        if (dScope.disablePlay === false)
                            dScope.playWord();
                        break;
                    case 37:
                        if (dScope.model.word.Words[0])
                            dScope.checkWord(dScope.model.word.Words[0]);
                        break;
                    case 39:
                        if (dScope.model.word.Words[1])
                            dScope.checkWord(dScope.model.word.Words[1]);
                        break;
                }
            }

            dScope.startActivity = function () {
                var _request =
                    {
                        ActivityId: dScope.model.activityInfo.ActivityId,
                        Session: dScope.model.activityInfo.Session
                    };

                if (dScope.model.activityInfo.QuestionId == null) {
                    activityService.populateActivity(_request).then(function (data) {
                        getNextWord();
                    }, function (error) {
                        notificationService.show("An error has been occured while starting the test.", NOTIFICATION_SETTINGS.TYPE.DANGER, NOTIFICATION_SETTINGS.POSITION.BOTTOM_RIGHT, 6000);
                    });
                }
                else {
                    getNextWord();
                }

                $timeout(function () {
                    dScope.goToStep(1);
                }, 1000);
            }

            var getNextWord = function () {
                var request =
                    {
                        ActivityId: dScope.model.activityInfo.ActivityId,
                        Session: dScope.model.activityInfo.Session
                    };

                activityService.getNextWord(request).then(function (data) {
                    if (data) {
                        $timeout(function () {
                            dScope.model.word = data;
                            dScope.model.word.audioQuestion = baseWordAudio + data.FileName;

                            dScope.disablePlay = false;
                            $(".activitybox").focus();
                        });
                    }
                    else {
                        $timeout(function () {
                            dScope.model.word = {};
                            generalService.GetClientInfo().then(function (data) {
                                generalService.activityCompletedEvent.publish(data);
                            }, function (error) {
                                notificationService.show("An error has been occured while retrieving data.", NOTIFICATION_SETTINGS.TYPE.DANGER, NOTIFICATION_SETTINGS.POSITION.BOTTOM_RIGHT, 6000);
                            });

                            dScope.goToStep(2);
                        }, 500);
                    }
                }, function (error) {
                    notificationService.show("An error has been occured while fetching the word.", NOTIFICATION_SETTINGS.TYPE.DANGER, NOTIFICATION_SETTINGS.POSITION.BOTTOM_RIGHT, 6000);
                });
            }

            function playFile(url) {
                return new Promise(function (resolve, reject) {   // return a promise
                    var audio = audioObj;                     // create audio wo/ src
                    audio.preload = "auto";                      // intend to play through
                    audio.autoplay = true;                       // autoplay when loaded
                    audio.onerror = reject;                      // on error, reject
                    audio.onended = resolve;                     // when done, resolve

                    audio.src = url; // just for example
                });
            }

            var presentFeedback = function () {
                if (dScope.model.activityInfo.CFTypeName == "Target") {
                    playFile(dScope.model.cf.audioCfOne).then(function () {
                        playFile(dScope.model.cf.audioFileNameOne);
                    });
                }
                else if (dScope.model.activityInfo.CFTypeName == "NonTarget") {
                    playFile(dScope.model.cf.audioCfOne).then(function () {
                        playFile(dScope.model.cf.audioFileNameTwo);
                    });
                }
                else {
                    playFile(dScope.model.cf.audioCfOne).then(function () {
                        playFile(dScope.model.cf.audioFileNameTwo).then(function () {
                            playFile(dScope.model.cf.audioCfTwo).then(function () {
                                playFile(dScope.model.cf.audioFileNameOne);
                            });
                        });
                    });
                }
            }

            dScope.playWord = function () {
                playFile(dScope.model.word.audioQuestion);
                if (dScope.model.activityInfo.IsTest) {
                    $timeout(function () {
                        dScope.disablePlay = true;
                    });
                }
            }

            dScope.checkWord = function (selWord) {
                activityService.updateQuestion({ questionId: dScope.model.word.QuestionId, ChosenWord: selWord }).then(function (data) {
                    if (dScope.model.activityInfo.IsTest) {
                        getNextWord();
                    }
                    else {
                        if (data.Result === true) {
                            getNextWord();
                        }
                        else {
                            dScope.model.cf.audioFileNameOne = baseWordAudio + data.FileNameOne;
                            dScope.model.cf.audioFileNameTwo = baseWordAudio + data.FileNameTwo;
                            dScope.model.cf.audioCfOne = baseCfAudio + data.CFFileNameOne;
                            dScope.model.cf.audioCfTwo = baseCfAudio + data.CFFileNameTwo;
                            presentFeedback();
                        }
                    }
                }, function (error) {
                    console.log(error);
                    notificationService.show("An error has been occured in updating the test.", NOTIFICATION_SETTINGS.TYPE.DANGER, NOTIFICATION_SETTINGS.POSITION.BOTTOM_RIGHT, 6000);
                });
            }
        }

        function initWizard(dScope) {
            dScope.finished = function () {
                stateService.go('app.dashboard');
            }

            dScope.logStep = function () {
                console.log("Step continued");
            }

            dScope.goBack = function () {
                WizardHandler.wizard().goTo(0);
            }

            dScope.getCurrentStep = function () {
                return WizardHandler.wizard().currentStepNumber();
            }

            dScope.goToStep = function (step) {
                WizardHandler.wizard().goTo(step);
            }

            dScope.$on('wizard:stepChanged', function (event, args) {
                if (args.index === 1) {
                    $timeout(function () {
                        $(".activitybox").focus();
                    }, 750);
                }
                else if (args.index === 2) {
                    activityService.getTestResult().then(function (data) {
                        $timeout(function () {
                            dScope.model.testResult = data;
                        });
                    }, function (error) {
                        notificationService.show("Error in retreiving test result!", NOTIFICATION_SETTINGS.TYPE.DANGER, NOTIFICATION_SETTINGS.POSITION.BOTTOM_RIGHT, 6000);
                    });
                }
            });
        }

    };

})();