/// <reference path="../Scripts/typings/lodash/lodash.d.ts" />

module model {

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
        switch (side) {
            case Side.black:
                return Side.white;
            case Side.white:
                return Side.black;
        }
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

        //If the coordinates lie outside of the board boundaries, returns 'undefined'
        public getSquare(col: number, row: number): Square {
            return _.find(this.squares, sq => sq.col === col && sq.row == row);
        }

        public allSquaresThatWouldBeFlippedBy(placement: Square, piece: Side): Square[] {
            var results = [];
            _.forEach(Direction, d => {
                var toAdd = this.bookendedSquares(placement, piece, d);
                _.forEach(toAdd, sq => results.push(sq));
            });
            return results;
        }

        private bookendedSquares(placement: Square, bookend: Side, direction: Direction): Square[] {
            var coveredSquares = [];
            var file = this.fileFrom(placement, direction);
            for (var i: number = 0; i < file.length; i++) {
                const sq: Square = file[i];
                if (sq.occupiedBy === bookend) {
                    return coveredSquares;;  //Terminate loop
                }
                if (sq.occupiedBy == undefined) {
                    return [];  //no squares are bookended
                }
                coveredSquares.push(sq);
            }
            return []; //Didn't find a bookend so return no squares;
        }

        //Returns an array representing the squares from the origin to the edge of
        //the board in the given direction, nearest first.
        private fileFrom(origin: Square, dir: Direction) {
            var file: Square[] = [];
            for (var i = 1; i <= 7; i++) { //Maximum of 7 steps in any direction to edge
                var sq: Square;
                switch (dir) {
                    case Direction.north:
                        sq = this.getSquare(origin.col, origin.row - i);
                        break;
                    case Direction.northEast:
                        sq = this.getSquare(origin.col + i, origin.row - i);
                        break;
                    case Direction.east:
                        sq = this.getSquare(origin.col + i, origin.row);
                        break;
                    case Direction.southEast:
                        sq = this.getSquare(origin.col + i, origin.row + i);
                        break;
                    case Direction.south:
                        sq = this.getSquare(origin.col, origin.row + i);
                        break;
                    case Direction.southWest:
                        sq = this.getSquare(origin.col - i, origin.row + i);
                        break;
                    case Direction.west:
                        sq = this.getSquare(origin.col - i, origin.row);
                        break;
                    case Direction.northWest:
                        sq = this.getSquare(origin.col - i, origin.row - i);
                        break;
                }
                if (sq != undefined) {
                    file.push(sq);
                }
            }
            return file;
        }

        public wouldBeValidMove(sq: Square, forPiece: Side): boolean {
            return sq.isEmpty() &&
                this.isAdjacentToPieceOfOppositeSide(sq, forPiece) &&
                this.allSquaresThatWouldBeFlippedBy(sq, forPiece).length > 0;
        }

        private isAdjacentToPieceOfOppositeSide(sq: Square, side: Side): boolean {
            const otherSide = oppositeSideTo(side);
            for (var col: number = sq.col - 1; col <= sq.col + 1; col++) {
                for (var row: number = sq.row - 1; row <= sq.row + 1; row++) {
                    const neighbour = this.getSquare(col, row);
                    if (neighbour != undefined &&
                        neighbour != sq && 
                        neighbour.occupiedBy == otherSide) return true; //exit loops early!
                }
            }
            return false; // as no match found
        }
    }

    export class GameMaster {

        public constructor(public board) {
            this.sideToGoNext = Side.white;
        }

        public sideToGoNext: Side;

        //Returns all squares flipped as a result of the move.
        public placePiece(sq: Square): Square[] {
            if (this.board.wouldBeValidMove(sq, this.sideToGoNext)) {
                const flips: Square[] = this.board.allSquaresThatWouldBeFlippedBy(sq, this.sideToGoNext);
                sq.occupiedBy = this.sideToGoNext;
                _.forEach(flips, sq => sq.occupiedBy = this.sideToGoNext);
                //net turn
                this.sideToGoNext = oppositeSideTo(this.sideToGoNext);
                return flips;
            } else {
                return null;
            }
        }
    }
}
