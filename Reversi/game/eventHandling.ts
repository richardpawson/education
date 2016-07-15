module eventHandling {
    import Square = model.Square;
    import Board = model.Board;
    import GameMaster = model.GameMaster;
    import Side = model.Side;

    const squareSide = 60;
    const pieceRadius = 25;

    //'Global' variables (undesirable!)
    var canvas: HTMLCanvasElement;
    var renderer: CanvasRenderingContext2D;
    var cursorLocation: Square;
    var game: GameMaster;
    var board: Board;

    window.onload = function () {
        canvas = document.getElementsByTagName("canvas")[0];
        renderer = canvas.getContext("2d");
        board = new Board();
        game = new GameMaster(board);
        cursorLocation = board.getSquare(0, 0);
        drawing.drawBoard(board, renderer);
        drawing.drawCursor(cursorLocation, board, game, renderer);
        drawing.updateStatus(game);
    }

    window.onkeypress = function (ke: KeyboardEvent) {
        if (game.gameOver) return;  //Can't continue
        switch (ke.keyCode) {
            case 53: //5 - place piece
                game.placePiece(cursorLocation);
                drawing.drawBoard(board, renderer);
                drawing.drawCursor(cursorLocation, board, game, renderer);
                drawing.updateStatus(game);
                break;
            case 52: //4 - left
                moveCursorBy(-1, 0);
                break;
            case 56: //8 - up
                moveCursorBy(0, -1);
                break;
            case 54: //6 - right
                moveCursorBy(1, 0);
                break;
            case 50: //2 - down
                moveCursorBy(0, 1);
                break;
            case 48: //0 -  Pass
                game.skipTurn();
                drawing.updateStatus(game);
                break;
        }
    }

    //Moves the cursor by one or more squares relative to the current position
    //horizontally and/or vertically.  But keeps the cursor within the bounds of
    //the board. Increment may be positive or negative number
    function moveCursorBy(cols: number, rows: number) {
        const col = keepWithinBounds(cursorLocation.col + cols);
        const row = keepWithinBounds(cursorLocation.row + rows);
        cursorLocation = board.getSquare(col, row);
        drawing.drawBoard(board, renderer);
        drawing.drawCursor(cursorLocation, board, game, renderer);
    }

    //Limits the input value to the range 0-7
    function keepWithinBounds(value: number): number {
        if (value < 0) return 0;
        if (value > 7) return 7;
        return value;
    }
} 