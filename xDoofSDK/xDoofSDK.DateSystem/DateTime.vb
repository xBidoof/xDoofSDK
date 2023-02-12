
Namespace DateSystem

    ''' <summary>
    ''' Initialise une nouvelle instance de la classe <see cref="DateTime"/>.
    ''' </summary>
    Public Class DateTime

        ''' <summary>
        ''' Retourne la date en format <see cref="String"/>.
        ''' </summary>
        Public Shared Function GetTimeString(ByVal format As String) As String
            Return Date.Now.ToString(format)
        End Function
        ''' <summary>
        ''' Retourne la date en format <see cref="String"/> en temps UTC.
        ''' </summary>
        Public Shared Function GetTimeUtcString(ByVal format As String) As String
            Return Date.UtcNow.ToString(format)
        End Function
        ''' <summary>
        ''' Retourne la date en format <see cref="Date"/>.
        ''' </summary>
        Public Shared Function GetTime() As Date
            Return Date.Now
        End Function
        ''' <summary>
        ''' Retourne la date en format <see cref="Date"/> en temps UTC.
        ''' </summary>
        Public Shared Function GetTimeUtc() As Date
            Return Date.UtcNow
        End Function
        ''' <summary>
        ''' Retourne le jour actuelle en <see cref="String"/>.
        ''' </summary>
        Public Shared Function GetCurrentDay() As String
            Return Date.Now.Day
        End Function
        ''' <summary>
        ''' Retourne le mois actuelle en <see cref="String"/>.
        ''' </summary>
        Public Shared Function GetCurrentMonth() As String
            Return Date.Now.Month
        End Function
        ''' <summary>
        ''' Retourne l'année actuelle en <see cref="String"/>.
        ''' </summary>
        Public Shared Function GetCurrentYear() As String
            Return Date.Now.Year
        End Function
        ''' <summary>
        ''' Retourne une chaîne d'une date créé selon les paramètres saisie.
        ''' </summary>
        Public Shared Function CreateAssemblingDate(ByVal seperator As String, Optional ByVal assemblingOrder As OrderDateAssembling = OrderDateAssembling.Day_Month_Year) As String
            If assemblingOrder = OrderDateAssembling.Day_Month_Year Then
                Return Date.Now.Day & seperator & Date.Now.Month & seperator & Date.Now.Year
            ElseIf assemblingOrder = OrderDateAssembling.Day_Year_Month Then
                Return Date.Now.Day & seperator & Date.Now.Year & seperator & Date.Now.Month
            ElseIf assemblingOrder = OrderDateAssembling.Month_Day_Year Then
                Return Date.Now.Month & seperator & Date.Now.Day & seperator & Date.Now.Year
            ElseIf assemblingOrder = OrderDateAssembling.Month_Year_Day Then
                Return Date.Now.Month & seperator & Date.Now.Year & seperator & Date.Now.Day
            ElseIf assemblingOrder = OrderDateAssembling.Year_Day_Month Then
                Return Date.Now.Year & seperator & Date.Now.Day & seperator & Date.Now.Month
            ElseIf assemblingOrder = OrderDateAssembling.Year_Month_Day Then
                Return Date.Now.Year & seperator & Date.Now.Month & seperator & Date.Now.Day
            End If
            Return Date.Now.Day & seperator & Date.Now.Month & seperator & Date.Now.Year
        End Function
    End Class
End Namespace
