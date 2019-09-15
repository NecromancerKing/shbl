(function () {
    'use strict';

    angular
        .module("app.services.misc")
        .factory("authService", authService);

    authService.$inject = ['$http', '$window', '$rootScope', 'ngSettings', 'stateService', 'storageService'];

    function authService($http, $window, $rootScope, ngSettings, stateService, storageService) {
        var serviceBase = ngSettings.apiServiceBaseUri;

        var authServiceFactory = {};
        var _redirectObject = {};

        //BEGIN Methods//

        var _externalLogin = function (provider) {
            var redirectUrl = String.Format('{0}//{1}/auth/complete', location.protocol, location.host);

            var externalProviderUrl = String.Format('{0}Auth/ExternalLogin?provider={1}&redirect_url={2}', ngSettings.apiServiceBaseUri
                , provider
                , redirectUrl);

            //var oauthWindow = window.open(externalProviderUrl, "Authenticate Account", "location=0,status=0,width=600,height=750");
            $window.location.href = externalProviderUrl;
        }

        var _obtainLocalAccessToken = function (provider, accessToken) {
            var obtainLocalAccessTokenModel =
                {
                    Provider: provider,
                    AccessToken: accessToken
                };

            return $http.post(serviceBase + "/ObtainLocalAccessToken", obtainLocalAccessTokenModel).then(function (response) {
                _setAuthData(response.data);
                _redirectToDashboard();
            });
        }

        var _login = function (loginModel) {
            return $http({
                method: 'POST',
                url: serviceBase + "Token",
                headers: { 'Content-type': 'application/x-www-form-urlencoded' },
                data: 'grant_type=password&UserName=' + loginModel.userName + '&Password=' + loginModel.password
            }).success(function (response) {
                _setAuthData(response);

                if (_redirectObject && _redirectObject.state) {
                    stateService.go(_redirectObject.state, _redirectObject.search);
                    _redirectObject = null;
                }
                else {
                    stateService.go('app.dashboard');
                }

                return response;
            }).error(function (error) {
                if (error.error_description === 'Please change your password on first login') {
                    stateService.go('auth.home.login.firstTimeLogin', { 'loginModel': loginModel });
                }
                return error;
            });

        }

        var _register = function (registerModel) {
            return $http.post(serviceBase + "Auth/Register", registerModel).success(function (response) {
                _setAuthData(response);

                if (_redirectObject && _redirectObject.state) {
                    stateService.go(_redirectObject.state, _redirectObject.search);
                    _redirectObject = null;
                }
                else {
                    stateService.go('app.dashboard');
                }

                return response;
            }).error(function (error) {
                return error;
            });
        }

        var _setAuthData = function (tokenResponse) {
            if (!tokenResponse.access_token) {
                return false;
            }

            var authData =
                {
                    isAuthenticated: true,
                    accessToken: tokenResponse.access_token,
                    refreshToken: tokenResponse.refresh_token,
                };

            storageService.authData.set(authData);
            return true;
        }

        var _logout = function () {
            storageService.authData.clear();
            $rootScope.redirectToLogin();
        }

        var _setRedirectObject = function (state, params, search) {
            var _redirectObject =
                {
                    state: state,
                    params: params,
                    search: search,
                };

            storageService.redirectObject.set(_redirectObject);
        }

        var _redirectToDashboard = function () {
            var _redirectObject = storageService.redirectObject.get();

            if (_redirectObject && _redirectObject.state) {
                if (_redirectObject.params) {
                    stateService.go(_redirectObject.state.name, _redirectObject.params);
                }
                else if (_redirectObject.search) {
                    stateService.go(_redirectObject.state.name, _redirectObject.search);
                }
                else {
                    stateService.go(_redirectObject.state.name);
                }

                storageService.redirectObject.clear();
            }
            else {
                stateService.go('app.dashboard');
            }
        }

        //END Methods//

        //BEGIN Proxy//

        authServiceFactory.externalLogin = _externalLogin;
        authServiceFactory.obtainLocalAccessToken = _obtainLocalAccessToken;
        authServiceFactory.login = _login;
        authServiceFactory.register = _register;
        authServiceFactory.setAuthData = _setAuthData;
        authServiceFactory.logout = _logout;
        authServiceFactory.setRedirectObject = _setRedirectObject;
        authServiceFactory.redirectToDashboard = _redirectToDashboard;

        //END Proxy//

        return authServiceFactory;
    }
})();