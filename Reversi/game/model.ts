/// <reference path="../Scripts/typings/lodash/lodash.d.ts" />

module model {

    import Dictionary = _.Dictionary;

    export class Square {
        constructor(public col: number, public row: number) {
            this.occupiedBy = null;
        }
        public foo: string
        public occupiedBy: Side;

        public flipPiece(): void {
            if (this.occupiedBy != null) {
                this.occupiedBy = oppositeSideTo(this.occupiedBy);
            }
        }

        public isEmpty(): boolean {
            return this.occupiedBy == null;
        }

        public isEdgeSquare(): boolean {
            return this.col == 0 || this.col == 7 || this.row == 0 || this.row == 7;
        }

        public isCornerSquare(): boolean {
            return (this.col == 0 || this.col == 7) && (this.row == 0 || this.row == 7);
        }
    }

    export enum Side { black, white }

    function oppositeSideTo(side: Side): Side {
        return side === Side.black? Side.white:  Side.black;
    }

    export enum Direction { north, northEast, east, southEast, south, southWest, west, northWest }

    export class Board {
        constructor() {
            this.squares = [];
            for (var col = 0; col < 8; col++) {
                for (var row = 0; row < 8; row++) {
                    this.squares.push(new Square(col, row));
                }
            }
            this.getSquare(3, 3).occupiedBy = Side.black;
            this.getSquare(4, 4).occupiedBy = Side.black;
            this.getSquare(4, 3).occupiedBy = Side.white;
            this.getSquare(3, 4).occupiedBy = Side.white;
        }

        private squares: Square[];

        public countPieces(): Dictionary<number>  {
            return _.countBy(this.squares, sq => sq.occupiedBy);
        }

        //If the coordinates lie outside of the board boundaries, returns 'undefined'
        public getSquare(col: number, row: number): Square {
            return _.find(this.squares, sq => sq.col === col && sq.row == row);
        }

        //Returns a list of all squares that would be captured (ultimely to be flipped)
        //by a given placement on a square
        public allCapturedSquares(placement: Square, side: Side): Square[] {
            var results = [];
            _.forEach(Direction, d => {
                var toAdd = this.capturedSquaresInASingleDirection(placement, side, d);
                _.forEach(toAdd, sq => results.push(sq));
            });
            return results;
        }

        private capturedSquaresInASingleDirection(placement: Square, side: Side, direction: Direction): Square[] {
            var coveredSquares = [];
            var file = this.lineFrom(placement, direction);
            for (var i: number = 0; i < file.length; i++) {
                const sq: Square = file[i];
                if (sq.occupiedBy === side) {
                    return coveredSquares;;  //Terminate loop
                }
                if (sq.occupiedBy == undefined) {
                    return [];  //no squares are bookended
                }
                coveredSquares.push(sq);
            }
            return []; //Didn't find a bookend so return no squares;
        }

        //Returns an array representing the line of squares from the given location to the edge of
        //the board in the given direction, nearest first.
        private lineFrom(location: Square, dir: Direction): Square[] {
            var line: Square[] = [];
            for (var i = 1; i <= 7; i++) { //Maximum of 7 steps in any direction to edge
                var sq: Square;
                switch (dir) {
                    case Direction.north:
                        sq = this.getSquare(location.col, location.row - i);
                        break;
                    case Direction.northEast:
                        sq = this.getSquare(location.col + i, location.row - i);
                        break;
                    case Direction.east:
                        sq = this.getSquare(location.col + i, location.row);
                        break;
                    case Direction.southEast:
                        sq = this.getSquare(location.col + i, location.row + i);
                        break;
                    case Direction.south:
                        sq = this.getSquare(location.col, location.row + i);
                        break;
                    case Direction.southWest:
                        sq = this.getSquare(location.col - i, location.row + i);
                        break;
                    case Direction.west:
                        sq = this.getSquare(location.col - i, location.row);
                        break;
                    case Direction.northWest:
                        sq = this.getSquare(location.col - i, location.row - i);
                        break;
                }
                if (sq != undefined) {
                    line.push(sq);
                }
            }
            return line;
        }

        public wouldBeValidMove(sq: Square, forPiece: Side): boolean {
            return sq.isEmpty() &&
                this.isAdjacentToPieceOfOppositeSide(sq, forPiece) &&
                this.allCapturedSquares(sq, forPiece).length > 0;
        }

        private isAdjacentToPieceOfOppositeSide(sq: Square, side: Side): boolean {
            var neighbours = this.getAdjacentSquares(sq);
            return _.some(neighbours, sq => sq.occupiedBy == oppositeSideTo(side));
        }

        //Returns all squares (on the board) that are immediate neighbours
        //of the given square  -  between 3 and 8 of them.
        private getAdjacentSquares(sq: Square): Square[] {
            var neighbours: Square[] = [];
            for (var col: number = sq.col - 1; col <= sq.col + 1; col++) {
                for (var row: number = sq.row - 1; row <= sq.row + 1; row++) {
                    var neighbour = this.getSquare(col, row);
                    if (neighbour != undefined && neighbour != sq) {
                        neighbours.push(sq);
                    }
                }
            }
            return neighbours;
        }

    }

    export class GameMaster {

        public constructor(public board: Board) {
            this.turn = Side.white;
            this.updateStatus();
        }

        public turn: Side;
        public status: string;
        public whiteCount: number;
        public blackCount: number;
        whiteHasSkippedTurn: boolean;
        blackHasSkippedTurn: boolean;
        public gameOver: boolean;

        //Returns all squares flipped as a result of the move.
        public placePiece(sq: Square): void {
            if (this.board.wouldBeValidMove(sq, this.turn)) {
                const flips: Square[] = this.board.allCapturedSquares(sq, this.turn);
                sq.occupiedBy = this.turn;
                _.forEach(flips, sq => sq.occupiedBy = this.turn);
                //net turn
                this.turn = oppositeSideTo(this.turn);
                this.updateStatus();
            } 
        }

        public updateStatus(): void {
            //Update counts
            this.whiteCount = this.board.countPieces()[Side.white];
            this.blackCount = this.board.countPieces()[Side.black];
            //Update status message
            if ((this.whiteCount + this.blackCount == 64)
                || (this.whiteHasSkippedTurn && this.blackHasSkippedTurn))
            { 
                this.gameOver = true;
                if (this.whiteCount > this.blackCount) {
                    this.status = 'GAME OVER. White has won!';
                } else if (this.whiteCount < this.blackCount) {
                    this.status = 'GAME OVER. Black has won!';
                } else {
                    this.status = 'GAME OVER. A draw!';
                }
            } else {
                switch (this.turn) {
                    case Side.black:
                        this.status = 'Black to play';
                        break;
                    case Side.white:
                        this.status = 'White to play';
                        break;
                }
            }  
        }

        public skipTurn(): void {
            if (this.turn == Side.white) this.whiteHasSkippedTurn = true;
            if (this.turn == Side.black) this.blackHasSkippedTurn = true;
            this.turn = oppositeSideTo(this.turn);
            this.updateStatus();
        }
    }
}
