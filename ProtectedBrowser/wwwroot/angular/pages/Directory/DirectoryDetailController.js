(function () {
    var applicationApp = angular.module("applicationApp");
    applicationApp.controller("DirectoryDetailController", directoryDetailController);
    directoryDetailController.$inject = ["$state", "$timeout", "DirectoryRepository", "$filter", "$stateParams", "AuthServerProvider"];

    function directoryDetailController($state, $timeout, AccessRepository, $filter, $stateParams, AuthRepository) {

        var vm = this;
        vm.remove = remove;
        vm.cancel = cancel;
        vm.record = {};
        init();

        function init() {
            vm.record = {};
            AccessRepository.fetch({
                "id": $stateParams.id
            }, function (response) {
                vm.record = response.data;
            },
            function (error) {
                $state.go("404");
            });
        }

        function cancel() {
            $state.go("DirectoryList");
        }

        function remove(recordId) {
            customDeleteConfirmation(removeRecordCallback, recordId);
        }

        function removeRecordCallback(recordId) {
            AccessRepository.remove({
                id: recordId
            }, function (application) {
                sweetAlert.close();
                $timeout(vm.cancel());
            }, function (error) {
                sweetAlert.close();
                setTimeout(function () {
                    customMessageAlert("<h4 style='word-break: break-all;'>" + error.data.message + "</h4>", "warning");
                }, 200);
            });
        }
    }
}());
