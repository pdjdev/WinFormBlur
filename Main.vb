Public Class Main
    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BlurForm.Show()
    End Sub

    Sub updateBlur()
        If Not Application.OpenForms().OfType(Of BlurForm).Any Then BlurForm.Show()
        BlurForm.Size = Me.Size
        BlurForm.DesktopLocation = Me.DesktopLocation

    End Sub

    Protected Overrides Sub OnLocationChanged(e As System.EventArgs)
        If WindowState = FormWindowState.Minimized Then
            BlurForm.Close()
        Else
            updateBlur()
        End If
        MyBase.OnLocationChanged(e)
    End Sub
End Class