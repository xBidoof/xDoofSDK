Namespace Draw
    ''' <summary>
    ''' Initialise une nouvelle structure de <see cref="DrawPoint"/> qui défini des points X et Y.
    ''' </summary>
    Public Structure DrawPoint

        Private pt_x As Integer
        Private pt_y As Integer
        Public Sub New(ByVal ptX As Integer, ByVal ptY As Integer)
            pt_x = ptX
            pt_y = ptY
        End Sub

        Public ReadOnly Property X As Integer
            Get
                Return pt_x
            End Get
        End Property

        Public ReadOnly Property Y As Integer
            Get
                Return pt_y
            End Get
        End Property

    End Structure
End Namespace
