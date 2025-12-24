@Code
    ViewData("Title") = "Inicio"
End Code

<h2>@ViewBag.Mensaje</h2>
<p>Hoy es: @DateTime.Now.ToString("dd/MM/yyyy")</p>

<div class="alert alert-success">
    Esta es una estructura clásica de .NET Framewor 4.8
</div>

