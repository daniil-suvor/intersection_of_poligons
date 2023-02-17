using segment;
using triangle;
using vector;

public interface IPoligon {
    public bool areIntersected(in Vector vec);
    public bool areIntersected(in Triangle tri);
    public bool areIntersected(in Segment seg);
    public bool areIntersected(in IPoligon obj) {
        return obj.areIntersected(this);
    }
}
