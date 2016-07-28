const squareSide: number = 60;

var canvas: HTMLCanvasElement;
var renderer: CanvasRenderingContext2D;

import Square = model.Square;

window.onload = function () {
    canvas = document.getElementsByTagName("canvas")[0];
    renderer = canvas.getContext("2d");

    //Draw background
    renderer.fillStyle = 'green';
    renderer.fillRect(0, 0, 480, 480);
    //Draw outline
    renderer.strokeStyle = 'black';
    renderer.strokeRect(0, 0, 480, 480);
    var sq = new Square(0, 0);
    drawing.drawSquare(sq, renderer);
    sq = new Square(0, 1);
    drawing.drawSquare(sq, renderer);
    var sq = new Square(1, 0);
    drawing.drawSquare(sq, renderer);
}
