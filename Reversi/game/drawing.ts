module drawing {
    import Square = model.Square;
    import Board = model.Board;
    import GameMaster = model.GameMaster;
    import Side = model.Side; 

    const squareSide = 60;
    const pieceRadius = 25;

    export function drawBoard(board: Board, renderer: CanvasRenderingContext2D) {
        for (var col: number = 0; col <= 7; col++) {
            for (var row: number = 0; row <= 7; row++) {
                const sq = board.getSquare(col,row);
                drawSquare(sq, renderer);
            }
        }
    }
    export function drawCircularPiece(
        centreX: number,
        centerY: number,
        colour: string,
        renderer: CanvasRenderingContext2D)
    {
        renderer.beginPath();
        renderer.strokeStyle = 'black';
        renderer.fillStyle = colour;
        renderer.arc(centreX, centerY, pieceRadius, 0, 2 * Math.PI);
        renderer.fill();
    }

    export function getColourForSide(side: Side): string {
        switch (side) {
            case Side.black:
                return 'black';
            case Side.white:
                return 'white';
            case null:
                return 'green';
        }
    }

    export function drawSquare(sq: Square, renderer: CanvasRenderingContext2D) {
        //Draw background
        renderer.fillStyle = 'green'
        renderer.fillRect(sq.col * squareSide, sq.row * squareSide, squareSide, squareSide);
        //Draw outline
        drawSquareOutline(sq, 'black', renderer);
        //Draw piece if occupied
        if (sq.occupiedBy != null) {
            var colour: string = getColourForSide(sq.occupiedBy);
            var x: number = sq.col * squareSide + squareSide / 2;
            var y: number = sq.row * squareSide + squareSide / 2;
            drawCircularPiece(x, y, colour, renderer);
        }
    }

    export function drawSquareOutline(square: Square, colour: string, renderer: CanvasRenderingContext2D) {
        renderer.strokeStyle = colour;
        renderer.strokeRect(square.col * squareSide, square.row * squareSide, squareSide, squareSide);
    }


    export function drawCursor(location: Square, board: Board, game: GameMaster, renderer: CanvasRenderingContext2D) {
        var colour: string;
        if (board.wouldBeValidMove(location, game.sideToGoNext)) {
            colour = 'yellow';
        } else {
            colour = 'red';
        }
        drawSquareOutline(location, colour, renderer);
    }

    export function updateStatus(game: GameMaster) {
        document.getElementById("status").innerHTML = game.status;
        document.getElementById("white").innerHTML = game.whiteCount.toString();
        document.getElementById("black").innerHTML = game.blackCount.toString();
    }
} 