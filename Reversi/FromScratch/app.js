var squareSide = 60;
var canvas;
var renderer;
var Square = model.Square;
var Board = model.Board;
window.onload = function () {
    canvas = document.getElementsByTagName("canvas")[0];
    renderer = canvas.getContext("2d");
    var board = new Board();
    drawing.drawBoard(board, renderer);
};
//# sourceMappingURL=app.js.map