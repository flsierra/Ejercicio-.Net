Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Public Module Module1
    Public contClientes As Integer
    Public contContactos As Integer
    Public cnn As SqlConnection
    Public Function ejecutar(ByVal consulta As String)
        Try
            If cnn.State = ConnectionState.Open Then
                Dim cmd As SqlCommand
                cmd = New SqlCommand
                cmd.Connection = cnn
                cmd.CommandText = consulta
                cmd.ExecuteNonQuery()
                cnn.Close()
                MsgBox("Registro actualizado", MsgBoxStyle.Information, "Información")
            Else
                cnn.Open()
                Dim cmd As SqlCommand
                cmd = New SqlCommand
                cmd.Connection = cnn
                cmd.CommandText = consulta
                cmd.ExecuteNonQuery()
                cnn.Close()
                MsgBox("Registro actualizado", MsgBoxStyle.Information, "Información")
            End If
        Catch ex As Exception
            MsgBox("Error", MsgBoxStyle.Exclamation, "Error")
        End Try
    End Function

    Public Sub cargarcombo(ByVal sentenciasql As String, ByVal comb As DropDownList, ByVal value As String, ByVal display As String)
        Dim datatab As New DataTable
        Dim dataada As New SqlDataAdapter(sentenciasql, cnn)
        dataada.SelectCommand.Connection = cnn
        dataada.SelectCommand.CommandText = sentenciasql
        dataada.Fill(datatab)
        If datatab.Rows.Count >= 0 Then
            comb.DataSource = datatab
            comb.DataValueField = datatab.Columns(value).ToString
            comb.DataTextField = datatab.Columns(display).ToString
            comb.DataBind()

        End If
    End Sub
End Module

