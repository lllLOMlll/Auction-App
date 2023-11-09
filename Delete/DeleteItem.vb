Module DeleteItem
    Sub deletingItem()
        Dim idToDelete As String
        Console.Clear()
        Console.WriteLine(vbNewLine & "----------------------- DELETE ITEM -----------------------" & vbNewLine)

        'Display the list of items
        displayingAllItems()

        'Ask and validate idToDelte (must be an in


        ' Ask the user wich Id he want to delete
        Do
            idToDelete = InputBox("Enter the ID of the item you wish to delete:")
            ' Attempt to convert to integer
            Try
                idToDelete = CInt(idToDelete)
                ' If the conversion is successful, exit the loop
                Exit Do
            Catch ex As Exception
                MsgBox("Please enter a valid integer ID.", MsgBoxStyle.Exclamation, "Invalid Input")
            End Try
        Loop

        Dim found As Boolean = False

        For i As Integer = 0 To auctionItems.Length - 1
            'Can only delete -Not Sold- items

            If auctionItems(i).id = idToDelete AndAlso auctionItems(i).isSold = "-Not Sold-" Then
                'Clear the item details by creating a new auctionItem with default values
                'It's not really deleting an item, it's more putting it to defautl values
                ' Sting = 'Nothing'
                ' Integer = '0'
                auctionItems(i) = New auctionItem()
                found = True
                Console.WriteLine("Item with ID " & idToDelete & " has been deleted." & vbNewLine)
                System.Threading.Thread.Sleep(2000)
                Console.Clear()
                Exit For
            End If
        Next

        If Not found Then
            Console.WriteLine("Item with ID " & idToDelete & " not found or already sold." & vbNewLine)
            System.Threading.Thread.Sleep(2000)
            Console.Clear()
        End If
    End Sub
End Module
