@ModelType IEnumerable(Of Katusoft.PracticaMVC.Web.EmpleadoDTO)

@Code
    ViewData("Title") = "Lista de empleados"
End Code

<h2>Nómina de empleados</h2>

@Html.ActionLink("Crear nuevo empleado", "Crear", "Hola", Nothing, New With {.class = "btn btn-success"})

<table class="table">
    <thead>
        <tr>
            <th>Nombre</th>
            <th>Cargo</th>
            <th>Sueldo Bruto</th>
            <th>Descuentos</th>
            <th>Total</th>
        </tr>
    </thead>
    <tbody>
        @For Each item In Model
            @<tr>
        <td>@item.NombreCompleto</td>
        <td>@item.Cargo</td>
        <td>@item.Sueldo.ToString("C2")</td>
        <td>@item.CalcularDescuento().ToString("C2")</td>
        <td>@item.SueldoTotal().ToString("C2")</td>
        <td>
            @Html.ActionLink("Editar", "Editar", New With {.id = item.Id}, New With {.class = "btn btn-info btn-sm"}) | 
            @Html.ActionLink("Eliminar", "Eliminar", New With {.id = item.Id}, New With {.class = "btn btn-danger btn-sm"})
        </td>
        </tr>
        Next
    </tbody>
</table>
<div class="mt-3">
    @If ViewBag.ActualPage > 1 Then
        @Html.ActionLink("« Anterior", "ListarEmpleados", New With {.page = ViewBag.ActualPage - 1}, New With {.class = "btn btn-primary"})
    End If

    <span class="mx-3 text-primary">Página @ViewBag.ActualPage</span>

   @If ViewBag.HasNextPage Then
       @Html.ActionLink("Siguiente >>", "ListarEmpleados", New With {.page = ViewBag.ActualPage + 1}, New With {.class = "btn btn-primary"})
   End If
                </div>