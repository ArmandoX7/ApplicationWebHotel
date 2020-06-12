// JavaScript Document
// César M. Cuéllar

/*Se carga el modulo que se va a utilizar en este caso visualization,
seguido de la versión y el paquete que es corechart para la grafica*/
google.load("visualization", "1", { packages: ["corechart"] });

/* En esta linea se indica que se va a llamar a la función dibujarGrafico
una vez que el documento se haya terminado de cargar*/
google.setOnLoadCallback(dibujarGrafica);

/* Código que obtiene los datos del servidor, para lo cual haremos una 
 * petición ajax que devolverá un JSON con la información a graficar 
 * que se se almacenará en la variable datos*/

function dibujarGrafica() {
    var datos = $.ajax({       
        url: '../SolicitudAjax.aspx/obtenerCantidadHabitacionesPorTipo',
        dataType: "json",
        type: 'post',
        async: false,
        contentType: "application/json; charset=utf-8",
    }).responseText;
  
    
    /* La grafica se necesita que la informaicon sea un objeto JSON entonces 
     lo convertimos con la funcion JSON.parse() */
  
    datos = JSON.parse(datos);
    alert(datos.d);
    var jsonData = datos.d;
  
    /* La informacion que se obtuvo del servidor se convierte a un dataTable
       para que se muestre en el grafico */

    var data = google.visualization.arrayToDataTable(jsonData);
   
    
    /* Se definen algunas opciones para el gráfico*/
    var options = {
        //title2: '¿Cuándo el profesor recurre al uso de textos multimodales virtuales en el aula de clase  propone actividades que permiten alcanzar  niveles únicamente  informativos? ',
        hAxis: {title: 'Médicos', titleTextStyle: {color: 'red'}},
        vAxis: {title: 'Cantidad', titleTextStyle: {color: 'blue'}},
        // backgroundColor:'#ffffff',
        //legend:{position: 'bottom', textStyle: {color: 'blue', fontSize: 13}},
        title: '¿El tipo de texto que permite  desarrollar un mayor nivel de concentración en  la lectura es?',
       // is3D: true
        //colors:['ffcc00','fffccc','cccccc']               
    };
    /* se crea un objeto de la clase google.visualization.ColumnChart  
     * ( Grafica de columna )     en el cual se indica cual es el elemento 
     * HTML que contendrá a la gráfica .El grafico se crea en el div con id='chart_div'*/

    var grafica = new google.visualization.ColumnChart(document.getElementById('chart_div'));
    /* Se llama al método draw para dibujar la gráfica*/
    grafica.draw(data, options);
}

