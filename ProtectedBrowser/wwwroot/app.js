var apiBaseUrl = '/';
var secureApiBaseUrl = apiBaseUrl + "api/";
var publicApiBaseUrl = apiBaseUrl;


(function () {
    var applicationApp = angular.module("applicationApp", ["ui.router", "common.services", "angularUtils.directives.dirPagination", 'LocalStorageModule', 'ui.bootstrap', 'angularFileUpload', 'pascalprecht.translate', 'pdf']);
    applicationApp.config(applicationAppConfig);
    applicationApp.run(applicationAppRun);
    
    applicationAppConfig.$inject = ["$stateProvider", "$httpProvider", "$urlRouterProvider", "$locationProvider", "paginationTemplateProvider", "$translateProvider"];
    applicationAppRun.$inject = ["$state", "$rootScope", "AuthServerProvider", "AccountRepository"];

    function applicationAppConfig($stateProvider, $httpProvider, $urlRouterProvider, $locationProvider, paginationTemplateProvider, $translateProvider) {
        
    	$translateProvider.useStaticFilesLoader({
            prefix: 'wwwroot/localization/',
            suffix: '.json'
        });

        $translateProvider.preferredLanguage('en-US');
        paginationTemplateProvider.setPath('js/dirPagination.tpl.html');

        $stateProvider.state("base", {
            url: "",
            templateUrl: "/wwwroot/angular/layouts/base.html?v=" + window.app_version
        });

        $stateProvider.state('/custom', {
            url: '/custom',
            parent: 'base',
			templateUrl: '/wwwroot/angular/custom/custom.html?v=' + window.app_version,
			controller: "CustomController",
			controllerAs: "vm"
		});
		
		$stateProvider.state("recoverPassword", {
			url: "/account/recover/:ucode",
			parent: 'base',
			templateUrl: "/wwwroot/angular/account/recoverPassword.html?v=" + window.app_version,
			controller: "RecoverPasswordController",
			controllerAs: "vm"
		});

		$stateProvider.state("signIn", {
			url: "/signIn",
			parent: 'base',
			templateUrl: "/wwwroot/angular/signIn/signIn.html",
			controller: 'SignInController',
			controllerAs: 'vm',
			resolve: {}
		});

		$stateProvider.state('dashboard', {
			url: '/dashboard',
			templateUrl: '/wwwroot/angular/layouts/dashboard.html?v=' + window.app_version,
			controller: 'HeaderController',
			controllerAs: 'vm',
			resolve: {
                authServerProvider: "AuthServerProvider",
                authorize: function (authServerProvider, $q) {
                    return authServerProvider.isAuthorizedRoleUser(['ROLE_ADMIN'], $q);
                }
            }
		});
		
		$stateProvider.state("ContactList", {
			url: "/contacts",
			parent: 'dashboard',
			templateUrl: "/wwwroot/angular/pages/Contact/ContactUsList.html?v=" + window.app_version,
			controller: "ContactUsListController",
			controllerAs: "vm",
			resolve: {
				authServerProvider: "AuthServerProvider",
				authorize: function (authServerProvider, $q) {
					return authServerProvider.isAuthorizedRoleUser(['ROLE_ADMIN'], $q);
				}
			}
		});
			
        $stateProvider.state("BlogCategoryList", {
			url: "/blog/categories",
			parent: 'dashboard',
			templateUrl: "/wwwroot/angular/pages/Blog/BlogCategoryList.html?v=" + window.app_version,
			controller: "BlogCategoryListcontroller",
			controllerAs: "vm",
			resolve: {
				authServerProvider: "AuthServerProvider",
				authorize: function (authServerProvider, $q) {
					return authServerProvider.isAuthorizedRoleUser(['ROLE_ADMIN'], $q);
				}
			}
		});

		$stateProvider.state("BlogList", {
			url: "/blogs",
			parent: 'dashboard',
			templateUrl: "/wwwroot/angular/pages/Blog/BlogList.html?v=" + window.app_version,
			controller: "BlogListController",
			controllerAs: "vm",
			resolve: {
				authServerProvider: "AuthServerProvider",
				authorize: function (authServerProvider, $q) {
					return authServerProvider.isAuthorizedRoleUser(['ROLE_ADMIN'], $q);
				}
			}
		});
		$stateProvider.state("BlogEdit", {
			url: "/blog/edit/:id",
			parent: 'dashboard',
			templateUrl: "/wwwroot/angular/pages/Blog/BlogEdit.html?v=" + window.app_version,
			controller: "BlogEditController",
			controllerAs: "vm",
			resolve: {
				authServerProvider: "AuthServerProvider",
				authorize: function (authServerProvider, $q) {
					return authServerProvider.isAuthorizedRoleUser(['ROLE_ADMIN'], $q);
				}
			}
		});


		$stateProvider.state("changePassword", {
			url: "/changePassword",
			parent: 'dashboard',
			templateUrl: "/wwwroot/angular/account/changePassword.html?v=" + window.app_version,
			controller: "ChangePasswordController",
			controllerAs: "vm"
		});


		$stateProvider.state("accountSettings", {
			url: "/accountSettings",
			parent: 'dashboard',
			templateUrl: "/wwwroot/angular/account/accountSettings.html?v=" + window.app_version,
			controller: "AccountSettingsController",
			controllerAs: "vm"
		});

		$stateProvider.state("404", {
			url: "/404",
			parent: 'base',
			templateUrl: "/wwwroot/angular/error/404.html?v=" + window.app_version,
			resolve: {}
		});

		$stateProvider.state("403", {
			url: "/403",
			parent: 'base',
			templateUrl: "/wwwroot/angular/error/403.html?v=" + window.app_version,
			resolve: {}
		});

		$stateProvider.state("DirectoryList", {
            url: "/DirectoryList",
            parent: 'dashboard',
            templateUrl: "wwwroot/angular/pages/Directory/DirectoryList.html",
            controller: "DirectoryListController",
            controllerAs: "vm",
            resolve: {
                authServerProvider: "AuthServerProvider",
                authorize: function (authServerProvider, $q) {
                    return authServerProvider.isAuthorizedRoleUser(['ROLE_ADMIN'], $q);
                }
            }
        });

        $stateProvider.state("DirectoryEdit", {
            url: "/Directory/edit/:id",
            parent: 'dashboard',
            templateUrl: "wwwroot/angular/pages/Directory/DirectoryEdit.html",
            controller: "DirectoryEditController",
            controllerAs: "vm",
            resolve: {
                authServerProvider: "AuthServerProvider",
                authorize: function (authServerProvider, $q) {
                    return authServerProvider.isAuthorizedRoleUser(['ROLE_ADMIN'], $q);
                }
            }
        });

        $stateProvider.state("DirectoryDetail", {
            url: "/Directory/detail/:id",
            parent: 'dashboard',
            templateUrl: "wwwroot/angular/pages/Directory/DirectoryDetail.html",
            controller: "DirectoryDetailController",
            controllerAs: "vm",
            resolve: {
                authServerProvider: "AuthServerProvider",
                authorize: function (authServerProvider, $q) {
                    return authServerProvider.isAuthorizedRoleUser(['ROLE_ADMIN'], $q);
                }
            }
        });
        if (window.history && window.history.pushState) {
            $locationProvider.html5Mode(true);
        }

        $urlRouterProvider.otherwise("custom");
        $httpProvider.interceptors.push('authInterceptor');
        $httpProvider.interceptors.push('authExpiredInterceptor');
    }

    function applicationAppRun($state, $rootScope, AuthServerProvider, AccountRepository) {
        $rootScope.$on('$stateChangeStart', function (event, toState) {
            $rootScope._viewPage = toState.url.split("/")[1];
            AuthServerProvider.authenticate();
        });

        $rootScope.signOff = signOff;

        function signOff() {
            AuthServerProvider.signOff();
        }

        // Call when the 401 response is returned by the client
        $rootScope.$on('event:auth-authRequired', function () {
            $rootScope.authenticated = true;
        });

        // Call when the user logs out
        $rootScope.$on('event:auth-authConfirmed', function () {
            $rootScope.user = AuthServerProvider.getUser();
            $rootScope.authenticated = true;
        });
    }

    

    applicationApp.directive('onFinishRender', function ($timeout) {
        return {
            restrict: 'A',
            link: function (scope, element, attr) {
                if (scope.$last === true) {
                    $timeout(function () {
                        scope.$emit(attr.broadcasteventname ? attr.broadcasteventname : 'ngRepeatFinished');
                    });
                }
            }
        }
    });
}());
