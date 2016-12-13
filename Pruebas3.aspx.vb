Imports Modulo
Imports System.Xml
Imports System.Data
Partial Class Pruebas3
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim dt As New DataTable()
        Try
            dt.Columns.AddRange(New DataColumn() {New DataColumn("Id", GetType(Integer)),
                                                   New DataColumn("Nombre", GetType(String)),
                                                   New DataColumn("Ciudad", GetType(String))})
            dt.Rows.Add(1, "Jonathan Orozco", "Monterrey")
            dt.Rows.Add(2, "Jesus Corona", "México")
            dt.Rows.Add(3, "Cirilo Zaucedo", "Tijuana")
            dt.Rows.Add(4, "Humberto Suazo", "Chile")
            Table1.DataSource = dt
            Table1.DataBind()
        Catch ex As Exception
            ClientScript.RegisterStartupScript(Me.[GetType](), "aleasrt", "alert(' Error: verifique los datos del formulario ');", True)
        End Try
    End Sub
End Class
