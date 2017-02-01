Imports Modulo
Imports System.Xml
Imports System.Data
Partial Class Pruebas3
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub

    Protected Sub BtnDescarga_Click(sender As Object, e As EventArgs) Handles BtnDescargar.Click
        Try
            Dim DocNum As String = "320308"
            Dim DocDate As String = "17-01-18"
            Dim FolioPdf As String = "Primario_" & DocNum & "_" & DocDate & "_" & Session("RfcCliente") & ".pdf"

            'Limpiamos la salida
            Response.Clear()
            'Con esto le decimos al browser que la salida sera descargable
            Response.ContentType = "application/octet-stream"
            'esta linea es opcional, en donde podemos cambiar el nombre del fichero a descargar (para que sea diferente al original)
            Response.AddHeader("Content-Disposition", "attachment; filename=" & FolioPdf)
            ' Escribimos el fichero a enviar 
            'Response.WriteFile("~/PDF/" & FolioPdf)
            Response.WriteFile("C:/Forsedi/Archivos/PDF/" & FolioPdf)
            ' volcamos el stream 
            Response.Flush()
            'Enviamos todo el encabezado ahora
            Response.End()

        Catch ex As Exception
            Dim fail As String = ex.Message
            ClientScript.RegisterStartupScript(Me.[GetType](), "aleasrt", "alert('" & fail & "');  ", True)
        End Try
    End Sub
End Class
