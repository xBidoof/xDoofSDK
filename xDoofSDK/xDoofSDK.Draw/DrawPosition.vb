Namespace Draw
    ''' <summary>
    ''' Initialise une nouvelle structure de <see cref="DrawPosition"/> qui défini des points X, Y et Z
    ''' </summary>
    Public Structure DrawPosition

        Private pt_x As Integer
        Private pt_y As Integer
        Private pt_z As Integer
        Public Sub New(ByVal ptX As Integer, ByVal ptY As Integer, ByVal ptZ As Integer)
            pt_x = ptX
            pt_y = ptY
            pt_z = ptZ
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

        Public ReadOnly Property Z As Integer
            Get
                Return pt_z
            End Get
        End Property

    End Structure
End Namespace