import Square = model.Square;
import Board = model.Board;

const squareSide: number = 60;
const pieceRadius = 25;

//Global variables
var canvas: HTMLCanvasElement;
var renderer: CanvasRenderingContext2D;
var board: Board;
var cursorLocation: Square;

window.onload = function () {
    canvas = document.getElementsByTagName("canvas")[0];
    renderer = canvas.getContext("2d");
    board = new Board();
    drawing.drawBoard(board, renderer);
    cursorLocation = board.getSquare(0, 0);
    drawing.drawSquareOutline(cursorLocation, 'yellow', renderer);
}
