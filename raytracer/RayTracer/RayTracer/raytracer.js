var Vector = (function () {
    function Vector(x, y, z) {
        this.x = x;
        this.y = y;
        this.z = z;
    }
    Vector.prototype.times = function (k) { return new Vector(k * this.x, k * this.y, k * this.z); };
    Vector.prototype.minus = function (v2) { return new Vector(this.x - v2.x, this.y - v2.y, this.z - v2.z); };
    Vector.prototype.plus = function (v2) { return new Vector(this.x + v2.x, this.y + v2.y, this.z + v2.z); };
    Vector.prototype.dotProduct = function (v2) { return this.x * v2.x + this.y * v2.y + this.z * v2.z; };
    Vector.prototype.magnitude = function () { return Math.sqrt(this.x * this.x + this.y * this.y + this.z * this.z); };
    Vector.prototype.norm = function () {
        var mag = this.magnitude();
        var div = (mag === 0) ? Infinity : 1.0 / mag;
        return this.times(div);
    };
    Vector.prototype.crossProduct = function (v2) {
        return new Vector(this.y * v2.z - this.z * v2.y, this.z * v2.x - this.x * v2.z, this.x * v2.y - this.y * v2.x);
    };
    return Vector;
}());
var Color = (function () {
    function Color(r, g, b) {
        this.r = r;
        this.g = g;
        this.b = b;
    }
    Color.prototype.scaleBy = function (k) { return new Color(k * this.r, k * this.g, k * this.b); };
    Color.prototype.plus = function (v2) { return new Color(this.r + v2.r, this.g + v2.g, this.b + v2.b); };
    Color.prototype.times = function (v2) { return new Color(this.r * v2.r, this.g * v2.g, this.b * v2.b); };
    Color.prototype.toDrawingColor = function () {
        var legalize = function (d) { return d > 1 ? 1 : d; };
        return new Color(Math.floor(legalize(this.r) * 255), Math.floor(legalize(this.g) * 255), Math.floor(legalize(this.b) * 255));
    };
    Color.white = new Color(1.0, 1.0, 1.0);
    Color.grey = new Color(0.5, 0.5, 0.5);
    Color.black = new Color(0.0, 0.0, 0.0);
    Color.background = Color.black;
    Color.defaultColor = Color.black;
    return Color;
}());
var Camera = (function () {
    function Camera(pos, lookAt) {
        this.pos = pos;
        var down = new Vector(0.0, -1.0, 0.0);
        this.forward = lookAt.minus(pos).norm();
        this.right = this.forward.crossProduct(down).norm().times(1.5);
        this.up = this.forward.crossProduct(this.right).norm().times(1.5);
    }
    return Camera;
}());
var Light = (function () {
    function Light(pos, color) {
        this.pos = pos;
        this.color = color;
    }
    return Light;
}());
var Ray = (function () {
    function Ray(start, dir) {
        this.start = start;
        this.dir = dir;
    }
    return Ray;
}());
var Intersection = (function () {
    function Intersection(thing, ray, dist) {
        this.thing = thing;
        this.ray = ray;
        this.dist = dist;
    }
    Intersection.prototype.pointOfIntersection = function () {
        return this.ray.start.plus(this.ray.dir.times(this.dist));
    };
    return Intersection;
}());
var Sphere = (function () {
    function Sphere(center, radius, surface) {
        this.center = center;
        this.surface = surface;
        this.radius2 = radius * radius;
    }
    Sphere.prototype.normal = function (pos) { return pos.minus(this.center).norm(); };
    Sphere.prototype.intersect = function (ray) {
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
        }
        else {
            return new Intersection(this, ray, dist);
        }
    };
    return Sphere;
}());
var Plane = (function () {
    function Plane(norm, offset, surface) {
        this.norm = norm;
        this.offset = offset;
        this.surface = surface;
    }
    Plane.prototype.normal = function (pos) { return this.norm; };
    Plane.prototype.intersect = function (ray) {
        var denom = this.norm.dotProduct(ray.dir);
        if (denom > 0) {
            return null;
        }
        else {
            var dist = (this.norm.dotProduct(ray.start) + this.offset) / (-denom);
            return new Intersection(this, ray, dist);
        }
    };
    return Plane;
}());
var Surfaces;
(function (Surfaces) {
    Surfaces.shiny = {
        diffuse: function (pos) { return Color.white; },
        specular: function (pos) { return Color.grey; },
        reflect: function (pos) { return 0.7; },
        roughness: 250
    };
    Surfaces.checkerboard = {
        diffuse: function (pos) {
            if ((Math.floor(pos.z) + Math.floor(pos.x)) % 2 !== 0) {
                return Color.white;
            }
            else {
                return Color.black;
            }
        },
        specular: function (pos) { return Color.white; },
        reflect: function (pos) {
            if ((Math.floor(pos.z) + Math.floor(pos.x)) % 2 !== 0) {
                return 0.1;
            }
            else {
                return 0.7;
            }
        },
        roughness: 150
    };
    Surfaces.flatWhite = {
        diffuse: function (pos) { return Color.white; },
        specular: function (pos) { return Color.white; },
        reflect: function (pos) { return 0.1; },
        roughness: 150
    };
})(Surfaces || (Surfaces = {}));
var RayTracer = (function () {
    function RayTracer() {
        this.maxDepth = 5;
    }
    RayTracer.prototype.intersections = function (ray, scene) {
        var closest = +Infinity;
        var closestInter = undefined;
        for (var i in scene.things) {
            var inter = scene.things[i].intersect(ray);
            if (inter != null && inter.dist < closest) {
                closestInter = inter;
                closest = inter.dist;
            }
        }
        return closestInter;
    };
    RayTracer.prototype.testRay = function (ray, scene) {
        var isect = this.intersections(ray, scene);
        if (isect != null) {
            return isect.dist;
        }
        else {
            return undefined;
        }
    };
    RayTracer.prototype.traceRay = function (ray, scene, depth) {
        var isect = this.intersections(ray, scene);
        if (isect === undefined) {
            return Color.background;
        }
        else {
            return this.shade(isect, scene, depth);
        }
    };
    RayTracer.prototype.shade = function (isect, scene, depth) {
        var d = isect.ray.dir;
        var pos = d.times(isect.dist).plus(isect.ray.start);
        var normal = isect.thing.normal(pos);
        var reflectDir = d.minus(normal.times(normal.dotProduct(d)).times(2));
        var naturalColor = Color.background.plus(this.getNaturalColor(isect.thing, pos, normal, reflectDir, scene));
        var reflectedColor = (depth >= this.maxDepth) ? Color.grey : this.getReflectionColor(isect.thing, pos, normal, reflectDir, scene, depth);
        return naturalColor.plus(reflectedColor);
    };
    RayTracer.prototype.getReflectionColor = function (thing, pos, normal, rd, scene, depth) {
        return this.traceRay({ start: pos, dir: rd }, scene, depth + 1).scaleBy(thing.surface.reflect(pos));
    };
    RayTracer.prototype.getNaturalColor = function (thing, pos, norm, rd, scene) {
        var _this = this;
        var addLight = function (col, light) {
            var ldis = light.pos.minus(pos);
            var livec = ldis.norm();
            var neatIsect = _this.testRay({ start: pos, dir: livec }, scene);
            var isInShadow = (neatIsect === undefined) ? false : (neatIsect <= ldis.magnitude());
            if (isInShadow) {
                return col;
            }
            else {
                var illum = livec.dotProduct(norm);
                var lcolor = (illum > 0) ? light.color.scaleBy(illum)
                    : Color.defaultColor;
                var specular = livec.dotProduct(rd.norm());
                var specColor = (specular > 0) ? light.color.scaleBy(Math.pow(specular, thing.surface.roughness))
                    : Color.defaultColor;
                return col.plus(thing.surface.diffuse(pos).times(lcolor).plus(specColor.times(thing.surface.specular(pos))));
            }
        };
        return scene.lights.reduce(addLight, Color.defaultColor);
    };
    RayTracer.prototype.render = function (scene, ctx, screenWidth, screenHeight) {
        var getPoint = function (x, y, camera) {
            var recenterX = function (x) { return (x - (screenWidth / 2.0)) / 2.0 / screenWidth; };
            var recenterY = function (y) { return -(y - (screenHeight / 2.0)) / 2.0 / screenHeight; };
            return camera.forward.plus(camera.right.times(recenterX(x)).plus(camera.up.times(recenterY(y)))).norm();
        };
        for (var y = 0; y < screenHeight; y++) {
            for (var x = 0; x < screenWidth; x++) {
                var color = this.traceRay({ start: scene.camera.pos, dir: getPoint(x, y, scene.camera) }, scene, 0);
                var c = color.toDrawingColor();
                ctx.fillStyle = "rgb(" + String(c.r) + ", " + String(c.g) + ", " + String(c.b) + ")";
                ctx.fillRect(x, y, x + 1, y + 1);
            }
        }
    };
    return RayTracer;
}());
function defaultScene() {
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
//# sourceMappingURL=raytracer.js.map