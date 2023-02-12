Namespace DateSystem

    Public Structure DateInfo

        Private Const MSPerSecond As Integer = 1000
        Private Const MSPerMinute As Integer = 600000000
        Private Const MSPerHour As ULong = 36000000000
        Private Const MSPerDay As ULong = 864000000000

        Private Const SecPerMinute As Integer = 60
        Private Const SecPerHour As Integer = 3600
        Private Const SecPerDay As Integer = 86400

        Private Const MinPerHour As Integer = 60
        Private Const MinPerDay As Integer = 1440

        Private Const HourPerDay As Integer = 24
        ''' <summary>
        ''' Retourne le nombre d'heure par jour.
        ''' </summary>
        Public ReadOnly Property HoursPerDay As Integer
            Get
                Return HourPerDay
            End Get
        End Property

        ''' <summary>
        ''' Retourne le nombre de minutes par heure.
        ''' </summary>
        Public ReadOnly Property MinutesPerHour As Integer
            Get
                Return MinPerHour
            End Get
        End Property
        ''' <summary>
        ''' Retourne le nombre de minutes par jour.
        ''' </summary>
        Public ReadOnly Property MinutesPerDay As Integer
            Get
                Return MinPerDay
            End Get
        End Property


        ''' <summary>
        ''' Retourne le nombre de secondes par minute.
        ''' </summary>
        Public ReadOnly Property SecondsPerMinute As Integer
            Get
                Return SecPerMinute
            End Get
        End Property
        ''' <summary>
        ''' Retourne le nombre de secondes par heure.
        ''' </summary>
        Public ReadOnly Property SecondsPerHour As Integer
            Get
                Return SecPerHour
            End Get
        End Property
        ''' <summary>
        ''' Retourne le nombre de secondes par jour.
        ''' </summary>
        Public ReadOnly Property SecondsPerDay As Integer
            Get
                Return SecPerDay
            End Get
        End Property


        ''' <summary>
        ''' Retourne le nombre de millisecondes par seconde.
        ''' </summary>
        Public ReadOnly Property MillisecondesPerSecond As Integer
            Get
                Return MSPerSecond
            End Get
        End Property
        ''' <summary>
        ''' Retourne le nombre de millisecondes par minute.
        ''' </summary>
        Public ReadOnly Property MillisecondesPerMinute As Integer
            Get
                Return MSPerMinute
            End Get
        End Property
        ''' <summary>
        ''' Retourne le nombre de millisecondes par heure.
        ''' </summary>
        Public ReadOnly Property MillisecondesPerHour As ULong
            Get
                Return MSPerHour
            End Get
        End Property
        ''' <summary>
        ''' Retourne le nombre de millisecondes par jour.
        ''' </summary>
        Public ReadOnly Property MillisecondesPerDay As ULong
            Get
                Return MSPerDay
            End Get
        End Property
    End Structure

End Namespace
