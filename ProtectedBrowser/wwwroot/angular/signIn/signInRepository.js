(function () {
    var commonService = angular.module("common.services");
    commonService.factory("SignInRepository", signInRepository);
    signInRepository.$inject = ["$resource"];

    function signInRepository($resource) {
        return $resource("", {}, {
            signIn: {
                method: 'POST',
                params: {},
                isArray: false,
                url: secureApiBaseUrl + "account/login"
            },
            resetPassword: {
                method: 'POST',
                params: {},
                isArray: false,
                url: secureApiBaseUrl + "account/forgotPassword"
            }
        });
    }
}());
