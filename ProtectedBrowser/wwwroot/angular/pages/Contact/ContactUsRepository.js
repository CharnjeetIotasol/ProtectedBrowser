(function () {
    var commonService = angular.module("common.services");
    commonService.factory("ContactUsRepository", blogRepository);
    blogRepository.$inject = ["$resource"];

    function blogRepository($resource) {
        return $resource(apiBaseUrl + "", {}, {
            addContact: {
                method: 'POST',
                params: {},
                isArray: false,
                url: secureApiBaseUrl + "contact-us"
            },
            deleteContact: {
                method: 'DELETE',
                params: {
                    id: '@id'
                },
                isArray: false,
                url: secureApiBaseUrl + "admin/contact-us/:id"
            },
            getAllContacts: {
                method: 'GET',
                params: {},
                isArray: false,
                url: secureApiBaseUrl + "admin/contact-us"
            }
        });
    }
}());
