function customDeleteConfirmation(callback, param1, param2, param3) {
	swal({
		title: "Are you sure?",
		type: "warning",
		showCancelButton: true,
		confirmButtonColor: "#DD6B55",
		confirmButtonText: "Yes, delete it!",
		closeOnConfirm: true,
		allowEscapeKey: false
	}, function () {
		callback(param1, param2, param3);
	});
}


function customTextConfirmation(mainText, subText, callback, param1, param2) {
	swal({
		title: mainText,
		type: "info",
		showCancelButton: true,
		confirmButtonColor: "#DD6B55",
		confirmButtonText: subText,
		closeOnConfirm: false,
		allowEscapeKey: false
	}, function () {
		callback(param1, param2);
	});
}

function customMessageAlert(_message, _type) {
	swal({
		title: _message,
		type: _type,
		html: true,
		allowEscapeKey: false
	});
}

function showTost(title, message, type) {
	$.notify({
		title: title,
		message: message,
		icon: (type == "info" || type == "success") ? 'fa fa-check' : 'fa fa-times'
	}, {
		type: type,
		allow_dismiss: false,
		placement: {
			from: "top",
			align: "right"
		},
		newest_on_top: true,
		offset: 20,
		z_index: 1031,
		delay: 5000,
		timer: 1000,
	});
}
