namespace segment;

using line;
using vector;

public class Segment : IFigure {
    public Segment(Vector pointA, Vector pointB) {
        basisLine = new Line(pointB - pointA, pointA);
        this.pointA = pointA;
        this.pointB = pointB;
    }

    public bool isCorrect() {
        return basisLine.isCorrect();
    }

    public bool areIntersected(Vector pointCheck) {
        Vector vectorACheck = pointCheck - pointA;
        Vector vectorBCheck = pointCheck - pointB;

        return (pointCheck.areIntersected(pointA) || pointCheck.areIntersected(pointB)) ||
               (basisLine.areIntersected(pointCheck)) && (vectorACheck.scalarProd(vectorBCheck) < 0);
    }

    public bool areIntersected(Segment checkSegment) {
        Vector incPoint;
        return  (checkSegment.areIntersected(pointA) || checkSegment.areIntersected(pointB)) ||
                (basisLine.areIntersected(checkSegment.basisLine, out incPoint)) && 
                (this.areIntersected(incPoint)) && (checkSegment.areIntersected(incPoint));
    }

    public bool areIntersected(IFigure obj) {
        return obj.areIntersected(this);
    }

    public Line BasisLine {
        get => basisLine;
    }

    private Line basisLine;
    private Vector pointA, pointB;
}
