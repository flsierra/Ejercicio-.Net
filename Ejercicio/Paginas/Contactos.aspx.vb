Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Public Class Contactos
    Inherits System.Web.UI.Page
    Public ds As DataSet

    Private Sub Contactos_Init(sender As Object, e As EventArgs) Handles Me.Init
        Try
            cnn = New SqlConnection
            cnn.ConnectionString = "Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True"
            Dim sql As String = "select * from Contactos order by Nombre_completo"
            Dim da As New SqlDataAdapter(sql, cnn)
            ds = New DataSet
            da.Fill(ds, "Contactos")
            id_contacto.Text = ds.Tables("Contactos").Rows(0).Item("id_contacto")
            nombre_comp.Text = ds.Tables("Contactos").Rows(0).Item("Nombre_completo")
            direccion.Text = ds.Tables("Contactos").Rows(0).Item("Direccion")
            telefono.Text = ds.Tables("Contactos").Rows(0).Item("Telefono")
            Call cargarcombo("select * from Clientes", DropDownList1, "id_cliente", "id_cliente")
            DropDownList1.SelectedValue = ds.Tables("Contactos").Rows(0).Item("id_cliente")
        Catch ex As Exception
            MsgBox("Error de conexión:" + ex.Message, MsgBoxStyle.Information, "Error")
        End Try
    End Sub



    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        contContactos = 0
        id_contacto.Text = ds.Tables("Contactos").Rows(contContactos).Item("id_contacto")
        nombre_comp.Text = ds.Tables("Contactos").Rows(contContactos).Item("Nombre_completo")
        direccion.Text = ds.Tables("Contactos").Rows(contContactos).Item("Direccion")
        telefono.Text = ds.Tables("Contactos").Rows(contContactos).Item("Telefono")
        DropDownList1.SelectedValue = ds.Tables("Contactos").Rows(contContactos).Item("id_cliente")
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        contContactos = contClientes - 1
        If contContactos < 0 Then
            contContactos = contContactos + 1
            id_contacto.Text = ds.Tables("Contactos").Rows(contContactos).Item("id_contacto")
            nombre_comp.Text = ds.Tables("Contactos").Rows(contContactos).Item("Nombre_completo")
            direccion.Text = ds.Tables("Contactos").Rows(contContactos).Item("Direccion")
            telefono.Text = ds.Tables("Contactos").Rows(contContactos).Item("Telefono")
            DropDownList1.SelectedValue = ds.Tables("Contactos").Rows(contContactos).Item("id_cliente")
        Else
            id_contacto.Text = ds.Tables("Contactos").Rows(contContactos).Item("id_contacto")
            nombre_comp.Text = ds.Tables("Contactos").Rows(contContactos).Item("Nombre_completo")
            direccion.Text = ds.Tables("Contactos").Rows(contContactos).Item("Direccion")
            telefono.Text = ds.Tables("Contactos").Rows(contContactos).Item("Telefono")
            DropDownList1.SelectedValue = ds.Tables("Contactos").Rows(contContactos).Item("id_cliente")
        End If

    End Sub

    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        contContactos = contContactos + 1
        If contContactos >= ds.Tables("Contactos").Rows.Count Then
            contContactos = ds.Tables("Contactos").Rows.Count
            contContactos = contContactos - 1
        End If
        id_contacto.Text = ds.Tables("Contactos").Rows(contContactos).Item("id_contacto")
        nombre_comp.Text = ds.Tables("Contactos").Rows(contContactos).Item("Nombre_completo")
        direccion.Text = ds.Tables("Contactos").Rows(contContactos).Item("Direccion")
        telefono.Text = ds.Tables("Contactos").Rows(contContactos).Item("Telefono")
        DropDownList1.SelectedValue = ds.Tables("Contactos").Rows(contContactos).Item("id_cliente")
    End Sub

    Protected Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        contContactos = ds.Tables("Contactos").Rows.Count
        contContactos = contContactos - 1
        id_contacto.Text = ds.Tables("Contactos").Rows(contContactos).Item("id_contacto")
        nombre_comp.Text = ds.Tables("Contactos").Rows(contContactos).Item("Nombre_completo")
        direccion.Text = ds.Tables("Contactos").Rows(contContactos).Item("Direccion")
        telefono.Text = ds.Tables("Contactos").Rows(contContactos).Item("Telefono")
        DropDownList1.SelectedValue = ds.Tables("Contactos").Rows(contContactos).Item("id_cliente")
    End Sub

    Protected Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        id_contacto.Text = ""
        nombre_comp.Text = ""
        direccion.Text = ""
        telefono.Text = ""

        Button5.Enabled = False
        Button7.Enabled = False
        Button8.Enabled = False
    End Sub

    Protected Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Call ejecutar("insert into Contactos (Nombre_completo,Direccion,Telefono,id_cliente) values('" & nombre_comp.Text & "', '" & direccion.Text & "','" & telefono.Text & "'," & DropDownList1.SelectedValue & ")")
        Button3.Enabled = False
        Button4.Enabled = False
        Button8.Enabled = False
        contContactos = 0
        Response.Redirect("Contactos.aspx")
    End Sub

    Protected Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Call ejecutar("update Contactos set Nombre_completo ='" & nombre_comp.Text & "'  where id_contacto= " & id_contacto.Text & " ")
        Call ejecutar("update Contactos set Direccion ='" & direccion.Text & "' where id_contacto= " & id_contacto.Text & " ")
        Call ejecutar("update Contactos set Telefono ='" & telefono.Text & "'  where id_contacto= " & id_contacto.Text & " ")
        Call ejecutar("update Contactos set id_cliente=" & DropDownList1.SelectedValue & " where id_contacto= " & id_contacto.Text & " ")
        contContactos = 0
        Response.Redirect("Contactos.aspx")
    End Sub

    Protected Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If MsgBox("¿Esta seguro de eliminar este registro ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
            Call ejecutar("delete from Contactos where id_contacto=" & id_contacto.Text & " ")
            contContactos = 0
            Response.Redirect("Contactos.aspx")
        Else
            Exit Sub
        End If
    End Sub
End Class