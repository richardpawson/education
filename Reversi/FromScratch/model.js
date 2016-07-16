/// <reference path="../Scripts/typings/lodash/lodash.d.ts" />
var model;
(function (model) {
    var Square = (function () {
        function Square(col, row) {
            this.col = col;
            this.row = row;
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
        }
        //If the coordinates lie outside of the board boundaries, returns 'undefined'
        Board.prototype.getSquare = function (col, row) {
            return _.find(this.squares, function (sq) { return sq.col === col && sq.row == row; });
        };
        return Board;
    }());
    model.Board = Board;
})(model || (model = {}));
//# sourceMappingURL=model.js.map