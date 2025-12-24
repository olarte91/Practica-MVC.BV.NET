Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

<Table("empleados")> ' Aquí fuerzas el nombre que tú quieras
Public Class Empleado
    <Key>
    Public Property Id As Integer
    Public Property Nombre As String
    Public Property Cargo As String
    Public Property Sueldo As Decimal

End Class
