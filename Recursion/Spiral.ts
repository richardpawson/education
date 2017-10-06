function spiral(size: number, p: Pen) {
    if (size >= 5) {
        p.go(size).turn(90);
        spiral(size - 5, p);
    }
}

let pen = new Pen("mycanvas");
pen.jump(250, 250);

spiral(200, pen);

pen.draw();