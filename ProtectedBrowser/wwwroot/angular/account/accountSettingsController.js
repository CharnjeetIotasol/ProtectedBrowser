(function () {
    "use strict";

    var applicationApp = angular.module("applicationApp");

    applicationApp.controller("AccountSettingsController", accountSettingsController);
    accountSettingsController.$inject = ["$scope", "$state", "$timeout", "$rootScope", "AccountRepository", "FileUploader", "localStorageService", "$window"];

    function accountSettingsController($scope, $state, $timeout, $rootScope, AccountRepository, FileUploader, localStorageService, $window) {
        var vm = this;
        vm.updateUserDetail = updateUserDetail;
        vm.userDetail = {};
        vm.onClickValidation = false;
        init();

        function init() {
            getUserDetails();
        }

        function getUserDetails() {
            AccountRepository.fetch(function (response) {
                if (!response.status) {
                    showTost("Error:", data.message, "danger");
                    return;
                }
                vm.userDetail = response.data;
            });
        }

        function updateUserDetail(bol) {
            vm.onClickValidation = !bol;
            if (!bol) {
                return false;
            }
            AccountRepository.updateUserDetail(vm.userDetail, function (response) {
                if (!response.status) {
                    showTost("Error:", response.message, "danger");
                    return;
                }
                showTost("Success:", response.message, "success");
                $(".user-fullName").html(vm.userDetail.firstName + " " + vm.userDetail.lastName);
            });
        }

        vm.uploader = $scope.uploader = new FileUploader({
            url: secureApiBaseUrl + 'file/upload',
            autoUpload: true
        });

        vm.uploader.onSuccessItem = function (fileItem, response, status, headers) {
            if (vm.userDetail.profileId != null || vm.userDetail.profileId != "") {
                vm.userDetail.isProfilePicChanged = true;
            }
            vm.userDetail.profileId = response.id;
            console.info('onSuccessItem', fileItem, response, status, headers);
        };
    }
}());
