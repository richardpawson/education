//class Disc extends Plane {
//    constructor(private center: Vector, private radius: number, protected norm: Vector, protected offset: number, public surface: Surface) {
//        super(norm, offset, surface);
//    }

//    public intersect(ray: Ray): Intersection {
//        var intersect = super.intersect(ray);
//        if (intersect == null) return null;
//        var point = intersect.pointOfIntersection();
//        var distFromCentre = point.minus(this.center).magnitude();
//        if (distFromCentre > this.radius) {
//            return null;
//        } else {
//            return intersect;
//        }
//    }
//}

//Code to add a disc into defaultScene (with just a Plane):
//new Disc(new Vector(0.0, 0.0, 0.0), 1.0, new Vector(0.0, 1.0, 0.0), -0.9, Surfaces.shiny)
