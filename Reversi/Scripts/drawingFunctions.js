var Drawing;
(function (Drawing) {
    var Side = model.Side;
    var squareSide = 60;
    var pieceRadius = 25;
    function drawBoard(board, renderer) {
        for (var col = 0; col <= 7; col++) {
            for (var row = 0; row <= 7; row++) {
                var sq = board.getSquare(col, row);
                drawSquare(sq, renderer);
            }
        }
        renderer.beginPath();
        renderer.strokeStyle = 'black';
        if (game.sideToGoNext === Side.black) {
            renderer.fillStyle = 'black';
        }
        else {
            renderer.fillStyle = 'white';
        }
        //TODO: generalise drawing of piece?
        renderer.arc(540, 30, pieceRadius, 0, 2 * Math.PI);
        renderer.fill();
        renderer.stroke();
    }
    function drawSquareOutline(square, colour, renderer) {
        renderer.strokeStyle = colour;
        renderer.strokeRect(square.col * squareSide, square.row * squareSide, squareSide, squareSide);
    }
    function drawSquare(sq, renderer) {
        renderer.fillStyle = 'green';
        renderer.fillRect(sq.col * squareSide, sq.row * squareSide, squareSide, squareSide);
        drawSquareOutline(sq, 'black');
        switch (sq.occupiedBy) {
            case Side.black:
                renderer.fillStyle = 'black';
                break;
            case Side.white:
                renderer.fillStyle = 'white';
                break;
            case null:
                renderer.fillStyle = 'green';
        }
        renderer.beginPath();
        renderer.arc(sq.col * squareSide + squareSide / 2, sq.row * squareSide + squareSide / 2, pieceRadius, 0, 2 * Math.PI);
        renderer.fill();
    }
    function drawCursor(location, board, game) {
        var colour;
        if (board.wouldBeValidMove(location, game.sideToGoNext)) {
            colour = 'yellow';
        }
        else {
            colour = 'red';
        }
        drawSquareOutline(location, colour);
    }
})(Drawing || (Drawing = {}));
//# sourceMappingURL=drawingFunctions.js.map