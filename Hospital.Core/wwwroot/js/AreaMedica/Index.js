loadDataTable();

function loadDataTable() {
    let dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/AreasMedicas/GetAll"
        },
        "columns": [
            { "data": "id" },
            { "data": "descripcion" },
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
                            <a href="/AreasMedicas/Details?id=${data}"
                               class="btn btn-secondary"><i class="fa-solid fa-circle-info"></i></a>
                            <a href="/AreasMedicas/Edit?id=${data}"
                               class="btn btn-primary"><i class="fa-solid fa-pen-to-square"></i></a>
                            <a href="/AreasMedicas/ActivateDisactivate?id=${data}"
                               class="btn btn-info"><i class="fa-solid fa-arrow-rotate-right"></i></a> 
                        </div>
                    `;
                },
                "width": "5%"
            },
        ]
    });
}
