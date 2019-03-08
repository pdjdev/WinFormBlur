Imports System.Runtime.InteropServices
Imports WinFormBlur.BlurBehind

Public Class BlurForm
    <DllImport("user32.dll")>
    Friend Shared Function SetWindowCompositionAttribute(ByVal hwnd As IntPtr, ByRef data As WindowCompositionAttributeData) As Integer
    End Function

    Private Sub BlurForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        EnableBlur()
    End Sub

    Friend Sub EnableBlur()
        Dim windowHelper As IntPtr = Me.Handle
        Dim accent = New AccentPolicy()
        accent.AccentState = AccentState.ACCENT_ENABLE_BLURBEHIND
        Dim accentStructSize = Marshal.SizeOf(accent)
        Dim accentPtr = Marshal.AllocHGlobal(accentStructSize)
        Marshal.StructureToPtr(accent, accentPtr, False)
        Dim data = New WindowCompositionAttributeData()
        data.Attribute = WindowCompositionAttribute.WCA_ACCENT_POLICY
        data.SizeOfData = accentStructSize
        data.Data = accentPtr
        SetWindowCompositionAttribute(windowHelper, data)
        Marshal.FreeHGlobal(accentPtr)
    End Sub
End Class
