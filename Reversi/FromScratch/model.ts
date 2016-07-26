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
    }

    export enum Side { black, white }



    export class GameManager {

        public constructor(board: Board) {
            this.turn = Side.black; //The rules state that Black always moves first
        }

        public turn: Side;

        public placePiece(sq: Square): void {
            sq.occupiedBy = this.turn;
            //Now set the next turn
            if (this.turn == Side.black) {
                this.turn = Side.white
            } else {
                this.turn = Side.black;
            }
        }
    }


}