Imports System.Data.Entity
Imports Npgsql

Public Class AppDbContext
    Inherits DbContext

    ' El nombre "MiConexionPostgres" debe ser IGUAL al 'name' que pusiste en el Web.config
    Public Sub New()
        MyBase.New("MiConexionPostgres")
    End Sub

    ' Aquí declaras tus tablas. Cada DbSet representa una tabla en PostgreSQL.
    Public Property Empleados As DbSet(Of Empleado)

    ' Este método es vital para PostgreSQL porque ayuda a mapear correctamente
    Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)
        ' Por defecto, Entity Framework busca esquemas de SQL Server ("dbo").
        ' En Postgres, el esquema por defecto es "public".
        modelBuilder.HasDefaultSchema("public")

        MyBase.OnModelCreating(modelBuilder)
    End Sub

End Class