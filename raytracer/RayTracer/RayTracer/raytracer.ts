class Vector {
    constructor(public x: number, public y: number, public z: number) {}
    times(k: number): Vector { return new Vector(k * this.x, k * this.y, k * this.z); }
    minus(v2: Vector): Vector { return new Vector(this.x - v2.x, this.y - v2.y, this.z - v2.z); }
    plus(v2: Vector): Vector { return new Vector(this.x + v2.x, this.y + v2.y, this.z + v2.z); }
    dotProduct(v2: Vector) { return this.x * v2.x + this.y * v2.y + this.z * v2.z; }
    magnitude(): number { return Math.sqrt(this.x * this.x + this.y * this.y + this.z * this.z); }
    norm(): Vector {
        var mag = this.magnitude();
        var div = (mag === 0) ? Infinity : 1.0 / mag;
        return this.times(div);
    }
    crossProduct(v2: Vector): Vector {
        return new Vector(this.y * v2.z - this.z * v2.y,
                          this.z * v2.x - this.x * v2.z,
                          this.x * v2.y - this.y * v2.x);
    }
}

class Color {
    constructor(public r: number, public g: number, public b: number) {}
    scaleBy(k: number): Color { return new Color(k * this.r, k * this.g, k * this.b); }
    plus(v2: Color): Color { return new Color(this.r + v2.r, this.g + v2.g, this.b + v2.b); }
    times(v2: Color): Color { return new Color(this.r * v2.r, this.g * v2.g, this.b * v2.b); }
    static white = new Color(1.0, 1.0, 1.0);
    static grey = new Color(0.5, 0.5, 0.5);
    static black = new Color(0.0, 0.0, 0.0);
    static background = Color.black;
    static defaultColor = Color.black;
    toDrawingColor(): Color {
        var legalize = d => d > 1 ? 1 : d;
        return new Color(
            Math.floor(legalize(this.r) * 255),
            Math.floor(legalize(this.g) * 255),
            Math.floor(legalize(this.b) * 255));
    }
}

class Camera {
    public forward: Vector;
    public right: Vector;
    public up: Vector;

    constructor(public pos: Vector, lookAt: Vector) {
        var down = new Vector(0.0, -1.0, 0.0);
        this.forward = lookAt.minus(pos).norm();
        this.right = this.forward.crossProduct(down).norm().times(1.5);
        this.up = this.forward.crossProduct(this.right).norm().times(1.5);
    }
}

class Light {

    constructor(public pos: Vector, public color: Color) {
    }
}

class Ray {
    constructor(public start: Vector, public dir: Vector) { }
}

class Intersection {
    constructor(public thing: Thing, public ray: Ray, public dist: number) { }
    pointOfIntersection(): Vector {
       return this.ray.start.plus(this.ray.dir.times(this.dist));
    }
}

interface Surface {
    diffuse: (pos: Vector) => Color;
    specular: (pos: Vector) => Color;
    reflect: (pos: Vector) => number;
    roughness: number;
}

interface Thing {
    intersect(ray: Ray): Intersection;
    normal(pos: Vector):Vector;
    surface: Surface;
}

interface Scene {
    things: Thing[];
    lights: Light[];
    camera: Camera;
}

class Sphere implements Thing {
    public radius2: number;

    constructor(public center: Vector, radius: number, public surface: Surface) {
        this.radius2 = radius * radius;
    }
    normal(pos: Vector): Vector { return pos.minus(this.center).norm(); }
    intersect(ray: Ray): Intersection {
        var eo = this.center.minus(ray.start);
        var v = eo.dotProduct(ray.dir);
        var dist = 0;
        if (v >= 0) {
            var disc = this.radius2 - (eo.dotProduct(eo) - v * v);
            if (disc >= 0) {
                dist = v - Math.sqrt(disc);
            }
        }
        if (dist === 0) {
            return null;
        } else {
            return new Intersection( this, ray,  dist );
        }
    }
}

class Plane implements Thing {
    public normal(pos: Vector): Vector { return this.norm; }
    public intersect(ray: Ray): Intersection {
        var denom = this.norm.dotProduct(ray.dir);
        if (denom > 0) {
            return null;
        } else {
            var dist = (this.norm.dotProduct(ray.start) + this.offset) / (-denom);
            return new Intersection(this,  ray,  dist );
        }
    }
    constructor(protected norm: Vector, protected offset: number, public surface: Surface) {
    }
}

module Surfaces {
    export var shiny: Surface = {
        diffuse: function(pos) { return Color.white; },
        specular: function(pos) { return Color.grey; },
        reflect: function(pos) { return 0.7; },
        roughness: 250
    }
    export var checkerboard: Surface = {
        diffuse: function(pos) {
            if ((Math.floor(pos.z) + Math.floor(pos.x)) % 2 !== 0) {
                return Color.white;
            } else {
                return Color.black;
            }
        },
        specular: function(pos) { return Color.white; },
        reflect: function(pos) {
            if ((Math.floor(pos.z) + Math.floor(pos.x)) % 2 !== 0) {
                return 0.1;
            } else {
                return 0.7;
            }
        },
        roughness: 150
    }

    export var flatWhite: Surface = {
        diffuse: function (pos) { return Color.white; },
        specular: function (pos) { return Color.white; },
        reflect: function (pos) { return 0.1; },
        roughness: 150
    }
}

class RayTracer {
    private maxDepth = 5;

    private intersections(ray: Ray, scene: Scene) {
        var closest = +Infinity;
        var closestInter: Intersection = undefined;
        for (var i in scene.things) {
            var inter = scene.things[i].intersect(ray);
            if (inter != null && inter.dist < closest) {
                closestInter = inter;
                closest = inter.dist;
            }
        }
        return closestInter;
    }

    private testRay(ray: Ray, scene: Scene) {
        var isect = this.intersections(ray, scene);
        if (isect != null) {
            return isect.dist;
        } else {
            return undefined;
        }
    }

    private traceRay(ray: Ray, scene: Scene, depth: number): Color {
        var isect = this.intersections(ray, scene);
        if (isect === undefined) {
            return Color.background;
        } else {
            return this.shade(isect, scene, depth);
        }
    }

    private shade(isect: Intersection, scene: Scene, depth: number) {
        var d = isect.ray.dir;
        var pos = d.times(isect.dist).plus(isect.ray.start);
        var normal = isect.thing.normal(pos);
        var reflectDir = d.minus(normal.times(normal.dotProduct(d)).times(2));
        var naturalColor = Color.background.plus(this.getNaturalColor(isect.thing, pos, normal, reflectDir, scene));
        var reflectedColor = (depth >= this.maxDepth) ? Color.grey : this.getReflectionColor(isect.thing, pos, normal, reflectDir, scene, depth);
        return naturalColor.plus(reflectedColor);
    }

    private getReflectionColor(thing: Thing, pos: Vector, normal: Vector, rd: Vector, scene: Scene, depth: number) {
        return this.traceRay({ start: pos, dir: rd }, scene, depth + 1).scaleBy(thing.surface.reflect(pos));
    }

    private getNaturalColor(thing: Thing, pos: Vector, norm: Vector, rd: Vector, scene: Scene) {
        var addLight = (col, light) => {
            var ldis = light.pos.minus(pos);
            var livec = ldis.norm();
            var neatIsect = this.testRay({ start: pos, dir: livec }, scene);
            var isInShadow = (neatIsect === undefined) ? false : (neatIsect <= ldis.magnitude());
            if (isInShadow) {
                return col;
            } else {
                var illum = livec.dotProduct(norm);
                var lcolor = (illum > 0) ? light.color.scaleBy(illum)
                                          : Color.defaultColor;
                var specular = livec.dotProduct(rd.norm());
                var specColor = (specular > 0) ? light.color.scaleBy(Math.pow(specular, thing.surface.roughness))
                                          : Color.defaultColor;
                return col.plus(thing.surface.diffuse(pos).times(lcolor).plus(specColor.times(thing.surface.specular(pos))));
            }
        }
        return scene.lights.reduce(addLight, Color.defaultColor);
    }

    render(scene, ctx, screenWidth, screenHeight) {
        var getPoint = (x, y, camera) => {
            var recenterX = x =>(x - (screenWidth / 2.0)) / 2.0 / screenWidth;
            var recenterY = y => - (y - (screenHeight / 2.0)) / 2.0 / screenHeight;
            return camera.forward.plus(camera.right.times(recenterX(x)).plus(camera.up.times(recenterY(y)))).norm();
        }
        for (var y = 0; y < screenHeight; y++) {
            for (var x = 0; x < screenWidth; x++) {
                var color = this.traceRay({ start: scene.camera.pos, dir: getPoint(x, y, scene.camera) }, scene, 0);
                var c = color.toDrawingColor();
                ctx.fillStyle = "rgb(" + String(c.r) + ", " + String(c.g) + ", " + String(c.b) + ")";
                ctx.fillRect(x, y, x + 1, y + 1);
            }
        }
    }
}

function defaultScene(): Scene {
    return {
        things: [
            new Plane(new Vector(0.0, 1.0, 0.0), 0.0, Surfaces.checkerboard),
            new Sphere(new Vector(0.0, 1.0, -0.25), 1.0, Surfaces.shiny),
            new Sphere(new Vector(0.5, 0.25, 0), 0.25, Surfaces.shiny),
            new Sphere(new Vector(-1.0, 0.5, 1.5), 0.5, Surfaces.shiny),
        ],
        lights: [
            new Light(new Vector(-2.0, 2.5, 0.0), new Color(0.49, 0.07, 0.07)),
            new Light(new Vector(1.5, 2.5, 1.5), new Color(0.07, 0.07, 0.49)),
            new Light(new Vector(1.5, 2.5, -1.5), new Color(0.07, 0.49, 0.071)),
            new Light(new Vector(0.0, 3.5, 0.0), new Color(0.21, 0.21, 0.35))],

        camera: new Camera(new Vector(3.0, 2.0, 4.0), new Vector(-1.0, 0.5, 0.0))
    };
}

function exec() {
    var canv = document.createElement("canvas");
    canv.width = 256;
    canv.height = 256;
    document.body.appendChild(canv);
    var ctx = canv.getContext("2d");
    var rayTracer = new RayTracer();
    return rayTracer.render(defaultScene(), ctx, 256, 256);
}

exec();
