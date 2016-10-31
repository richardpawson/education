function random(min: number, max: number): number {
    const range = max - min;
    return min + Math.floor(Math.random() * range);
}


function fork(length: number, p: Pen) {
    p.penstyle('brown');
    const width = Math.floor(length / 20) + 1;
    p.pensize(width);
    if (length > 10) {
        let trunk = random(length / 4, length / 3);
        let shoot = length - trunk;
        p.go(trunk);
        p.draw();
        let angle = random(10, 60);
        p.turn(angle);
        fork(shoot, p);
        p.turn(-angle);
        angle = random(10, 60);
        p.turn(-angle);
        fork(shoot, p);
        p.turn(angle);
        p.back(trunk);
    }
    else {
        p.penstyle('green')
        p.pensize(5);
        p.go(5);
        p.back(5);
        p.draw();
        p.penstyle('blue');
        p.penstyle('brown');
    }
}

let p = new Pen("mycanvas");
p.jump(250, 250);
p.penstyle('brown');
fork(300, p);
p.draw();
