module MissileFunctions
open FAB.Model

let generateBombSpread centreCol centreRow board =
    let colRange = [centreCol - 1..centreCol + 1]
    let rowRange = [centreRow - 1..centreRow + 1]
    [for col in colRange do
          for row in rowRange do
            yield new Location(col, row ) ]

let fireBomb (loc: Location) board = 
    let locs = generateBombSpread loc.Col loc.Row board
    GameBoardFunctions.checkSquaresAndRecordOutcome board locs

let fireMissile (loc: Location) board =
    GameBoardFunctions.checkSquareAndRecordOutcome board loc false

