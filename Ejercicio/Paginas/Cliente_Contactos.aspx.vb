Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Public Class Cliente_Contactos
    Inherits System.Web.UI.Page
    Public ds As DataSet

    Private Sub Cliente_Contactos_Init(sender As Object, e As EventArgs) Handles Me.Init
        cnn = New SqlConnection
        cnn.ConnectionString = "Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True"
        Dim sql As String = "select cl.Nombre_completo as Nombre_Cliente, cl.Direccion as Direccion_Cliente, cl.Telefono as Telefono_Cliente, cnt.Nombre_completo as Nombre_Contacto from Clientes cl, Contactos cnt where cl.id_cliente= cnt.id_cliente and cnt.id_cliente >1"
        Dim da As New SqlDataAdapter(sql, cnn)
        ds = New DataSet
        da.Fill(ds, "Clientes")

        GridView1.DataSource = ds
        GridView1.DataBind()
    End Sub


End Class