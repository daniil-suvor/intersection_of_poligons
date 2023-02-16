using segment;
using triangle;
using vector;

public interface IFigure {
    public bool areIntersected(in Vector vec);
    public bool areIntersected(in Triangle tri);
    public bool areIntersected(in Segment seg);
    public bool areIntersected(in IFigure obj) {
        return obj.areIntersected(this);
    }
}
