Module Module1

    Sub Main()

    End Sub

    ''' <summary>
    ''' Girilen IBAN No'nun standartlara uygun olup olmadığını denetler
    ''' </summary>
    ''' <param name="IBAN">Denetlenmek istenen IBAN</param>
    ''' <returns>True Or False</returns>
    Public Function IBANKontrol(IBAN As String) As Boolean

        If IBAN.Count > 26 Then
            IBAN = IBAN.Replace(" ", String.Empty)  'TR470000100100000350930001
        End If

        Dim ParcalanmisIBAN As String() = New String(2) {}

        ParcalanmisIBAN(0) = IBAN.Substring(0, 4)
        ParcalanmisIBAN(1) = IBAN.Substring(4, 22)

        IBAN = ParcalanmisIBAN(1) & ParcalanmisIBAN(0)

        IBAN = IBAN.Replace("T", "29")
        IBAN = IBAN.Replace("R", "27")

        ParcalanmisIBAN(0) = IBAN.Substring(0, 9)
        ParcalanmisIBAN(1) = IBAN.Substring(9, 19)

        ParcalanmisIBAN(0) = ParcalanmisIBAN(0) Mod 97
        ParcalanmisIBAN(1) = ParcalanmisIBAN(0) & ParcalanmisIBAN(1)

        ParcalanmisIBAN(0) = ParcalanmisIBAN(1).Substring(0, 9)


        Return False
    End Function

End Module
