/* 
 * Código JaVaScript uso de Ajax
 * 
 * @Autor César Marino Cuéllar
 */
$(function () {

    $("#cbTipo").change(function () {

        var parametros = {
            "tipo": $('#cbTipo').val(),
            "piso": $('#cbPiso').val()
        };

        $.ajax({
            // url: '../ServiceAjax.svc/obtenerHabitacionesDisponibles',
            url: 'SolicitudesAjax.aspx/obtenerHabitacionesDisponibles',
            data: parametros,
            dataType: 'json',
            type: 'post',
            contentType: "application/json; charset=utf-8",
            success: function (resultado) {
                var habita = JSON.parse(resultado.d);
                console.log(habita);


                $.each(habita, function (index, item) {
                    $("#cbHabitacion").append("<option value=" + item.idHabitacion + ">" + item.Numero + " </option>");
                });

            },
            error: function (result) {
                alert("ERROR " + result.status + ' ' + result.statusText);
            }

        });
    });

    $("#txtIdentificacion").change(function () {
        var parametros = {
            "identificacion": $('#txtIdentificacion').val()
        };
        $.ajax({
            // url: '../ServiceAjax.svc/obtenerClientePorIdentificacion',
            url: 'SolicitudesAjax.aspx/obtenerClientePorIdentificacion',
            data: parametros,
            dataType: 'json',
            type: 'post',
            contentType: "application/json; charset=utf-8",
            success: function (resultado) {
                console.log(resultado.d);
                /*if (resultado.d != null) {
                    $("#txtNombre").val(resultado.d.Nombre);
                    $("#txtCorreo").val(resultado.d.Correo);
                } else {
                    $("#txtNombre").val('');
                    $("#txtCorreo").val('');
                }
                /* var habita = resultado.d;
 
                 $("#habita").append("<asp:DropDownList ID='cbHabitacion' runat='server' Height='26px' Width='269px'>");
                 $.each(habita, function (index, item) {
                     $("#habita").append("<option value=" + item.idHabitacion + ">" + item.Numero + " </option>");
                 });
                 $("#habita").append("</asp:DropDownList>");*/
            },
            error: function (result) {
                alert("ERROR " + result.status + ' ' + result.statusText);
            }

        });
    });

    //#departamento: el campo select de los departamentos
    $("#departamento").change(function () {

        /*los parametros que vamos a pasar al llamar al archivo
        obtenerMunicipos.php*/
        var parametros = {
            "idDepartamento": $('#departamento').val()
        };
        $.ajax({
            url: '../../Controlador/obtenerMunicipios.php',
            data: parametros,
            type: 'post',
            success: function (response) {
                /*#municipios: nombre del div donde coloca todo el html
                que trae del archivo obtenerMunicipios.php*/
                $("#municipios").html(response);
            }
        });
    });



    $("#txtIdentifica").change(function () {
        var parametros = {
            "identifica": $('#txtIdentifica').val()
        };
        $.ajax({
            url: '../../Controlador/ctrlObtenerPacienteByIdentificacion.php',
            data: parametros,
            type: 'post',
            dataType: 'text',
            success: function (response) {
                var respuesta = response;
                if (respuesta == "NO") {
                    $("#mensajeId").html("Paciente con dicha Identificación No Existe");
                    $("#txtNombres").val('');
                    $("#txtApellidos").val('');
                }
                else {
                    var nombre = respuesta.split(',');
                    $("#txtNombres").val(nombre[0]);
                    $("#txtApellidos").val(nombre[1]);
                    $("#mensajeId").html("");
                }
            }
        });
    });

    $("#especialidad").change(function () {
        var parametros = {
            "especialidad": $('#especialidad').val()
        };
        $.ajax({
            url: '../../Controlador/obtenerMedicosByEspecialidad.php',
            data: parametros,
            type: 'post',
            success: function (response) {
                $("#medicos").html(response);
            }
        });
    });



    $("#medicos").on("change", "#medico", function () {
        $("#txtFechaCita").val('');
        var parametros = {
            "medico": $('#medico').val()
        };
        $.ajax({
            url: '../../Controlador/ctrlObtenerConsultorio.php',
            data: parametros,
            type: 'post',
            dataType: 'text',
            success: function (response) {
                $datosConsultorio = response.split(',');
                $("#idConsultorio").val($datosConsultorio[0]);
                $("#txtConsultorio").val($datosConsultorio[1]);
            }
        });
    });

    $("#txtFechaCita").change(function () {
        var parametros = {
            "medico": $('#medico').val(),
            "fechaCita": $('#txtFechaCita').val()
        };
        $.ajax({
            url: '../../Controlador/ctrlHorasCita.php',
            data: parametros,
            type: 'post',
            success: function (response) {
                $("#horasCita").html(response);
            }
        });
    });

    $("#txtCorreo").change(function () {
        var parametros = {
            "correo": $('#txtCorreo').val()
        };
        $.ajax({
            url: '../../Controlador/existePersonaByCorreo.php',
            data: parametros,
            type: 'post',
            success: function (response) {
                $("#mensajeCorreo").html(response);
                $("#txtCorreo").focus();
            }
        });
    });



    //abrir ventana modal actualizar Aprendiz
    $("#actualizar").dialog({
        autoOpen: false,
        width: 600,
        heigth: 600
        /*buttons: [
            {
                text: "Ok",
                click: function() {
                    $( this ).dialog( "close" );
                }
            },
            {
                text: "Cancel",
                click: function() {
                    $( this ).dialog( "close" );
                }
            }
        ]*/

    });

    $("#editar").click(function (event) {
        $("#actualizar").dialog("open");
        event.preventDefault();
    });

});

function abrirVentanaEditar(idAprendiz) {
    $("#actualizar").dialog("open");
    document.getElementById("idAprendiz").value = idAprendiz;
    alert(document.getElementById("idAprendiz").value);
}

