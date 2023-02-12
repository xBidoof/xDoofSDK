''' <summary>
''' Initialise une nouvelle instance de la classe <see cref="Structuration"/>.
''' </summary>
Public Structure Structuration
    ''' <summary>
    ''' Objet qui retourne True ou 1.
    ''' </summary>
    Public Shared ReadOnly Enable = True Or 1
    ''' <summary>
    ''' Objet qui retourne False ou 0.
    ''' </summary>
    Public Shared ReadOnly Disable = False Or 0
End Structure
