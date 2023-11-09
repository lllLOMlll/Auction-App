Module ShowMinMaxItem
    Sub displayMinMaxItem()
        Console.Clear()
        Console.WriteLine(vbNewLine & "----------------------- SHOW MIN AND MAX ITEMS -----------------------" & vbNewLine)

        Dim minPriceItems As New List(Of auctionItem)
        Dim maxPriceItems As New List(Of auctionItem)
        Dim minPrice As Decimal = Decimal.MaxValue
        Dim maxPrice As Decimal = Decimal.MinValue

        ' Find min and max prices first
        For Each item As auctionItem In auctionItems
            If item.isSold = "-Not Sold-" AndAlso item.id > 0 Then
                Dim itemPrice As Decimal = Decimal.Parse(item.price)
                If itemPrice < minPrice Then
                    minPrice = itemPrice
                End If
                If itemPrice > maxPrice Then
                    maxPrice = itemPrice
                End If
            End If
        Next

        ' Find all items with min and max price
        For Each item As auctionItem In auctionItems
            If item.isSold = "-Not Sold-" AndAlso item.id > 0 Then
                Dim itemPrice As Decimal = Decimal.Parse(item.price)
                If itemPrice = minPrice Then
                    minPriceItems.Add(item)
                End If
                If itemPrice = maxPrice Then
                    maxPriceItems.Add(item)
                End If
            End If
        Next

        ' Display all min price items
        If minPriceItems.Count > 0 Then
            Console.WriteLine("MINIMUM PRICED ITEMS (Not Sold):")
            For Each item As auctionItem In minPriceItems
                Console.WriteLine("ID: " & item.id & ", Artist: " & item.artistName & ", Title: " & item.pictureTitle & ", Rank: " & item.rank & ", Price: $" & item.price)
            Next
        Else
            Console.WriteLine("No minimum priced items found.")
        End If

        Console.WriteLine()

        ' Display all max price items
        If maxPriceItems.Count > 0 Then
            Console.WriteLine("MAXIMUM PRICED ITEMS (Not Sold):")
            For Each item As auctionItem In maxPriceItems
                Console.WriteLine("ID: " & item.id & ", Artist: " & item.artistName & ", Title: " & item.pictureTitle & ", Rank: " & item.rank & ", Price: $" & item.price)
                System.Threading.Thread.Sleep(2000)
            Next
        Else
            Console.WriteLine("No maximum priced items found.")
        End If

        Console.WriteLine(vbNewLine & "-----------------------------------------------------------------" & vbNewLine & vbNewLine)
    End Sub
End Module
