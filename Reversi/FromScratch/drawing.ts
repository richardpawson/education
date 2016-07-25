namespace drawing {
    import Square = model.Square;

    export function drawSquare(sq: Square, renderer: CanvasRenderingContext2D) {
        //Draw background
        renderer.fillStyle = 'green';
        renderer.fillRect(sq.col * squareSide, sq.row * squareSide, squareSide, squareSide);
        //Draw outline
        renderer.strokeStyle = 'black';
        renderer.strokeRect(sq.col * squareSide, sq.row * squareSide, squareSide, squareSide);
    }

    export function drawBoard(board: Board, renderer: CanvasRenderingContext2D) {
        for (var col: number = 0; col <= 7; col++) {
            for (var row: number = 0; row <= 7; row++) {
                const sq = board.getSquare(col, row);
                drawSquare(sq, renderer);
            }
        }
    }
}