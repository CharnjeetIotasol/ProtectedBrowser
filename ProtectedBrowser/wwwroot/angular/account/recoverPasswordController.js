(function () {
    "use strict";

    var applicationApp = angular.module("applicationApp");
    applicationApp.controller("RecoverPasswordController", recoverPwdController);

    recoverPwdController.$inject = ["$scope", "$state", "$filter", "$stateParams", "AccountRepository", "$location"];

    function recoverPwdController($scope, $state, $filter, $stateParams, AccountRepository, $location) {
        var vm = this;
        vm.recoverpassword = {};
        vm.resetPassword = resetPassword;
        vm.onClickValidation = false;
        init();

        function init() {
            vm.recoverpassword.code = encodeURIComponent($location.search().code);
            vm.recoverpassword.uniqueCode = $stateParams.ucode;            
            if (vm.recoverpassword.code === "" || vm.recoverpassword.code === null) {
                $state.go("404");
            }
        }

        function resetPassword(bol) {
            vm.onClickValidation = !bol;
            if (!bol) {
                return false;
            }
            if (vm.confirmPassword !== vm.password) {
                showTost("Error:", "password doesn't matches", "danger");
                return;
            }
            vm.recoverpassword.password = vm.password;
            AccountRepository.resetPassword(vm.recoverpassword, function (data) {
                if (!data.status) {
                    showTost("Error:", data.message, "danger");
                    return;
                }
                vm.recoverEmail = "";
                showTost("Success:", data.message, "success");
                $state.go("/");
            });
        }
    }
}());
