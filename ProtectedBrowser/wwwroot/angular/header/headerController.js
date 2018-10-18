(function () {
    "use strict";

    var applicationApp = angular.module("applicationApp");
    applicationApp.controller("HeaderController", headerController);

    headerController.$inject = ["$scope", "CommonUtils", "AuthServerProvider"];

    function headerController($scope, CommonUtils, AuthRepository) {
        var vm = this;
        vm.changeLanguage = changeLanguage;
        vm.getChosenLanguage = getChosenLanguage;
        init();

        function init() {
        }

        function changeLanguage(language) {
            CommonUtils.setChosenLanguage(language);
        }

        function getChosenLanguage() {
            return CommonUtils.getChosenLanguage();
        }
    }
}());
