/// <reference path="../Scripts/typings/lodash/lodash.d.ts" />

namespace model {

    export class Square {
        constructor(public col: number, public row: number) {
            this.occupiedBy = null;
        }
        public occupiedBy: Side;
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
            this.getSquare(3, 3).occupiedBy = Side.white;
            this.getSquare(4, 4).occupiedBy = Side.white;
            this.getSquare(4, 3).occupiedBy = Side.black;
            this.getSquare(3, 4).occupiedBy = Side.black;
        }

        private squares: Square[];

        //If the coordinates lie outside of the board boundaries, returns 'undefined'
        public getSquare(col: number, row: number): Square {
            return _.find(this.squares, sq => sq.col === col && sq.row == row);
        }

        //Limits the input value to the range 0-7
        public keepWithinBounds(value: number): number {
            if (value < 0) return 0;
            if (value > 7) return 7;
            return value;
        }

        public wouldBeValidMove(sq: Square, side: Side): boolean {
            return sq.occupiedBy == null &&
                this.isAdjacentToPiece(sq, oppositeSideTo(side));
        }


        //Returns all squares (on the board) that are immediate neighbours
        //of the given square  -  between 3 and 8 of them.
        private getAdjacentSquares(sq: Square): Square[] {
            var neighbours: Square[] = [];
            for (var col: number = sq.col - 1; col <= sq.col + 1; col++) {
                for (var row: number = sq.row - 1; row <= sq.row + 1; row++) {
                    var neighbour = this.getSquare(col, row);
                    if (neighbour != undefined && neighbour != sq) {
                        neighbours.push(neighbour);
                    }
                }
            }
            return neighbours;
        }

        private isAdjacentToPiece(sq: Square, piece: Side): boolean {
            var neighbours = this.getAdjacentSquares(sq);
            return _.some(neighbours, sq => sq.occupiedBy == piece);
        }

        //Returns an array representing the line of squares from the given location to the edge of
        //the board in the given direction, nearest first.
        public squaresFrom(location: Square, dir: Direction): Square[] {
            var squares: Square[] = [];
            for (var i = 1; i <= 7; i++) { //Can only be maximum of 7 steps in any direction to edge
                var sq: Square = this.getSquare(location.col, location.row - i);
                var sq: Square;
                switch (dir) {
                    case Direction.north:
                        sq = this.getSquare(location.col, location.row - i);
                        break;
                    case Direction.east:
                        sq = this.getSquare(location.col + i, location.row);
                        break;
                }
                if (sq != undefined) {
                    squares.push(sq);
                }
            }
            return squares;
        }

        public capturedSquares(placement: Square, side: Side, dir: Direction): Square[] {
            var coveredSquares = [];
            var squares = this.squaresFrom(placement, dir);
            for (var i: number = 0; i < squares.length; i++) {
                var sq: Square = squares[i];
                if (sq.occupiedBy == side) {
                    return coveredSquares;;  //Terminate loop
                }
                if (sq.occupiedBy == undefined) {
                    return [];  //no squares are bookended
                }
                coveredSquares.push(sq);
            }
            return []; //Didn't find a bookend so return no squares;
        }

        //Returns a list of all squares that would be captured (ultimely to be flipped)
        //by a given placement on a square
        public allCapturedSquares(placement: Square, side: Side): Square[] {
            var results = [];
            _.forEach(Direction, d => {
                results = results.concat(this.capturedSquares(placement, side, d));
            });
            return results;
        }
    }

    export enum Side { black, white }

    function oppositeSideTo(side: Side): Side {
        return side === Side.black ? Side.white : Side.black;
    }

    export class GameManager {

        public constructor(public board: Board) {
            this.turn = Side.black; //The rules state that Black always moves first
            this.updateStatus();
        }

        public turn: Side;
        public status: string;

        public placePiece(sq: Square): void {
            if (this.board.wouldBeValidMove(sq, this.turn)) {
                sq.occupiedBy = this.turn;
                //Now set the next turn
                this.turn = oppositeSideTo(this.turn);
                this.updateStatus();
            }
        }

        public updateStatus(): void {
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


}