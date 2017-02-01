Imports Modulo
Imports ConectaMod
Imports System.Xml
Imports System.Globalization
Imports System.Drawing
Imports System.IO
Imports System.Data
Partial Class HistFacturacion
    Inherits System.Web.UI.Page

    Dim totalSuma As Double = 0
    Dim sqldato As String
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        '//**Creacion 30/01/2017**//
        '//Update 31/01/2017
        If Not Page.IsPostBack Then
            Try
                Dim FecIni = ((DateTime.Now).AddYears(-1)).ToString("yyyy-MM-dd")
                Dim FecFin = DateTime.Now.ToString("yyyy-MM-dd")
                DtpFin.Value = FecFin
                DtpInicial.Value = FecIni
                'dato.Text = DtpInicial.Value
                RbRadios.SelectedIndex = 0
                Vista.Visible = False
                LlenarTabla()
            Catch ex As Exception
                ClientScript.RegisterStartupScript(Me.[GetType](), "aleasrt", "alert(' error " & ex.Message & "');  ", True)
            End Try
        End If
    End Sub

    Protected Sub RbRadios_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RbRadios.SelectedIndexChanged
        '//**Creacion 31/01/2017**//
        '//Update 31/01/2017
        If RbRadios.SelectedIndex = 0 Then
            Vista.Visible = False
        Else
            Vista.Visible = True
        End If
    End Sub

    Protected Sub BtnBuscar_Click(sender As Object, e As EventArgs) Handles BtnBuscar.ServerClick
        LlenarTabla()
    End Sub

    Protected Sub LlenarTabla()
        '//**Creacion 31/01/2017**//
        '//Update 31/01/2017
        Try
            Dim sql As String = Nothing
            '--Realizar busqueda XML
            Select Case RbRadios.SelectedItem.Value
                Case "RbFacVen"
                    sql = "SELECT T0.[DocDate], T1.[DueDate], T0.[DocNum],  T0.[DocCur], T1.[InsTotal], T1.[PaidToDate]  FROM NuevaBD.[dbo].[OINV] T0 INNER JOIN NuevaBD.[dbo].[INV6] T1 ON T0.[DocEntry] = T1.[DocEntry] LEFT OUTER JOIN NuevaBD.[dbo].[OCRD] T2 ON T0.[FatherCard] = T2.[CardCode] AND T0.[FatherType] = 'P' WHERE T0.[CardCode]  = '" & Session("RazCode") & "' " &
                        "and ((T0.[isIns] = 'N' AND T0.[DocStatus] = 'O') OR (T1.[Status] = 'O' AND T0.[CANCELED] = 'N'))"

                Case "RbFacVenxFec"
                    sql = "SELECT T0.[DocDate], T1.[DueDate], T0.[DocNum],  T0.[DocCur], T1.[InsTotal], T1.[PaidToDate]  FROM NuevaBD.[dbo].[OINV] T0 INNER JOIN NuevaBD.[dbo].[INV6] T1 ON T0.[DocEntry] = T1.[DocEntry] LEFT OUTER JOIN NuevaBD.[dbo].[OCRD] T2 ON T0.[FatherCard] = T2.[CardCode] AND T0.[FatherType] = 'P' WHERE T0.[CardCode]  = '" & Session("RazCode") & "' " &
                        "and ((T0.[isIns] = 'N' AND T0.[DocStatus] = 'O') OR (T1.[Status] = 'O' AND T0.[CANCELED] = 'N')) " &
                        "AND T0.[DocDate] &gt;= '" & DtpInicial.Value & "' " &
                        "AND T0.[DocDate] &lt;= '" & DtpFin.Value & "'"
                Case "RbFacFec"
                    sql = "SELECT T0.[DocDate], T1.[DueDate], T0.[DocNum],  T0.[DocCur], T1.[InsTotal], T1.[PaidToDate]   FROM NuevaBD.[dbo].[OINV] T0 INNER JOIN NuevaBD.[dbo].[INV6] T1 ON T0.[DocEntry] = T1.[DocEntry] LEFT OUTER JOIN NuevaBD.[dbo].[OCRD] T2 ON T0.[FatherCard] = T2.[CardCode] AND T0.[FatherType] = 'P' WHERE T0.[CardCode]  = '" & Session("RazCode") & "' " &
                    "AND T0.[DocDate] &gt;= '" & DtpInicial.Value & "' " &
                    "AND T0.[DocDate] &lt;= '" & DtpFin.Value & "'"
            End Select
            '---Definir tabla temporal para llenar gv
            Dim DataTable As New DataTable()
            DataTable.Columns.AddRange(New DataColumn() {New DataColumn("Fecha", GetType(String)),
                                                       New DataColumn("Vencimiento", GetType(String)),
                                                       New DataColumn("Folio", GetType(String)),
                                                       New DataColumn("Moneda", GetType(String)),
                                                       New DataColumn("Cargo", GetType(String)),
                                                       New DataColumn("Abono", GetType(String)),
                                                       New DataColumn("Saldo", GetType(String))})


            ws = New DIS.DIServer
            XmlDoc.LoadXml(ws.ExecuteSQL(Session("Token"), Sql).InnerXml)
            Node = XmlDoc.FirstChild.LastChild.Clone.ChildNodes

            Dim Folio As String = Nothing
            '---Recorrer Busqueda
            For Each Nodo As XmlNode In Node
                Folio = Nodo("DocNum").InnerText
                If Folio <> "0" Then
                    DataTable.Rows.Add(Mid(Nodo("DocDate").InnerText, 1, 4) + "/" + Mid(Nodo("DocDate").InnerText, 5, 2) + "/" + Mid(Nodo("DocDate").InnerText, 7, 2),
                                  Mid(Nodo("DueDate").InnerText, 1, 4) + "/" + Mid(Nodo("DueDate").InnerText, 5, 2) + "/" + Mid(Nodo("DueDate").InnerText, 7, 2),
                                   Folio,
                                   If(Nodo("DocCur").InnerText = "MXP", "Moneda Local", Nodo("DocCur").InnerText),
                                   String.Format("{0:c}", Convert.ToDouble(Nodo("InsTotal").InnerText)),
                                   String.Format("{0:c}", Convert.ToDouble(Nodo("PaidToDate").InnerText)),
                                    String.Format("{0:c}", (Convert.ToDouble(Nodo("InsTotal").InnerText) - Convert.ToDouble(Nodo("PaidToDate").InnerText))))
                End If
            Next

            GvFacturas.DataSource = DataTable
            GvFacturas.DataBind()

        Catch ex As Exception
            Dim fail As String = ex.Message
            ClientScript.RegisterStartupScript(Me.[GetType](), "aleasrt", "alert('" & fail & "');  ", True)
        End Try
    End Sub

    Protected Sub BtnDescarga_Click(sender As Object, e As EventArgs)
        Try
            Dim gvRow As GridViewRow = CType(CType(sender, Control).Parent.Parent,
                                        GridViewRow)
            Dim Filad As Integer = gvRow.RowIndex



            Dim DocNum As String = GvFacturas.Rows(Filad).Cells(2).Text
            Dim DocDate As String = Format(Convert.ToDateTime(GvFacturas.Rows(Filad).Cells(0).Text), "yy-MM-dd")
            Dim año As String = Format(Convert.ToDateTime(GvFacturas.Rows(Filad).Cells(0).Text), "yyyy")
            Dim mes As String = Format(Convert.ToDateTime(GvFacturas.Rows(Filad).Cells(0).Text), "MM")
            Dim FolioPdf As String = "Primario_" & DocNum & "_" & DocDate & "_" & Session("RfcCliente") & ".pdf"
            Dim Ruta As String = "C:/Forsedi/Archivos/PDF/" & año & "/" & mes & "/" & FolioPdf
            'Limpiamos la salida
            Response.Clear()
            'Con esto le decimos al browser que la salida sera descargable
            Response.ContentType = "application/octet-stream"
            'esta linea es opcional, en donde podemos cambiar el nombre del fichero a descargar (para que sea diferente al original)
            Response.AddHeader("Content-Disposition", "attachment; filename=" & FolioPdf)
            ' Escribimos el fichero a enviar 
            'Response.WriteFile("~/PDF/" & FolioPdf)
            Response.WriteFile(Ruta)
            ' volcamos el stream 
            Response.Flush()
            'Enviamos todo el encabezado ahora
            'Response.End()
            ClientScript.RegisterStartupScript(Me.[GetType](), "aleasrt", "alert('" & FolioPdf & "Descargando" & "');  ", True)
        Catch ex As Exception
            Dim fail As String = ex.Message
            ClientScript.RegisterStartupScript(Me.[GetType](), "aleasrt", "alert('" & fail & "');  ", True)
        End Try
    End Sub


End Class
