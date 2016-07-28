/// <reference path="../Scripts/typings/lodash/lodash.d.ts" />
var model;
(function (model) {
    var Square = (function () {
        function Square(col, row) {
            this.col = col;
            this.row = row;
            this.occupiedBy = null;
        }
        return Square;
    }());
    model.Square = Square;
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
        //If the coordinates lie outside of the board boundaries, returns 'undefined'
        Board.prototype.getSquare = function (col, row) {
            return _.find(this.squares, function (sq) { return sq.col === col && sq.row == row; });
        };
        Board.prototype.keepWithinBounds = function (value) {
            if (value < 0)
                return 0;
            if (value > 7)
                return 7;
            return value;
        };
        return Board;
    }());
    model.Board = Board;
    (function (Side) {
        Side[Side["black"] = 0] = "black";
        Side[Side["white"] = 1] = "white";
    })(model.Side || (model.Side = {}));
    var Side = model.Side;
})(model || (model = {}));
//# sourceMappingURL=model.js.map