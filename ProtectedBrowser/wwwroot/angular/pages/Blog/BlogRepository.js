(function () {
    var commonService = angular.module("common.services");
    commonService.factory("BlogRepository", blogRepository);
    blogRepository.$inject = ["$resource"];

    function blogRepository($resource) {
        return $resource(apiBaseUrl + "api/", {}, {
            fetchAll: {
                method: 'GET',
                params: {},
                isArray: false,
                url: secureApiBaseUrl + "Blog/categories"
            },
            addBlogCategory: {
                method: 'POST',
                params: {},
                isArray: false,
                url: secureApiBaseUrl + "Admin/Blog"
            },
            updateBlogCategory: {
                method: 'PUT',
                params: {},
                isArray: false,
                url: secureApiBaseUrl + "admin/Blog"
            },
            deleteBlogCategory: {
                method: 'DELETE',
                params: {
                    id: '@id'
                },
                isArray: false,
                url: secureApiBaseUrl + "Admin/Blog/:id/Category"
            },
            getBlogCategoryById: {
                method: 'GET',
                params: {
                    id: '@id'
                },
                isArray: false,
                url: secureApiBaseUrl + "blogs/:id/category"
            },
            getAllBlogs: {
                method: 'GET',
                params: {},
                isArray: false,
                url: secureApiBaseUrl + "admin/blogs"
            },
            addBlogs: {
                method: 'POST',
                
                isArray: false,
                url: secureApiBaseUrl + "admin/blog"
            },
            updateBlogs: {
                method: 'PUT',

                isArray: false,
                url: secureApiBaseUrl + "admin/blog"
            },
            getBlogById: {
                method: 'GET',
                params: {
                    id: '@id'
                },
                isArray: false,
                url: secureApiBaseUrl + "blog/:id"
            },
            deleteBlog: {
                method: 'DELETE',
                params: {
                    id: '@id'
                },
                isArray: false,
                url: secureApiBaseUrl + "admin/blog/:id"
            },
            uploadImage: {
                method: 'POST',
                params: {},
                isArray: false,
                url: secureApiBaseUrl + "Admin/uploadFile"
            }
        });
    }
}());
