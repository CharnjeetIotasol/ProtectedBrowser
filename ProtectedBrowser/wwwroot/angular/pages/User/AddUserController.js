(function () {
    var applicationApp = angular.module("applicationApp");
    applicationApp.controller("AddUserController", addUserController);
    addUserController.$inject = ["$stateParams", "UserRepository","$state"];
    function addUserController($stateParams, UserRepository,$state) {

        var vm = this;
        init();

        function init() {
            vm.user = {};
            vm.save = save;
            vm.onClickValidation = false;
            vm.roleList = [
                {
                    name: "Admin",
                    value: "ROLE_ADMIN"
                },
                {
                    name: "Receptionist",
                    value: "ROLE_RECEPTIONIST"
                }
            ];
            vm.salutation = [
                {
                    name: "Mr",
                    value: "Mr"
                },
                {
                    name: "Mrs",
                    value: "Mrs"
                }
            ];
            vm.recordId = $stateParams.id;
            vm.isNewRecord = true;
            if ($stateParams.id != '0') {
                UserRepository.getUserById({id:$stateParams.id}, function (resp) {
                    if (resp.data) {
                        vm.isNewRecord = false;
                        vm.user = resp.data;
                    }

                }, function (error) {
                    showTost("Error:", "Somethings went wrong.", "danger");
                });
            };
            vm.disableSaveButton = false;
           
            

        };

        //save or update user Detail
        function save(valid) {
            if (!valid) {
                vm.onClickValidation = true;
                return;
            }
            vm.disableSaveButton = true;
            if (vm.isNewRecord) {
                UserRepository.saveUser(vm.user, function (resp) {
                    if (!resp.status) {
                        showTost("Error:", resp.message, "danger");
                        vm.disableSaveButton = false;
                        return;
                    }
                    showTost("Success:", resp.message, "success");
                    $state.go("UserList");
                }, function (error) {
                    vm.disableSaveButton = false;
                    showTost("Error:", "Somethings went wrong.", "danger");
                });
            } else {
                UserRepository.updateUser(vm.user, function (resp) {
                    if (!resp.status) {
                        showTost("Error:", resp.message, "danger");
                        vm.disableSaveButton = false;
                        return;
                    }
                    showTost("Success:", resp.message, "success");
                    $state.go("UserList");
                }, function (error) {
                    vm.disableSaveButton = false;
                    showTost("Error:", "Somethings went wrong.", "danger");
                });
            }

        };
       

    }
}());
