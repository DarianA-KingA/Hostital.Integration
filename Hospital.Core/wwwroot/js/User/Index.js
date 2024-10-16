loadDataTable();

function loadDataTable() {
    let dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/User/GetAll"
        },
        "columns": [
            { "data": "cedula" },
            { "data": "name" },
            { "data": "lastName" },
            { "data": "email" },
            { "data": "phoneNumber" },
            { "data": "roleName" },
            {
                "data": "estado",
                "render": function (data) {
                    if (data) {
                        return `<span class="badge bg-success">Activo</span>`;
                    } else {
                        return `<span class="badge bg-danger">Inactivo</span>`;
                    }
                }
            },
            {
                "data": "id",
                "render": function (data) {
                    return `
                        <div class="w-75 btn-group">
                            <a href="/User/Details?userId=${data}"
                               class="btn btn-secondary"><i class="fa-solid fa-circle-info"></i></a>
                            <a href="/User/Edit?userId=${data}"
                               class="btn btn-primary"><i class="fa-solid fa-pen-to-square"></i></a>
                            <a href="/User/ActivateDisactivate?userId=${data}"
                               class="btn btn-info"><i class="fa-solid fa-arrow-rotate-right"></i></a> 
                        </div>
                    `;
                },
                "width": "5%"
            },
        ]
    });
}
