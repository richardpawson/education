module drawing {
    import Square = model.Square;

    export function drawSquare(sq: Square, renderer: CanvasRenderingContext2D) {
        //Draw background
        renderer.fillStyle = 'green';
        renderer.fillRect(sq.col * squareSide, sq.row * squareSide, squareSide, squareSide);
        //Draw outline
        renderer.strokeStyle = 'black';
        renderer.strokeRect(sq.col * squareSide, sq.row * squareSide, squareSide, squareSide);
    }
}