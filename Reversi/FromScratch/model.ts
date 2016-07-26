/// <reference path="../Scripts/typings/lodash/lodash.d.ts" />

namespace model {

    export class Square {
        constructor(public col: number, public row: number) {
            this.occupiedBy = null;
        }
        public occupiedBy: Side;
    }

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

        public 

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