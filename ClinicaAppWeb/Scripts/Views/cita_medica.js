
//declaramos las variables globales para obtener los idEmpleado , idCliente que se guardan cuando se buscan por su respectivo procedimiento almacenado
var idEmpleado = -1;
var idCliente = -1;



function buscarEmpleado() {

    dni = document.getElementById("txtDniEmpleado").value;
    $.ajax({
        url: '/CitaMedica/buscarEmpleadoPorDNI?dni=' + dni,
        type: "GET",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            
            var datos = data.data

            $('#txtNombreEmpleado').val(datos.nombre);

            idEmpleado = datos.id_empleado;
        },
        error: function () {
            console.log('err')
        }

    });
}

function buscarCliente() {

    dni = document.getElementById("txtDniCliente").value;
    $.ajax({
        url: '/CitaMedica/buscarClientePorDNI?dni=' + dni,
        type: "GET",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {

            var datos = data.data;
            $("#txtNombreCliente").val(datos.nombre);
            idCliente = datos.id_cliente;
           
        },
        error: function () {
            console.log('err')
        }

    });
}


$('#btnGuardarCitaMedica').click(function () {
    
    if (idEmpleado == -1 || idCliente == -1) {
        swal("Mensaje", "se debe buscar cliente y empleado para poder registrar cita", "warning")
    } else {
        var datos = Object();
        datos.id_empleado = idEmpleado;
        datos.id_cliente = idCliente;
        datos.id_tipo_area = $('#cbxArea').val();
        datos.fecha_atencion = $('#txtFechaAtencion').val();
        datos.detalle_cita = $('#txtDetalleCita').val();
        datos.id_tipo_servicio = $('#cbxTipoServicioClinico').val();
        datos.precio = $('#txtPrecio').val();

        $.ajax({
            url: '/CitaMedica/registrarCitaMedica' + "?cita=" + JSON.stringify(datos),
            type: "POST",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {

                if (data.resultado) {
                    swal("Mensaje", "Se registro correctamente la cita", "success")
                    setInterval("inicializarPagina()", 2000);
                } else {
                    swal("Mensaje", "No se pudo registrar la cita", "warning")
                    setInterval("inicializarPagina()", 2000);
                }



            },
            error: function () {
                console.log('err')
            }

        });



    }







});

function inicializarPagina() {
    location.reload();
}


$(document).ready(function () {
    $.ajax({
       
        url: '/CitaMedica/GetListadoAreas',
        type: "GET",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            //cbxArea
            var area = $('#cbxArea');
            var datos = data.data;
            $(datos).each(function (i, v) {
                area.append('<option value="' + v.id_tipo_area + '">' + v.nombre_tipo_area + '</option>')
            });


        },
        error: function () {
            console.log('err')
        }

    });

    //getListadoTipoServicioClinico
    $.ajax({

        url: '/CitaMedica/getListadoTipoServicioClinico',
        type: "GET",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            //cbxArea
            var area = $('#cbxTipoServicioClinico');
            var datos = data.data;
            $(datos).each(function (i, v) {
                area.append('<option value="' + v.id_tipo_servicio + '">' + v.nombre_servicio + '</option>')
            });


        },
        error: function () {
            console.log('err')
        }

    });

    var tableCitaMedicas = $('#tbCitasMedicas').dataTable({
        "destroy": true,
        "processing": true,
        "ajax": {
            "url": "/CitaMedica/listadoCitaMedicas",
            "type": "GET"
        },
        "columns": [
            { "data": "id_cita" },
            { "data": "id_empleado" },
            { "data": "NombreEmpleado" },
            { "data": "id_cliente" },
            { "data": "NombreCliente" },
            { "data": "id_tipo_area" },
            { "data": "nombre_tipo_area" },
            { "data": "detalle_cita" },
            { "data": "id_tipo_servicio" },
            { "data": "nombre_servicio" },
            { "data": "id_servicio_clinico" },
            { "data": "precio" },
            


        ]

    });





})

//$.fn.dataTable.render.moment = function (from, to, locale) {
//    if (arguments.length === 1) {
//        locale = 'en';
//        to = from;
//        from = 'YYYY-MM-DD';
//    } else if (arguments.length === 2) {
//        locale = 'en';
//    }
//    return function (d, type, row) {
//        if (!d) {
//            return type === 'sort' || type === 'type' ? 0 : d;
//        }
//        var m = window.moment(d, from, locale, true);

//        return m.format(type === 'sort' || type === 'type' ? 'x' : to);
//    };

//};