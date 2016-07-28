const squareSide: number = 60;
const pieceRadius = 25;

//Global variables
var canvas: HTMLCanvasElement;
var renderer: CanvasRenderingContext2D;
var board: model.Board;
var cursorLocation: model.Square;

window.onload = function () {
    canvas = document.getElementsByTagName("canvas")[0];
    renderer = canvas.getContext("2d");
    board = new model.Board();
    drawing.drawBoard(board, renderer);
    cursorLocation = board.getSquare(0, 0);
    moveCursorBy(3, 2);
}

function moveCursorBy(cols: number, rows: number) {
    var col = board.keepWithinBounds(cursorLocation.col + cols);
    var row = board.keepWithinBounds(cursorLocation.row + rows);
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
        case 13: // 'Enter'
            placePiece(model.Side.black);
            break;
    }
}

function placePiece(side: model.Side): void {
    cursorLocation.occupiedBy = side;
    moveCursorBy(0, 0);
}

