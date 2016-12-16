Imports System.Xml
Imports System.Diagnostics.Debug
Imports Modulo
Imports System.Web.Configuration
Imports System.Data
Imports ConectaClass


Partial Class Login
    Inherits System.Web.UI.Page
    Public ws As DIS.DIServer

    Protected Sub monedas()
        Respuesta = ws.ExecuteSQL(Session("Token"), "Select  MainCurncy ,SysCurrncy  from OADM")
        Session("ML") = ReadXML(Respuesta.InnerXml, "MainCurncy")
        Session("MS") = ReadXML(Respuesta.InnerXml, "SysCurrncy")
    End Sub
    Dim dt As New DataTable
    Dim dr As DataRow
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        ' Dim pol As String = getItemPriceDiscountByPolo("ss", "dd", Session("Token")) 
    End Sub

    Dim Respuesta As XmlNode
    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click

        Try
            Session("Imagen") = ""
            Session("dbserver") = System.Web.Configuration.WebConfigurationManager.AppSettings("dbserver")
            Session("dbname") = System.Web.Configuration.WebConfigurationManager.AppSettings("dbname")
            Session("dbtype") = System.Web.Configuration.WebConfigurationManager.AppSettings("dbtype")
            Session("dbusername") = System.Web.Configuration.WebConfigurationManager.AppSettings("dbusername")
            Session("dbuserpass") = System.Web.Configuration.WebConfigurationManager.AppSettings("dbuserpass")
            Session("dbcompanyuser") = System.Web.Configuration.WebConfigurationManager.AppSettings("dbcompanyuser")
            Session("dbcompanypass") = System.Web.Configuration.WebConfigurationManager.AppSettings("dbcompanypass")
            Session("lenguaje") = System.Web.Configuration.WebConfigurationManager.AppSettings("lenguaje")
            Session("licenseserver") = System.Web.Configuration.WebConfigurationManager.AppSettings("licenseserver")
            Session("license") = System.Web.Configuration.WebConfigurationManager.AppSettings("license")
            Session("ftp") = System.Web.Configuration.WebConfigurationManager.AppSettings("ftp")
            Session("pagIni") = 1
            Session("busqueda") = ""
            Session("resetDESC") = False
            System.Diagnostics.Debug.Write(Session("Imagen") & vbCrLf)

            ws = New DIS.DIServer
            ws.Url = Serveriii
            Dim resultlogin As String
            resultlogin = ws.Token(Session("dbserver"), Session("dbname"), Session("dbtype"), Session("dbusername"), Session("dbuserpass"), Session("dbcompanyuser"), Session("dbcompanypass"), Session("lenguaje"), Session("licenseserver"), Session("license"))
            resultlogin = ws.LoginSSL(resultlogin)
            If ws.Validate(resultlogin) Then
                Session("Token") = resultlogin
                System.Diagnostics.Debug.Write(resultlogin & vbCrLf)
            Else
                MsgBox("Error de conexion: " + resultlogin, MsgBoxStyle.Information, "Admin")
            End If

            monedas()


        Catch ex As Exception
            System.Diagnostics.Debug.Write("checar los permisos" & vbCrLf)
            Session.Clear()
            Session.Abandon()
            ClientScript.RegisterStartupScript(Me.[GetType](), "aleasrt", "alert('Error de configuracion, contacte al administrador');document.location.href='Login';", True)
        End Try

        Alertamail.Style("display") = "none"
        If IsNumeric(usu.Text) Then

            Try


                Dim sqldato As String = "select *   from [Ecom].[dbo].[color]  "
                Respuesta = ws.ExecuteSQL(Session("Token"), sqldato)
                Session("colorTop") = ReadXML(Respuesta.InnerXml, "barratop")
                Session("colorInfo") = ReadXML(Respuesta.InnerXml, "infousu")
                Session("colorMenu") = ReadXML(Respuesta.InnerXml, "menu")
                Session("colorContenido") = ReadXML(Respuesta.InnerXml, "contenido")
                Session("logo") = ReadXML(Respuesta.InnerXml, "img")

                'sqldato = "select top 1 U_arttype as tipo,U_artcan as cantidad,tipodoc from [Ecom].[dbo].[@IL_CONFIG_E]   "
                'Respuesta = ws.ExecuteSQL(Session("Token"), sqldato)
                'Session("configarttype") = ReadXML(Respuesta.InnerXml, "tipo")
                'Session("configartcan") = ReadXML(Respuesta.InnerXml, "cantidad")
                'Session("tipodocventas") = ReadXML(Respuesta.InnerXml, "tipodoc")

                sqldato = "select top 1 U_arttype as tipo,U_artcan as cantidad ,rutaxml,rutapdf,tipodoc,[smtp],[puerto],[username], [acount],[password],[ssl] from [Ecom].[dbo].[@IL_CONFIG_E]   "
                Respuesta = ws.ExecuteSQL(Session("Token"), sqldato)
                Session("configarttype") = ReadXML(Respuesta.InnerXml, "tipo")
                Session("configartcan") = ReadXML(Respuesta.InnerXml, "cantidad")
                Session("rutapdf") = ReadXML(Respuesta.InnerXml, "rutaxml")
                Session("rutaxml") = ReadXML(Respuesta.InnerXml, "rutapdf")
                Session("tipodocventas") = ReadXML(Respuesta.InnerXml, "tipodoc")


                Session("smtp") = ReadXML(Respuesta.InnerXml, "smtp")
                Session("puerto") = ReadXML(Respuesta.InnerXml, "puerto")
                Session("username") = ReadXML(Respuesta.InnerXml, "username")
                Session("acount") = ReadXML(Respuesta.InnerXml, "acount")
                Session("password") = ReadXML(Respuesta.InnerXml, "password")
                Session("ssl") = ReadXML(Respuesta.InnerXml, "ssl")

            Catch ex As Exception

            End Try

            'Dim Respuesta As XmlNode

            Respuesta = ws.ExecuteSQL(Session("Token"), "Select top 1 * from OSLP where SlpCode='" & usu.Text & "' AND U_IL_pass='" & pass.Text & "'")

            '<BO xmlns="http://www.sap.com/SBO/DIS"><AdmInfo><Object>oRecordset</Object></AdmInfo><OSLP><row><SlpCode>66</SlpCode><SlpName>LEOPOLDO DE LA TORRE GARCIA</SlpName><Memo>ventas</Memo><Commission>0.000000</Commission><GroupCode>0</GroupCode><Locked>N</Locked><DataSource>I</DataSource><UserSign>1</UserSign><EmpID>0</EmpID><Active>Y</Active><U_BOY_50_BRKO /><U_NumEmpl>0</U_NumEmpl><U_IL_Sucursal>Chapala</U_IL_Sucursal><U_IL_Vendedor>Si</U_IL_Vendedor><U_IL_Porcentaje>10.000000</U_IL_Porcentaje><U_U_IL_OLK /><U_IL_Jefe /><U_IL_Subjefe /><U_IL_Comision>0.000000</U_IL_Comision><U_IL_Supervisor /><U_IL_ETrabajo /><U_IL_nUsuario>polo</U_IL_nUsuario><U_IL_pass>1234</U_IL_pass></row></OSLP></BO>'iisexpress.exe' (CLR v4.0.30319: /LM/W3SVC/6/ROOT-1-130936596895666238): Loaded 'C:\Windows\assembly\GAC_MSIL\Microsoft.VisualStudio.Debugger.Runtime\12.0.0.0__b03f5f7f11d50a3a\Microsoft.VisualStudio.Debugger.Runtime.dll'. 

            Dim doc As New XmlDocument()
            doc.LoadXml(Respuesta.InnerXml)
            System.Diagnostics.Debug.Write(Respuesta.InnerXml & vbCrLf)
            Dim root As XmlNode = doc.FirstChild

            root = root.LastChild
            root = root.FirstChild

            'Display the contents of the child nodes.
            Dim bandera As Boolean = True

            If root.HasChildNodes Then
                Dim i As Integer
                For i = 0 To root.ChildNodes.Count - 1
                    Select Case root.ChildNodes(i).Name
                        Case "SlpCode"
                            If root.ChildNodes(i).InnerText = "0" Then
                                System.Diagnostics.Debug.Write("nada de nada" & vbCrLf)
                                i = root.ChildNodes.Count - 1
                                bandera = False
                            Else
                                System.Diagnostics.Debug.Write(root.ChildNodes(i).InnerText & vbCrLf)
                                Session("usuCode") = root.ChildNodes(i).InnerText
                            End If

                        Case "SlpName"
                            System.Diagnostics.Debug.Write(root.ChildNodes(i).InnerText & vbCrLf)
                            Session("usuName") = root.ChildNodes(i).InnerText
                        Case "U_IL_admin"
                            If root.ChildNodes(i).InnerText = "SI" Then
                                Session("usutipo") = "admin"
                            Else
                                Session("usutipo") = "venta"
                            End If
                            'Case "U_IL_imagen" 
                            '    Session("Imagen") = "data:image/png;base64," + root.ChildNodes(i).InnerText
                    End Select
                Next i

                If bandera = True Then
                    System.Diagnostics.Debug.Write("continua" & vbCrLf)


                    If Session("usutipo") = "admin" Then
                        Respuesta = ws.ExecuteSQL(Session("Token"), "select Rate from ORTT where RateDate = CONVERT (date, GETDATE()) ")

                        Session("usdrate") = ReadXML(Respuesta.InnerXml, "rate")
                        Respuesta = ws.ExecuteSQL(Session("Token"), "select img  from [Ecom].[dbo].[perfil] where usu='" & Session("usuCode") & "'")
                        Session("Imagen") = "data:image/png;base64," & ReadXML(Respuesta.InnerXml, "img")

                        Response.Redirect("~/View/Inicio.aspx")


                    Else
                        Respuesta = ws.ExecuteSQL(Session("Token"), "select img   from [Ecom].[dbo].[perfil] where usu='" & Session("usuCode") & "'")
                        Session("Imagen") = "data:image/png;base64," & ReadXML(Respuesta.InnerXml, "img")
                        Response.Redirect("~/View/Config/Razon.aspx")
                    End If
                Else
                    bandera = buscaCliente()
                    If bandera = True Then
                        System.Diagnostics.Debug.Write("continua" & vbCrLf)
                        Respuesta = ws.ExecuteSQL(Session("Token"), "select img  from [Ecom].[dbo].[perfil] where usu='" & Session("usuCode") & "'")
                        Dim imagensiia As String = ReadXML(Respuesta.InnerXml, "img")
                        Session("Imagen") = "data:image/png;base64," & imagensiia
                        Response.Redirect("~/View/Inicio.aspx")
                    Else
                        Alertamail.Style("display") = "block"
                        System.Diagnostics.Debug.Write("usuario desconocido" & vbCrLf)
                        Session.Clear()
                        Session.Abandon()
                    End If
                End If
            End If
        Else

            Try


                Dim sqldato As String = "select *   from [Ecom].[dbo].[color]  "
                Respuesta = ws.ExecuteSQL(Session("Token"), sqldato)
                Session("colorTop") = ReadXML(Respuesta.InnerXml, "barratop")
                Session("colorInfo") = ReadXML(Respuesta.InnerXml, "infousu")
                Session("colorMenu") = ReadXML(Respuesta.InnerXml, "menu")
                Session("colorContenido") = ReadXML(Respuesta.InnerXml, "contenido")
                Session("logo") = ReadXML(Respuesta.InnerXml, "img")

                'sqldato = "select top 1 U_arttype as tipo,U_artcan as cantidad,tipodoc from [Ecom].[dbo].[@IL_CONFIG_E]   "
                'Respuesta = ws.ExecuteSQL(Session("Token"), sqldato)
                'Session("configarttype") = ReadXML(Respuesta.InnerXml, "tipo")
                'Session("configartcan") = ReadXML(Respuesta.InnerXml, "cantidad")
                'Session("tipodocventas") = ReadXML(Respuesta.InnerXml, "tipodoc")

                sqldato = "select top 1 U_arttype as tipo,U_artcan as cantidad ,rutaxml,rutapdf,tipodoc,[smtp],[puerto],[username], [acount],[password],[ssl] from [Ecom].[dbo].[@IL_CONFIG_E]   "
                Respuesta = ws.ExecuteSQL(Session("Token"), sqldato)
                Session("configarttype") = ReadXML(Respuesta.InnerXml, "tipo")
                Session("configartcan") = ReadXML(Respuesta.InnerXml, "cantidad")
                Session("rutapdf") = ReadXML(Respuesta.InnerXml, "rutaxml")
                Session("rutaxml") = ReadXML(Respuesta.InnerXml, "rutapdf")
                Session("tipodocventas") = ReadXML(Respuesta.InnerXml, "tipodoc")


                Session("smtp") = ReadXML(Respuesta.InnerXml, "smtp")
                Session("puerto") = ReadXML(Respuesta.InnerXml, "puerto")
                Session("username") = ReadXML(Respuesta.InnerXml, "username")
                Session("acount") = ReadXML(Respuesta.InnerXml, "acount")
                Session("password") = ReadXML(Respuesta.InnerXml, "password")
                Session("ssl") = ReadXML(Respuesta.InnerXml, "ssl")
            Catch ex As Exception

            End Try

            If buscaCliente() Then
                System.Diagnostics.Debug.Write("continua" & vbCrLf)
                Dim busqueda As String = "select img  from [Ecom].[dbo].[perfil] where usu='" & Session("usuCode") & "'"
                Respuesta = ws.ExecuteSQL(Session("Token"), busqueda)
                Dim imagensiia As String = ReadXML(Respuesta.InnerXml, "img")
                Session("Imagen") = "data:image/png;base64," & imagensiia
                Response.Redirect("~/View/Inicio.aspx")

            Else
                Alertamail.Style("display") = "block"
                System.Diagnostics.Debug.Write("usuario desconocido" & vbCrLf)
                Session.Clear()
                Session.Abandon()
            End If

        End If

    End Sub



    Public Function buscaCliente() As Boolean
        Dim Respuesta As XmlNode
        Respuesta = ws.ExecuteSQL(Session("Token"), "Select top 1 T0.CardCode,T0.CardName,T0.Address,T0.ZipCode,T0.Currency,T0.E_Mail from OCRD T0 where CardCode='" & usu.Text & "' AND U_IL_pass='" & pass.Text & "'")

        Dim doc2 As New XmlDocument()
        doc2.LoadXml(Respuesta.InnerXml)
        System.Diagnostics.Debug.Write(Respuesta.InnerXml & vbCrLf)
        Dim root2 As XmlNode = doc2.FirstChild

        root2 = root2.LastChild
        root2 = root2.FirstChild

        Dim bandera As Boolean = True

        If root2.HasChildNodes Then
            Dim x As Integer
            For x = 0 To root2.ChildNodes.Count - 1
                Select Case root2.ChildNodes(x).Name
                    Case "CardCode"
                        If root2.ChildNodes(x).InnerText = "" Then
                            System.Diagnostics.Debug.Write("nada de nada" & vbCrLf)
                            x = root2.ChildNodes.Count - 1
                            Return False
                        Else
                            System.Diagnostics.Debug.Write(root2.ChildNodes(x).InnerText & vbCrLf)
                            Session("usuCode") = root2.ChildNodes(x).InnerText
                            Session("usutipo") = "cliente"
                            Session("RazCode") = root2.ChildNodes(x).InnerText
                        End If

                    Case "CardName"
                        System.Diagnostics.Debug.Write(root2.ChildNodes(x).InnerText & vbCrLf)
                        Session("usuName") = root2.ChildNodes(x).InnerText
                    Case "Address"
                        Session("RazAdr") = root2.ChildNodes(x).InnerText
                    Case "ZipCode"
                        Session("RazZip") = root2.ChildNodes(x).InnerText
                    Case "Currency"
                        Session("RazMON") = root2.ChildNodes(x).InnerText
                    Case "E_Mail"
                        Session("MailDestino") = root2.ChildNodes(x).InnerText
                        'Case "U_IL_imagen"
                        '    Session("Imagen") = "data:image/png;base64," + root2.ChildNodes(x).InnerText
                End Select
            Next x

            Respuesta = ws.ExecuteSQL(Session("Token"), "select Rate from ORTT where RateDate = CONVERT (date, GETDATE()) ")
            Session("usdrate") = ReadXML(Respuesta.InnerXml, "rate")
        End If
        Return True

    End Function


    Private Function ReadXML(Xml As String, NodeName As String) As String
        Dim reader As System.Xml.XmlTextReader = New System.Xml.XmlTextReader(New System.IO.StringReader(Xml))
        Dim valor As String
        valor = ""
        Do While (reader.Read())
            If reader.NodeType = System.Xml.XmlNodeType.Element Then
                If reader.Name.ToUpper = NodeName.ToUpper Then
                    valor = reader.ReadElementContentAsString
                End If
            End If
        Loop
        reader.Close()
        reader.Dispose()
        Return valor
    End Function

End Class
