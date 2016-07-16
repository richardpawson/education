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
        return Square;
    }());
    model.Square = Square;
    (function (Side) {
        Side[Side["black"] = 0] = "black";
        Side[Side["white"] = 1] = "white";
    })(model.Side || (model.Side = {}));
    var Side = model.Side;
    function oppositeSideTo(side) {
        return side === Side.black ? Side.white : Side.black;
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
            this.getSquare(3, 3).occupiedBy = Side.white;
            this.getSquare(4, 4).occupiedBy = Side.white;
            this.getSquare(4, 3).occupiedBy = Side.black;
            this.getSquare(3, 4).occupiedBy = Side.black;
        }
        Board.prototype.countPieces = function () {
            return _.countBy(this.squares, function (sq) { return sq.occupiedBy; });
        };
        //If the coordinates lie outside of the board boundaries, returns 'undefined'
        Board.prototype.getSquare = function (col, row) {
            return _.find(this.squares, function (sq) { return sq.col === col && sq.row == row; });
        };
        //Returns a list of all squares that would be captured (ultimely to be flipped)
        //by a given placement on a square
        Board.prototype.allCapturedSquares = function (placement, side) {
            var _this = this;
            var results = [];
            _.forEach(Direction, function (d) {
                var toAdd = _this.capturedSquaresInASingleDirection(placement, side, d);
                _.forEach(toAdd, function (sq) { return results.push(sq); });
            });
            return results;
        };
        Board.prototype.capturedSquaresInASingleDirection = function (placement, side, direction) {
            var coveredSquares = [];
            var file = this.lineFrom(placement, direction);
            for (var i = 0; i < file.length; i++) {
                var sq = file[i];
                if (sq.occupiedBy === side) {
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
        //Returns an array representing the line of squares from the given location to the edge of
        //the board in the given direction, nearest first.
        Board.prototype.lineFrom = function (location, dir) {
            var line = [];
            for (var i = 1; i <= 7; i++) {
                var sq;
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
        };
        Board.prototype.wouldBeValidMove = function (sq, forPiece) {
            return sq.isEmpty() &&
                this.isAdjacentToPieceOfOppositeSide(sq, forPiece) &&
                this.allCapturedSquares(sq, forPiece).length > 0;
        };
        Board.prototype.isAdjacentToPieceOfOppositeSide = function (sq, side) {
            var neighbours = this.getAdjacentSquares(sq);
            return _.some(neighbours, function (sq) { return sq.occupiedBy == oppositeSideTo(side); });
        };
        //Returns all squares (on the board) that are immediate neighbours
        //of the given square  -  between 3 and 8 of them.
        Board.prototype.getAdjacentSquares = function (sq) {
            var neighbours = [];
            for (var col = sq.col - 1; col <= sq.col + 1; col++) {
                for (var row = sq.row - 1; row <= sq.row + 1; row++) {
                    var neighbour = this.getSquare(col, row);
                    if (neighbour != undefined && neighbour != sq) {
                        neighbours.push(neighbour);
                    }
                }
            }
            return neighbours;
        };
        return Board;
    }());
    model.Board = Board;
    var GameMaster = (function () {
        function GameMaster(board) {
            this.board = board;
            this.turn = Side.black;
            this.updateStatus();
        }
        //Returns all squares flipped as a result of the move.
        GameMaster.prototype.placePiece = function (sq) {
            var _this = this;
            if (this.board.wouldBeValidMove(sq, this.turn)) {
                var flips = this.board.allCapturedSquares(sq, this.turn);
                sq.occupiedBy = this.turn;
                _.forEach(flips, function (sq) { return sq.occupiedBy = _this.turn; });
                //net turn
                this.turn = oppositeSideTo(this.turn);
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
                switch (this.turn) {
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
            if (this.turn == Side.white)
                this.whiteHasSkippedTurn = true;
            if (this.turn == Side.black)
                this.blackHasSkippedTurn = true;
            this.turn = oppositeSideTo(this.turn);
            this.updateStatus();
        };
        return GameMaster;
    }());
    model.GameMaster = GameMaster;
})(model || (model = {}));
//# sourceMappingURL=model.js.map