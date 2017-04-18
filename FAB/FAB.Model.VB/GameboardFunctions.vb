
Imports System.Collections.Generic
Imports System.Collections.Immutable
Imports System.Linq
Imports TechnicalServices
Imports FAB

Namespace FAB
    Public Module GameBoardFunctions

        Private Const newLine As String = vbLf

        Public Function allSunk(ships As IEnumerable(Of Ship)) As Boolean
            Return Not ships.Any(Function(ship) Not ship.isSunk())
        End Function

        <System.Runtime.CompilerServices.Extension>
        Public Function checkSquareAndRecordOutcome(board As GameBoard, loc As Location, Optional aggregateMessages As Boolean = False) As GameBoard
            Dim results = board.Ships.[Select](Function(s) s.fireAt(loc))
            Dim newShips = results.[Select](Function(r) r.Item1)
            Dim hit = results.[Select](Function(r) r.Item2).Aggregate(Function(a, b) a Or b)
            Dim newMessages As String = results.[Select](Function(r) r.Item3).Aggregate(Function(a, b) a + b)
            Dim aggregatedMessages = If(aggregateMessages, Convert.ToString(board.Messages) & newMessages, newMessages)
            Dim misses = board.Misses
            If hit Then
                If allSunk(newShips) Then
                    Dim newMessage = newMessages & Convert.ToString("All ships sunk!")
                    Return New GameBoard(board.Size, newShips.ToImmutableArray(), newMessage, misses)
                Else
                    Return New GameBoard(board.Size, newShips.ToImmutableArray(), aggregatedMessages, misses)
                End If
            Else
                Dim newMisses = board.Misses.Add(loc)
                Dim newMessage = aggregatedMessages + "Sorry, (" + loc.Col + "," + loc.Row + ") is a miss."
                Return New GameBoard(board.Size, newShips.ToImmutableArray(), newMessage, newMisses)
            End If
        End Function

        <System.Runtime.CompilerServices.Extension>
        Public Function checkSquaresAndRecordOutcome(board As GameBoard, locs As IImmutableList(Of Location)) As GameBoard
            Dim boardFromHead = checkSquareAndRecordOutcome(board, locs.First(), True)
            If locs.Count() = 1 Then
                Return boardFromHead
            Else
                Return checkSquaresAndRecordOutcome(boardFromHead, locs.Remove(locs.First()))
            End If
        End Function

        Public Function isValidPosition(boardSize As Integer, existingShips As IImmutableList(Of Ship), shipToBePlaced As Ship, loc As Location, orientation As Orientations) As Boolean
            If Not shipWouldFitWithinBoard(boardSize, shipToBePlaced, loc, orientation) Then
                Return False
            Else
                Dim locs = locationsThatShipWouldOccupy(loc, orientation, shipToBePlaced.Size)
                Dim occupiedLocations = From l In locs From s In existingShips Where s.occupies(loc)
                Return occupiedLocations.Count() = 0
            End If
        End Function

        Public Function locationsThatShipWouldOccupy(loc As Location, orient As Orientations, locsToAdd As Integer) As ImmutableArray(Of Location)
            If locsToAdd = 0 Then
                Return ImmutableArray(Of Location).Empty
            Else
                If orient = Orientations.Horizontal Then
                    Return locationsThatShipWouldOccupy(loc.Add(1, 0), orient, locsToAdd - 1).Add(loc)
                Else
                    Return locationsThatShipWouldOccupy(loc.Add(0, 1), orient, locsToAdd - 1).Add(loc)
                End If
            End If
        End Function

        Public Function shipWouldFitWithinBoard(boardSize As Integer, ship As Ship, loc As Location, orientation As Orientations) As Boolean
            Return (orientation = Orientations.Horizontal AndAlso loc.Col + ship.Size <= boardSize) OrElse (orientation = Orientations.Vertical AndAlso loc.Row + ship.Size <= boardSize)
        End Function

        <System.Runtime.CompilerServices.Extension>
        Public Function contains(board As GameBoard, loc As Location) As Boolean
            Dim boardSize As Integer = board.Size
            Return loc.Col >= 0 AndAlso loc.Col < boardSize AndAlso loc.Row >= 0 AndAlso loc.Row < boardSize
        End Function

        <System.Runtime.CompilerServices.Extension>
        Public Function readSquare(board As GameBoard, loc As Location) As SquareValues
            If board.Ships.Any(Function(s) s.isHitInLocation(loc)) Then
                Return SquareValues.Hit
            ElseIf board.Misses.Contains(loc) Then
                Return SquareValues.Miss
            Else
                Return SquareValues.Empty
            End If
        End Function

        Public Function createBoardWithShipsPlacedRandomly(boardSize As Integer, shipsToBePlaced As ImmutableArray(Of Ship), random As Random) As GameBoard
            Dim shipPlacements = locateShipsRandomly(boardSize, shipsToBePlaced, ImmutableArray(Of Ship).Empty, random)
            Dim newShips = shipPlacements.[Select](Function(r) r.Item1).ToImmutableArray()
            Dim messages As String = shipPlacements.[Select](Function(r) r.Item2).Aggregate(Function(r, s) r + s)
            Dim noMisses = ImmutableList(Of Location).Empty
            Return New GameBoard(boardSize, newShips, messages, noMisses)
        End Function

        Public Function locateShipsRandomly(boardSize As Integer, shipsToBePlaced As ImmutableArray(Of Ship), shipsAlreadyPlaced As ImmutableArray(Of Ship), random As Random) As ImmutableList(Of Tuple(Of Ship, String))
            If shipsToBePlaced.Count() = 0 Then
                Return ImmutableList(Of Tuple(Of Ship, String)).Empty
            Else
                Dim thisShip = shipsToBePlaced(0)
                Dim result = locateShipRandomly(boardSize, shipsAlreadyPlaced, thisShip, random)
                Dim shipPlacement = Tuple.Create(result.Item1, result.Item2)
                Dim newRandom = result.Item3
                Dim newshipsAlreadyPlaced = shipsAlreadyPlaced.Add(result.Item1)
                Dim newShipsToBePlaced = shipsToBePlaced.Remove(thisShip)
                Return locateShipsRandomly(boardSize, newShipsToBePlaced, newshipsAlreadyPlaced, newRandom).Insert(0, shipPlacement)
            End If
        End Function

        Public Function locateShipRandomly(boardSize As Integer, shipsAlreadyLocated As ImmutableArray(Of Ship), shipToBeLocated As Ship, random As Random) As Tuple(Of Ship, String, Random)
            Dim pos = getValidRandomPosition(boardSize, shipsAlreadyLocated, shipToBeLocated, random)
            Dim message = Convert.ToString("Computer placing the " + shipToBeLocated.Name) & newLine
            Dim newShip = shipToBeLocated.setPosition(pos.Item1, pos.Item2)
            Return Tuple.Create(newShip, message, pos.Item3)
        End Function

        Public Function getValidRandomPosition(boardSize As Integer, shipsAlreadyLocated As ImmutableArray(Of Ship), shipToBeLocated As Ship, random As Random) As Tuple(Of Location, Orientations, Random)
            Dim pos = getRandomPosition(boardSize, random)
            Return If(isValidPosition(boardSize, shipsAlreadyLocated, shipToBeLocated, pos.Item1, pos.Item2), pos, getValidRandomPosition(boardSize, shipsAlreadyLocated, shipToBeLocated, pos.Item3))
        End Function

        Public Function getRandomPosition(boardSize As Integer, random As Random) As Tuple(Of Location, Orientations, Random)
            Dim result1 = RandomNumbers.[Next](random, 0, boardSize)
            Dim col = result1.Number

            Dim result2 = RandomNumbers.[Next](result1.NewGenerator, 0, boardSize)
            Dim row = result2.Number

            Dim result3 = RandomNumbers.[Next](result2.NewGenerator, 0, 2)
            Dim orientation = DirectCast(result3.Number, Orientations)

            Dim loc = New Location(col, row)
            Return Tuple.Create(loc, orientation, result3.NewGenerator)
        End Function
    End Module
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================
