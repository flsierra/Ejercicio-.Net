Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Public Class Contactos_Carl
    Inherits System.Web.UI.Page
    Public ds As DataSet

    Private Sub Contactos_Carl_Init(sender As Object, e As EventArgs) Handles Me.Init
        cnn = New SqlConnection
        cnn.ConnectionString = "Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True"
        Dim sql As String = "select cl.id_cliente as Identificador_Cliente, cl.Nombre_completo as Nombre_Cliente,cnt.id_contacto as Identificador_Contacto, cnt.Nombre_completo as Nombre_Contacto from Clientes cl, Contactos cnt where cl.id_contacto = cnt.id_contacto and cnt.Nombre_completo like 'Carl%'"
        Dim da As New SqlDataAdapter(sql, cnn)
        ds = New DataSet
        da.Fill(ds, "Clientes")

        GridView1.DataSource = ds
        GridView1.DataBind()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

End Class