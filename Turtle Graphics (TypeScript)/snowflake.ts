
function drawSide(lineLength: number, p: Pen) {
    if (lineLength > 5) {
        const aThird = lineLength / 3;
        drawSide(aThird, p);
        p.turn(60);
        drawSide(aThird, p);
        p.turn(-120);
        drawSide(aThird, p)
        p.turn(60);
        drawSide(aThird, p)
    }
    else {
        p.go(lineLength);
    }
}

function drawFlake(size: number, p: Pen) {
   for (let n = 1; n <= 3; n++) {
        drawSide(size, p);
        p.turn(-120);
    }
}

let p = new Pen("mycanvas");
p.jump(250, 250);
drawFlake(200, p);
p.draw();

