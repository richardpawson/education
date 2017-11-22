/**
	Pen
	===
	
	Canvas implementation of turtle graphics found in Logo, at least in spirit, and
	reimagined for a JavaScript world.

	Conventions
	-----------
	
	- coordinate and distance units are expressed in pixels
	- angles are expressed in degrees (mecause most humans don't grok radians)
*/

class Pen {

    constructor(canvasId: string) {
        var canvas: any = document.getElementById(canvasId);
        this.ctx = canvas.getContext("2d");
        this.strokeStyle = this.ctx.strokeStyle = "#000";
        this.lineWidth = this.ctx.lineWidth = 1;
        this.fillStyle = this.ctx.fillStyle = "";
        this.ctx.beginPath();
    }

    private dir: number = -90;
    private x: number = 0;
    private y: number = 0;
    private ctx: CanvasRenderingContext2D;
    private strokeStyle: string;
    private lineWidth: number;
    private fillStyle: string;
    private ox: number = 0;;
    private oy: number = 0;
    private pen: boolean = true;
    private rad: number = Math.PI / 180.0;
    private homes: TurtlePosition[] = [];

    //	  A canvas wrapper, usually this is a solid color, e.g. `fillstyle("#ff0")` will
    //fill your shapes with eye- blinding yellow.
    fillstyle(style: string): Pen {
        this.fillStyle = this.ctx.fillStyle = style;
        return this;
    }

    //Moves forward in the current direction by `distance` pixels.
    go(r: number): Pen {
        var a = this.toRad(this.dir);
        this.x += r * Math.cos(a);
        this.y += r * Math.sin(a);
        if (this.pen)
            this.ctx.lineTo(this.x, this.y);
        else
            this.ctx.moveTo(this.x, this.y);

        return this;
    }

    //The opposite of `go`.
    back(r: number): Pen {
        this.turn(-180);
        this.go(r);
        this.turn(180);
        return this;
    }

    //Turns your current direction.To turn left (counter - clockwise), use negative
    //numbers. To turn right, well, do the opposite.
    turn(deg: number): Pen {
        this.dir += deg;
        this.dir = this.dir % 360;
        return this;
    }

    // Resets the pen's current direction relative to the page (0 degrees is "up").
    angle(a: number): Pen {
        this.dir = a - 90;
        return this;
    }

    //Canvas wrapper which lets you manually specify which of these operations you want
    //to perform on your path (everything since the last `begin` or `jump` call).
    stroke(): Pen {
        this.ctx.stroke();
        return this;
    }

    //Canvas wrapper which lets you manually specify which of these operations you want
    //to perform on your path (everything since the last `begin` or `jump` call).
    fill(): Pen {
        this.ctx.fill();
        return this;
    }

    //Starts a new path in canvas, and looks more Logo- ish along the way.
    begin(): Pen {
        this.ctx.beginPath();
        return this;
    }

    //If you're making a closed shape and you want the corners to match up, put this
    //after you're done drawing your shape but before you call `draw()`.
    close(): Pen {
        this.ctx.closePath();
        return this;
    }

    //    Convenience method which calls `fill()` and `stroke()`, in that order, but only
    //calls each if there is a fill style and stroke style defined, respectively.
    draw(): Pen {
        if (this.fillStyle)
            this.fill();
        if (this.lineWidth)
            this.stroke();
        return this.begin();
    }

    // turns off drawing)
    penup(): Pen {
        this.pen = false;
        return this;
    }

    // turns on drawing
    pendown(): Pen {
        this.pen = true;

        return this;
    }

    // Moves the pen to the specified coordinates, respecting pen state (up or down).
    goto(x: number, y: number): Pen {
        this.x = x;
        this.y = y;

        if (!this.pen)
            this.ctx.moveTo(x, y);
        else
            this.ctx.lineTo(x, y);

        return this;
    }

    //Like `goto` except it will never draw a line to the specified point, and it
    //also quietly calls `begin`.
    jump(x: number, y: number): Pen {
        this.ctx.beginPath();
        var p = this.pen;
        this.pen = true;
        this.goto(x, y);
        this.pen = p;
        return this;
    }

    //Makes a relative move using the coordinate system
    up(r: number): Pen {
        return this.goto(this.x, this.y - r);
    }

    //Makes a relative move using the coordinate system
    down(r: number): Pen {
        return this.goto(this.x, this.y + r);
    }

    //Makes a relative move using the coordinate system
    left(r: number): Pen {
        return this.goto(this.x - r, this.y);
    }

    //Makes a relative move using the coordinate system
    right(r: number): Pen {
        return this.goto(this.x + r, this.y);
    }

    // Performs a `goto` using polar coordinates which are relative to the last origin set.
    // This is an interesting addition to typical turtle features, and can be a huge time
    // (math) saver.
    polar(r: number, angle: number): Pen {
        var a = this.toRad(angle + this.dir);

        this.x = this.ox + r * Math.cos(a);
        this.y = this.oy + r * Math.sin(a);

        if (this.pen)
            this.ctx.lineTo(this.x, this.y);
        else
            this.ctx.moveTo(this.x, this.y);

        return this;
    }

    // Sets current location as the origin point for `polar()` moves.
    origin(): Pen {
        this.ox = this.x;
        this.oy = this.y;
        return this;
    }

    toRad(d: number): number {
        return d * this.rad;
    }

    // Sets the thickness of the line your pen draws with.
    pensize(size: number): Pen {
        this.lineWidth = this.ctx.lineWidth = size;

        return this;
    }

    // A canvas passthru to set the line style of your pen.For example: `penstyle("#00f")`
    // will turn your pen blue.
    penstyle(str: string): Pen {
        this.ctx.strokeStyle = this.strokeStyle = str;

        return this;
    }

    //Draws, well, text... at the current position. Currently does not support current
    // angle, but it should in the future.
    text(str: string): Pen {
        this.ctx.fillText(str, this.x, this.y);

        return this;
    }

    //    Pass in a typical CSS font spec, e.g. `font("bold 15px Helvetica")`.The color
    //of your font will depend on your last `fillstyle`(defaults to black).
    font(str: string): Pen {
        this.ctx.font = str;
        return this;
    }
};

class TurtlePosition {
    constructor(public x: number, public y: number, public angle: number) { };
};