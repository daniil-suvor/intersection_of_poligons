namespace segment;

using line;
using vector;
using triangle;

public class Segment : IPoligon {
    public Segment(in Vector pointA, in Vector pointB) {
        basisLine = new Line(pointB - pointA, pointA);
        this.pointA = pointA;
        this.pointB = pointB;
        length = (pointB - PointA).scalarProd(pointB - PointA);
    }

    public bool isCorrect() {
        return basisLine.isCorrect();
    }

    public bool areIntersected(in Vector pointCheck) {
        Vector vectorACheck = pointCheck - pointA;
        Vector vectorBCheck = pointCheck - pointB;

        return (pointCheck.areIntersected(pointA) || pointCheck.areIntersected(pointB)) ||
               ((basisLine.areIntersected(pointCheck)) && (vectorACheck.scalarProd(vectorBCheck) < 0));
    }

    public bool areIntersected(in Segment checkSegment) {
        Vector incPoint;
        return  (checkSegment.areIntersected(pointA) || checkSegment.areIntersected(pointB) ||
                 this.areIntersected(checkSegment.pointA) || this.areIntersected(checkSegment.pointB)) ||
                ((basisLine.areIntersected(checkSegment.basisLine, out incPoint)) && 
                (this.areIntersected(incPoint)) && (checkSegment.areIntersected(incPoint)));
    }
    public bool areIntersected(in Triangle checkTriangle) {
        return checkTriangle.areIntersected(this);
    }
    public bool areIntersected(in IPoligon obj) {
        return obj.areIntersected(this);
    }

    public Line BasisLine {
        get => basisLine;
    }

    public Vector PointA {
        get => pointA;
    }

    public decimal Length {
        get => length;
    }

    private Line basisLine;
    private Vector pointA, pointB;
    decimal length;
}
