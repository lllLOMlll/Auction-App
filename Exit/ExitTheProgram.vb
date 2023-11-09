Module ExitTheProgram
    Sub exitProgram()

        Console.Clear()
        Console.WriteLine()
        Console.WriteLine("                             *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*")
        Console.WriteLine("                             Thanks for using PAINTING AUCTION, a Major Software")
        Console.WriteLine("                             *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*")
        Console.WriteLine(vbNewLine)
        System.Threading.Thread.Sleep(2000)
        Console.Clear()
        userSessionActive = False
        quit = False
    End Sub

End Module
