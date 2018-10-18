(function () {
    var commonService = angular.module("common.services");
    commonService.factory("DirectoryRepository", directoryRepository);
    directoryRepository.$inject = ["$resource"];

    function directoryRepository($resource) {
        return $resource(apiBaseUrl + "api/", {}, {
            fetchAll: {
                method: 'GET',
                params: {},
                isArray: false,
                url: secureApiBaseUrl + "directorys"
            },
            fetch: {
                method: 'GET',
                params: {
                    id: '@id'
                },
                isArray: false,
                url: secureApiBaseUrl + "directory/:id"
            },
            save: {
                method: 'POST',
                params: {},
                isArray: false,
                url: secureApiBaseUrl + "directory"
            },
            update: {
                method: 'PUT',
                params: {
                    id: '@id'
                },
                isArray: false,
                url: secureApiBaseUrl + "directory"
            },
            remove: {
                method: 'DELETE',
                params: {
                    id: '@id'
                },
                isArray: false,
                url: secureApiBaseUrl + "directory/:id"
            },
            removeAll: {
                method: 'POST',
                params: {},
                isArray: false,
                url: secureApiBaseUrl + "directory/remove"
            }
        });
    }
}());
