Module EditItem
    Sub editigItem()
        Console.Clear()
        Console.WriteLine(vbNewLine & "----------------------- EDIT ITEM -----------------------" & vbNewLine)

        'Display the items
        displayingAllItems()

        Dim idToEditString As String = InputBox("Enter the ID of the item you wish to edit:", "Edit Auction Item")
        Dim idToEdit As Integer
        If Integer.TryParse(idToEditString, idToEdit) Then
            Dim itemFound As Boolean = False

            For i As Integer = 0 To auctionItems.Length - 1
                If auctionItems(i).id = idToEdit AndAlso auctionItems(i).isSold = "-Not Sold-" Then
                    itemFound = True

                    ' Display the item details before editing
                    Console.WriteLine("You are editing the following item:")
                    Console.WriteLine("ID: " & auctionItems(i).id & ", Artist: " & auctionItems(i).artistName & ", Title: " & auctionItems(i).pictureTitle & ", Rank: " & auctionItems(i).rank & ", Price: $" & auctionItems(i).price & ", Status: " & auctionItems(i).isSold)
                    Console.WriteLine("-----------------------------------------------------------------")

                    ' Edit Price
                    Dim newPriceString As String = InputBox("Current price is $" & auctionItems(i).price & ". Enter the new price:", "Edit Item Price")
                    Dim newPrice As Decimal
                    If Decimal.TryParse(newPriceString, newPrice) Then
                        auctionItems(i).price = newPrice.ToString("0.##") ' Formats price without unnecessary decimal places
                    Else
                        Console.WriteLine("Invalid price entered. No changes made to the price.")
                    End If

                    ' Edit Status
                    Do
                        Dim newStatusString As String = InputBox("Enter new status (-Not Sold- or a price if sold):", "Edit Item Status")
                        Dim newStatus As Decimal
                        Dim notSoldCount As Integer = auctionItems.Count(Function(item) item.isSold = "-Not Sold-")

                        If newStatusString = "-Not Sold-" Then
                            ' Check if there are already 20 items with "-Not Sold-" status
                            If notSoldCount < 20 OrElse auctionItems(i).isSold = "-Not Sold-" Then
                                auctionItems(i).isSold = newStatusString
                                Exit Do
                            Else
                                MsgBox("Cannot set as '-Not Sold-'. There are already 20 items with this status.", MsgBoxStyle.Exclamation, "Limit Reached")
                            End If
                        ElseIf Decimal.TryParse(newStatusString, newStatus) Then
                            ' The user entered a price indicating the item is sold
                            auctionItems(i).isSold = newStatus.ToString("0.##") ' Formats status as a price without unnecessary decimal places
                            Exit Do
                        Else
                            MsgBox("Invalid status. Please enter a valid price or '-Not Sold-' if the item is not sold.", MsgBoxStyle.Exclamation, "Invalid Input")
                        End If
                    Loop


                    Console.WriteLine("Item updated successfully.")
                    Exit For
                End If
            Next

            If Not itemFound Then
                Console.WriteLine("Item with ID " & idToEdit & " not found or is already sold.")
            End If
        Else
            Console.WriteLine("Invalid ID entered.")
        End If

        Console.WriteLine(vbNewLine & "-----------------------------------------------------------------" & vbNewLine & vbNewLine)
    End Sub
End Module
