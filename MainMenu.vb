Module MainMenu
    'Initializing and setting the value of the password
    ' Constant
    Const PASSWORD As String = "pp"

    'Public variables
    Public nextId As Integer = 21
    Public userSessionActive As Boolean
    Public quit As Boolean = False
    Public userChoice As String
    Dim userChoiceInt As Integer
    Public auctionItems(19) As auctionItem

    'Structure
    Public Structure auctionItem
        Dim id As Integer
        Dim artistName As String
        Dim pictureTitle As String
        Dim rank As String
        Dim price As String
        Dim isSold As String
    End Structure

    Sub Main()

        'Declare instances auction items
        ' 20 items
        ' 19 -Not Sold-
        auctionItems(0) = New auctionItem With {.id = 1, .artistName = "Michael Angel", .pictureTitle = "Mon Li", .rank = "1", .price = "50000", .isSold = "-Not Sold-"}
        auctionItems(1) = New auctionItem With {.id = 2, .artistName = "James Hire", .pictureTitle = "The flower", .rank = "5", .price = "1000", .isSold = "200"}
        auctionItems(2) = New auctionItem With {.id = 3, .artistName = "Alysha Lowery", .pictureTitle = "Masterpiece", .rank = "10", .price = "50000", .isSold = "-Not Sold-"}
        auctionItems(3) = New auctionItem With {.id = 4, .artistName = "Taylor Bird", .pictureTitle = "TheRainbow", .rank = "7", .price = "45000", .isSold = "-Not Sold-"}
        auctionItems(4) = New auctionItem With {.id = 5, .artistName = "Robert Hockey", .pictureTitle = "Scribble", .rank = "2", .price = "100", .isSold = "-Not Sold-"}
        auctionItems(5) = New auctionItem With {.id = 6, .artistName = "Casey Davis", .pictureTitle = "Bright Whisper", .rank = "7", .price = "88005", .isSold = "-Not Sold-"}
        auctionItems(6) = New auctionItem With {.id = 7, .artistName = "Jamie Johnson", .pictureTitle = "Inifinty Infinite", .rank = "1", .price = "24674", .isSold = "-Not Sold-"}
        auctionItems(7) = New auctionItem With {.id = 8, .artistName = "Pat Jones", .pictureTitle = "Despair", .rank = "8", .price = "6846", .isSold = "-Not Sold-"}
        auctionItems(8) = New auctionItem With {.id = 9, .artistName = "Greta Van Fleet", .pictureTitle = "Title Todle", .rank = "10", .price = "48985", .isSold = "-Not Sold-"}
        auctionItems(9) = New auctionItem With {.id = 10, .artistName = "Roger Paparoch", .pictureTitle = "Bolibolo", .rank = "6", .price = "64116", .isSold = "-Not Sold-"}
        auctionItems(10) = New auctionItem With {.id = 11, .artistName = "Cathie Gauthier", .pictureTitle = "Crouch", .rank = "9", .price = "4632", .isSold = "-Not Sold-"}
        auctionItems(11) = New auctionItem With {.id = 12, .artistName = "Baldur Gate", .pictureTitle = "Padou", .rank = "9", .price = "86060", .isSold = "-Not Sold-"}
        auctionItems(12) = New auctionItem With {.id = 13, .artistName = "Fanie Losier", .pictureTitle = "Trip to whenever", .rank = "8", .price = "2196", .isSold = "-Not Sold-"}
        auctionItems(13) = New auctionItem With {.id = 14, .artistName = "Harold Hamilton", .pictureTitle = "Ok Ok Ok!", .rank = "7", .price = "48073", .isSold = "-Not Sold-"}
        auctionItems(14) = New auctionItem With {.id = 15, .artistName = "Penicia Papalo", .pictureTitle = "Gig Big Frig", .rank = "3", .price = "20780", .isSold = "-Not Sold-"}
        auctionItems(15) = New auctionItem With {.id = 16, .artistName = "Ruta Baga", .pictureTitle = "The bike", .rank = "3", .price = "44147", .isSold = "-Not Sold-"}
        auctionItems(16) = New auctionItem With {.id = 17, .artistName = "Balonie Petrosky", .pictureTitle = "Rollabob", .rank = "1", .price = "55668", .isSold = "-Not Sold-"}
        auctionItems(17) = New auctionItem With {.id = 18, .artistName = "Karl Peloquin", .pictureTitle = "Super Conductor", .rank = "1", .price = "39866", .isSold = "-Not Sold-"}
        auctionItems(18) = New auctionItem With {.id = 19, .artistName = "John Williams", .pictureTitle = "Rah", .rank = "6", .price = "42679", .isSold = "-Not Sold-"}
        auctionItems(19) = New auctionItem With {.id = 20, .artistName = "Tony Brush", .pictureTitle = "Good God of Evil", .rank = "2", .price = "39707", .isSold = "-Not Sold-"}


        'MAIN PROGRAM LOOP
        Do
            'Ask password
            askAndValidatePassword()

            'Making "userSessionActive" true so the Do While can run 
            userSessionActive = True

            'SESSION PROGRAM LOOP
            Do While userSessionActive ' By defautl = True, when user hits "7" = exit, userSessionActive = False and the program is back to asking the password
                'Display Title
                displayTitle()

                'Display Menu               
                displayMenu()

                'Ask the user to choice an option
                'Validate user choice
                Do
                    Console.WriteLine(vbNewLine & "Choose an option (1 to 7)")
                    userChoice = Console.ReadLine()

                    ' Try to convert the user input into an integer
                    If Integer.TryParse(userChoice, userChoiceInt) Then
                        ' If the conversion is successful, check if the number is within the valid range
                        If userChoiceInt >= 1 AndAlso userChoiceInt <= 7 Then
                            Exit Do
                        Else
                            MsgBox("Please choose a number between 1 and 7.", MsgBoxStyle.Exclamation, "Wrong Input")
                        End If
                        'If the parse was NOT successful -> Wrong input
                    Else
                        MsgBox("Please enter a valid number.", MsgBoxStyle.Exclamation, "Wrong Input")
                    End If
                Loop

                Select Case userChoice
                    'ADDING 
                    Case 1
                        addingAnItem()
                    'DELETING 
                    Case 2
                        deletingItem()
                    'EDITING
                    Case 3
                        editigItem()
                    ' DISPLAYING
                    Case 4
                        displayingAllItems()
                    ' SHOW MIN AND MAX
                    Case 5
                        displayMinMaxItem()
                    ' FIND AN ITEM
                    Case 6
                        ' EXIT THE PROGRRAM                       
                        findingItem()
                    Case 7
                        exitProgram()
                End Select
            Loop
        Loop

        Console.ReadKey()



    End Sub
    ' STRUCTURE

    'SUB
    Sub askAndValidatePassword()
        Dim inputPassword As String

        Do Until quit
            inputPassword = InputBox("Please, enter your password", "Password validation -> Painting Auction")
            Try
                inputPassword = CStr(inputPassword)
                If inputPassword = PASSWORD Then
                    MsgBox("Welcome to the Painting Auction", MsgBoxStyle.OkOnly, "Welcome!")
                    quit = True
                Else
                    MsgBox("Wrong password!", MsgBoxStyle.Critical, "Error")
                End If
            Catch ex As Exception
                MsgBox("An error occurred: " & ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
        Loop
    End Sub

    Sub displayTitle()
        Console.WriteLine("================================================================================================")
        Console.WriteLine("                                  PAINTING AUCTION MENU                                         ")
        Console.WriteLine("================================================================================================" & vbNewLine)
    End Sub
    Sub displayMenu()
        Console.WriteLine("1. Add item")
        Console.WriteLine("2. Delete item [ONLY IF NOT SOLD]")
        Console.WriteLine("3. Edit item [ONLY IF NOT SOLD]")
        Console.WriteLine("4. Show all items")
        Console.WriteLine("5. Show min and max items (by price) [ONLY IF NOT SOLD]")
        Console.WriteLine("6. Find a item (Author or Title)")
        Console.WriteLine("7. Exit")
    End Sub


End Module
