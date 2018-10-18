(function () {
    var applicationApp = angular.module("applicationApp");
    applicationApp.controller("UserListController", userListController);
    userListController.$inject = ["UserRepository", "CommonUtils", "$scope", "$timeout"];
    function userListController(UserRepository, CommonUtils, $scope, $timeout) {

        var vm = this;
        vm.init = init;
        vm.init();
        showDetails = showDetails;
        vm.selectRecord = selectRecord;
        vm.userList = [];
        vm.selectedRecord = {};
        vm.selectedRecords = [];
        vm.selectAll = selectAll;
        function init() {
            CommonUtils.logging("Error", "Got Error", "Init()", "UserListController.js");
            vm.loading = true;
            vm.userList = undefined;
            UserRepository.fetchAll(function (resp) {
                if (!resp.status) {
                    showTost("Error:", resp.message, "danger");
                    vm.loading = false;
                    return;
                }
                vm.userList = resp.data;
                vm.loading = false;
            }, function (error) {
                showTost("Error:", "Somethings went wrong.", "danger");
            });
            vm.userStatusChange = userStatusChange;
        }

        //fetch all users 
        function fetchAllUsers() {
            
        }
        function showDetails(record) {
            vm.selectedRecord = angular.copy(record);
        }

        $scope.$on('ngRepeatBroadcast1', function () {
            $timeout(function () {
                $('#sampleTable').DataTable({
                    "destroy": true
                });
            });
            $('[data-toggle="tooltip"]').tooltip();
        });
        //single record select
        function selectRecord(record) {
            if (!angular.isDefined(record)) {
                return;
            }
            if (record.isSelected) {
                vm.selectedRecord.id = record.id;
                vm.selectedRecords.push({
                    "id": record.id
                });
                if (vm.selectedRecords.length == vm.userList.length) {
                    vm.allSelected = true;
                }
                return;
            }
            vm.allSelected = false;
            vm.selectedRecords.splice(vm.selectedRecords.indexOf(record.id), 1);
        }

        //select all records
        function selectAll(val) {
            if (!val) {
                vm.selectedRecords = [];
            }

            angular.forEach(vm.userList, function (record, indx) {
                record.isSelected = val;
                if (val) {
                    vm.selectedRecords.push({
                        id: record.id
                    });
                }
            });

        };
        //user status update
        function userStatusChange(obj) {
            var user = angular.copy(obj);
            if (!obj.isActive) {
                user.isActive = true;
            } else {
                user.isActive = false;

            }
            UserRepository.updateUser(user, function (resp) {
                if (!resp.status) {
                    showTost("Error:", resp.message, "danger");
                    return;
                }
                if (!user.isActive) {
                    showTost("Success:", "User deactivated", "success");
                } else {
                    showTost("Success:", "User activated", "success");
                }
                obj.isActive = user.isActive;
            }, function (error) {
                showTost("Error:", "Somethings went wrong.", "danger");
            });
        }
    }
}());
