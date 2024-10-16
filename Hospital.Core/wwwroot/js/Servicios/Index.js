loadDataTable();

function loadDataTable() {
    let dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Servicios/GetAll"
        },
        "columns": [
            { "data": "id" },
            { "data": "descricionTipoServcio" },
            { "data": "descripcionAreaMedica" },
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
            { "data": "costo" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                        <div class="w-75 btn-group">
                            <a href="/Servicios/Details?id=${data}"
                               class="btn btn-secondary"><i class="fa-solid fa-circle-info"></i></a>
                            <a href="/Servicios/Edit?id=${data}"
                               class="btn btn-primary"><i class="fa-solid fa-pen-to-square"></i></a>
                            <a href="/Servicios/ActivateDisactivate?id=${data}"
                               class="btn btn-info"><i class="fa-solid fa-arrow-rotate-right"></i></a> 
                        </div>
                    `;
                },
                "width": "5%"
            },
        ]
    });
}
