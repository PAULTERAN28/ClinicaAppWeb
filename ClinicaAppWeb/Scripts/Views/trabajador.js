
var id_empleado = -1;
var id_persona = -1;



$('#btnActualizarEmpleado').click(function () {
    var datos = Object();
    datos.id_persona = id_persona;
    datos.id_empleado = id_empleado;
    datos.id_tipo_area = $('#cbxArea').val();
    datos.detalle = $('#txtDetalle').val();
    datos.id_tipo_empleado = $('#cbxTipoEmpleado').val();
    datos.nombre = $('#txtNombreEmpleado').val();
    datos.apellido_paterno = $('#txtApellidoPaterno').val();
    datos.apellido_materno = $('#txtApellidoMaterno').val();
    datos.fecha_nacimiento = $('#txtFechaNacimiento').val();
    datos.dni = $('#txtDni').val();
    datos.celular = $('#txtCelular').val();
    datos.correo = $('#txtCorreo').val();
    datos.sexo = $('#cbxSexo').val();
    datos.direccion = $('#txtDireccion').val();
    $.ajax({
        url: "/Trabajador/actualizarEmpleado?empleado=" + JSON.stringify(datos),
        type: "POST",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {

            if (data.resultado) {
                swal("Mensaje", "Se actualizo correctamente al empleado", "success")
                setInterval("inicializarPagina()", 2000);
            } else {
                swal("Mensaje", "No se pudo actualizar al empleado", "warning")
                /*setInterval("inicializarPagina()", 2000);*/
            }



        },
        error: function () {
            console.log('err')
        }

    });
})


$('#btnAgregarEmpleado').click(function () {

    var datos = Object();
    
    datos.nombre = $('#txtNombreEmpleado').val();
    datos.apellido_paterno = $('#txtApellidoPaterno').val();
    datos.apellido_materno = $('#txtApellidoMaterno').val();
    datos.fecha_nacimiento = $('#txtFechaNacimiento').val();
    datos.dni = $('#txtDni').val();
    datos.celular = $('#txtCelular').val();
    datos.correo = $('#txtCorreo').val();
    datos.sexo = $('#cbxSexo').val();
    datos.direccion = $('#txtDireccion').val();
    datos.detalle = $('#txtDetalle').val();
    datos.id_tipo_area = $('#cbxArea').val();
    datos.id_tipo_empleado = $('#cbxTipoEmpleado').val();

    console.log(datos);
    $.ajax({
        url: "/Trabajador/registrarEmpleado?empleado=" + JSON.stringify(datos),
        type: "POST",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {

            if (data.resultado) {
                swal("Mensaje", "Se registro correctamente al empleado", "success")
                setInterval("inicializarPagina()", 2000);
            } else {
                swal("Mensaje", "No se pudo registrar al empleado", "warning")
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

function activarBtnActualizar() {
    const btnActualizar = document.getElementById('btnActualizarEmpleado');
    btnActualizar.disabled = false;
}




function GetDatos(tbody,table) {
    $(tbody).on('click', '#btnEditar', function () {
        activarBtnActualizar();
        var datosTabla = table.row($(this).parents('tr')).data();

        id_empleado = datosTabla.id_empleado;
        id_persona = datosTabla.id_persona;

        $('#txtNombreEmpleado').val(datosTabla.nombre);
        $('#txtApellidoPaterno').val(datosTabla.apellido_paterno);
        $('#txtApellidoMaterno').val(datosTabla.apellido_materno);
        $('#txtDni').val(datosTabla.dni);
        $('#txtCelular').val(datosTabla.celular);
        $('#txtCorreo').val(datosTabla.correo);
        $('#txtDireccion').val(datosTabla.direccion);
        $('#txtDetalle').val(datosTabla.detalle);
        document.querySelector('#cbxSexo').value = datosTabla.sexo;
        document.querySelector('#cbxArea').value = datosTabla.id_tipo_area;
        document.querySelector('#cbxTipoEmpleado').value = datosTabla.id_tipo_empleado;
        
    })

    $(tbody).on('click', '#btnEliminar', function () {
        var datosTabla = table.row($(this).parents('tr')).data();

        id_empleado = datosTabla.id_empleado;
        id_persona = datosTabla.id_persona;

        if (id_empleado == -1 || id_persona == -1) {
            swal("Mensaje", "Debe Seleccionar un empleado para eliminar", "warning")
        } else {
            var datos = Object();
            datos.id_persona = id_persona;
            datos.id_empleado = id_empleado;
            $.ajax({
                url: "/Trabajador/eliminarEmpleado?empleado=" + JSON.stringify(datos),
                type: "POST",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {

                    if (data.resultado) {
                        swal("Mensaje", "Se elimino correctamente al empleado", "success")
                        setInterval("inicializarPagina()", 2000);
                    } else {
                        swal("Mensaje", "No se pudo eliminar al empleado", "warning")
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






$(document).ready(function () {

    var tableEmpleados = $('#tbEmpleados').DataTable({
        "destroy": true,
        "processing": true,
        "ajax": {
            "url": "/Trabajador/GetListadoEmpleados",
            "type": "GET"
        },
        "columns": [
            
            { "data": "id_persona" },
            { "data": "id_empleado" },
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
            { "data": "id_tipo_area" },
            { "data": "nombre_tipo_area" },
            { "data": "id_tipo_empleado" },
            { "data": "nombre_tipo_empleado" },
            { "defaultContent": "<button class='btn btn-info'  id='btnEditar' name='btnEditar'>Editar<span class='glyphicon glyphicon-pencil'></span></button> <button class='btn btn-danger' id='btnEliminar' name='btnEliminar'>Eliminar<span class='glyphicon glyphicon-trash'></span></button> " }


        ]

    });

    GetDatos('#tbEmpleados', tableEmpleados);







    $.ajax({

        url: '/Trabajador/GetListadoAreas',
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
    $.ajax({

        url: '/Trabajador/GetListadoTipoEmpleados',
        type: "GET",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            //cbxArea
            var area = $('#cbxTipoEmpleado');
            var datos = data.data;
            $(datos).each(function (i, v) {
                area.append('<option value="' + v.id_tipo_empleado + '">' + v.nombre_tipo_empleado + '</option>')
            });


        },
        error: function () {
            console.log('err')
        }

    });



});