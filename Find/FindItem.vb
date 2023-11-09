Module FindItem
    Sub findingItem()
        Console.Clear()
        displayingAllItems()
        Console.WriteLine(vbNewLine & "----------------------- FIND AN ITEM -----------------------" & vbNewLine)

        Dim searchTerm As String = InputBox("Enter the full name of the artist or the full title of the picture:", "Find Auction Item")
        Dim foundItems As New List(Of auctionItem)

        ' Search for items by artist name or picture title
        For Each item As auctionItem In auctionItems
            If item.id > 0 AndAlso (Not String.IsNullOrEmpty(item.artistName) AndAlso item.artistName.Equals(searchTerm, StringComparison.OrdinalIgnoreCase)) _
Or (Not String.IsNullOrEmpty(item.pictureTitle) AndAlso item.pictureTitle.Equals(searchTerm, StringComparison.OrdinalIgnoreCase)) Then
                foundItems.Add(item)
            End If
        Next
        ' Display found items
        If foundItems.Count > 0 Then
            For Each foundItem As auctionItem In foundItems
                Console.Clear()
                Console.WriteLine("--------------------------- ITEM FOUND -------------------------------------------" & vbNewLine)
                Console.WriteLine("ID: " & foundItem.id & ", Artist: " & foundItem.artistName & ", Title: " & foundItem.pictureTitle & ", Rank: " & foundItem.rank & ", Price: $" & foundItem.price & ", Status: " & foundItem.isSold)
                System.Threading.Thread.Sleep(2000)
            Next
        Else
            Console.Clear()
            Console.WriteLine("No items found with the provided artist name or title.")
            System.Threading.Thread.Sleep(2000)
            Console.Clear()
        End If

        Console.WriteLine(vbNewLine & "-----------------------------------------------------------------" & vbNewLine & vbNewLine)
    End Sub
End Module
