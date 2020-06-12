//Código
$(function () {
    $("#ContentPlaceHolderContenido_txtIdentificacion").change(function () {

        //valores de parametros a enviar
        var identificacion = $('#ContentPlaceHolderContenido_txtIdentificacion').val();
        
        //llamado mediante ajax
        $.ajax({
            url: '../SolicitudAjax.aspx/obtenerClientePorIdentificacion',
            data: '{identificacion: ' + identificacion + '}',
            dataType: 'json',
            type: 'post',
            contentType: "application/json; charset=utf-8",
            success: function (resultado) {               
                if (resultado.d != null) {
                    $("#ContentPlaceHolderContenido_txtNombre").val(resultado.d.Nombre);
                    $("#ContentPlaceHolderContenido_txtCorreo").val(resultado.d.Correo);
                    $("#ContentPlaceHolderContenido_txtIdCliente").val(resultado.d.IdCliente);
                    $('#mensaje').html('');
                } else {
                    $("#ContentPlaceHolderContenido_txtNombre").val('');
                    $("#ContentPlaceHolderContenido_txtCorreo").val('');
                    $('#mensaje').html('No existe Cliente con el número de documento de identidad');
                }                
            },
            error: function (resultado) {
                alert("ERROR " + resultado.status + ' ' + resultado.statusText);
            }
        });   
    });  
    
    $("#ContentPlaceHolderContenido_txtNHabita").change(function () {

        var numero = parseInt($('#ContentPlaceHolderContenido_txtNHabita').val());
        if (numero > 0) {
            $.ajax({
                url: '../SolicitudAjax.aspx/obtenerHabitacionPorNumero',
                data: '{numero: ' + numero + '}',
                dataType: 'json',
                type: 'post',
                contentType: "application/json; charset=utf-8",
                success: function (resultado) {
                    console.log(resultado);
                    if (resultado.d != null) {
                        $("#ContentPlaceHolderContenido_txtDHabita").val(resultado.d.Descripcion);
                        $('#mensaje').html('');
                    } else {
                        $("#ContentPlaceHolderContenido_txtDHabita").val('');
                        $('#mensaje').html('No existe Habitación con ese Número');
                    }
                },
                error: function (resultado) {
                    alert("ERROR " + resultado.status + ' ' + resultado.statusText);
                }
            });
        } else {
            $('#mensaje').html('Debe ingresar número');
            $("#ContentPlaceHolderContenido_txtDHabita").val('');
        }


    });

    $("[id*=btnExport]").click(function () {
        $("[id*=grillaOculta]").val($("[id*=tablaAlquiladas]").html());
    });

    var dateFormat = "dd-mm-yy",
      from = $("#ContentPlaceHolderContenido_txtFechaInicial")
        .datepicker({
            defaultDate: "+1w",
            changeMonth: true,
            numberOfMonths: 1,
            dateFormat:"dd-mm-yy",
        })
        .on("change", function () {
            to.datepicker("option", "minDate", getDate(this));
        }),
      to = $("#ContentPlaceHolderContenido_txtFechaFinal").datepicker({
          defaultDate: "+1w",
          changeMonth: true,
          numberOfMonths: 1,
          dateFormat: "dd-mm-yy",
      })
      .on("change", function () {
          from.datepicker("option", "maxDate", getDate(this));
      });

    function getDate(element) {
        var date;
        try {
            date = $.datepicker.parseDate(dateFormat, element.value);
        } catch (error) {
            date = null;
        }

        return date;
    }


});




   /* $("#cbTipo").change(function () {
        $("#cbHabitacion").html("");
        //valores de parametrosa enviar
        var tipo = $('#cbTipo').val();
        var piso = $('#cbPiso').val();
        $.ajax({
            url: 'SolicitudesAjax.aspx/obtenerHabitacionesDisponibles',
            data: '{tipo: ' + tipo + ', piso: ' + piso + '}',
            dataType: 'json',
            type: 'post',
            contentType: "application/json; charset=utf-8",
            success: function (resultado) {
                console.log(resultado.d);                
                var habita = resultado.d;                 
                 $.each(habita, function (index, item) {
                     $("#cbHabitacion").append("<option value=" + item.idHabitacion + ">" + item.Numero + " </option>");
                 });
                 $("#txtIdHabitacion").val($("#cbHabitacion").val());
            },
            error: function (result) {
                alert("ERROR " + result.status + ' ' + result.statusText);
            }

        });
        
    });*/   
