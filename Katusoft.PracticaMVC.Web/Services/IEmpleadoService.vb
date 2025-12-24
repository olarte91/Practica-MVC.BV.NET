Public Interface IEmpleadoService
    Function GetAll() As List(Of EmpleadoDTO)
    Function GetPage(page As Integer, size As Integer) As List(Of EmpleadoDTO)
    Function HasNextPage(page As Integer, size As Integer) As Boolean
End Interface
