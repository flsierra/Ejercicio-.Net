Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Public Class Clientes
    Inherits System.Web.UI.Page
    Public ds As DataSet

    Private Sub Clientes_Init(sender As Object, e As EventArgs) Handles Me.Init
        Try
            cnn = New SqlConnection
            cnn.ConnectionString = "Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True"
            Dim sql As String = "select * from Clientes order by Nombre_completo"
            Dim da As New SqlDataAdapter(sql, cnn)
            ds = New DataSet
            da.Fill(ds, "Clientes")
            id_cliente.Text = ds.Tables("Clientes").Rows(0).Item("id_cliente")
            nombre_comp.Text = ds.Tables("Clientes").Rows(0).Item("Nombre_completo")
            direccion.Text = ds.Tables("Clientes").Rows(0).Item("Direccion")
            telefono.Text = ds.Tables("Clientes").Rows(0).Item("Telefono")
            Call cargarcombo("select * from Contactos", DropDownList1, "id_contacto", "nombre_completo")
            Calendar1.SelectedDate = ds.Tables("Clientes").Rows(0).Item("Fecha_creacion")
            Calendar1.VisibleDate = ds.Tables("Clientes").Rows(0).Item("Fecha_creacion")
            DropDownList1.SelectedValue = ds.Tables("Clientes").Rows(0).Item("id_contacto")
        Catch ex As Exception
            MsgBox("Error de conexión:" + ex.Message, MsgBoxStyle.Information, "Error")
        End Try
    End Sub



    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        contClientes = 0
        id_cliente.Text = ds.Tables("Clientes").Rows(contClientes).Item("id_cliente")
        nombre_comp.Text = ds.Tables("Clientes").Rows(contClientes).Item("Nombre_completo")
        direccion.Text = ds.Tables("Clientes").Rows(contClientes).Item("Direccion")
        telefono.Text = ds.Tables("Clientes").Rows(contClientes).Item("Telefono")
        Calendar1.SelectedDate = ds.Tables("Clientes").Rows(contClientes).Item("Fecha_creacion")
        Calendar1.VisibleDate = ds.Tables("Clientes").Rows(contClientes).Item("Fecha_creacion")
        DropDownList1.SelectedValue = ds.Tables("Clientes").Rows(contClientes).Item("id_contacto")
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        contClientes = contClientes - 1
        If contClientes < 0 Then
            contClientes = contClientes + 1
            id_cliente.Text = ds.Tables("Clientes").Rows(contClientes).Item("id_cliente")
            nombre_comp.Text = ds.Tables("Clientes").Rows(contClientes).Item("Nombre_completo")
            direccion.Text = ds.Tables("Clientes").Rows(contClientes).Item("Direccion")
            telefono.Text = ds.Tables("Clientes").Rows(contClientes).Item("Telefono")
            Calendar1.SelectedDate = ds.Tables("Clientes").Rows(contClientes).Item("Fecha_creacion")
            Calendar1.VisibleDate = ds.Tables("Clientes").Rows(contClientes).Item("Fecha_creacion")
            DropDownList1.SelectedValue = ds.Tables("Clientes").Rows(contClientes).Item("id_contacto")
        Else
            id_cliente.Text = ds.Tables("Clientes").Rows(contClientes).Item("id_cliente")
            nombre_comp.Text = ds.Tables("Clientes").Rows(contClientes).Item("Nombre_completo")
            direccion.Text = ds.Tables("Clientes").Rows(contClientes).Item("Direccion")
            telefono.Text = ds.Tables("Clientes").Rows(contClientes).Item("Telefono")
            Calendar1.SelectedDate = ds.Tables("Clientes").Rows(contClientes).Item("Fecha_creacion")
            Calendar1.VisibleDate = ds.Tables("Clientes").Rows(contClientes).Item("Fecha_creacion")
            DropDownList1.SelectedValue = ds.Tables("Clientes").Rows(contClientes).Item("id_contacto")
        End If

    End Sub

    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        contClientes = contClientes + 1
        If contClientes >= ds.Tables("Clientes").Rows.Count Then
            contClientes = ds.Tables("Clientes").Rows.Count
            contClientes = contClientes - 1
        End If
        id_cliente.Text = ds.Tables("Clientes").Rows(contClientes).Item("id_cliente")
        nombre_comp.Text = ds.Tables("Clientes").Rows(contClientes).Item("Nombre_completo")
        direccion.Text = ds.Tables("Clientes").Rows(contClientes).Item("Direccion")
        telefono.Text = ds.Tables("Clientes").Rows(contClientes).Item("Telefono")
        Calendar1.SelectedDate = ds.Tables("Clientes").Rows(contClientes).Item("Fecha_creacion")
        Calendar1.VisibleDate = ds.Tables("Clientes").Rows(contClientes).Item("Fecha_creacion")
        DropDownList1.SelectedValue = ds.Tables("Clientes").Rows(contClientes).Item("id_contacto")
    End Sub

    Protected Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        contClientes = ds.Tables("Clientes").Rows.Count
        contClientes = contClientes - 1
        id_cliente.Text = ds.Tables("Clientes").Rows(contClientes).Item("id_cliente")
        nombre_comp.Text = ds.Tables("Clientes").Rows(contClientes).Item("Nombre_completo")
        direccion.Text = ds.Tables("Clientes").Rows(contClientes).Item("Direccion")
        telefono.Text = ds.Tables("Clientes").Rows(contClientes).Item("Telefono")
        Calendar1.SelectedDate = ds.Tables("Clientes").Rows(contClientes).Item("Fecha_creacion")
        Calendar1.VisibleDate = ds.Tables("Clientes").Rows(contClientes).Item("Fecha_creacion")
        DropDownList1.SelectedValue = ds.Tables("Clientes").Rows(contClientes).Item("id_contacto")
    End Sub

    Protected Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        id_cliente.Text = ""
        nombre_comp.Text = ""
        direccion.Text = ""
        telefono.Text = ""

        Button5.Enabled = False
        Button7.Enabled = False
        Button8.Enabled = False
    End Sub

    Protected Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Call ejecutar("insert into Clientes (Nombre_completo,Direccion,Telefono,Fecha_creacion,id_contacto) values('" & nombre_comp.Text & "', '" & direccion.Text & "','" & telefono.Text & "','" & Calendar1.SelectedDate & "'," & DropDownList1.SelectedValue & ")")
        Button3.Enabled = False
        Button4.Enabled = False
        Button8.Enabled = False
        contClientes = 0
        Response.Redirect("Clientes.aspx")
    End Sub

    Protected Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Call ejecutar("update Clientes set Nombre_completo ='" & nombre_comp.Text & "'  where id_cliente= " & id_cliente.Text & " ")
        Call ejecutar("update Clientes set Direccion ='" & direccion.Text & "'  where id_cliente= " & id_cliente.Text & " ")
        Call ejecutar("update Clientes set Telefono ='" & telefono.Text & "'  where id_cliente= " & id_cliente.Text & " ")
        Call ejecutar("update Clientes set Fecha_creacion='" & Calendar1.SelectedDate & "',id_contacto=" & DropDownList1.SelectedValue & " where id_cliente= " & id_cliente.Text & " ")
        contClientes = 0
        Response.Redirect("Clientes.aspx")
    End Sub

    Protected Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If MsgBox("¿Esta seguro de eliminar este registro ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
            Call ejecutar("delete from Clientes where id_cliente=" & id_cliente.Text & " ")
            contClientes = 0
            Response.Redirect("Clientes.aspx")
        Else
            Exit Sub
        End If
    End Sub
End Class