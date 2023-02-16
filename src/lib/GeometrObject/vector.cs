namespace vector;
using segment;
using triangle;
using compare;
public class Vector : IFigure {
    public Vector(double x, double y, double z) {
        this.x = x; this.y = y; this.z = z;
    }

    public bool areIntersected(Vector checkPoint) {
        return this == checkPoint;
    }
    public bool areIntersected(Segment checkSegment) {
        return checkSegment.areIntersected(this);
    }

    public bool areIntersected(Triangle checkTriangle) {
        return checkTriangle.areIntersected(this);
    }
    public bool areIntersected(IFigure obj) {
        return obj.areIntersected(this);
    }

    public override bool Equals(object? obj) {
        if (obj == null)
            return false;
        if (obj is Vector v)
            return v == this;
        else
            return false;
    }
    public override int GetHashCode() { // Error Hash to compile without warnings
        return (int)(x + y + z);
    }

     public bool isZero() {
        return ((Compare.doubleCompare(x, 0)) && 
                (Compare.doubleCompare(y, 0)) && 
                (Compare.doubleCompare(z, 0)));
    }
    
    public override string ToString() {
        return $"{x}; {y}; {z}";
    }
    public Vector(Vector a) : this(a.x, a.y, a.z) {}

    public double scalarProd(in Vector vec) {
        return x*vec.x + y*vec.y + z*vec.z;
    }

    public bool areOrthogonal(Vector vec) {
        return Compare.doubleCompare(this.scalarProd(vec), 0);
    }

    public Vector vectorProd(in Vector vec) {
        return new Vector(y*vec.z - z*vec.y, -(x*vec.z - z*vec.x), x*vec.y - y*vec.x);
    }

    public double norma() {
        return Math.Sqrt(this.scalarProd(this));
    }

    public double cos(in Vector vec) {
        return this.scalarProd(vec)/(this.norma()*vec.norma());
    }
    
    public static Vector operator + (in Vector a, in Vector b) {
        return new Vector(a.x + b.x, a.y + b.y, a.z + b.z);
    }
    
    public static Vector operator - (in Vector a, in Vector b) {
        return new Vector(a.x - b.x, a.y - b.y, a.z - b.z);
    }

    public static Vector operator - (in Vector a) {
        return -1*a;
    }
    
    public static Vector operator * (double k, in Vector a) {
        return new Vector(a.x*k, a.y*k, a.z*k);
    }
    
    public static Vector operator * (in Vector a, double k) {
        return k*a;
    }
    
    public static Vector operator / (in Vector a, double k) {
        return a*(1/k);
    }
    
    public static bool operator == (in Vector a, in Vector b) {
        return ((Compare.doubleCompare(a.x, b.x)) && 
                (Compare.doubleCompare(a.y, b.y)) && 
                (Compare.doubleCompare(a.z, b.z)));
    }
    
    public static bool operator != (in Vector a, in Vector b) {
        return !(a == b);
    }

    private double x, y, z;
}
