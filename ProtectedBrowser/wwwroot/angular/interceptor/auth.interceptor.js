(function () {
    var commonService = angular.module("common.services");

    commonService.factory("authInterceptor", authInterceptor);
    authInterceptor.$inject = ["$rootScope", "localStorageService"];

    function authInterceptor($rootScope, localStorageService) {
        return {
            // Add Authorization token to headers
            request: function (config) {
                var token = localStorageService.get('token');
                if (token && token.accessToken && token.expires_at && token.expires_at > new Date().getTime()) {
                    config.headers.Authorization = token.tokenType + " " + token.accessToken;
                }
                return config;
            }
        };
    }

    commonService.factory("authExpiredInterceptor", authExpiredInterceptor);
    authExpiredInterceptor.$inject = ["$rootScope", "$q", "localStorageService"];

    function authExpiredInterceptor($rootScope, $q, localStorageService) {
        return {
            // Add Authorization token to headers
            responseError: function (response) {
                // token has expired
            	if (response.status === 401 && (response.statusText == 'invalid_token' || response.statusText == 'Unauthorized')) {
                    localStorageService.clearAll();
                     window.location.href = "/signIn";
                }
                return $q.reject(response);
            }
        };
    }

    function getMinutesBetweenDates(endDate, startDate) {
        var diff = endDate - startDate;
        return (diff / 60000);
    }
}());
