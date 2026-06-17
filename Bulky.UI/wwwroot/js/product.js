var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        ajax: { url: '/Product/GetAll' },
        columns: [
            { data: 'name', "width": '25%' },
            { data: 'isbn', "width": '10%' },
            { data: 'author', "width": '20%' },
            { data: 'listPrice', "width": '10%' },
            { data: 'category.name', "width": '15%' },
            {
                data: 'id', "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                            <a href="/Product/upsert?id=${data}" class="btn btn-primary mx-2">
                            <i class="bi bi-pencil-square"></i> Edit
                            </a>
                            <a onclick="Delete('/Product/delete/${data}')" class="btn btn-danger mx-2">
                            <i class="bi bi-trash-fill"></i> Delete
                            </a>
                           </div>`;
                }, "width": '25%'
            }
        ]
    });
}


function Delete(url) {
    const swalWithBootstrapButtons = Swal.mixin({
        customClass: {
            confirmButton: "btn btn-success",
            cancelButton: "btn btn-danger"
        },
        buttonsStyling: false
    });
    swalWithBootstrapButtons.fire({
        title: "Are you sure?",
        text: "You won't be able to revert this!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonText: "Yes, delete it!",
        cancelButtonText: "No, cancel!",
        reverseButtons: true
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    dataTable.ajax.reload();
                    toast.success(data.message);
                }
            })
        };
    });
}