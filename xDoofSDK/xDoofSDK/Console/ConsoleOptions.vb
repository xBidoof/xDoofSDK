
Imports System.Text
''' <summary>
''' Initialise une nouvelle instance de la classe <see cref="ConsoleOptions"/>.
''' </summary>
Public NotInheritable Class ConsoleOptions

    ''' <summary>
    ''' Classe des fonctions du flux d'entrée.
    ''' </summary>
    Public NotInheritable Class InFlux
        ''' <summary>
        ''' Lis et retourne tout les caractères entre la position actuelle et la fin du lecteur.
        ''' </summary>
        Public Shared Function ReadEnd() As String
            Return Console.In.ReadToEnd()
        End Function
        ''' <summary>
        ''' Lis une ligne de caractères à partir du lecteur de texte et retourne les données.
        ''' </summary>
        Public Shared Function ReadCharLine() As String
            Return Console.In.ReadLine()
        End Function
        ''' <summary>
        ''' Lis le caractère suivant à partir du lecteur de texte et retourne l'implémentation.
        ''' </summary>
        Public Shared Function Read() As Integer
            Return Console.In.Read()
        End Function
        ''' <summary>
        ''' Lis le caractère suivant et retourne le prochain caractère disponible.
        ''' </summary>
        Public Shared Function Peek() As Integer
            Return Console.In.Peek()
        End Function
        ''' <summary>
        ''' Ferme et libère toutes les ressources.
        ''' </summary>
        Public Shared Sub CloseAndRelease()
            Console.In.Close()
        End Sub
    End Class
    ''' <summary>
    ''' Écrit dans le terminateur du flux de sortie.
    ''' </summary>
    Public Shared Sub WriteLine(ByVal value As String)
        Console.WriteLine(value)
    End Sub
    ''' <summary>
    ''' Écrit dans le terminateur de la ligne active dans le flux de sortie.
    ''' </summary>
    Public Shared Sub Write(ByVal format As String, ByVal arg0 As Object)
        Console.Write(format, arg0)
    End Sub
    ''' <summary>
    ''' Modifie la couleur de font de la console.
    ''' </summary>
    Public Shared Sub SetColorBackground(ByVal consoleColor As ConsoleColor)
        Console.BackgroundColor = consoleColor
    End Sub
    ''' <summary>
    ''' Récupère la couleur de font de la console.
    ''' </summary>
    Public Shared Function GetColorBackground() As ConsoleColor
        Return Console.BackgroundColor
    End Function
    ''' <summary>
    ''' Lit le son d'un signal sonore via le haut-parleur.
    ''' </summary>
    Public Shared Sub BeepSound()
        Console.Beep()
    End Sub
    ''' <summary>
    ''' Efface le contenu de la console.
    ''' </summary>
    Public Shared Sub ClearConsole()
        Console.Clear()
    End Sub
    ''' <summary>
    ''' Modifie l'encodage pour lire l'entrée.
    ''' </summary>
    Public Shared Sub EncodingInput(ByVal encoding As Encoding)
        Console.InputEncoding = encoding
    End Sub
    ''' <summary>
    ''' Lis le caractère suivant du flux d'entrée.
    ''' </summary>
    Public Shared Function ReadConsole() As Integer
        Return Console.Read()
    End Function
    ''' <summary>
    '''  Lit la ligne de caractères suivante du flux d'entrée.
    ''' </summary>
    Public Shared Function ReadLineConsole() As String
        Return Console.ReadLine()
    End Function
    ''' <summary>
    '''  Remet à zéro les couleurs de la console par défaut.
    ''' </summary>
    Public Shared Sub ColorReset()
        Console.ResetColor()
    End Sub
End Class