Module IBANKontrol

    Sub Main()
        IBANKontrol("TR130006219932988256155416")
        Console.ReadLine()
    End Sub

    Function IBANKontrol(IBAN As String) As Boolean
        Console.WriteLine("IBAN: " & IBAN)

        '! IBAN SAYISI BOŞLUKLARDAN ARINDIRILDI.
        If IBAN.Count > 26 Then
            IBAN = IBAN.Replace(" ", String.Empty)  'TR470000100100000350930001
        End If
        Console.WriteLine("1. Aşama: " & IBAN)

        '! TR47 SONA ALINDI.
        Dim ParcalanmisIBAN As String() = New String(4) {}
        ParcalanmisIBAN(0) = IBAN.Substring(0, 4)
        ParcalanmisIBAN(1) = IBAN.Substring(4, 22)
        IBAN = ParcalanmisIBAN(1) & ParcalanmisIBAN(0)
        Console.WriteLine("2. Aşama: " & IBAN)

        '! T VE R DEĞERLERİ SAYISAL DEĞERE ÇEVRİLDİ.
        IBAN = IBAN.Replace("T", "29")
        IBAN = IBAN.Replace("R", "27")
        Console.WriteLine("3. Aşama: " & IBAN)

        '! IBAN PARÇALANDI.
        ParcalanmisIBAN(0) = IBAN.Substring(0, 9)
        ParcalanmisIBAN(1) = IBAN.Substring(9, 7)
        ParcalanmisIBAN(2) = IBAN.Substring(16, 7)
        ParcalanmisIBAN(3) = IBAN.Substring(23, 5)

        ParcalanmisIBAN(0) = ParcalanmisIBAN(0) Mod 97  '19
        ParcalanmisIBAN(1) = ParcalanmisIBAN(0) & ParcalanmisIBAN(1)
        ParcalanmisIBAN(1) = ParcalanmisIBAN(1) Mod 97  '48
        ParcalanmisIBAN(2) = ParcalanmisIBAN(1) & ParcalanmisIBAN(2)
        ParcalanmisIBAN(2) = ParcalanmisIBAN(2) Mod 97  '2
        ParcalanmisIBAN(3) = ParcalanmisIBAN(2) & ParcalanmisIBAN(3)
        ParcalanmisIBAN(3) = ParcalanmisIBAN(3) Mod 97  '1

        If ParcalanmisIBAN(3) = 1 Then
            Console.WriteLine("IBAN Doğru")
        Else
            Console.WriteLine("IBAN Hatalı")
        End If

        Return False
    End Function

End Module
