@ModelType Katusoft.PracticaMVC.Web.Empleado
@Code
    ViewData("Title") = "Eliminar"
End Code

<h2>Eliminar Empleado</h2>

<h3>Está seguro que desea eliminar este empleado?</h3>
<div>
    <h4>Empleado</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Nombre)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Nombre)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Cargo)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Cargo)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Sueldo)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Sueldo)
        </dd>

    </dl>
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
            <input type="submit" value="Delete" class="btn btn-default" /> |
            @Html.ActionLink("Back to List", "ListarEmpleados", "Hola")
        </div>
    End Using
</div>
