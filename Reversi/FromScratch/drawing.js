var drawing;
(function (drawing) {
    function drawSquare(sq, renderer) {
        //Draw background
        renderer.fillStyle = 'green';
        renderer.fillRect(sq.col * squareSide, sq.row * squareSide, squareSide, squareSide);
        //Draw outline
        renderer.strokeStyle = 'black';
        renderer.strokeRect(sq.col * squareSide, sq.row * squareSide, squareSide, squareSide);
    }
    drawing.drawSquare = drawSquare;
})(drawing || (drawing = {}));
//# sourceMappingURL=drawing.js.map