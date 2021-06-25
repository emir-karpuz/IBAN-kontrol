Module IBANKontrol

    Sub Main()
        IBANKontrol("TR47 0000 1001 0000 0350 9300 01")
        Console.ReadLine()
    End Sub

    Function IBANKontrol(IBAN As String) As Boolean
        Console.WriteLine("IBAN: " & IBAN)

        If IBAN.Count > 26 Then
            IBAN = IBAN.Replace(" ", String.Empty)  'TR470000100100000350930001
        End If
        Console.WriteLine("1. Aşama: " & IBAN)

        Dim ParcalanmisIBAN As String() = New String(2) {}
        ParcalanmisIBAN(0) = IBAN.Substring(0, 4)
        ParcalanmisIBAN(1) = IBAN.Substring(4, 22)
        IBAN = ParcalanmisIBAN(1) & ParcalanmisIBAN(0)
        Console.WriteLine("2. Aşama: " & IBAN)

        IBAN = IBAN.Replace("T", "29")
        IBAN = IBAN.Replace("R", "27")
        Console.WriteLine("3. Aşama: " & IBAN)

        ParcalanmisIBAN(0) = IBAN.Substring(0, 9)   '000010010
        ParcalanmisIBAN(1) = IBAN.Substring(9, 19)  '0000350930001292747
        ParcalanmisIBAN(0) = ParcalanmisIBAN(0) Mod 97  '19
        ParcalanmisIBAN(1) = ParcalanmisIBAN(0) & ParcalanmisIBAN(1).Substring(0, 9)    '19000035093
        ParcalanmisIBAN(0) = ParcalanmisIBAN(1) Mod 97  '43
        ParcalanmisIBAN(1) = ParcalanmisIBAN(0) & ParcalanmisIBAN(1).Substring(0, 9)    'DÜZENLENECEK


        Return False
    End Function

End Module
