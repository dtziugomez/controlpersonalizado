Imports System.ComponentModel
Public Class ColorMixer
    '<Category("color"),Description("Valor del color rojo")>_ 
    <Category("Color"), Description("Valor del color Rojo")> _
    Public Property Rojo() As Integer
        Get
            Rojo = TrackBar1.Value
        End Get
        Set(ByVal value As Integer)
            TrackBar1.Value = Rojo
        End Set
    End Property

    <Category("color"), Description("Valor del color azul")> _
    Public Property Azul() As Integer
        Get
            Rojo = TrackBar2.Value
        End Get
        Set(ByVal value As Integer)
            TrackBar2.Value = Azul
        End Set
    End Property

    <Category("color"), Description("Valor del color verde")> _
    Public Property Verde() As Integer
        Get
            Rojo = TrackBar3.Value
        End Get
        Set(ByVal value As Integer)
            TrackBar3.Value = Verde
        End Set
    End Property

    Public Class ColorMixerConEventos
        Inherits EventArgs
        Public ReadOnly Rojo, Verde, Azul As Integer
        Public Sub New(ByVal RojoVal As Integer, ByVal VerdeVal As Integer, ByVal AzulVal As Integer)
            Me.Rojo = RojoVal
            Me.Verde = VerdeVal
            Me.Azul = AzulVal
        End Sub
    End Class
    Public Delegate Sub CambioEstado(ByVal sender As Object, ByVal args As ColorMixerConEventos)
    Public Event Cambiar As CambioEstado

    Protected Sub AlCambiar(ByVal e As ColorMixerConEventos)
        RaiseEvent Cambiar(Me, e)

    End Sub

    Private Sub TrackBar1_CambiarValor(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrackBar1.ValueChanged
        Dim args As ColorMixerConEventos = New ColorMixerConEventos(TrackBar1.Value, TrackBar2.Value, TrackBar3.Value)
        AlCambiar(args)
    End Sub

    Private Sub TrackBar2_CambiarValor(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrackBar2.ValueChanged
        Dim args As ColorMixerConEventos = New ColorMixerConEventos(TrackBar1.Value, TrackBar2.Value, TrackBar3.Value)
        AlCambiar(args)
    End Sub

    Private Sub TrackBar3_CambiarValor(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrackBar3.ValueChanged
        Dim args As ColorMixerConEventos = New ColorMixerConEventos(TrackBar1.Value, TrackBar2.Value, TrackBar3.Value)
        AlCambiar(args)
    End Sub
End Class
