Public Class ClsSecurity

    Public Function BypassOK(ByVal jDate As Long, mycode As String) As Boolean
        Dim ScramDate As String
        Dim strDate As String

        Dim retcode As Boolean

        strDate = Trim(Str(jDate))
        ScramDate = Mid(strDate, 7, 1) & Mid(strDate, 5, 1) & Mid(strDate, 3, 1) & Mid(strDate, 1, 1) & Mid(strDate, 2, 1) & Mid(strDate, 4, 1) & Mid(strDate, 6, 1)
        Debug.Print(ScramDate)
        If ScramDate = mycode Then
            retcode = True
        Else
            retcode = False
        End If

        Return retcode
    End Function

    Public Function Date2Julian(ByVal vDate As Date) As Long

        Date2Julian = CLng(Format(Year(vDate), "0000") _
                      + Format(DateDiff("d", CDate("01/01/" _
                      + Format(Year(vDate), "0000")), vDate) _
                      + 1, "000"))

    End Function

End Class
