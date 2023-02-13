namespace vector;

static class Constants
{
    public const double compareEpsilon = 1E-15;
    static public Vector zeroVector = new Vector();
}
public class Vector {
    public Vector() : this(0, 0, 0) {}
    public Vector(double x, double y, double z) : this(0, 0, 0, x, y, z) {}
    public Vector(double x0, double y0, double z0, double x1, double y1, double z1) {
        x = x1 - x0;
        y = y1 - y0;
        z = z1 - z0;
    }
    public override bool Equals(object? obj) {
        if (obj == null)
            return false;
        if (obj is Vector v)
            return v == this;
        else
            return false;
    }
    public override int GetHashCode() {
        return (int)(x + y + z);
    }
    public override string ToString() {
        return $"{x}; {y}; {z}";
    }
    public Vector(Vector a) : this(a.x, a.y, a.z) {}

    public double scalarProd(Vector vec) {
        return x*vec.x + y*vec.y + z*vec.z;
    }

    public Vector vectorProd(Vector vec) {
        return new Vector(y*vec.z - z*vec.y, -(x*vec.z - z*vec.x), x*vec.y - y*vec.x);
    }

    public double norma() {
        return Math.Sqrt(this.scalarProd(this));
    }

    public double cos(Vector vec) {
        return this.scalarProd(vec)/(this.norma()*vec.norma());
    }
    
    public static Vector operator + (Vector a, Vector b) {
        return new Vector(a.x + b.x, a.y + b.y, a.z + b.z);
    }
    
    public static Vector operator - (Vector a, Vector b) {
        return new Vector(a.x - b.x, a.y - b.y, a.z - b.z);
    }

    public static Vector operator - (Vector a) {
        return new Vector() - a;
    }
    
    public static Vector operator * (double k, Vector a) {
        return new Vector(a.x*k, a.y*k, a.z*k);
    }
    
    public static Vector operator * (Vector a, double k) {
        return k*a;
    }
    
    public static Vector operator / (Vector a, double k) {
        return a*(1/k);
    }
    
    public static bool operator == (Vector a, Vector b) {
        return ((Math.Abs(a.x - b.x) < Constants.compareEpsilon) && 
                (Math.Abs(a.y - b.y) < Constants.compareEpsilon) && 
                (Math.Abs(a.z - b.z) < Constants.compareEpsilon));
    }
    
    public static bool operator != (Vector a, Vector b) {
        return !(a == b);
    }

    private double x, y, z;
}
