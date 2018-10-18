(function () {
	var applicationApp = angular.module("applicationApp");
	applicationApp.controller("BlogListController", blogListcontroller);
	blogListcontroller.$inject = ["$state", "$timeout", "BlogRepository", "$filter", "$scope", "CommonUtils"];

	function blogListcontroller($state, $timeout, RecordRepository, $filter, $scope, CommonUtils) {

		var vm = this;
		vm.remove = remove;

		function init() {
			vm.loading = true;
			vm.recordList = undefined;
			var pagination_obj = {};
			pagination_obj.Next = 10;
			pagination_obj.Offset = 1;
			RecordRepository.getAllBlogs(pagination_obj, function (response) {
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
			$('[data-toggle="tooltip"]').tooltip();
		});

		function remove(id) {
			customDeleteConfirmation(removeRecordCallback, id);
		}

		function removeRecordCallback(id) {
			RecordRepository.deleteBlog({
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
	}
}());
