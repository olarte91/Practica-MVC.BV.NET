$(document).ready(function () {

    botonesDeDetalle();
    resaltarSueldosDeMasDe3M();
 
});

function resaltarSueldosDeMasDe3M() {
    $(".sueldo-total").each(function () {
        var celda = $(this);
        var empleadoId = celda.data("aidi");

        $.ajax({
            url: '/Hola/SueldoMayorA3',
            type: 'GET',
            data: { id: empleadoId },
            success: function (response) {
                if (response.esMayor) {
                    celda.closest("tr").css("background-color", "#fffccc");
                }
            }
        });
    });
    
}

function botonesDeDetalle() {
    // Usamos delegación de eventos por si la tabla cambia
    $(document).on("click", ".btn-detalles", function (e) {
        e.preventDefault(); // Evita que el enlace recargue la página

        var id = $(this).data("id"); // Obtenemos el ID del empleado

        // Abrimos el modal (vacío por ahora)
        $("#modalDetalles").modal("show");
        $("#contenidoModal").html("<p>Cargando información...</p>");

        // Llamada AJAX para traer la Vista Parcial
        $.ajax({
            url: '/Hola/VerDetalles',
            type: 'GET',
            data: { id: id },
            success: function (htmlRecibido) {
                // Inyectamos el HTML que nos mandó el servidor dentro del modal
                $("#contenidoModal").html(htmlRecibido);
            },
            error: function () {
                $("#contenidoModal").html("<p class='text-danger'>Error al cargar los datos.</p>");
            }
        });
    });
}