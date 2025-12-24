Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class CorregirNombreTablaEmpleados
        Inherits DbMigration
    
        Public Overrides Sub Up()
            RenameTable(name := "public.Empleadoes", newName := "empleados")
        End Sub
        
        Public Overrides Sub Down()
            RenameTable(name := "public.empleados", newName := "Empleadoes")
        End Sub
    End Class
End Namespace
