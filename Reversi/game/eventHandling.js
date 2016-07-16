var eventHandling;
(function (eventHandling) {
    var Board = model.Board;
    var GameMaster = model.GameMaster;
    var squareSide = 60;
    var pieceRadius = 25;
    //'Global' variables (undesirable!)
    var canvas;
    var renderer;
    var cursorLocation;
    var game;
    var board;
    window.onload = function () {
        canvas = document.getElementsByTagName("canvas")[0];
        renderer = canvas.getContext("2d");
        board = new Board();
        game = new GameMaster(board);
        cursorLocation = board.getSquare(0, 0);
        drawing.drawBoard(board, renderer);
        drawing.drawCursor(cursorLocation, board, game, renderer);
        drawing.updateStatus(game);
    };
    window.onkeydown = function (ke) {
        ke.preventDefault();
        if (game.gameOver)
            return; //Can't continue
        switch (ke.keyCode) {
            case 37:
                moveCursorBy(-1, 0);
                break;
            case 38:
                moveCursorBy(0, -1);
                break;
            case 39:
                moveCursorBy(1, 0);
                break;
            case 40:
                moveCursorBy(0, 1);
                break;
            case 13:
                game.placePiece(cursorLocation);
                drawing.drawBoard(board, renderer);
                drawing.drawCursor(cursorLocation, board, game, renderer);
                drawing.updateStatus(game);
                break;
            case 27:
                game.skipTurn();
                drawing.updateStatus(game);
                break;
        }
    };
    //Moves the cursor by one or more squares relative to the current position
    //horizontally and/or vertically.  But keeps the cursor within the bounds of
    //the board. Increment may be positive or negative number
    function moveCursorBy(cols, rows) {
        var col = keepWithinBounds(cursorLocation.col + cols);
        var row = keepWithinBounds(cursorLocation.row + rows);
        cursorLocation = board.getSquare(col, row);
        drawing.drawBoard(board, renderer);
        drawing.drawCursor(cursorLocation, board, game, renderer);
    }
    //Limits the input value to the range 0-7
    function keepWithinBounds(value) {
        if (value < 0)
            return 0;
        if (value > 7)
            return 7;
        return value;
    }
})(eventHandling || (eventHandling = {}));
//# sourceMappingURL=eventHandling.js.map