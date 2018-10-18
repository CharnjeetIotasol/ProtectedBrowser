(function () {

    var commonService = angular.module("common.services");
    commonService.factory("AccountRepository", accountRepository);
    accountRepository.$inject = ["$resource"];

    function accountRepository($resource) {
        return $resource("", {}, {
            fetch: {
                method: 'GET',
                params: {},
                isArray: false,
                url: secureApiBaseUrl + "account/userDetail"
            },
            resetPassword: {
                method: 'POST',
                params: {},
                isArray: false,
                url: secureApiBaseUrl + "account/resetPassword"
            },
            changePassword: {
                method: 'POST',
                params: {},
                isArray: false,
                url: secureApiBaseUrl + "account/changePassword"
            },
            updateUserDetail: {
                method: 'PUT',
                params: {},
                isArray: false,
                url: secureApiBaseUrl + "account/updateUserDetail"
            },
            
        });
    }
}());
