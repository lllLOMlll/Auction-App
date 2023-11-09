Module AddItem
    Sub addingAnItem()
        'Count the number of items with the status "-Not Sold-"
        ' No more than 20!
        Dim notSoldCount As Integer = 0

        For Each item In auctionItems
            If item.isSold = "-Not Sold-" Then
                notSoldCount += 1
            End If
        Next


        ' Check if there are already 20 items with "-Not Sold-" status
        If notSoldCount >= 20 Then
            MsgBox("Cannot add more items with the status '-Not Sold-'. The limit is 20.", MsgBoxStyle.Exclamation, "Limit Reached")
            Console.Clear()
            Return
        End If

        Console.Clear()
        Console.WriteLine(vbNewLine & "----------------------- ADD ITEM -----------------------")

        If nextId > auctionItems.Length Then ' nextId should be greater than Length to resize
            ReDim Preserve auctionItems(nextId - 1) ' Resize the array to fit the new item
        End If

        'Create a auctionItem
        Dim newItem As auctionItem
        newItem.id = nextId
        nextId += 1

        ' Validate artist's name input
        Do
            newItem.artistName = InputBox("Enter the artist's name:", "Add Auction Item")
            If String.IsNullOrEmpty(newItem.artistName) Then
                MsgBox("The artist's name cannot be empty. Please enter a valid name.", MsgBoxStyle.Exclamation, "Input Required")
            End If
        Loop While String.IsNullOrEmpty(newItem.artistName)

        ' Validate picture title input
        Do
            newItem.pictureTitle = InputBox("Enter the picture title:", "Add Auction Item")
            If String.IsNullOrEmpty(newItem.pictureTitle) Then
                MsgBox("The painting name cannot be empty. Please enter a valid title.", MsgBoxStyle.Exclamation, "Input Required")
            End If
        Loop While String.IsNullOrEmpty(newItem.pictureTitle)

        ' Validate rank input
        Dim rankValid As Boolean = False
        Do
            Dim rankInput As String = InputBox("Enter the item rank (1-10):", "Add Auction Item")
            Dim rank As Integer
            If Integer.TryParse(rankInput, rank) AndAlso rank >= 1 AndAlso rank <= 10 Then
                newItem.rank = rank.ToString()
                rankValid = True
            Else
                MsgBox("Please enter a valid rank between 1 and 10.", MsgBoxStyle.Exclamation, "Invalid Input")
            End If
        Loop Until rankValid

        ' Validate price input
        Dim priceValid As Boolean = False
        Do
            Dim priceInput As String = InputBox("Enter the item price:", "Add Auction Item")
            Dim price As Decimal
            If Decimal.TryParse(priceInput, price) AndAlso price > 0 AndAlso price <= 1000000 Then
                ' "0.##" = format 2 decimals
                newItem.price = price.ToString("0.##")
                priceValid = True
            Else
                MsgBox("Please enter a valid price. Between $1 and $1,000,000.", MsgBoxStyle.Exclamation, "Invalid Input")
            End If
        Loop Until priceValid

        ' Set default status to "-Not Sold-"
        newItem.isSold = "-Not Sold-"

        ' Add the new item to the array
        auctionItems(newItem.id - 1) = newItem
        Console.WriteLine("Item added successfully with ID: " & newItem.id)
    End Sub
End Module
