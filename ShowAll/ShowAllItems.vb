Module ShowAllItems
    Sub displayingAllItems()
        Console.WriteLine(vbNewLine & "----------------------- ALL AUCTION ITEMS -----------------------" & vbNewLine)
        Console.WriteLine("ID".PadRight(5) & "ARTIST".PadRight(20) & "TITLE".PadRight(20) & "RANK".PadRight(10) & "PRICE".PadRight(15) & "SOLD")

        For Each item In auctionItems
            ' Check that item is not Nothing and id is greater than 0 (those deleted)
            If item.id > 0 Then
                ' C2 = currency amount
                Dim formattedPrice As String = Convert.ToDecimal(item.price).ToString("C2")
                Dim status As String
                ' Check if the item is a price or "-Not Sold-". Apply formatting C2 to numbers.
                If item.isSold = "-Not Sold-" Then
                    status = item.isSold
                Else
                    status = Convert.ToDecimal(item.isSold).ToString("C2")
                End If

                Console.WriteLine(item.id.ToString().PadRight(5) & item.artistName.PadRight(20) & item.pictureTitle.PadRight(20) & item.rank.PadRight(10) & formattedPrice.PadRight(15) & status)
            End If
        Next

        Console.WriteLine(vbNewLine & "-----------------------------------------------------------------" & vbNewLine & vbNewLine)
    End Sub
End Module
