var drawing;
(function (drawing) {
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
    }
    drawing.drawBoard = drawBoard;
    function drawSquare(sq, renderer) {
        //Draw background
        renderer.fillStyle = 'green';
        renderer.fillRect(sq.col * squareSide, sq.row * squareSide, squareSide, squareSide);
        //Draw outline
        drawSquareOutline(sq, 'black', renderer);
        //Draw piece if square has one
        if (sq.occupiedBy != null) {
            var colour = getColourForSide(sq.occupiedBy);
            drawPiece(sq, colour, renderer);
        }
    }
    drawing.drawSquare = drawSquare;
    function drawSquareOutline(square, colour, renderer) {
        renderer.strokeStyle = colour;
        renderer.strokeRect(square.col * squareSide, square.row * squareSide, squareSide, squareSide);
    }
    drawing.drawSquareOutline = drawSquareOutline;
    function drawPiece(sq, colour, renderer) {
        var centreX = sq.col * squareSide + squareSide / 2;
        var centerY = sq.row * squareSide + squareSide / 2;
        renderer.fillStyle = colour;
        renderer.beginPath();
        renderer.arc(centreX, centerY, pieceRadius, 0, 2 * Math.PI);
        renderer.fill();
    }
    drawing.drawPiece = drawPiece;
    function getColourForSide(side) {
        return side === Side.black ? 'black' : 'white';
    }
    drawing.getColourForSide = getColourForSide;
    function drawCursor(location, board, game, renderer) {
        var colour = board.wouldBeValidMove(location, game.turn) ? 'yellow' : 'red';
        drawSquareOutline(location, colour, renderer);
    }
    drawing.drawCursor = drawCursor;
    function updateStatus(game) {
        document.getElementById("status").innerHTML = game.status;
        document.getElementById("white").innerHTML = game.whiteCount.toString();
        document.getElementById("black").innerHTML = game.blackCount.toString();
    }
    drawing.updateStatus = updateStatus;
})(drawing || (drawing = {}));
//# sourceMappingURL=drawing.js.map