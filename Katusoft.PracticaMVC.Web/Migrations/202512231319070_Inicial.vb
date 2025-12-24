Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class Inicial
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "public.Empleadoes",
                Function(c) New With
                    {
                        .Id = c.Int(nullable := False, identity := True),
                        .Nombre = c.String(),
                        .Cargo = c.String(),
                        .Sueldo = c.Decimal(nullable := False, precision := 18, scale := 2)
                    }) _
                .PrimaryKey(Function(t) t.Id)
            
        End Sub
        
        Public Overrides Sub Down()
            DropTable("public.Empleadoes")
        End Sub
    End Class
End Namespace
