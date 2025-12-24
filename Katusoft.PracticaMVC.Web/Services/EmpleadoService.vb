Public Class EmpleadoService
    Implements IEmpleadoService
    Private db As New AppDbContext()

    Public Function GetAll() As List(Of EmpleadoDTO) Implements IEmpleadoService.GetAll
        Return db.Empleados.Select(Function(e) New EmpleadoDTO With {
                                       .Id = e.Id,
                                       .NombreCompleto = e.Nombre,
                                       .Cargo = e.Cargo,
                                       .Sueldo = e.Sueldo
    }).ToList()
    End Function

    Public Function GetPage(page As Integer, size As Integer) As List(Of EmpleadoDTO) Implements IEmpleadoService.GetPage
        Return db.Empleados _
            .OrderBy(Function(e) e.Id) _
            .Skip((page - 1) * 5) _
            .Take(5) _
            .Select(Function(e) New EmpleadoDTO With {
                                       .Id = e.Id,
                                       .NombreCompleto = e.Nombre,
                                       .Cargo = e.Cargo,
                                       .Sueldo = e.Sueldo}).ToList()
    End Function

    Public Function HasNextPage(page As Integer, size As Integer) As Boolean Implements IEmpleadoService.HasNextPage
        Dim total = db.Empleados.Count()
        Return (page * size) < total
    End Function

    Public Sub Guardar(dto As EmpleadoDTO)
        Dim entidad As New Empleado With {
            .Nombre = dto.NombreCompleto,
            .Cargo = dto.Cargo,
            .Sueldo = Decimal.Parse(dto.Sueldo)}
        db.Empleados.Add(entidad)

    End Sub
End Class
