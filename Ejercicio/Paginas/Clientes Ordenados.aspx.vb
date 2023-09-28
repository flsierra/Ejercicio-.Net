Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Public Class Clientes_Ordenados
    Inherits System.Web.UI.Page
    Public ds As DataSet

    Private Sub Clientes_Ordenados_Init(sender As Object, e As EventArgs) Handles Me.Init
        cnn = New SqlConnection
        cnn.ConnectionString = "Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True"
        Dim sql As String = "select * from Clientes order by Fecha_creacion"
        Dim da As New SqlDataAdapter(sql, cnn)
        ds = New DataSet
        da.Fill(ds, "Clientes")

        GridView1.DataSource = ds
        GridView1.DataBind()
    End Sub


    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged

    End Sub
End Class