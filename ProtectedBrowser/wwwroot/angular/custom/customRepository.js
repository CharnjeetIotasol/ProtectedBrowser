(function () {

    var commonService = angular.module("common.services");
    commonService.factory("CustomRepository", customRepository);
    customRepository.$inject = ["$resource"];

    function customRepository($resource) {
        return $resource("", {}, {
            getRootPath: {
                method: 'GET',
                params: {},
                isArray: false,
                url: secureApiBaseUrl + "getrootpath"
            },
            getFolderJson: {
                method: 'GET',
                params: {},
                isArray: false,
                url: secureApiBaseUrl + "folderjson"
            },
            getFile: {
                method: 'GET',
                params: {},
                isArray: false,
                url: secureApiBaseUrl + "filereader"
            }
        });
    }
}());
