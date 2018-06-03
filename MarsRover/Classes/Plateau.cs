public class Plateau : ILand
{
    public Point CornerPoint { get; private set; }

    public Plateau (Point maxPoint)
    {
        this.CornerPoint = maxPoint;
    }

    public bool IsInsideLand (int x, int y)
    {
        if (x <= CornerPoint.X && y <= CornerPoint.Y)
            return true;
        else
            return false;
    }
}