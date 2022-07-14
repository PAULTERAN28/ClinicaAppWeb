

var id_usuario = -1;
var id_persona = -1;

$('#btnActualizarUsuario').click(function () {
    var datos = Object();
    datos.id_usuario = id_usuario;
    datos.id_persona = id_persona;
    datos.id_tipo_usuario = $('#cbxTipoUsuario').val();
    datos.usuario = $('#txtUsuario').val();
    datos.password = $('#txtPassword').val();
    $.ajax({
        url: "/Usuario/actualizarUsuario?usuario=" + JSON.stringify(datos),
        type: "POST",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {

            if (data.resultado) {
                swal("Mensaje", "Se actualizo correctamente al usuario", "success")
                setInterval("inicializarPagina()", 2000);
            } else {
                swal("Mensaje", "No se pudo actualizo al usuario", "warning")
                /*setInterval("inicializarPagina()", 2000);*/
            }



        },
        error: function () {
            console.log('err')
        }

    });
})

$('#btnAgregarUsuario').click(function () {
    var datos = Object();
    datos.id_persona = $('#cbxDni').val();
    datos.id_tipo_usuario = $('#cbxTipoUsuario').val();
    datos.usuario = $('#txtUsuario').val();
    datos.password = $('#txtPassword').val();

    $.ajax({
        url: "/Usuario/registrarUsuario?usuario=" + JSON.stringify(datos),
        type: "POST",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {

            if (data.resultado) {
                swal("Mensaje", "Se registro correctamente al usuario", "success")
                setInterval("inicializarPagina()", 2000);
            } else {
                swal("Mensaje", "No se pudo registrar al usuario", "warning")
                /*setInterval("inicializarPagina()", 2000);*/
            }



        },
        error: function () {
            console.log('err')
        }

    });
})
function inicializarPagina() {
    location.reload();
}



function GetDatos(tbody, table) {
    $(tbody).on('click', '#btnEditar', function () {
        activarBtnActualizar();
        var datosTabla = table.row($(this).parents('tr')).data();
        id_usuario = datosTabla.id_usuario;
        id_persona = datosTabla.id_persona;
        let cbxTipoUsuario = document.querySelector('#cbxTipoUsuario');
        cbxTipoUsuario.value = datosTabla.id_tipo_usuario;
        $('#txtUsuario').val(datosTabla.usuario);
        let cbxDni = document.querySelector('#cbxDni');
        cbxDni.value = datosTabla.id_persona;
        
       
        

    });
    $(tbody).on('click', '#btnEliminar', function () {
        
        var datosTabla = table.row($(this).parents('tr')).data();
        id_usuario = datosTabla.id_usuario;
        id_persona = datosTabla.id_persona;

        if (id_usuario == -1 || id_persona == -1) {
            swal("Mensaje", "Debe Seleccionar un usuario para eliminar", "warning")
        } else {
            var datos = Object();
            datos.id_usuario = id_usuario;
            datos.id_persona = id_persona;
            $.ajax({
                url: "/Usuario/eliminarUsuario?usuario=" + JSON.stringify(datos),
                type: "POST",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {

                    if (data.resultado) {
                        swal("Mensaje", "Se elimino correctamente al usuario", "success")
                        setInterval("inicializarPagina()", 2000);
                    } else {
                        swal("Mensaje", "No se pudo eliminar al usuario", "warning")
                        /*setInterval("inicializarPagina()", 2000);*/
                    }



                },
                error: function () {
                    console.log('err')
                }

            });
        }


    });
}
function activarBtnActualizar() {
    const btnActualizar = document.getElementById('btnActualizarUsuario');
    btnActualizar.disabled = false;
}

$(document).ready(function () {

    var tableUsuarios = $('#tbUsuarios').DataTable({
        "destroy": true,
        "processing": true,
        "ajax": {
            "url": "/Usuario/GetListadoUsuariosPersonas",
            "type": "GET"

        },
        "columns": [
            { "data": "id_persona" },
            { "data": "id_usuario" },
            { "data": "usuario" },
            { "data": "nombre" },
            { "data": "apellido_paterno" },
            { "data": "apellido_materno" },
            { "data": "dni" },
            { "data": "celular" },
            { "data": "correo" },
            { "data": "id_tipo_usuario" },
            { "data": "nombre_tipo_usuario" },
            { "defaultContent": "<button class='btn btn-info'  id='btnEditar' name='btnEditar'>Editar<span class='glyphicon glyphicon-pencil'></span></button> <button class='btn btn-danger' id='btnEliminar' name='btnEliminar'>Eliminar<span class='glyphicon glyphicon-trash'></span></button> " }


        ]




    });
    GetDatos('#tbUsuarios', tableUsuarios);



    $.ajax({

        url: '/Usuario/GetPersonas',
        type: "GET",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            //cbxArea
            var area = $('#cbxDni');
            var datos = data.data;
            $(datos).each(function (i, v) {
                area.append('<option value="' + v.id_persona + '">' + v.dni + '</option>')
            });


        },
        error: function () {
            console.log('err')
        }

    });
    $.ajax({

        url: '/Usuario/GetTipoUsuarios',
        type: "GET",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            //cbxArea
            var area = $('#cbxTipoUsuario');
            var datos = data.data;
            $(datos).each(function (i, v) {
                area.append('<option value="' + v.id_tipo_usuario + '">' + v.nombre_tipo_usuario + '</option>')
            });


        },
        error: function () {
            console.log('err')
        }

    });


})