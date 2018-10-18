(function () {
    var applicationApp = angular.module("applicationApp");
    applicationApp.controller("DirectoryEditController", directoryEditController);
    directoryEditController.$inject = ["$scope", "$state", "$timeout", "DirectoryRepository", "$filter","FileUploader", "$stateParams", "AuthServerProvider"];

    function directoryEditController($scope, $state, $timeout, AccessRepository, $filter,FileUploader, $stateParams, AuthRepository) {

        var vm = this;
        vm.save = save;
        vm.cancel = cancel;
		vm.remove = remove;
		init();
		
        function init() {
            vm.record = {
                isActive: true
            };
            vm.recordId = $stateParams.id;
            vm.isNewRecord = true;
            if (vm.recordId <= 0) {
                autoSelected();
                return;
            }
            AccessRepository.fetch({
                "id": vm.recordId
            }, function (response) {
                vm.loading = false;
                vm.isNewRecord = false;
                vm.record = response.data;
                postprocessing();
                
            },
            function (error) {
                vm.errorResponse = error.data;
                vm.isError = true;
                vm.loading = false;
            });
        }
		function postprocessing(){
            autoSelected();
		}
		
        function autoSelected(value) {
        	$('.select-2').select2();
            $('.datepicker').datepicker({
                format: "dd/mm/yyyy",
                autoclose: true,
                todayHighlight: true
            });
        }

        function save(bol) {
            vm.onClickValidation = !bol;
            if (!bol) {
                return;
            }
			
            
            var method="save";
            if (!vm.isNewRecord) {
            	method="update"
            } 
            AccessRepository[method](vm.record, function (data) {
                if (!data.status) {
                    showTost("Error:", data.message, "danger");
                    return;
                }
                showTost("Success:", data.message, "success");
                vm.cancel();
            }, function (error) {
                showTost("Error:", error.data.message, "danger");
            });
        }

        function cancel() {
            $state.go("DirectoryList");
        }

        function remove() {
            customDeleteConfirmation(removeRecordCallback, vm.recordId);
        }

        function removeRecordCallback(recordId) {
            AccessRepository.remove({
                id: recordId
            }, function (response) {
                sweetAlert.close();
                if (!response.status) {
                    showTost("Error:", response.message, "danger");
                    return;
                }
                showTost("Success:", "Record Deleted Successfully", "success");
                vm.cancel();
            }, function (error) {
                sweetAlert.close();
                showTost("Error:", "Some Things went wrong.", "danger");
            });
        }
        
		
		vm.loadAssociatedPopup = loadAssociatedPopup;

		function loadAssociatedPopup(name, fieldName) {
			vm.associated = {
				isActive: true
			};
			
			$("#" + name).modal("show");

		}
		vm.onSelectAssociated = onSelectAssociated;

		function onSelectAssociated(value, name, popUpName) {
			vm.record[name] = value;
			setTimeout(function () {
				$('.' + name).val(value).trigger("change");
			});
			vm.associated = undefined;
			$("#" + popUpName).modal("hide");
		}

		vm.onRemoveAssociated = onRemoveAssociated;

		function onRemoveAssociated(id, fieldName) {
			customDeleteConfirmation(removeAssociatedRecordCallback, id, fieldName);
		}

		function removeAssociatedRecordCallback(recordId, fieldName) {
			vm.repository.remove({
				id: recordId
			}, function (response) {
				sweetAlert.close();
				if (!response.status) {
					showTost("Error:", response.message, "danger");
					return;
				}
				showTost("Success:", "Record Deleted Successfully", "success");
				vm.loadAssociatedAll(fieldName);
			}, function (error) {
				sweetAlert.close();
				showTost("Error:", "Some Things went wrong.", "danger");
			});
		}
		vm.loadAssociatedAll = loadAssociatedAll;

		function loadAssociatedAll() {
			vm.repository.fetchAll(function (response) {
			});
		}
		vm.onSaveAssociated = onSaveAssociated;

		function onSaveAssociated(fieldName) {
			vm.repository.save(vm.associated, function (response) {
				if (!response.status) {
					showTost("Error:", response.message, "danger");
					return;
				}
				vm.associated = {
					isActive: true
				};
				vm.showAddForm = false;
				vm.loadAssociatedAll(fieldName);
			});
		} 
	}	
}());

