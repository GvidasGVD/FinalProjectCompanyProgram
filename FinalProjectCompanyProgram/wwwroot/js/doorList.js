//import { Toast } from "../lib/bootstrap/dist/js/bootstrap.bundle";

var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/doors/getall/",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "type", "width": "9%" },
            { "data": "model", "width": "9%" },
            { "data": "doorLeaf", "width": "9%" },
            { "data": "doorJamb", "width": "9%" },
            { "data": "hinges", "width": "9%" },
            { "data": "finish", "width": "9%" },
            { "data": "height", "width": "9%" },
            { "data": "width", "width": "9%" },
            { "data": "price", "width": "9%" },
            { "data": "additions", "width": "9%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                        <a href="/Doors/Edit?id=${data}" class='btn btn-success text-white' style='cursor:pointer; width:70px;'>
                            Edit
                        </a>
                        &nbsp;
                        <a class='btn btn-danger text-white' style='cursor:pointer; width:70px;'
                            onclick=Delete('/Doors/AjaxDelete?id=${data}')>
                            Delete
                        </a>
                        </div>`;
                }, "width": "9%"
            }
        ],
        "language": {
            "emptyTable": "no data found"
        },
        "width": "100%"
    });
}
function Delete(url) {
    swal({
        title: "Are you sure?",
        text: "Once deleted, you will not be able to recover the record",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        //dataTable.ajax.reload();
                        location.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }

                }
            });
        }
    });
}
