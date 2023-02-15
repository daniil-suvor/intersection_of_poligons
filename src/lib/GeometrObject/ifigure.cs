using segment;
using triangle;
using vector;

public interface IFigure {
    public bool areIntersected(Vector vec);
    public bool areIntersected(Triangle tri);
    public bool areIntersected(Segment seg);
    public bool areIntersected(IFigure obj) {
        return obj.areIntersected(this);
    }
}
