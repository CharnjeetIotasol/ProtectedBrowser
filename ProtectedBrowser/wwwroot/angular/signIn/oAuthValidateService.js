(function () {

    var commonService = angular.module("common.services");

    commonService.factory("AuthServerProvider", authServerProvider);
    authServerProvider.$inject = ["$http", "localStorageService", "$rootScope", "$state", "$timeout", "$location", "CONSTANTS"];

    function authServerProvider($http, localStorageService, $rootScope, $state, $timeout, $location, CONSTANTS) {
        //var userRoles = this.getUser().roles;
        return {
            authenticate: function () {
                var token = this.getToken();
                var isAuthenticated = token && token.expires_at && token.expires_at > new Date().getTime();
                if (isAuthenticated) {
                    $rootScope.$broadcast('event:auth-authConfirmed');
                } else {
                    $rootScope.$broadcast('event:auth-authRequired');
                }
            },
            signOff: function () {
                localStorageService.clearAll();
                window.location.href = "/signIn";
            },
            getToken: function () {
                return localStorageService.get('token');
            },
            getUser: function () {
                return localStorageService.get('user');
            },
            hasValidToken: function () {
                var token = this.getToken();
                return token && token.accessToken && token.expires_at && token.expires_at > new Date().getTime();
            },
            isAnonymous: function () {
                if (this.hasValidToken()) {
                    $state.go('/');
                }
            },
            isAuthorizedRoleUser: function (roles, $q) {
                var deferred = $q.defer();
                if (!this.hasValidToken()) {
                    localStorageService.clearAll();
                    $timeout(deferred.reject);
                    window.location.href = "/signIn";
                    return deferred.promise;
                }

                var userRoles = this.getUser().roles;
                var result = userRoles.filter(function (item) {
                    return roles.indexOf(item) > -1
                });
                if (result.length <= 0) {
                    $timeout(deferred.reject);
                    $state.go('403');
                    return deferred.promise;
                }
                $timeout(deferred.resolve);
                return deferred.promise;
            },
            isAccessible: isAccessible,
            isDisabled: isDisabled
        };

        function isAccessible(VIEW) {
            //var allowedRoles = CONSTANTS.VIEW_USER_MAPPING[VIEW].SHOW_TO_ROLE;
            //return allowedRoles.some(function (ele) {
            //    return userRoles.includes(ele);
            //}); 
            return true;
        };

        function isDisabled(VIEW) {
            //console.log(VIEW);
            //var allowedRoles = CONSTANTS.VIEW_USER_MAPPING[VIEW].ENABLED_FOR_ROLE;
            //return !allowedRoles.some(function (ele) {
            //    return userRoles.includes(ele);
            //});
            return true;
        };
    }
}());
