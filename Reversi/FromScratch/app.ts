const squareSide: number = 60;

var canvas: HTMLCanvasElement;
var renderer: CanvasRenderingContext2D;

import Square = model.Square;
import Board = model.Board;

window.onload = function () {
    canvas = document.getElementsByTagName("canvas")[0];
    renderer = canvas.getContext("2d");

    var board = new Board();
    drawing.drawBoard(board, renderer);
}