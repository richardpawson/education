namespace drawing {

    export function drawSquare(sq: model.Square, renderer: CanvasRenderingContext2D) {
        //Draw background
        renderer.fillStyle = 'green';
        renderer.fillRect(sq.col * squareSide, sq.row * squareSide, squareSide, squareSide);
        //Draw outline
        drawSquareOutline(sq, 'black', renderer);
        renderer.strokeRect(sq.col * squareSide, sq.row * squareSide, squareSide, squareSide);
        if (sq.occupiedBy != null) {
            var colour: string = getColourForSide(sq.occupiedBy);
            drawPiece(sq, colour, renderer);
        }
    }

    export function drawBoard(board: model.Board, renderer: CanvasRenderingContext2D) {
        for (var col: number = 0; col <= 7; col++) {
            for (var row: number = 0; row <= 7; row++) {
                const sq = board.getSquare(col, row);
                drawSquare(sq, renderer);
            }
        }
    }

    export function getColourForSide(side: model.Side): string {
        if (side == model.Side.black) {
            return 'black';
        } else {
            return 'white';
        }
    }

    export function drawPiece(
        sq: model.Square,
        colour: string,
        renderer: CanvasRenderingContext2D) {

        var centreX: number = sq.col * squareSide + squareSide / 2;
        var centerY: number = sq.row * squareSide + squareSide / 2;
        renderer.fillStyle = colour;
        renderer.beginPath();
        renderer.arc(centreX, centerY, pieceRadius, 0, 2 * Math.PI);
        renderer.fill();
    }

    export function drawSquareOutline(square: model.Square, colour: string, renderer: CanvasRenderingContext2D) {
        renderer.strokeStyle = colour;
        renderer.strokeRect(square.col * squareSide, square.row * squareSide, squareSide, squareSide);
    }

    export function updateText(game: model.GameManager) {
        document.getElementById("status").innerHTML = game.status;
        document.getElementById("black").innerHTML = board.countPieces(model.Side.black).toString();
        document.getElementById("white").innerHTML = board.countPieces(model.Side.white).toString();

    }

}
