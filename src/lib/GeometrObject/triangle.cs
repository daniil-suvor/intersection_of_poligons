namespace triangle;
using vector;
using line;
using plane;
using segment;

public class Triangle : IFigure {
    public Triangle(in Vector pointA, in Vector pointB, in Vector pointC) {
        this.pointA = pointA;
        this.pointB = pointB;
        this.pointC = pointC;

        lineAB = new Segment(pointA, pointB);
        lineAC = new Segment(pointA, pointC);
        lineBC = new Segment(pointB, pointC);

        basisPlane = new Plane(pointA, pointB, pointC);
    }

    public bool isCorrect() {
        return basisPlane.isCorrect();
    }

    public double square() {
        return (pointB - pointA).vectorProd(pointC - pointA).norma()/2;
    }

    public bool areIntersected(in Vector point) {
        if ((point.areIntersected(pointA)) || (point.areIntersected(pointB)) || (point.areIntersected(pointC))) {
            return true;
        }

        Line checkLine = new Line(point - pointA, point);
        
        Vector intersectPoint;
        if (checkLine.areIntersected(lineBC.BasisLine, out intersectPoint)) {
            Segment checkSegment = new Segment(pointA, intersectPoint);
            return (lineBC.areIntersected(intersectPoint) && checkSegment.areIntersected(intersectPoint));
        }
        return false;
    }

    public bool areIntersected(Segment checkSegment) {
        return false;
    }
    
    public List<Vector> findPointIntersected(in Line checkLine) {
        List<Vector> res = new List<Vector>();
        Vector point;
        if (lineAB.BasisLine.areIntersected(checkLine, out point))
            res.Add(point);
        if (lineAC.BasisLine.areIntersected(checkLine, out point))
            res.Add(point);
        if (lineBC.BasisLine.areIntersected(checkLine, out point))
            res.Add(point);
        
        return res;
    }

    

    public bool areIntersected(in Triangle checkTriangle) {
        Line intersectLine;
        List<Vector> checkPoints = new List<Vector>();

        if ((this.areIntersected(checkTriangle.pointC)) || (checkTriangle.areIntersected(pointC))) {
            return true;
        }

        if (basisPlane.isMatched(checkTriangle.basisPlane)) {
            checkPoints.AddRange(checkTriangle.findPointIntersected(lineAB.BasisLine));
            checkPoints.AddRange(checkTriangle.findPointIntersected(lineAC.BasisLine));
            checkPoints.AddRange(checkTriangle.findPointIntersected(lineBC.BasisLine));
        } else if (basisPlane.areIntersected(checkTriangle.basisPlane, out intersectLine)) {
            checkPoints.AddRange(this.findPointIntersected(intersectLine));
            checkPoints.AddRange(checkTriangle.findPointIntersected(intersectLine));
        }

        foreach(Vector checkPoint in checkPoints) {
            if (this.areIntersected(checkPoint) && checkTriangle.areIntersected(checkPoint))
                return true;
        }
        return false;
    }

    public bool areIntersected(IFigure obj) {
        return obj.areIntersected(this);
    }

    private Vector pointA, pointB, pointC;
    private Segment lineAB, lineAC, lineBC;
    private Plane basisPlane;
}
