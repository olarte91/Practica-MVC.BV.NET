Imports System.Web.Mvc
Imports System.Data.Entity

Namespace Controllers
    Public Class HolaController
        Inherits Controller

        Private db As New AppDbContext()
        Private ReadOnly _service As IEmpleadoService

        Public Sub New()
            _service = New EmpleadoService()
        End Sub


        ' GET: Hola
        Function Index() As ActionResult
            ViewBag.Mensaje = "¡Bienvenido a mi primier proyecto en VB.NET MVC! estoy contento!"
            Return View()
        End Function

        Function ListarEmpleados(Optional page As Integer = 1) As ActionResult
            Dim pageSize = 5

            ViewBag.ActualPage = page
            ViewBag.HasNextPage = _service.HasNextPage(page, pageSize)

            Dim employees = _service.GetPage(page, pageSize)

            Return View(employees)
        End Function

        Protected Overrides Sub Dispose(disposing As Boolean)
            If disposing Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Muestra el formulario para crear un nuevo empleado
        Function Crear() As ActionResult
            Return View()
        End Function

        <HttpPost>
        <ValidateAntiForgeryToken>
        Function Crear(ByVal empleado As Empleado) As ActionResult
            If ModelState.IsValid Then
                db.Empleados.Add(empleado) 'Lo prepara para insertar en la bd
                db.SaveChanges() 'Lo guarda en postgres
                Return RedirectToAction("ListarEmpleados")
            End If
            Return View(empleado)
        End Function

        'Verificar la existencia de los datos en la base de datos
        Function Editar(ByVal id As Integer) As ActionResult
            Dim empleado = db.Empleados.Find(id)
            If IsNothing(empleado) Then Return HttpNotFound()
            Return View(empleado)
        End Function

        'Recibe datos modificados y guarda en la base de datos
        <HttpPost>
        <ValidateAntiForgeryToken>
        Function Editar(ByVal empleado As Empleado) As ActionResult
            If ModelState.IsValid Then
                db.Entry(empleado).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("ListarEmpleados")
            End If
            Return View(empleado)
        End Function

        'Mostrar la pantalla de confirmación de eliminación
        Function Eliminar(ByVal id As Integer) As ActionResult
            Dim empleado = db.Empleados.Find(id)
            If IsNothing(empleado) Then Return HttpNotFound()
            Return View(empleado)
        End Function

        'Ejecutar el borrado final
        <HttpPost, ActionName("Eliminar")>
        <ValidateAntiForgeryToken>
        Function ConfirmarEliminar(ByVal id As Integer) As ActionResult
            Dim empleado = db.Empleados.Find(id)
            db.Empleados.Remove(empleado)
            db.SaveChanges()
            Return RedirectToAction("ListarEmpleados")
        End Function

        'Verificar si el empleado gana mas de 3 M
        <HttpGet>
        Function SueldoMayorA3(ByVal id As Integer) As JsonResult
            Dim resultado = _service.SueldoMayorA3(id)
            Return Json(New With {.esMayor = resultado}, JsonRequestBehavior.AllowGet)
        End Function

        Function VerDetalles(ByVal id As Integer) As ActionResult
            Dim empleado = _service.ObtenerPorId(id) ' Tu lógica para buscarlo

            ' Devolvemos una Vista Parcial pasándole el modelo
            Return PartialView("_DetallesEmpleado", empleado)
        End Function
    End Class
End Namespace