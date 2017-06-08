Partial Public Class _Default
    Inherits System.Web.UI.Page
    Dim txtresult As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnAttach_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAttach.Click

        txtresult = txtresult + FileUpload1.FileName.ToString()

        lblResult.Text = "Attached " + txtresult

    End Sub
End Class