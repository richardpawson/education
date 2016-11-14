let p = new Pen("mycanvas");
p.jump(250, 400);
fork(300, 0.2, 0.4, 10, 40, 10, p);
p.draw();

function fork(size: number,
                minTrunk: number,
                maxTrunk: number,
                minAngle: number,
                maxAngle: number,
                minTwigLength: number,
                p: Pen) {

    if (size > minTwigLength) {
        p.penstyle('brown');
        const trunk = random(size * minTrunk, size * maxTrunk);
        const width = Math.floor(trunk / 10) + 1;
        p.pensize(width);
        const shoot = size - trunk;
        p.go(trunk);
        p.draw();
        let angle = random(minAngle, maxAngle);
        p.turn(angle);
        fork(shoot, minTrunk, maxTrunk, minAngle, maxAngle, minTwigLength, p);
        p.turn(-angle);
        angle = random(minAngle, maxAngle);
        p.turn(-angle);
        fork(shoot, minTrunk, maxTrunk, minAngle, maxAngle, minTwigLength, p);
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

function random(min: number, max: number): number {
    const range = max - min;
    return Math.floor(min) + Math.floor(Math.random() * range);
}

