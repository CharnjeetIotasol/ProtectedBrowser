(function () {
    var commonService = angular.module("common.services");
    commonService.factory("UserRepository", userRepository);
    userRepository.$inject = ["$resource"];

    function userRepository($resource) {
        return $resource(apiBaseUrl + "api", {}, {
            saveUser: {
                method: 'POST',
                params: {},
                isArray: false,
                url: secureApiBaseUrl + "account/register"
            },
            fetchAll: {
                method: 'GET',
                params: {},
                isArray: false,
                url: secureApiBaseUrl + "account/users"
            },
            getUserById: {
                method: 'GET',
                params: {},
                isArray: false,
                url: secureApiBaseUrl + "account/user/:id"
            },
            updateUser: {
                method: 'PUT',
                params: {},
                isArray: false,
                url: secureApiBaseUrl + "account/updateUser"
            },
        });
    }
}());
