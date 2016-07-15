/// <reference path="../Scripts/typings/lodash/lodash.d.ts" />
var model;
(function (model) {
    var Square = (function () {
        function Square(col, row) {
            this.col = col;
            this.row = row;
            this.occupiedBy = null;
        }
        Square.prototype.flipPiece = function () {
            if (this.occupiedBy != null) {
                this.occupiedBy = oppositeSideTo(this.occupiedBy);
            }
        };
        Square.prototype.isEmpty = function () {
            return this.occupiedBy == null;
        };
        Square.prototype.isEdgeSquare = function () {
            return this.col == 0 || this.col == 7 || this.row == 0 || this.row == 7;
        };
        Square.prototype.isCornerSquare = function () {
            return (this.col == 0 || this.col == 7) && (this.row == 0 || this.row == 7);
        };
        return Square;
    }());
    model.Square = Square;
    (function (Side) {
        Side[Side["black"] = 0] = "black";
        Side[Side["white"] = 1] = "white";
    })(model.Side || (model.Side = {}));
    var Side = model.Side;
    function oppositeSideTo(side) {
        switch (side) {
            case Side.black:
                return Side.white;
            case Side.white:
                return Side.black;
        }
    }
    (function (Direction) {
        Direction[Direction["north"] = 0] = "north";
        Direction[Direction["northEast"] = 1] = "northEast";
        Direction[Direction["east"] = 2] = "east";
        Direction[Direction["southEast"] = 3] = "southEast";
        Direction[Direction["south"] = 4] = "south";
        Direction[Direction["southWest"] = 5] = "southWest";
        Direction[Direction["west"] = 6] = "west";
        Direction[Direction["northWest"] = 7] = "northWest";
    })(model.Direction || (model.Direction = {}));
    var Direction = model.Direction;
    var Board = (function () {
        function Board() {
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
        Board.prototype.countPieces = function () {
            return _.countBy(this.squares, function (sq) { return sq.occupiedBy; });
        };
        //If the coordinates lie outside of the board boundaries, returns 'undefined'
        Board.prototype.getSquare = function (col, row) {
            return _.find(this.squares, function (sq) { return sq.col === col && sq.row == row; });
        };
        Board.prototype.allSquaresThatWouldBeFlippedBy = function (placement, piece) {
            var _this = this;
            var results = [];
            _.forEach(Direction, function (d) {
                var toAdd = _this.bookendedSquares(placement, piece, d);
                _.forEach(toAdd, function (sq) { return results.push(sq); });
            });
            return results;
        };
        Board.prototype.bookendedSquares = function (placement, bookend, direction) {
            var coveredSquares = [];
            var file = this.fileFrom(placement, direction);
            for (var i = 0; i < file.length; i++) {
                var sq = file[i];
                if (sq.occupiedBy === bookend) {
                    return coveredSquares;
                    ; //Terminate loop
                }
                if (sq.occupiedBy == undefined) {
                    return []; //no squares are bookended
                }
                coveredSquares.push(sq);
            }
            return []; //Didn't find a bookend so return no squares;
        };
        //Returns an array representing the squares from the origin to the edge of
        //the board in the given direction, nearest first.
        Board.prototype.fileFrom = function (origin, dir) {
            var file = [];
            for (var i = 1; i <= 7; i++) {
                var sq;
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
        };
        Board.prototype.wouldBeValidMove = function (sq, forPiece) {
            return sq.isEmpty() &&
                this.isAdjacentToPieceOfOppositeSide(sq, forPiece) &&
                this.allSquaresThatWouldBeFlippedBy(sq, forPiece).length > 0;
        };
        Board.prototype.isAdjacentToPieceOfOppositeSide = function (sq, side) {
            var otherSide = oppositeSideTo(side);
            for (var col = sq.col - 1; col <= sq.col + 1; col++) {
                for (var row = sq.row - 1; row <= sq.row + 1; row++) {
                    var neighbour = this.getSquare(col, row);
                    if (neighbour != undefined &&
                        neighbour != sq &&
                        neighbour.occupiedBy == otherSide)
                        return true; //exit loops early!
                }
            }
            return false; // as no match found
        };
        return Board;
    }());
    model.Board = Board;
    var GameMaster = (function () {
        function GameMaster(board) {
            this.board = board;
            this.sideToGoNext = Side.white;
            this.updateStatus();
        }
        //Returns all squares flipped as a result of the move.
        GameMaster.prototype.placePiece = function (sq) {
            var _this = this;
            if (this.board.wouldBeValidMove(sq, this.sideToGoNext)) {
                var flips = this.board.allSquaresThatWouldBeFlippedBy(sq, this.sideToGoNext);
                sq.occupiedBy = this.sideToGoNext;
                _.forEach(flips, function (sq) { return sq.occupiedBy = _this.sideToGoNext; });
                //net turn
                this.sideToGoNext = oppositeSideTo(this.sideToGoNext);
                this.updateStatus();
            }
        };
        GameMaster.prototype.updateStatus = function () {
            //Update counts
            this.whiteCount = this.board.countPieces()[Side.white];
            this.blackCount = this.board.countPieces()[Side.black];
            //Update status message
            if ((this.whiteCount + this.blackCount == 64)
                || (this.whiteHasSkippedTurn && this.blackHasSkippedTurn)) {
                this.gameOver = true;
                if (this.whiteCount > this.blackCount) {
                    this.status = 'GAME OVER. White has won!';
                }
                else if (this.whiteCount < this.blackCount) {
                    this.status = 'GAME OVER. Black has won!';
                }
                else {
                    this.status = 'GAME OVER. A draw!';
                }
            }
            else {
                switch (this.sideToGoNext) {
                    case Side.black:
                        this.status = 'Black to play';
                        break;
                    case Side.white:
                        this.status = 'White to play';
                        break;
                }
            }
        };
        GameMaster.prototype.skipTurn = function () {
            if (this.sideToGoNext == Side.white)
                this.whiteHasSkippedTurn = true;
            if (this.sideToGoNext == Side.black)
                this.blackHasSkippedTurn = true;
            this.sideToGoNext = oppositeSideTo(this.sideToGoNext);
            this.updateStatus();
        };
        return GameMaster;
    }());
    model.GameMaster = GameMaster;
})(model || (model = {}));
//# sourceMappingURL=model.js.map