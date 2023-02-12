Imports System.Drawing

Namespace Draw
    ''' <summary>
    ''' Initialise une nouvelle structure de <see cref="DrawColor"/>.
    ''' </summary>
    Public Structure DrawColor

        Public Shared ReadOnly White As DrawColor = New DrawColor(ColorKnow.White)
        Public Shared ReadOnly Transparent As DrawColor = New DrawColor(ColorKnow.Transparent)
        Public Shared ReadOnly Blue As DrawColor = New DrawColor(ColorKnow.Blue)
        Public Shared ReadOnly Black As DrawColor = New DrawColor(ColorKnow.Black)
        Public Shared ReadOnly Brown As DrawColor = New DrawColor(ColorKnow.Brown)
        Public Shared ReadOnly Cyan As DrawColor = New DrawColor(ColorKnow.Cyan)
        Public Shared ReadOnly Green As DrawColor = New DrawColor(ColorKnow.Green)
        Public Shared ReadOnly Gray As DrawColor = New DrawColor(ColorKnow.Gray)
        Public Shared ReadOnly Yellow As DrawColor = New DrawColor(ColorKnow.Yellow)
        Public Shared ReadOnly Purple As DrawColor = New DrawColor(ColorKnow.Purple)
        Public Shared ReadOnly Maroon As DrawColor = New DrawColor(ColorKnow.Maroon)
        Public Shared ReadOnly Pink As DrawColor = New DrawColor(ColorKnow.Pink)
        Public Shared ReadOnly Red As DrawColor = New DrawColor(ColorKnow.Red)
        Public Shared ReadOnly Turquoise As DrawColor = New DrawColor(ColorKnow.Turquoise)

        Public Sub New(ByVal colorKnow As ColorKnow)

        End Sub

        Friend Function ToColor(ByVal colorKnow As DrawColor) As System.Drawing.Color
            If colorKnow = DrawColor.White Then : Return System.Drawing.Color.White
            ElseIf colorKnow = DrawColor.Transparent Then : Return System.Drawing.Color.Transparent
            ElseIf colorKnow = DrawColor.Blue Then : Return System.Drawing.Color.Blue
            ElseIf colorKnow = DrawColor.Black Then : Return System.Drawing.Color.Black
            ElseIf colorKnow = DrawColor.Brown Then : Return System.Drawing.Color.Brown
            ElseIf colorKnow = DrawColor.Cyan Then : Return System.Drawing.Color.Cyan
            ElseIf colorKnow = DrawColor.Green Then : Return System.Drawing.Color.Green
            ElseIf colorKnow = DrawColor.Gray Then : Return System.Drawing.Color.Gray
            ElseIf colorKnow = DrawColor.Yellow Then : Return System.Drawing.Color.Yellow
            ElseIf colorKnow = DrawColor.Purple Then : Return System.Drawing.Color.Purple
            ElseIf colorKnow = DrawColor.Maroon Then : Return System.Drawing.Color.Maroon
            ElseIf colorKnow = DrawColor.Pink Then : Return System.Drawing.Color.Pink
            ElseIf colorKnow = DrawColor.Red Then : Return System.Drawing.Color.Red
            ElseIf colorKnow = DrawColor.Turquoise Then : Return System.Drawing.Color.Turquoise
            End If
        End Function

        Public Shared Function toDrawColor(ByVal getColor As System.Drawing.Color) As DrawColor
            If getColor = System.Drawing.Color.White Then : Return DrawColor.White
            ElseIf getColor = System.Drawing.Color.Transparent Then : Return DrawColor.Transparent
            ElseIf getColor = System.Drawing.Color.Blue Then : Return DrawColor.Blue
            ElseIf getColor = System.Drawing.Color.Black Then : Return DrawColor.Black
            ElseIf getColor = System.Drawing.Color.Brown Then : Return DrawColor.Brown
            ElseIf getColor = System.Drawing.Color.Cyan Then : Return DrawColor.Cyan
            ElseIf getColor = System.Drawing.Color.Green Then : Return DrawColor.Green
            ElseIf getColor = System.Drawing.Color.Gray Then : Return DrawColor.Gray
            ElseIf getColor = System.Drawing.Color.Yellow Then : Return DrawColor.Yellow
            ElseIf getColor = System.Drawing.Color.Purple Then : Return DrawColor.Purple
            ElseIf getColor = System.Drawing.Color.Maroon Then : Return DrawColor.Maroon
            ElseIf getColor = System.Drawing.Color.Pink Then : Return DrawColor.Pink
            ElseIf getColor = System.Drawing.Color.Red Then : Return DrawColor.Red
            ElseIf getColor = System.Drawing.Color.Turquoise Then : Return DrawColor.Turquoise
            End If
        End Function
        Public Shared Operator =(left As DrawColor, right As DrawColor) As Boolean
            Return True
        End Operator
        Public Shared Operator <>(left As DrawColor, right As DrawColor) As Boolean
            Return True
        End Operator
    End Structure
End Namespace