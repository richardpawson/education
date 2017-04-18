
Imports FAB

Namespace FAB
    Public Module ShipFunctions

        <System.Runtime.CompilerServices.Extension>
        Public Function setPosition(ship As Ship, loc As Location, orient As Orientations) As Ship
            Return New Ship(ship.Name, ship.Size, ship.Hits, loc, orient)
        End Function

        'Calculated based on the size and the orientation of the ship
        <System.Runtime.CompilerServices.Extension>
        Public Function occupies(ship As Ship, loc As Location) As Boolean
            Return If(ship.Orientation = Orientations.Horizontal, ship.Location.Row = loc.Row AndAlso loc.Col >= ship.Location.Col AndAlso loc.Col < ship.Location.Col + ship.Size, ship.Location.Col = loc.Col AndAlso loc.Row >= ship.Location.Row AndAlso loc.Row < ship.Location.Row + ship.Size)
        End Function

        <System.Runtime.CompilerServices.Extension>
        Public Function isHitInLocation(ship As Ship, loc As Location) As Boolean
            Return ship.Hits.Contains(loc)
        End Function

        <System.Runtime.CompilerServices.Extension>
        Public Function fireAt(ship As Ship, loc As Location) As Tuple(Of Ship, Boolean, [String])
            If ship.occupies(loc) Then
                Dim newHits = ship.Hits.Add(loc)
                Dim newShip = New Ship(ship.Name, ship.Size, newHits, ship.Location, ship.Orientation)
                Dim message As String = If(isSunk(newShip), newShip.Name + " sunk!", "Hit a " + newShip.Name + " at (" + loc.Col + "," + loc.Row + ").")
                Return Tuple.Create(newShip, True, message)
            Else
                Return Tuple.Create(ship, False, "")
            End If
        End Function

        <System.Runtime.CompilerServices.Extension>
        Public Function isSunk(ship As Ship) As Boolean
            Return ship.Hits.Count >= ship.Size
        End Function
    End Module
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================
