import Square = model.Square;
import Board = model.Board;

const squareSide: number = 60;
const pieceRadius: number = 25;

var canvas: HTMLCanvasElement;
var renderer: CanvasRenderingContext2D;
var cursorLocation: Square;
var board: Board;

window.onload = function () {
    canvas = document.getElementsByTagName("canvas")[0];
    renderer = canvas.getContext("2d");
    board = new Board();
    cursorLocation = board.getSquare(0, 0);
    moveCursorBy(3, 2);
}


//Moves the cursor by one or more squares relative to the current position
//horizontally and/or vertically.  But keeps the cursor within the bounds of
//the board. Increment may be positive or negative number
function moveCursorBy(cols: number, rows: number) {
    var col = keepWithinBounds(cursorLocation.col + cols);
    var row = keepWithinBounds(cursorLocation.row + rows);
    cursorLocation = board.getSquare(col, row);
    drawing.drawBoard(board, renderer); //Re-drawing board clears the current cursor
    drawing.drawSquareOutline(cursorLocation, 'yellow', renderer);
}

window.onkeydown = function (ke: KeyboardEvent) {
    ke.preventDefault();
    switch (ke.keyCode) {
        case 37: // left arrow
            moveCursorBy(-1, 0);
            break;
        case 38: // up arrow
            moveCursorBy(0, -1);
            break;
        case 39: // right arrow
            moveCursorBy(1, 0);
            break;
        case 40: // down arrow
            moveCursorBy(0, 1);
            break;
    }
}

//Limits the input value to the range 0-7
function keepWithinBounds(value: number): number {
    if (value < 0) return 0;
    if (value > 7) return 7;
    return value;
}