namespace lib;
public class TestLib {
    static public bool AreIntersected(double[] coordinates) {
        foreach(double coor in coordinates) {
            if (coor < 0) {
                return false;
            }
        }
        return true;
    }
}
