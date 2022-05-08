window.ShowToastr = (type, message) => {
    if (type == "success") {
        toastr.success(message, 'Operation Successful', { timeOut: 5000 })
    }

    if (type == "error") {
        toastr.error(message, 'Operation Failed', { timeOut: 5000 })
    }
}


window.ShowSwal = (type, message) => {
    if (type == "success") {
        Swal.fire(
            'Success notification!',
            'You clicked the button!',
            'success'
        )
    }

    if (type == "error") {
        Swal.fire(
            'Error notification!',
            'You clicked the button!',
            'error'
        )
    }
}

function ShowDeleteConfirmationModal() {
    $('#deleteConfirmationModal').modal('show');
}

function HideDeleteConfirmationModal() {
    $('#deleteConfirmationModal').modal('hide');
}