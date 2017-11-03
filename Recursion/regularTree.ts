function fork(length: number, p: Pen) {
    p.penstyle('black');
    if (length > 10) {
        let trunk = length / 3;
        let shoot = length - trunk;
        p.go(trunk);
        p.draw();
        let angle = 30;
        p.turn(angle);
        fork(shoot, p);
        p.turn(-angle);
        p.turn(-angle);
        fork(shoot, p);
        p.turn(angle);
        p.back(trunk);
    }
}

let p = new Pen("mycanvas");
p.jump(250, 250);
fork(200, p);
p.draw();
