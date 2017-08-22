﻿Imports System.Data.SqlClient

Public Class fcliente
    Inherits conexion
    Dim cmd As New SqlCommand

    Public Function mostrar() As DataTable
        Try
            conectado()
            cmd = New SqlCommand("mostrar_clientes")
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Connection = cn

            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Return dt
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            desconectado()
        End Try
    End Function

    Public Function ingresar(ByVal dts As vcliente) As Boolean
        'Try
        conectado()
            cmd = New SqlCommand("ingresar_cliente")
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Connection = cn

            cmd.Parameters.AddWithValue("@nombre", dts.gnombre)
            cmd.Parameters.AddWithValue("@apellido", dts.gapellido)
            cmd.Parameters.AddWithValue("@direccion", dts.gdireccion)
            cmd.Parameters.AddWithValue("@telefono", dts.gtelefono)
            cmd.Parameters.AddWithValue("@email", dts.gemail)
        cmd.Parameters.AddWithValue("@fechanacimiento", dts.gfechanacimiento)
        cmd.Parameters.AddWithValue("@cedula", dts.gcedula)

            If cmd.ExecuteNonQuery Then
                Return True
            Else
                Return False
            End If

        'Catch ex As Exception
        'MsgBox(ex.Message)
        'Return False
        'Finally
        desconectado()
        'End Try
    End Function
End Class
