(function () {
	var applicationApp = angular.module("applicationApp");
	applicationApp.controller("BlogEditController", blogController);
	blogController.$inject = ["$scope", "$state", "$timeout", "BlogRepository", "$filter", "$stateParams", "FileUploader", "$q"];

	function blogController($scope, $state, $timeout, AccessRepository, $filter, $stateParams, FileUploader, $q) {

		var vm = this;
		vm.save = save;
		vm.cancel = cancel;
		vm.remove = remove;

		vm.tinymceOptions = {
			menubar: false,
			plugins: 'link image code',
			min_height: 250,
			resize: false
		};


		function init() {
			vm.record = {
				isActive: true
			};
			vm.record.file = {};
			var promies = [];
			vm.isNewRecord = $stateParams.id == 0;
			promies.push(AccessRepository.fetchAll().$promise);
			if (!vm.isNewRecord) {
				promies.push(AccessRepository.getBlogById({
					"id": vm.recordId
				}).$promise);
			}
			$q.all(promies).then(function (response) {
				vm.loading = false;
				vm.categoryList = response[0].data;
				if (!vm.isNewRecord) {
					vm.record = response[1].data;
				}
			}).catch(function (error) {
				vm.loading = false;
			});
		}
		init();

		vm.uploader = $scope.uploader = new FileUploader({
			url: secureApiBaseUrl + 'file/upload',
			autoUpload: true
		});

		vm.uploader.onSuccessItem = function (fileItem, response, status, headers) {
			response.targetType = "Catalog";
			vm.record.file = response;
		};

		function save(bol) {
			vm.onClickValidation = !bol;
			if (!bol) {
				return;
			}
			if (vm.record.file == null) {
				showTost("Error:", "Image is Required", "danger");
				return;
			}
			if (vm.uploader.progress > 0 && vm.uploader.progress < 100) {
				showTost("Error:", "image upload in processing", "danger");
				return;
			}


			var method = "addBlogs";
			if (!vm.isNewRecord) {
				method = "updateBlogs"
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
			$state.go("BlogList");
		}

		function remove(id) {
			customDeleteConfirmation(removeRecordCallback, id);
		}

		function removeRecordCallback(recordId) {
			AttachmentRepository.remove({
				id: recordId
			}, function (response) {
				sweetAlert.close();
				if (!response.status) {
					showTost("Error:", response.message, "danger");
					return;
				}
				showTost("Success:", "Record Deleted Successfully", "success");
				vm.record.file = {};
			}, function (error) {
				sweetAlert.close();
				showTost("Error:", "Some Things went wrong.", "danger");
			});
		}
	}
}());
