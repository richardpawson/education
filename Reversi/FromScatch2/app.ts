const squareSide: number = 60;
const pieceRadius = 25;

//Global variables
var canvas: HTMLCanvasElement;
var renderer: CanvasRenderingContext2D;
var board: model.Board;
var cursorLocation: model.Square;
var game: model.GameManager;

window.onload = function () {
    canvas = document.getElementsByTagName("canvas")[0];
    renderer = canvas.getContext("2d");
    board = new model.Board();
    game = new model.GameManager(board);
    cursorLocation = board.getSquare(0, 0);
    drawing.updateText(game);
    moveCursorBy(3, 2);
}

function moveCursorBy(cols: number, rows: number) {
    var col = board.keepWithinBounds(cursorLocation.col + cols);
    var row = board.keepWithinBounds(cursorLocation.row + rows);
    cursorLocation = board.getSquare(col, row);
    drawing.drawBoard(board, renderer); //Re-drawing board clears the current cursor
    if (board.wouldBeValidMove(cursorLocation, game.turn)) {
        drawing.drawSquareOutline(cursorLocation, 'yellow', renderer);
        var captured = board.allCapturedSquares(cursorLocation, game.turn);
        _.forEach(captured, n => drawing.drawSquareOutline(n, 'blue', renderer));
    } else {
        drawing.drawSquareOutline(cursorLocation, 'red', renderer);
    }
}

window.onkeydown = function (ke: KeyboardEvent) {
    ke.preventDefault();
    if (game.gameOver) return;  //Can't continue
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
        case 13: // Enter
            game.placePiece(cursorLocation);
            drawing.updateText(game);
            moveCursorBy(0, 0);
            break;
    }
}
