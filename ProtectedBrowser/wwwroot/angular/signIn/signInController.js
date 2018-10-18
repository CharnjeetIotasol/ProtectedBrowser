(function () {

	var applicationApp = angular.module("applicationApp");
	applicationApp.controller("SignInController", signInController);
	signInController.$inject = ["$scope", "$state", "$filter", "localStorageService", "$timeout", "SignInRepository", "CommonUtils"];

	function signInController($scope, $state, $filter, localStorageService, $timeout, SignInRepository, CommonUtils) {

		var vm = this;
		vm.signIn = signIn;
		vm.resetPassword = resetPassword;
		vm.onClickValidation = false;
		vm._view = 'LOGIN';

		function signIn(bol, form) {
			vm.onClickValidation = !bol;
			if (!bol) {
				if (form.username.$error.email) {
					showTost("Error:", "Please enter valid email", "danger");
				}
				return false;
			}
			SignInRepository.signIn({
				email: vm.username,
				password: vm.password
			}, function (data) {
				if (!data.status) {
					showTost("Error:", data.message, "danger");
					vm.result = data;
					return;
				}
				var response = data.data;
				response.token.expires_at = new Date(response.token.expires).getTime();
				localStorageService.set('token', response.token);
				localStorageService.set('user', response.user);
				$timeout(function () {
					window.location.href = "/dashboard";
				}, 100);
			});
		}

		function resetPassword(bol, form) {
			vm.onClickValidation = !bol;
			if (!bol) {
				if (form.remail.$error.email) {
					showTost("Error:", "Please enter valid email", "danger");
				}
				return false;
			}
			SignInRepository.resetPassword({
				userName: vm.recoverEmail,
			}, function (data) {
				if (!data.status) {
					showTost("Error:", data.message, "danger");
					return;
				}
				vm.recoverEmail = "";
				showTost("Success:", data.message, "success");
				$('.login-box').toggleClass('flipped');
			});
		}
		vm.loadForgotPage = loadForgotPage;

		function loadForgotPage() {
			vm.onClickValidation = false;
			$("#loginContainer").slideUp();
			$("#forgotContainer").fadeIn();
		}

		vm.loadLoginPage = loadLoginPage;

		function loadLoginPage() {
			vm.onClickValidation = false;
			$("#forgotContainer").fadeOut();
			$("#loginContainer").slideDown();
		}
	}
}());
