(function () {
	var applicationApp = angular.module("applicationApp");
	applicationApp.controller("BlogCategoryListcontroller", blogCategoryListcontroller);
	blogCategoryListcontroller.$inject = ["$state", "$timeout", "BlogRepository", "$filter", "$scope", "CommonUtils"];

	function blogCategoryListcontroller($state, $timeout, AccessRepository, $filter, $scope, CommonUtils) {

		var vm = this;
		vm.remove = remove;
		vm.openCategoryPopup = openCategoryPopup;
		vm.editCategory = editCategory;
		vm.save = save;

		function init() {
			vm.loading = true;
			vm.recordList = undefined;
			vm.onClickValidation = false;
			vm.isNewRecord = false;
			vm.category = {};
			AccessRepository.fetchAll(function (response) {
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
			$timeout(function () {
				$('#sampleTable').DataTable({
					"destroy": true
				});
			});
		});

		function remove(id) {
			customDeleteConfirmation(removeRecordCallback, id);
		}

		function removeRecordCallback(id) {
			AccessRepository.deleteBlogCategory({
				id: id
			}, function (response) {
				sweetAlert.close();
				if (!response.status) {
					showTost("Error:", response.message, "danger");
					return;
				}
				showTost("Success:", "Record Deleted Successfully", "success");
				vm.init();
			}, function (error) {
				sweetAlert.close();
				showTost("Error:", "Somethings went wrong.", "danger");
			});
		}

		function openCategoryPopup() {
			vm.isNewRecord = true;
			$("#categoryModel").modal('show');
		}

		function editCategory(obj) {
			vm.isNewRecord = false;
			vm.category = angular.copy(obj);
			$("#categoryModel").modal('show');
		}

		function save(bol) {
			vm.onClickValidation = !bol;

			if (!bol) {
				return;
			}
			var method = vm.isNewRecord ? "addBlogCategory" : "updateBlogCategory";
			AccessRepository[method](vm.category, function (data) {
				if (!data.status) {
					showTost("Error:", data.message, "danger");
					return;
				}
				showTost("Success:", data.message, "success");
				$("#categoryModel").modal('hide');
				init();
			}, function (error) {
				vm.disabledSaveButton = false;
				showTost("Error:", error.message, "danger");
			});
		}
	}
}());
