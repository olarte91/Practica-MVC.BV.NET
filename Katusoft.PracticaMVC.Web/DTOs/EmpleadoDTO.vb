Public Class EmpleadoDTO
    Public Property Id As Integer
    Public Property NombreCompleto As String
    Public Property Cargo As String
    Public Property Sueldo As Decimal

    Public Function CalcularDescuento() As Decimal
        Return Sueldo * 0.05
    End Function

    Public Function SueldoTotal() As Decimal
        Return Sueldo - CalcularDescuento()
    End Function

End Class
