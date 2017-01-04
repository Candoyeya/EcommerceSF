Imports Microsoft.VisualBasic
Imports System.Web.Configuration
Imports System.Xml
Imports System.Data.SqlClient

Public Class ConectaClass

End Class

Public Module ConectaMod
    '----ConexionWebService
    Public ws As DIS.DIServer = New DIS.DIServer
    'Public Server As HttpServerUtility = "http://SERVERIII/SAP/DIServer.asmx"
    Public Serveriii As String = System.Web.HttpContext.Current.Server.HtmlEncode("http://SERVERIII/SAP/DIServer.asmx")
    'Public Serveriii As String = System.Web.HttpContext.Current.Server.HtmlEncode("http://localhost/SAP/DIServer.asmx")
    'Public Serveriii As String = System.Web.HttpContext.Current.Server.HtmlEncode("http://surtidoraserver.ddns.net/SAP/DIServer.asmx")
    'Public ws.Url = "http://SERVERIII/SAP/DIServer.asmx"
    Public XmlDoc As New XmlDocument
    Public XmlDoc2 As New XmlDocument
    Public Node As XmlNodeList
    Public Node2 As XmlNodeList
    Public Respuesta As XmlNode
    '-------------------------------------------------------------------------------------------------------------------------------------
    '---Conexion sql
    Public ConnectionString As String = "Data Source=SERVERIII; Initial Catalog=NuevaBD; User Id=sa; Password=B1Admin"
    Public cnn As SqlConnection = New SqlConnection(ConnectionString)
    Public con As SqlConnection = New SqlConnection(ConnectionString)
    Public cmd, command As SqlCommand
    Public dr, dr2 As SqlDataReader
End Module
