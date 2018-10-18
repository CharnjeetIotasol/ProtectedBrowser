(function () {
    var applicationApp = angular.module("applicationApp");
    applicationApp.controller("DirectoryListController", directoryListController);
    directoryListController.$inject = ["$state", "$timeout", "DirectoryRepository", "$filter", "$scope", "CommonUtils", "AuthServerProvider"];

    function directoryListController($state, $timeout, RecordRepository, $filter, $scope, CommonUtils, AuthRepository) {

        var vm = this;
        vm.remove = remove;

        function init() {
            vm.loading = true;
            vm.recordList = [];
            RecordRepository.fetchAll(function (response) {
                    vm.recordList = response.data;
                    vm.loading = false;
                },
                function (error) {
                    vm.errorResponse = error.data;
                    vm.isError = true;
                    vm.loading = false;
                    return;
                });
        }
		init();
		
        $scope.$on('ngRepeatBroadcast1', function () {
            $timeout(function(){
	            $('#sampleTable').DataTable({
	                "destroy": true
	            });
            });
            $('[data-toggle="tooltip"]').tooltip();
        });

        function remove(id) {
            customDeleteConfirmation(removeRecordCallback,id);
        }

        function removeRecordCallback(id) {
            RecordRepository.remove({id:id}, function (response) {
                sweetAlert.close();
                if (!response.status) {
                    showTost("Error:", response.message, "danger");
                    return;
                }
                showTost("Success:", "Record Deleted Successfully", "success");
                init();
            }, function (error) {
                sweetAlert.close();
                showTost("Error:", "Somethings went wrong.", "danger");
            });
        }
    }
}());
