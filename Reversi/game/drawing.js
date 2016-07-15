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
    function drawCircularPiece(centreX, centerY, colour, renderer) {
        renderer.beginPath();
        renderer.strokeStyle = 'black';
        renderer.fillStyle = colour;
        renderer.arc(centreX, centerY, pieceRadius, 0, 2 * Math.PI);
        renderer.fill();
    }
    drawing.drawCircularPiece = drawCircularPiece;
    function getColourForSide(side) {
        switch (side) {
            case Side.black:
                return 'black';
            case Side.white:
                return 'white';
            case null:
                return 'green';
        }
    }
    drawing.getColourForSide = getColourForSide;
    function drawSquare(sq, renderer) {
        //Draw background
        renderer.fillStyle = 'green';
        renderer.fillRect(sq.col * squareSide, sq.row * squareSide, squareSide, squareSide);
        //Draw outline
        drawSquareOutline(sq, 'black', renderer);
        //Draw piece if occupied
        if (sq.occupiedBy != null) {
            var colour = getColourForSide(sq.occupiedBy);
            var x = sq.col * squareSide + squareSide / 2;
            var y = sq.row * squareSide + squareSide / 2;
            drawCircularPiece(x, y, colour, renderer);
        }
    }
    drawing.drawSquare = drawSquare;
    function drawSquareOutline(square, colour, renderer) {
        renderer.strokeStyle = colour;
        renderer.strokeRect(square.col * squareSide, square.row * squareSide, squareSide, squareSide);
    }
    drawing.drawSquareOutline = drawSquareOutline;
    function drawCursor(location, board, game, renderer) {
        var colour;
        if (board.wouldBeValidMove(location, game.sideToGoNext)) {
            colour = 'yellow';
        }
        else {
            colour = 'red';
        }
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