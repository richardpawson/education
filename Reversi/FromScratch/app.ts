const squareSide: number = 60;
const pieceRadius: number = 25;

var canvas: HTMLCanvasElement;
var renderer: CanvasRenderingContext2D;
var cursorLocation: Square;

import Square = model.Square;
import Board = model.Board;

window.onload = function () {
    canvas = document.getElementsByTagName("canvas")[0];
    renderer = canvas.getContext("2d");
    var board = new Board();
    drawing.drawBoard(board, renderer);
    cursorLocation = board.getSquare(0, 0);
    renderer.strokeStyle = 'yellow';
    renderer.strokeRect(cursorLocation.col * squareSide, cursorLocation.row * squareSide, squareSide, squareSide);
    drawing.drawSquareOutline(cursorLocation, 'yellow', renderer);
}