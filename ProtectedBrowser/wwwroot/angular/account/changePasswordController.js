(function () {
    "use strict";

    var applicationApp = angular.module("applicationApp");
    applicationApp.controller("ChangePasswordController", changePwdController);

    changePwdController.$inject = ["$scope", "$state", "$filter", "AccountRepository"];

    function changePwdController($scope, $state, $filter, AccountRepository) {
        var vm = this;
        vm.changePassword = {};
        vm.changePasswordFunc = changePasswordFunc;
        vm.onClickValidation = false;
        
        function changePasswordFunc(bol) {
            vm.onClickValidation = !bol;
            if (!bol) {
                return false;
            }
            if (vm.confirmPassword !== vm.newPassword) {
                showTost("Error:", "password doesn't matches", "danger");
                return;
            }

            AccountRepository.changePassword(vm.changePassword, function (data) {
                if (!data.status) {
                    showTost("Error:", data.message, "danger");
                    return;
                }
                vm.changePassword = {};
                showTost("Success:", data.message, "success");
            });
        }
    }
}());
