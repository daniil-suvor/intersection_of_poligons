namespace vector;

using segment;
using triangle;
using compare;

public class Vector : IPoligon {
    public Vector(in decimal x, in decimal y, in decimal z) {
        this.x = x; this.y = y; this.z = z;
    }

    public bool areIntersected(in Vector checkPoint) {
        return this == checkPoint;
    }
    public bool areIntersected(in Segment checkSegment) {
        return checkSegment.areIntersected(this);
    }

    public bool areIntersected(in Triangle checkTriangle) {
        return checkTriangle.areIntersected(this);
    }
    public bool areIntersected(in IPoligon obj) {
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
    public override int GetHashCode() { // Error Hash need for compile without warnings
        return (int)(x + y + z);
    }

    public bool isZero() {
        return ((Compare.decimalCompare(x, 0)) && 
                (Compare.decimalCompare(y, 0)) && 
                (Compare.decimalCompare(z, 0)));
    }
    
    public override string ToString() {
        return $"{x}; {y}; {z}";
    }
    public Vector(Vector a) : this(a.x, a.y, a.z) {}

    public decimal scalarProd(in Vector vec) {
        return x*vec.x + y*vec.y + z*vec.z;
    }

    public bool areOrthogonal(in Vector vec) {
        return Compare.decimalCompare(this.scalarProd(vec), 0);
    }

    public Vector vectorProd(in Vector vec) {
        return new Vector(y*vec.z - z*vec.y, -(x*vec.z - z*vec.x), x*vec.y - y*vec.x);
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
    
    public static Vector operator * (decimal k, in Vector a) {
        return new Vector(a.x*k, a.y*k, a.z*k);
    }
    
    public static Vector operator * (in Vector a, decimal k) {
        return k*a;
    }
    
    public static Vector operator / (in Vector a, decimal k) {
        return a*(1/k);
    }
    
    public static bool operator == (in Vector a, in Vector b) {
        return ((Compare.decimalCompare(a.x, b.x)) && 
                (Compare.decimalCompare(a.y, b.y)) && 
                (Compare.decimalCompare(a.z, b.z)));
    }
    
    public static bool operator != (in Vector a, in Vector b) {
        return !(a == b);
    }

    private decimal x, y, z;
}
