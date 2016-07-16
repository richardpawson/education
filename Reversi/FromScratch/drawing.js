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
    function drawBoard(board, renderer) {
        for (var col = 0; col <= 7; col++) {
            for (var row = 0; row <= 7; row++) {
                var sq = board.getSquare(col, row);
                drawSquare(sq, renderer);
            }
        }
    }
    drawing.drawBoard = drawBoard;
})(drawing || (drawing = {}));
//# sourceMappingURL=drawing.js.map