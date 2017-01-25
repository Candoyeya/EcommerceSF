Imports Modulo

Imports System.Xml
Imports System.Globalization
Partial Class EmbarqueDiscrep
    Inherits System.Web.UI.Page
    Public ws As DIS.DIServer
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            Dim twoDarray(20, 10) As String

            'Busqueda de facturas venciadas Balance
            Dim tRow As New TableRow()
            Dim tCell As New TableCell()

            Dim factura As ArrayList = New ArrayList

            ws = New DIS.DIServer
            ws.Url = Serveriii

            Try

                Dim Respuesta As XmlNode

                Dim sqldato As String = "   select DocEntry,DocNum ,DocDate  from ODLN where DocNum  ='" & Session("DocNumDis") & "' "
                Respuesta = ws.ExecuteSQL(Session("Token"), sqldato)


                sqldato = "   select ItemCode ,Dscription ,Quantity ,unitMsr from DLN1 where DocEntry  ='" & ReadXML(Respuesta.InnerXml, "DocEntry") & "' "
                Respuesta = ws.ExecuteSQL(Session("Token"), sqldato)

                Dim doc2 As New XmlDocument()
                doc2.LoadXml(Respuesta.InnerXml)
                System.Diagnostics.Debug.Write(Respuesta.InnerXml & vbCrLf)
                Dim root2 As XmlNode = doc2.FirstChild
                Dim rootin As XmlNode

                root2 = root2.LastChild
                'root2 = root2.FirstChild
                If root2.HasChildNodes Then
                    Dim s As Integer
                    For s = 0 To root2.ChildNodes.Count - 1

                        rootin = root2.ChildNodes(s)

                        If rootin.HasChildNodes Then
                            Dim x As Integer
                            tRow = New TableRow()

                            For x = 0 To rootin.ChildNodes.Count - 1

                                Select Case rootin.ChildNodes(x).Name
                                    Case "ItemCode"
                                        tCell = New TableCell()
                                        tCell.Text = rootin.ChildNodes(x).InnerText
                                        tRow.Cells.Add(tCell)

                                        DropDownList1.Items.Insert(s, rootin.ChildNodes(x).InnerText)
                                    Case "Dscription"
                                        tCell = New TableCell()
                                        tCell.Text = rootin.ChildNodes(x).InnerText
                                        tRow.Cells.Add(tCell)

                                    Case "Quantity"
                                        tCell = New TableCell()
                                        tCell.Text = CInt(rootin.ChildNodes(x).InnerText)
                                        tRow.Cells.Add(tCell)

                                    Case "unitMsr"
                                        tCell = New TableCell()
                                        tCell.Text = rootin.ChildNodes(x).InnerText
                                        tRow.Cells.Add(tCell)

                                End Select
                            Next x

                            Table1.Rows.Add(tRow)

                        End If
                    Next s
                End If

                sqldato = "  select art,can,obs,img,id from  [Ecom].[dbo].[discrepancias] where fac='" & Session("DocNumDis") & "' and edo='1'  "
                Respuesta = ws.ExecuteSQL(Session("Token"), sqldato)

                If ReadXML(Respuesta.InnerXml, "art") <> "" Then

                    doc2 = New XmlDocument()
                    doc2.LoadXml(Respuesta.InnerXml)
                    System.Diagnostics.Debug.Write(Respuesta.InnerXml & vbCrLf)
                    root2 = doc2.FirstChild
                    root2 = root2.LastChild
                    'root2 = root2.FirstChild 
                    If root2.HasChildNodes Then
                        Dim s As Integer
                        For s = 0 To root2.ChildNodes.Count - 1

                            rootin = root2.ChildNodes(s)

                            If rootin.HasChildNodes Then
                                Dim x As Integer
                                tRow = New TableRow()

                                For x = 0 To rootin.ChildNodes.Count - 1

                                    Select Case rootin.ChildNodes(x).Name

                                        Case "art"
                                            tCell = New TableCell()
                                            tCell.Text = rootin.ChildNodes(x).InnerText
                                            tRow.Cells.Add(tCell)
                                            factura.Add(rootin.ChildNodes(x).InnerText)
                                        Case "can"
                                            tCell = New TableCell()
                                            tCell.Text = rootin.ChildNodes(x).InnerText
                                            tRow.Cells.Add(tCell)

                                        Case "obs"
                                            tCell = New TableCell()
                                            tCell.Text = rootin.ChildNodes(x).InnerText
                                            tRow.Cells.Add(tCell)

                                        Case "img"
                                            tCell = New TableCell()
                                            Dim imagen As String = "iVBORw0KGgoAAAANSUhEUgAAAMgAAAChCAQAAAAoqjiHAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAACXBIWXMAAC4jAAAuIwF4pT92AAAAB3RJTUUH4AEcAA8ZHszEugAAAAJiS0dEAP+Hj8y/AAASTklEQVR42u2deXyV1ZnH3+wCQgEVBIXRSrVYcAHrVtFqsSzpl2Hs4jo6tm6Mn5kuarVqXTrautSOU8XWiq1ttaJUpy1igIqKWMf2niQEhIQsBAwQIAnZ99z7mz/um8t9b25CknuvWTjP8w/3Jfe85zzf9zzPc857zrmO02sxjlli1GddYhwrCRELxAKxYoFYIFYsEAvEigVigVggFogFYoEMMiBzzFLzdJ90qZljgSQOSJJJ7rMmWSBWDrN+4pgkqxHqmAHAMNJMM5eaO8xS8xvzW/OC1TB9zjxmrjNnmYkmxXwiMCabq8xKU2YaTaAfmdbhoe3mgNlsHjXnmAyTUBwjzVXmQ9NuTd5LrTJLzYyEODHjGMdMNctMozVzHzXfXGFSTQJwnGrWWSfVLz1gbo+z6zKO+Yx5z5q239pgvhvHXmIcM96ssGaNSSvNvDjFEuMYx9xmOqxRY9QPzOR4AZlhtluDxqx+80AcJo+MY5LNw4eb8XwxaI/51qfjAeR4U3C4AclXST+1SDndlxsw3405jhjHLDrcxh7ZOiAp0A+VWrSpp7L/aNJMzAH9ycOtfwSB9E9aewZSYE6MFUi6ecMCiRuQZvPlWIGMNh9YIHED4jdXmpiHhLkWSNyAyNwQK5CjzUYLJI5AllggFogFYoFYIBaIBWKBWCAWiAVigVggFogFYoFYIBZIPIHsVVM/tVZ5Fkj8NVcb+6m5id1FNniB+NxnOUe52qhc5Sg77Pog1uEGxCejXG1WkfaoSrWqV4Ma1aB61apKe1Skj5Q7mMEMJyA+5Shfu1SvNvm7Cap+taleu5SvnMEJZbgA8WmjSlWtjl5mOx2qUak2Dj4owwGITzkqVb0CfUxBA6pT6WDrKcMBSL6qu3VRhxK/alRggcRPc1SmNsUmbSo7dDpqgfRG87S/B0fVoSbVqUbVqlGdmnqILwFVatPgcF1DF4hPm1XdjRtq1F6VqkCblKNsZStbOdqkApWqXI3duLc6bRkMSIYqEJ8+Ul0Us7arUoXKc1eod12zbpSnQlWqPcp3G7R14JEMVSCbVBvFRVVqq7IPaVSfsrVVlVFcWIM+skD6oxujzLc2qrgXMMKhFKuhSymHnPyzQKLPtnYNypv77G582qzKLknBfnfWywLptZZEOBu/9ii3X97fp1yVRwR5v0otkL7oZjVGGHB3TM90tnZHIGnWRwMX3IcekL0RzmpvT5vEejm43BvhuCoGzm0NLSA+5UeMy2viMsbOjUgSOrRtoPrI0AKSrf0Rb6jz42I4n7ao2VPygYHqI0MJiE9bPf0joLI4lr7D47baVTAwfWRo9ZDdEcO4jXF9T17jKX2f7SGHHg42evpHaVyfYZ9KPNlW06EW7BzuQHwq8Iw/GuM+ps71zI4FVDIQTmso9ZByj0vZnYA7lHnuUG57SM+jhdoEJ6Y+bfEkDfVxjVHDDkieJzGtT8g7vlzVezKtAXhDMlSA+JTveYdR8Qm4Rb8KLZDugZR6xgm7E2Iqn7Z7osh2C6R7U+1KYMp78C6FntT3Ywuke1Pt8YT0wgQByfek1uU2qPdulrc9QW+/fdriiVT7LZDeAWlLUP5jgfTBVOWfwNSfT1s9LmuvBdK7oO5XcYKAFHiC+i4LpHtT7fQkpB8nCEixJ7kutVlWTwlp4p2JzzObFVCRBdLT4obWMGNVJ+SNXrZncWpHnN5HDlMguZ5lbS0JWWPonS9rGYg3IkNp+r3KE0VKEzDbW+QJ6VUD8V59KL2g8s5mVcW8/KerVn4CicMw6iHeKNIedw+/JcHlDzsgORGrp+K9Cte7BK86AT1w2C0DKk7YUh2f8j39I6AddhlQb9ad1Cdg3WIwh6uK2NwwQNsShtpSUu9ytkDcJjc+jii3bGBwDL3F1hsjdk61xWE07VNhxIrhxoHbtjPUgPhUHLE7pDnGbMinfDVFbHDYPlA4huJ2hGzt67KZrf9IfMqP2G8iVQ5MfjVUgRhtigjtUrOK+1lWccSqd6lxILfrDNVNnwWeFDWYAu/q47Y2n3K1u8v26LaBWPoz9IEYbe9iyoBqVdjLfbg+ZWubarts+OzQjoGEMZSBGO2Iss+8QxUqVE4PP0/nk085KlRFlG/7VTawO3CHNpBs7Yh6HkOHalSmrcpVtozn9wOzlautKlNN1FNPOgYDjqF++EyJWro94adBB7RXO93fD9ypvTqghm5PDmpV6WDAMfSPZyqIchqDN7Ic/A3B7qVB2wYDjOEAxGiT9kV1Xb2VDu0bLEczDQ8gRtkqVE2fD/jrzMyKBoerGk5AgmOKEtX1+gjMYM+oU8ngOwZz+BwT61OutqlCTYc8f9GvJlVoWz/PR7FA+gTFKE/FKle1GtXuCeYBtatR1SpXsXvAmRmMOhyPGg+OOfKUryJtV6lKVartKlK+8tyxiRm8OpwP4+/Tj8sPFr0l9t/CzTGyGje9PlYgo8wGa8a4aYf5eqxAUs3r1pBx01ozJ1YgjrnfGjJuaszEmIA4jnHMF0yNNWWcdJlJih3IePOBNWVctNlcESMO12ndYjqsOeOgG8y4mIE4jnHMZPO+NWfM2miuNk58gDhmsTlgTRqjvmxGxwFHKPm937Rao8agH5npcekfISRjzDOm3Rq2n1pk5sYRh4tknHnMNFjj9kPzzCVxxuEiOcLcYApNwJq4T6F8eVydVQSSJHOqedLstIbu5bjjHXOtGZUgHCEoKeY0823zR7PD1JkW02q1izaaSmPME+ZfzPiEwvAkwiPMSeZcM88sNAusRuhF5nQzwSR/AiisWLFixYoVK1asWLFixYoVK1asWLFixYoVK1asWLFixYqVw1NIJp10UnFIDf0r+D+d/5dGEsHPKaSTHvwU+r6DwwimMo2JpNJ5JViWV5NI8ZTmkHbws+PgkETawRqE7p8S9vlopjGVIzrrGFaLFM+9kiPakELnHUZzIp9mbKgWqRF19LZsJCdwEuPC6hhmg1BL00hy75PstiGsHnRpWdQau3/vMINXWc0S0rmL1azmZ4wM3XwRq1jNzxnrFnsDq/kzcwiv8kk8wBq2UkQ2f+CrZOCQwt2sZlWYZvEik7meNfyJS+hs7MOs4VeMD91vLD9nDc9yrNvcmfwvWVxFsPpzeZ5/UMQWVvE9JoRDwSGTLPdeb7KSF/imW+szWMEavoWDwwk8zDtsYxsb+B9m4uBwK2vCvvc8VzLCrd/x3MNa8inkA5ZyHkk4OFzNav7CAjpx3MVaXmA8C8jiz3yBiSwL1WQVL/HvjMNhAi+wlruCj6xb429F2OhNXme2w0VUI55mBK8gxF7ODj2PzyNETrDxjGM9QvwurCd8iVwCKKR1PEgGKawIuxbUPUzjUYR4j0k4OIzhLcQ2JoWATCAH4edht/EX0YS4H4c0vsv+sNLaWct0z/O2JOJ+razgeBzmUot4HIepvO35izxm4fBMxPcaeZB0HGbxPv6w62VcTwoODyDE35mCg0M6ryB2MpmbEW18lRMp8pTXzvMcyRR2Il4hPazGj3exUQPzHS50gRzBcvfyfS79kylEiGwXyCKaEKKEU1wgp5CLaMPwG37BSqoQNcwniRWIBtZ5esgkF0iAn5CCwxj+iijwAMl2G39BGJD7cLicWkQtq/klv6eAAGIl47oAyecNVrGOMoR4jhS+FALyIAECZPMrfskG2hEvkc4ziBbWs4pVrKMSUcW5HMs7CD95vMCzrKMJsZ95ONzvWumnpHYB0splLpD9ZLGKtexCtPANjusGSCsbIntIVyBZjMLB4Zvusx8EksJTiAABxF0usgcQfp7nWJJwSGMJzYjlZLACsY2pYR46LeyZqGB+j0BEFseEgPyQo9mAqOZmRuCQxKm8g2jmmrB4FwRyJ8mkk8EFbELs51wuphbxGCmsROzjXBwcJvEeooTjeBpRzgxSSSeDOwggruNm/IhX+SeScDiSu2lBZDEyBKSKzB6AZHEkaaRyOc2I+7oFUslsTyxJjgakigtwOIKX3M9BIKewHZFDMeJtxuEwiRxECSeFjDKOVeTzA0ZEAZLi6aTvMZnRPQDxc1cIyD1cRAPi153NwWE+tYjXSIsAcnvImf4HHYh7+aLbQ5L5I6KRJ5nFp0jmW/yaH3MUSxF7ONl9xBbThriDNYj9zAqlE2NcnNP5YagNf2MKqd0AWc0YjmAUN9KC+F4vgaTiRAMibsfhNMoRgRCQb+Kng+u5B9HEYhxmcwDxMuk4pDGRSUzifM5mIulRXNYStwpN7ED4eYijugFSRSViN+cyhybE3VxDAD9XhvWHsfwNYTqdlheImxCUI54Nc1lXUIcIsJcP+S1XcTSOG0MqWMRMTufLvIVo5la2IdYyJsx8tyFaWcS9iBa2EyDAo4xieVQgVaznXT6kClHMTI7vhctazZ2kRQKpYy9iLaO5kQBV7EdkcwyjWIso5bOcTw3iOZK4kCbEgzg4TOdvFFLAVraRxSRe7RKwnnGrsI9b+RhRwddZExXIen6EH7GKy2hE3M0tiFYWhjUmjT8h8oP5WFQgx1OCeJEvU+MCyeA7lIQCdQtvcaYLxM8BKqikkQDiXS5kF+JZT9JwHcLPTfwQcYBvU4qoYjF/iArEmzx8rpdBfTkZkUB28Byimrm8iXiVDxDZHM1ZVCL2sIK/UI/Yw6mcRwPiZyThcCb7QsUWMIVXuu0hFZzOHfgRG9kUFcjbTGM9opk3aUbczY2INhaFNSaDLMQmju4WyDTKEMvCsqwMRnEGt/EiebQg1/Uu9Zikniw+z4mUIX7vSVJvQrRzLfciajmH79CBMLwfFUg5r7GC19iEH/E6M9jRvx5SwpVU4+c3lBNgCW+5LuvRCJYB/pNT2I3YwKdwmMz9PM5PKUAUcDyvuDEkLdw/ukBmMp4sRAB/VCDvks48KlyHKe7mn2lD/CDMZZ1CMWJd2JgpEsjXaEI84gb1R5jNSt7nShySOY7FrHcN+xSihvu5mVu4jksYi8MxbEJsYSoHx1tPIOo4zwVyNmN5A+GnLSqQNxlJCilM431EBYvZ3k0MOavnGLKDM1iHaEIUcBpvIwwz8CHKWMGrvMJKahEfMsV1clcEx8U4jODPYUBCpvZUoYLTcbjATUyjAxlBCj8JjW/u5WRKEfmc5obedP4LIX7cJcu6za3JaP6AaOIyN6g/wiz2I5aR7pZxL6KZuTzVGdQ9o/7/RrTz7eAsAQ7nswPxERO5zwXpcB473Rp2BbLKvU8av0NU8w1KEMu7AKngNCKmTrxAdnIc33dvs4yRvIv4B9+hCfEEqaSRxpG8iKhnHl+hGlHOA1zIbObzS2rDXNYurmY+C1jAAhYynwk8FgKSxD209wCkMzHtHBf9CCH+weXMZg5PUIco4dQu45BlzCOTq1lOC+IdxnCJm/aO4QNEHY9yAbP4GtmIcqbzdCQQx8Hh8+xCHOAhzmc217EZ4ef77jgkCCSJO2nrBoiPRSwgkzvZj9jKhZQi1rPItUcmp/NTRC23Ms+9toAFfDoakOCVZq4knXcReaxB1DCXgwHOj3iJEdxDAyJAAwdcv9zCL/gUryICtNHqahsNLOaREBCHo8hCXUbqB4E4zKMyBOQ4ViJEG9U0EEBU8m8HZ55CQDpopc0N3Du5FCcsy/pXakJ1bUUEeIo0nokKJImb3b+up5p2RIAVTPAAcRjn1qorEL/b6gCinduYys7Q1VZa8fMSP3Nb1BqmtzvMYR8dPMkRvIgoYgojeQORzUQy+Ct+KqnEz/rOJBCHE9iIn22cTBrX8H9uduKngXe5jiNJ4eWwmx8E8hAB9rhzSA4XsIsONodlShP4EPFXF0gqD9FCO/fg4DCFx9lDByJAE++x+GDIdYPuwaY1sY8VfJEkHC6hAj8/wSGda8mjxa1rJU8wAYenEDv4TJfJyjS+wd9pdqc/PuYhd8LnXvxUcLbbhvPYSQdFTOIG2qlnMSewlfZQTerZwu2MZgpFYVeDQB6nw2MjF8h4LmUhnyOZM8jkYkbgMJOvcDbJJHMOC1nIQjKZFTbjmcxZZDKPiTg4TORiruEmrmIOR7lzm2eSGdYRgy7rWE4hk7mMDs2znk0mF5IRKjedL5DJOaG52aOYx0Km0Tk3PJOvciPXcjHHeOd7cZjKwtDdLmIGo0JlXEomn3XrNYV5XMtNXM7s4JwxnyOTS4J/7UTOYk/iUq7nBhYzPTR/9xkyuZSxoTZ8nkwuJoOpbhtHcJFbk4XM4zymkIzDCC4Oq98CMjmT6Z4rnS7LihUrVqxY6af8P3oUYq6kg9j4AAAAJXRFWHRkYXRlOmNyZWF0ZQAyMDE2LTAxLTI4VDAwOjE1OjI1KzAwOjAwT/+2wQAAACV0RVh0ZGF0ZTptb2RpZnkAMjAxNi0wMS0yOFQwMDoxNToyNSswMDowMD6iDn0AAABNdEVYdHNvZnR3YXJlAEltYWdlTWFnaWNrIDYuOS4yLTcgUTE2IHg4Nl82NCAyMDE1LTEyLTAyIGh0dHA6Ly93d3cuaW1hZ2VtYWdpY2sub3Jnbo4WPwAAABh0RVh0VGh1bWI6OkRvY3VtZW50OjpQYWdlcwAxp/+7LwAAABh0RVh0VGh1bWI6OkltYWdlOjpIZWlnaHQANjAz49fsDwAAABd0RVh0VGh1bWI6OkltYWdlOjpXaWR0aAA3NTHinUMMAAAAGXRFWHRUaHVtYjo6TWltZXR5cGUAaW1hZ2UvcG5nP7JWTgAAABd0RVh0VGh1bWI6Ok1UaW1lADE0NTM5NDAxMjXE4EguAAAAD3RFWHRUaHVtYjo6U2l6ZQAwQkKUoj7sAAAASHRFWHRUaHVtYjo6VVJJAGZpbGU6Ly8vdG1wL3ZpZ25ldHRlLzY0NzEwN2FmLTUwNjAtNDNlNi05YzNhLWJhMjIyMzJhOGQyZS5wbmceKVNmAAAAAElFTkSuQmCC"
                                            If rootin.ChildNodes(x).InnerText <> "" Then
                                                imagen = rootin.ChildNodes(x).InnerText
                                            End If
                                            tCell.Text = "<a href='data:image/png;base64," & imagen & "' target='_blank'><img alt='' src='data:image/png;base64," & imagen & "' width='50' height='50'   /></a>"
                                            'tCell.Text = rootin.ChildNodes(x).InnerText.Length
                                            tCell.HorizontalAlign = HorizontalAlign.Center
                                            tRow.Cells.Add(tCell)
                                        Case "id"
                                            tCell = New TableCell()
                                            tCell.HorizontalAlign = HorizontalAlign.Center
                                            tCell.Text = "<button class='btn btn-danger waves-effect' id='row" & rootin.ChildNodes(x).InnerText & "'       onclick='basura( id)'> Eliminar <i class='material-icons'>delete</i></button>"
                                            tRow.Cells.Add(tCell)
                                    End Select
                                Next x

                                Table2.Rows.Add(tRow)

                            End If
                        Next s
                    End If
                Else
                    Table2.Style("display") = "none"
                End If

                ' factura = CType(Session("factura"), ArrayList)

                Session("factura") = factura

            Catch ex As Exception
            End Try
        End If

    End Sub


    Protected Sub secretbutton_ServerClick(sender As Object, e As EventArgs) Handles secretbutton.ServerClick

        Try
            ws = New DIS.DIServer
            ws.Url = Serveriii

            Dim Respuesta As XmlNode

            Dim sqldato As String = "update [Ecom].[dbo].[discrepancias] set edo='0' where id='" & actuaid.Value & "'"
            Respuesta = ws.ExecuteSQL(Session("Token"), sqldato)


            sqldato = "  select art,can,obs,img,id from  [Ecom].[dbo].[discrepancias] where fac='" & Session("DocNumDis") & "' and edo='1'  "
            Respuesta = ws.ExecuteSQL(Session("Token"), sqldato)

            If ReadXML(Respuesta.InnerXml, "art") = "" Then
                Try
                    ws = New DIS.DIServer
                    ws.Url = Serveriii

                    sqldato = "  select DocEntry from ODLN where DocNum  =" & Session("DocNumDis") & " "
                    Respuesta = ws.ExecuteSQL(Session("Token"), sqldato)
                    Dim mystring As String = "<env:Envelope xmlns:env='http://schemas.xmlsoap.org/soap/envelope/'>   <env:Header>    <SessionID>" & Session("Token") & "</SessionID>   </env:Header>   <env:Body>    <dis:UpdateObject xmlns:dis='http://www.sap.com/SBO/DIS'>     <BOM>      <BO>       <AdmInfo>        <Object>oDeliveryNotes</Object>       </AdmInfo>       <QueryParams>        <DocEntry>" & ReadXML(Respuesta.InnerXml, "DocEntry") & "</DocEntry>       </QueryParams>     <Documents>                 <row>          <U_IL_estado>S</U_IL_estado>            </row>                </Documents>               </BO>     </BOM>    </dis:UpdateObject>   </env:Body>  </env:Envelope>"
                    Dim restring As String = ws.Interact(Session("Token"), mystring)

                Catch ex As Exception

                End Try
            End If
            ClientScript.RegisterStartupScript(Me.[GetType](), "aleasrt", "alert(' Se elimino discrepancia ');document.location.href='EmbarqueDiscrep'; ", True)

        Catch ex As Exception

        End Try


    End Sub


    Private Function ReadXML(Xml As String, NodeName As String)
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

    Protected Sub enviardisc_ServerClick(sender As Object, e As EventArgs) Handles enviardisc.ServerClick
        Dim fn As String = System.IO.Path.GetFileName(File1.PostedFile.FileName)

        Dim bmp As System.Drawing.Bitmap
        Dim ms As System.IO.MemoryStream
        Dim byteimage() As Byte
        Dim imgstring As String = ""
        Try
            Dim valor As Integer = Cantidad.Value
            Try
                If File1.PostedFile.ContentLength <> 0 Then
                    Try
                        bmp = New System.Drawing.Bitmap(File1.PostedFile.InputStream)

                        Dim ratioX = 1280 / bmp.Width
                        Dim ratioY = 720 / bmp.Height
                        Dim ratio = Math.Min(ratioX, ratioY)

                        Dim newWidth = (bmp.Width * ratio)
                        Dim newHeight = (bmp.Height * ratio)
                        bmp = New System.Drawing.Bitmap(bmp, New Drawing.Size(newWidth, newHeight))

                        ms = New System.IO.MemoryStream
                        bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
                        byteimage = ms.ToArray()
                        imgstring = Convert.ToBase64String(byteimage)


                    Catch ex As Exception
                    End Try
                End If

                ws = New DIS.DIServer
                ws.Url = Serveriii

                Dim Respuesta As XmlNode

                Dim sqldato As String = "insert into [Ecom].[dbo].[discrepancias]  (fac,tipo,can,obs,img,art,edo  ) " &
                "values ('" & Session("DocNumDis") & "','" & DropDownList2.SelectedValue & "'," &
                "'" & valor & "','" & TextArea1.Value & "','" & imgstring & "','" & DropDownList1.SelectedValue & "','1' )"
                Respuesta = ws.ExecuteSQL(Session("Token"), sqldato)

                '====Mensaje 1======
                sqldato = " <env:Envelope xmlns:env='http://schemas.xmlsoap.org/soap/envelope/'>" &
                                "<env:Header>" &
                                    "<SessionID>" & Session("Token") & "</SessionID>" &
                                "</env:Header>" &
                                "<env:Body>" &
                                    "<dis:SendMessage xmlns:dis='http://www.sap.com/SBO/DIS'>" &
                                        "<Service>MessagesService</Service>" &
                                        "<Message>" &
                                            "<Subject>Discrepancia del Socio: " & Session("usuName") & "</Subject>" &
                                            "<Text>Entrega:  " & Session("DocNumDis") & " - " & TextArea1.Value & " </Text>" &
                                            "<RecipientCollection>" &
                                                "<Recipient>" &
                                                    "<UserCode>manager</UserCode>" &
                                                    "<UserCode>Gsia1</UserCode>" &
                                                    "<UserCode>Admin</UserCode>" &
                                                    "<SendInternal>tYES</SendInternal>" &
                                                "</Recipient>" &
                                            "</RecipientCollection>" &
                                        "</Message>" &
                                    "</dis:SendMessage>" &
                                "</env:Body>" &
                            "</env:Envelope>"

                '" & TextArea1.Value & "','" & Session("RazCode") & "','Admin','" & id & "','" & DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") & "')"
                ws.Interact(Session("Token"), sqldato)
                '====Mensaje 2======
                'sqldato = " <env:Envelope xmlns:env='http://schemas.xmlsoap.org/soap/envelope/'>   <env:Header>    <SessionID>" & Session("Token") & "</SessionID>   </env:Header>   <env:Body>    <dis:SendMessage xmlns:dis='http://www.sap.com/SBO/DIS'>     <Service>MessagesService</Service>      <Message>       <Subject>Discrepancia del Socio: " & Session("usuName") & "</Subject>       <Text>Entrega:  " & Session("DocNumDis") & " - " & TextArea1.Value & " </Text>       <RecipientCollection>        <Recipient>         <UserCode>Marco</UserCode>         <SendInternal>tYES</SendInternal>        </Recipient>       </RecipientCollection>              </Message>     </dis:SendMessage>   </env:Body>  </env:Envelope>"

                '" & TextArea1.Value & "','" & Session("RazCode") & "','Admin','" & id & "','" & DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") & "')"
                'ws.Interact(Session("Token"), sqldato)

                '====Mensaje 3======
                'sqldato = " <env:Envelope xmlns:env='http://schemas.xmlsoap.org/soap/envelope/'>   <env:Header>    <SessionID>" & Session("Token") & "</SessionID>   </env:Header>   <env:Body>    <dis:SendMessage xmlns:dis='http://www.sap.com/SBO/DIS'>     <Service>MessagesService</Service>      <Message>       <Subject>Discrepancia del Socio: " & Session("usuName") & "</Subject>       <Text>Entrega:  " & Session("DocNumDis") & " - " & TextArea1.Value & " </Text>       <RecipientCollection>        <Recipient>         <UserCode>Gsia1</UserCode>         <SendInternal>tYES</SendInternal>        </Recipient>       </RecipientCollection>              </Message>     </dis:SendMessage>   </env:Body>  </env:Envelope>"

                '" & TextArea1.Value & "','" & Session("RazCode") & "','Admin','" & id & "','" & DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") & "')"
                'ws.Interact(Session("Token"), sqldato)
                Try
                    ws = New DIS.DIServer
                    ws.Url = Serveriii

                    sqldato = "  select DocEntry from ODLN where DocNum  =" & Session("DocNumDis") & " "
                    Respuesta = ws.ExecuteSQL(Session("Token"), sqldato)
                    Dim mystring As String = "<env:Envelope xmlns:env='http://schemas.xmlsoap.org/soap/envelope/'>   <env:Header>    <SessionID>" & Session("Token") & "</SessionID>   </env:Header>   <env:Body>    <dis:UpdateObject xmlns:dis='http://www.sap.com/SBO/DIS'>     <BOM>      <BO>       <AdmInfo>        <Object>oDeliveryNotes</Object>       </AdmInfo>       <QueryParams>        <DocEntry>" & ReadXML(Respuesta.InnerXml, "DocEntry") & "</DocEntry>       </QueryParams>     <Documents>                 <row>          <U_IL_estado>D</U_IL_estado>            </row>                </Documents>               </BO>     </BOM>    </dis:UpdateObject>   </env:Body>  </env:Envelope>"
                    Dim restring As String = ws.Interact(Session("Token"), mystring)
                    ClientScript.RegisterStartupScript(Me.[GetType](), "aleasrt", "alert(' Se Registro discrepancia de entrega: " & Session("DocNumDis") & " ');document.location.href='EmbarqueDiscrep'; ", True)

                Catch ex As Exception

                End Try
                ClientScript.RegisterStartupScript(Me.[GetType](), "aleasrt", "alert(' Se agrego discrepancia ');document.location.href='EmbarqueDiscrep'; ", True)

            Catch ex As Exception

            End Try

        Catch ex As Exception
            ClientScript.RegisterStartupScript(Me.[GetType](), "aleasrt", "alert(' Error: verifique los datos del formulario ');document.location.href='EmbarqueDiscrep'; ", True)

        End Try

    End Sub

    Public Overloads Shared Function ResizeImage(bmSource As Drawing.Bitmap, TargetWidth As Int32, TargetHeight As Int32) As Drawing.Bitmap
        Dim bmDest As New Drawing.Bitmap(TargetWidth, TargetHeight, Drawing.Imaging.PixelFormat.Format32bppArgb)

        Dim nSourceAspectRatio = bmSource.Width / bmSource.Height
        Dim nDestAspectRatio = bmDest.Width / bmDest.Height

        Dim NewX = 0
        Dim NewY = 0
        Dim NewWidth = bmDest.Width
        Dim NewHeight = bmDest.Height

        If nDestAspectRatio = nSourceAspectRatio Then
            'same ratio
        ElseIf nDestAspectRatio > nSourceAspectRatio Then
            'Source is taller
            NewWidth = Convert.ToInt32(Math.Floor(nSourceAspectRatio * NewHeight))
            NewX = Convert.ToInt32(Math.Floor((bmDest.Width - NewWidth) / 2))
        Else
            'Source is wider
            NewHeight = Convert.ToInt32(Math.Floor((1 / nSourceAspectRatio) * NewWidth))
            NewY = Convert.ToInt32(Math.Floor((bmDest.Height - NewHeight) / 2))
        End If

        Using grDest = Drawing.Graphics.FromImage(bmDest)
            With grDest
                .CompositingQuality = Drawing.Drawing2D.CompositingQuality.HighQuality
                .InterpolationMode = Drawing.Drawing2D.InterpolationMode.HighQualityBicubic
                .PixelOffsetMode = Drawing.Drawing2D.PixelOffsetMode.HighQuality
                .SmoothingMode = Drawing.Drawing2D.SmoothingMode.AntiAlias
                .CompositingMode = Drawing.Drawing2D.CompositingMode.SourceOver

                .DrawImage(bmSource, NewX, NewY, NewWidth, NewHeight)
            End With
        End Using

        Return bmDest
    End Function
End Class
