
var id_cliente = -1;
var id_persona = -1;

$('#btnAgregarCliente').click(function () {

    var datos = Object();
    datos.detalle = $('#txtDetalle').val();
    datos.nombre = $('#txtNombreCliente').val();
    datos.apellido_paterno = $('#txtApellidoPaterno').val();
    datos.apellido_materno = $('#txtApellidoMaterno').val();
    datos.fecha_nacimiento = $('#txtFechaNacimiento').val();
    datos.dni = $('#txtDni').val();
    datos.celular = $('#txtCelular').val();
    datos.correo = $('#txtCorreo').val();
    datos.sexo = $('#cbxSexo').val();
    datos.direccion = $('#txtDireccion').val();

    
    $.ajax({
        url: "/Paciente/registrarCliente?cliente=" + JSON.stringify(datos),
        type: "POST",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {

            if (data.resultado) {
                swal("Mensaje", "Se registro correctamente al cliente", "success")
                setInterval("inicializarPagina()", 2000);
            } else {
                swal("Mensaje", "No se pudo registrar al cliente", "warning")
                /*setInterval("inicializarPagina()", 2000);*/
            }



        },
        error: function () {
            console.log('err')
        }

    });


});

function inicializarPagina() {
    location.reload();
}


$(document).ready(function () {


    var tableClientes = $('#tbClientes').DataTable({
        "destroy": true,
        "processing": true,
        "ajax": {
            "url": "/Paciente/GetListadoClientes",
            "type": "GET"

        },
        "columns": [
            { "data": "id_persona" },
            { "data": "id_cliente" },
            { "data": "nombre" },
            { "data": "apellido_paterno" },
            { "data": "apellido_materno" },
            { "data": "dni" },
            { "data": "celular" },
            { "data": "correo" },
            {
                "data": "sexo",
                "render": function (data) {
                    if (data) {
                        return '<span class="badge badge-success">MASCULINO</span>'
                    } else {
                        return '<span class="badge badge-success">FEMENINO</span>'
                    }
                }
            },
            { "data": "direccion" },
            { "data": "detalle" },
            { "defaultContent": "<button class='btn btn-info'  id='btnEditar' name='btnEditar'>Editar<span class='glyphicon glyphicon-pencil'></span></button> <button class='btn btn-danger' id='btnEliminar' name='btnEliminar'>Eliminar<span class='glyphicon glyphicon-trash'></span></button> " }

        ]

    });
    GetDatos('#tbClientes', tableClientes);
});
function activarBtnActualizar() {
    const btnActualizar = document.getElementById('btnActualizarCliente');
    btnActualizar.disabled = false;
}

$('#btnActualizarCliente').click(function () {
    var datos = Object();
    datos.id_persona = id_persona;
    datos.id_cliente = id_cliente;
    datos.detalle = $('#txtDetalle').val();
    datos.nombre = $('#txtNombreCliente').val();
    datos.apellido_paterno = $('#txtApellidoPaterno').val();
    datos.apellido_materno = $('#txtApellidoMaterno').val();
    datos.fecha_nacimiento = $('#txtFechaNacimiento').val();
    datos.dni = $('#txtDni').val();
    datos.celular = $('#txtCelular').val();
    datos.correo = $('#txtCorreo').val();
    datos.sexo = $('#cbxSexo').val();
    datos.direccion = $('#txtDireccion').val();

    $.ajax({
        url: "/Paciente/actualizarCliente?cliente=" + JSON.stringify(datos),
        type: "POST",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {

            if (data.resultado) {
                swal("Mensaje", "Se actualizo correctamente al cliente", "success")
                setInterval("inicializarPagina()", 2000);
            } else {
                swal("Mensaje", "No se pudo actualizo al cliente", "warning")
                /*setInterval("inicializarPagina()", 2000);*/
            }



        },
        error: function () {
            console.log('err')
        }

    });
})

function GetDatos(tbody, table) {
    $(tbody).on('click', '#btnEditar', function () {
        activarBtnActualizar();
        var datosTabla = table.row($(this).parents('tr')).data();
        id_cliente = datosTabla.id_cliente;
        id_persona = datosTabla.id_persona;

        $('#txtDetalle').val(datosTabla.detalle);
        $('#txtNombreCliente').val(datosTabla.nombre);
        $('#txtApellidoPaterno').val(datosTabla.apellido_paterno);
        $('#txtApellidoMaterno').val(datosTabla.apellido_paterno);
        
        $('#txtDni').val(datosTabla.dni);
        $('#txtCelular').val(datosTabla.celular);
        $('#txtCorreo').val(datosTabla.correo);

        document.querySelector('#cbxSexo').value = datosTabla.sexo;

       
       
        $('#txtDireccion').val(datosTabla.direccion);

    });

    $(tbody).on('click', '#btnEliminar', function () {
        var datosTabla = table.row($(this).parents('tr')).data();
        id_cliente = datosTabla.id_cliente;
        id_persona = datosTabla.id_persona;

        if (id_cliente == -1 || id_persona == -1) {
            swal("Mensaje", "Debe Seleccionar un cliente para eliminar", "warning")
        } else {
            var datos = Object();
            datos.id_persona = id_persona;
            datos.id_cliente = id_cliente;
           
            $.ajax({
                url: "/Paciente/eliminarCliente?cliente=" + JSON.stringify(datos),
                type: "POST",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {

                    if (data.resultado) {
                        swal("Mensaje", "Se elimino correctamente al cliente", "success")
                        setInterval("inicializarPagina()", 2000);
                    } else {
                        swal("Mensaje", "No se pudo eliminar al cliente", "warning")
                        /*setInterval("inicializarPagina()", 2000);*/
                    }



                },
                error: function () {
                    console.log('err')
                }

            });
        }
    })

}