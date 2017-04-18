module Missile
open FAB.Types

let generateLocationsToHit centreCol centreRow board =
    let colRange = [|centreCol - 1..centreCol + 1|]
    let rowRange = [|centreRow - 1..centreRow + 1|]
//    let locations = colRange.SelectMany(col => rowRange, (col, row) => new Location(col, row));
//     ImmutableArray.CreateRange(locations);
    [for col in colRange do
          for row in rowRange do
            yield new Location(col, row ) ]

let fireBomb (loc: Location) board = 
    let locs = generateLocationsToHit loc.Col loc.Row board
    GameBoardFunctions.checkSquaresAndRecordOutcome board locs

let fireMissile (loc: Location) board =
    GameBoardFunctions.checkSquareAndRecordOutcome board loc false

