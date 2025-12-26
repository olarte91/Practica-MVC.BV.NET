@ModelType Katusoft.PracticaMVC.Web.EmpleadoDTO

<div class="card">
    <div class="card-body">
        <p><strong>Nombre:</strong> @Model.NombreCompleto</p>
        <p><strong>Cargo:</strong> @Model.Cargo</p>
        <p><strong>Sueldo Base:</strong> @Model.Sueldo.ToString("C2")</p>
        <hr />
        <p class="text-info">Información procesada por el servidor.</p>
    </div>
</div>