//Variables Globales
var tabla;
//Fin Variables Globales

//Funciones
function inicializar() {
    tabla = $('#tbl_device').DataTable(
        {
            "order": [[2, "asc"]],
            "columnDefs": [
                {
                    "targets": [0],
                    "searchable": false,
                    "visible": false,
                },
                {
                    "targets": [1],
                    "searchable": true,
                    "className": "text-center",
                    "visible": true
                },
                {
                    "targets": [2],
                    "className": "text-center"
                },
                {
                    "targets": [3],
                    "className": "text-center"
                }
            ],
            "dom": 'Blfrtip',
            "buttons": [

            ],
            "paging": false,
            "autoWidth": false,
            "pageLength": 25,
            "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "All"]],
            "oLanguage":
            {
                "sInfo": "Tenemos un total de _TOTAL_ para mostrar (_START_ to _END_)",
                "sLengthMenu": "Mostrar _MENU_ ",
                "sSearch": "<i class='fa fa-search' aria-hidden='true'></i> Buscar:",
                "oPaginate": {
                    "sNext": "Siguiente",
                    "sPrevious": "Anterior"
                },
                "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
                "oAria": {
                    "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
                    "sSortDescending": ": Activar para ordenar la columna de manera descendente"
                }
            }
        }
    );
    tabla.buttons().container()
        .appendTo($('.col-sm-6:eq(0)', tabla.table().container()));
    GetDataAjax();
}
function GetDataAjax() {
    $.ajax({
        type: "GET",
        url: "/Device/GetListDevice",
        data: null,
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr.status + "\n" + xhr.responseText, + "\n" + thrownError);
        },
        success: function (data) {
            tabla.clear().draw();
            if (data.length > 0) {
                console.log(data);
                CargaDevice(data);
            }
        }
    });
}
function CargaDevice(data) {
    for (var i = 0; i < data.length; i++) {
        button = "";
        if ((data[i].status != 0) && (data[i].status != 2)) {
            button = `<button title ="Borrar" id="${data[i]._id}" class="btn btn-danger btn-deny" style="width:50%;"> <i class="fa fa-trash"></i> </button>`;
        }
        tabla.row.add([
            data[i]._id,
            data[i].host,
            data[i].model,
            button
        ]).draw(false);
    }
}
//Fin Funciones

function DeleteDataAjax(idDelete) {
    $.ajax({
        type: "POST",
        url: "/Device/Delete",
        data: {id:idDelete},
        dataType: 'json',
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr.status + "\n" + xhr.responseText, + "\n" + thrownError);
        },
        success: function (data) {
            tabla.clear().draw();
            tabla.destroy()
            if(data == "200"){
                console.log("200")
                inicializar();
            }
            else{
                console.log("400")
            }

        }
    });
}
//Eventos
inicializar();

$(document).on('click', '.btn-deny', function (e) {
    console.log(e.target.id);
    e.preventDefault();
    var datotabla = $(this).parent().parent();
    var dataRow = tabla.row(datotabla).data();
    var idTarget = e.target.id;
    DeleteDataAjax(idTarget);
    //sendDataAjax(data[0], 0);

}); 
//Fin Eventos