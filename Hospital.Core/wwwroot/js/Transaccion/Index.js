loadDataTable();

function loadDataTable() {
    let dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Transacciones/GetAll"
        },
        "columns": [
            { "data": "id" },
            { "data": "nombreCajero" },
            { "data": "nombrePaciente" },
            { "data": "tipoTransaccion" },
            { "data": "estadoTransaccion" },
            { "data": "monto" },
            { "data": "fecha" },
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
                            <a href="/Transacciones/Details?id=${data}"
                               class="btn btn-secondary"><i class="fa-solid fa-circle-info"></i></a>
                            <a href="/Transacciones/Edit?id=${data}"
                               class="btn btn-primary"><i class="fa-solid fa-pen-to-square"></i></a>
                            <a href="/Transacciones/ActivateDisactivate?id=${data}"
                               class="btn btn-info"><i class="fa-solid fa-arrow-rotate-right"></i></a> 
                        </div>
                    `;
                },
                "width": "5%"
            },
        ]
    });
}
