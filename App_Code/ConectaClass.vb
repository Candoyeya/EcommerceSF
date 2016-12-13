Imports Microsoft.VisualBasic
Imports System.Web.Configuration

Public Class ConectaClass

End Class

Public Module ConectaMod
    Public ws As DIS.DIServer = New DIS.DIServer
    'Public Server As HttpServerUtility = "http://SERVERIII/SAP/DIServer.asmx"
    Public Serveriii As String = System.Web.HttpContext.Current.Server.HtmlEncode("http://SERVERIII/SAP/DIServer.asmx")
    'Public Serveriii As String = System.Web.HttpContext.Current.Server.HtmlEncode("http://surtidoraserver.ddns.net/SAP/DIServer.asmx")
    'Public ws.Url = "http://SERVERIII/SAP/DIServer.asmx"
End Module
